import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { ReservationInformationApiService } from 'app/core/services/reservationınformation.service';
import { MatDialog } from '@angular/material/dialog';
import { Reservationınformation } from 'app/shared/models/reservationınformation';
import { ReservationInformationDialogComponent } from './reservationınformation-dialog/reservationınformation-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-ReservationInformation-cmp',
    templateUrl: 'ReservationInformation.component.html',
    providers: [ReservationInformationApiService]
})

export class ReservationInformationComponent implements OnInit, OnDestroy {
    public dtos: Reservationınformation[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private reservationınformationApiService: ReservationInformationApiService,
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
                emptyTable: 'Fetching ReservationInformation...'
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

        this.getAllReservationInformations();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllReservationInformations() {
        this.reservationınformationApiService.getAllReservationInformations().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(ReservationInformationDialogComponent, {
            width: '650px',
            data: new Reservationınformation()
        });

        dialogRef.afterClosed().subscribe(reservationınformation => {
            if (reservationınformation) {
                this.reservationınformationApiService.addReservationInformation(reservationınformation).subscribe(() => {
                    this.getAllReservationInformations();
                    this.notificationsService.showNotification('Success', 'Reservationınformation added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(reservationınformation: Reservationınformation) {
        const dialogRef = this.dialog.open(ReservationInformationDialogComponent, {
            width: '650px',
            data: reservationınformation
        });

        dialogRef.afterClosed().subscribe(reservationınformation => {
            if (reservationınformation) {
                this.reservationınformationApiService.updateReservationInformation(reservationınformation).subscribe(() => {
                    this.getAllReservationInformations();
                    this.notificationsService.showNotification('Success', 'Reservationınformation updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(reservationınformation: Reservationınformation) {
        const dialogData = new ConfirmDialogModel("Really delete?", reservationınformation.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.reservationınformationApiService.deleteReservationInformation(reservationınformation.ıd).subscribe(() => {
                    this.getAllReservationInformations();
                    this.notificationsService.showNotification('Success', 'Reservationınformation deleted successfully', 'success');
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

