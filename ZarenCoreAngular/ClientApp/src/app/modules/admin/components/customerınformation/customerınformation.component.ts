import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { CustomerInformationApiService } from 'app/core/services/customerınformation.service';
import { MatDialog } from '@angular/material/dialog';
import { Customerınformation } from 'app/shared/models/customerınformation';
import { CustomerInformationDialogComponent } from './customerınformation-dialog/customerınformation-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-CustomerInformation-cmp',
    templateUrl: 'CustomerInformation.component.html',
    providers: [CustomerInformationApiService]
})

export class CustomerInformationComponent implements OnInit, OnDestroy {
    public dtos: Customerınformation[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private customerınformationApiService: CustomerInformationApiService,
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
                emptyTable: 'Fetching CustomerInformation...'
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

        this.getAllCustomerInformations();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllCustomerInformations() {
        this.customerınformationApiService.getAllCustomerInformations().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(CustomerInformationDialogComponent, {
            width: '650px',
            data: new Customerınformation()
        });

        dialogRef.afterClosed().subscribe(customerınformation => {
            if (customerınformation) {
                this.customerınformationApiService.addCustomerInformation(customerınformation).subscribe(() => {
                    this.getAllCustomerInformations();
                    this.notificationsService.showNotification('Success', 'Customerınformation added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(customerınformation: Customerınformation) {
        const dialogRef = this.dialog.open(CustomerInformationDialogComponent, {
            width: '650px',
            data: customerınformation
        });

        dialogRef.afterClosed().subscribe(customerınformation => {
            if (customerınformation) {
                this.customerınformationApiService.updateCustomerInformation(customerınformation).subscribe(() => {
                    this.getAllCustomerInformations();
                    this.notificationsService.showNotification('Success', 'Customerınformation updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(customerınformation: Customerınformation) {
        const dialogData = new ConfirmDialogModel("Really delete?", customerınformation.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.customerınformationApiService.deleteCustomerInformation(customerınformation.ıd).subscribe(() => {
                    this.getAllCustomerInformations();
                    this.notificationsService.showNotification('Success', 'Customerınformation deleted successfully', 'success');
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

