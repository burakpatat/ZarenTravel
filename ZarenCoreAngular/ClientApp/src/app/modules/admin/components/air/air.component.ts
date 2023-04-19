import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { AirApiService } from 'app/core/services/air.service';
import { MatDialog } from '@angular/material/dialog';
import { Air } from 'app/shared/models/air';
import { AirDialogComponent } from './air-dialog/air-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-Air-cmp',
    templateUrl: 'Air.component.html',
    providers: [AirApiService]
})

export class AirComponent implements OnInit, OnDestroy {
    public dtos: Air[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private airApiService: AirApiService,
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
                emptyTable: 'Fetching Air...'
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

        this.getAllAirs();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllAirs() {
        this.airApiService.getAllAirs().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(AirDialogComponent, {
            width: '650px',
            data: new Air()
        });

        dialogRef.afterClosed().subscribe(air => {
            if (air) {
                this.airApiService.addAir(air).subscribe(() => {
                    this.getAllAirs();
                    this.notificationsService.showNotification('Success', 'Air added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(air: Air) {
        const dialogRef = this.dialog.open(AirDialogComponent, {
            width: '650px',
            data: air
        });

        dialogRef.afterClosed().subscribe(air => {
            if (air) {
                this.airApiService.updateAir(air).subscribe(() => {
                    this.getAllAirs();
                    this.notificationsService.showNotification('Success', 'Air updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(air: Air) {
        const dialogData = new ConfirmDialogModel("Really delete?", air.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.airApiService.deleteAir(air.ıd).subscribe(() => {
                    this.getAllAirs();
                    this.notificationsService.showNotification('Success', 'Air deleted successfully', 'success');
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

