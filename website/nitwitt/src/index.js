import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import './index.css';
import {BrowserRouter as Router, Route} from 'react-router-dom'
import {Home} from './containers/Home.react'

ReactDOM.render(
    <Router>
        <Route path="/" exact component={Home} />
    </Router>,
  document.getElementById('root')
);
