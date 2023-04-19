import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Airline } from 'app/shared/models/airline';


@Component({
    selector: 'airline-dialog-cmp',
    templateUrl: 'airline-dialog.component.html',
    styleUrls: ['airline-dialog.component.css'],
	providers: [],
})
export class AirlineDialogComponent {
    airlineObj: Airline;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<AirlineDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public airline: Airline) {
        this.airlineObj = Object.assign({}, airline);
		
    }
	
	

    saveairline(airline: Airline): void {
        this.dialogRef.close(airline);
    }
}