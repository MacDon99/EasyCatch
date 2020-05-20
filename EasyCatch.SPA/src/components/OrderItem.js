import React, { Component } from 'react'

export class OrderItem extends Component {
    render() {
        if(this.props.product.photoUrl[0] === "h")
        {
        return (
            <div>
                <h4>{this.props.product.description}</h4>
                <h5>Price: {this.props.product.price}</h5>
                <img src={this.props.product.photoUrl} alt={this.props.product.name} className="ui small image centered"></img>
                <h5>Quantity: {this.props.product.quantity}</h5>
                <hr/>
            </div>
        )
    } else {
        return (
            <div>
                <h4>{this.props.product.description}</h4>
                <h5>Price: {this.props.product.price}</h5>
                <img src={"https://localhost:5001/" + this.props.product.photoUrl} alt={this.props.product.name} className="ui small image centered"></img>
                <h5>Quantity: {this.props.product.quantity}</h5>
                <hr/>
            </div>

        )
    }
    }
}

export default OrderItem
