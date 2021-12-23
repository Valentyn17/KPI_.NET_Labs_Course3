import { Component, OnInit } from '@angular/core';
import { StorageService } from 'src/app/storage.service';
@Component({
  selector: 'app-show-delete-good',
  templateUrl: './show-delete-good.component.html',
  styleUrls: ['./show-delete-good.component.css']
})
export class ShowDeleteGoodComponent implements OnInit {

  constructor(private serice: StorageService) { }

  GoodList : any=[];
  ModalTitle: string="";
  ActivateAddUpdateGoodComp: boolean=false;
  good:any;
  

  ngOnInit(): void {
    this.refreshGoodList();
  }

  addClick(){
    this.good={
      Id:0,
      Name:"",
      Price:0,
      Count:0,
      Descr:"",
    }
    this.ModalTitle="Add good";
    this.ActivateAddUpdateGoodComp=true;
  }

  editClick(item :any){
    this.good=item;
    this.ModalTitle="Edit Good";
    this.ActivateAddUpdateGoodComp=true;
  }

  closeClick(){
    this.ActivateAddUpdateGoodComp=false;
    this.refreshGoodList();
  }

  deleteClick(item: any)
  {
     if(confirm("Are you sure?")){
       this.serice.deleteGood(item.Id).subscribe(data=>{
         alert('Good with id '+data.toString()+" was deleted!!");
         this.refreshGoodList();
       });
     }
  }
  refreshGoodList(){
    this.serice.getGoodList().subscribe(data=>{
      this.GoodList=data;
    });
  }
}
