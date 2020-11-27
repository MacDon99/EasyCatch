import React, { Component } from 'react'

export class OrderItem extends Component {
    // constructor(props) {
    //     super(props);
    //     this.deleteProduct = this.deleteProduct.bind(this);
    //   }
    // deleteProduct = event => (productId) => {
    //     if(productId != null){
    //         this.props.deleteProduct.bind(this, productId)
    //     }
    // }
    render() {
        if(this.props.product.photoUrl[0] === "h")
        {
        return (
            <div>
                <h4>{this.props.product.description}</h4>
                <h5>Price: {this.props.product.price}</h5>
                <img src={this.props.product.photoUrl} alt={this.props.product.name} className="ui small image centered"></img>
                <h5>Quantity: {this.props.product.quantity}</h5>
                <button className="ui button" onClick={this.props.deleteProduct.bind(this, this.props.product.id)}>Delete</button>
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
                <button className="ui button" onClick={this.props.deleteProduct.bind(this, this.props.product.id)}>Delete</button>
                <hr/>
            </div>

        )
    }
    }
}

export default OrderItem
