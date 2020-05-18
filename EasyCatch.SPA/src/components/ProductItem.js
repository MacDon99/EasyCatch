import React, { Component } from 'react'

export default class ProductItem extends Component {
    render() {
        return (
            <div>
                {this.props.product.description}
            </div>
        )
    }
}
