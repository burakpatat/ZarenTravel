import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { HotelCodesApiService } from 'app/core/services/hotelcodes.service';
import { MatDialog } from '@angular/material/dialog';
import { Hotelcodes } from 'app/shared/models/hotelcodes';
import { HotelCodesDialogComponent } from './hotelcodes-dialog/hotelcodes-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-HotelCodes-cmp',
    templateUrl: 'HotelCodes.component.html',
    providers: [HotelCodesApiService]
})

export class HotelCodesComponent implements OnInit, OnDestroy {
    public dtos: Hotelcodes[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private hotelcodesApiService: HotelCodesApiService,
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
                emptyTable: 'Fetching HotelCodes...'
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

        this.getAllHotelCodess();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllHotelCodess() {
        this.hotelcodesApiService.getAllHotelCodess().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(HotelCodesDialogComponent, {
            width: '650px',
            data: new Hotelcodes()
        });

        dialogRef.afterClosed().subscribe(hotelcodes => {
            if (hotelcodes) {
                this.hotelcodesApiService.addHotelCodes(hotelcodes).subscribe(() => {
                    this.getAllHotelCodess();
                    this.notificationsService.showNotification('Success', 'Hotelcodes added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(hotelcodes: Hotelcodes) {
        const dialogRef = this.dialog.open(HotelCodesDialogComponent, {
            width: '650px',
            data: hotelcodes
        });

        dialogRef.afterClosed().subscribe(hotelcodes => {
            if (hotelcodes) {
                this.hotelcodesApiService.updateHotelCodes(hotelcodes).subscribe(() => {
                    this.getAllHotelCodess();
                    this.notificationsService.showNotification('Success', 'Hotelcodes updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(hotelcodes: Hotelcodes) {
        const dialogData = new ConfirmDialogModel("Really delete?", hotelcodes.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.hotelcodesApiService.deleteHotelCodes(hotelcodes.ıd).subscribe(() => {
                    this.getAllHotelCodess();
                    this.notificationsService.showNotification('Success', 'Hotelcodes deleted successfully', 'success');
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

