import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RouteConfig } from 'src/enums/route-config';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.less']
})
export class HomePage { 

  constructor( public router: Router ){}

  openJobs() {
    this.router.navigate([RouteConfig.job]);
  }

  openCourses() {
    this.router.navigate([RouteConfig.course]);
  }

}