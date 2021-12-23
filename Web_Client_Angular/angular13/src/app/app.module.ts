import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GoodComponent } from './good/good.component';
import { AddUpdateGoodComponent } from './good/add-update-good/add-update-good.component';
import { ShowDeleteGoodComponent } from './good/show-delete-good/show-delete-good.component';
import { OrderComponent } from './order/order.component';
import { StorageService } from './storage.service';


import {HttpClientModule} from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ShowDeleteOrderComponent } from './order/show-delete-order/show-delete-order.component';
import { AddUpdateOrderComponent } from './order/add-update-order/add-update-order.component';

@NgModule({
  declarations: [
    AppComponent,
    GoodComponent,
    AddUpdateGoodComponent,
    ShowDeleteGoodComponent,
    OrderComponent,
    ShowDeleteOrderComponent,
    AddUpdateOrderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [StorageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
