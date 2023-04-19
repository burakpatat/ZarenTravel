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
    public partial class EditHotel
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
            hotel = await TravelCDbService.GetHotelById(Id);

            agenciesForAgencyId = await TravelCDbService.GetAgencies();

            apisForApiId = await TravelCDbService.GetApis();

            fraudRisksForFraudRiskId = await TravelCDbService.GetFraudRisks();

            manuelRegistrationsForManuelRegistrationId = await TravelCDbService.GetManuelRegistrations();

            microSitesForMicroSiteId = await TravelCDbService.GetMicroSites();

            statusForStatu = await TravelCDbService.GetStatus();
        }
        protected bool errorVisible;
        protected Travel.Models.TravelCDb.Hotel hotel;

        protected IEnumerable<Travel.Models.TravelCDb.Agency> agenciesForAgencyId;

        protected IEnumerable<Travel.Models.TravelCDb.Api> apisForApiId;

        protected IEnumerable<Travel.Models.TravelCDb.FraudRisk> fraudRisksForFraudRiskId;

        protected IEnumerable<Travel.Models.TravelCDb.ManuelRegistration> manuelRegistrationsForManuelRegistrationId;

        protected IEnumerable<Travel.Models.TravelCDb.MicroSite> microSitesForMicroSiteId;

        protected IEnumerable<Travel.Models.TravelCDb.Statu> statusForStatu;

        protected async Task FormSubmit()
        {
            try
            {
                await TravelCDbService.UpdateHotel(Id, hotel);
                DialogService.Close(hotel);
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

            hotel = await TravelCDbService.GetHotelById(Id);
        }
    }
}