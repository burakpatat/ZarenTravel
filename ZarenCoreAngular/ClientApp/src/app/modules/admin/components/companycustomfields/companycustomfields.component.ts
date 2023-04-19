import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { CompanyCustomFieldsApiService } from 'app/core/services/companycustomfields.service';
import { MatDialog } from '@angular/material/dialog';
import { Companycustomfields } from 'app/shared/models/companycustomfields';
import { CompanyCustomFieldsDialogComponent } from './companycustomfields-dialog/companycustomfields-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-CompanyCustomFields-cmp',
    templateUrl: 'CompanyCustomFields.component.html',
    providers: [CompanyCustomFieldsApiService]
})

export class CompanyCustomFieldsComponent implements OnInit, OnDestroy {
    public dtos: Companycustomfields[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private companycustomfieldsApiService: CompanyCustomFieldsApiService,
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
                emptyTable: 'Fetching CompanyCustomFields...'
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

        this.getAllCompanyCustomFieldss();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllCompanyCustomFieldss() {
        this.companycustomfieldsApiService.getAllCompanyCustomFieldss().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(CompanyCustomFieldsDialogComponent, {
            width: '650px',
            data: new Companycustomfields()
        });

        dialogRef.afterClosed().subscribe(companycustomfields => {
            if (companycustomfields) {
                this.companycustomfieldsApiService.addCompanyCustomFields(companycustomfields).subscribe(() => {
                    this.getAllCompanyCustomFieldss();
                    this.notificationsService.showNotification('Success', 'Companycustomfields added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(companycustomfields: Companycustomfields) {
        const dialogRef = this.dialog.open(CompanyCustomFieldsDialogComponent, {
            width: '650px',
            data: companycustomfields
        });

        dialogRef.afterClosed().subscribe(companycustomfields => {
            if (companycustomfields) {
                this.companycustomfieldsApiService.updateCompanyCustomFields(companycustomfields).subscribe(() => {
                    this.getAllCompanyCustomFieldss();
                    this.notificationsService.showNotification('Success', 'Companycustomfields updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(companycustomfields: Companycustomfields) {
        const dialogData = new ConfirmDialogModel("Really delete?", companycustomfields.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.companycustomfieldsApiService.deleteCompanyCustomFields(companycustomfields.ıd).subscribe(() => {
                    this.getAllCompanyCustomFieldss();
                    this.notificationsService.showNotification('Success', 'Companycustomfields deleted successfully', 'success');
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

