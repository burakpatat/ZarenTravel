import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { carrentApiService } from 'app/core/services/carrent.service';
import { MatDialog } from '@angular/material/dialog';
import { Carrent } from 'app/shared/models/carrent';
import { carrentDialogComponent } from './carrent-dialog/carrent-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-carrent-cmp',
    templateUrl: 'carrent.component.html',
    providers: [carrentApiService]
})

export class carrentComponent implements OnInit, OnDestroy {
    public dtos: Carrent[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private carrentApiService: carrentApiService,
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
                emptyTable: 'Fetching carrent...'
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

        this.getAllcarrents();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllcarrents() {
        this.carrentApiService.getAllcarrents().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(carrentDialogComponent, {
            width: '650px',
            data: new Carrent()
        });

        dialogRef.afterClosed().subscribe(carrent => {
            if (carrent) {
                this.carrentApiService.addcarrent(carrent).subscribe(() => {
                    this.getAllcarrents();
                    this.notificationsService.showNotification('Success', 'Carrent added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(carrent: Carrent) {
        const dialogRef = this.dialog.open(carrentDialogComponent, {
            width: '650px',
            data: carrent
        });

        dialogRef.afterClosed().subscribe(carrent => {
            if (carrent) {
                this.carrentApiService.updatecarrent(carrent).subscribe(() => {
                    this.getAllcarrents();
                    this.notificationsService.showNotification('Success', 'Carrent updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(carrent: Carrent) {
        const dialogData = new ConfirmDialogModel("Really delete?", carrent.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.carrentApiService.deletecarrent(carrent.ıd).subscribe(() => {
                    this.getAllcarrents();
                    this.notificationsService.showNotification('Success', 'Carrent deleted successfully', 'success');
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

