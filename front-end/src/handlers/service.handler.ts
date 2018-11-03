import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { StorageHandler } from './storage.handler';
import { Table } from 'src/enums/table';
import { User } from 'src/models/user';

@Injectable()
export class ServiceHandler {
    constructor(
        public http: HttpClient, 
        private storage: StorageHandler
    ){ }

    post(path: string, body: any): Promise<any> {
        return this.http.post(path, body).toPromise();
    }

    get(path: string): Promise<any> {
        return this.http.get(path).toPromise();
    }

}