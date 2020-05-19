import React from 'react'
import Register from './Register'
import ItemsList from './ItemsList'

class Main extends React.Component {

    state = {
        isLoggedIn: null,
        token: null,
        userModel: []
    }

    componentDidMount(){
        if(!localStorage.getItem("token")){
            this.setState({isLoggedIn: false})
        } else 
        this.setState({isLoggedIn: true})
    }
    componentDidUpdate(){

    }
    register = (user) => {
        console.log(user)
    }
    


    render(){
        if(this.props.isInRegisterMode){
        return (
        <div>
            <Register register = {this.props.register} errors={this.props.errors}/>
        </div>

)} else if (this.props.isInAddingProductMode) {
    return(
        <div>
            AddingProductMode
        </div>
    )
} else {
    return (
        <div>
            <ItemsList/>
        </div>
    )
}

}}
export default Main