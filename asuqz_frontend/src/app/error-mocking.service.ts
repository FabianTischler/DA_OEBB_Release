import { OEBBError } from './../models/oebb-error';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ErrorMockingService {
  private errors: OEBBError[];

  constructor() {
    this.errors = [
      {name: 'RADWELLENLAGER_B	0	INNENRG_B_RW OR AUSSENRG_B_RW OR WÄLZK_B_RW', date: '2021-04-20', zustand: 'Lager'},
      {name: 'RADWELLENLAGER_B	0	INNENRG_B_RW OR AUSSENRG_B_RW OR WÄLZK_B_RW', date: '2021-05-17', zustand: 'Lager'},
      {name: 'UNWUCHT_A_RW	0	UNWUCHT_VA', date: '2021-07-12', zustand: 'Auslauf'},
      {name: 'MOTORWELLENLAGER_B	0	INNENRG_B_MW OR AUSSENRG_B_MW OR WÄLZK_B_MW', date: '2021-04-19', zustand: 'Auslauf 2'},
      {name: 'RAD_A	0	PLANLAUF_A_MAX OR RUNDLAUF_A_MAX', date: '2021-03-01', zustand: 'Schlag'},
      {name: 'BREMSWELLENLAGER_B	0	INNENRG_B_BW OR AUSSENRG_B_BW OR WÄLZK_B_BW', date: '2021-06-09', zustand: 'Warmlauf'},
      {name: 'BREMSWELLENLAGER_A	0	INNENRG_A_BW OR AUSSENRG_A_BW OR WÄLZK_A_BW', date: '2021-05-25', zustand: 'Wuchtlauf'},
    ];
  }

  getErrors(zustandParam: String, dateParam?: String){
    if(dateParam == undefined){
      return this.errors.filter(x => x.zustand == zustandParam);
    }
    return this.errors.filter(x => x.zustand == zustandParam && x.date == dateParam)
  }
}
