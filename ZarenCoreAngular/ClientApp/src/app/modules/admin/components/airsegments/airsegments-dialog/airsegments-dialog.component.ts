import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Airsegments } from 'app/shared/models/airsegments';


@Component({
    selector: 'airsegments-dialog-cmp',
    templateUrl: 'airsegments-dialog.component.html',
    styleUrls: ['airsegments-dialog.component.css'],
	providers: [],
})
export class AirSegmentsDialogComponent {
    airsegmentsObj: Airsegments;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<AirSegmentsDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public airsegments: Airsegments) {
        this.airsegmentsObj = Object.assign({}, airsegments);
		
    }
	
	

    saveairsegments(airsegments: Airsegments): void {
        this.dialogRef.close(airsegments);
    }
}