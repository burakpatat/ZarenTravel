import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Gds } from 'app/shared/models/gds';


@Component({
    selector: 'gds-dialog-cmp',
    templateUrl: 'gds-dialog.component.html',
    styleUrls: ['gds-dialog.component.css'],
	providers: [],
})
export class GDSDialogComponent {
    gdsObj: Gds;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<GDSDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public gds: Gds) {
        this.gdsObj = Object.assign({}, gds);
		
    }
	
	

    savegds(gds: Gds): void {
        this.dialogRef.close(gds);
    }
}