import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { GDSApiService } from 'app/core/services/gds.service';
import { MatDialog } from '@angular/material/dialog';
import { Gds } from 'app/shared/models/gds';
import { GDSDialogComponent } from './gds-dialog/gds-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-GDS-cmp',
    templateUrl: 'GDS.component.html',
    providers: [GDSApiService]
})

export class GDSComponent implements OnInit, OnDestroy {
    public dtos: Gds[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private gdsApiService: GDSApiService,
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
                emptyTable: 'Fetching GDS...'
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

        this.getAllGDSs();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllGDSs() {
        this.gdsApiService.getAllGDSs().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(GDSDialogComponent, {
            width: '650px',
            data: new Gds()
        });

        dialogRef.afterClosed().subscribe(gds => {
            if (gds) {
                this.gdsApiService.addGDS(gds).subscribe(() => {
                    this.getAllGDSs();
                    this.notificationsService.showNotification('Success', 'Gds added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(gds: Gds) {
        const dialogRef = this.dialog.open(GDSDialogComponent, {
            width: '650px',
            data: gds
        });

        dialogRef.afterClosed().subscribe(gds => {
            if (gds) {
                this.gdsApiService.updateGDS(gds).subscribe(() => {
                    this.getAllGDSs();
                    this.notificationsService.showNotification('Success', 'Gds updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(gds: Gds) {
        const dialogData = new ConfirmDialogModel("Really delete?", gds.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.gdsApiService.deleteGDS(gds.ıd).subscribe(() => {
                    this.getAllGDSs();
                    this.notificationsService.showNotification('Success', 'Gds deleted successfully', 'success');
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

