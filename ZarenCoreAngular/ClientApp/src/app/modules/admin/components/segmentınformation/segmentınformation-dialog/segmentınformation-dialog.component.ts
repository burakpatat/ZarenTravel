import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Segmentınformation } from 'app/shared/models/segmentınformation';


@Component({
    selector: 'segmentınformation-dialog-cmp',
    templateUrl: 'segmentınformation-dialog.component.html',
    styleUrls: ['segmentınformation-dialog.component.css'],
	providers: [],
})
export class SegmentInformationDialogComponent {
    segmentınformationObj: Segmentınformation;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<SegmentInformationDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public segmentınformation: Segmentınformation) {
        this.segmentınformationObj = Object.assign({}, segmentınformation);
		
    }
	
	

    savesegmentınformation(segmentınformation: Segmentınformation): void {
        this.dialogRef.close(segmentınformation);
    }
}