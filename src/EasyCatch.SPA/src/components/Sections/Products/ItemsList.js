import React from 'react'
import Products from './Products'

class ItemsList extends React.Component{
    render(){
        return(
            <div className = "ui center aligned segment">
                <h4>Welcome to my shop, here is a list of items you can buy</h4>
                <Products products={this.props.products} addToCart = {this.props.addToCart} UserRole={this.props.UserRole} deleteProduct={this.props.deleteProduct}/>
            </div>
        )
    }
}
export default ItemsList