import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Company } from 'app/shared/models/company';


@Component({
    selector: 'company-dialog-cmp',
    templateUrl: 'company-dialog.component.html',
    styleUrls: ['company-dialog.component.css'],
	providers: [],
})
export class CompanyDialogComponent {
    companyObj: Company;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<CompanyDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public company: Company) {
        this.companyObj = Object.assign({}, company);
		
    }
	
	

    savecompany(company: Company): void {
        this.dialogRef.close(company);
    }
}