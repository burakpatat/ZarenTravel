using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace Payzee.Pages
{
    public partial class Currencies
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
        public Payment3Service Payment3Service { get; set; }

        protected IEnumerable<Payzee.Models.Payment3.Currency> currencies;

        protected RadzenDataGrid<Payzee.Models.Payment3.Currency> grid0;

        protected string search = "";

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            currencies = await Payment3Service.GetCurrencies(new Query { Filter = $@"i => i.Country.Contains(@0) || i.Name.Contains(@0) || i.CurrencyCode.Contains(@0) || i.Number.Contains(@0)", FilterParameters = new object[] { search } });
        }
        protected override async Task OnInitializedAsync()
        {
            currencies = await Payment3Service.GetCurrencies(new Query { Filter = $@"i => i.Country.Contains(@0) || i.Name.Contains(@0) || i.CurrencyCode.Contains(@0) || i.Number.Contains(@0)", FilterParameters = new object[] { search } });
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await grid0.InsertRow(new Payzee.Models.Payment3.Currency());
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Payzee.Models.Payment3.Currency currency)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await Payment3Service.DeleteCurrency(currency.Id);

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
                    Detail = $"Unable to delete Currency" 
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await Payment3Service.ExportCurrenciesToCSV(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "Currencies");
            }

            if (args == null || args.Value == "xlsx")
            {
                await Payment3Service.ExportCurrenciesToExcel(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "Currencies");
            }
        }

        protected async Task GridRowUpdate(Payzee.Models.Payment3.Currency args)
        {
            await Payment3Service.UpdateCurrency(args.Id, args);
        }

        protected async Task GridRowCreate(Payzee.Models.Payment3.Currency args)
        {
            await Payment3Service.CreateCurrency(args);
            await grid0.Reload();
        }

        protected async Task EditButtonClick(MouseEventArgs args, Payzee.Models.Payment3.Currency data)
        {
            await grid0.EditRow(data);
        }

        protected async Task SaveButtonClick(MouseEventArgs args, Payzee.Models.Payment3.Currency data)
        {
            await grid0.UpdateRow(data);
        }

        protected async Task CancelButtonClick(MouseEventArgs args, Payzee.Models.Payment3.Currency data)
        {
            grid0.CancelEditRow(data);
            await Payment3Service.CancelCurrencyChanges(data);
        }
    }
}