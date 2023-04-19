import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Airextras } from 'app/shared/models/airextras';


@Component({
    selector: 'airextras-dialog-cmp',
    templateUrl: 'airextras-dialog.component.html',
    styleUrls: ['airextras-dialog.component.css'],
	providers: [],
})
export class AirExtrasDialogComponent {
    airextrasObj: Airextras;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<AirExtrasDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public airextras: Airextras) {
        this.airextrasObj = Object.assign({}, airextras);
		
    }
	
	

    saveairextras(airextras: Airextras): void {
        this.dialogRef.close(airextras);
    }
}