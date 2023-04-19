import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Languages } from 'app/shared/models/languages';


@Component({
    selector: 'languages-dialog-cmp',
    templateUrl: 'languages-dialog.component.html',
    styleUrls: ['languages-dialog.component.css'],
	providers: [],
})
export class LanguagesDialogComponent {
    languagesObj: Languages;
	
	
    

    constructor(
        public dialogRef: MatDialogRef<LanguagesDialogComponent>,
		
        @Inject(MAT_DIALOG_DATA) public languages: Languages) {
        this.languagesObj = Object.assign({}, languages);
		
    }
	
	

    savelanguages(languages: Languages): void {
        this.dialogRef.close(languages);
    }
}