import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Agencygroup } from 'app/shared/models/agencygroup';


@Component({
    selector: 'agencygroup-dialog-cmp',
    templateUrl: 'agencygroup-dialog.component.html',
    styleUrls: ['agencygroup-dialog.component.css'],
	providers: [],
})
export class AgencyGroupDialogComponent {
    agencygroupObj: Agencygroup;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<AgencyGroupDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public agencygroup: Agencygroup) {
        this.agencygroupObj = Object.assign({}, agencygroup);
		
    }
	
	

    saveagencygroup(agencygroup: Agencygroup): void {
        this.dialogRef.close(agencygroup);
    }
}