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
    public partial class Countries
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

        protected IEnumerable<Travel.Models.TravelCDb.Country> countries;

        protected RadzenDataGrid<Travel.Models.TravelCDb.Country> grid0;

        protected string search = "";

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            countries = await TravelCDbService.GetCountries(new Query { Filter = $@"i => i.Name.Contains(@0) || i.ShortName.Contains(@0) || i.Temperature.Contains(@0) || i.Area.Contains(@0) || i.Religion.Contains(@0) || i.Location.Contains(@0) || i.Density.Contains(@0) || i.Symbol.Contains(@0) || i.Abbreviation.Contains(@0) || i.FlagBase64.Contains(@0) || i.Expectancy.Contains(@0) || i.Dish.Contains(@0) || i.LanguagesJSON.Contains(@0) || i.Landlocked.Contains(@0) || i.Iso.Contains(@0) || i.Independence.Contains(@0) || i.Government.Contains(@0) || i.North.Contains(@0) || i.South.Contains(@0) || i.West.Contains(@0) || i.East.Contains(@0) || i.Elevation.Contains(@0) || i.DomainTld.Contains(@0) || i.CurrencyName.Contains(@0) || i.CurrencyCode.Contains(@0) || i.CostLine.Contains(@0) || i.Continent.Contains(@0) || i.City.Contains(@0) || i.CallingCode.Contains(@0) || i.Barcode.Contains(@0) || i.Height.Contains(@0) || i.Logo.Contains(@0)", FilterParameters = new object[] { search }, Expand = "Language,MicroSiteCountriesFraudRisk" });
        }
        protected override async Task OnInitializedAsync()
        {
            countries = await TravelCDbService.GetCountries(new Query { Filter = $@"i => i.Name.Contains(@0) || i.ShortName.Contains(@0) || i.Temperature.Contains(@0) || i.Area.Contains(@0) || i.Religion.Contains(@0) || i.Location.Contains(@0) || i.Density.Contains(@0) || i.Symbol.Contains(@0) || i.Abbreviation.Contains(@0) || i.FlagBase64.Contains(@0) || i.Expectancy.Contains(@0) || i.Dish.Contains(@0) || i.LanguagesJSON.Contains(@0) || i.Landlocked.Contains(@0) || i.Iso.Contains(@0) || i.Independence.Contains(@0) || i.Government.Contains(@0) || i.North.Contains(@0) || i.South.Contains(@0) || i.West.Contains(@0) || i.East.Contains(@0) || i.Elevation.Contains(@0) || i.DomainTld.Contains(@0) || i.CurrencyName.Contains(@0) || i.CurrencyCode.Contains(@0) || i.CostLine.Contains(@0) || i.Continent.Contains(@0) || i.City.Contains(@0) || i.CallingCode.Contains(@0) || i.Barcode.Contains(@0) || i.Height.Contains(@0) || i.Logo.Contains(@0)", FilterParameters = new object[] { search }, Expand = "Language,MicroSiteCountriesFraudRisk" });
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddCountry>("Add Country", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<Travel.Models.TravelCDb.Country> args)
        {
            await DialogService.OpenAsync<EditCountry>("Edit Country", new Dictionary<string, object> { {"Id", args.Data.Id} });
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Travel.Models.TravelCDb.Country country)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await TravelCDbService.DeleteCountry(country.Id);

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
                    Detail = $"Unable to delete Country" 
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await TravelCDbService.ExportCountriesToCSV(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "Language,MicroSiteCountriesFraudRisk", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "Countries");
            }

            if (args == null || args.Value == "xlsx")
            {
                await TravelCDbService.ExportCountriesToExcel(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "Language,MicroSiteCountriesFraudRisk", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "Countries");
            }
        }
    }
}