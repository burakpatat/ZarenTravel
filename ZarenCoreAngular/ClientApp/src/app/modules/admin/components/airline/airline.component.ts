import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { AirlineApiService } from 'app/core/services/airline.service';
import { MatDialog } from '@angular/material/dialog';
import { Airline } from 'app/shared/models/airline';
import { AirlineDialogComponent } from './airline-dialog/airline-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-Airline-cmp',
    templateUrl: 'Airline.component.html',
    providers: [AirlineApiService]
})

export class AirlineComponent implements OnInit, OnDestroy {
    public dtos: Airline[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private airlineApiService: AirlineApiService,
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
                emptyTable: 'Fetching Airline...'
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

        this.getAllAirlines();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllAirlines() {
        this.airlineApiService.getAllAirlines().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(AirlineDialogComponent, {
            width: '650px',
            data: new Airline()
        });

        dialogRef.afterClosed().subscribe(airline => {
            if (airline) {
                this.airlineApiService.addAirline(airline).subscribe(() => {
                    this.getAllAirlines();
                    this.notificationsService.showNotification('Success', 'Airline added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(airline: Airline) {
        const dialogRef = this.dialog.open(AirlineDialogComponent, {
            width: '650px',
            data: airline
        });

        dialogRef.afterClosed().subscribe(airline => {
            if (airline) {
                this.airlineApiService.updateAirline(airline).subscribe(() => {
                    this.getAllAirlines();
                    this.notificationsService.showNotification('Success', 'Airline updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(airline: Airline) {
        const dialogData = new ConfirmDialogModel("Really delete?", airline.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.airlineApiService.deleteAirline(airline.ıd).subscribe(() => {
                    this.getAllAirlines();
                    this.notificationsService.showNotification('Success', 'Airline deleted successfully', 'success');
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

