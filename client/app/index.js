import '@babel/polyfill';

import React from 'react';
import { render } from 'react-dom';

import App from './components/App';

import {Provider } from 'react-redux'
import reducers from './reducers';

import { createStore, applyMiddleware, compose } from 'redux';
import thunk from 'redux-thunk';

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const store = createStore(
    reducers, 
    composeEnhancers(applyMiddleware(thunk)));

render(
    <Provider store={store}>
        <App />
    </Provider>,
    document.querySelector('#root')
);