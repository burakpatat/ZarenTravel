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
    public partial class EditAgency
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

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            agency = await TravelCDbService.GetAgencyById(Id);

            agencyManagersForAgencyManagerId = await TravelCDbService.GetAgencyManagers();

            countriesForCountryId = await TravelCDbService.GetCountries();

            invoiceTypesForInvoiceTypeId = await TravelCDbService.GetInvoiceTypes();

            statusForStatu = await TravelCDbService.GetStatus();
        }
        protected bool errorVisible;
        protected Travel.Models.TravelCDb.Agency agency;

        protected IEnumerable<Travel.Models.TravelCDb.AgencyManager> agencyManagersForAgencyManagerId;

        protected IEnumerable<Travel.Models.TravelCDb.Country> countriesForCountryId;

        protected IEnumerable<Travel.Models.TravelCDb.InvoiceType> invoiceTypesForInvoiceTypeId;

        protected IEnumerable<Travel.Models.TravelCDb.Statu> statusForStatu;

        protected async Task FormSubmit()
        {
            try
            {
                await TravelCDbService.UpdateAgency(Id, agency);
                DialogService.Close(agency);
            }
            catch (Exception ex)
            {
                hasChanges = ex is Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException;
                canEdit = !(ex is Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException);
                errorVisible = true;
            }
        }

        protected async Task CancelButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }


        protected bool hasChanges = false;
        protected bool canEdit = true;


        protected async Task ReloadButtonClick(MouseEventArgs args)
        {
           TravelCDbService.Reset();
            hasChanges = false;
            canEdit = true;

            agency = await TravelCDbService.GetAgencyById(Id);
        }
    }
}