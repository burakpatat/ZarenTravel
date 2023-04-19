import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Companycustomfields } from 'app/shared/models/companycustomfields';


@Component({
    selector: 'companycustomfields-dialog-cmp',
    templateUrl: 'companycustomfields-dialog.component.html',
    styleUrls: ['companycustomfields-dialog.component.css'],
	providers: [],
})
export class CompanyCustomFieldsDialogComponent {
    companycustomfieldsObj: Companycustomfields;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<CompanyCustomFieldsDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public companycustomfields: Companycustomfields) {
        this.companycustomfieldsObj = Object.assign({}, companycustomfields);
		
    }
	
	

    savecompanycustomfields(companycustomfields: Companycustomfields): void {
        this.dialogRef.close(companycustomfields);
    }
}