import React from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';
import { createStore } from 'redux';
import todoList from './reducers/todoList';
import App from './components/app';

const store = createStore(todoList);
render(
    <Provider store={store}>
      <App/>
    </Provider>,
    document.getElementById('app'));
