import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CountryVM } from '../Classes/country-vm';
import { StateVM } from '../Classes/state-vm';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  Url = 'http://localhost:50282/api';
  constructor(private http: HttpClient) { }
  CountryDDL(): Observable<CountryVM[]> {
    return this.http.get<CountryVM[]>(this.Url + '/Country');
  }
  StateDDL(CountryId: string): Observable<StateVM[]> {
    return this.http.get<StateVM[]>(this.Url + '/Country/' + CountryId + '/State');
  }
}
