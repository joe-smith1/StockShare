import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { StockCardComponent } from './stock-card/stock-card.component';
import { AddStockComponent } from './add-stock/add-stock.component';
import { DateInputComponent } from './_form-components/date-input/date-input.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TextInputComponent } from './_form-components/text-input/text-input.component';
import { UpdateStockComponent } from './update-stock/update-stock.component';
import { StockFeedComponent } from './stock-feed/stock-feed.component';
import { PrivateStockFeedComponent } from './private-stock-feed/private-stock-feed.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    StockCardComponent,
    AddStockComponent,
    DateInputComponent,
    TextInputComponent,
    UpdateStockComponent,
    StockFeedComponent,
    PrivateStockFeedComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    ApiAuthorizationModule,
    PaginationModule.forRoot(),
    BsDropdownModule.forRoot(),

    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'private-stock-feed', component: PrivateStockFeedComponent, canActivate: [AuthorizeGuard] },
      { path: 'add-stock', component: AddStockComponent, canActivate: [AuthorizeGuard] },
      { path: 'update-stock', component: UpdateStockComponent, canActivate: [AuthorizeGuard] }
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
