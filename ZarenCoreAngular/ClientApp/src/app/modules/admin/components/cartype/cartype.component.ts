import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { CarTypeApiService } from 'app/core/services/cartype.service';
import { MatDialog } from '@angular/material/dialog';
import { Cartype } from 'app/shared/models/cartype';
import { CarTypeDialogComponent } from './cartype-dialog/cartype-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-CarType-cmp',
    templateUrl: 'CarType.component.html',
    providers: [CarTypeApiService]
})

export class CarTypeComponent implements OnInit, OnDestroy {
    public dtos: Cartype[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private cartypeApiService: CarTypeApiService,
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
                emptyTable: 'Fetching CarType...'
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

        this.getAllCarTypes();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllCarTypes() {
        this.cartypeApiService.getAllCarTypes().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(CarTypeDialogComponent, {
            width: '650px',
            data: new Cartype()
        });

        dialogRef.afterClosed().subscribe(cartype => {
            if (cartype) {
                this.cartypeApiService.addCarType(cartype).subscribe(() => {
                    this.getAllCarTypes();
                    this.notificationsService.showNotification('Success', 'Cartype added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(cartype: Cartype) {
        const dialogRef = this.dialog.open(CarTypeDialogComponent, {
            width: '650px',
            data: cartype
        });

        dialogRef.afterClosed().subscribe(cartype => {
            if (cartype) {
                this.cartypeApiService.updateCarType(cartype).subscribe(() => {
                    this.getAllCarTypes();
                    this.notificationsService.showNotification('Success', 'Cartype updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(cartype: Cartype) {
        const dialogData = new ConfirmDialogModel("Really delete?", cartype.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.cartypeApiService.deleteCarType(cartype.ıd).subscribe(() => {
                    this.getAllCarTypes();
                    this.notificationsService.showNotification('Success', 'Cartype deleted successfully', 'success');
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

