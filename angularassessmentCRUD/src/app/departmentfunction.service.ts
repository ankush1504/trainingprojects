import { Injectable } from '@angular/core';
import { department } from "./department";

@Injectable({
  providedIn: 'root'
})
export class DepartmentfunctionService {

  deplist:department[]=[
    {departmentid:1,name:'Engineering',groupname:'Research and Development',modifieddate:new Date('2002-06-01')},
    {departmentid:2,name:'Tool Design',groupname:'Research and Development',modifieddate:new Date('2002-07-05')},
    {departmentid:3,name:'Sales',groupname:'Sales and Marketing',modifieddate:new Date('2002-08-21')},
    {departmentid:4,name:'Marketing',groupname:'Sales and Marketing',modifieddate:new Date('2002-08-25')},
    {departmentid:5,name:'Purchasing',groupname:'Inventory Management',modifieddate:new Date('2002-09-07')},
    {departmentid:6,name:'Research and Development',groupname:'Research and Development',modifieddate:new Date('2002-10-11')}  
    
  ]

  constructor() { }

  getdepartment(){
    return this.deplist;
  }

  save(dep:department){
    this.deplist.push(dep);
  }
  update(dep:department,index:number){
    this.deplist[index]=dep;
  }

  delete(index:number)
  {
    this.deplist.splice(index,1);
  }
}
