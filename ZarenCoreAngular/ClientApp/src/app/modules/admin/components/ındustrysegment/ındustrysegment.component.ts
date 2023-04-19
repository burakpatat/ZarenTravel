import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { IndustrySegmentApiService } from 'app/core/services/ındustrysegment.service';
import { MatDialog } from '@angular/material/dialog';
import { Industrysegment } from 'app/shared/models/ındustrysegment';
import { IndustrySegmentDialogComponent } from './ındustrysegment-dialog/ındustrysegment-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-IndustrySegment-cmp',
    templateUrl: 'IndustrySegment.component.html',
    providers: [IndustrySegmentApiService]
})

export class IndustrySegmentComponent implements OnInit, OnDestroy {
    public dtos: Industrysegment[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private ındustrysegmentApiService: IndustrySegmentApiService,
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
                emptyTable: 'Fetching IndustrySegment...'
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

        this.getAllIndustrySegments();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllIndustrySegments() {
        this.ındustrysegmentApiService.getAllIndustrySegments().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(IndustrySegmentDialogComponent, {
            width: '650px',
            data: new Industrysegment()
        });

        dialogRef.afterClosed().subscribe(ındustrysegment => {
            if (ındustrysegment) {
                this.ındustrysegmentApiService.addIndustrySegment(ındustrysegment).subscribe(() => {
                    this.getAllIndustrySegments();
                    this.notificationsService.showNotification('Success', 'Industrysegment added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(ındustrysegment: Industrysegment) {
        const dialogRef = this.dialog.open(IndustrySegmentDialogComponent, {
            width: '650px',
            data: ındustrysegment
        });

        dialogRef.afterClosed().subscribe(ındustrysegment => {
            if (ındustrysegment) {
                this.ındustrysegmentApiService.updateIndustrySegment(ındustrysegment).subscribe(() => {
                    this.getAllIndustrySegments();
                    this.notificationsService.showNotification('Success', 'Industrysegment updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(ındustrysegment: Industrysegment) {
        const dialogData = new ConfirmDialogModel("Really delete?", ındustrysegment.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.ındustrysegmentApiService.deleteIndustrySegment(ındustrysegment.ıd).subscribe(() => {
                    this.getAllIndustrySegments();
                    this.notificationsService.showNotification('Success', 'Industrysegment deleted successfully', 'success');
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

