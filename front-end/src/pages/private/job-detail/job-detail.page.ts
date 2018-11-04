import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/services/user.service';
import { JobService } from 'src/services/job.service';
import { Job } from 'src/models/job';
import { NgBlockUI, BlockUI } from 'ng-block-ui';

@Component({
    selector: 'app-job-detail',
    templateUrl: './job-detail.page.html',
    styleUrls: ['./job-detail.page.less']
})
export class JobDetailPage implements OnInit {
    job: Job;
    @BlockUI() blockUI: NgBlockUI;
    actionButton = 'Assumir este Trabalho';
    constructor(
        public activaredRoute: ActivatedRoute,
        public jobService: JobService
    ) { }

    ngOnInit() {
        this.activaredRoute.params.subscribe(data => {
            this.blockUI.start();
            this.jobService.getJob(data.slug)
                .then(job => {this.job = job; console.log(job)})
                .catch(err => console.log(err))
                .then(() => this.blockUI.stop());

        });
    }

    onActionButton() {
        console.log('On Action');
    }
}