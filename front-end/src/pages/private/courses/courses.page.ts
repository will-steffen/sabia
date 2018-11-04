import { Component, OnInit } from '@angular/core';
import { CourseService } from 'src/services/course.service';
import { NgBlockUI, BlockUI } from 'ng-block-ui';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.page.html',
  styleUrls: ['./courses.page.less']
})
export class CoursesPage implements OnInit { 

  @BlockUI() blockUI: NgBlockUI;
  
  constructor(public courseService: CourseService){}

  ngOnInit() {
    this.blockUI.start();
    this.courseService.getCourses()
      .then(courses => console.log(courses))
      .catch(err => console.log(err))
      .then(() =>this.blockUI.stop());
  }
}