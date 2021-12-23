import { Component, OnInit, Input } from '@angular/core';
import { StorageService } from 'src/app/storage.service';
@Component({
  selector: 'app-add-update-good',
  templateUrl: './add-update-good.component.html',
  styleUrls: ['./add-update-good.component.css']
})
export class AddUpdateGoodComponent implements OnInit {

  constructor(private service: StorageService) { }
  @Input() good:any;
  Id:number=0;
  Name:string="";
  Count:number=0;
  Price:number=0;
  Descr:string="";

  
  ngOnInit(): void {
    this.Id=this.good.Id;
    this.Name=this.good.Name;
    this.Price=this.good.Price;
    this.Count=this.good.Count;
  }

  addGood(){
    var val={Id:this.Id,
             Name: this.Name,
             Count: this.Count,
             Price: this.Price,
             Descr: this.Descr        
    };
    this.service.addGood(val).subscribe(res=>{
      alert("Good was added");
    }, err=>
      {
        alert("Wrong parameters");
      }
    );
  }

  updateGood(){
    var val={Id:this.Id,
      Name: this.Name,
      Count: this.Count,
      Price: this.Price,
      Descr: this.Descr};
    this.service.updateGood(val).subscribe(res=>{
    alert("Good was updated");
    }, err=>
    {
      alert("Wrong parameters");
    });
  }

}
