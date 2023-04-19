import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Agentınformation } from 'app/shared/models/agentınformation';


@Component({
    selector: 'agentınformation-dialog-cmp',
    templateUrl: 'agentınformation-dialog.component.html',
    styleUrls: ['agentınformation-dialog.component.css'],
	providers: [],
})
export class AgentInformationDialogComponent {
    agentınformationObj: Agentınformation;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<AgentInformationDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public agentınformation: Agentınformation) {
        this.agentınformationObj = Object.assign({}, agentınformation);
		
    }
	
	

    saveagentınformation(agentınformation: Agentınformation): void {
        this.dialogRef.close(agentınformation);
    }
}