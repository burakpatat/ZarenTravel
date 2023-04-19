import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Airport } from 'app/shared/models/airport';


@Component({
    selector: 'airport-dialog-cmp',
    templateUrl: 'airport-dialog.component.html',
    styleUrls: ['airport-dialog.component.css'],
	providers: [],
})
export class AirportDialogComponent {
    airportObj: Airport;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<AirportDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public airport: Airport) {
        this.airportObj = Object.assign({}, airport);
		
    }
	
	

    saveairport(airport: Airport): void {
        this.dialogRef.close(airport);
    }
}