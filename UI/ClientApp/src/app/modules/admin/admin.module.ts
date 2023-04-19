import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule, CoreModule } from '@angular/flex-layout';

import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatCheckboxModule} from '@angular/material/checkbox'
import {MatRippleModule} from '@angular/material/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatSelectModule} from '@angular/material/select';
import {MatDialogModule} from '@angular/material/dialog';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {MatRadioModule} from '@angular/material/radio';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatTabsModule} from '@angular/material/tabs';

import { DataTablesModule } from 'angular-datatables';

import { AdminRoutes } from './admin.routing';
import { HotelComponent } from './components/hotel/hotel.component';
import { HotelDialogComponent } from './components/hotel/hotel-dialog/hotel-dialog.component';


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminRoutes),
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatRippleModule,
    MatFormFieldModule,
    MatInputModule,
	MatCheckboxModule,
    MatSelectModule,
    MatTooltipModule,
    MatDialogModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatRadioModule,
    FlexLayoutModule,
    MatProgressBarModule,
	MatTabsModule,
    DataTablesModule,
    CoreModule
  ],
  declarations: [
  
HotelComponent,
HotelDialogComponent  
  ],
  entryComponents: [HotelComponent,HotelDialogComponent]
})

export class AdminModule { }
