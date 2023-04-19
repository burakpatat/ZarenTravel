import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { ExchangeRatesApiService } from 'app/core/services/exchangerates.service';
import { MatDialog } from '@angular/material/dialog';
import { Exchangerates } from 'app/shared/models/exchangerates';
import { ExchangeRatesDialogComponent } from './exchangerates-dialog/exchangerates-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-ExchangeRates-cmp',
    templateUrl: 'ExchangeRates.component.html',
    providers: [ExchangeRatesApiService]
})

export class ExchangeRatesComponent implements OnInit, OnDestroy {
    public dtos: Exchangerates[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private exchangeratesApiService: ExchangeRatesApiService,
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
                emptyTable: 'Fetching ExchangeRates...'
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

        this.getAllExchangeRatess();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllExchangeRatess() {
        this.exchangeratesApiService.getAllExchangeRatess().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(ExchangeRatesDialogComponent, {
            width: '650px',
            data: new Exchangerates()
        });

        dialogRef.afterClosed().subscribe(exchangerates => {
            if (exchangerates) {
                this.exchangeratesApiService.addExchangeRates(exchangerates).subscribe(() => {
                    this.getAllExchangeRatess();
                    this.notificationsService.showNotification('Success', 'Exchangerates added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(exchangerates: Exchangerates) {
        const dialogRef = this.dialog.open(ExchangeRatesDialogComponent, {
            width: '650px',
            data: exchangerates
        });

        dialogRef.afterClosed().subscribe(exchangerates => {
            if (exchangerates) {
                this.exchangeratesApiService.updateExchangeRates(exchangerates).subscribe(() => {
                    this.getAllExchangeRatess();
                    this.notificationsService.showNotification('Success', 'Exchangerates updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(exchangerates: Exchangerates) {
        const dialogData = new ConfirmDialogModel("Really delete?", exchangerates.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.exchangeratesApiService.deleteExchangeRates(exchangerates.ıd).subscribe(() => {
                    this.getAllExchangeRatess();
                    this.notificationsService.showNotification('Success', 'Exchangerates deleted successfully', 'success');
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

