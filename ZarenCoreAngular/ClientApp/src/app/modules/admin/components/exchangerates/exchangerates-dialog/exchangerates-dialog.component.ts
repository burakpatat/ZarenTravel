import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Exchangerates } from 'app/shared/models/exchangerates';


@Component({
    selector: 'exchangerates-dialog-cmp',
    templateUrl: 'exchangerates-dialog.component.html',
    styleUrls: ['exchangerates-dialog.component.css'],
	providers: [],
})
export class ExchangeRatesDialogComponent {
    exchangeratesObj: Exchangerates;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<ExchangeRatesDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public exchangerates: Exchangerates) {
        this.exchangeratesObj = Object.assign({}, exchangerates);
		
    }
	
	

    saveexchangerates(exchangerates: Exchangerates): void {
        this.dialogRef.close(exchangerates);
    }
}