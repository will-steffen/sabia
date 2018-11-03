import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-job-detail',
  templateUrl: './job-detail.page.html',
  styleUrls: ['./job-detail.page.less']
})
export class JobDetailPage {
  slug = '';
  constructor(public activaredRoute: ActivatedRoute) {
    activaredRoute.params.subscribe(data => {
      this.slug = data.slug;
    });
  }
}