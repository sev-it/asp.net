import React from "react";
import PropTypes from "prop-types";
import TablePaginationActions from "../TablePaginationActions/TablePaginationActions";
import { withStyles } from "@material-ui/core/styles";
import Avatar from "@material-ui/core/Avatar";
import Table from "@material-ui/core/Table";
import TableHead from "@material-ui/core/TableHead";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableFooter from "@material-ui/core/TableFooter";
import TablePagination from "@material-ui/core/TablePagination";
import TableRow from "@material-ui/core/TableRow";
import Tooltip from "@material-ui/core/Tooltip";
import Zoom from "@material-ui/core/Zoom";
import Paper from "@material-ui/core/Paper";
import { observer } from "mobx-react";
import { PokemonType } from "../../../../constants/constants";
import pokemonOverviewStyles from "../../css/Style";
import tableViewStyles from "./css/Style";
import { mergeStyles } from "../../../../utils/StyleAggregator";

@observer
class TableView extends React.Component {
  // Отрисовка типов покемона
  renderTypesSection = pokemon => {
    let { classes } = this.props;

    let types = pokemon.types.map(t => {
      let className = `${classes.flexItem} ${classes.typeCircle} ${
        classes[PokemonType[t.type.name].color || "unknow"]
      }`;
      return (
        <Tooltip
          key={t.slot}
          TransitionComponent={Zoom}
          disableFocusListener
          disableTouchListener
          classes={{
            tooltip: classes.tooltip
          }}
          title={PokemonType[t.type.name].name || "незивестный"}
        >
          <div className={className} />
        </Tooltip>
      );
    });
    return <>{types}</>;
  };

  render() {
    const { classes, viewStore, dataStore } = this.props;

    return (
      <Paper className={classes.root}>
        <div
          className={classes.tableWrapper}
        >
          <Table className={classes.table} padding="none">
            <TableHead>
              <TableRow>
                <TablePagination
                  classes={{
                    spacer: classes.spacer
                  }}
                  rowsPerPageOptions={[10, 20, 50]}
                  colSpan={7}
                  count={dataStore.pokemonsCount}
                  rowsPerPage={viewStore.limit}
                  page={viewStore.page}
                  SelectProps={{
                    native: true
                  }}
                  onChangePage={this.props.onChangePage}
                  onChangeRowsPerPage={this.props.onChangeRowsPerPage}
                  ActionsComponent={TablePaginationActions}
                  labelDisplayedRows={({ from, to, count }) =>
                    `${from}-${to} из ${count}`
                  }
                  labelRowsPerPage={"Строк на страницу: "}
                />
              </TableRow>
              <TableRow>
                <TableCell />
                <TableCell align="center">Тип</TableCell>
                <TableCell align="center">Имя</TableCell>
                <TableCell align="center">Скорость</TableCell>
                <TableCell align="center">Атака</TableCell>
                <TableCell align="center">Защита</TableCell>
                <TableCell align="center">Спец. атака</TableCell>
                <TableCell align="center">Спец. защита</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {dataStore.getPokemons && dataStore.getPokemons.length > 0 ? (
                dataStore.getPokemons.map(row => (
                  <TableRow key={row.name}>
                    <TableCell align="center">
                      <Avatar
                        alt={row.name}
                        src={row.avatarUrl}
                        classes={{ img: classes.avatarImg }}
                      />
                    </TableCell>
                    <TableCell align="center">
                      <div className={classes.flexContainer}>
                        {this.renderTypesSection(row)}
                      </div>
                    </TableCell>
                    <TableCell align="center">{row.name}</TableCell>
                    <TableCell align="center">
                      {row.stats &&
                        row.stats.filter(s => s.stat.name == "speed")[0]
                          .base_stat}
                    </TableCell>
                    <TableCell align="center">
                      {row.stats &&
                        row.stats.filter(s => s.stat.name == "attack")[0]
                          .base_stat}
                    </TableCell>
                    <TableCell align="center">
                      {row.stats &&
                        row.stats.filter(s => s.stat.name == "defense")[0]
                          .base_stat}
                    </TableCell>
                    <TableCell align="center">
                      {row.stats &&
                        row.stats.filter(
                          s => s.stat.name == "special-attack"
                        )[0].base_stat}
                    </TableCell>
                    <TableCell align="center">
                      {row.stats &&
                        row.stats.filter(
                          s => s.stat.name == "special-defense"
                        )[0].base_stat}
                    </TableCell>
                  </TableRow>
                ))
              ) : (
                <TableRow>
                  <TableCell align="center" colSpan={8}>
                    Нет данных
                  </TableCell>
                </TableRow>
              )}
            </TableBody>
            <TableFooter>
              <TableRow>
                <TablePagination
                  classes={{
                    spacer: classes.spacer
                  }}
                  rowsPerPageOptions={[10, 20, 50]}
                  colSpan={7}
                  count={dataStore.pokemonsCount}
                  rowsPerPage={viewStore.limit}
                  page={viewStore.page}
                  SelectProps={{
                    native: true
                  }}
                  onChangePage={this.props.onChangePage}
                  onChangeRowsPerPage={this.props.onChangeRowsPerPage}
                  ActionsComponent={TablePaginationActions}
                  labelDisplayedRows={({ from, to, count }) =>
                    `${from}-${to} из ${count}`
                  }
                  labelRowsPerPage={"Строк на страницу: "}
                />
              </TableRow>
            </TableFooter>
          </Table>
        </div>
      </Paper>
    );
  }
}

TableView.propTypes = {
  classes: PropTypes.object.isRequired,
  viewStore: PropTypes.object.isRequired,
  dataStore: PropTypes.object.isRequired
};

const styles = theme =>
  mergeStyles(pokemonOverviewStyles, tableViewStyles(theme));

export default withStyles(styles)(TableView);
