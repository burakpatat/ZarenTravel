import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Passengerınformation } from 'app/shared/models/passengerınformation';


@Component({
    selector: 'passengerınformation-dialog-cmp',
    templateUrl: 'passengerınformation-dialog.component.html',
    styleUrls: ['passengerınformation-dialog.component.css'],
	providers: [],
})
export class PassengerInformationDialogComponent {
    passengerınformationObj: Passengerınformation;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<PassengerInformationDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public passengerınformation: Passengerınformation) {
        this.passengerınformationObj = Object.assign({}, passengerınformation);
		
    }
	
	

    savepassengerınformation(passengerınformation: Passengerınformation): void {
        this.dialogRef.close(passengerınformation);
    }
}