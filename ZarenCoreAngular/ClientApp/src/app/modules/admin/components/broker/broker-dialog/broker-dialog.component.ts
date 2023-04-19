import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Broker } from 'app/shared/models/broker';


@Component({
    selector: 'broker-dialog-cmp',
    templateUrl: 'broker-dialog.component.html',
    styleUrls: ['broker-dialog.component.css'],
	providers: [],
})
export class BrokerDialogComponent {
    brokerObj: Broker;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<BrokerDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public broker: Broker) {
        this.brokerObj = Object.assign({}, broker);
		
    }
	
	

    savebroker(broker: Broker): void {
        this.dialogRef.close(broker);
    }
}