import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Accommodation } from 'app/shared/models/accommodation';


@Component({
    selector: 'accommodation-dialog-cmp',
    templateUrl: 'accommodation-dialog.component.html',
    styleUrls: ['accommodation-dialog.component.css'],
	providers: [],
})
export class AccommodationDialogComponent {
    accommodationObj: Accommodation;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<AccommodationDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public accommodation: Accommodation) {
        this.accommodationObj = Object.assign({}, accommodation);
		
    }
	
	

    saveaccommodation(accommodation: Accommodation): void {
        this.dialogRef.close(accommodation);
    }
}