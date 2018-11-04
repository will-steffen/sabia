import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgBlockUI, BlockUI } from 'ng-block-ui';
import { CourseService } from 'src/services/course.service';
import { Course } from 'src/models/course';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-course-detail',
  templateUrl: './course-detail.page.html',
  styleUrls: ['./course-detail.page.less']
})
export class CourseDetailPage implements OnInit {
  slug = '';
  course: Course;
  @BlockUI() blockUI: NgBlockUI;
  constructor(
    public activaredRoute: ActivatedRoute,
    public courseService: CourseService,
    public userService: UserService
  ) {
    activaredRoute.params.subscribe(data => {
      this.slug = data.slug;
    });
  }

  ngOnInit() {
    this.activaredRoute.params.subscribe(data => {
      this.blockUI.start();
      this.courseService.getCourse(data.slug)
        .then(course => {
          this.course = course;
        })
        .catch(err => console.log(err))
        .then(() => this.blockUI.stop());
    });
  }

  initCourse() {
    this.blockUI.start();
    this.courseService.assign(this.course)
      .then(() => {
        this.blockUI.stop();
        this.ngOnInit();
      });
  }

}