
// Angular
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';

// NGPRIME:
import { ButtonModule } from 'primeng/button';
import {TableModule} from 'primeng/table';

// Pages
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { PortalPageComponent } from './pages/portal-page/portal-page.component';

// Services
import { ApiService } from './services/api.service'
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { PeopleTableComponent } from './tables/people-table/people-table.component'

@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent,
    PortalPageComponent,
    LoginPageComponent,
    PeopleTableComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ButtonModule,
    RouterModule.forRoot(
      [
        { path: '', component: LandingPageComponent},
        { path: 'portal', component: PortalPageComponent},
        { path: 'login', component: LoginPageComponent},
      ], 
      { relativeLinkResolution: 'legacy' })
  ],
  providers: [
    ApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
