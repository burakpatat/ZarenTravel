import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Pcc } from 'app/shared/models/pcc';


@Component({
    selector: 'pcc-dialog-cmp',
    templateUrl: 'pcc-dialog.component.html',
    styleUrls: ['pcc-dialog.component.css'],
	providers: [],
})
export class PCCDialogComponent {
    pccObj: Pcc;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<PCCDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public pcc: Pcc) {
        this.pccObj = Object.assign({}, pcc);
		
    }
	
	

    savepcc(pcc: Pcc): void {
        this.dialogRef.close(pcc);
    }
}