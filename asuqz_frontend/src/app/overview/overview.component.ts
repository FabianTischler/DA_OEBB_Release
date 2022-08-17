import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ChartDataSets, ChartType } from 'chart.js';
import { BaseChartDirective, ChartsModule, Color, Label } from 'ng2-charts';
import { OEBBPruefer } from 'src/models/oebb-pruefer';
import { DialogOverview } from './dialog-overview';


@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit {
  dataPointsBWA: ChartDataSets[] = [];
  BWALabels: Label[] = [ '0.000', '0.6250', '1.2500', '1.8750', '2.5000', '3.1250', '3.7500', '4.3750'];
  dataPointsBWB: ChartDataSets[] = [];
  BWBLabels: Label[] = [ '0.000', '0.6250', '1.2500', '1.8750', '2.5000', '3.1250', '3.7500', '4.3750'];
  dataPointsMWA: ChartDataSets[] = [];
  MWALabels: Label[] = [ '0.000', '0.6250', '1.2500', '1.8750', '2.5000', '3.1250', '3.7500', '4.3750'];
  dataPointsMWB: ChartDataSets[] = [];
  MWBLabels: Label[] = [ '0.000', '0.6250', '1.2500', '1.8750', '2.5000', '3.1250', '3.7500', '4.3750'];
  dataPointsRWA: ChartDataSets[] = [];
  RWALabels: Label[] = [ '0.000', '0.6250', '1.2500', '1.8750', '2.5000', '3.1250', '3.7500', '4.3750'];
  dataPointsRWB: ChartDataSets[] = [];
  RWBLabels: Label[] = [ '0.000', '0.6250', '1.2500', '1.8750', '2.5000', '3.1250', '3.7500', '4.3750'];

  options = {
    responsive: false
  };
  colors: Color[] = [
    {
      borderColor: 'black',
    },
  ];
  legend = true;
  plugins = [];
  type: ChartType = 'line';


  pruefers: OEBBPruefer[] = [
    { p_id: 0, p_nachname: 'Tischler', p_vorname: 'Fabian'},
    { p_id: 1, p_nachname: 'Trinkl', p_vorname: 'Philip'}
  ];

  //selectedPruefer: string = '';
  selectedPruefer: OEBBPruefer = new OEBBPruefer(0, '', '')

  constructor(public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  loadChartData(){
    this.dataPointsBWA = [{data: [-30.0431, -29.0684, -28.7432, -28.2064, -27.8274, -27.9592, -25.7714, -28.1736], label: 'Lager Bremswelle A'}]
    this.dataPointsBWB = [{data: [-31.0431, -28.0684, -30.7432, -30.1064, -28.8274, -31.9592, -24.7714, -30.1736], label: 'Lager Bremswelle B'}]
    this.dataPointsMWA = [{data: [-27.0431, -28.0684, -30.7432, -27.1064, -30.8274, -29.9592, -24.7714, -31.1736], label: 'Lager Motorwelle A'}]
    this.dataPointsMWB = [{data: [-31.0431, -28.0684, -30.7432, -30.1064, -27.8274, -24.9592, -24.7714, -25.1736], label: 'Lager Motorwelle B'}]
    this.dataPointsRWA = [{data: [-28.0431, -28.0684, -31.7432, -27.1064, -24.8274, -29.9592, -24.7714, -30.1736], label: 'Lager Radwelle A'}]
    this.dataPointsRWB = [{data: [-31.0431, -28.0684, -30.7432, -30.1064, -27.8274, -30.9592, -28.7714, -25.1736], label: 'Lager Radwelle B'}]
  }

  clearCharts(){
    this.dataPointsBWA = [{data: [], label: ''}]
    this.dataPointsBWB = [{data: [], label: ''}]
    this.dataPointsMWA = [{data: [], label: ''}]
    this.dataPointsMWB = [{data: [], label: ''}]
    this.dataPointsRWA = [{data: [], label: ''}]
    this.dataPointsRWB = [{data: [], label: ''}]
  }

  openDialog(): void{
    const dialogRef = this.dialog.open(DialogOverview, {
      width: '300',
      height: '500',
      data: {pruefer: this.selectedPruefer}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('Prüfung wurde gespeichert');
    });
  }
}
