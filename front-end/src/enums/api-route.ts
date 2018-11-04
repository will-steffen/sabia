import { environment } from "src/environments/environment";


let basePath = environment.apiURL;

export const ApiRoute = {    
    auth: basePath + '/auth',
    user: {
        login: basePath + '/user/login'
    },
    job: {
        base: basePath + '/job',
        assign: basePath + '/job/AttributeJob'
    },
    course:{
        base: basePath + '/course'
    }
};
