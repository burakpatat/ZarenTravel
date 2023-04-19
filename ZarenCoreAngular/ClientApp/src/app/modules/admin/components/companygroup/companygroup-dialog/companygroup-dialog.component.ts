import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Companygroup } from 'app/shared/models/companygroup';


@Component({
    selector: 'companygroup-dialog-cmp',
    templateUrl: 'companygroup-dialog.component.html',
    styleUrls: ['companygroup-dialog.component.css'],
	providers: [],
})
export class CompanyGroupDialogComponent {
    companygroupObj: Companygroup;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<CompanyGroupDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public companygroup: Companygroup) {
        this.companygroupObj = Object.assign({}, companygroup);
		
    }
	
	

    savecompanygroup(companygroup: Companygroup): void {
        this.dialogRef.close(companygroup);
    }
}