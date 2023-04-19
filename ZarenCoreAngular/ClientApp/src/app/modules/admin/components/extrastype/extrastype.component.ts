import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { ExtrasTypeApiService } from 'app/core/services/extrastype.service';
import { MatDialog } from '@angular/material/dialog';
import { Extrastype } from 'app/shared/models/extrastype';
import { ExtrasTypeDialogComponent } from './extrastype-dialog/extrastype-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-ExtrasType-cmp',
    templateUrl: 'ExtrasType.component.html',
    providers: [ExtrasTypeApiService]
})

export class ExtrasTypeComponent implements OnInit, OnDestroy {
    public dtos: Extrastype[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private extrastypeApiService: ExtrasTypeApiService,
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
                emptyTable: 'Fetching ExtrasType...'
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

        this.getAllExtrasTypes();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllExtrasTypes() {
        this.extrastypeApiService.getAllExtrasTypes().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(ExtrasTypeDialogComponent, {
            width: '650px',
            data: new Extrastype()
        });

        dialogRef.afterClosed().subscribe(extrastype => {
            if (extrastype) {
                this.extrastypeApiService.addExtrasType(extrastype).subscribe(() => {
                    this.getAllExtrasTypes();
                    this.notificationsService.showNotification('Success', 'Extrastype added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(extrastype: Extrastype) {
        const dialogRef = this.dialog.open(ExtrasTypeDialogComponent, {
            width: '650px',
            data: extrastype
        });

        dialogRef.afterClosed().subscribe(extrastype => {
            if (extrastype) {
                this.extrastypeApiService.updateExtrasType(extrastype).subscribe(() => {
                    this.getAllExtrasTypes();
                    this.notificationsService.showNotification('Success', 'Extrastype updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(extrastype: Extrastype) {
        const dialogData = new ConfirmDialogModel("Really delete?", extrastype.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.extrastypeApiService.deleteExtrasType(extrastype.ıd).subscribe(() => {
                    this.getAllExtrasTypes();
                    this.notificationsService.showNotification('Success', 'Extrastype deleted successfully', 'success');
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

