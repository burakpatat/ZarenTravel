using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using Travel.Data;

namespace Travel.Controllers
{
    public partial class ExportTravelCDbController : ExportController
    {
        private readonly TravelCDbContext context;
        private readonly TravelCDbService service;

        public ExportTravelCDbController(TravelCDbContext context, TravelCDbService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/TravelCDb/agencies/csv")]
        [HttpGet("/export/TravelCDb/agencies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgenciesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencies(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/agencies/excel")]
        [HttpGet("/export/TravelCDb/agencies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgenciesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencies(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/agencymanagers/csv")]
        [HttpGet("/export/TravelCDb/agencymanagers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyManagersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyManagers(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/agencymanagers/excel")]
        [HttpGet("/export/TravelCDb/agencymanagers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyManagersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyManagers(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/agencyusers/csv")]
        [HttpGet("/export/TravelCDb/agencyusers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyUsersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyUsers(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/agencyusers/excel")]
        [HttpGet("/export/TravelCDb/agencyusers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyUsersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyUsers(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/apis/csv")]
        [HttpGet("/export/TravelCDb/apis/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetApis(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/apis/excel")]
        [HttpGet("/export/TravelCDb/apis/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetApis(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/apiproducts/csv")]
        [HttpGet("/export/TravelCDb/apiproducts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApiProductsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetApiProducts(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/apiproducts/excel")]
        [HttpGet("/export/TravelCDb/apiproducts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApiProductsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetApiProducts(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/apiresults/csv")]
        [HttpGet("/export/TravelCDb/apiresults/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApiResultsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetApiResults(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/apiresults/excel")]
        [HttpGet("/export/TravelCDb/apiresults/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApiResultsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetApiResults(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/autocompletes/csv")]
        [HttpGet("/export/TravelCDb/autocompletes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompletesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAutoCompletes(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/autocompletes/excel")]
        [HttpGet("/export/TravelCDb/autocompletes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompletesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAutoCompletes(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/autocompletetypes/csv")]
        [HttpGet("/export/TravelCDb/autocompletetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompleteTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAutoCompleteTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/autocompletetypes/excel")]
        [HttpGet("/export/TravelCDb/autocompletetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompleteTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAutoCompleteTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/cities/csv")]
        [HttpGet("/export/TravelCDb/cities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCities(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/cities/excel")]
        [HttpGet("/export/TravelCDb/cities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCities(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/countries/csv")]
        [HttpGet("/export/TravelCDb/countries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/countries/excel")]
        [HttpGet("/export/TravelCDb/countries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/currencies/csv")]
        [HttpGet("/export/TravelCDb/currencies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrenciesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCurrencies(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/currencies/excel")]
        [HttpGet("/export/TravelCDb/currencies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrenciesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCurrencies(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/descriptions/csv")]
        [HttpGet("/export/TravelCDb/descriptions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDescriptionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDescriptions(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/descriptions/excel")]
        [HttpGet("/export/TravelCDb/descriptions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDescriptionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDescriptions(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/fraudrisks/csv")]
        [HttpGet("/export/TravelCDb/fraudrisks/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFraudRisksToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFraudRisks(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/fraudrisks/excel")]
        [HttpGet("/export/TravelCDb/fraudrisks/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFraudRisksToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFraudRisks(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/genders/csv")]
        [HttpGet("/export/TravelCDb/genders/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGendersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGenders(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/genders/excel")]
        [HttpGet("/export/TravelCDb/genders/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGendersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGenders(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/hotelcategories/csv")]
        [HttpGet("/export/TravelCDb/hotelcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/hotelcategories/excel")]
        [HttpGet("/export/TravelCDb/hotelcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/hotelfacilities/csv")]
        [HttpGet("/export/TravelCDb/hotelfacilities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelFacilitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelFacilities(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/hotelfacilities/excel")]
        [HttpGet("/export/TravelCDb/hotelfacilities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelFacilitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelFacilities(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/hotelfacilitycategories/csv")]
        [HttpGet("/export/TravelCDb/hotelfacilitycategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelFacilityCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelFacilityCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/hotelfacilitycategories/excel")]
        [HttpGet("/export/TravelCDb/hotelfacilitycategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelFacilityCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelFacilityCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/hotelpresentations/csv")]
        [HttpGet("/export/TravelCDb/hotelpresentations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelPresentationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelPresentations(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/hotelpresentations/excel")]
        [HttpGet("/export/TravelCDb/hotelpresentations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelPresentationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelPresentations(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/hotels/csv")]
        [HttpGet("/export/TravelCDb/hotels/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotels(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/hotels/excel")]
        [HttpGet("/export/TravelCDb/hotels/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotels(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/invoicetypes/csv")]
        [HttpGet("/export/TravelCDb/invoicetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportInvoiceTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetInvoiceTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/invoicetypes/excel")]
        [HttpGet("/export/TravelCDb/invoicetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportInvoiceTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetInvoiceTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/manuelregistrations/csv")]
        [HttpGet("/export/TravelCDb/manuelregistrations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportManuelRegistrationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetManuelRegistrations(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/manuelregistrations/excel")]
        [HttpGet("/export/TravelCDb/manuelregistrations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportManuelRegistrationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetManuelRegistrations(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/micrositeapiproviders/csv")]
        [HttpGet("/export/TravelCDb/micrositeapiproviders/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMicroSiteApiProvidersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMicroSiteApiProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/micrositeapiproviders/excel")]
        [HttpGet("/export/TravelCDb/micrositeapiproviders/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMicroSiteApiProvidersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMicroSiteApiProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/micrositecountries/csv")]
        [HttpGet("/export/TravelCDb/micrositecountries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMicrositeCountriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMicrositeCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/micrositecountries/excel")]
        [HttpGet("/export/TravelCDb/micrositecountries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMicrositeCountriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMicrositeCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/micrositecountriesfraudrisks/csv")]
        [HttpGet("/export/TravelCDb/micrositecountriesfraudrisks/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMicroSiteCountriesFraudRisksToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMicroSiteCountriesFraudRisks(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/micrositecountriesfraudrisks/excel")]
        [HttpGet("/export/TravelCDb/micrositecountriesfraudrisks/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMicroSiteCountriesFraudRisksToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMicroSiteCountriesFraudRisks(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/micrositeinvoices/csv")]
        [HttpGet("/export/TravelCDb/micrositeinvoices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMicroSiteInvoicesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMicroSiteInvoices(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/micrositeinvoices/excel")]
        [HttpGet("/export/TravelCDb/micrositeinvoices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMicroSiteInvoicesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMicroSiteInvoices(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/microsites/csv")]
        [HttpGet("/export/TravelCDb/microsites/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMicroSitesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMicroSites(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/microsites/excel")]
        [HttpGet("/export/TravelCDb/microsites/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMicroSitesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMicroSites(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/producttypes/csv")]
        [HttpGet("/export/TravelCDb/producttypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProductTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProductTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/producttypes/excel")]
        [HttpGet("/export/TravelCDb/producttypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProductTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProductTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/rooms/csv")]
        [HttpGet("/export/TravelCDb/rooms/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRooms(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/rooms/excel")]
        [HttpGet("/export/TravelCDb/rooms/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRooms(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/roomsselectedhotels/csv")]
        [HttpGet("/export/TravelCDb/roomsselectedhotels/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomsSelectedHotelsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRoomsSelectedHotels(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/roomsselectedhotels/excel")]
        [HttpGet("/export/TravelCDb/roomsselectedhotels/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomsSelectedHotelsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRoomsSelectedHotels(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/status/csv")]
        [HttpGet("/export/TravelCDb/status/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportStatusToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetStatus(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/status/excel")]
        [HttpGet("/export/TravelCDb/status/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportStatusToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetStatus(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/languages/csv")]
        [HttpGet("/export/TravelCDb/languages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/TravelCDb/languages/excel")]
        [HttpGet("/export/TravelCDb/languages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLanguages(), Request.Query), fileName);
        }
    }
}
