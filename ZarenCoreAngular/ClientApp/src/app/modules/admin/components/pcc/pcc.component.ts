import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { PCCApiService } from 'app/core/services/pcc.service';
import { MatDialog } from '@angular/material/dialog';
import { Pcc } from 'app/shared/models/pcc';
import { PCCDialogComponent } from './pcc-dialog/pcc-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-PCC-cmp',
    templateUrl: 'PCC.component.html',
    providers: [PCCApiService]
})

export class PCCComponent implements OnInit, OnDestroy {
    public dtos: Pcc[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private pccApiService: PCCApiService,
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
                emptyTable: 'Fetching PCC...'
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

        this.getAllPCCs();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllPCCs() {
        this.pccApiService.getAllPCCs().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(PCCDialogComponent, {
            width: '650px',
            data: new Pcc()
        });

        dialogRef.afterClosed().subscribe(pcc => {
            if (pcc) {
                this.pccApiService.addPCC(pcc).subscribe(() => {
                    this.getAllPCCs();
                    this.notificationsService.showNotification('Success', 'Pcc added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(pcc: Pcc) {
        const dialogRef = this.dialog.open(PCCDialogComponent, {
            width: '650px',
            data: pcc
        });

        dialogRef.afterClosed().subscribe(pcc => {
            if (pcc) {
                this.pccApiService.updatePCC(pcc).subscribe(() => {
                    this.getAllPCCs();
                    this.notificationsService.showNotification('Success', 'Pcc updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(pcc: Pcc) {
        const dialogData = new ConfirmDialogModel("Really delete?", pcc.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.pccApiService.deletePCC(pcc.ıd).subscribe(() => {
                    this.getAllPCCs();
                    this.notificationsService.showNotification('Success', 'Pcc deleted successfully', 'success');
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

