import React from 'react'
import '../nav.css'
import { Link, Redirect} from 'react-router-dom'


class Nav extends React.Component {

    componentDidUpdate(){
        if(this.state.redirect){
            this.setState({
                redirect: false
            })
        }
        // console.log("Redirect: " + this.state.redirect)
        // console.log("LoggedIn: " + this.props.isLoggedIn)
        // console.log("MainItemClass: " + this.state.mainItemClass)
        // console.log("LoginChecker: " + this.state.loginChecker)
        if(this.props.isLoggedIn && this.state.mainItemClass === "item" && this.state.loginChecker){
            this.setState({
                mainItemClass: "item active",
                registerItemClass: "item",
                addingItemClass: "item",
                cartItemClass: "item",
                loginChecker: false,
                redirect: true,
        })
        }
    }
    onChangeLoginReq = (event) => {
        this.setState({loginReq: event.target.value})
    }

    onChangePasReq = (event) => {
        this.setState({passReq: event.target.value})
    }

    logout = () => {
        this.props.logout()
        this.setState({
            mainItemClass: "item active",
            registerItemClass: "item",
            addingItemClass: "item",
            cartItemClass: "item",
            loginChecker: true
    })}

    onRegisterClick = () => {
        if(this.state.registerItemClass === "item")
        {
            this.setState({
                mainItemClass: "item",
                registerItemClass: "item active",
                addingItemClass: "item",
                cartItemClass: "item",
        })
        }
    }
    onMainClick = () => {
        this.setState({
            mainItemClass: "item active",
            registerItemClass: "item",
            addingItemClass: "item",
            cartItemClass: "item",
    })
    }

    login = event => () => {
        this.props.login(this.state.loginReq, this.state.passReq)
    }

    AddProductMode = () => {
        if(this.state.addingItemClass === "item")
        {
            this.setState({
                mainItemClass: "item",
                registerItemClass: "item",
                addingItemClass: "item active",
                cartItemClass: "item",
                loginChecker: false
            })
        }
}
    enableCartMode = () => {
        if(this.state.cartItemClass === "item" ){
            this.setState({
                mainItemClass: "item",
                registerItemClass: "item",
                addingItemClass: "item",
                cartItemClass: "item active",
                loginChecker: false
            })
        }
            //  this.props.enableCartView()
        //  }
    }

    state = {
        loginReq: null,
        passReq: null,
        mainItemClass: "item active",
        registerItemClass: "item",
        addingItemClass: "item",
        cartItemClass: "item",
        redirect: false,
        loginChecker: true,
        itemsQuantity: this.props.Order == null? 0: this.props.Order.products.length
    }

    render(){
        if(this.state.redirect){
            return(
            <Redirect to="/"/>
            )
        }
         if(!this.props.isLoggedIn){
            return(
                <div className="ui menu">
                        <Link to="/">
                            <div className={this.state.mainItemClass} href="#" onClick={this.onMainClick}>Main</div>
                        </Link>
                        <Link to="/Register">
                            <div className={this.state.registerItemClass} onClick={this.onRegisterClick}>Register</div>
                        </Link>
                    <div className="right menu">
                        <div className="ui transparent icon input">
                            <input type="text" placeholder="Login..." onChange={this.onChangeLoginReq}/>
                        </div>
                        <div className="ui transparent icon input">
                            <input type="password" placeholder="Password..." onChange={this.onChangePasReq}/>
                        </div>
                        {/* <Link to="/"> */}
                            <div className="item" onClick={this.login()}>Sign In</div>
                        {/* </Link> */}
                    </div>
                </div>
            )} else if (this.props.isLoggedIn === true && this.props.UserRole!=="Admin") {
            return(
                <div className="ui menu">
                    <Link to="/">
                        <div className={this.state.mainItemClass} onClick={this.onMainClick}>Main</div>
                    </Link>
                        <Link to="/">
                            <div className="item" onClick={this.logout}>Logout</div>
                        </Link>
                        <Link to="/Cart">
                            <div className={this.state.cartItemClass} onClick={this.enableCartMode}><i className="ui cart icon"/>Cart: {this.props.itemsQuantity}</div>
                        </Link>
                    <div className="right menu">
                        <div className="ui transparent icon input">
                            <div className="item">Session ends at: {this.props.sessionEnds}</div>
                        </div>
                        <div className="item">Hi {this.props.User.fullName}</div>
                    </div>
                </div>
            )
    } else if(this.props.isLoggedIn === true && this.props.UserRole === "Admin") {
        return(
            <div className="ui menu">
            <Link to="/">
                <div className={this.state.mainItemClass} onClick={this.onMainClick}>Main</div>
            </Link>
                <Link to="/">
                    <div className="item" onClick={this.logout}>Logout</div>
                </Link>
                <Link to="/AddProduct">
                    <div className={this.state.addingItemClass} onClick={this.AddProductMode}>Add Product</div>
                </Link>
                <Link to="/Cart">
                    <div className={this.state.cartItemClass} onClick={this.enableCartMode}><i className="ui cart icon"/>Cart: {this.props.itemsQuantity}</div>
                </Link>
            <div className="right menu">
                <div className="ui transparent icon input">
                    <div className="item">Session ends at: {this.props.sessionEnds}</div>
                </div>
                <div className="item">Hi {this.props.User.fullName}</div>
            </div>
        </div>
        )
    }
}
}
export default Nav

