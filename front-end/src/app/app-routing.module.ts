import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PrivateBasePage } from '../pages/private/private-base/private-base.page';
import { AuthService } from 'src/services/auth.service';
import { LoginPage } from 'src/pages/public/login/login.page';
import { RouteConfig } from 'src/enums/route-config';
import { HomePage } from 'src/pages/private/home/home.page';
import { JobsPage } from 'src/pages/private/jobs/jobs.page';
import { CoursesPage } from 'src/pages/private/courses/courses.page';
import { CourseDetailPage } from 'src/pages/private/course-detail/course-detail.page';
import { JobDetailPage } from 'src/pages/private/job-detail/job-detail.page';
import { CameraPage } from 'src/pages/private/camera/camera.page';

const routes: Routes = [
    { path: RouteConfig.login, component: LoginPage, canActivate: [AuthService] },
    { path: '', component: PrivateBasePage, canActivate: [AuthService], 
        children:[
            {path: RouteConfig.home, component: HomePage},
            {path: RouteConfig.job, component: JobsPage},
            {path: RouteConfig.job + '/:slug', component: JobDetailPage},
            {path: RouteConfig.course, component: CoursesPage},
            {path: RouteConfig.course + '/:slug', component: CourseDetailPage},
            {path: RouteConfig.camera, component: CameraPage},
        ] 
    },
    { path: '**', redirectTo: '' }
];

@NgModule({
    exports: [ RouterModule ],
    imports: [ RouterModule.forRoot(routes) ],
})
export class AppRoutingModule { }
