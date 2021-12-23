import { Component, OnInit } from '@angular/core';
import { StorageService } from 'src/app/storage.service';

@Component({
  selector: 'app-show-delete-order',
  templateUrl: './show-delete-order.component.html',
  styleUrls: ['./show-delete-order.component.css']
})
export class ShowDeleteOrderComponent implements OnInit {

  constructor(private serice: StorageService) { }

  OrderList : any=[];
  ModalTitle: string="";
  ActivateAddUpdateOrderComp: boolean=false;
  order:any;


  ngOnInit(): void {
    this.refreshOrderList();
  }

  addClick(){
    this.order={
      Id:0,
      GoodName:"",
      GoodId: 0,
      Sum:0,
      Date: "", 
      Count:0,
      Email:"",
      Status:0
    }
    this.ModalTitle="Make order";
    this.ActivateAddUpdateOrderComp=true;
  }

  editClick(item :any){
    this.order=item;
    this.ModalTitle="Edit Order";
    this.ActivateAddUpdateOrderComp=true;
  }

  closeClick(){
    this.ActivateAddUpdateOrderComp=false;
    this.refreshOrderList();
  }

  deleteClick(item: any)
  {
     if(confirm("Are you sure?")){
       this.serice.deleteOrder(item.Id).subscribe(data=>{
         alert('Order with id '+data.toString()+" was deleted!!");
         this.refreshOrderList();
       });
     }
  }
  refreshOrderList(){
    this.serice.getOrderList().subscribe(data=>{
      this.OrderList=data;
    });
  }
}
