import React, { Component } from 'react'

export class OrderItem extends Component {
    render() {
        return (
            <div>
                <h4>{this.props.product.description}</h4>
                <h5>Price: {this.props.product.price}</h5>
                <img src={this.props.product.photoUrl} alt={this.props.product.name} className="ui small image centered"></img>
                <h5>Quantity: {this.props.product.quantity}</h5>
                <hr/>
            </div>
        )
    }
}

export default OrderItem
