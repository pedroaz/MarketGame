
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
import {CardModule} from 'primeng/card';
import {TabMenuModule} from 'primeng/tabmenu';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {InputTextModule} from 'primeng/inputtext';

// Pages
import { LandingPageComponent } from './pages/landing-page/landing-page.component';
import { PortalPageComponent } from './pages/portal-page/portal-page.component';

// Services
import { ApiService } from './services/api.service'
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { PeopleTableComponent } from './tables/people-table/people-table.component';
import { PersonPageComponent } from './pages/person-page/person-page.component';
import { StockCertificateTableComponent } from './tables/stock-certificate-table/stock-certificate-table.component';
import { OrdersTableComponent } from './tables/orders-table/orders-table.component';
import { OrdersPageComponent } from './pages/orders-page/orders-page.component';
import { TopMenuComponent } from './navigation/top-menu/top-menu.component'



@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent,
    PortalPageComponent,
    LoginPageComponent,
    PeopleTableComponent,
    PersonPageComponent,
    StockCertificateTableComponent,
    OrdersTableComponent,
    OrdersPageComponent,
    TopMenuComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ButtonModule,
    TableModule,
    InputTextModule,
    CardModule,
    TabMenuModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(
      [
        { path: '', component: LandingPageComponent},
        { path: 'portal', component: PortalPageComponent},
        { path: 'login', component: LoginPageComponent},
        { path: 'person/:id', component: PersonPageComponent},
        { path: 'orders', component: OrdersPageComponent},
      ], 
      { relativeLinkResolution: 'legacy' })
  ],
  providers: [
    ApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
