import { Injectable } from '@angular/core';
import { Table } from '../enums/table';
import '../utils/array';

@Injectable()
export class StorageHandler {

  list(table: Table): any[] {
    let data = localStorage.getItem(table);
    let result = data ? JSON.parse(data) : [];
    return result;
  }

  save(table: Table, item: any): string {
    let data = this.list(table);
    if (item.storageId === undefined) item.storageId = this.guid();
    data = data.filter(i => { return i.storageId != item.storageId });
    data.push(item);
    this.persist(table, data);
    return item.storageId;
  }

  saveList(table: Table, items: any[]): void {
    let data = this.list(table);
    let ids = [];
    items.forEach(i => {
      if (i.storageId === undefined) i.storageId = this.guid();
      ids.push(i.storageId);
    });
    data = data.filter(i => { return !ids.contains(i.storageId) });
    data = data.concat(items);
    this.persist(table, data);
  }

  getByStorageId(table: Table, storageId: string): any {
    let data = this.list(table);
    let resultFilter = data.filter(item => { return item.storageId == storageId });
    let result = resultFilter.length > 0 ? resultFilter[0] : null;
    return result;
  }

  getByProp(table: Table, prop: string, value: string): any[] {
    let data = this.list(table);
    let resultFilter = data.filter(item => { return item[prop] == value });
    return resultFilter;
  }

  deleteTable(table: Table): void {
    localStorage.removeItem(table);
  }

  deleteByStorageId(table: Table, storageId: string): void {
    let data = this.list(table);
    data.removeFirstByProp('storageId', storageId);
    this.persist(table, data);
  }

  delete(table: Table, item: any): void {
    this.deleteByStorageId(table, item.storageId);
  }

  private persist(table: Table, items: any[]): void {
    localStorage.setItem(table, JSON.stringify(items));
  }

  private guid(): string {
    function s4() {
      return Math.floor((1 + Math.random()) * 0x10000)
        .toString(16)
        .substring(1);
    }
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' + s4() + '-' + s4() + s4() + s4();
  }

}
