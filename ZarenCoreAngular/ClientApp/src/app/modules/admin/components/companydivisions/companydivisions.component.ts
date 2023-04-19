import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { CompanyDivisionsApiService } from 'app/core/services/companydivisions.service';
import { MatDialog } from '@angular/material/dialog';
import { Companydivisions } from 'app/shared/models/companydivisions';
import { CompanyDivisionsDialogComponent } from './companydivisions-dialog/companydivisions-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-CompanyDivisions-cmp',
    templateUrl: 'CompanyDivisions.component.html',
    providers: [CompanyDivisionsApiService]
})

export class CompanyDivisionsComponent implements OnInit, OnDestroy {
    public dtos: Companydivisions[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private companydivisionsApiService: CompanyDivisionsApiService,
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
                emptyTable: 'Fetching CompanyDivisions...'
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

        this.getAllCompanyDivisionss();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllCompanyDivisionss() {
        this.companydivisionsApiService.getAllCompanyDivisionss().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(CompanyDivisionsDialogComponent, {
            width: '650px',
            data: new Companydivisions()
        });

        dialogRef.afterClosed().subscribe(companydivisions => {
            if (companydivisions) {
                this.companydivisionsApiService.addCompanyDivisions(companydivisions).subscribe(() => {
                    this.getAllCompanyDivisionss();
                    this.notificationsService.showNotification('Success', 'Companydivisions added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(companydivisions: Companydivisions) {
        const dialogRef = this.dialog.open(CompanyDivisionsDialogComponent, {
            width: '650px',
            data: companydivisions
        });

        dialogRef.afterClosed().subscribe(companydivisions => {
            if (companydivisions) {
                this.companydivisionsApiService.updateCompanyDivisions(companydivisions).subscribe(() => {
                    this.getAllCompanyDivisionss();
                    this.notificationsService.showNotification('Success', 'Companydivisions updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(companydivisions: Companydivisions) {
        const dialogData = new ConfirmDialogModel("Really delete?", companydivisions.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.companydivisionsApiService.deleteCompanyDivisions(companydivisions.ıd).subscribe(() => {
                    this.getAllCompanyDivisionss();
                    this.notificationsService.showNotification('Success', 'Companydivisions deleted successfully', 'success');
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

