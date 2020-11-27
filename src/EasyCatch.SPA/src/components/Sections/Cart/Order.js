import React, { Component } from 'react'
import OrderItem from './OrderItem'

export class Order extends Component {
    render() {
        return this.props.products.map((product) => <h3 key={product.id}><OrderItem product = {product} deleteProduct={this.props.deleteProduct}/></h3>)
    }
}

export default Order
