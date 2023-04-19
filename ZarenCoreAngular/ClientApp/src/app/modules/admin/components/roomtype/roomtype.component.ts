import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { RoomTypeApiService } from 'app/core/services/roomtype.service';
import { MatDialog } from '@angular/material/dialog';
import { Roomtype } from 'app/shared/models/roomtype';
import { RoomTypeDialogComponent } from './roomtype-dialog/roomtype-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-RoomType-cmp',
    templateUrl: 'RoomType.component.html',
    providers: [RoomTypeApiService]
})

export class RoomTypeComponent implements OnInit, OnDestroy {
    public dtos: Roomtype[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private roomtypeApiService: RoomTypeApiService,
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
                emptyTable: 'Fetching RoomType...'
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

        this.getAllRoomTypes();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllRoomTypes() {
        this.roomtypeApiService.getAllRoomTypes().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(RoomTypeDialogComponent, {
            width: '650px',
            data: new Roomtype()
        });

        dialogRef.afterClosed().subscribe(roomtype => {
            if (roomtype) {
                this.roomtypeApiService.addRoomType(roomtype).subscribe(() => {
                    this.getAllRoomTypes();
                    this.notificationsService.showNotification('Success', 'Roomtype added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(roomtype: Roomtype) {
        const dialogRef = this.dialog.open(RoomTypeDialogComponent, {
            width: '650px',
            data: roomtype
        });

        dialogRef.afterClosed().subscribe(roomtype => {
            if (roomtype) {
                this.roomtypeApiService.updateRoomType(roomtype).subscribe(() => {
                    this.getAllRoomTypes();
                    this.notificationsService.showNotification('Success', 'Roomtype updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(roomtype: Roomtype) {
        const dialogData = new ConfirmDialogModel("Really delete?", roomtype.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.roomtypeApiService.deleteRoomType(roomtype.ıd).subscribe(() => {
                    this.getAllRoomTypes();
                    this.notificationsService.showNotification('Success', 'Roomtype deleted successfully', 'success');
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

