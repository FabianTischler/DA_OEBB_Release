import { OEBBKriterien } from './../../models/oebb-kriterien';
import { OebbService } from './../oebb.service';
import { OEBBMessergebnisse } from './../../models/oebb-messergebnisse';
import { OEBBFunktion } from './../../models/oebb-funktion';
import { Component, OnInit } from '@angular/core';
import { ChartDataSets, ChartType } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-show-function',
  templateUrl: './show-function.component.html',
  styleUrls: ['./show-function.component.css']
})
export class ShowFunctionComponent implements OnInit {
  dataPoints: ChartDataSets[] = [];
  labels: Label[] = [];
  options = {
    responsive: false,
    scales:  {
    }
  };
  colors: Color[] = [
    {
      borderColor: 'black',
      backgroundColor: undefined
    },
  ];
  legend = true;
  plugins = [];
  type: ChartType = 'line';

  functions: OEBBFunktion[] = [];
  kriterien: OEBBKriterien[] = [];

  messergebnisse: OEBBMessergebnisse[] = [
    { id: 0, number: 0, yWert: 0.0000, mittel: 0.0000, max: 0.0000, min: 0.0000 },
  ]
  selectedFunction: string = '';
  dataMittel: number[] = [];
  dataMax: number[] = [];
  dataMin: number[] = [];
  kriterium: OEBBKriterien[] = [];
  pushCount = 100;
  disabled = true;
  kriteriumOneMin: number[] = [];
  kriteriumOneMax: number[] = [];
  kriteriumTwoMin: number[] = [];
  kriteriumTwoMax: number[] = [];
  kriteriumThreeMin: number[] = [];
  kriteriumThreeMax: number[] = [];
  fileName = '';

  constructor(public service: OebbService) { }

  async ngOnInit(): Promise<void> {
    this.functions = this.service.getFunctions();
    this.kriterien = this.service.getKriterien();
  }

  onSelect(): void {
    this.disabled = false;
    this.dataMittel = [];
    this.dataMax = [];
    this.dataMin = [];
    this.labels = [];
    this.kriteriumOneMin = [];
    this.kriteriumOneMax = [];
    this.kriterium = [];
    this.kriteriumTwoMin = [];
    this.kriteriumTwoMax = [];
    this.kriteriumThreeMin = [];
    this.kriteriumThreeMax = [];
    this.pushCount = 50;
    let f: OEBBFunktion = new OEBBFunktion(0,'',0,0,0,0,this.messergebnisse);
    this.functions.forEach(element => {
      if(element.beschreibung === this.selectedFunction){
        f = element;
      }
    });

    switch(f.beschreibung){
      case 'LagerEnvelope(Bremswelle A)':
        this.kriterium = [this.kriterien[1], this.kriterien[9], this.kriterien[19]];
        break;
      case 'LagerEnvelope(Bremswelle B)':
        this.kriterium = [this.kriterien[5], this.kriterien[13], this.kriterien[23]];
        break;
      case 'LagerEnvelope(Motorwelle A)':
        this.kriterium = [this.kriterien[2], this.kriterien[10], this.kriterien[20]];
        break;
      case 'LagerEnvelope(Motorwelle B)':
        this.kriterium = [this.kriterien[6], this.kriterien[14], this.kriterien[24]];
        break;
      case 'LagerEnvelope(Radwelle A)':
        this.kriterium = [this.kriterien[3], this.kriterien[11], this.kriterien[21]];
        break;
      case 'LagerEnvelope(Radwelle B)':
        this.kriterium = [this.kriterien[7], this.kriterien[15], this.kriterien[25]];
        break;
      default:
        this.kriterium = [];
        break;
    }

    if(this.kriterium.length > 0){
      for(let i = 0; i < 100; i++){
        this.dataMittel.push(f.messergebnisse[i].mittel);
        this.dataMax.push(f.messergebnisse[i].max);
        this.dataMin.push(f.messergebnisse[i].min);
        this.labels.push(f.messergebnisse[i].yWert.toString());
        this.kriteriumOneMin.push(this.kriterium[0].minWert);
        this.kriteriumOneMax.push(this.kriterium[0].maxWert);
        this.kriteriumTwoMin.push(this.kriterium[1].minWert);
        this.kriteriumTwoMax.push(this.kriterium[1].maxWert);
        this.kriteriumThreeMin.push(this.kriterium[2].minWert);
        this.kriteriumThreeMax.push(this.kriterium[2].maxWert);
      }
    }
    else{
      for(let i = 0; i < 100; i++){
        console.log(f.messergebnisse)
        this.dataMittel.push(f.messergebnisse[i].mittel);
        this.dataMax.push(f.messergebnisse[i].max);
        this.dataMin.push(f.messergebnisse[i].min);
        this.labels.push(f.messergebnisse[i].yWert.toString());
      }
    }
    if(this.kriterium.length > 0){
      this.dataPoints = [
        {fill: false, data: this.kriteriumOneMin, label: this.kriterium[0].name + " Min"},
        {fill: false, data: this.kriteriumOneMax, label: this.kriterium[0].name + " Max"},
        {fill: false, data: this.kriteriumTwoMin, label: this.kriterium[1].name + " Min"},
        {fill: false, data: this.kriteriumTwoMax, label: this.kriterium[1].name + " Max"},
        {fill: false, data: this.kriteriumThreeMin, label: this.kriterium[2].name + " Min"},
        {fill: false, data: this.kriteriumThreeMax, label: this.kriterium[2].name + " Max"},
        {fill: false, data: this.dataMittel, label: f.beschreibung + " Mittel"},
        {fill: false, data: this.dataMax, label: f.beschreibung + " Max"},
        {fill: false, data: this.dataMin, label: f.beschreibung + " Min"}
      ]
    }
    else{
      this.dataPoints = [
        {fill: false, data: this.dataMittel, label: f.beschreibung + " Mittel"},
        {fill: false, data: this.dataMax, label: f.beschreibung + " Max"},
        {fill: false, data: this.dataMin, label: f.beschreibung + " Min"}
      ]
    }

  }

