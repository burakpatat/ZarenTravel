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
    public partial class AgencyUsers
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

        protected IEnumerable<Travel.Models.TravelCDb.AgencyUser> agencyUsers;

        protected RadzenDataGrid<Travel.Models.TravelCDb.AgencyUser> grid0;

        protected string search = "";

        protected async Task Search(ChangeEventArgs args)
        {
            search = $"{args.Value}";

            await grid0.GoToPage(0);

            agencyUsers = await TravelCDbService.GetAgencyUsers(new Query { Filter = $@"i => i.UserName.Contains(@0) || i.Password.Contains(@0) || i.Email.Contains(@0) || i.ForwardToEmail.Contains(@0) || i.Phone.Contains(@0) || i.Name.Contains(@0) || i.Surname.Contains(@0) || i.DocumentNumber.Contains(@0) || i.ExternalCode.Contains(@0) || i.Remark.Contains(@0)", FilterParameters = new object[] { search }, Expand = "Agency,Country1,Gender1,Currency,Statu1" });
        }
        protected override async Task OnInitializedAsync()
        {
            agencyUsers = await TravelCDbService.GetAgencyUsers(new Query { Filter = $@"i => i.UserName.Contains(@0) || i.Password.Contains(@0) || i.Email.Contains(@0) || i.ForwardToEmail.Contains(@0) || i.Phone.Contains(@0) || i.Name.Contains(@0) || i.Surname.Contains(@0) || i.DocumentNumber.Contains(@0) || i.ExternalCode.Contains(@0) || i.Remark.Contains(@0)", FilterParameters = new object[] { search }, Expand = "Agency,Country1,Gender1,Currency,Statu1" });
        }

        protected async Task AddButtonClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddAgencyUser>("Add AgencyUser", null);
            await grid0.Reload();
        }

        protected async Task EditRow(DataGridRowMouseEventArgs<Travel.Models.TravelCDb.AgencyUser> args)
        {
            await DialogService.OpenAsync<EditAgencyUser>("Edit AgencyUser", new Dictionary<string, object> { {"Id", args.Data.Id} });
        }

        protected async Task GridDeleteButtonClick(MouseEventArgs args, Travel.Models.TravelCDb.AgencyUser agencyUser)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var deleteResult = await TravelCDbService.DeleteAgencyUser(agencyUser.Id);

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
                    Detail = $"Unable to delete AgencyUser" 
                });
            }
        }

        protected async Task ExportClick(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await TravelCDbService.ExportAgencyUsersToCSV(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "Agency,Country1,Gender1,Currency,Statu1", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "AgencyUsers");
            }

            if (args == null || args.Value == "xlsx")
            {
                await TravelCDbService.ExportAgencyUsersToExcel(new Query
{ 
    Filter = $@"{(string.IsNullOrEmpty(grid0.Query.Filter)? "true" : grid0.Query.Filter)}", 
    OrderBy = $"{grid0.Query.OrderBy}", 
    Expand = "Agency,Country1,Gender1,Currency,Statu1", 
    Select = string.Join(",", grid0.ColumnsCollection.Where(c => c.GetVisible()).Select(c => c.Property))
}, "AgencyUsers");
            }
        }
    }
}