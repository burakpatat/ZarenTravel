import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { TerminalApiService } from 'app/core/services/terminal.service';
import { MatDialog } from '@angular/material/dialog';
import { Terminal } from 'app/shared/models/terminal';
import { TerminalDialogComponent } from './terminal-dialog/terminal-dialog.component';
import { ConfirmDialogModel } from 'app/shared/models/confirm-dialog';
import { ConfirmDialogComponent } from 'app/shared/components/confirm-dialog/confirm-dialog.component';
import { NotificationsService } from 'app/core/services/notifications.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';

@Component({
    selector: 'app-Terminal-cmp',
    templateUrl: 'Terminal.component.html',
    providers: [TerminalApiService]
})

export class TerminalComponent implements OnInit, OnDestroy {
    public dtos: Terminal[];

    @ViewChild(DataTableDirective,  {static: false}) dtElement: DataTableDirective;
    public dtTrigger: Subject<any> = new Subject();
    public dtOptions: any;

    constructor(
        public dialog: MatDialog,
        private terminalApiService: TerminalApiService,
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
                emptyTable: 'Fetching Terminal...'
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

        this.getAllTerminals();
    }

    ngAfterViewInit() {
        this.renderDataTable();
    }

    getAllTerminals() {
        this.terminalApiService.getAllTerminals().subscribe(dtos => {
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
        const dialogRef = this.dialog.open(TerminalDialogComponent, {
            width: '650px',
            data: new Terminal()
        });

        dialogRef.afterClosed().subscribe(terminal => {
            if (terminal) {
                this.terminalApiService.addTerminal(terminal).subscribe(() => {
                    this.getAllTerminals();
                    this.notificationsService.showNotification('Success', 'Terminal added successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    editDialog(terminal: Terminal) {
        const dialogRef = this.dialog.open(TerminalDialogComponent, {
            width: '650px',
            data: terminal
        });

        dialogRef.afterClosed().subscribe(terminal => {
            if (terminal) {
                this.terminalApiService.updateTerminal(terminal).subscribe(() => {
                    this.getAllTerminals();
                    this.notificationsService.showNotification('Success', 'Terminal updated successfully', 'success');
                }, (err) => {
                    this.notificationsService.showNotification('Error', err.message, 'warning');
                });
            }
        });
    }

    deleteDialog(terminal: Terminal) {
        const dialogData = new ConfirmDialogModel("Really delete?", terminal.ıd.toString());
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
            width: "400px",
            data: dialogData
        });

        dialogRef.afterClosed().subscribe(remove => {
            if (remove) {
                this.terminalApiService.deleteTerminal(terminal.ıd).subscribe(() => {
                    this.getAllTerminals();
                    this.notificationsService.showNotification('Success', 'Terminal deleted successfully', 'success');
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

