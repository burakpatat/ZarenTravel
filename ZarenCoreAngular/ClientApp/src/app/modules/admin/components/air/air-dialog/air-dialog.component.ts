import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Air } from 'app/shared/models/air';


@Component({
    selector: 'air-dialog-cmp',
    templateUrl: 'air-dialog.component.html',
    styleUrls: ['air-dialog.component.css'],
	providers: [],
})
export class AirDialogComponent {
    airObj: Air;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<AirDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public air: Air) {
        this.airObj = Object.assign({}, air);
		
    }
	
	

    saveair(air: Air): void {
        this.dialogRef.close(air);
    }
}