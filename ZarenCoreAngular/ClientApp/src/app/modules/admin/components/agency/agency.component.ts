import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { AgencyApiService } from 'app/core/services/agency.service';
import { MatDialog } from '@angular/material/dialog';
import { Agency } from 'app/shared/models/agency';
import { AgencyDialogComponent } from './agency-dialog/agency-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-Agency-cmp',
    templateUrl: 'Agency.component.html',
    providers: [AgencyApiService]
})

export class AgencyComponent implements OnInit, OnDestroy {
    public dtos: Agency[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private agencyApiService: AgencyApiService,
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
                emptyTable: 'Fetching Agency...'
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

        this.getAllAgencys();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllAgencys() {
        this.agencyApiService.getAllAgencys().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(AgencyDialogComponent, {
            width: '650px',
            data: new Agency()
        });

        dialogRef.afterClosed().subscribe(agency => {
            if (agency) {
                this.agencyApiService.addAgency(agency).subscribe(() => {
                    this.getAllAgencys();
                    this.notificationsService.showNotification('Success', 'Agency added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(agency: Agency) {
        const dialogRef = this.dialog.open(AgencyDialogComponent, {
            width: '650px',
            data: agency
        });

        dialogRef.afterClosed().subscribe(agency => {
            if (agency) {
                this.agencyApiService.updateAgency(agency).subscribe(() => {
                    this.getAllAgencys();
                    this.notificationsService.showNotification('Success', 'Agency updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(agency: Agency) {
        const dialogData = new ConfirmDialogModel("Really delete?", agency.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.agencyApiService.deleteAgency(agency.ıd).subscribe(() => {
                    this.getAllAgencys();
                    this.notificationsService.showNotification('Success', 'Agency deleted successfully', 'success');
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

