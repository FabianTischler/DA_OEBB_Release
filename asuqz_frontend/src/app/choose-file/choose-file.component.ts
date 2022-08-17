import { Router, RouterModule } from '@angular/router';
import { OebbService } from './../oebb.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { OEBBFunktion } from 'src/models/oebb-funktion';
import { OEBBKriterien } from 'src/models/oebb-kriterien';
import {MatCheckboxModule} from '@angular/material/checkbox';

@Component({
  selector: 'app-choose-file',
  templateUrl: './choose-file.component.html',
  styleUrls: ['./choose-file.component.css']
})
export class ChooseFileComponent implements OnInit {

  fileName = '';
  disabled = false;
  zustand = '';

  constructor(private httpClient: HttpClient, private service: OebbService, private router: Router) { }

  ngOnInit(): void {
  }

  async onFileSelected(event: any){
    const file: File = event.target.files[0];

    const f : OEBBFunktion[] = await this.httpClient
      .get<OEBBFunktion[]>('https://localhost:5001/' + this.zustand + '/' + file.name)
      .toPromise();
    const k : OEBBKriterien[] = await this.httpClient
      .get<OEBBKriterien[]>('https://localhost:5001/criteria/' + this.zustand + '/' + file.name)
      .toPromise();

    this.service.setFunctions(f);
    this.service.setKriterien(k);

    switch(k.length){
      case 27:
        this.router.navigate(['show-function']);
        break;
      case 2:
        this.router.navigate(['show-function-auslauf']);
        break;
      case 15:
        this.router.navigate(['show-function-schlaglauf']);
        break;
      case 8:
        this.router.navigate(['show-function-warmlauf']);
        break;
      case 7:
        this.router.navigate(['show-function-wuchtlauf']);
        break;
    }
  }

  onAuslaufSelected(): void {
    this.disabled = true;
    this.zustand = 'Auslauf';
  }

  onAuslauf2Selected(): void {
    this.disabled = true;
    this.zustand = 'Auslauf_2';
  }

  onLagerSelected(): void {
    this.disabled = true;
    this.zustand = 'Lager';
  }

  onSchlagSelected(): void {
    this.disabled = true;
    this.zustand = 'Schlag';
  }

  onWarmSelected(): void {
    this.disabled = true;
    this.zustand = 'Warmlauf';
  }

  onWuchtSelected(): void {
    this.disabled = true;
    this.zustand = 'Wuchtlauf';
  }

}
