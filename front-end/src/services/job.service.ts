import { Injectable } from "@angular/core";
import { ServiceHandler } from "src/handlers/service.handler";
import { UserService } from "./user.service";
import { ApiRoute } from "src/enums/api-route";
import { Job } from "src/models/job";

@Injectable()
export class JobService {
    jobs: Job[];
    constructor(
        private service: ServiceHandler,
        private userService: UserService
    ){}

    getJobs() : Promise<Job[]>{
        return new Promise((resolve, reject) => {
            let user = this.userService.getUser();
            this.service.get(ApiRoute.job.base + '/' + user.id).then(data => {    
                this.jobs = data.map(x => Job.fromData(x));            
                resolve(this.jobs);
            }).catch(err => {
                reject(err);
            })
        });
    }
}