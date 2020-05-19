import React, { Component } from 'react'
import Nav from './Nav'
import Main from './Main'
import axios from 'axios'
import jwt from 'jwt-decode'
import alertify from 'alertifyjs'
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
            // notify('Success')
              notify('You have been logged in', 'success')
            console.log("xdddd")
            // alertify.alert('Alert Title')
        })
        .catch( (error) => {
            if (error.response) {
              // Request made and server responded
              console.log("Errors: " + error.response.data.errors);
              this.setState({Errors: error.response.data.errors})
              notify(error.response.data.errors[0], 'error')
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
            {/* <button onClick={() => notify('this is a notification')}>onClick</button> */}
            <Notification/>
             <Nav UserRole={this.state.UserRole} sessionEnds={this.state.expTime} isInRegisterMode={this.state.RegisterMode} AddProductMode={this.AddProductMode} isLoggedIn={this.state.isLoggedIn} User = {this.state.User} login={this.login} register={this.moveToRegisterPage} returnToMain={this.returnToMain} logout={this.logout} disableProductMode={this.disableProductMode}></Nav>
             <Main isInRegisterMode={this.state.RegisterMode} isInAddingProductMode={this.state.AddProductMode} register = {this.register} errors = {this.state.Errors}></Main>
         </div>)
    }
}
export default App