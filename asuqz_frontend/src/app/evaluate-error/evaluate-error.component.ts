import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { OEBBError } from './../../models/oebb-error';
import { Component, OnInit } from '@angular/core';
import { $ } from 'protractor';
import { ErrorMockingService } from '../error-mocking.service';
import { Console } from 'console';

@Component({
  selector: 'app-evaluate-error',
  templateUrl: './evaluate-error.component.html',
  styleUrls: ['./evaluate-error.component.css']
})
export class EvaluateErrorComponent implements OnInit {

  zustand: String[] = [];
  years: Number[] = [];
  months: String[] = ['01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12'];
  days: String[] = [];

  selectedZustand = "";
  selectedYear = null;
  selectedMonth = null;
  selectedDay = null;

  errors: OEBBError[] = [];

  constructor(public mockingService: ErrorMockingService, private httpClient: HttpClient) {
  }

  ngOnInit(): void {
    this.zustand = ["Auslauf", "Auslauf_2", "Lager", "Schlag", "Warmlauf", "Wuchtlauf"];
    this.years = [2021];
  }

  chooseDays(){
    if(this.selectedMonth == '02'){
      this.days = ['01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12', '13', '14',
       '15', '16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28']
    }
    else if(this.selectedMonth == '01' || this.selectedMonth == '03' || this.selectedMonth == '05' || this.selectedMonth == '07' ||
      this.selectedMonth == '08' || this.selectedMonth == '11' || this.selectedMonth == '12'){
        this.days =['01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12', '13', '14',
        '15', '16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30', '31']
    }
    else{
      this.days = ['01', '02', '03', '04', '05', '06', '07', '08', '09', '10', '11', '12', '13', '14',
      '15', '16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30']
    }
  }

  getEvaluationMocking(){
    this.errors = [];
    let date = undefined;
    if(this.selectedDay != null && this.selectedMonth != null && this.selectedYear != null){
      date = this.selectedYear! + this.selectedMonth! + '-' + this.selectedDay;
    }
    this.errors = this.mockingService.getErrors(this.selectedZustand, date);
    this.selectedDay = null;
    this.selectedMonth = null;
    this.selectedYear = null;
  }

  async getEvaluation(){
    this.errors = [];

    if(this.selectedYear == null){
      let x = await this.httpClient.get<OEBBError[]>('https://localhost:5001/api/Function/GetErrors/errors/' + this.selectedZustand)
      .toPromise()
      .catch((err: HttpErrorResponse) => {
        return [];
      });
      this.errors = x!;
    }
    else if(this.selectedMonth == null){
      let x = await this.httpClient.get<OEBBError[]>('https://localhost:5001/api/Function/GetErrors/errors/' + this.selectedZustand
       + '/' + this.selectedYear)
       .toPromise()
       .catch((err: HttpErrorResponse) => {
         return []
       });
       this.errors = x!;
    }
    else if(this.selectedDay == null){
      let x = await this.httpClient.get<OEBBError[]>('https://localhost:5001/api/Function/GetErrors/errors/' + this.selectedZustand
       + '/' + this.selectedYear + '/' + this.selectedMonth)
       .toPromise()
       .catch((err: HttpErrorResponse) => {
         return [];
       });
       this.errors = x!;
    }
    else{
      let x = await this.httpClient.get<OEBBError[]>('https://localhost:5001/api/Function/GetErrors/errors/' + this.selectedZustand
      + '/' + this.selectedYear + '/' + this.selectedMonth + '/' + this.selectedDay)
      .toPromise()
      .catch((err: HttpErrorResponse) => {
        return [];
      });
      this.errors = x!;
    }

    if(this.errors.length == 0){
      this.errors = [{name: 'Es gibt keine Fehler für ' + this.selectedZustand + ' ' + this.selectedYear + ' '
      + this.selectedMonth + ' ' + this.selectedDay, date: "", zustand: ""}]
    }

    this.selectedDay = null;
    this.selectedMonth = null;
    this.selectedYear = null;
    this.selectedZustand = "";
  }
}
