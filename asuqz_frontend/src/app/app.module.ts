import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ChartsModule } from 'ng2-charts';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OverviewComponent } from './overview/overview.component';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldControl, MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';
import { MatInputModule } from '@angular/material/input';
import { ShowFunctionComponent } from './show-function/show-function.component';
import { HttpClientModule } from '@angular/common/http';
import {MatCardModule} from '@angular/material/card';
import {MatDialogModule} from '@angular/material/dialog';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { DialogOverview } from './overview/dialog-overview';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatIconModule} from '@angular/material/icon';
import {MatList, MatListModule} from '@angular/material/list';
import { ChooseFileComponent } from './choose-file/choose-file.component';
import { ShowFunctionAuslaufComponent } from './show-function-auslauf/show-function-auslauf.component';
import { ShowFunctionSchlagComponent } from './show-function-schlag/show-function-schlag.component';
import { ShowFunctionWarmComponent } from './show-function-warm/show-function-warm.component';
import { ShowFunctionWuchtComponent } from './show-function-wucht/show-function-wucht.component';
import { EvaluateErrorComponent } from './evaluate-error/evaluate-error.component';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatToolbarModule} from '@angular/material/toolbar';

@NgModule({
  declarations: [
    AppComponent,
    OverviewComponent,
    ShowFunctionComponent,
    DialogOverview,
    ChooseFileComponent,
    ShowFunctionAuslaufComponent,
    ShowFunctionSchlagComponent,
    ShowFunctionWarmComponent,
    ShowFunctionWuchtComponent,
    EvaluateErrorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ChartsModule,
    MatSelectModule,
    MatFormFieldModule,
    MatButtonModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    MatSliderModule,
    MatInputModule,
    HttpClientModule,
    MatCardModule,
    MatDialogModule,
    MatCheckboxModule,
    MatExpansionModule,
    MatIconModule,
    MatListModule,
    MatSidenavModule,
    MatToolbarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
