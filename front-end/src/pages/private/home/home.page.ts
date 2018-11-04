import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RouteConfig } from 'src/enums/route-config';
import { UserService } from 'src/services/user.service';
import { User } from 'src/models/user';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.less']
})
export class HomePage { 

  user = new User();
  constructor( public router: Router, public userService: UserService ){
    this.user = userService.getUser();
  }

  openJobs() {
    this.router.navigate([RouteConfig.job]);
  }

  openCourses() {
    this.router.navigate([RouteConfig.course]);
  }

}