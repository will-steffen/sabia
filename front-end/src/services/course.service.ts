import { Injectable } from "@angular/core";
import { ServiceHandler } from "src/handlers/service.handler";
import { UserService } from "./user.service";
import { ApiRoute } from "src/enums/api-route";
import { Job } from "src/models/job";
import { Course } from "src/models/course";

@Injectable()
export class CourseService {
    courses: Course[];
    constructor(
        private service: ServiceHandler,
        private userService: UserService
    ){}

    getCourses() : Promise<any[]>{
        return new Promise((resolve, reject) => {
            let user = this.userService.getUser();
            this.service.get(ApiRoute.course.base + '/' + user.id).then(data => {                  
                this.courses = data.map(x => Course.fromData(x));          
                resolve(this.courses);
            }).catch(err => {
                reject(err);
            })
        });
    }

    getCourse(slug: string) : Promise<any>{
        return new Promise((resolve, reject) => {
            let user = this.userService.getUser();
            this.service.get(ApiRoute.course.base + '/' + slug +'/' + user.id).then(data => {         
                resolve(Course.fromData(data));
            }).catch(err => {
                reject(err);
            })
        });
    }

    assign(course: Course) : Promise<any> {
        return new Promise((resolve) => {
            let user = this.userService.getUser();
            this.service.post(ApiRoute.course.assign, {
                UserId: user.id,
                CourseId: course.id
            }).then(data => {         
                resolve();
            }).catch(err => {
                resolve();
            })
        });
    }
}

