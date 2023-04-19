import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { CarRentalApiService } from 'app/core/services/carrental.service';
import { MatDialog } from '@angular/material/dialog';
import { Carrental } from 'app/shared/models/carrental';
import { CarRentalDialogComponent } from './carrental-dialog/carrental-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-CarRental-cmp',
    templateUrl: 'CarRental.component.html',
    providers: [CarRentalApiService]
})

export class CarRentalComponent implements OnInit, OnDestroy {
    public dtos: Carrental[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private carrentalApiService: CarRentalApiService,
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
                emptyTable: 'Fetching CarRental...'
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

        this.getAllCarRentals();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllCarRentals() {
        this.carrentalApiService.getAllCarRentals().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(CarRentalDialogComponent, {
            width: '650px',
            data: new Carrental()
        });

        dialogRef.afterClosed().subscribe(carrental => {
            if (carrental) {
                this.carrentalApiService.addCarRental(carrental).subscribe(() => {
                    this.getAllCarRentals();
                    this.notificationsService.showNotification('Success', 'Carrental added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(carrental: Carrental) {
        const dialogRef = this.dialog.open(CarRentalDialogComponent, {
            width: '650px',
            data: carrental
        });

        dialogRef.afterClosed().subscribe(carrental => {
            if (carrental) {
                this.carrentalApiService.updateCarRental(carrental).subscribe(() => {
                    this.getAllCarRentals();
                    this.notificationsService.showNotification('Success', 'Carrental updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(carrental: Carrental) {
        const dialogData = new ConfirmDialogModel("Really delete?", carrental.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.carrentalApiService.deleteCarRental(carrental.ıd).subscribe(() => {
                    this.getAllCarRentals();
                    this.notificationsService.showNotification('Success', 'Carrental deleted successfully', 'success');
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

