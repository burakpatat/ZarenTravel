import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Pnrcustomfields } from 'app/shared/models/pnrcustomfields';


@Component({
    selector: 'pnrcustomfields-dialog-cmp',
    templateUrl: 'pnrcustomfields-dialog.component.html',
    styleUrls: ['pnrcustomfields-dialog.component.css'],
	providers: [],
})
export class PNRCustomFieldsDialogComponent {
    pnrcustomfieldsObj: Pnrcustomfields;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<PNRCustomFieldsDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public pnrcustomfields: Pnrcustomfields) {
        this.pnrcustomfieldsObj = Object.assign({}, pnrcustomfields);
		
    }
	
	

    savepnrcustomfields(pnrcustomfields: Pnrcustomfields): void {
        this.dialogRef.close(pnrcustomfields);
    }
}