import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Terminal } from 'app/shared/models/terminal';


@Component({
    selector: 'terminal-dialog-cmp',
    templateUrl: 'terminal-dialog.component.html',
    styleUrls: ['terminal-dialog.component.css'],
	providers: [],
})
export class TerminalDialogComponent {
    terminalObj: Terminal;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<TerminalDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public terminal: Terminal) {
        this.terminalObj = Object.assign({}, terminal);
		
    }
	
	

    saveterminal(terminal: Terminal): void {
        this.dialogRef.close(terminal);
    }
}