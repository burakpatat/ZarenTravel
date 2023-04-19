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
    public partial class FraudRisks
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

        protected IEnumerable<Travel.Models.TravelCDb.FraudRisk> fraudRisks;

        protected RadzenDataGrid<Travel.Models.TravelCDb.FraudRisk> grid0;

        protected string search = "";

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            fraudRisks = await TravelCDbService.GetFraudRisks(new Query { Filter = $@"i => i.Name.Contains(@0)", FilterParameters = new object[] { search } });
        }
        protected override async Task OnInitializedAsync()
        {
            fraudRisks = await TravelCDbService.GetFraudRisks(new Query { Filter = $@"i => i.Name.Contains(@0)", FilterParameters = new object[] { search } });
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddFraudRisk>("Add FraudRisk", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<Travel.Models.TravelCDb.FraudRisk> args)
        {
            await DialogService.OpenAsync<EditFraudRisk>("Edit FraudRisk", new Dictionary<string, object> { {"Id", args.Data.Id} });
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Travel.Models.TravelCDb.FraudRisk fraudRisk)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await TravelCDbService.DeleteFraudRisk(fraudRisk.Id);

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
                    Detail = $"Unable to delete FraudRisk" 
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await TravelCDbService.ExportFraudRisksToCSV(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "FraudRisks");
            }

            if (args == null || args.Value == "xlsx")
            {
                await TravelCDbService.ExportFraudRisksToExcel(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "FraudRisks");
            }
        }
    }
}