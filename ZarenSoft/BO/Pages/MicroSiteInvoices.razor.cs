using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace Travel.Pages
{
    public partial class MicroSiteInvoices
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        public TravelCDbService TravelCDbService { get; set; }

        protected IEnumerable<Travel.Models.TravelCDb.MicroSiteInvoice> microSiteInvoices;

        protected RadzenDataGrid<Travel.Models.TravelCDb.MicroSiteInvoice> grid0;

        protected string search = "";

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            microSiteInvoices = await TravelCDbService.GetMicroSiteInvoices(new Query { Filter = $@"i => i.NumberPrefix.Contains(@0) || i.Name.Contains(@0) || i.Address.Contains(@0) || i.Email.Contains(@0) || i.VAT.Contains(@0) || i.BillingDetails.Contains(@0) || i.BankDetails.Contains(@0) || i.TaxesDetails.Contains(@0) || i.LegalFooter.Contains(@0) || i.MailBody.Contains(@0)", FilterParameters = new object[] { search }, Expand = "Agency,City,Country,MicroSite" });
        }
        protected override async Task OnInitializedAsync()
        {
            microSiteInvoices = await TravelCDbService.GetMicroSiteInvoices(new Query { Filter = $@"i => i.NumberPrefix.Contains(@0) || i.Name.Contains(@0) || i.Address.Contains(@0) || i.Email.Contains(@0) || i.VAT.Contains(@0) || i.BillingDetails.Contains(@0) || i.BankDetails.Contains(@0) || i.TaxesDetails.Contains(@0) || i.LegalFooter.Contains(@0) || i.MailBody.Contains(@0)", FilterParameters = new object[] { search }, Expand = "Agency,City,Country,MicroSite" });
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddMicroSiteInvoice>("Add MicroSiteInvoice", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<Travel.Models.TravelCDb.MicroSiteInvoice> args)
        {
            await DialogService.OpenAsync<EditMicroSiteInvoice>("Edit MicroSiteInvoice", new Dictionary<string, object> { {"Id", args.Data.Id} });
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Travel.Models.TravelCDb.MicroSiteInvoice microSiteInvoice)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await TravelCDbService.DeleteMicroSiteInvoice(microSiteInvoice.Id);

                    if (deleteResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage
                { 
                    Severity = NotificationSeverity.Error,
                    Summary = $"Error", 
                    Detail = $"Unable to delete MicroSiteInvoice" 
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await TravelCDbService.ExportMicroSiteInvoicesToCSV(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "Agency,City,Country,MicroSite", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "MicroSiteInvoices");
            }

            if (args == null || args.Value == "xlsx")
            {
                await TravelCDbService.ExportMicroSiteInvoicesToExcel(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "Agency,City,Country,MicroSite", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "MicroSiteInvoices");
            }
        }
    }
}