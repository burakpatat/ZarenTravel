import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { CityApiService } from 'app/core/services/city.service';
import { MatDialog } from '@angular/material/dialog';
import { City } from 'app/shared/models/city';
import { CityDialogComponent } from './city-dialog/city-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-City-cmp',
    templateUrl: 'City.component.html',
    providers: [CityApiService]
})

export class CityComponent implements OnInit, OnDestroy {
    public dtos: City[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private cityApiService: CityApiService,
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
                emptyTable: 'Fetching City...'
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

        this.getAllCitys();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllCitys() {
        this.cityApiService.getAllCitys().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(CityDialogComponent, {
            width: '650px',
            data: new City()
        });

        dialogRef.afterClosed().subscribe(city => {
            if (city) {
                this.cityApiService.addCity(city).subscribe(() => {
                    this.getAllCitys();
                    this.notificationsService.showNotification('Success', 'City added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(city: City) {
        const dialogRef = this.dialog.open(CityDialogComponent, {
            width: '650px',
            data: city
        });

        dialogRef.afterClosed().subscribe(city => {
            if (city) {
                this.cityApiService.updateCity(city).subscribe(() => {
                    this.getAllCitys();
                    this.notificationsService.showNotification('Success', 'City updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(city: City) {
        const dialogData = new ConfirmDialogModel("Really delete?", city.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.cityApiService.deleteCity(city.ıd).subscribe(() => {
                    this.getAllCitys();
                    this.notificationsService.showNotification('Success', 'City deleted successfully', 'success');
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

