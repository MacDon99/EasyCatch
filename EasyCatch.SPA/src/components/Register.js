import React from 'react'

class Register extends React.Component{

    onUsernameChange = (event) => {
        this.setState({loginReq: event.target.value})
    }
    onEmailChange = (event) => {
        this.setState({emailReq: event.target.value})
    }
    onPasswordChange = (event) => {
        this.setState({passwordReq: event.target.value})
    }
    onFirstNameChange = (event) => {
        this.setState({firstNameReq: event.target.value})
    }
    onLastNameChange = (event) => {
        this.setState({lastNameReq: event.target.value})
    }
    register = () => {

    }
    state = {
        loginReq: null,
        passwordReq: null,
        emailReq: null,
        firstNameReq: null,
        lastNameReq: null,
    }


    render(){
        const userToRegister = {
            login: this.state.loginReq,
            password: this.state.passwordReq,
            email: this.state.emailReq,
            name: this.state.firstNameReq,
            surname: this.state.lastNameReq
        }
        return(
            <div className = "ui center aligned segment">
                <h4>Create Account</h4>
                <div className="ui three column centered grid">
                <div className="ui column"></div>
                <div className="ui column">
                <div className="ui form">
                    <div className="ui fields center aligned grid">
                            <div className="field ui center aligned grid">
                                <label >Username</label>
                                <input type="text" placeholder="Username" onChange={this.onUsernameChange}/>
                            </div>
                    </div>
                    <div className="fields ">
                        <div className="field ui center aligned grid">
                            <label>E-mail</label>
                            <input type="email" placeholder="E-mail" onChange = {this.onEmailChange}/>
                        </div>
                        <div className="field ui center aligned grid">
                            <label>Password</label>
                            <input type="password" onChange = {this.onPasswordChange}/>
                        </div>
                    </div>
                    <div className="fields">
                        <div className="field">
                            <label>First name</label>
                            <input type="text" placeholder="First Name" onChange = {this.onFirstNameChange}/>
                        </div>
                        <div className="field">
                            <label>Last name</label>
                            <input type="text" placeholder="Last Name" onChange = {this.onLastNameChange}/>
                        </div>
                    </div>

                </div>

                </div>
                <div className="ui column"></div>
                </div>
                <button className="ui basic button" onClick={this.props.register.bind(this, userToRegister)}>
                    <i className="icon user"></i>
                    Register
                </button>
            </div>
        )
    }
}
export default Register