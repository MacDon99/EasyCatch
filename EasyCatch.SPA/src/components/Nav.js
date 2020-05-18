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
        this.props.disableProductMode()
        this.props.logout()
        this.setState({mainItemClass: "item active"})
        // this.forceUpdate();
    }
    onRegisterClick = () => {
        this.props.register()
        if(this.state.registerItemClass == "item")
        {
            this.setState({registerItemClass: "item active"})
            this.setState({mainItemClass: "item"})
        } else {
            this.setState({registerItemClass: "item"})
            this.setState({mainItemClass: "item active"})
        }

    }
    onMainClick = () => {
        this.props.returnToMain()
        this.setState({registerItemClass: "item"})
        this.setState({addingItemClass: "item"})
        this.setState({mainItemClass: "item active"})
        this.props.disableProductMode()
    }
    login = event => () => {
        this.setState({registerItemClass: "item"})
        this.setState({mainItemClass: "item active"})
        this.props.login(this.state.loginReq, this.state.passReq)
    }
    AddProductMode = () => {
        if(this.state.addingItemClass == "item")
        {
            this.setState({addingItemClass: "item active"})
            this.setState({mainItemClass: "item"})
        } else {
            this.setState({addingItemClass: "item"})
            this.setState({mainItemClass: "item active"})
        }
        this.props.AddProductMode()
    }
    state = {
        loginReq: null,
        passReq: null,
        mainItemClass: "item active",
        registerItemClass: "item",
        addingItemClass: "item"
    }


    render(){
        if(!localStorage.getItem("token")){
            return(
                <div className="ui menu">
                        <a className={this.state.mainItemClass} href="#" onClick={this.onMainClick}>Main</a>
                        <a className={this.state.registerItemClass} onClick={this.onRegisterClick}>Register</a>
                    <div className="right menu">
                        <div className="ui transparent icon input">
                            <input type="text" placeholder="Login..." onChange={this.onChangeLoginReq}/>
                        </div>
                        <div className="ui transparent icon input">
                            <input type="password" placeholder="Password..." onChange={this.onChangePasReq}/>
                        </div>
                        <a className="item" onClick={this.login()}>Sign In</a>
                    </div>
                </div>
            )} else if (this.props.isLoggedIn == true && this.props.UserRole!="Admin") {
            return(
                <div className="ui menu">
                        <a className="item active" onClick={this.onMainClick}>Main</a>
                        <a className="item" onClick={this.logout}>Logout</a>
                        <a className="item">Cart: 0</a>
                    <div className="right menu">
                        <div className="ui transparent icon input">
                            <a className="item">Session ends at: {this.props.sessionEnds}</a>
                        </div>
                        <a className="item">Hi {this.props.User.fullName}</a>
                    </div>
                </div>
            )
    } else {
        return(
            <div className="ui menu">
                        <a className={this.state.mainItemClass} onClick={this.onMainClick}>Main</a>
                        <a className="item" onClick={this.logout}>Logout</a>
                        <a className={this.state.addingItemClass} onClick={this.AddProductMode}>Add Product</a>
                    <div className="right menu">
                        <div className="ui transparent icon input">
                            <a className="item">Session ends at: {this.props.sessionEnds}</a>
                        </div>
                        <a className="item">Hi {this.props.User.fullName}</a>
                   </div>
            </div>
        )
    }
}
}
export default Nav