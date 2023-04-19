import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Agency } from 'app/shared/models/agency';


@Component({
    selector: 'agency-dialog-cmp',
    templateUrl: 'agency-dialog.component.html',
    styleUrls: ['agency-dialog.component.css'],
	providers: [],
})
export class AgencyDialogComponent {
    agencyObj: Agency;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<AgencyDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public agency: Agency) {
        this.agencyObj = Object.assign({}, agency);
		
    }
	
	

    saveagency(agency: Agency): void {
        this.dialogRef.close(agency);
    }
}