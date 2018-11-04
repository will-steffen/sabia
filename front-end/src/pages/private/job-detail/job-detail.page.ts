import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
    jobIsMine= false;
    actionButton = 'Assumir este Trabalho';
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

                    if(this.jobIsMine){
                        this.actionButton = 'Submeter arquivos';
                    }else{
                        this.actionButton = 'Assumir este Trabalho';
                    }
                })
                .catch(err => console.log(err))
                .then(() => this.blockUI.stop());

        });
    }

    onActionButton(ctx: JobDetailPage) {
        if(!ctx.jobIsMine){
            ctx.blockUI.start();
            ctx.jobService.assign(ctx.job)
                .then(() => {ctx.ngOnInit()})
                .catch(err => console.log(err))
                .then(() => ctx.blockUI.stop())
        }else{
            alert('encerrar');
        }
    }
}