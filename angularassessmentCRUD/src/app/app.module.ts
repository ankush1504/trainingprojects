import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DepartmentlistComponent } from './departmentlist.component';
import { NavComponent } from './nav.component';
import { CreatedepartmentComponent } from './createdepartment.component';

@NgModule({
  declarations: [
    AppComponent,
    DepartmentlistComponent,
    NavComponent,
    CreatedepartmentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
