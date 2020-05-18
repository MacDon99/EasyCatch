import React from 'react'
import axios from 'axios'
import Products from './Products'

class NotRegistered extends React.Component{

    getAllProducts()
    {
        axios.get("https://localhost:5001/api/product/all")
        .then(result => {
            this.setState({products: result.data})
        })
        .catch(err => {
            console.log(err)
        })
    }
    componentDidMount(){
        this.getAllProducts()
    }

    state = {
        products: []
    }
    render(){
        return(
            <div className = "ui center aligned segment">
                <h4>Welcome to my shop, here is a list of items you can buy</h4>
                <Products products={this.state.products}/>
            </div>
        )
    }
}
export default NotRegistered