import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Carrental } from 'app/shared/models/carrental';


@Component({
    selector: 'carrental-dialog-cmp',
    templateUrl: 'carrental-dialog.component.html',
    styleUrls: ['carrental-dialog.component.css'],
	providers: [],
})
export class CarRentalDialogComponent {
    carrentalObj: Carrental;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<CarRentalDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public carrental: Carrental) {
        this.carrentalObj = Object.assign({}, carrental);
		
    }
	
	

    savecarrental(carrental: Carrental): void {
        this.dialogRef.close(carrental);
    }
}