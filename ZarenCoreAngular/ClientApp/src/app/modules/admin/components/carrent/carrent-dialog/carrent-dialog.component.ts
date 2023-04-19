import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Carrent } from 'app/shared/models/carrent';


@Component({
    selector: 'carrent-dialog-cmp',
    templateUrl: 'carrent-dialog.component.html',
    styleUrls: ['carrent-dialog.component.css'],
	providers: [],
})
export class carrentDialogComponent {
    carrentObj: Carrent;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<carrentDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public carrent: Carrent) {
        this.carrentObj = Object.assign({}, carrent);
		
    }
	
	

    savecarrent(carrent: Carrent): void {
        this.dialogRef.close(carrent);
    }
}