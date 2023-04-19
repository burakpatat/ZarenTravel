import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { HotelApiService } from 'src/app/core/services/hotel.service';
import { MatDialog } from '@angular/material/dialog';
import { Hotel } from 'src/app/shared/models/hotel';
import { HotelDialogComponent } from './hotel-dialog/hotel-dialog.component';
import { ConfirmDialogModel } from 'src/app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'src/app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-Hotel-cmp',
    templateUrl: 'hotel.component.html',
    providers: [HotelApiService]
})

export class HotelComponent implements OnInit, OnDestroy {
    public dtos!: Hotel[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement!: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private hotelApiService: HotelApiService,
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
                emptyTable: 'Fetching Hotel...'
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

        this.getAllHotels();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllHotels() {
        this.hotelApiService.getAllHotels().subscribe((dtos: Hotel[]) => {
            this.dtos = dtos;
            if (this.dtos.length == 0) {
                this.dtOptions.language.emptyTable = 'No dtos available yet.';
            }

            this.renderDataTable();
        }, (err: { message: string; }) => {
            this.renderDataTable();
            this.dtOptions.language.emptyTable = 'Error while fetching dtos, pls try refreshing the page or contact admin.';
            this.notificationsService.showNotification('Error', err.message, 'warning');
        });
    }

    addDialog() {
        const dialogRef = this.dialog.open(HotelDialogComponent, {
            width: '650px',
            data: new Hotel()
        });

        dialogRef.afterClosed().subscribe(hotel => {
            if (hotel) {
                this.hotelApiService.addHotel(hotel).subscribe(() => {
                    this.getAllHotels();
                    this.notificationsService.showNotification('Success', 'Hotel added successfully', 'success');
                }, (err: { message: string; }) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(hotel: Hotel) {
        const dialogRef = this.dialog.open(HotelDialogComponent, {
            width: '650px',
            data: hotel
        });

        dialogRef.afterClosed().subscribe(hotel => {
            if (hotel) {
                this.hotelApiService.updateHotel(hotel).subscribe(() => {
                    this.getAllHotels();
                    this.notificationsService.showNotification('Success', 'Hotel updated successfully', 'success');
                }, (err: { message: string; }) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(hotel: Hotel) {
        const dialogData = new ConfirmDialogModel("Really delete?", hotel.id.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.hotelApiService.deleteHotel(hotel.id).subscribe(() => {
                    this.getAllHotels();
                    this.notificationsService.showNotification('Success', 'Hotel deleted successfully', 'success');
                }, (err: { message: string; }) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    renderDataTable(): void {
        //if (this.dtElement && this.dtElement.dtInstance) {
        //    this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
        //        dtInstance.destroy();
        //    });
        //}

        //this.dtTrigger.next();
    }

    ngOnDestroy(): void {
        this.dtTrigger.unsubscribe();
    }
}

