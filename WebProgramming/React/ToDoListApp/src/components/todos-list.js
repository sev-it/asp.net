import _ from 'lodash';
import React from 'react';
import TodosListHeader from './todos-list-header';
import TodosListItem from './todos-list-item';
import { connect } from 'react-redux';

class TodosList extends React.Component {
    renderItems() {
        const props = _.omit(this.props, 'todos');
        return _.map(this.props.todos, (todo, index) => <TodosListItem key={index} {...todo} />)
    }
    render() {
        return (
          <form className="col s3">
            <div className="valign-wrapper">
              <div className="align">
                <table>
                    <TodosListHeader />
                    <tbody>
                        {this.renderItems()}
                    </tbody>
                </table>
              </div>
            </div>
          </form>
        );
    }
}

export default connect(
  state => ({
    todos: state
  }),
  dispatch => ({})
)(TodosList);
