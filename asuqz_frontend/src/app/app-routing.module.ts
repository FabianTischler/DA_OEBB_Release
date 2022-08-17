import { ShowFunctionWuchtComponent } from './show-function-wucht/show-function-wucht.component';
import { ShowFunctionSchlagComponent } from './show-function-schlag/show-function-schlag.component';
import { ShowFunctionAuslaufComponent } from './show-function-auslauf/show-function-auslauf.component';
import { ChooseFileComponent } from './choose-file/choose-file.component';
import { ShowFunctionComponent } from './show-function/show-function.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OverviewComponent } from './overview/overview.component';
import { ShowFunctionWarmComponent } from './show-function-warm/show-function-warm.component';
import { EvaluateErrorComponent } from './evaluate-error/evaluate-error.component';

const routes: Routes = [
  { path: 'overview', component: OverviewComponent },
  { path: 'show-function', component: ShowFunctionComponent},
  { path: 'choose-file', component: ChooseFileComponent},
  { path: 'show-function-auslauf', component: ShowFunctionAuslaufComponent},
  { path: 'show-function-schlaglauf', component: ShowFunctionSchlagComponent},
  { path: 'show-function-warmlauf', component: ShowFunctionWarmComponent},
  { path: 'show-function-wuchtlauf', component: ShowFunctionWuchtComponent},
  { path: 'evaluate-error', component: EvaluateErrorComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
