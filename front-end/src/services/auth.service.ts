import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, Router } from "@angular/router";
import { RouteConfig } from "src/enums/route-config";
import { ServiceHandler } from "src/handlers/service.handler";
import { ApiRoute } from "src/enums/api-route";
import { UserService } from "./user.service";
import { AuthInfo } from "src/models/view/auth-info";
import { User } from "src/models/user";

@Injectable()
export class AuthService implements CanActivate {
    constructor(
        private router: Router,
        private service: ServiceHandler,
        private userService: UserService
    ) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        let user = this.userService.getUser();
        if (route.routeConfig.path == RouteConfig.login) {
            if (!user) {
                return true
            } else {
                this.router.navigate([RouteConfig.home]);
                return false;
            }
        } else {
            if (user) {
                return true
            } else {
                this.router.navigate([RouteConfig.login]);
                return false;
            }
        }
    }

    login(info: AuthInfo) : Promise<any> {
        return new Promise((resolve, reject) => {
            this.service.post(ApiRoute.auth, info).then(data => {
                let user = User.fromData(data);
                this.userService.saveUser(user);
                resolve();
            }).catch(err => reject(err));
        });        
    }

}