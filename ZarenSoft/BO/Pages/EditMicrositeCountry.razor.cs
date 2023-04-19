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
    public partial class EditMicrositeCountry
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
            micrositeCountry = await TravelCDbService.GetMicrositeCountryById(Id);

            agenciesForAgencyId = await TravelCDbService.GetAgencies();

            microSitesForMicroSiteId = await TravelCDbService.GetMicroSites();
        }
        protected bool errorVisible;
        protected Travel.Models.TravelCDb.MicrositeCountry micrositeCountry;

        protected IEnumerable<Travel.Models.TravelCDb.Agency> agenciesForAgencyId;

        protected IEnumerable<Travel.Models.TravelCDb.MicroSite> microSitesForMicroSiteId;

        protected async Task FormSubmit()
        {
            try
            {
                await TravelCDbService.UpdateMicrositeCountry(Id, micrositeCountry);
                DialogService.Close(micrositeCountry);
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

            micrositeCountry = await TravelCDbService.GetMicrositeCountryById(Id);
        }
    }
}