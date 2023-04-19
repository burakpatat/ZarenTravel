import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { LanguagesApiService } from 'app/core/services/languages.service';
import { MatDialog } from '@angular/material/dialog';
import { Languages } from 'app/shared/models/languages';
import { LanguagesDialogComponent } from './languages-dialog/languages-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-Languages-cmp',
    templateUrl: 'Languages.component.html',
    providers: [LanguagesApiService]
})

export class LanguagesComponent implements OnInit, OnDestroy {
    public dtos: Languages[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private languagesApiService: LanguagesApiService,
        private notificationsService: NotificationsService) { }

    ngOnInit() {
        this.dtOptions = {
            pagingType: 'full_numbers',
            lengthMenu: [
                [5, 10, 20, -1],
                [5, 10, 20, 'All']
            ],
            language: {
                search: '_INPUT_',
                searchPlaceholder: 'Search records',
                emptyTable: 'Fetching Languages...'
            },
            scrollX: true,
            responsive: true,
            // Declare the use of the extension in the dom parameter
            dom: 'Bfrtip',
            
            buttons: [
                
                'copy',
                'print',
                'excel',
                
            ]
        };

        this.getAllLanguagess();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllLanguagess() {
        this.languagesApiService.getAllLanguagess().subscribe(dtos => {
            this.dtos = dtos;
            if (this.dtos.length == 0) {
                this.dtOptions.language.emptyTable = 'No dtos available yet.';
            }

            this.renderDataTable();
        }, (err) => {
            this.renderDataTable();
            this.dtOptions.language.emptyTable = 'Error while fetching dtos, pls try refreshing the page or contact admin.';
            this.notificationsService.showNotification('Error', err.message, 'warning');
        });
    }

    addDialog() {
        const dialogRef = this.dialog.open(LanguagesDialogComponent, {
            width: '650px',
            data: new Languages()
        });

        dialogRef.afterClosed().subscribe(languages => {
            if (languages) {
                this.languagesApiService.addLanguages(languages).subscribe(() => {
                    this.getAllLanguagess();
                    this.notificationsService.showNotification('Success', 'Languages added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(languages: Languages) {
        const dialogRef = this.dialog.open(LanguagesDialogComponent, {
            width: '650px',
            data: languages
        });

        dialogRef.afterClosed().subscribe(languages => {
            if (languages) {
                this.languagesApiService.updateLanguages(languages).subscribe(() => {
                    this.getAllLanguagess();
                    this.notificationsService.showNotification('Success', 'Languages updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(languages: Languages) {
        const dialogData = new ConfirmDialogModel("Really delete?", languages.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.languagesApiService.deleteLanguages(languages.ıd).subscribe(() => {
                    this.getAllLanguagess();
                    this.notificationsService.showNotification('Success', 'Languages deleted successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    renderDataTable(): void {
        if (this.dtElement && this.dtElement.dtInstance) {
            this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
                dtInstance.destroy();
            });
        }

        this.dtTrigger.next();
    }

    ngOnDestroy(): void {
        this.dtTrigger.unsubscribe();
    }
}

