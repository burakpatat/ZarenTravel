import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Hotel } from 'app/shared/models/hotel';


@Component({
    selector: 'hotel-dialog-cmp',
    templateUrl: 'hotel-dialog.component.html',
    styleUrls: ['hotel-dialog.component.css'],
	providers: [],
})
export class HotelDialogComponent {
    hotelObj: Hotel;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<HotelDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public hotel: Hotel) {
        this.hotelObj = Object.assign({}, hotel);
		
    }
	
	

    savehotel(hotel: Hotel): void {
        this.dialogRef.close(hotel);
    }
}