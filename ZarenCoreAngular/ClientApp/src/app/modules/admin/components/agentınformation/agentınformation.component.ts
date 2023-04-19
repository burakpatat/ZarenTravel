import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { AgentInformationApiService } from 'app/core/services/agentınformation.service';
import { MatDialog } from '@angular/material/dialog';
import { Agentınformation } from 'app/shared/models/agentınformation';
import { AgentInformationDialogComponent } from './agentınformation-dialog/agentınformation-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-AgentInformation-cmp',
    templateUrl: 'AgentInformation.component.html',
    providers: [AgentInformationApiService]
})

export class AgentInformationComponent implements OnInit, OnDestroy {
    public dtos: Agentınformation[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private agentınformationApiService: AgentInformationApiService,
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
                emptyTable: 'Fetching AgentInformation...'
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

        this.getAllAgentInformations();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllAgentInformations() {
        this.agentınformationApiService.getAllAgentInformations().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(AgentInformationDialogComponent, {
            width: '650px',
            data: new Agentınformation()
        });

        dialogRef.afterClosed().subscribe(agentınformation => {
            if (agentınformation) {
                this.agentınformationApiService.addAgentInformation(agentınformation).subscribe(() => {
                    this.getAllAgentInformations();
                    this.notificationsService.showNotification('Success', 'Agentınformation added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(agentınformation: Agentınformation) {
        const dialogRef = this.dialog.open(AgentInformationDialogComponent, {
            width: '650px',
            data: agentınformation
        });

        dialogRef.afterClosed().subscribe(agentınformation => {
            if (agentınformation) {
                this.agentınformationApiService.updateAgentInformation(agentınformation).subscribe(() => {
                    this.getAllAgentInformations();
                    this.notificationsService.showNotification('Success', 'Agentınformation updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(agentınformation: Agentınformation) {
        const dialogData = new ConfirmDialogModel("Really delete?", agentınformation.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.agentınformationApiService.deleteAgentInformation(agentınformation.ıd).subscribe(() => {
                    this.getAllAgentInformations();
                    this.notificationsService.showNotification('Success', 'Agentınformation deleted successfully', 'success');
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

