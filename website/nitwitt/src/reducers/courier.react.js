import {Promise} from 'bluebird'

export const backendCalls = (state, action) => {
    switch (action.type) {
        case 'BACKEND_CALL':
            return [
                ...state,
                {
                    endpoint: action.endpoint,
                    method: endpoint.method,
                    result: Promise.resolve(action.promise)
                }
            ]
        case 'SAMPLE':
            return [
                ...state,
                {
                    result: 'Yo Man - courier.react.js'
                }
            ]
    }
}