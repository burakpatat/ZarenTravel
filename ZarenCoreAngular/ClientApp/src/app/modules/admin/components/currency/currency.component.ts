import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { CurrencyApiService } from 'app/core/services/currency.service';
import { MatDialog } from '@angular/material/dialog';
import { Currency } from 'app/shared/models/currency';
import { CurrencyDialogComponent } from './currency-dialog/currency-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-Currency-cmp',
    templateUrl: 'Currency.component.html',
    providers: [CurrencyApiService]
})

export class CurrencyComponent implements OnInit, OnDestroy {
    public dtos: Currency[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private currencyApiService: CurrencyApiService,
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
                emptyTable: 'Fetching Currency...'
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

        this.getAllCurrencys();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllCurrencys() {
        this.currencyApiService.getAllCurrencys().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(CurrencyDialogComponent, {
            width: '650px',
            data: new Currency()
        });

        dialogRef.afterClosed().subscribe(currency => {
            if (currency) {
                this.currencyApiService.addCurrency(currency).subscribe(() => {
                    this.getAllCurrencys();
                    this.notificationsService.showNotification('Success', 'Currency added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(currency: Currency) {
        const dialogRef = this.dialog.open(CurrencyDialogComponent, {
            width: '650px',
            data: currency
        });

        dialogRef.afterClosed().subscribe(currency => {
            if (currency) {
                this.currencyApiService.updateCurrency(currency).subscribe(() => {
                    this.getAllCurrencys();
                    this.notificationsService.showNotification('Success', 'Currency updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(currency: Currency) {
        const dialogData = new ConfirmDialogModel("Really delete?", currency.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.currencyApiService.deleteCurrency(currency.ıd).subscribe(() => {
                    this.getAllCurrencys();
                    this.notificationsService.showNotification('Success', 'Currency deleted successfully', 'success');
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

