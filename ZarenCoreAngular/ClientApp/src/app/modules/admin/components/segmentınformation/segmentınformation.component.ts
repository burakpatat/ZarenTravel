import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { SegmentInformationApiService } from 'app/core/services/segmentınformation.service';
import { MatDialog } from '@angular/material/dialog';
import { Segmentınformation } from 'app/shared/models/segmentınformation';
import { SegmentInformationDialogComponent } from './segmentınformation-dialog/segmentınformation-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-SegmentInformation-cmp',
    templateUrl: 'SegmentInformation.component.html',
    providers: [SegmentInformationApiService]
})

export class SegmentInformationComponent implements OnInit, OnDestroy {
    public dtos: Segmentınformation[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private segmentınformationApiService: SegmentInformationApiService,
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
                emptyTable: 'Fetching SegmentInformation...'
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

        this.getAllSegmentInformations();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllSegmentInformations() {
        this.segmentınformationApiService.getAllSegmentInformations().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(SegmentInformationDialogComponent, {
            width: '650px',
            data: new Segmentınformation()
        });

        dialogRef.afterClosed().subscribe(segmentınformation => {
            if (segmentınformation) {
                this.segmentınformationApiService.addSegmentInformation(segmentınformation).subscribe(() => {
                    this.getAllSegmentInformations();
                    this.notificationsService.showNotification('Success', 'Segmentınformation added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(segmentınformation: Segmentınformation) {
        const dialogRef = this.dialog.open(SegmentInformationDialogComponent, {
            width: '650px',
            data: segmentınformation
        });

        dialogRef.afterClosed().subscribe(segmentınformation => {
            if (segmentınformation) {
                this.segmentınformationApiService.updateSegmentInformation(segmentınformation).subscribe(() => {
                    this.getAllSegmentInformations();
                    this.notificationsService.showNotification('Success', 'Segmentınformation updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(segmentınformation: Segmentınformation) {
        const dialogData = new ConfirmDialogModel("Really delete?", segmentınformation.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.segmentınformationApiService.deleteSegmentInformation(segmentınformation.ıd).subscribe(() => {
                    this.getAllSegmentInformations();
                    this.notificationsService.showNotification('Success', 'Segmentınformation deleted successfully', 'success');
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

