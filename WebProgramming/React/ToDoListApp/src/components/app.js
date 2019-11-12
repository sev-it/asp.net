import React from 'react';
import TodosList from './todos-list';
import CreateTodo from './create-todo.js';
import jQuery from 'jquery';
import Materialize from 'materialize-css';

export default class App extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <h1>React ToDos App</h1>
                <CreateTodo />
                <TodosList />
            </div>
        );
    }
}
