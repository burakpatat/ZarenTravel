import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { City } from 'app/shared/models/city';


@Component({
    selector: 'city-dialog-cmp',
    templateUrl: 'city-dialog.component.html',
    styleUrls: ['city-dialog.component.css'],
	providers: [],
})
export class CityDialogComponent {
    cityObj: City;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<CityDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public city: City) {
        this.cityObj = Object.assign({}, city);
		
    }
	
	

    savecity(city: City): void {
        this.dialogRef.close(city);
    }
}