import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StudentComponent } from './Student/student/student.component';
import { TestComponent } from './test/test.component';
import { Test1Component } from './test1/test1.component';
import { Test2Component } from './test2/test2.component';
import {HttpClientModule, HttpClient} from '@angular/common/http'; 

@NgModule({
  declarations: [
    AppComponent,
    StudentComponent,
    TestComponent,
    Test1Component,
    Test2Component
  ],
  imports: [
    FormsModule,ReactiveFormsModule,
    BrowserModule,HttpClientModule,
    AppRoutingModule
  ],

  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
