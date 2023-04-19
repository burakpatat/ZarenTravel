import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { AgencyGroupApiService } from 'app/core/services/agencygroup.service';
import { MatDialog } from '@angular/material/dialog';
import { Agencygroup } from 'app/shared/models/agencygroup';
import { AgencyGroupDialogComponent } from './agencygroup-dialog/agencygroup-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-AgencyGroup-cmp',
    templateUrl: 'AgencyGroup.component.html',
    providers: [AgencyGroupApiService]
})

export class AgencyGroupComponent implements OnInit, OnDestroy {
    public dtos: Agencygroup[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private agencygroupApiService: AgencyGroupApiService,
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
                emptyTable: 'Fetching AgencyGroup...'
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

        this.getAllAgencyGroups();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllAgencyGroups() {
        this.agencygroupApiService.getAllAgencyGroups().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(AgencyGroupDialogComponent, {
            width: '650px',
            data: new Agencygroup()
        });

        dialogRef.afterClosed().subscribe(agencygroup => {
            if (agencygroup) {
                this.agencygroupApiService.addAgencyGroup(agencygroup).subscribe(() => {
                    this.getAllAgencyGroups();
                    this.notificationsService.showNotification('Success', 'Agencygroup added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(agencygroup: Agencygroup) {
        const dialogRef = this.dialog.open(AgencyGroupDialogComponent, {
            width: '650px',
            data: agencygroup
        });

        dialogRef.afterClosed().subscribe(agencygroup => {
            if (agencygroup) {
                this.agencygroupApiService.updateAgencyGroup(agencygroup).subscribe(() => {
                    this.getAllAgencyGroups();
                    this.notificationsService.showNotification('Success', 'Agencygroup updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(agencygroup: Agencygroup) {
        const dialogData = new ConfirmDialogModel("Really delete?", agencygroup.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.agencygroupApiService.deleteAgencyGroup(agencygroup.ıd).subscribe(() => {
                    this.getAllAgencyGroups();
                    this.notificationsService.showNotification('Success', 'Agencygroup deleted successfully', 'success');
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

