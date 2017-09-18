import React from 'react';
import ReactDOM from 'react-dom';
import {createStore} from 'redux'
import App from './App';
import {Provider} from 'react-redux'
import './index.css';
import {BrowserRouter as Router, Route} from 'react-router-dom'
import {Home} from './containers/Home.react'
import {emitSample} from "./actions/courier.react";
import {ApiActionContainer, ApiActionController} from './containers/ApiAction.react'

let store = createStore(emitSample, {})

export const Root = ({store}) => (
    <Provider store={store}>
        <Router>
            <Route path="/" exact component={ApiActionController} />
        </Router>
    </Provider>
)

ReactDOM.render(
    <Root store={store} />,
  document.getElementById('root')
);
