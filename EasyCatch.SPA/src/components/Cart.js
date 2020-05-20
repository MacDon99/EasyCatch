import React, { Component } from 'react'
import axios from 'axios'
import Order from './Order'
import { notify } from './Notifications'
export class Cart extends Component {

    componentDidUpdate(){
        if(this.props.OrderId !== 0){
            if(this.state.products.length === 0){
                this.getOrder()
            }

        }
    }
    getOrder = () => {
        const headers = {
            "Authorization": "Bearer " + localStorage.getItem("token")
          }
        axios.get(`https://localhost:5001/api/order/${this.props.OrderId}`, {
            headers: headers
        })
        .then(result => {
            this.setState({
                products: result.data.order.products,
                orderPrice: result.data.order.totalPrice
            })
        })
        .catch(err => {
            console.log("Nie śmigło")
        })
    }
    completeOrder = () => {
        const headers = {
            "Authorization": "Bearer " + localStorage.getItem("token")
          }
        axios.delete(`https://localhost:5001/api/order/${this.props.OrderId}`, {
            headers: headers
        })
        .then(result => {
            notify("You have completed the Order", "success")
            this.props.completeOrder()
        })
        .catch(err => {
            notify("Completing error","error")
        })
    }

    state = {
        products: [],
        orderPrice: 0
    }
    render() {
        if(this.props.OrderId !== 0)
        {
            return (
                <div className = "ui center aligned segment">
                    <h4>This is your Cart</h4>
                    <h5>Order price: {this.state.orderPrice}</h5>
                    <Order products = {this.state.products}/>
                    <button className="ui button centered" onClick={this.completeOrder}>Complete Order</button>
                    {/* <Order products = {this.state.products}/> */}
                </div>
            )
        } else {
            return (
                <div>
                    <h4>This are none items in your Cart</h4>
                </div>
            )
        }
    }
}

export default Cart
