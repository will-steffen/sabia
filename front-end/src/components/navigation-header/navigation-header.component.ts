import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RouteConfig } from 'src/enums/route-config';


@Component({
    selector: 'app-navigation-header',
    templateUrl: './navigation-header.component.html',
    styleUrls: ['./navigation-header.component.less']
})
export class NavigationHeaderComponent {
    constructor(public router: Router) { }

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

}