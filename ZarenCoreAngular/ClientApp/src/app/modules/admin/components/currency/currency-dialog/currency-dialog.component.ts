import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Currency } from 'app/shared/models/currency';


@Component({
    selector: 'currency-dialog-cmp',
    templateUrl: 'currency-dialog.component.html',
    styleUrls: ['currency-dialog.component.css'],
	providers: [],
})
export class CurrencyDialogComponent {
    currencyObj: Currency;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<CurrencyDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public currency: Currency) {
        this.currencyObj = Object.assign({}, currency);
		
    }
	
	

    savecurrency(currency: Currency): void {
        this.dialogRef.close(currency);
    }
}