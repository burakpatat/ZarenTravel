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
    public partial class MicroSiteApiProviders
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

        protected IEnumerable<Travel.Models.TravelCDb.MicroSiteApiProvider> microSiteApiProviders;

        protected RadzenDataGrid<Travel.Models.TravelCDb.MicroSiteApiProvider> grid0;

        protected string search = "";

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            microSiteApiProviders = await TravelCDbService.GetMicroSiteApiProviders(new Query { Expand = "Agency,Api,ApiProduct,MicroSite" });
        }
        protected override async Task OnInitializedAsync()
        {
            microSiteApiProviders = await TravelCDbService.GetMicroSiteApiProviders(new Query { Expand = "Agency,Api,ApiProduct,MicroSite" });
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddMicroSiteApiProvider>("Add MicroSiteApiProvider", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<Travel.Models.TravelCDb.MicroSiteApiProvider> args)
        {
            await DialogService.OpenAsync<EditMicroSiteApiProvider>("Edit MicroSiteApiProvider", new Dictionary<string, object> { {"Id", args.Data.Id} });
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Travel.Models.TravelCDb.MicroSiteApiProvider microSiteApiProvider)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await TravelCDbService.DeleteMicroSiteApiProvider(microSiteApiProvider.Id);

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
                    Detail = $"Unable to delete MicroSiteApiProvider" 
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await TravelCDbService.ExportMicroSiteApiProvidersToCSV(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "Agency,Api,ApiProduct,MicroSite", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "MicroSiteApiProviders");
            }

            if (args == null || args.Value == "xlsx")
            {
                await TravelCDbService.ExportMicroSiteApiProvidersToExcel(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "Agency,Api,ApiProduct,MicroSite", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "MicroSiteApiProviders");
            }
        }
    }
}