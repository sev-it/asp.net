import PropTypes from "prop-types";

class PokemonModel {
  id;
  name;
  avatarUrl;
  types;
  stats;

  constructor(id, name, avatarUrl, types, stats) {
    this.id = id;
    this.name = name;
    this.avatarUrl = avatarUrl;
    this.types = types;
    this.stats = stats;
  }
}

PokemonModel.propTypes = {
  id: PropTypes.string.isRequired,
  name: PropTypes.string.isRequired,
  avatarUrl: PropTypes.string.isRequired,
  types: PropTypes.array.isRequired,
  stats: PropTypes.array.isRequired
};

export default PokemonModel;
