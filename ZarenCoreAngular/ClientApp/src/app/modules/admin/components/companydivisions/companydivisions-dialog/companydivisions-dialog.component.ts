import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Companydivisions } from 'app/shared/models/companydivisions';


@Component({
    selector: 'companydivisions-dialog-cmp',
    templateUrl: 'companydivisions-dialog.component.html',
    styleUrls: ['companydivisions-dialog.component.css'],
	providers: [],
})
export class CompanyDivisionsDialogComponent {
    companydivisionsObj: Companydivisions;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<CompanyDivisionsDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public companydivisions: Companydivisions) {
        this.companydivisionsObj = Object.assign({}, companydivisions);
		
    }
	
	

    savecompanydivisions(companydivisions: Companydivisions): void {
        this.dialogRef.close(companydivisions);
    }
}