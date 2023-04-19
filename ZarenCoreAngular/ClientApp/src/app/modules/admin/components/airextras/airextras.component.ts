import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { AirExtrasApiService } from 'app/core/services/airextras.service';
import { MatDialog } from '@angular/material/dialog';
import { Airextras } from 'app/shared/models/airextras';
import { AirExtrasDialogComponent } from './airextras-dialog/airextras-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-AirExtras-cmp',
    templateUrl: 'AirExtras.component.html',
    providers: [AirExtrasApiService]
})

export class AirExtrasComponent implements OnInit, OnDestroy {
    public dtos: Airextras[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private airextrasApiService: AirExtrasApiService,
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
                emptyTable: 'Fetching AirExtras...'
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

        this.getAllAirExtrass();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllAirExtrass() {
        this.airextrasApiService.getAllAirExtrass().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(AirExtrasDialogComponent, {
            width: '650px',
            data: new Airextras()
        });

        dialogRef.afterClosed().subscribe(airextras => {
            if (airextras) {
                this.airextrasApiService.addAirExtras(airextras).subscribe(() => {
                    this.getAllAirExtrass();
                    this.notificationsService.showNotification('Success', 'Airextras added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(airextras: Airextras) {
        const dialogRef = this.dialog.open(AirExtrasDialogComponent, {
            width: '650px',
            data: airextras
        });

        dialogRef.afterClosed().subscribe(airextras => {
            if (airextras) {
                this.airextrasApiService.updateAirExtras(airextras).subscribe(() => {
                    this.getAllAirExtrass();
                    this.notificationsService.showNotification('Success', 'Airextras updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(airextras: Airextras) {
        const dialogData = new ConfirmDialogModel("Really delete?", airextras.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.airextrasApiService.deleteAirExtras(airextras.ıd).subscribe(() => {
                    this.getAllAirExtrass();
                    this.notificationsService.showNotification('Success', 'Airextras deleted successfully', 'success');
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

