import { Component, ViewChild, ElementRef } from '@angular/core';
import { AlertHandler } from 'src/handlers/alert.handler';
import { NgBlockUI, BlockUI } from 'ng-block-ui';
import { HttpStatus } from 'src/enums/http-status';
import { AuthService } from 'src/services/auth.service';
import { Router } from '@angular/router';
import { RouteConfig } from 'src/enums/route-config';

@Component({
    selector: 'app-login',
    templateUrl: './login.page.html',
    styleUrls: ['./login.page.less']
})
export class LoginPage {
    @BlockUI() blockUI: NgBlockUI;
    constructor(
        private alert: AlertHandler,
        private authService: AuthService,
        private router: Router
    ) { }


}