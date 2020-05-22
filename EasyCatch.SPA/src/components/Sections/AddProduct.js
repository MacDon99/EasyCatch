import React, { Component } from 'react'
import axios from 'axios'
import { notify } from '../Notifications'

export class AddProduct extends Component {
    onChangeHandler=event=>{

        if(event.target.files[0].type === "image/jpeg" || event.target.files[0].type === "image/png"){
            this.setState({
                message: event.target.files[0].name,
                file: event.target.files[0]
            })
        } else {
            notify("Chosen file is not a photo", "error");
        }
    }
    onNameChange = (event) => {
        this.setState({
            name: event.target.value
        })
    }
    onDescriptionChange = (event) => {
        this.setState({
            description: event.target.value
        })
    }
    onPriceChange = (event) => {
        this.setState({
            price: event.target.value
        })
    }
    onQuantityChange = (event) => {
        this.setState({
            quantity: event.target.value
        })
    }
    AddProduct = (event) => {
        event.preventDefault()
        if(this.state.file !== null && this.state.name !== null && this.state.price !== null && this.state.quantity !== null && this.state.description !== null){
        const headers = {
            "Authorization": "Bearer " + localStorage.getItem("token")
          }
        const data = new FormData() 
        data.append('file', this.state.file)
        data.append('name', this.state.name)
        data.append('description', this.state.description)
        data.append('price', this.state.price)
        data.append('quantity', this.state.quantity)

        axios.post("https://localhost:5001/api/product/add", data, {
            headers: headers
        })
        .then(result => {
            notify("You have added a new product!","success")
        })
        .catch((err) => {
        })
    } else {
        notify("Please enter required data.","error");
    }
    }


    state = {
        message: "",
        file: null,
        name: null,
        description:  null,
        price: null,
        quantity: null,
        Errors: []
    }
    render() {
        return (
            <div>
                <form className="ui form">
                <div className="field">
                    <label>Product name</label>
                    <input type="text" name="first-name" placeholder="Name.." onChange={this.onNameChange}/>
                </div>
                <div className="field">
                    <label>Description</label>
                    <input type="text" name="last-name" placeholder="Description..." onChange={this.onDescriptionChange}/>
                </div>
                <div className="field">
                    <label>Price</label>
                    <input type="number" min="0" name="last-name" placeholder="Price..." onChange={this.onPriceChange}/>
                </div>
                <div className="field">
                    <label>Quantity</label>
                    <input type="number" min="0" name="last-name" placeholder="Quantity..." onChange={this.onQuantityChange}/>
                </div>
                <div>
                    <label htmlFor="file" className="ui icon button">
                        <i className="file icon"></i>
                        Open File</label>
                    <input type="file" id="file" style={{display: "none"}} onChange={this.onChangeHandler}/>
                    <label>{this.state.message}</label>
                </div>
                <button className="ui button" type="submit" onClick={this.AddProduct}>Submit</button>
                </form>
            </div>
        )
    }
}

export default AddProduct