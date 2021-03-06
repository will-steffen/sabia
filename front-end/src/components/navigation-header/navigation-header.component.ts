import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RouteConfig } from 'src/enums/route-config';
import { CameraService } from 'src/services/camera.service';
import { UserService } from 'src/services/user.service';
import { User } from 'src/models/user';


@Component({
    selector: 'app-navigation-header',
    templateUrl: './navigation-header.component.html',
    styleUrls: ['./navigation-header.component.less']
})
export class NavigationHeaderComponent implements OnInit{

    user = new User();

    constructor(
        public router: Router, 
        public cameraService: CameraService,
        public userService: UserService
    ) { 
        this.user = userService.getUser();
    }

    ngOnInit() {
        this.userService.refreshUser()
        .then(() => {this.user = this.userService.getUser()})       
    }

    openJobs() {
        this.router.navigate([RouteConfig.job]);
    }

    openCourses() {
        this.router.navigate([RouteConfig.course]);
    }

    isCoursesActive() {
        return window.location.pathname.indexOf(RouteConfig.course) > 0;
    }

    isJobsActive() {
        return window.location.pathname.indexOf(RouteConfig.job) > 0;
    }

    logout() {
        this.userService.logout();
        this.router.navigate([RouteConfig.login]);
    }

    toCUrrency(n) {
        return n.toFixed(2).replace('.', ',');
    }

}