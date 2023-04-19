import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { BrokerApiService } from 'app/core/services/broker.service';
import { MatDialog } from '@angular/material/dialog';
import { Broker } from 'app/shared/models/broker';
import { BrokerDialogComponent } from './broker-dialog/broker-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-Broker-cmp',
    templateUrl: 'Broker.component.html',
    providers: [BrokerApiService]
})

export class BrokerComponent implements OnInit, OnDestroy {
    public dtos: Broker[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private brokerApiService: BrokerApiService,
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
                emptyTable: 'Fetching Broker...'
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

        this.getAllBrokers();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllBrokers() {
        this.brokerApiService.getAllBrokers().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(BrokerDialogComponent, {
            width: '650px',
            data: new Broker()
        });

        dialogRef.afterClosed().subscribe(broker => {
            if (broker) {
                this.brokerApiService.addBroker(broker).subscribe(() => {
                    this.getAllBrokers();
                    this.notificationsService.showNotification('Success', 'Broker added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(broker: Broker) {
        const dialogRef = this.dialog.open(BrokerDialogComponent, {
            width: '650px',
            data: broker
        });

        dialogRef.afterClosed().subscribe(broker => {
            if (broker) {
                this.brokerApiService.updateBroker(broker).subscribe(() => {
                    this.getAllBrokers();
                    this.notificationsService.showNotification('Success', 'Broker updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(broker: Broker) {
        const dialogData = new ConfirmDialogModel("Really delete?", broker.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.brokerApiService.deleteBroker(broker.ıd).subscribe(() => {
                    this.getAllBrokers();
                    this.notificationsService.showNotification('Success', 'Broker deleted successfully', 'success');
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

