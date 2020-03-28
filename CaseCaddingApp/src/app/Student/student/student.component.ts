import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { StateVM } from 'src/app/Classes/state-vm';
import { CountryVM } from 'src/app/Classes/country-vm';
import { StudentService } from 'src/app/Services/student.service';
import { HttpClient, HttpHeaders } from "@angular/common/http";
@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {
  private _allCountry: Observable<CountryVM[]>;
  private _allState: Observable<StateVM[]>;
  SelCountryId: string = "0";
  FromStudent: any;
  constructor(private formbulider: FormBuilder, private StudentService: StudentService) { }
  FillCountryDDL() {
    // debugger;
    this._allCountry = this.StudentService.CountryDDL();
    // this._allCountry.subscribe(c => console.log(c));
  }
  FillStateDDL() {
    // debugger;
    this._allState = this.StudentService.StateDDL(this.SelCountryId);
    // this._allState.subscribe(s => console.log(s));
  }
  ngOnInit() {
    this.FromStudent = this.formbulider.group({
      StudentName: ['', [Validators.required]],
      Country: ['', [Validators.required]],
      State: ['', [Validators.required]]
    });
    this.FillCountryDDL();
  }

}
