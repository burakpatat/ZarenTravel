import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Country } from 'app/shared/models/country';


@Component({
    selector: 'country-dialog-cmp',
    templateUrl: 'country-dialog.component.html',
    styleUrls: ['country-dialog.component.css'],
	providers: [],
})
export class CountryDialogComponent {
    countryObj: Country;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<CountryDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public country: Country) {
        this.countryObj = Object.assign({}, country);
		
    }
	
	

    savecountry(country: Country): void {
        this.dialogRef.close(country);
    }
}