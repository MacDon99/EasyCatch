import React from 'react'
import Nav from './Nav'
import Main from './Main'
import axios from 'axios'
import jwt from 'jwt-decode'



class App extends React.Component {

    constructor(props) {
        super(props);
        this.login = this.login.bind(this);
        this.register = this.register.bind(this);
      }
 
      componentDidMount(){
        //odświeżanie komponentu
        localStorage.removeItem("token")
        this.interval = setInterval(() => this.setState({ time: Date.now() }), 100);
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
        })
        .catch(function (error) {
            if (error.response) {
              // Request made and server responded
              console.log(error.response.data.errors);
            } else if (error.request) {
              // The request was made but no response was received
              console.log(error.request);
            } else {
              // Something happened in setting up the request that triggered an Error
              console.log('Error', error.message);
            }

          })
    }
    login = (loginReq, passReq) => {
        const userToLogin = {
            login: loginReq,
            password: passReq
        }
        console.log(userToLogin)
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
        })
        .catch( (error) => {
            if (error.response) {
              // Request made and server responded
              console.log("Errors: " + error.response.data.errors);
              this.setState({Errors: error.response.data.errors})
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
    }
    moveToRegisterPage = () => {
        this.setState({RegisterMode: !this.state.RegisterMode})
    }
    returnToMain = () => {
      this.setState({RegisterMode: false})
    }
    AddProductMode = () => {
      this.setState({AddProductMode: !this.state.AddProductMode})
    }
    disableProductMode = () => {
      this.setState({AddProductMode: false})
    }

    state = {
        User: {
            login: "None",
            email: "none@none.com",
            fullName: "Test Testowski"},
        Token: null,
        isLoggedIn: false,
        Errors: [],
        RegisterMode: false,
        AddProductMode: false,
        expTime: null,
        UserRole: "None"
    }


    render (){
        return(
         <div className="ui container">
             <Nav UserRole={this.state.UserRole} sessionEnds={this.state.expTime} isInRegisterMode={this.state.RegisterMode} AddProductMode={this.AddProductMode} isLoggedIn={this.state.isLoggedIn} User = {this.state.User} login={this.login} register={this.moveToRegisterPage} returnToMain={this.returnToMain} logout={this.logout} disableProductMode={this.disableProductMode}></Nav>
             <Main isInRegisterMode={this.state.RegisterMode} isInAddingProductMode={this.state.AddProductMode} register = {this.register}></Main>
         </div>)
    }
}
export default App