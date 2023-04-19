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
    public partial class Hotels
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

        protected IEnumerable<Travel.Models.TravelCDb.Hotel> hotels;

        protected RadzenDataGrid<Travel.Models.TravelCDb.Hotel> grid0;

        protected string search = "";

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            hotels = await TravelCDbService.GetHotels(new Query { Filter = $@"i => i.Name.Contains(@0) || i.SystemId.Contains(@0) || i.GiataId.Contains(@0) || i.FaxNumber.Contains(@0) || i.PhoneNumber.Contains(@0) || i.HomePage.Contains(@0) || i.Provider.Contains(@0) || i.Thumbnail.Contains(@0) || i.ThumbnailFull.Contains(@0) || i.Code.Contains(@0) || i.Adress.Contains(@0)", FilterParameters = new object[] { search }, Expand = "Agency,Api,FraudRisk,ManuelRegistration,MicroSite,Statu1" });
        }
        protected override async Task OnInitializedAsync()
        {
            hotels = await TravelCDbService.GetHotels(new Query { Filter = $@"i => i.Name.Contains(@0) || i.SystemId.Contains(@0) || i.GiataId.Contains(@0) || i.FaxNumber.Contains(@0) || i.PhoneNumber.Contains(@0) || i.HomePage.Contains(@0) || i.Provider.Contains(@0) || i.Thumbnail.Contains(@0) || i.ThumbnailFull.Contains(@0) || i.Code.Contains(@0) || i.Adress.Contains(@0)", FilterParameters = new object[] { search }, Expand = "Agency,Api,FraudRisk,ManuelRegistration,MicroSite,Statu1" });
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddHotel>("Add Hotel", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<Travel.Models.TravelCDb.Hotel> args)
        {
            await DialogService.OpenAsync<EditHotel>("Edit Hotel", new Dictionary<string, object> { {"Id", args.Data.Id} });
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Travel.Models.TravelCDb.Hotel hotel)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await TravelCDbService.DeleteHotel(hotel.Id);

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
                    Detail = $"Unable to delete Hotel" 
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await TravelCDbService.ExportHotelsToCSV(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "Agency,Api,FraudRisk,ManuelRegistration,MicroSite,Statu1", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "Hotels");
            }

            if (args == null || args.Value == "xlsx")
            {
                await TravelCDbService.ExportHotelsToExcel(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "Agency,Api,FraudRisk,ManuelRegistration,MicroSite,Statu1", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "Hotels");
            }
        }
    }
}