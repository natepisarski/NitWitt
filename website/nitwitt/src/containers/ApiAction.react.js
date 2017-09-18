import React from 'react'
import {connect} from 'react-redux'
import {makeBackendCall, emitSample} from "../actions/courier.react";
import {ApiAction} from "../components/ApiActionResult.react";
import {head} from 'lodash'

export class ApiActionContainer extends React.Component {
    constructor(props) {
        super(props)
    }

    render() {
        return (
            <h1 onClick={this.props.onApiCallClick}>You rendered me correctly! {this.props.apiCalls} </h1>
        )
    }
}

const getFirstActiveCall = (samples) => {
    return samples
}

const mapStateToProps = state => {
    return {
        apiCalls: state.result
    }
}

const mapDispatchToProps = dispatch => {
    return {
        onApiCallClick: () => {
            dispatch(emitSample())
        }
    }
}

export const ApiActionController = connect(
    mapStateToProps,
    mapDispatchToProps)(ApiActionContainer)