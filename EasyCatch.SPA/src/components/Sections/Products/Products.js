import React, { Component } from 'react'
import Product from './ProductItem'

export default class Products extends Component {
    render() {
        return this.props.products.map((product) => <h3 key={product.id}><Product product = {product} addToCart={this.props.addToCart}/></h3>)
    }
}
