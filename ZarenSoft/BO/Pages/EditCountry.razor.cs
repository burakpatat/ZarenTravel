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
    public partial class EditCountry
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
            country = await TravelCDbService.GetCountryById(Id);

            languagesForDefaultLanguageId = await TravelCDbService.GetLanguages();

            microSiteCountriesFraudRisksForHasFraudRiskId = await TravelCDbService.GetMicroSiteCountriesFraudRisks();
        }
        protected bool errorVisible;
        protected Travel.Models.TravelCDb.Country country;

        protected IEnumerable<Travel.Models.TravelCDb.Language> languagesForDefaultLanguageId;

        protected IEnumerable<Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk> microSiteCountriesFraudRisksForHasFraudRiskId;

        protected async Task FormSubmit()
        {
            try
            {
                await TravelCDbService.UpdateCountry(Id, country);
                DialogService.Close(country);
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

            country = await TravelCDbService.GetCountryById(Id);
        }
    }
}