import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { PNRCustomFieldsApiService } from 'app/core/services/pnrcustomfields.service';
import { MatDialog } from '@angular/material/dialog';
import { Pnrcustomfields } from 'app/shared/models/pnrcustomfields';
import { PNRCustomFieldsDialogComponent } from './pnrcustomfields-dialog/pnrcustomfields-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-PNRCustomFields-cmp',
    templateUrl: 'PNRCustomFields.component.html',
    providers: [PNRCustomFieldsApiService]
})

export class PNRCustomFieldsComponent implements OnInit, OnDestroy {
    public dtos: Pnrcustomfields[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private pnrcustomfieldsApiService: PNRCustomFieldsApiService,
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
                emptyTable: 'Fetching PNRCustomFields...'
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

        this.getAllPNRCustomFieldss();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllPNRCustomFieldss() {
        this.pnrcustomfieldsApiService.getAllPNRCustomFieldss().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(PNRCustomFieldsDialogComponent, {
            width: '650px',
            data: new Pnrcustomfields()
        });

        dialogRef.afterClosed().subscribe(pnrcustomfields => {
            if (pnrcustomfields) {
                this.pnrcustomfieldsApiService.addPNRCustomFields(pnrcustomfields).subscribe(() => {
                    this.getAllPNRCustomFieldss();
                    this.notificationsService.showNotification('Success', 'Pnrcustomfields added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(pnrcustomfields: Pnrcustomfields) {
        const dialogRef = this.dialog.open(PNRCustomFieldsDialogComponent, {
            width: '650px',
            data: pnrcustomfields
        });

        dialogRef.afterClosed().subscribe(pnrcustomfields => {
            if (pnrcustomfields) {
                this.pnrcustomfieldsApiService.updatePNRCustomFields(pnrcustomfields).subscribe(() => {
                    this.getAllPNRCustomFieldss();
                    this.notificationsService.showNotification('Success', 'Pnrcustomfields updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(pnrcustomfields: Pnrcustomfields) {
        const dialogData = new ConfirmDialogModel("Really delete?", pnrcustomfields.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.pnrcustomfieldsApiService.deletePNRCustomFields(pnrcustomfields.ıd).subscribe(() => {
                    this.getAllPNRCustomFieldss();
                    this.notificationsService.showNotification('Success', 'Pnrcustomfields deleted successfully', 'success');
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

