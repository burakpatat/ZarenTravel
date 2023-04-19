import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Roomtype } from 'app/shared/models/roomtype';


@Component({
    selector: 'roomtype-dialog-cmp',
    templateUrl: 'roomtype-dialog.component.html',
    styleUrls: ['roomtype-dialog.component.css'],
	providers: [],
})
export class RoomTypeDialogComponent {
    roomtypeObj: Roomtype;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<RoomTypeDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public roomtype: Roomtype) {
        this.roomtypeObj = Object.assign({}, roomtype);
		
    }
	
	

    saveroomtype(roomtype: Roomtype): void {
        this.dialogRef.close(roomtype);
    }
}