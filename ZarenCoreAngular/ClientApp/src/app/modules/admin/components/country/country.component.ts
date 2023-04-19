import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { CountryApiService } from 'app/core/services/country.service';
import { MatDialog } from '@angular/material/dialog';
import { Country } from 'app/shared/models/country';
import { CountryDialogComponent } from './country-dialog/country-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-Country-cmp',
    templateUrl: 'Country.component.html',
    providers: [CountryApiService]
})

export class CountryComponent implements OnInit, OnDestroy {
    public dtos: Country[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private countryApiService: CountryApiService,
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
                emptyTable: 'Fetching Country...'
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

        this.getAllCountrys();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllCountrys() {
        this.countryApiService.getAllCountrys().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(CountryDialogComponent, {
            width: '650px',
            data: new Country()
        });

        dialogRef.afterClosed().subscribe(country => {
            if (country) {
                this.countryApiService.addCountry(country).subscribe(() => {
                    this.getAllCountrys();
                    this.notificationsService.showNotification('Success', 'Country added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(country: Country) {
        const dialogRef = this.dialog.open(CountryDialogComponent, {
            width: '650px',
            data: country
        });

        dialogRef.afterClosed().subscribe(country => {
            if (country) {
                this.countryApiService.updateCountry(country).subscribe(() => {
                    this.getAllCountrys();
                    this.notificationsService.showNotification('Success', 'Country updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(country: Country) {
        const dialogData = new ConfirmDialogModel("Really delete?", country.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.countryApiService.deleteCountry(country.ıd).subscribe(() => {
                    this.getAllCountrys();
                    this.notificationsService.showNotification('Success', 'Country deleted successfully', 'success');
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

