import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-course-detail',
  templateUrl: './course-detail.page.html',
  styleUrls: ['./course-detail.page.less']
})
export class CourseDetailPage { 
  slug = '';
  constructor(public activaredRoute: ActivatedRoute) {
    activaredRoute.params.subscribe(data => {
      this.slug = data.slug;
    });
  }
}