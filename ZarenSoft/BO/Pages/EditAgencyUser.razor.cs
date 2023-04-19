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
    public partial class EditAgencyUser
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
            agencyUser = await TravelCDbService.GetAgencyUserById(Id);

            agenciesForAgencyId = await TravelCDbService.GetAgencies();

            countriesForCountry = await TravelCDbService.GetCountries();

            gendersForGender = await TravelCDbService.GetGenders();

            currenciesForManagementFeeCurrencyId = await TravelCDbService.GetCurrencies();

            statusForStatu = await TravelCDbService.GetStatus();
        }
        protected bool errorVisible;
        protected Travel.Models.TravelCDb.AgencyUser agencyUser;

        protected IEnumerable<Travel.Models.TravelCDb.Agency> agenciesForAgencyId;

        protected IEnumerable<Travel.Models.TravelCDb.Country> countriesForCountry;

        protected IEnumerable<Travel.Models.TravelCDb.Gender> gendersForGender;

        protected IEnumerable<Travel.Models.TravelCDb.Currency> currenciesForManagementFeeCurrencyId;

        protected IEnumerable<Travel.Models.TravelCDb.Statu> statusForStatu;

        protected async Task FormSubmit()
        {
            try
            {
                await TravelCDbService.UpdateAgencyUser(Id, agencyUser);
                DialogService.Close(agencyUser);
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

            agencyUser = await TravelCDbService.GetAgencyUserById(Id);
        }
    }
}