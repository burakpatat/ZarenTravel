import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { AccommodationApiService } from 'app/core/services/accommodation.service';
import { MatDialog } from '@angular/material/dialog';
import { Accommodation } from 'app/shared/models/accommodation';
import { AccommodationDialogComponent } from './accommodation-dialog/accommodation-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-Accommodation-cmp',
    templateUrl: 'Accommodation.component.html',
    providers: [AccommodationApiService]
})

export class AccommodationComponent implements OnInit, OnDestroy {
    public dtos: Accommodation[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private accommodationApiService: AccommodationApiService,
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
                emptyTable: 'Fetching Accommodation...'
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

        this.getAllAccommodations();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllAccommodations() {
        this.accommodationApiService.getAllAccommodations().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(AccommodationDialogComponent, {
            width: '650px',
            data: new Accommodation()
        });

        dialogRef.afterClosed().subscribe(accommodation => {
            if (accommodation) {
                this.accommodationApiService.addAccommodation(accommodation).subscribe(() => {
                    this.getAllAccommodations();
                    this.notificationsService.showNotification('Success', 'Accommodation added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(accommodation: Accommodation) {
        const dialogRef = this.dialog.open(AccommodationDialogComponent, {
            width: '650px',
            data: accommodation
        });

        dialogRef.afterClosed().subscribe(accommodation => {
            if (accommodation) {
                this.accommodationApiService.updateAccommodation(accommodation).subscribe(() => {
                    this.getAllAccommodations();
                    this.notificationsService.showNotification('Success', 'Accommodation updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(accommodation: Accommodation) {
        const dialogData = new ConfirmDialogModel("Really delete?", accommodation.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.accommodationApiService.deleteAccommodation(accommodation.ıd).subscribe(() => {
                    this.getAllAccommodations();
                    this.notificationsService.showNotification('Success', 'Accommodation deleted successfully', 'success');
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

