import React from "react";
import PropTypes from "prop-types";
import TableView from "./components/TableView/TableView";
import CardView from "./components/CardView/CardView";
import { observer } from "mobx-react";
import { TABLE_VIEW } from "../../constants/constants";

@observer
class PokemonOverview extends React.Component {
  handleChangePage = (event, page) => {
    this.props.viewStore.setPage(page);
    this.props.dataStore.setPokemonStats();
  };

  handleChangeRowsPerPage = event => {
    this.props.viewStore.setLimit(
      Number(event.target.value),
      this.props.dataStore.pokemonsCount
    );
    this.props.dataStore.setPokemonStats();
  };

  render() {
    const { dataStore, viewStore } = this.props;

    return (
      <>
        {viewStore.view === TABLE_VIEW ? (
          <TableView onChangePage={this.handleChangePage} onChangeRowsPerPage={this.handleChangeRowsPerPage} dataStore={dataStore} viewStore={viewStore} />
        ) : (
          <CardView onChangePage={this.handleChangePage} onChangeRowsPerPage={this.handleChangeRowsPerPage} dataStore={dataStore} viewStore={viewStore} />
        )}
      </>
    );
  }
}

PokemonOverview.propTypes = {
  viewStore: PropTypes.object.isRequired,
  dataStore: PropTypes.object.isRequired
};

export default PokemonOverview;
