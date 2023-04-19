import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Customerınformation } from 'app/shared/models/customerınformation';


@Component({
    selector: 'customerınformation-dialog-cmp',
    templateUrl: 'customerınformation-dialog.component.html',
    styleUrls: ['customerınformation-dialog.component.css'],
	providers: [],
})
export class CustomerInformationDialogComponent {
    customerınformationObj: Customerınformation;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<CustomerInformationDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public customerınformation: Customerınformation) {
        this.customerınformationObj = Object.assign({}, customerınformation);
		
    }
	
	

    savecustomerınformation(customerınformation: Customerınformation): void {
        this.dialogRef.close(customerınformation);
    }
}