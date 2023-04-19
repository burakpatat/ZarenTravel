import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Industrysegment } from 'app/shared/models/ındustrysegment';


@Component({
    selector: 'ındustrysegment-dialog-cmp',
    templateUrl: 'ındustrysegment-dialog.component.html',
    styleUrls: ['ındustrysegment-dialog.component.css'],
	providers: [],
})
export class IndustrySegmentDialogComponent {
    ındustrysegmentObj: Industrysegment;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<IndustrySegmentDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public ındustrysegment: Industrysegment) {
        this.ındustrysegmentObj = Object.assign({}, ındustrysegment);
		
    }
	
	

    saveındustrysegment(ındustrysegment: Industrysegment): void {
        this.dialogRef.close(ındustrysegment);
    }
}