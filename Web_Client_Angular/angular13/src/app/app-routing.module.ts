import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {GoodComponent} from './good/good.component';
import { OrderComponent } from './order/order.component';


const routes: Routes = [
  {path: 'good', component: GoodComponent},
  {path: 'order', component: OrderComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
