import { OEBBKriterien } from './../models/oebb-kriterien';
import { OEBBFunktion } from './../models/oebb-funktion';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OebbService {
  private functions: OEBBFunktion[];
  private kriterien: OEBBKriterien[];

  constructor() {
    this.functions = [];
    this.kriterien = [];
  }
  setFunctions(data: OEBBFunktion[]){
    this.functions = data;
  }
  getFunctions(){
    return this.functions;
  }
  setKriterien(data: OEBBKriterien[]){
    this.kriterien = data;
  }
  getKriterien(){
    return this.kriterien;
  }
}
