import React from 'react'
import Nav from './Nav'
import Main from './Main'
import axios from 'axios'


class App extends React.Component {

    constructor(props) {
        super(props);
        this.login = this.login.bind(this);
        this.register = this.register.bind(this);
      }
 
      componentDidMount(){
        //odświeżanie komponentu
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
            this.setState({Token: result.data.token})
            this.setState({isLoggedIn: true})
            this.setState({RegisterMode: !this.state.RegisterMode})
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
            this.setState({RegisterMode: !this.state.RegisterMode})
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
    moveToRegisterPage = () => {
        this.setState({RegisterMode: !this.state.RegisterMode})
    }

    state = {
        User: {
            login: "Tes",
            email: "test@email.com",
            fullName: "Test Testowski"},
        Token: null,
        Errors: [],
        RegisterMode: false
    }


    render (){
        return(
         <div className="ui container">
             <Nav igLoggedIn={this.state.isLoggedIn} User = {this.state.User} login={this.login} register={this.moveToRegisterPage}></Nav>
             <Main isInRegisterMode={this.state.RegisterMode} register = {this.register}></Main>
         </div>)
    }
}
export default App