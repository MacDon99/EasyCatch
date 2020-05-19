import React, { Component } from 'react'
import styled from 'styled-components'
import ee from 'event-emitter'

const Container = styled.div`
background-color: ${props => props.type};
color: white;
padding: 16px;
position: absolute;
top: ${props => props.top}px;
right:16px;
z-index: 999;
transition: top 0.5s ease;
border: 1px solid black;

> i {
    margin-left: 8px;
}

`;

const emitter = new ee()

export const notify = (msg, type) => {
    emitter.emit('notification', msg, type)
}

// export const notifySuccess = () => {

// }

export default class index extends Component {
    constructor(props)
    {
        super(props)
        this.state = {
            top: -100,
            msg: '',
            type: '',
            icon: '',

        }

        this.timeout = null

        emitter.on('notification', (msg, type) => {
            this.onShow(msg)
            switch(type){
                case "error":{
                    this.setState({
                        type: "#f00",
                        icon: "x icon"
                    })
                    break;
                }
                case 'success':{
                    this.setState({
                        type: "#0cc413",
                        icon: "thumbs up icon"
                    })
                    break;
                }
                default:{
                    console.log(type)
                    this.setState({
                        type: "#444"
                    })
                }
            }
        })
    }
    onShow = (msg) => {
        if(this.timeout){
            clearTimeout(this.timeout)
            this.setState({top: -100}, () => {
                this.timeout = setTimeout(() => {
                    this.showNotification(msg)
                }, 0)
            })
        } else {
            this.showNotification(msg)
        }
    }
    showNotification = (msg) => {
        this.setState({
            top:16,
            msg
        }, () => {
            this.timeout = setTimeout(() => {
                this.setState({
                    top: -100,
                })
            }, 2000)
        }
        )
    }
    render() {
        return (
            <Container top ={this.state.top} type = {this.state.type}><i className={this.state.icon}></i>{this.state.msg}</Container>
        )
    }
}
