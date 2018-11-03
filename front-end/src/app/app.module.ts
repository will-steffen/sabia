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

@NgModule({
  declarations: [
    AppComponent,

    LoginPage,
    PrivateBasePage
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    BlockUIModule.forRoot(),
    ToastrModule.forRoot()
  ],
  providers: [
    ServiceHandler,
    StorageHandler,
    AlertHandler,

    AuthService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
