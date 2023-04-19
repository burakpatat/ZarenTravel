import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Hotelcodes } from 'app/shared/models/hotelcodes';


@Component({
    selector: 'hotelcodes-dialog-cmp',
    templateUrl: 'hotelcodes-dialog.component.html',
    styleUrls: ['hotelcodes-dialog.component.css'],
	providers: [],
})
export class HotelCodesDialogComponent {
    hotelcodesObj: Hotelcodes;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<HotelCodesDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public hotelcodes: Hotelcodes) {
        this.hotelcodesObj = Object.assign({}, hotelcodes);
		
    }
	
	

    savehotelcodes(hotelcodes: Hotelcodes): void {
        this.dialogRef.close(hotelcodes);
    }
}