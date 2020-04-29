import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';

import { DatePipe } from '@angular/common';

import { PaginatorModule } from 'primeng/paginator';
import { TableModule } from 'primeng/table';
import { CalendarModule } from 'primeng/calendar';
import { DropdownModule } from 'primeng/dropdown';
import { MultiSelectModule } from 'primeng/multiselect';
import { CheckboxModule } from 'primeng/checkbox';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { AddNewCustomerComponent } from './Customer/add-new-customer/add-new-customer.component';
import { ListOfCustomerComponent } from './Customer/list-of-customer/list-of-customer.component';
import { AddNewAssetComponent } from './Asset/add-new-asset/add-new-asset.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AddNewCustomerComponent,
    ListOfCustomerComponent,
    AddNewAssetComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      maxOpened: 1,
      timeOut: 5000,
      // disableTimeOut:true,
      preventDuplicates: true,
      //positionClass: 'custom-toast-class',
      positionClass: 'toast-top-center',
    }),
    PaginatorModule,
    TableModule,
    CalendarModule,
    DropdownModule,
    MultiSelectModule,
    CheckboxModule,
    AutoCompleteModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'add-new-Customer', component: AddNewCustomerComponent },
      { path: 'add-new-Asset', component: AddNewAssetComponent },
      { path: 'list-Of-Customer', component: ListOfCustomerComponent },
    ])
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent],
  exports: [
    PaginatorModule,
    TableModule,
    CalendarModule,
    DropdownModule,
    MultiSelectModule,
    CheckboxModule,
    AutoCompleteModule,
  ]
})
export class AppModule { }