  public push(): void {
    this.dataMittel = [];
    this.dataMax = [];
    this.dataMin = [];
    this.labels = [];
    let f: OEBBFunktion = new OEBBFunktion(0,'',0,0,0,0,this.messergebnisse);
    this.functions.forEach(element => {if(element.beschreibung === this.selectedFunction){f = element;}});
    if(f.messergebnisse[this.pushCount+50] === undefined){
      this.disabled = true;
    }
    for(let i = this.pushCount - 50; i < this.pushCount + 50; i++){
      this.dataMittel.push(f.messergebnisse[i].mittel);
      this.dataMax.push(f.messergebnisse[i].max);
      this.dataMin.push(f.messergebnisse[i].min);
      this.labels.push(f.messergebnisse[i].yWert.toString());
    }

    if(this.kriterium.length > 0){
      this.dataPoints = [
        {fill: false, data: this.kriteriumOneMin, label: this.kriterium[0].name + " Min"},
        {fill: false, data: this.kriteriumOneMax, label: this.kriterium[0].name + " Max"},
        {fill: false, data: this.kriteriumTwoMin, label: this.kriterium[1].name + " Min"},
        {fill: false, data: this.kriteriumTwoMax, label: this.kriterium[1].name + " Max"},
        {fill: false, data: this.kriteriumThreeMin, label: this.kriterium[2].name + " Min"},
        {fill: false, data: this.kriteriumThreeMax, label: this.kriterium[2].name + " Max"},
        {fill: false, data: this.dataMittel, label: f.beschreibung + " Mittel"},
        {fill: false, data: this.dataMax, label: f.beschreibung + " Max"},
        {fill: false, data: this.dataMin, label: f.beschreibung + " Min"}
      ]
    } else{
      this.dataPoints = [
        {fill: false, data: this.dataMittel, label: f.beschreibung + " Mittel"},
        {fill: false, data: this.dataMax, label: f.beschreibung + " Max"},
        {fill: false, data: this.dataMin, label: f.beschreibung + " Min"}
      ]
    }
    this.pushCount += 50;
  }
}
