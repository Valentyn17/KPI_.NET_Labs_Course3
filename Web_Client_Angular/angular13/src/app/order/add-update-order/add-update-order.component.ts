import { Component, OnInit, Input } from '@angular/core';
import { StorageService } from 'src/app/storage.service';
import {Status} from '../../status-enum'
@Component({
  selector: 'app-add-update-order',
  templateUrl: './add-update-order.component.html',
  styleUrls: ['./add-update-order.component.css']
})

export class AddUpdateOrderComponent implements OnInit {
  propertyType: Array<string> = Object.keys(Status).filter(key => isNaN(+key));
  constructor(private service: StorageService) { }
  @Input() order:any;
  Id:number=0;
  GoodName:string="";
  Count:number=0;
  Sum:number=0;
  Date:string="";
  Status: string="";
  GoodId: number=0;
  Email: string="";
  
  GoodList: any=[];
  ngOnInit(): void {
    this.loadGoodList();
  }

  loadGoodList(){
    this.service.getGoodList().subscribe((data:any)=>{
    this.GoodList=data;
    this.Id=this.order.Id;
    this.GoodName=this.order.Name;
    this.Sum=this.order.Sum;
    this.Count=this.order.Count;
    this.GoodId=this.order.GoodId;
    this.Date=this.order.Date;
    this.Status=this.order.Status;
    this.Email=this.order.Email;
    });
  }


  findGoodIdByName(Name: string){
    var found = false;

    for (var i = 0; i < this.GoodList.length; i++) {
      if (this.GoodList[i].Name === Name) {
        
        return this.GoodList[i].Id;
      }
    }
  }



  addOrder(){
    var val={
      Email: this.Email,
      Count: this.Count,
      GoodId: this.findGoodIdByName(this.GoodName)};
    this.service.addOrder(val).subscribe( data => {
      alert(JSON.stringify(data));
      }, err => {
      alert("Some parameters were wrong");
      });
  }

  updateOrder(){
    var val={Id:this.Id,
      GoodName: this.GoodName,
      Count: this.Count,
      Sum: this.Sum,
      GoodId: this.GoodId,
      Date: this.Date,
      Status: this.Status,
      Email: this.Email};
    this.service.updateOrder(val).subscribe(res=>{
    alert("Order status was changed");
    }, (err :any)=>{
      alert("You can-t change status to this");
    });
  }

}

