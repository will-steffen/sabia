import { Component, ViewChild, ElementRef } from '@angular/core';
import { AlertHandler } from 'src/handlers/alert.handler';
import { NgBlockUI, BlockUI } from 'ng-block-ui';
import { HttpStatus } from 'src/enums/http-status';
import { AuthService } from 'src/services/auth.service';
import { Router } from '@angular/router';
import { RouteConfig } from 'src/enums/route-config';
import { AuthInfo } from 'src/models/view/auth-info';
import { UserService } from 'src/services/user.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.page.html',
    styleUrls: ['./login.page.less']
})
export class LoginPage {
    info = new AuthInfo();

    @BlockUI() blockUI: NgBlockUI;
    constructor(
        private alert: AlertHandler,
        private authService: AuthService,
        private router: Router
    ) { }

    login() {
        if(!this.info.Password || !this.info.Username) return;
        this.blockUI.start();
        this.authService.login(this.info)
            .then(() => this.router.navigate([RouteConfig.home]))
            .catch(err => {
                console.log(err);
                this.alert.error("Usuário não encontrado.");
            }) 
            .then(() => this.blockUI.stop());
    }

}