import { observable, action } from 'mobx';
import PokemonModel from '../models/PokemonModel';
import Pokedox from 'pokedex-promise-v2';

export default class DataStore {
  viewStore;
  constructor(viewStore) {
    this.viewStore = viewStore;
    this.init();
  }

  @observable pokemons = [];
  pokemonsCount = 0;

  async init() {
    this.loadPokemons();
  }

  // Получение списка покемонов без характеристик (API этого не предусматривает)
  async loadPokemons() {
    this.viewStore.setLoading(true);
    try {
      let P = new Pokedox();
      let response = await P.getPokemonsList();
      this.pokemonsCount = response.count;
      let pokeList = [...response.results];
      // Берём порцию данных для первой страницы
      let firstPageData = pokeList.slice(this.viewStore.page * this.viewStore.limit, this.viewStore.page * this.viewStore.limit + this.viewStore.limit);
      // Для каждого покемона из коллекции дергаем API чтобы получить характеристики (их нужно вывести в таблице)
      for (let item of firstPageData) {
        var pInfo = await P.getPokemonByName(item.name);
        item.id = pInfo.id;
        item.avatarUrl = pInfo.sprites.front_default;
        item.type = pInfo.types;
        item.stats = pInfo.stats;
       }
       // Формируем нужные нам модельки и записываем в observable
      this.fromJS(pokeList);
    } catch (err) {
      console.log(err);
    }
    this.viewStore.setLoading(false);
  }

  fromJS(array) {
    this.pokemons = array.map(item => new PokemonModel(item.id, item.name, item.avatarUrl, item.type, item.stats));
  }

  // Получение статистики для порции данных
  @action
  async setPokemonStats() {
    this.viewStore.setLoading(true);
    let result = this.getPokemons;
    let P = new Pokedox();
    for (let item of result) {
     await P.getPokemonByName(item.name).then(pInfo => {
        item.id = pInfo.id;
        item.avatarUrl = pInfo.sprites.front_default;
        item.types = pInfo.types;
        item.stats = pInfo.stats;
      });
    }
    this.pokemons = [...this.pokemons];
    this.viewStore.setLoading(false);
  }

  // Получение порции данных с принудительной фильтрацией, в случае если фильтр не пуст
  get getPokemons() {
    let data = this.checkFilter()
      ? this.getFilteredData()
      : this.pokemons;
    this.pokemonsCount = data.length;
    return data.slice(this.viewStore.page * this.viewStore.limit, this.viewStore.page * this.viewStore.limit + this.viewStore.limit)
  }

  // Проверка заполнен ли фильтр
  checkFilter() {
    return this.viewStore.searchValue && this.viewStore.searchValue.trim().length >= 3;
  }

  // Получение отфильтрованных данных
  getFilteredData() {
    return this.pokemons.filter(p => p.name.includes(this.viewStore.searchValue.trim()))
  }
}