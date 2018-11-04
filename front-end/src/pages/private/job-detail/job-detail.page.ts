import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/services/user.service';
import { JobService } from 'src/services/job.service';
import { Job } from 'src/models/job';
import { NgBlockUI, BlockUI } from 'ng-block-ui';
import { RouteConfig } from 'src/enums/route-config';

@Component({
    selector: 'app-job-detail',
    templateUrl: './job-detail.page.html',
    styleUrls: ['./job-detail.page.less']
})
export class JobDetailPage implements OnInit {
    job: Job;
    @BlockUI() blockUI: NgBlockUI;
    @ViewChild('files') files: ElementRef;
    jobIsMine = false;
    constructor(
        public activaredRoute: ActivatedRoute,
        public jobService: JobService,
        public userService: UserService,
        public router: Router
    ) { }

    ngOnInit() {
        this.activaredRoute.params.subscribe(data => {
            this.blockUI.start();
            this.jobService.getJob(data.slug)
                .then(job => {
                    this.job = job;
                    let user = this.userService.getUser();
                    this.jobIsMine = this.job.userId == user.id;
                })
                .catch(err => console.log(err))
                .then(() => this.blockUI.stop());

        });
    }

    assign() {
        this.blockUI.start();
        this.jobService.assign(this.job)
            .then(() => { this.ngOnInit() })
            .catch(err => console.log(err))
            .then(() => this.blockUI.stop())
    }

    selectFiles() {
        this.files.nativeElement.onchange = () => {
            this.blockUI.start()
            this.jobService.close(this.job)
                .then(() => {this.router.navigate([RouteConfig.job])})
                .catch(err => console.log(err))
                .then(() => this.blockUI.stop());
        };
        this.files.nativeElement.click();
    }

}