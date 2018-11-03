import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, Router } from "@angular/router";
import { RouteConfig } from "src/enums/route-config";
import { ServiceHandler } from "src/handlers/service.handler";
import { ApiRoute } from "src/enums/api-route";
import { UserService } from "./user.service";

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

}