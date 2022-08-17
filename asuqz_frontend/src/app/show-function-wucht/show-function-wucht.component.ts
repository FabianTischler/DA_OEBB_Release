import { Component, OnInit } from '@angular/core';
import { ChartDataSets, ChartType } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { OEBBFunktion } from 'src/models/oebb-funktion';
import { OEBBKriterien } from 'src/models/oebb-kriterien';
import { OEBBMessergebnisse } from 'src/models/oebb-messergebnisse';
import { OebbService } from '../oebb.service';

@Component({
  selector: 'app-show-function-wucht',
  templateUrl: './show-function-wucht.component.html',
  styleUrls: ['./show-function-wucht.component.css']
})
export class ShowFunctionWuchtComponent implements OnInit {
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
    this.pushCount = 50;
    let f: OEBBFunktion = new OEBBFunktion(0,'',0,0,0,0,this.messergebnisse);
    this.functions.forEach(element => {
      if(element.beschreibung === this.selectedFunction){
        f = element;
      }
    });

    switch(f.beschreibung){
      case 'DLL.PHASE A':
        this.kriterium = [this.kriterien[2]];
        break;
      case 'DLL.PHASE B':
        this.kriterium = [this.kriterien[3]];
        break;
      case 'Wuchtenv10 (Radwelle A)':
        this.kriterium = [this.kriterien[5]];
        break;
      case 'Wuchtenv20 (Radwelle B)':
        this.kriterium = [this.kriterien[6]];
        break;
      default:
        this.kriterium = [];
        break;
    }

    if(this.kriterium.length > 0 && this.messergebnisse.length != 1){
      for(let i = 0; i < 100; i++){
        this.dataMittel.push(f.messergebnisse[i].mittel);
        this.dataMax.push(f.messergebnisse[i].max);
        this.dataMin.push(f.messergebnisse[i].min);
        this.labels.push(f.messergebnisse[i].yWert.toString());
      }
    }
    else if(this.messergebnisse.length == 1 && this.kriterium.length > 0){
      this.disabled = true;
      for(let i = 0; i < 50; i++){
        this.dataMittel.push(f.messergebnisse[0].mittel);
        this.dataMax.push(f.messergebnisse[0].max);
        this.dataMin.push(f.messergebnisse[0].min);
        this.labels.push(f.messergebnisse[0].yWert.toString());
        this.kriteriumOneMin.push(this.kriterium[0].minWert);
        this.kriteriumOneMax.push(this.kriterium[0].maxWert);
      }
    }
    else{
      for(let i = 0; i < 100; i++){
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
    this.functions.forEach(element => {
      if(element.beschreibung === this.selectedFunction){
        f = element;
      }
    });
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
    this.pushCount += 50;
  }

}
