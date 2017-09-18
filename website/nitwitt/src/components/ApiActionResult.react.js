import React from 'react'
import PropTypes from 'prop-types'

export const ApiAction =  ({onApiCallClick, endpoint, method, result}) => (
    <div>
        <h1 onClick={onApiCallClick}>You've made an API Call!</h1>
        <h3>Your {method} call to {endpoint} has returned:</h3>
        <div style={{backgroundColor: 'lightgray'}}>
            {result}
        </div>
    </div>
)

ApiAction.propTypes = {
    endpoint: PropTypes.string.isRequired,
    method: PropTypes.string.isRequired,
    result: PropTypes.any.isRequired
}