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
    public partial class MicrositeCountries
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

        protected IEnumerable<Travel.Models.TravelCDb.MicrositeCountry> micrositeCountries;

        protected RadzenDataGrid<Travel.Models.TravelCDb.MicrositeCountry> grid0;

        protected string search = "";

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            micrositeCountries = await TravelCDbService.GetMicrositeCountries(new Query { Filter = $@"i => i.Code.Contains(@0) || i.Flag.Contains(@0) || i.Name.Contains(@0) || i.Continent.Contains(@0) || i.Prefix.Contains(@0)", FilterParameters = new object[] { search }, Expand = "Agency,MicroSite" });
        }
        protected override async Task OnInitializedAsync()
        {
            micrositeCountries = await TravelCDbService.GetMicrositeCountries(new Query { Filter = $@"i => i.Code.Contains(@0) || i.Flag.Contains(@0) || i.Name.Contains(@0) || i.Continent.Contains(@0) || i.Prefix.Contains(@0)", FilterParameters = new object[] { search }, Expand = "Agency,MicroSite" });
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddMicrositeCountry>("Add MicrositeCountry", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<Travel.Models.TravelCDb.MicrositeCountry> args)
        {
            await DialogService.OpenAsync<EditMicrositeCountry>("Edit MicrositeCountry", new Dictionary<string, object> { {"Id", args.Data.Id} });
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Travel.Models.TravelCDb.MicrositeCountry micrositeCountry)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await TravelCDbService.DeleteMicrositeCountry(micrositeCountry.Id);

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
                    Detail = $"Unable to delete MicrositeCountry" 
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await TravelCDbService.ExportMicrositeCountriesToCSV(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "Agency,MicroSite", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "MicrositeCountries");
            }

            if (args == null || args.Value == "xlsx")
            {
                await TravelCDbService.ExportMicrositeCountriesToExcel(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "Agency,MicroSite", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "MicrositeCountries");
            }
        }
    }
}