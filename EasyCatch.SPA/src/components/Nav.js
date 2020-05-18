import React from 'react'

class Nav extends React.Component {


    onChangeLoginReq = (event) => {
        this.setState({loginReq: event.target.value})
    }
    onChangePasReq = (event) => {
        this.setState({passReq: event.target.value})
    }
    login = () => {
        localStorage.setItem("token", "token")
        // this.forceUpdate();
    }
    logout = () => {
        localStorage.removeItem("token");
        // this.forceUpdate();
    }
    state = {
        loginReq: null,
        passReq: null,
    }


    render(){
        if(!localStorage.getItem("token")){
            return(
                <div className="ui menu">
                        <a className="item active" href="#">Main</a>
                        <a className="item" onClick={this.props.register}>Register</a>
                    <div className="right menu">
                        <div className="ui transparent icon input">
                            <input type="text" placeholder="Login..." onChange={this.onChangeLoginReq}/>
                        </div>
                        <div className="ui transparent icon input">
                            <input type="password" placeholder="Password..." onChange={this.onChangePasReq}/>
                        </div>
                        <a className="item" onClick={this.props.login.bind(this, this.state.loginReq, this.state.passReq)}>Sign In</a>
                    </div>
                </div>
            )} else {
            return(
                <div className="ui menu">
                        <a className="item active">Main</a>
                        <a className="item" onClick={this.logout}>Logout</a>
                    <div className="right menu">
                    <a className="item">Hi {this.props.User.fullName}</a>
                    </div>
                </div>
            )
    }
        
}
}
export default Nav