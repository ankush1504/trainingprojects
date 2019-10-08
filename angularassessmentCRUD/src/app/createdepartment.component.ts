import { Component, OnInit } from '@angular/core';
import { department } from "./department";
import { DepartmentfunctionService } from "./departmentfunction.service";
import { Router } from "@angular/router";

@Component({
  selector: 'app-createdepartment',
  templateUrl: './createdepartment.component.html',
  styleUrls: ['./createdepartment.component.scss']
})
export class CreatedepartmentComponent implements OnInit {
  deplist:department[];
  constructor(private depservive:DepartmentfunctionService,private route:Router) { }
 
  dep=new department();
  
  savedepartment():void{
   this.depservive.save(this.dep);
   this.route.navigate(["/show"]);
  }

  ngOnInit() {
  }

}
