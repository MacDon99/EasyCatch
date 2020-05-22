import React from 'react'
import Register from './Sections/Register'
import ItemsList from './Sections/Products/ItemsList'
import Cart from './Sections/Cart/Cart'
import AddProduct from './Sections/AddProduct'

class Main extends React.Component {

    state = {
        isLoggedIn: null,
        token: null,
        userModel: []
    }

    componentDidMount(){
        if(!localStorage.getItem("token")){
            this.setState({isLoggedIn: false})
        } else 
        this.setState({isLoggedIn: true})
    }
    componentDidUpdate(){

    }

    render(){
        if(this.props.isInRegisterMode){
        return (
        <div>
            <Register register = {this.props.register} errors={this.props.errors} removeErrors={this.props.removeErrors}/>
        </div>

)} else if (this.props.isInAddingProductMode) {
    return(
        <div>
            <AddProduct/>
        </div>
    )
} else if(this.props.isInCartMode){
    return (
        <div>
            <Cart completeOrder={this.props.completeOrder} OrderId={this.props.OrderId}/>
        </div>
    )
} else {
    return (
        <div>
            <ItemsList products={this.props.products} addToCart={this.props.addToCart}/>
        </div>
    )
}

}}
export default Main