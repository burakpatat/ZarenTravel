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
    public partial class ApiResults
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

        protected IEnumerable<Travel.Models.TravelCDb.ApiResult> apiResults;

        protected RadzenDataGrid<Travel.Models.TravelCDb.ApiResult> grid0;

        protected string search = "";

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            apiResults = await TravelCDbService.GetApiResults(new Query { Filter = $@"i => i.RequestData.Contains(@0) || i.ResponseData.Contains(@0) || i.Currency.Contains(@0) || i.CheckIn.Contains(@0) || i.Nationality.Contains(@0) || i.Query.Contains(@0)", FilterParameters = new object[] { search }, Expand = "ProductType1" });
        }
        protected override async Task OnInitializedAsync()
        {
            apiResults = await TravelCDbService.GetApiResults(new Query { Filter = $@"i => i.RequestData.Contains(@0) || i.ResponseData.Contains(@0) || i.Currency.Contains(@0) || i.CheckIn.Contains(@0) || i.Nationality.Contains(@0) || i.Query.Contains(@0)", FilterParameters = new object[] { search }, Expand = "ProductType1" });
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddApiResult>("Add ApiResult", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<Travel.Models.TravelCDb.ApiResult> args)
        {
            await DialogService.OpenAsync<EditApiResult>("Edit ApiResult", new Dictionary<string, object> { {"Id", args.Data.Id} });
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Travel.Models.TravelCDb.ApiResult apiResult)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await TravelCDbService.DeleteApiResult(apiResult.Id);

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
                    Detail = $"Unable to delete ApiResult" 
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await TravelCDbService.ExportApiResultsToCSV(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "ProductType1", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "ApiResults");
            }

            if (args == null || args.Value == "xlsx")
            {
                await TravelCDbService.ExportApiResultsToExcel(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "ProductType1", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "ApiResults");
            }
        }
    }
}