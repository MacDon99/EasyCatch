import React from 'react'
import Nav from './Nav'
import Main from './Main'
import axios from 'axios'
import jwt from 'jwt-decode'
import Notification, {notify} from '../components/Notifications/index'
import {BrowserRouter as Router, Redirect} from 'react-router-dom'
 


class App extends React.Component {
  
  
    constructor(props) {
        super(props);
        this.login = this.login.bind(this);
        this.register = this.register.bind(this);
      }
      
      componentDidMount(){
        //odświeżanie komponentu
        localStorage.removeItem("token")
         //this.interval = setInterval(() => this.setState({ time: Date.now() }), 100);
        this.getAllProducts()
        // this.returnToMain()
        this.setState({
          User: {
            login: "None",
            email: "none@none.com",
            fullName: "Test Testowski"},
            Token: null,
            isLoggedIn: false,
            Errors: [],
            RegisterMode: false,
            AddProductMode: false,
            CartMode: false,
            expTime: null,
            UserRole: "None",
            Order: null,
            itemsQuantity: 0,
            orderId: 0,
            redirect: true
        })
    }
    componentWillUnmount() {
        //zwolnienie pamięci
         //clearInterval(this.interval);
    }
      register = (user) => {
        axios.post("https://localhost:5001/api/authentication/register", user)
        .then(result => {
            localStorage.setItem("token", result.data.token)
            const decodedToken = jwt(localStorage.getItem("token"))
            this.setState({
              User: result.data.userModel,
              UserRole: decodedToken.role,
              expTime: new Date(decodedToken.exp*1000).getHours() + ":" +
                       new Date(decodedToken.exp*1000).getMinutes(),
              isLoggedIn: true,
              RegisterMode: false
            })
            notify("You have succesfully registered a new account", "success")
        })
        .catch( (error) => {
            if (error.response) {
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
              notify('You have been logged in', 'success')
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
      localStorage.removeItem("token")
      notify("You have been logged out", "success")
      this.setState({
        User: {
          login: "None",
          email: "none@none.com",
          fullName: "Test Testowski"},
          Token: null,
          isLoggedIn: false,
          Errors: [],
          RegisterMode: false,
          AddProductMode: false,
          CartMode: false,
          expTime: null,
          UserRole: "None",
          Order: null,
          itemsQuantity: 0,
          orderId: 0,
          redirect: true,
          productsQuantity: 0,
      })
          if(this.state.Order != null){
            this.deleteOrder()
          }
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
            this.setState({
              products: result.data
            })
            this.state.products.forEach(element => {
            });
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
                Order: result.data.order,
                orderId: result.data.order.id
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

    deleteOrder = () => {
        const headers = {
            "Authorization": "Bearer " + localStorage.getItem("token")
          }
        axios.delete(`https://localhost:5001/api/order/${this.state.OrderId}`, {
            headers: headers
        })
        .then(result => {
        })
        .catch(err => {
        })
    }

    completeOrder = () => {
      this.setState({
        Order: null,
        orderId: 0,
        itemsQuantity: 0
      })
    }
    loadNewListOfProducts = () => {
      this.setState({
        products: []
      })
      this.getAllProducts()
    }
    
    
    state = {
        User: {
            login: "None",
            email: "none@none.com",
            fullName: "None"},
        Token: null,
        products: [],
        isLoggedIn: false,
        Errors: [],
        expTime: null,
        UserRole: "None",
        Order: null,
        itemsQuantity: 0,
        orderId: 0,
        productsQuantity: null,
    }


    render (){
      if(this.state.redirect){
        return(
              <Router>
                  <div className="ui container">
                      <Notification/>
                      <Nav
                            disableCartMode={this.disableCartView}
                            isInCartMode={this.state.CartMode}
                            itemsQuantity={this.state.itemsQuantity}
                            UserRole={this.state.UserRole}
                            sessionEnds={this.state.expTime}
                            isInRegisterMode={this.state.RegisterMode}
                            isInAddingProductMode={this.state.AddProductMode}
                            AddProductMode={this.AddProductMode}
                            isLoggedIn={this.state.isLoggedIn}
                            User = {this.state.User}
                            login={this.login}
                            logout={this.logout}
                            >
                      </Nav>
                      <Main
                            completeOrder={this.completeOrder}
                            OrderId = {this.state.orderId}
                            isInCartMode={this.state.CartMode}
                            products={this.state.products}
                            addToCart={this.addToCart}
                            removeErrors={this.removeErrors}
                            isInRegisterMode={this.state.RegisterMode}
                            isInAddingProductMode={this.state.AddProductMode}
                            register = {this.register}
                            errors = {this.state.Errors}
                            loadNewListOfProducts={this.loadNewListOfProducts}
                            >
                      </Main>
                  </div>
              </Router>
         )} else {
           return(
             <Router>
                <Redirect to="/"/>
             </Router>
           )
         }
    }
}
export default App