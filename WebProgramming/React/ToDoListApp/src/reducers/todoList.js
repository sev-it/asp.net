const initialState = [
    {
        task: 'Make react tutorial',
        isCompleted: true
    },
    {
        task: 'eat dinner',
        isCompleted: false
    }
];

function findTodo(state, task) {
  return _.find(state, todo => todo.task === task);
}

export default function todoList(state = initialState, action) {
  if (action.type === "ADD_TASK") {
    return [
      ...state,
      {task: action.payload, isCompleted: false }
    ];
  } else if (action.type === "EDIT_TASK") {
    findTodo(state, action.payload.oldTask).task = action.payload.newTask;
    return [...state];
  } else if (action.type === "DELETE_TASK") {
    _.remove(state, todo => todo.task === action.payload.taskToDelete);
    return [...state];
  } else if (action.type === "TOOGLE_TASK") {
    const foundTodo = findTodo(state, action.payload.task);
    foundTodo.isCompleted = !foundTodo.isCompleted;
    return [...state];
  }
  return state;
}
