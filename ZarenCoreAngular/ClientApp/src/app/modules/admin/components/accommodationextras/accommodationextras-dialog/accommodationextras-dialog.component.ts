import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Accommodationextras } from 'app/shared/models/accommodationextras';


@Component({
    selector: 'accommodationextras-dialog-cmp',
    templateUrl: 'accommodationextras-dialog.component.html',
    styleUrls: ['accommodationextras-dialog.component.css'],
	providers: [],
})
export class AccommodationExtrasDialogComponent {
    accommodationextrasObj: Accommodationextras;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<AccommodationExtrasDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public accommodationextras: Accommodationextras) {
        this.accommodationextrasObj = Object.assign({}, accommodationextras);
		
    }
	
	

    saveaccommodationextras(accommodationextras: Accommodationextras): void {
        this.dialogRef.close(accommodationextras);
    }
}