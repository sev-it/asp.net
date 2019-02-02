import React, { Component } from "react";
import PropTypes from "prop-types";
import AppHeader from "../AppHeader/AppHeader";
import PokemonOverview from "../PokemonOverview/PokemonsOverview";
import logo from "./img/logo.svg";
import "./css/App.css";
import { observer } from "mobx-react";

@observer
class App extends Component {
  render() {
    const { dataStore, viewStore } = this.props;

    return (
      <div className="app">
        <AppHeader viewStore={viewStore} dataStore={dataStore} />
        {viewStore.loading ? (
          <div>
            <div className="loader-container">
              <img src={logo} className="loader-logo" alt="Загрузка" />
              <p>Загрузка</p>
            </div>      
          </div>
        ) : (
          null
        )}
        <div>
              <PokemonOverview dataStore={dataStore} viewStore={viewStore} />
            </div>
      </div>
    );
  }
}

App.propTypes = {
  viewStore: PropTypes.object.isRequired,
  dataStore: PropTypes.object.isRequired
};

export default App;
