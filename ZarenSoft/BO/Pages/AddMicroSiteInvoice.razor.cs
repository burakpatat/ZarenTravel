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
    public partial class AddMicroSiteInvoice
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

        protected override async Task OnInitializedAsync()
        {
            microSiteInvoice = new Travel.Models.TravelCDb.MicroSiteInvoice();

            agenciesForAgencyId = await TravelCDbService.GetAgencies();

            citiesForCityId = await TravelCDbService.GetCities();

            countriesForCountryId = await TravelCDbService.GetCountries();

            microSitesForMicroSiteId = await TravelCDbService.GetMicroSites();
        }
        protected bool errorVisible;
        protected Travel.Models.TravelCDb.MicroSiteInvoice microSiteInvoice;

        protected IEnumerable<Travel.Models.TravelCDb.Agency> agenciesForAgencyId;

        protected IEnumerable<Travel.Models.TravelCDb.City> citiesForCityId;

        protected IEnumerable<Travel.Models.TravelCDb.Country> countriesForCountryId;

        protected IEnumerable<Travel.Models.TravelCDb.MicroSite> microSitesForMicroSiteId;

        protected async Task FormSubmit()
        {
            try
            {
                await TravelCDbService.CreateMicroSiteInvoice(microSiteInvoice);
                DialogService.Close(microSiteInvoice);
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
    }
}