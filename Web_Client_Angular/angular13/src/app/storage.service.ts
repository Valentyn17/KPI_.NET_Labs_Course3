import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  readonly APIUrl="https://localhost:44356/api";
  constructor(private http: HttpClient) { }

  getGoodList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Good');
  }

  addGood(val: any){
    return this.http.post(this.APIUrl+'/Good', val);
  }

  updateGood(val: any){
    return this.http.put(this.APIUrl+'/Good', val);
  }
  deleteGood(val: any){
    return this.http.delete(this.APIUrl+'/Good/'+val);
  }

  getOrderList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Order');
  }

  addOrder(val: any){
    return this.http.post(this.APIUrl+'/Order',val);
  }

  updateOrder(val: any){
    return this.http.put(this.APIUrl+'/Order', val);
  }
  deleteOrder(val: any){
    return this.http.delete(this.APIUrl+'/Order/'+val);
  }
}
