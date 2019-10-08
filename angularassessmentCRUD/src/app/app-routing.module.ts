import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {CreatedepartmentComponent} from './createdepartment.component';
import { DepartmentlistComponent } from "./departmentlist.component";


const routes: Routes = [
  {path:'add',component:CreatedepartmentComponent},
  {path:'show',component:DepartmentlistComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
