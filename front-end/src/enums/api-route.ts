import { environment } from "src/environments/environment";


let basePath = environment.apiURL;

export const ApiRoute = {    
    auth: basePath + '/auth',
    user: {
        login: basePath + '/user/login',
        base: basePath + '/user',
    },
    job: {
        base: basePath + '/job',
        assign: basePath + '/job/AttributeJob',
        fininsh: basePath + '/job/FinishJob',        
    },
    course:{
        base: basePath + '/course',
        assign: basePath + '/course/AttributeCourse'
    }
};
