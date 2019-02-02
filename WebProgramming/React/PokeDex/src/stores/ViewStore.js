import {observable, action} from 'mobx';
import { TABLE_VIEW, CARDS_VIEW } from "../constants/constants";

export default class ViewStore {
  /*
  // loading - флаг состояния отображения лоадера во вьюхах
  // limit - количество записей для отображения на одной странице
  // page - текущая страница в представлении
  // searchValue - значение в фильтре поиска
  */
  @observable loading = false;
  @observable view = TABLE_VIEW;
  limit = 10;
  page = 0;
  searchValue = "";
  
  @action
  setLoading = (loading) => {
    this.loading = loading;
  }

  @action
  setView = (view) => {
    this.view = view;
  }

  setSearchValue = (value) => {
    this.searchValue = value;
    this.resetPgination();
  }

  setLimit = (limit, pokemonsCount) => {
    this.limit = limit;
    let pageNum = Math.max(0, Math.ceil(pokemonsCount / limit) - 1);
    if (this.page > pageNum)
      this.page = pageNum;
  }

  setPage = (page) => {
    this.page = page;
  }

  resetPagination = () => {
    this.resetPgination();
  }

  resetPgination() {
    this.page = 0;
  }
}