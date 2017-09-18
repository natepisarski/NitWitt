import {Promise} from 'bluebird'

export const callBackend = (endpoint, httpMethod) => {
    return new Promise((resolve, reject) => {
        let request = new XMLHttpRequest
        request.addEventListener("error", reject)
        request.addEventListener("load", resolve)
        request.open(httpMethod, endpoint)
        request.send(null)
    })
}

export const makeBackendCall = (endpoint, method) => {
    return {
        type: 'BACKEND_CALL',
        endpoint,
        method,
        promise: callBackend(endpoint, method)
    }
}

export const emitSample = () => {
    return {
        result: 'Yo Man - courier.react.js'
    }
}
