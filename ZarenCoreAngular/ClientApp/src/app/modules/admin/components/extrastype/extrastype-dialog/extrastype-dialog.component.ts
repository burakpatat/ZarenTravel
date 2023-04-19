import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Extrastype } from 'app/shared/models/extrastype';


@Component({
    selector: 'extrastype-dialog-cmp',
    templateUrl: 'extrastype-dialog.component.html',
    styleUrls: ['extrastype-dialog.component.css'],
	providers: [],
})
export class ExtrasTypeDialogComponent {
    extrastypeObj: Extrastype;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<ExtrasTypeDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public extrastype: Extrastype) {
        this.extrastypeObj = Object.assign({}, extrastype);
		
    }
	
	

    saveextrastype(extrastype: Extrastype): void {
        this.dialogRef.close(extrastype);
    }
}