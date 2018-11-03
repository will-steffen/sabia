import { environment } from "src/environments/environment";


let basePath = environment.apiURL;

export const ApiRoute = {
    auth: {
        login: basePath + '/auth/login',
        hasSession: basePath + '/auth'
    },
    user: {
        logged: basePath + '/user'
    }
};
