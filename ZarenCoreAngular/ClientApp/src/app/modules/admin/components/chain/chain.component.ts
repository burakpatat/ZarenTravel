import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { ChainApiService } from 'app/core/services/chain.service';
import { MatDialog } from '@angular/material/dialog';
import { Chain } from 'app/shared/models/chain';
import { ChainDialogComponent } from './chain-dialog/chain-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-Chain-cmp',
    templateUrl: 'Chain.component.html',
    providers: [ChainApiService]
})

export class ChainComponent implements OnInit, OnDestroy {
    public dtos: Chain[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private chainApiService: ChainApiService,
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
                emptyTable: 'Fetching Chain...'
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

        this.getAllChains();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllChains() {
        this.chainApiService.getAllChains().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(ChainDialogComponent, {
            width: '650px',
            data: new Chain()
        });

        dialogRef.afterClosed().subscribe(chain => {
            if (chain) {
                this.chainApiService.addChain(chain).subscribe(() => {
                    this.getAllChains();
                    this.notificationsService.showNotification('Success', 'Chain added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(chain: Chain) {
        const dialogRef = this.dialog.open(ChainDialogComponent, {
            width: '650px',
            data: chain
        });

        dialogRef.afterClosed().subscribe(chain => {
            if (chain) {
                this.chainApiService.updateChain(chain).subscribe(() => {
                    this.getAllChains();
                    this.notificationsService.showNotification('Success', 'Chain updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(chain: Chain) {
        const dialogData = new ConfirmDialogModel("Really delete?", chain.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.chainApiService.deleteChain(chain.ıd).subscribe(() => {
                    this.getAllChains();
                    this.notificationsService.showNotification('Success', 'Chain deleted successfully', 'success');
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

