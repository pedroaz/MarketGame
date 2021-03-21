
// Angular
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';

// NGPRIME:
import { ButtonModule } from 'primeng/button';

// Pages
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { PortalPageComponent } from './pages/portal-page/portal-page.component';

// Services
import { HelperService } from './services/helper/helper.service'

@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent,
    PortalPageComponent
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
      ], 
      { relativeLinkResolution: 'legacy' })
  ],
  providers: [
    HelperService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
