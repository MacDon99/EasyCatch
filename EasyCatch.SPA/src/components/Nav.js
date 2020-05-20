import React from 'react'
import '../nav.css'

class Nav extends React.Component {

    componentDidUpdate(){
        if(this.props.isLoggedIn && this.state.mainItemClass !== "item active" && this.state.addingItemClass !== "item active"){
            if(!this.props.isInCartMode){
            this.setState({
                mainItemClass: "item active"
            })
        }
    }
    }

    onChangeLoginReq = (event) => {
        this.setState({loginReq: event.target.value})
    }

    onChangePasReq = (event) => {
        this.setState({passReq: event.target.value})
    }

    logout = () => {
        this.props.disableProductMode()
        this.props.logout()
        this.setState({
            mainItemClass: "item active",
            registerItemClass: "item",
            addingItemClass: "item",
            cartItemClass: "item",
    })}

    onRegisterClick = () => {
        this.props.register()
        if(this.state.registerItemClass === "item")
        {
            this.setState({
                mainItemClass: "item",
                registerItemClass: "item active",
                addingItemClass: "item",
                cartItemClass: "item",
        })
        } else {
            this.setState({
                mainItemClass: "item active",
                registerItemClass: "item",
                addingItemClass: "item",
                cartItemClass: "item"
        })
        }

    }
    onMainClick = () => {
        this.props.returnToMain()
        this.setState({
            mainItemClass: "item active",
            registerItemClass: "item",
            addingItemClass: "item",
            cartItemClass: "item",
    })
        this.props.disableProductMode()
        this.props.disableCartMode()
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
        })
        } else {
            this.setState({
                mainItemClass: "item active",
                registerItemClass: "item",
                addingItemClass: "item",
                cartItemClass: "item",
        })
        }
        this.props.AddProductMode()
    }
    enableCartMode = () => {
        if(this.state.cartItemClass === "item" ){
            this.setState({
                mainItemClass: "item",
                registerItemClass: "item",
                addingItemClass: "item",
                cartItemClass: "item active",
            })
            this.props.enableCartView()
        } else {
            this.setState({
                mainItemClass: "item active",
                registerItemClass: "item",
                addingItemClass: "item",
                cartItemClass: "item",
            })
            this.props.returnToMain()
        }
    }

    state = {
        loginReq: null,
        passReq: null,
        mainItemClass: "item active",
        registerItemClass: "item",
        addingItemClass: "item",
        cartItemClass: "item",
        itemsQuantity: this.props.Order == null? 0: this.props.Order.products.length
    }

    render(){
        if(!this.props.isLoggedIn){
            return(
                <div className="ui menu">
                        <div className={this.state.mainItemClass} href="#" onClick={this.onMainClick}>Main</div>
                        <div className={this.state.registerItemClass} onClick={this.onRegisterClick}>Register</div>
                    <div className="right menu">
                        <div className="ui transparent icon input">
                            <input type="text" placeholder="Login..." onChange={this.onChangeLoginReq}/>
                        </div>
                        <div className="ui transparent icon input">
                            <input type="password" placeholder="Password..." onChange={this.onChangePasReq}/>
                        </div>
                        <div className="item" onClick={this.login()}>Sign In</div>
                    </div>
                </div>
            )} else if (this.props.isLoggedIn === true && this.props.UserRole!=="Admin") {
            return(
                <div className="ui menu">
                        <div className={this.state.mainItemClass} onClick={this.onMainClick}>Main</div>
                        <div className="item" onClick={this.logout}>Logout</div>
                        <div className={this.state.cartItemClass} onClick={this.enableCartMode}><i className="ui cart icon"/>Cart: {this.props.itemsQuantity}</div>
                    <div className="right menu">
                        <div className="ui transparent icon input">
                            <div className="item">Session ends at: {this.props.sessionEnds}</div>
                        </div>
                        <div className="item">Hi {this.props.User.fullName}</div>
                    </div>
                </div>
            )
    } else {
        return(
            <div className="ui menu">
                        <div className={this.state.mainItemClass} onClick={this.onMainClick}>Main</div>
                        <div className="item" onClick={this.logout}>Logout</div>
                        <div className={this.state.addingItemClass} onClick={this.AddProductMode}>Add Product</div>
                        <div className={this.state.cartItemClass} onClick={this.enableCartMode}><i className="ui cart icon"/>Cart: {this.props.itemsQuantity}</div>
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