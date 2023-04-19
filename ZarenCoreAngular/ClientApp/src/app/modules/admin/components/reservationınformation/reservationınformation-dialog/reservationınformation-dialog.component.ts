import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Reservationınformation } from 'app/shared/models/reservationınformation';


@Component({
    selector: 'reservationınformation-dialog-cmp',
    templateUrl: 'reservationınformation-dialog.component.html',
    styleUrls: ['reservationınformation-dialog.component.css'],
	providers: [],
})
export class ReservationInformationDialogComponent {
    reservationınformationObj: Reservationınformation;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<ReservationInformationDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public reservationınformation: Reservationınformation) {
        this.reservationınformationObj = Object.assign({}, reservationınformation);
		
    }
	
	

    savereservationınformation(reservationınformation: Reservationınformation): void {
        this.dialogRef.close(reservationınformation);
    }
}