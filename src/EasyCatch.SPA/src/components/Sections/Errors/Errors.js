import React, { Component } from 'react'
import Error from './ErrorItem'
import { v4 as newUUID } from 'uuid'

export default class Errors extends Component {
    render() {
            return this.props.errors.map((error) => <h3 key={newUUID()}><Error error = {error}/></h3>)
    }
}
