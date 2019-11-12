import React from 'react';
import { connect } from 'react-redux';

class TodosListItem extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            isEditing: false
        };
    }

    renderTaskSection() {
        const { task, isCompleted } = this.props;
        const taskStyle = {
            color: isCompleted ? 'green' : 'red',
            cursor: 'pointer'
        };
        if (this.state.isEditing) {
            return (
                <td>
                    <from onSubmit={this.onSaveClick.bind(this)}>
                        <div className="input-field col s2 align">
                            <input
                                type="text"
                                id="taskName"
                                className="validate"
                                defaultValue={task}
                                ref="editInput"
                                autoFocus />
                            <label htmlFor="taskName">
                                New task
                            </label>
                        </div>
                    </from>
                </td>
            );
        }
        return (
            <td style={taskStyle} onClick={this.toogleTask.bind(this)}>
                {task}
            </td>
        );
    }

    renderActionSection() {
        if (this.state.isEditing) {
            return (
                <td>
                    <button onClick={this.onSaveClick.bind(this)}>Save</button>
                    <button onClick={this.onCancelClick.bind(this)}>Cancel</button>
                </td>
            );
        }
        return (
            <td>
                <button onClick={this.onEditClick.bind(this)}>Edit</button>
                <button onClick={this.onDeleteClick.bind(this)}>Delete</button>
            </td>
        );
    }

    render() {
        return (
            <tr>
                {this.renderTaskSection()}
                {this.renderActionSection()}
            </tr>
        );
    }

    onEditClick(event) {
        event.preventDefault();
        this.setState({ isEditing: true });
    }

    onCancelClick(event) {
        event.preventDefault();
        this.setState({ isEditing: false });
    }

    onSaveClick(event) {
        event.preventDefault();
        const oldTask = this.props.task;
        const newTask = this.refs.editInput.value;

        this.props.onEditTask(oldTask, newTask);
        this.setState({ isEditing: false });
    }

    onDeleteClick(event) {
        event.preventDefault();
        this.props.onDeleteTask(this.props.task);
    }

    toogleTask(event) {
      event.preventDefault();
      this.props.onToogleTask(this.props.task);
    }
}

export default connect(
  state => ({}),
  dispatch => ({
    onEditTask: (oldTask, newTask) => {
      dispatch({type: 'EDIT_TASK', payload: {oldTask, newTask}})
    },
    onDeleteTask: (task) => {
      dispatch({type: 'DELETE_TASK', payload: {taskToDelete : task}})
    },
    onToogleTask: (task) => {
      dispatch({type: 'TOOGLE_TASK', payload: {task: task}})
    }
  })
)(TodosListItem);
