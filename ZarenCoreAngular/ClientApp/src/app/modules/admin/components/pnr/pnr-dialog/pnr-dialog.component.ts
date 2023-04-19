import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Pnr } from 'app/shared/models/pnr';


@Component({
    selector: 'pnr-dialog-cmp',
    templateUrl: 'pnr-dialog.component.html',
    styleUrls: ['pnr-dialog.component.css'],
	providers: [],
})
export class PNRDialogComponent {
    pnrObj: Pnr;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<PNRDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public pnr: Pnr) {
        this.pnrObj = Object.assign({}, pnr);
		
    }
	
	

    savepnr(pnr: Pnr): void {
        this.dialogRef.close(pnr);
    }
}