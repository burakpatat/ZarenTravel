import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Fieldstype } from 'app/shared/models/fieldstype';


@Component({
    selector: 'fieldstype-dialog-cmp',
    templateUrl: 'fieldstype-dialog.component.html',
    styleUrls: ['fieldstype-dialog.component.css'],
	providers: [],
})
export class FieldsTypeDialogComponent {
    fieldstypeObj: Fieldstype;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<FieldsTypeDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public fieldstype: Fieldstype) {
        this.fieldstypeObj = Object.assign({}, fieldstype);
		
    }
	
	

    savefieldstype(fieldstype: Fieldstype): void {
        this.dialogRef.close(fieldstype);
    }
}