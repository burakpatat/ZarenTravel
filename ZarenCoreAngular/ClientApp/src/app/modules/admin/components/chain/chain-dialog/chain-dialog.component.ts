import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Chain } from 'app/shared/models/chain';


@Component({
    selector: 'chain-dialog-cmp',
    templateUrl: 'chain-dialog.component.html',
    styleUrls: ['chain-dialog.component.css'],
	providers: [],
})
export class ChainDialogComponent {
    chainObj: Chain;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<ChainDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public chain: Chain) {
        this.chainObj = Object.assign({}, chain);
		
    }
	
	

    savechain(chain: Chain): void {
        this.dialogRef.close(chain);
    }
}