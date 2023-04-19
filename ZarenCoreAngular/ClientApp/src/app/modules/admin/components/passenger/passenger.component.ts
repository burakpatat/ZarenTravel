import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { PassengerApiService } from 'app/core/services/passenger.service';
import { MatDialog } from '@angular/material/dialog';
import { Passenger } from 'app/shared/models/passenger';
import { PassengerDialogComponent } from './passenger-dialog/passenger-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-Passenger-cmp',
    templateUrl: 'Passenger.component.html',
    providers: [PassengerApiService]
})

export class PassengerComponent implements OnInit, OnDestroy {
    public dtos: Passenger[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private passengerApiService: PassengerApiService,
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
                emptyTable: 'Fetching Passenger...'
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

        this.getAllPassengers();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllPassengers() {
        this.passengerApiService.getAllPassengers().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(PassengerDialogComponent, {
            width: '650px',
            data: new Passenger()
        });

        dialogRef.afterClosed().subscribe(passenger => {
            if (passenger) {
                this.passengerApiService.addPassenger(passenger).subscribe(() => {
                    this.getAllPassengers();
                    this.notificationsService.showNotification('Success', 'Passenger added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(passenger: Passenger) {
        const dialogRef = this.dialog.open(PassengerDialogComponent, {
            width: '650px',
            data: passenger
        });

        dialogRef.afterClosed().subscribe(passenger => {
            if (passenger) {
                this.passengerApiService.updatePassenger(passenger).subscribe(() => {
                    this.getAllPassengers();
                    this.notificationsService.showNotification('Success', 'Passenger updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(passenger: Passenger) {
        const dialogData = new ConfirmDialogModel("Really delete?", passenger.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.passengerApiService.deletePassenger(passenger.ıd).subscribe(() => {
                    this.getAllPassengers();
                    this.notificationsService.showNotification('Success', 'Passenger deleted successfully', 'success');
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

