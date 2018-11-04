import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ServiceHandler } from 'src/handlers/service.handler';
import { StorageHandler } from 'src/handlers/storage.handler';
import { AlertHandler } from 'src/handlers/alert.handler';
import { AuthService } from 'src/services/auth.service';
import { UserService } from 'src/services/user.service';
import { LoginPage } from 'src/pages/public/login/login.page';
import { PrivateBasePage } from 'src/pages/private/private-base/private-base.page';
import { BlockUIModule } from 'ng-block-ui';
import { ToastrModule } from 'ngx-toastr';
import { HttpClientModule } from '@angular/common/http';

import { HomePage } from 'src/pages/private/home/home.page';
import { CourseDetailPage } from 'src/pages/private/course-detail/course-detail.page';
import { CoursesPage } from 'src/pages/private/courses/courses.page';
import { JobDetailPage } from 'src/pages/private/job-detail/job-detail.page';
import { JobsPage } from 'src/pages/private/jobs/jobs.page';
import { AngularMaterialModule } from './material/angular-material.module';
import { FaceViewComponent } from 'src/components/face-view/face-view.component';
import { NavigationHeaderComponent } from 'src/components/navigation-header/navigation-header.component';
import { PageDetailHeaderComponent } from 'src/components/page-detail-header/page-detail-header.component';
import { CameraService } from 'src/services/camera.service';
import { JobService } from 'src/services/job.service';
import { CourseService } from 'src/services/course.service';


@NgModule({
  declarations: [
    AppComponent,

    LoginPage,
    PrivateBasePage,
    HomePage,
    JobsPage,
    JobDetailPage,
    CoursesPage,
    CourseDetailPage,

    FaceViewComponent,
    NavigationHeaderComponent,
    PageDetailHeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    BlockUIModule.forRoot(),
    ToastrModule.forRoot(),
    AngularMaterialModule  
  ],
  providers: [
    ServiceHandler,
    StorageHandler,
    AlertHandler,

    AuthService,
    UserService,
    CameraService,
    JobService,
    CourseService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
