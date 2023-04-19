import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { AirSegmentsApiService } from 'app/core/services/airsegments.service';
import { MatDialog } from '@angular/material/dialog';
import { Airsegments } from 'app/shared/models/airsegments';
import { AirSegmentsDialogComponent } from './airsegments-dialog/airsegments-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-AirSegments-cmp',
    templateUrl: 'AirSegments.component.html',
    providers: [AirSegmentsApiService]
})

export class AirSegmentsComponent implements OnInit, OnDestroy {
    public dtos: Airsegments[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private airsegmentsApiService: AirSegmentsApiService,
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
                emptyTable: 'Fetching AirSegments...'
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

        this.getAllAirSegmentss();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllAirSegmentss() {
        this.airsegmentsApiService.getAllAirSegmentss().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(AirSegmentsDialogComponent, {
            width: '650px',
            data: new Airsegments()
        });

        dialogRef.afterClosed().subscribe(airsegments => {
            if (airsegments) {
                this.airsegmentsApiService.addAirSegments(airsegments).subscribe(() => {
                    this.getAllAirSegmentss();
                    this.notificationsService.showNotification('Success', 'Airsegments added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(airsegments: Airsegments) {
        const dialogRef = this.dialog.open(AirSegmentsDialogComponent, {
            width: '650px',
            data: airsegments
        });

        dialogRef.afterClosed().subscribe(airsegments => {
            if (airsegments) {
                this.airsegmentsApiService.updateAirSegments(airsegments).subscribe(() => {
                    this.getAllAirSegmentss();
                    this.notificationsService.showNotification('Success', 'Airsegments updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(airsegments: Airsegments) {
        const dialogData = new ConfirmDialogModel("Really delete?", airsegments.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.airsegmentsApiService.deleteAirSegments(airsegments.ıd).subscribe(() => {
                    this.getAllAirSegmentss();
                    this.notificationsService.showNotification('Success', 'Airsegments deleted successfully', 'success');
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

