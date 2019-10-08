import { Component, OnInit } from '@angular/core';
import { department } from "./department";
import { DepartmentfunctionService } from "./departmentfunction.service";


@Component({
  selector: 'app-departmentlist',
  templateUrl: './departmentlist.component.html',
  styleUrls: ['./departmentlist.component.scss']
})
export class DepartmentlistComponent implements OnInit {
depslist:department[];
dep:department;
updatediv=false;


  constructor(private deplistservice:DepartmentfunctionService) { 
    this.depslist=this.deplistservice.getdepartment();
  }

  ngOnInit() {
  }
  edit(index:number)
  {   
    
     this.updatediv=true; 
     this.dep=this.depslist[index];
    this.deplistservice.update(this.dep,index);  
   }
  deletedepartment(index:number)
  {
    this.deplistservice.delete(index);
   }

}
