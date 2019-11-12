import React from 'react';
import { connect } from 'react-redux';

class CreateTodo extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null
        };
    }

    render() {
        return (
            <form className="col s3">
                <div className="valign-wrapper">
                    <div className="input-field col s2 align">
                        <input type="text" id="todo" ref="createInput" />
                        <label htmlFor="todo" data-error={this.state.error} className="active">New task</label>
                    </div>
                    <div className="col s1 align">
                        <a className="btn-floating btn-small waves-effect waves-light red" onClick={this.handleCreate.bind(this)}><i className="material-icons">add</i></a>
                    </div>
                </div>
            </form>
        );
    }

    handleCreate(event) {
        event.preventDefault();
        let task = this.refs.createInput.value;
        let isTaskValid = this.validateInput(task);
        if (isTaskValid) {
            this.setState({ error: isTaskValid });
            todo.className = 'validate invalid';
            todo.focus();
            return;
        }
        this.setState({ error: null });
        this.props.onCreateTask(task);
        this.refs.createInput.value = null;
        todo.className = 'validate valid';
        todo.focus();
        todo.blur();
    }

    validateInput(task) {
        if (!task) {
          return 'Please enter a task.';
        } else if (_.find(this.props.todos, todo => todo.task === task)) {
            return 'Task already exists.';
        } else {
          return null;
        }
    }
}

export default connect(
  state => ({
    todos: state
  }),
  dispatch => ({
    onCreateTask: (task) => {
      dispatch({type: "ADD_TASK", payload: task})
    }
  })
)(CreateTodo);
