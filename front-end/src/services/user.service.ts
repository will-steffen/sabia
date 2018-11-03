import { Injectable } from '@angular/core';
import { ServiceHandler } from 'src/handlers/service.handler';
import { StorageHandler } from 'src/handlers/storage.handler';
import { User } from 'src/models/user';
import { Table } from 'src/enums/table';
import { ApiRoute } from 'src/enums/api-route';
import { AuthInfo } from 'src/models/view/auth-info';

@Injectable()
export class UserService {

    constructor(
        private service: ServiceHandler, 
        private storage: StorageHandler
    ) { } 

    getUser() : User {
        let l = this.storage.list(Table.USER);
        if(l.length == 0) return null;
        return User.fromData(l[0]);        
    }

    logout() {
        this.storage.deleteTable(Table.USER);
    }

    saveUser(user: User) {
        this.logout();
        this.storage.save(Table.USER, user);
    }    

}