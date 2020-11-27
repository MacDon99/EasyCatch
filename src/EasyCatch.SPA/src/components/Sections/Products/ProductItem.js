import React, { Component } from 'react'

export default class ProductItem extends Component {

    render() {
        if(this.props.UserRole !=="Admin"){
                if(this.props.product.photoUrl[0] !== "h")
                {
                return (
                    <div>
                        <h5>{this.props.product.description}</h5>
                        <h6>Price: {this.props.product.price}</h6>
                        <img src={"https://localhost:5001/" + this.props.product.photoUrl} alt={this.props.product.name} className="ui medium image centered"></img>
                        <div className="ui button" onClick={this.props.addToCart.bind(this, this.props.product.id)}>
                            <div>
                                Add to Cart <i className="shop icon"></i>
                            </div>
                        </div>
                        <hr/>
                    </div>
                )
            } else {
                return(
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
        } else {
            if(this.props.product.photoUrl[0] !== "h")
                {
                return (
                    <div>
                        <h5>{this.props.product.description}</h5>
                        <h6>Price: {this.props.product.price}</h6>
                        <img src={"https://localhost:5001/" + this.props.product.photoUrl} alt={this.props.product.name} className="ui medium image centered"></img>
                        <div className="ui button" onClick={this.props.addToCart.bind(this, this.props.product.id)}>
                            <div>
                                Add to Cart <i className="shop icon"></i>
                            </div>
                        </div>
                        <button className="ui button" onClick={this.props.deleteProduct.bind(this, this.props.product.id)}>Delete</button>
                        <hr/>
                    </div>
                )
            } else {
                return(
                    <div>
                        <h5>{this.props.product.description}</h5>
                        <h6>Price: {this.props.product.price}</h6>
                        <img src={this.props.product.photoUrl} alt={this.props.product.name} className="ui medium image centered"></img>
                        <div className="ui button" onClick={this.props.addToCart.bind(this, this.props.product.id)}>
                            <div>
                                Add to Cart <i className="shop icon"></i>
                            </div>
                        </div>
                        <button className="ui button" onClick={this.props.deleteProduct.bind(this, this.props.product.id)}>Delete</button>
                        <hr/>
                    </div>
                )
            }
        }
}
}
