import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { CompanyApiService } from 'app/core/services/company.service';
import { MatDialog } from '@angular/material/dialog';
import { Company } from 'app/shared/models/company';
import { CompanyDialogComponent } from './company-dialog/company-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-Company-cmp',
    templateUrl: 'Company.component.html',
    providers: [CompanyApiService]
})

export class CompanyComponent implements OnInit, OnDestroy {
    public dtos: Company[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private companyApiService: CompanyApiService,
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
                emptyTable: 'Fetching Company...'
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

        this.getAllCompanys();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllCompanys() {
        this.companyApiService.getAllCompanys().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(CompanyDialogComponent, {
            width: '650px',
            data: new Company()
        });

        dialogRef.afterClosed().subscribe(company => {
            if (company) {
                this.companyApiService.addCompany(company).subscribe(() => {
                    this.getAllCompanys();
                    this.notificationsService.showNotification('Success', 'Company added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(company: Company) {
        const dialogRef = this.dialog.open(CompanyDialogComponent, {
            width: '650px',
            data: company
        });

        dialogRef.afterClosed().subscribe(company => {
            if (company) {
                this.companyApiService.updateCompany(company).subscribe(() => {
                    this.getAllCompanys();
                    this.notificationsService.showNotification('Success', 'Company updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(company: Company) {
        const dialogData = new ConfirmDialogModel("Really delete?", company.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.companyApiService.deleteCompany(company.ıd).subscribe(() => {
                    this.getAllCompanys();
                    this.notificationsService.showNotification('Success', 'Company deleted successfully', 'success');
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

