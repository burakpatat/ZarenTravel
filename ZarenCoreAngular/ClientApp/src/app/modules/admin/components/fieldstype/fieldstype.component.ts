import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { FieldsTypeApiService } from 'app/core/services/fieldstype.service';
import { MatDialog } from '@angular/material/dialog';
import { Fieldstype } from 'app/shared/models/fieldstype';
import { FieldsTypeDialogComponent } from './fieldstype-dialog/fieldstype-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-FieldsType-cmp',
    templateUrl: 'FieldsType.component.html',
    providers: [FieldsTypeApiService]
})

export class FieldsTypeComponent implements OnInit, OnDestroy {
    public dtos: Fieldstype[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private fieldstypeApiService: FieldsTypeApiService,
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
                emptyTable: 'Fetching FieldsType...'
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

        this.getAllFieldsTypes();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllFieldsTypes() {
        this.fieldstypeApiService.getAllFieldsTypes().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(FieldsTypeDialogComponent, {
            width: '650px',
            data: new Fieldstype()
        });

        dialogRef.afterClosed().subscribe(fieldstype => {
            if (fieldstype) {
                this.fieldstypeApiService.addFieldsType(fieldstype).subscribe(() => {
                    this.getAllFieldsTypes();
                    this.notificationsService.showNotification('Success', 'Fieldstype added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(fieldstype: Fieldstype) {
        const dialogRef = this.dialog.open(FieldsTypeDialogComponent, {
            width: '650px',
            data: fieldstype
        });

        dialogRef.afterClosed().subscribe(fieldstype => {
            if (fieldstype) {
                this.fieldstypeApiService.updateFieldsType(fieldstype).subscribe(() => {
                    this.getAllFieldsTypes();
                    this.notificationsService.showNotification('Success', 'Fieldstype updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(fieldstype: Fieldstype) {
        const dialogData = new ConfirmDialogModel("Really delete?", fieldstype.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.fieldstypeApiService.deleteFieldsType(fieldstype.ıd).subscribe(() => {
                    this.getAllFieldsTypes();
                    this.notificationsService.showNotification('Success', 'Fieldstype deleted successfully', 'success');
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

