import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { AirportApiService } from 'app/core/services/airport.service';
import { MatDialog } from '@angular/material/dialog';
import { Airport } from 'app/shared/models/airport';
import { AirportDialogComponent } from './airport-dialog/airport-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-Airport-cmp',
    templateUrl: 'Airport.component.html',
    providers: [AirportApiService]
})

export class AirportComponent implements OnInit, OnDestroy {
    public dtos: Airport[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private airportApiService: AirportApiService,
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
                emptyTable: 'Fetching Airport...'
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

        this.getAllAirports();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllAirports() {
        this.airportApiService.getAllAirports().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(AirportDialogComponent, {
            width: '650px',
            data: new Airport()
        });

        dialogRef.afterClosed().subscribe(airport => {
            if (airport) {
                this.airportApiService.addAirport(airport).subscribe(() => {
                    this.getAllAirports();
                    this.notificationsService.showNotification('Success', 'Airport added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(airport: Airport) {
        const dialogRef = this.dialog.open(AirportDialogComponent, {
            width: '650px',
            data: airport
        });

        dialogRef.afterClosed().subscribe(airport => {
            if (airport) {
                this.airportApiService.updateAirport(airport).subscribe(() => {
                    this.getAllAirports();
                    this.notificationsService.showNotification('Success', 'Airport updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(airport: Airport) {
        const dialogData = new ConfirmDialogModel("Really delete?", airport.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.airportApiService.deleteAirport(airport.ıd).subscribe(() => {
                    this.getAllAirports();
                    this.notificationsService.showNotification('Success', 'Airport deleted successfully', 'success');
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

