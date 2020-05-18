import React from 'react'
import Register from './Register'
import NotRegistered from './NotRegistered'

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
    isLogged(){
        if(!localStorage.getItem("token")){
            
            this.setState({isLoggedIn: false})
        }
    }
    register = (user) => {
        console.log(user)
    }
    


    render(){
        if(this.props.isInRegisterMode){
        return (
        <div>
            <Register register = {this.props.register}/>
        </div>

)} else {
    return(
        <div>
            <NotRegistered/>
        </div>
    )
}

}}
export default Main