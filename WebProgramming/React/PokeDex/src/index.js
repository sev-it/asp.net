import React from 'react';
import ReactDOM from 'react-dom';
import 'typeface-roboto';
import './index.css';
import App from './components/App/App';
import { DataStore, ViewStore } from './stores/index';

const viewStore = new ViewStore();
const dataStore = new DataStore(viewStore);

ReactDOM.render(<App dataStore={dataStore} viewStore={viewStore} />, document.getElementById('root'));
