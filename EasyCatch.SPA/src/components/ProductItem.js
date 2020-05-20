import React, { Component } from 'react'

export default class ProductItem extends Component {
    componentDidUpdate(){
        // console.log(this.props.product)
    }
    render() {
        return (
            <div>
                <h5>{this.props.product.description}</h5>
                <h6>Price: {this.props.product.price}</h6>
                <img src={this.props.product.photoUrl} alt={this.props.product.name} className="ui medium image centered"></img>
                <div className="ui button" onClick={this.props.addToCart.bind(this, this.props.product.id)}>
                    <div>
                        Add to Cart <i className="shop icon"></i>
                    </div>
                </div>
                <hr/>
            </div>
        )
    }
}
