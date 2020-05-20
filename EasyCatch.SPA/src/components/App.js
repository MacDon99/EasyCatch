import React from 'react'
import Nav from './Nav'
import Main from './Main'
import axios from 'axios'
import jwt from 'jwt-decode'
import Notification, {notify} from '../components/Notifications/index'
 


class App extends React.Component {
  
  
    constructor(props) {
        super(props);
        this.login = this.login.bind(this);
        this.register = this.register.bind(this);
        // module.exports = () => <Alertify />;

      }
      
      componentDidMount(){
        //odświeżanie komponentu
        localStorage.removeItem("token")
        this.interval = setInterval(() => this.setState({ time: Date.now() }), 100);
        this.getAllProducts()
    }
    componentWillUnmount() {
        //zwolnienie pamięci
        clearInterval(this.interval);
    }
      register = (user) => {
        const userToRegister = {
            "login": user.login,
            "password": user.password,
            "email": user.email,
            "name": user.name,
            "surname": user.surname
        }
        
        console.log(userToRegister)
        axios.post("https://localhost:5001/api/authentication/register", user)
        .then(result => {
            this.setState({User: result.data.userModel})
            localStorage.setItem("token", result.data.token)
            const decodedToken = jwt(localStorage.getItem("token"))
            this.setState({UserRole: decodedToken.role})
            this.setState({expTime: new Date(decodedToken.exp*1000).getHours() + ":" +
            new Date(decodedToken.exp*1000).getMinutes()})
            this.setState({isLoggedIn: true})
            this.setState({RegisterMode: false})
            notify("You have succesfully registered a new account", "success")
        })
        .catch( (error) => {
            if (error.response) {
              // Request made and server responded
              // console.log(error.response.data.errors);
              this.setState({
                Errors: error.response.data.errors
              })
              console.log(error.response.data.errors)
              notify("Registration error", "error")

            } else if (error.request) {
              // The request was made but no response was received
              console.log(error.request);
            } else {
              // Something happened in setting up the request that triggered an Error
              console.log('Error', error.message);
            }
          }
          )
    }
    login = (loginReq, passReq) => {
        const userToLogin = {
            login: loginReq,
            password: passReq
        }
        axios
        .post("https://localhost:5001/api/authentication/login", userToLogin)
        .then(result => {
            this.setState({User: result.data.userModel})
            localStorage.setItem("token", result.data.token)
            const decodedToken = jwt(localStorage.getItem("token"))
            this.setState({UserRole: decodedToken.role})
            this.setState({expTime: new Date(decodedToken.exp*1000).getHours() + ":" +
            new Date(decodedToken.exp*1000).getMinutes()})
            this.setState({RegisterMode: false})
            this.setState({isLoggedIn: true})
            // notify('Success')
              notify('You have been logged in', 'success')
            // alertify.alert('Alert Title')
        })
        .catch( (error) => {
            if (error.response) {
              // Request made and server responded
              console.log("Errors: " + error.response.data.errors);
              // this.setState({Errors: error.response.data.errors})
              notify(error.response.data.errors[0], 'error')
              // this.setState({
                // Errors: []
              // })
            } else if (error.request) {
              // The request was made but no response was received
              console.log(error.request);
            } else {
              // Something happened in setting up the request that triggered an Error
              console.log('Error', error.message);
            }

          })
    }
    logout = () => {
      this.setState({isLoggedIn: false})
      localStorage.removeItem("token")
      notify("You have been logged out", "success")
      this.setState({Errors: []})
    }
    moveToRegisterPage = () => {
        this.setState({RegisterMode: !this.state.RegisterMode})
    }
    returnToMain = () => {
      this.setState({RegisterMode: false})
      this.setState({Errors: []})
    }
    AddProductMode = () => {
      this.setState({AddProductMode: !this.state.AddProductMode})
    }
    disableProductMode = () => {
      this.setState({AddProductMode: false})
    }
    removeErrors = () => {
      this.setState({
        Errors: []
      })
    }
    getAllProducts()
    {
        axios.get("https://localhost:5001/api/product/all")
        .then(result => {
            this.setState({products: result.data})
        })
        .catch(err => {
            console.log(err)
        })
    }
    addToCart = (id) => {
      if(this.state.isLoggedIn){
        const headers = {
          "Authorization": "Bearer " + localStorage.getItem("token")
        }
          if(this.state.Order === null){
            axios.get("https:localhost:5001/api/order/createorder", {
              headers: headers
            })
            .then(result => {
              this.setState({
                Order: result.data.order
              })
              axios.patch("https:localhost:5001/api/order/addProduct", {
                orderId: this.state.Order.id,
                productId: id
              }, {
                headers: headers
              })
              .then(result => {
                this.setState({
                  itemsQuantity: this.state.itemsQuantity + 1
                })
                notify("You have added a new item to cart!", "success")
              })
              .catch((err) => {
                console.log(err.response.data)
              })
            })
            .catch((error) => {
              console.log(error)
            })
          } else {
            axios.patch("https:localhost:5001/api/order/addProduct", {
              orderId: this.state.Order.id,
              productId: id
            }, {
              headers: headers
            })
            .then(result => {
              notify("You have added a new item to cart!", "success")
              this.setState({
                itemsQuantity: this.state.itemsQuantity + 1,
                Order: result.data.order
              })
            })
            .catch((err) => {
              console.log(err.response.data)
            })
          }
      } else {
        notify("You have to be logged in", "error")
      }
    }
    getOrderProductsQuantity = () => {
      if(!this.state.Order){
        return 0
      } else {
        return this.state.Order.products.length
      }
    }

    state = {
        User: {
            login: "None",
            email: "none@none.com",
            fullName: "Test Testowski"},
        Token: null,
        products: [],
        isLoggedIn: false,
        Errors: [],
        RegisterMode: false,
        AddProductMode: false,
        expTime: null,
        UserRole: "None",
        Order: null,
        itemsQuantity: 0
    }


    render (){
        return(
         <div className="ui container">
            <Notification/>
             <Nav itemsQuantity={this.state.itemsQuantity} UserRole={this.state.UserRole} sessionEnds={this.state.expTime} isInRegisterMode={this.state.RegisterMode} AddProductMode={this.AddProductMode} isLoggedIn={this.state.isLoggedIn} User = {this.state.User} login={this.login} register={this.moveToRegisterPage} returnToMain={this.returnToMain} logout={this.logout} disableProductMode={this.disableProductMode}></Nav>
             <Main products={this.state.products} addToCart={this.addToCart} removeErrors={this.removeErrors} isInRegisterMode={this.state.RegisterMode} isInAddingProductMode={this.state.AddProductMode} register = {this.register} errors = {this.state.Errors}></Main>
         </div>)
    }
}
export default App