import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { AccommodationExtrasApiService } from 'app/core/services/accommodationextras.service';
import { MatDialog } from '@angular/material/dialog';
import { Accommodationextras } from 'app/shared/models/accommodationextras';
import { AccommodationExtrasDialogComponent } from './accommodationextras-dialog/accommodationextras-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-AccommodationExtras-cmp',
    templateUrl: 'AccommodationExtras.component.html',
    providers: [AccommodationExtrasApiService]
})

export class AccommodationExtrasComponent implements OnInit, OnDestroy {
    public dtos: Accommodationextras[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private accommodationextrasApiService: AccommodationExtrasApiService,
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
                emptyTable: 'Fetching AccommodationExtras...'
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

        this.getAllAccommodationExtrass();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllAccommodationExtrass() {
        this.accommodationextrasApiService.getAllAccommodationExtrass().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(AccommodationExtrasDialogComponent, {
            width: '650px',
            data: new Accommodationextras()
        });

        dialogRef.afterClosed().subscribe(accommodationextras => {
            if (accommodationextras) {
                this.accommodationextrasApiService.addAccommodationExtras(accommodationextras).subscribe(() => {
                    this.getAllAccommodationExtrass();
                    this.notificationsService.showNotification('Success', 'Accommodationextras added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(accommodationextras: Accommodationextras) {
        const dialogRef = this.dialog.open(AccommodationExtrasDialogComponent, {
            width: '650px',
            data: accommodationextras
        });

        dialogRef.afterClosed().subscribe(accommodationextras => {
            if (accommodationextras) {
                this.accommodationextrasApiService.updateAccommodationExtras(accommodationextras).subscribe(() => {
                    this.getAllAccommodationExtrass();
                    this.notificationsService.showNotification('Success', 'Accommodationextras updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(accommodationextras: Accommodationextras) {
        const dialogData = new ConfirmDialogModel("Really delete?", accommodationextras.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.accommodationextrasApiService.deleteAccommodationExtras(accommodationextras.ıd).subscribe(() => {
                    this.getAllAccommodationExtrass();
                    this.notificationsService.showNotification('Success', 'Accommodationextras deleted successfully', 'success');
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

