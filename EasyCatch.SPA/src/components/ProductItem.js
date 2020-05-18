import React, { Component } from 'react'

export default class ProductItem extends Component {
    render() {
        return (
            <div>
                <h5>{this.props.product.description}</h5>
                <h6>Price: {this.props.product.price}</h6>
                <img src={this.props.product.photoUrl} alt={this.props.product.name} className="ui medium image centered"></img>
                <hr/>
            </div>
        )
    }
}
