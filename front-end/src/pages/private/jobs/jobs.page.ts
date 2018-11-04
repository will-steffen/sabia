import { Component, OnInit } from '@angular/core';
import { JobService } from 'src/services/job.service';
import { NgBlockUI, BlockUI } from 'ng-block-ui';
import { Job } from 'src/models/job';
import { RouteConfig } from 'src/enums/route-config';
import { Router } from '@angular/router';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.page.html',
  styleUrls: ['./jobs.page.less']
})
export class JobsPage implements OnInit{ 
  panelOpenState = false;

  myJobs: Job[];
  availableJobs: Job[];

  @BlockUI() blockUI: NgBlockUI;
  constructor(
    public jobService: JobService,
    public router: Router
  ) {   }

  ngOnInit() {
    this.blockUI.start();
    this.jobService.getJobs()
    .then(jobs => {
      this.myJobs = jobs.filter(x => x.yourUserDoing);
      this.availableJobs = jobs.filter(x => !x.yourUserDoing);
      console.log(jobs);
    })
    .then(err => console.log(err))
    .then(() => this.blockUI.stop());
  }

  toCurrency(n: number) {
    return n.toFixed(2).replace('.', ',');
  }
  openJob(job: Job) {
    this.router.navigate([RouteConfig.job, job.slug]);
  }
}