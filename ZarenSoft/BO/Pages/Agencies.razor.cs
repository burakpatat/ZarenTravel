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
    public partial class Agencies
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

        protected IEnumerable<Travel.Models.TravelCDb.Agency> agencies;

        protected RadzenDataGrid<Travel.Models.TravelCDb.Agency> grid0;

        protected string search = "";

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            agencies = await TravelCDbService.GetAgencies(new Query { Filter = $@"i => i.City.Contains(@0) || i.WhatsAppNo.Contains(@0) || i.Email.Contains(@0) || i.Address.Contains(@0) || i.Provience.Contains(@0) || i.DocumentNumber.Contains(@0) || i.ContactPersonName.Contains(@0) || i.BillingEmails.Contains(@0) || i.BusinessName.Contains(@0) || i.PostalCode.Contains(@0) || i.Region.Contains(@0) || i.PhoneNo.Contains(@0) || i.ContactPersonLastName.Contains(@0) || i.ManagementGroup.Contains(@0) || i.Remarks.Contains(@0) || i.WinterHours.Contains(@0) || i.SummerHours.Contains(@0) || i.GDSIdentifierForGalileo.Contains(@0)", FilterParameters = new object[] { search }, Expand = "AgencyManager,Country,InvoiceType,Statu1" });
        }
        protected override async Task OnInitializedAsync()
        {
            agencies = await TravelCDbService.GetAgencies(new Query { Filter = $@"i => i.City.Contains(@0) || i.WhatsAppNo.Contains(@0) || i.Email.Contains(@0) || i.Address.Contains(@0) || i.Provience.Contains(@0) || i.DocumentNumber.Contains(@0) || i.ContactPersonName.Contains(@0) || i.BillingEmails.Contains(@0) || i.BusinessName.Contains(@0) || i.PostalCode.Contains(@0) || i.Region.Contains(@0) || i.PhoneNo.Contains(@0) || i.ContactPersonLastName.Contains(@0) || i.ManagementGroup.Contains(@0) || i.Remarks.Contains(@0) || i.WinterHours.Contains(@0) || i.SummerHours.Contains(@0) || i.GDSIdentifierForGalileo.Contains(@0)", FilterParameters = new object[] { search }, Expand = "AgencyManager,Country,InvoiceType,Statu1" });
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddAgency>("Add Agency", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<Travel.Models.TravelCDb.Agency> args)
        {
            await DialogService.OpenAsync<EditAgency>("Edit Agency", new Dictionary<string, object> { {"Id", args.Data.Id} });
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Travel.Models.TravelCDb.Agency agency)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await TravelCDbService.DeleteAgency(agency.Id);

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
                    Detail = $"Unable to delete Agency" 
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await TravelCDbService.ExportAgenciesToCSV(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "AgencyManager,Country,InvoiceType,Statu1", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "Agencies");
            }

            if (args == null || args.Value == "xlsx")
            {
                await TravelCDbService.ExportAgenciesToExcel(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "AgencyManager,Country,InvoiceType,Statu1", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "Agencies");
            }
        }
    }
}