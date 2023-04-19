import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { CompanyGroupApiService } from 'app/core/services/companygroup.service';
import { MatDialog } from '@angular/material/dialog';
import { Companygroup } from 'app/shared/models/companygroup';
import { CompanyGroupDialogComponent } from './companygroup-dialog/companygroup-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-CompanyGroup-cmp',
    templateUrl: 'CompanyGroup.component.html',
    providers: [CompanyGroupApiService]
})

export class CompanyGroupComponent implements OnInit, OnDestroy {
    public dtos: Companygroup[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private companygroupApiService: CompanyGroupApiService,
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
                emptyTable: 'Fetching CompanyGroup...'
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

        this.getAllCompanyGroups();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllCompanyGroups() {
        this.companygroupApiService.getAllCompanyGroups().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(CompanyGroupDialogComponent, {
            width: '650px',
            data: new Companygroup()
        });

        dialogRef.afterClosed().subscribe(companygroup => {
            if (companygroup) {
                this.companygroupApiService.addCompanyGroup(companygroup).subscribe(() => {
                    this.getAllCompanyGroups();
                    this.notificationsService.showNotification('Success', 'Companygroup added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(companygroup: Companygroup) {
        const dialogRef = this.dialog.open(CompanyGroupDialogComponent, {
            width: '650px',
            data: companygroup
        });

        dialogRef.afterClosed().subscribe(companygroup => {
            if (companygroup) {
                this.companygroupApiService.updateCompanyGroup(companygroup).subscribe(() => {
                    this.getAllCompanyGroups();
                    this.notificationsService.showNotification('Success', 'Companygroup updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(companygroup: Companygroup) {
        const dialogData = new ConfirmDialogModel("Really delete?", companygroup.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.companygroupApiService.deleteCompanyGroup(companygroup.ıd).subscribe(() => {
                    this.getAllCompanyGroups();
                    this.notificationsService.showNotification('Success', 'Companygroup deleted successfully', 'success');
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

