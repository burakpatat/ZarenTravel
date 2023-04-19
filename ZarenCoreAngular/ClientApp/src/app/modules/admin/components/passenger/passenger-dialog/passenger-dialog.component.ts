import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Passenger } from 'app/shared/models/passenger';


@Component({
    selector: 'passenger-dialog-cmp',
    templateUrl: 'passenger-dialog.component.html',
    styleUrls: ['passenger-dialog.component.css'],
	providers: [],
})
export class PassengerDialogComponent {
    passengerObj: Passenger;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<PassengerDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public passenger: Passenger) {
        this.passengerObj = Object.assign({}, passenger);
		
    }
	
	

    savepassenger(passenger: Passenger): void {
        this.dialogRef.close(passenger);
    }
}