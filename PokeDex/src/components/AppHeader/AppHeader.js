import React from "react";
import PropTypes from "prop-types";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";
import InputBase from "@material-ui/core/InputBase";
import SearchIcon from "@material-ui/icons/Search";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import FormGroup from "@material-ui/core/FormGroup";
import FormLabel from "@material-ui/core/FormLabel";
import Radio from "@material-ui/core/Radio";
import { withStyles } from "@material-ui/core/styles";
import styles from "./css/Style";
import { TABLE_VIEW, CARDS_VIEW } from "../../constants/constants";
import { observer } from "mobx-react";

@observer
class AppHeader extends React.Component {
  constructor(props) {
    super(props);
    this.state = { width: window.innerWidth };
    this.updateWindowDimensions = this.updateWindowDimensions.bind(this);
  }

  componentDidMount() {
    window.addEventListener('resize', this.updateWindowDimensions);
  }
  
  componentWillUnmount() {
    window.removeEventListener('resize', this.updateWindowDimensions);
  }
  
  updateWindowDimensions() {
    let currWidth = this.state.width;
    let newWidth = window.innerWidth;
    if ((currWidth >= 658 && newWidth < 658) || (currWidth < 658 && newWidth >= 658)) {
      this.setState({ width: window.innerWidth });
    }
  }

  // Обвертка для задержки исполнения колбэка при заполнении фильтра с поиском
  delay = (() => {
    var timer = 0;
    return (callback, ms) => {
      clearTimeout(timer);
      timer = setTimeout(callback, ms);
    };
  })();

  // Обработчик поля ввода поиска
  handleSearchBoxChange = event => {
    let searchValue = event.target.value;
    if ( (searchValue && (searchValue.length >= 3 || searchValue.length === 0)) || !searchValue ) {
      this.delay(() => {
        this.props.viewStore.setSearchValue(searchValue);
        this.props.dataStore.setPokemonStats();
      }, 700);
    }
  };

  // Смена представления - таблица или карточки
  setView = event => {
    this.props.viewStore.setView(event.target.value);
  };

  render() {
    console.log("rerender AppHeader");
    const { classes, viewStore } = this.props;
    return (
      <div className={classes.root}>
        <AppBar position="static">
          <Toolbar>
            <Typography
              className={classes.title}
              variant="h6"
              color="inherit"
              noWrap
            >
              PokeDex
            </Typography>
            <div className={classes.search}>
              <div className={classes.searchIcon}>
                <SearchIcon />
              </div>
              <InputBase
                placeholder="Поиск по покемонам"
                classes={{
                  root: classes.inputRoot,
                  input: classes.inputInput
                }}
                onChange={this.handleSearchBoxChange}
              />
            </div>
            <div>
              <FormLabel component="legend" classes={{
                root: classes.formLabelRoot
              }}>Представление:</FormLabel>
              <FormGroup row classes={{
                root: classes.fgRoot
              }}>
                  <FormControlLabel
                    value={TABLE_VIEW}
                    control={
                      <Radio
                        checked={viewStore.view === TABLE_VIEW}
                        onChange={this.setView}
                        value={TABLE_VIEW}
                        name={TABLE_VIEW}
                        classes={{
                          root: classes.rbRoot,
                          checked: classes.rbChecked
                        }}
                      />
                    }
                    label="Таблица"
                    labelPlacement={this.state.width >= 658 ? "start" : "end"}
                    classes={{
                      label: classes.formControlLabel,
                      labelPlacementStart: classes.formControlLabelStart
                    }}
                  />
                  <FormControlLabel
                    value={CARDS_VIEW}
                    control={
                      <Radio
                        checked={viewStore.view === CARDS_VIEW}
                        onChange={this.handleChange}
                        value={CARDS_VIEW}
                        name={CARDS_VIEW}
                        classes={{
                          root: classes.rbRoot,
                          checked: classes.rbChecked
                        }}
                      />
                    }
                    label="Карточки"
                    labelPlacement="end"
                    classes={{
                      label: classes.formControlLabel
                    }}
                  />
              </FormGroup>
            </div>
            
          </Toolbar>
        </AppBar>
      </div>
    );
  }
}

AppHeader.propTypes = {
  viewStore: PropTypes.object.isRequired,
  dataStore: PropTypes.object.isRequired,
  classes: PropTypes.object.isRequired
};

export default withStyles(styles)(AppHeader);
