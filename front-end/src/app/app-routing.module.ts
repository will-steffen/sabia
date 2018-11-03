import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PrivateBasePage } from '../pages/private/private-base/private-base.page';
import { AuthService } from 'src/services/auth.service';
import { LoginPage } from 'src/pages/public/login/login.page';
import { RouteConfig } from 'src/enums/route-config';

const routes: Routes = [
    { path: RouteConfig.login, component: LoginPage, canActivate: [AuthService] },
    { path: '', component: PrivateBasePage, canActivate: [AuthService], 
        // children:[
        //     {path: RouteConfig.home, redirectTo: RouteConfig.user, pathMatch: 'full'}
        // ] 
    },
    { path: '**', redirectTo: '' }
];

@NgModule({
    exports: [ RouterModule ],
    imports: [ RouterModule.forRoot(routes) ],
})
export class AppRoutingModule { }
