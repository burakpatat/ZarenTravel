import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Cartype } from 'app/shared/models/cartype';


@Component({
    selector: 'cartype-dialog-cmp',
    templateUrl: 'cartype-dialog.component.html',
    styleUrls: ['cartype-dialog.component.css'],
	providers: [],
})
export class CarTypeDialogComponent {
    cartypeObj: Cartype;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<CarTypeDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public cartype: Cartype) {
        this.cartypeObj = Object.assign({}, cartype);
		
    }
	
	

    savecartype(cartype: Cartype): void {
        this.dialogRef.close(cartype);
    }
}