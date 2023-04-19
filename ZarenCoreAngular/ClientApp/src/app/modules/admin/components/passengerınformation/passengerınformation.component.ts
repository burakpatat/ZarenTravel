import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { PassengerInformationApiService } from 'app/core/services/passengerınformation.service';
import { MatDialog } from '@angular/material/dialog';
import { Passengerınformation } from 'app/shared/models/passengerınformation';
import { PassengerInformationDialogComponent } from './passengerınformation-dialog/passengerınformation-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-PassengerInformation-cmp',
    templateUrl: 'PassengerInformation.component.html',
    providers: [PassengerInformationApiService]
})

export class PassengerInformationComponent implements OnInit, OnDestroy {
    public dtos: Passengerınformation[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private passengerınformationApiService: PassengerInformationApiService,
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
                emptyTable: 'Fetching PassengerInformation...'
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

        this.getAllPassengerInformations();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllPassengerInformations() {
        this.passengerınformationApiService.getAllPassengerInformations().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(PassengerInformationDialogComponent, {
            width: '650px',
            data: new Passengerınformation()
        });

        dialogRef.afterClosed().subscribe(passengerınformation => {
            if (passengerınformation) {
                this.passengerınformationApiService.addPassengerInformation(passengerınformation).subscribe(() => {
                    this.getAllPassengerInformations();
                    this.notificationsService.showNotification('Success', 'Passengerınformation added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(passengerınformation: Passengerınformation) {
        const dialogRef = this.dialog.open(PassengerInformationDialogComponent, {
            width: '650px',
            data: passengerınformation
        });

        dialogRef.afterClosed().subscribe(passengerınformation => {
            if (passengerınformation) {
                this.passengerınformationApiService.updatePassengerInformation(passengerınformation).subscribe(() => {
                    this.getAllPassengerInformations();
                    this.notificationsService.showNotification('Success', 'Passengerınformation updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(passengerınformation: Passengerınformation) {
        const dialogData = new ConfirmDialogModel("Really delete?", passengerınformation.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.passengerınformationApiService.deletePassengerInformation(passengerınformation.ıd).subscribe(() => {
                    this.getAllPassengerInformations();
                    this.notificationsService.showNotification('Success', 'Passengerınformation deleted successfully', 'success');
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

