import React from "react";
import PropTypes from "prop-types";
import TablePaginationActions from "../TablePaginationActions/TablePaginationActions";
import { withStyles } from "@material-ui/core/styles";
import Paper from "@material-ui/core/Paper";
import Table from "@material-ui/core/Table";
import TableHead from "@material-ui/core/TableHead";
import TableBody from "@material-ui/core/TableBody";
import TableFooter from "@material-ui/core/TableFooter";
import TableRow from "@material-ui/core/TableRow";
import TableCell from "@material-ui/core/TableCell";
import TablePagination from "@material-ui/core/TablePagination";
import Grid from "@material-ui/core/Grid";
import Card from "@material-ui/core/Card";
import CardHeader from "@material-ui/core/CardHeader";
import CardContent from "@material-ui/core/CardContent";
import CardActions from "@material-ui/core/CardActions";
import Avatar from "@material-ui/core/Avatar";
import Tooltip from "@material-ui/core/Tooltip";
import Zoom from "@material-ui/core/Zoom";
import Typography from "@material-ui/core/Typography";
import { observer } from "mobx-react";
import { PokemonType } from "../../../../constants/constants";
import pokemonOverviewStyles from "../../css/Style";
import cardViewStyles from "./css/Style";
import { mergeStyles } from "../../../../utils/StyleAggregator";

@observer
class CardView extends React.Component {
  constructor(props) {
    super(props);
    this.state = { width: window.innerWidth };
    this.updateWindowDimensions = this.updateWindowDimensions.bind(this);
  }

  componentDidMount() {
    window.addEventListener("resize", this.updateWindowDimensions);
  }

  componentWillUnmount() {
    window.removeEventListener("resize", this.updateWindowDimensions);
  }

  updateWindowDimensions() {
    let currWidth = this.state.width;
    let newWidth = window.innerWidth;
    if (
      (currWidth >= 547 && newWidth < 547) ||
      (currWidth < 547 && newWidth >= 547)
    ) {
      this.setState({ width: window.innerWidth });
    }
  }

  // Отрисовка карточек покемонов
  renderCardSection = pokemon => {
    let { classes } = this.props;

    return (
      <Grid item key={pokemon.name}>
        <Card className={classes.card}>
          <CardHeader
            avatar={
              <Avatar
                alt={pokemon.name}
                src={pokemon.avatarUrl}
                classes={{ img: classes.avatarImg }}
              />
            }
            title={pokemon.name}
            action={this.renderTypesSection(pokemon)}
          />
          <CardContent>{this.renderStatSection(pokemon)}</CardContent>
          <CardActions className={classes.actions} disableActionSpacing />
        </Card>
      </Grid>
    );
  };

  // Отрисовка светофоров с типами покемона
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

  // Отрисовка характеристик покемона
  renderStatSection = pokemon => {
    let { classes } = this.props;

    return (
      <Table className={classes.table}>
        <TableBody>
          <TableRow key="speed">
            <TableCell align="left">Скорость</TableCell>
            <TableCell align="left">
              {pokemon.stats &&
                pokemon.stats.filter(s => s.stat.name == "speed")[0].base_stat}
            </TableCell>
          </TableRow>
          <TableRow>
            <TableCell align="left">Атака</TableCell>
            <TableCell align="left">
              {pokemon.stats &&
                pokemon.stats.filter(s => s.stat.name == "attack")[0].base_stat}
            </TableCell>
          </TableRow>
          <TableRow>
            <TableCell align="left">Защита</TableCell>
            <TableCell align="left">
              {pokemon.stats &&
                pokemon.stats.filter(s => s.stat.name == "defense")[0]
                  .base_stat}
            </TableCell>
          </TableRow>
          <TableRow>
            <TableCell align="left">Спец. атака</TableCell>
            <TableCell align="center">
              {pokemon.stats &&
                pokemon.stats.filter(s => s.stat.name == "special-attack")[0]
                  .base_stat}
            </TableCell>
          </TableRow>
          <TableRow>
            <TableCell align="left">Спец. защита</TableCell>
            <TableCell align="center">
              {pokemon.stats &&
                pokemon.stats.filter(s => s.stat.name == "special-defense")[0]
                  .base_stat}
            </TableCell>
          </TableRow>
        </TableBody>
      </Table>
    );
  };

  render() {
    const { classes, viewStore, dataStore } = this.props;

    return (
      <Paper className={classes.root}>
        <div className={classes.tableWrapper}>
          <Table className={classes.table}>
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
            </TableHead>
          </Table>
          <Grid container className={classes.gridRoot}>
            <Grid
              container
              direction="row"
              spacing={ataStore.getPokemons && dataStore.getPokemons.length > 0 ? 16 :0}
              justify={
                this.state.width >= 547 &&
                dataStore.getPokemon &&
                dataStore.getPokemon.length > 0
                  ? "flex-start"
                  : "center"
              }
              alignItems="center"
            >
              {dataStore.getPokemons && dataStore.getPokemons.length > 0 ? (
                dataStore.getPokemons.map(row => this.renderCardSection(row))
              ) : (
                <Grid item>
                  <Typography component="p">Нет данных</Typography>
                </Grid>
              )}
            </Grid>
          </Grid>
          <Table className={classes.table}>
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

CardView.propTypes = {
  classes: PropTypes.object.isRequired,
  viewStore: PropTypes.object.isRequired,
  dataStore: PropTypes.object.isRequired
};

const styles = theme =>
  mergeStyles(pokemonOverviewStyles, cardViewStyles(theme));

export default withStyles(styles)(CardView);
