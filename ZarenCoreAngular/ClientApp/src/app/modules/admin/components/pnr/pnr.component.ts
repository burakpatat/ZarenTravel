import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { PNRApiService } from 'app/core/services/pnr.service';
import { MatDialog } from '@angular/material/dialog';
import { Pnr } from 'app/shared/models/pnr';
import { PNRDialogComponent } from './pnr-dialog/pnr-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-PNR-cmp',
    templateUrl: 'PNR.component.html',
    providers: [PNRApiService]
})

export class PNRComponent implements OnInit, OnDestroy {
    public dtos: Pnr[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private pnrApiService: PNRApiService,
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
                emptyTable: 'Fetching PNR...'
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

        this.getAllPNRs();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllPNRs() {
        this.pnrApiService.getAllPNRs().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(PNRDialogComponent, {
            width: '650px',
            data: new Pnr()
        });

        dialogRef.afterClosed().subscribe(pnr => {
            if (pnr) {
                this.pnrApiService.addPNR(pnr).subscribe(() => {
                    this.getAllPNRs();
                    this.notificationsService.showNotification('Success', 'Pnr added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(pnr: Pnr) {
        const dialogRef = this.dialog.open(PNRDialogComponent, {
            width: '650px',
            data: pnr
        });

        dialogRef.afterClosed().subscribe(pnr => {
            if (pnr) {
                this.pnrApiService.updatePNR(pnr).subscribe(() => {
                    this.getAllPNRs();
                    this.notificationsService.showNotification('Success', 'Pnr updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(pnr: Pnr) {
        const dialogData = new ConfirmDialogModel("Really delete?", pnr.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.pnrApiService.deletePNR(pnr.ıd).subscribe(() => {
                    this.getAllPNRs();
                    this.notificationsService.showNotification('Success', 'Pnr deleted successfully', 'success');
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

