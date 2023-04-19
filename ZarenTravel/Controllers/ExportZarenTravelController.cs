using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ZarenTravel.Controllers;
using ZarenTravelBO.Data;

namespace ZarenTravelBO.Controllers
{
    public partial class ExportZarenTravelController : ExportController
    {
        private readonly ZarenTravelContext context;
        private readonly ZarenTravelService service;

        public ExportZarenTravelController(ZarenTravelContext context, ZarenTravelService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/ZarenTravel/agencies/csv")]
        [HttpGet("/export/ZarenTravel/agencies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgenciesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencies(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/agencies/excel")]
        [HttpGet("/export/ZarenTravel/agencies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgenciesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencies(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/agencygroups/csv")]
        [HttpGet("/export/ZarenTravel/agencygroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyGroupsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/agencygroups/excel")]
        [HttpGet("/export/ZarenTravel/agencygroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyGroupsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/agentinformations/csv")]
        [HttpGet("/export/ZarenTravel/agentinformations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgentInformationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgentInformations(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/agentinformations/excel")]
        [HttpGet("/export/ZarenTravel/agentinformations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgentInformationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgentInformations(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/airextras/csv")]
        [HttpGet("/export/ZarenTravel/airextras/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAirExtrasToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAirExtras(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/airextras/excel")]
        [HttpGet("/export/ZarenTravel/airextras/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAirExtrasToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAirExtras(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/airlines/csv")]
        [HttpGet("/export/ZarenTravel/airlines/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAirlinesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAirlines(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/airlines/excel")]
        [HttpGet("/export/ZarenTravel/airlines/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAirlinesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAirlines(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/airports/csv")]
        [HttpGet("/export/ZarenTravel/airports/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAirportsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAirports(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/airports/excel")]
        [HttpGet("/export/ZarenTravel/airports/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAirportsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAirports(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/airs/csv")]
        [HttpGet("/export/ZarenTravel/airs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAirsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAirs(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/airs/excel")]
        [HttpGet("/export/ZarenTravel/airs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAirsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAirs(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/airsegments/csv")]
        [HttpGet("/export/ZarenTravel/airsegments/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAirSegmentsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAirSegments(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/airsegments/excel")]
        [HttpGet("/export/ZarenTravel/airsegments/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAirSegmentsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAirSegments(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/apis/csv")]
        [HttpGet("/export/ZarenTravel/apis/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetApis(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/apis/excel")]
        [HttpGet("/export/ZarenTravel/apis/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetApis(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/authorizationtemplates/csv")]
        [HttpGet("/export/ZarenTravel/authorizationtemplates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuthorizationTemplatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuthorizationTemplates(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/authorizationtemplates/excel")]
        [HttpGet("/export/ZarenTravel/authorizationtemplates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuthorizationTemplatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuthorizationTemplates(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/autocompletes/csv")]
        [HttpGet("/export/ZarenTravel/autocompletes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompletesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAutoCompletes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/autocompletes/excel")]
        [HttpGet("/export/ZarenTravel/autocompletes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompletesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAutoCompletes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/autocompletetypes/csv")]
        [HttpGet("/export/ZarenTravel/autocompletetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompleteTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAutoCompleteTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/autocompletetypes/excel")]
        [HttpGet("/export/ZarenTravel/autocompletetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompleteTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAutoCompleteTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/banners/csv")]
        [HttpGet("/export/ZarenTravel/banners/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBannersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBanners(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/banners/excel")]
        [HttpGet("/export/ZarenTravel/banners/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBannersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBanners(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/boardtypelanguages/csv")]
        [HttpGet("/export/ZarenTravel/boardtypelanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBoardTypeLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBoardTypeLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/boardtypelanguages/excel")]
        [HttpGet("/export/ZarenTravel/boardtypelanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBoardTypeLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBoardTypeLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/boardtypes/csv")]
        [HttpGet("/export/ZarenTravel/boardtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBoardTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBoardTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/boardtypes/excel")]
        [HttpGet("/export/ZarenTravel/boardtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBoardTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBoardTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/bookingdeals/csv")]
        [HttpGet("/export/ZarenTravel/bookingdeals/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBookingDealsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBookingDeals(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/bookingdeals/excel")]
        [HttpGet("/export/ZarenTravel/bookingdeals/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBookingDealsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBookingDeals(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/bookingrooms/csv")]
        [HttpGet("/export/ZarenTravel/bookingrooms/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBookingRoomsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBookingRooms(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/bookingrooms/excel")]
        [HttpGet("/export/ZarenTravel/bookingrooms/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBookingRoomsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBookingRooms(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/bookings/csv")]
        [HttpGet("/export/ZarenTravel/bookings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBookingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBookings(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/bookings/excel")]
        [HttpGet("/export/ZarenTravel/bookings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBookingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBookings(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/brokers/csv")]
        [HttpGet("/export/ZarenTravel/brokers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBrokersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBrokers(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/brokers/excel")]
        [HttpGet("/export/ZarenTravel/brokers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBrokersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBrokers(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/buyrooms/csv")]
        [HttpGet("/export/ZarenTravel/buyrooms/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBuyRoomsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBuyRooms(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/buyrooms/excel")]
        [HttpGet("/export/ZarenTravel/buyrooms/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBuyRoomsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBuyRooms(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/cancelationlanguages/csv")]
        [HttpGet("/export/ZarenTravel/cancelationlanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCancelationLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCancelationLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/cancelationlanguages/excel")]
        [HttpGet("/export/ZarenTravel/cancelationlanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCancelationLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCancelationLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/cancellationrules/csv")]
        [HttpGet("/export/ZarenTravel/cancellationrules/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCancellationRulesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCancellationRules(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/cancellationrules/excel")]
        [HttpGet("/export/ZarenTravel/cancellationrules/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCancellationRulesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCancellationRules(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/cancellationseasons/csv")]
        [HttpGet("/export/ZarenTravel/cancellationseasons/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCancellationSeasonsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCancellationSeasons(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/cancellationseasons/excel")]
        [HttpGet("/export/ZarenTravel/cancellationseasons/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCancellationSeasonsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCancellationSeasons(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/carrentals/csv")]
        [HttpGet("/export/ZarenTravel/carrentals/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCarRentalsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCarRentals(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/carrentals/excel")]
        [HttpGet("/export/ZarenTravel/carrentals/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCarRentalsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCarRentals(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/carrents/csv")]
        [HttpGet("/export/ZarenTravel/carrents/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCarRentsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCarRents(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/carrents/excel")]
        [HttpGet("/export/ZarenTravel/carrents/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCarRentsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCarRents(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/cartypes/csv")]
        [HttpGet("/export/ZarenTravel/cartypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCarTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCarTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/cartypes/excel")]
        [HttpGet("/export/ZarenTravel/cartypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCarTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCarTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/cities/csv")]
        [HttpGet("/export/ZarenTravel/cities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCities(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/cities/excel")]
        [HttpGet("/export/ZarenTravel/cities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCities(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/citymodels/csv")]
        [HttpGet("/export/ZarenTravel/citymodels/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCityModelsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCityModels(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/citymodels/excel")]
        [HttpGet("/export/ZarenTravel/citymodels/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCityModelsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCityModels(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/companies/csv")]
        [HttpGet("/export/ZarenTravel/companies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCompaniesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCompanies(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/companies/excel")]
        [HttpGet("/export/ZarenTravel/companies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCompaniesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCompanies(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/contacts/csv")]
        [HttpGet("/export/ZarenTravel/contacts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportContactsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetContacts(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/contacts/excel")]
        [HttpGet("/export/ZarenTravel/contacts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportContactsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetContacts(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/countries/csv")]
        [HttpGet("/export/ZarenTravel/countries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/countries/excel")]
        [HttpGet("/export/ZarenTravel/countries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/currencies/csv")]
        [HttpGet("/export/ZarenTravel/currencies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrenciesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCurrencies(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/currencies/excel")]
        [HttpGet("/export/ZarenTravel/currencies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrenciesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCurrencies(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/customerinformations/csv")]
        [HttpGet("/export/ZarenTravel/customerinformations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCustomerInformationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCustomerInformations(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/customerinformations/excel")]
        [HttpGet("/export/ZarenTravel/customerinformations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCustomerInformationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCustomerInformations(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/databasecolumns/csv")]
        [HttpGet("/export/ZarenTravel/databasecolumns/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDatabaseColumnsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDatabaseColumns(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/databasecolumns/excel")]
        [HttpGet("/export/ZarenTravel/databasecolumns/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDatabaseColumnsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDatabaseColumns(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/databasetables/csv")]
        [HttpGet("/export/ZarenTravel/databasetables/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDatabaseTablesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDatabaseTables(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/databasetables/excel")]
        [HttpGet("/export/ZarenTravel/databasetables/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDatabaseTablesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDatabaseTables(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/databasevaluetypes/csv")]
        [HttpGet("/export/ZarenTravel/databasevaluetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDatabaseValueTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDatabaseValueTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/databasevaluetypes/excel")]
        [HttpGet("/export/ZarenTravel/databasevaluetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDatabaseValueTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDatabaseValueTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/datatablecmsinputtypes/csv")]
        [HttpGet("/export/ZarenTravel/datatablecmsinputtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDatatableCmsInputTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDatatableCmsInputTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/datatablecmsinputtypes/excel")]
        [HttpGet("/export/ZarenTravel/datatablecmsinputtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDatatableCmsInputTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDatatableCmsInputTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/deals/csv")]
        [HttpGet("/export/ZarenTravel/deals/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDealsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDeals(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/deals/excel")]
        [HttpGet("/export/ZarenTravel/deals/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDealsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDeals(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/dealtypelanguages/csv")]
        [HttpGet("/export/ZarenTravel/dealtypelanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDealTypeLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDealTypeLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/dealtypelanguages/excel")]
        [HttpGet("/export/ZarenTravel/dealtypelanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDealTypeLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDealTypeLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/dealtypes/csv")]
        [HttpGet("/export/ZarenTravel/dealtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDealTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDealTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/dealtypes/excel")]
        [HttpGet("/export/ZarenTravel/dealtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDealTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDealTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/exchangerates/csv")]
        [HttpGet("/export/ZarenTravel/exchangerates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportExchangeRatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetExchangeRates(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/exchangerates/excel")]
        [HttpGet("/export/ZarenTravel/exchangerates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportExchangeRatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetExchangeRates(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/extensions/csv")]
        [HttpGet("/export/ZarenTravel/extensions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportExtensionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetExtensions(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/extensions/excel")]
        [HttpGet("/export/ZarenTravel/extensions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportExtensionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetExtensions(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/extrastypes/csv")]
        [HttpGet("/export/ZarenTravel/extrastypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportExtrasTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetExtrasTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/extrastypes/excel")]
        [HttpGet("/export/ZarenTravel/extrastypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportExtrasTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetExtrasTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/facilities/csv")]
        [HttpGet("/export/ZarenTravel/facilities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFacilitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFacilities(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/facilities/excel")]
        [HttpGet("/export/ZarenTravel/facilities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFacilitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFacilities(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/facilitieshotels/csv")]
        [HttpGet("/export/ZarenTravel/facilitieshotels/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFacilitiesHotelsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFacilitiesHotels(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/facilitieshotels/excel")]
        [HttpGet("/export/ZarenTravel/facilitieshotels/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFacilitiesHotelsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFacilitiesHotels(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/facilitylanguages/csv")]
        [HttpGet("/export/ZarenTravel/facilitylanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFacilityLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFacilityLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/facilitylanguages/excel")]
        [HttpGet("/export/ZarenTravel/facilitylanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFacilityLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFacilityLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/fieldstypes/csv")]
        [HttpGet("/export/ZarenTravel/fieldstypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/fieldstypes/excel")]
        [HttpGet("/export/ZarenTravel/fieldstypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/headercolors/csv")]
        [HttpGet("/export/ZarenTravel/headercolors/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHeaderColorsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHeaderColors(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/headercolors/excel")]
        [HttpGet("/export/ZarenTravel/headercolors/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHeaderColorsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHeaderColors(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelagencymarkups/csv")]
        [HttpGet("/export/ZarenTravel/hotelagencymarkups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelAgencyMarkupsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelAgencyMarkups(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelagencymarkups/excel")]
        [HttpGet("/export/ZarenTravel/hotelagencymarkups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelAgencyMarkupsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelAgencyMarkups(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelbuyroomallotments/csv")]
        [HttpGet("/export/ZarenTravel/hotelbuyroomallotments/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelBuyRoomAllotmentsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelBuyRoomAllotments(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelbuyroomallotments/excel")]
        [HttpGet("/export/ZarenTravel/hotelbuyroomallotments/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelBuyRoomAllotmentsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelBuyRoomAllotments(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelbuyrooms/csv")]
        [HttpGet("/export/ZarenTravel/hotelbuyrooms/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelBuyRoomsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelBuyRooms(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelbuyrooms/excel")]
        [HttpGet("/export/ZarenTravel/hotelbuyrooms/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelBuyRoomsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelBuyRooms(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelchains/csv")]
        [HttpGet("/export/ZarenTravel/hotelchains/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelChainsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelChains(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelchains/excel")]
        [HttpGet("/export/ZarenTravel/hotelchains/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelChainsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelChains(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hoteldescriptions/csv")]
        [HttpGet("/export/ZarenTravel/hoteldescriptions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelDescriptionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelDescriptions(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hoteldescriptions/excel")]
        [HttpGet("/export/ZarenTravel/hoteldescriptions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelDescriptionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelDescriptions(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelphotolanguages/csv")]
        [HttpGet("/export/ZarenTravel/hotelphotolanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelPhotoLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelPhotoLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelphotolanguages/excel")]
        [HttpGet("/export/ZarenTravel/hotelphotolanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelPhotoLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelPhotoLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelphotos/csv")]
        [HttpGet("/export/ZarenTravel/hotelphotos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelPhotosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelPhotos(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelphotos/excel")]
        [HttpGet("/export/ZarenTravel/hotelphotos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelPhotosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelPhotos(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelroomdailyprices/csv")]
        [HttpGet("/export/ZarenTravel/hotelroomdailyprices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelRoomDailyPricesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelRoomDailyPrices(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelroomdailyprices/excel")]
        [HttpGet("/export/ZarenTravel/hotelroomdailyprices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelRoomDailyPricesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelRoomDailyPrices(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelroomlanguages/csv")]
        [HttpGet("/export/ZarenTravel/hotelroomlanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelRoomLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelRoomLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelroomlanguages/excel")]
        [HttpGet("/export/ZarenTravel/hotelroomlanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelRoomLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelRoomLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelrooms/csv")]
        [HttpGet("/export/ZarenTravel/hotelrooms/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelRoomsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelRooms(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotelrooms/excel")]
        [HttpGet("/export/ZarenTravel/hotelrooms/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelRoomsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelRooms(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotels/csv")]
        [HttpGet("/export/ZarenTravel/hotels/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotels(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hotels/excel")]
        [HttpGet("/export/ZarenTravel/hotels/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotels(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hoteltypelanguages/csv")]
        [HttpGet("/export/ZarenTravel/hoteltypelanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelTypeLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelTypeLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hoteltypelanguages/excel")]
        [HttpGet("/export/ZarenTravel/hoteltypelanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelTypeLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelTypeLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hoteltypes/csv")]
        [HttpGet("/export/ZarenTravel/hoteltypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/hoteltypes/excel")]
        [HttpGet("/export/ZarenTravel/hoteltypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/languages/csv")]
        [HttpGet("/export/ZarenTravel/languages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/languages/excel")]
        [HttpGet("/export/ZarenTravel/languages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/logpermissions/csv")]
        [HttpGet("/export/ZarenTravel/logpermissions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLogPermissionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLogPermissions(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/logpermissions/excel")]
        [HttpGet("/export/ZarenTravel/logpermissions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLogPermissionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLogPermissions(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/logs/csv")]
        [HttpGet("/export/ZarenTravel/logs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLogsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLogs(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/logs/excel")]
        [HttpGet("/export/ZarenTravel/logs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLogsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLogs(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/menus/csv")]
        [HttpGet("/export/ZarenTravel/menus/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMenusToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMenus(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/menus/excel")]
        [HttpGet("/export/ZarenTravel/menus/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMenusToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMenus(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/ogseos/csv")]
        [HttpGet("/export/ZarenTravel/ogseos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOgSeosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOgSeos(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/ogseos/excel")]
        [HttpGet("/export/ZarenTravel/ogseos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOgSeosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOgSeos(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/pagecontents/csv")]
        [HttpGet("/export/ZarenTravel/pagecontents/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPageContentsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPageContents(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/pagecontents/excel")]
        [HttpGet("/export/ZarenTravel/pagecontents/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPageContentsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPageContents(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/pagetypes/csv")]
        [HttpGet("/export/ZarenTravel/pagetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPageTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPageTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/pagetypes/excel")]
        [HttpGet("/export/ZarenTravel/pagetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPageTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPageTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/passengerinformations/csv")]
        [HttpGet("/export/ZarenTravel/passengerinformations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPassengerInformationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPassengerInformations(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/passengerinformations/excel")]
        [HttpGet("/export/ZarenTravel/passengerinformations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPassengerInformationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPassengerInformations(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/passengers/csv")]
        [HttpGet("/export/ZarenTravel/passengers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPassengersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPassengers(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/passengers/excel")]
        [HttpGet("/export/ZarenTravel/passengers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPassengersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPassengers(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/pnrcustomfields/csv")]
        [HttpGet("/export/ZarenTravel/pnrcustomfields/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPnrCustomFieldsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPnrCustomFields(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/pnrcustomfields/excel")]
        [HttpGet("/export/ZarenTravel/pnrcustomfields/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPnrCustomFieldsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPnrCustomFields(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/pnrs/csv")]
        [HttpGet("/export/ZarenTravel/pnrs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPnRsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPnRs(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/pnrs/excel")]
        [HttpGet("/export/ZarenTravel/pnrs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPnRsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPnRs(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/possiblequeries/csv")]
        [HttpGet("/export/ZarenTravel/possiblequeries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPossibleQueriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPossibleQueries(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/possiblequeries/excel")]
        [HttpGet("/export/ZarenTravel/possiblequeries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPossibleQueriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPossibleQueries(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/providers/csv")]
        [HttpGet("/export/ZarenTravel/providers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProvidersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/providers/excel")]
        [HttpGet("/export/ZarenTravel/providers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProvidersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/proviences/csv")]
        [HttpGet("/export/ZarenTravel/proviences/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProviencesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProviences(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/proviences/excel")]
        [HttpGet("/export/ZarenTravel/proviences/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProviencesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProviences(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/regions/csv")]
        [HttpGet("/export/ZarenTravel/regions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRegionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRegions(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/regions/excel")]
        [HttpGet("/export/ZarenTravel/regions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRegionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRegions(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/reservationdetails/csv")]
        [HttpGet("/export/ZarenTravel/reservationdetails/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReservationDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReservationDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/reservationdetails/excel")]
        [HttpGet("/export/ZarenTravel/reservationdetails/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReservationDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReservationDetails(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/reservations/csv")]
        [HttpGet("/export/ZarenTravel/reservations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReservationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReservations(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/reservations/excel")]
        [HttpGet("/export/ZarenTravel/reservations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReservationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReservations(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/rooms/csv")]
        [HttpGet("/export/ZarenTravel/rooms/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRooms(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/rooms/excel")]
        [HttpGet("/export/ZarenTravel/rooms/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRooms(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/statuses/csv")]
        [HttpGet("/export/ZarenTravel/statuses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportStatusesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetStatuses(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/statuses/excel")]
        [HttpGet("/export/ZarenTravel/statuses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportStatusesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetStatuses(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/supplierbuyingdestinations/csv")]
        [HttpGet("/export/ZarenTravel/supplierbuyingdestinations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSupplierBuyingDestinationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSupplierBuyingDestinations(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/supplierbuyingdestinations/excel")]
        [HttpGet("/export/ZarenTravel/supplierbuyingdestinations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSupplierBuyingDestinationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSupplierBuyingDestinations(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/supplierfees/csv")]
        [HttpGet("/export/ZarenTravel/supplierfees/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSupplierFeesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSupplierFees(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/supplierfees/excel")]
        [HttpGet("/export/ZarenTravel/supplierfees/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSupplierFeesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSupplierFees(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/supplierproducttypes/csv")]
        [HttpGet("/export/ZarenTravel/supplierproducttypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSupplierProductTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSupplierProductTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/supplierproducttypes/excel")]
        [HttpGet("/export/ZarenTravel/supplierproducttypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSupplierProductTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSupplierProductTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/supplierregisteredproducts/csv")]
        [HttpGet("/export/ZarenTravel/supplierregisteredproducts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSupplierRegisteredProductsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSupplierRegisteredProducts(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/supplierregisteredproducts/excel")]
        [HttpGet("/export/ZarenTravel/supplierregisteredproducts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSupplierRegisteredProductsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSupplierRegisteredProducts(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/suppliers/csv")]
        [HttpGet("/export/ZarenTravel/suppliers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSuppliersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSuppliers(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/suppliers/excel")]
        [HttpGet("/export/ZarenTravel/suppliers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSuppliersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSuppliers(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/suppliersellingdestinations/csv")]
        [HttpGet("/export/ZarenTravel/suppliersellingdestinations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSupplierSellingDestinationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSupplierSellingDestinations(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/suppliersellingdestinations/excel")]
        [HttpGet("/export/ZarenTravel/suppliersellingdestinations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSupplierSellingDestinationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSupplierSellingDestinations(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/suppliertypes/csv")]
        [HttpGet("/export/ZarenTravel/suppliertypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSupplierTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSupplierTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/suppliertypes/excel")]
        [HttpGet("/export/ZarenTravel/suppliertypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSupplierTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSupplierTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/terminals/csv")]
        [HttpGet("/export/ZarenTravel/terminals/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTerminalsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTerminals(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/terminals/excel")]
        [HttpGet("/export/ZarenTravel/terminals/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTerminalsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTerminals(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/themestyles/csv")]
        [HttpGet("/export/ZarenTravel/themestyles/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportThemeStylesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetThemeStyles(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/themestyles/excel")]
        [HttpGet("/export/ZarenTravel/themestyles/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportThemeStylesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetThemeStyles(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/urls/csv")]
        [HttpGet("/export/ZarenTravel/urls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportUrlsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetUrls(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/urls/excel")]
        [HttpGet("/export/ZarenTravel/urls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportUrlsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetUrls(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/userpreferences/csv")]
        [HttpGet("/export/ZarenTravel/userpreferences/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportUserPreferencesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetUserPreferences(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/userpreferences/excel")]
        [HttpGet("/export/ZarenTravel/userpreferences/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportUserPreferencesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetUserPreferences(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/users/csv")]
        [HttpGet("/export/ZarenTravel/users/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportUsersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetUsers(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/users/excel")]
        [HttpGet("/export/ZarenTravel/users/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportUsersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetUsers(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/usertypes/csv")]
        [HttpGet("/export/ZarenTravel/usertypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportUserTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetUserTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/usertypes/excel")]
        [HttpGet("/export/ZarenTravel/usertypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportUserTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetUserTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/yesnos/csv")]
        [HttpGet("/export/ZarenTravel/yesnos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportYesNosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetYesNos(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/yesnos/excel")]
        [HttpGet("/export/ZarenTravel/yesnos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportYesNosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetYesNos(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/zones/csv")]
        [HttpGet("/export/ZarenTravel/zones/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportZonesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetZones(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/zones/excel")]
        [HttpGet("/export/ZarenTravel/zones/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportZonesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetZones(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/zonescities/csv")]
        [HttpGet("/export/ZarenTravel/zonescities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportZonesCitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetZonesCities(), Request.Query), fileName);
        }

        [HttpGet("/export/ZarenTravel/zonescities/excel")]
        [HttpGet("/export/ZarenTravel/zonescities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportZonesCitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetZonesCities(), Request.Query), fileName);
        }
    }
}
