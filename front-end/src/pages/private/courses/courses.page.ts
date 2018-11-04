import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/services/course.service';
import { NgBlockUI, BlockUI } from 'ng-block-ui';
import { Course } from 'src/models/course';
import { Router } from '@angular/router';
import { RouteConfig } from 'src/enums/route-config';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.page.html',
  styleUrls: ['./courses.page.less']
})
export class CoursesPage implements OnInit { 

  myCourses: Course[];
  availableCourses: Course[];

  @BlockUI() blockUI: NgBlockUI;
  
  constructor(
    public courseService: CourseService,
    public router: Router
  ){}

  ngOnInit() {
    this.blockUI.start();
    this.courseService.getCourses()
      .then(courses => {
        this.myCourses = courses.filter(x => x.courseAssigned);
        this.availableCourses = courses.filter(x => !x.courseAssigned);
        console.log(this.myCourses);
      })
      .catch(err => console.log(err))
      .then(() =>this.blockUI.stop());
  }

  open(course: Course) {
    this.router.navigate([RouteConfig.course, course.slug]);
  }
}