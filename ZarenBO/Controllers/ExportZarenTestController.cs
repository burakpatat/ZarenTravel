using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using ZarenTravelBO.Data;

namespace ZarenTravelBO.Controllers
{
    public partial class Exportzaren_testController : ExportController
    {
        private readonly zaren_testContext context;
        private readonly zaren_testService service;

        public Exportzaren_testController(zaren_testContext context, zaren_testService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/zaren_test/agencies/csv")]
        [HttpGet("/export/zaren_test/agencies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgenciesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencies(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencies/excel")]
        [HttpGet("/export/zaren_test/agencies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgenciesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencies(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycmsdevices/csv")]
        [HttpGet("/export/zaren_test/agencycmsdevices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCmsDevicesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyCmsDevices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycmsdevices/excel")]
        [HttpGet("/export/zaren_test/agencycmsdevices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCmsDevicesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyCmsDevices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycmssectiontypes/csv")]
        [HttpGet("/export/zaren_test/agencycmssectiontypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCmsSectionTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyCmsSectionTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycmssectiontypes/excel")]
        [HttpGet("/export/zaren_test/agencycmssectiontypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCmsSectionTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyCmsSectionTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycmssocialmediaurls/csv")]
        [HttpGet("/export/zaren_test/agencycmssocialmediaurls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCmsSocialMediaUrlsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyCmsSocialMediaUrls(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycmssocialmediaurls/excel")]
        [HttpGet("/export/zaren_test/agencycmssocialmediaurls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCmsSocialMediaUrlsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyCmsSocialMediaUrls(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycmsthemes/csv")]
        [HttpGet("/export/zaren_test/agencycmsthemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCmsThemesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyCmsThemes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycmsthemes/excel")]
        [HttpGet("/export/zaren_test/agencycmsthemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCmsThemesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyCmsThemes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycommisions/csv")]
        [HttpGet("/export/zaren_test/agencycommisions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCommisionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyCommisions(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycommisions/excel")]
        [HttpGet("/export/zaren_test/agencycommisions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCommisionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyCommisions(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractsclosedtours/csv")]
        [HttpGet("/export/zaren_test/agencycontractsclosedtours/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsClosedToursToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsClosedTours(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractsclosedtours/excel")]
        [HttpGet("/export/zaren_test/agencycontractsclosedtours/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsClosedToursToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsClosedTours(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractshotelcategories/csv")]
        [HttpGet("/export/zaren_test/agencycontractshotelcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsHotelCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractshotelcategories/excel")]
        [HttpGet("/export/zaren_test/agencycontractshotelcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsHotelCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractshotelinformations/csv")]
        [HttpGet("/export/zaren_test/agencycontractshotelinformations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelInformationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsHotelInformations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractshotelinformations/excel")]
        [HttpGet("/export/zaren_test/agencycontractshotelinformations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelInformationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsHotelInformations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractshotelinformationimages/csv")]
        [HttpGet("/export/zaren_test/agencycontractshotelinformationimages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelInformationImagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsHotelInformationImages(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractshotelinformationimages/excel")]
        [HttpGet("/export/zaren_test/agencycontractshotelinformationimages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelInformationImagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsHotelInformationImages(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractshotelsconfigurations/csv")]
        [HttpGet("/export/zaren_test/agencycontractshotelsconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelsConfigurationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsHotelsConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractshotelsconfigurations/excel")]
        [HttpGet("/export/zaren_test/agencycontractshotelsconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelsConfigurationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsHotelsConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractshotelsconfigurationdays/csv")]
        [HttpGet("/export/zaren_test/agencycontractshotelsconfigurationdays/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelsConfigurationDaysToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsHotelsConfigurationDays(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractshotelsconfigurationdays/excel")]
        [HttpGet("/export/zaren_test/agencycontractshotelsconfigurationdays/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelsConfigurationDaysToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsHotelsConfigurationDays(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractshotelsmenus/csv")]
        [HttpGet("/export/zaren_test/agencycontractshotelsmenus/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelsMenusToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsHotelsMenus(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractshotelsmenus/excel")]
        [HttpGet("/export/zaren_test/agencycontractshotelsmenus/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelsMenusToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsHotelsMenus(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractsinsurancebasicdata/csv")]
        [HttpGet("/export/zaren_test/agencycontractsinsurancebasicdata/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsInsuranceBasicDataToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsInsuranceBasicData(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractsinsurancebasicdata/excel")]
        [HttpGet("/export/zaren_test/agencycontractsinsurancebasicdata/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsInsuranceBasicDataToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsInsuranceBasicData(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractsinsuranceselectedlanguages/csv")]
        [HttpGet("/export/zaren_test/agencycontractsinsuranceselectedlanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsInsuranceSelectedLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsInsuranceSelectedLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractsinsuranceselectedlanguages/excel")]
        [HttpGet("/export/zaren_test/agencycontractsinsuranceselectedlanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsInsuranceSelectedLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsInsuranceSelectedLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractsinsuranceselectedproducttypes/csv")]
        [HttpGet("/export/zaren_test/agencycontractsinsuranceselectedproducttypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsInsuranceSelectedProductTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsInsuranceSelectedProductTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractsinsuranceselectedproducttypes/excel")]
        [HttpGet("/export/zaren_test/agencycontractsinsuranceselectedproducttypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsInsuranceSelectedProductTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsInsuranceSelectedProductTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractsinsurancetypes/csv")]
        [HttpGet("/export/zaren_test/agencycontractsinsurancetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsInsuranceTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsInsuranceTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractsinsurancetypes/excel")]
        [HttpGet("/export/zaren_test/agencycontractsinsurancetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsInsuranceTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsInsuranceTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycreditdeposits/csv")]
        [HttpGet("/export/zaren_test/agencycreditdeposits/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCreditDepositsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyCreditDeposits(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycreditdeposits/excel")]
        [HttpGet("/export/zaren_test/agencycreditdeposits/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCreditDepositsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyCreditDeposits(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymanagers/csv")]
        [HttpGet("/export/zaren_test/agencymanagers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyManagersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyManagers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymanagers/excel")]
        [HttpGet("/export/zaren_test/agencymanagers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyManagersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyManagers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositeapiproductproviders/csv")]
        [HttpGet("/export/zaren_test/agencymicrositeapiproductproviders/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteApiProductProvidersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteApiProductProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositeapiproductproviders/excel")]
        [HttpGet("/export/zaren_test/agencymicrositeapiproductproviders/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteApiProductProvidersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteApiProductProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositedesigns/csv")]
        [HttpGet("/export/zaren_test/agencymicrositedesigns/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteDesignsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteDesigns(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositedesigns/excel")]
        [HttpGet("/export/zaren_test/agencymicrositedesigns/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteDesignsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteDesigns(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositedomainlanguagesettings/csv")]
        [HttpGet("/export/zaren_test/agencymicrositedomainlanguagesettings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteDomainLanguageSettingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteDomainLanguageSettings(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositedomainlanguagesettings/excel")]
        [HttpGet("/export/zaren_test/agencymicrositedomainlanguagesettings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteDomainLanguageSettingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteDomainLanguageSettings(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositedomains/csv")]
        [HttpGet("/export/zaren_test/agencymicrositedomains/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteDomainsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteDomains(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositedomains/excel")]
        [HttpGet("/export/zaren_test/agencymicrositedomains/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteDomainsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteDomains(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositepaymentproviders/csv")]
        [HttpGet("/export/zaren_test/agencymicrositepaymentproviders/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSitePaymentProvidersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSitePaymentProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositepaymentproviders/excel")]
        [HttpGet("/export/zaren_test/agencymicrositepaymentproviders/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSitePaymentProvidersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSitePaymentProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositeproperties/csv")]
        [HttpGet("/export/zaren_test/agencymicrositeproperties/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSitePropertiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteProperties(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositeproperties/excel")]
        [HttpGet("/export/zaren_test/agencymicrositeproperties/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSitePropertiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteProperties(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrosites/csv")]
        [HttpGet("/export/zaren_test/agencymicrosites/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSitesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSites(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrosites/excel")]
        [HttpGet("/export/zaren_test/agencymicrosites/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSitesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSites(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingpassengerdata/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingpassengerdata/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingPassengerDataToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingPassengerData(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingpassengerdata/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingpassengerdata/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingPassengerDataToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingPassengerData(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsaccommodationsearchresults/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsaccommodationsearchresults/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsAccommodationSearchResultsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsAccommodationSearchResults(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsaccommodationsearchresults/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsaccommodationsearchresults/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsAccommodationSearchResultsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsAccommodationSearchResults(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsbookingprocesses/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsbookingprocesses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsBookingProcessesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsBookingProcesses(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsbookingprocesses/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsbookingprocesses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsBookingProcessesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsBookingProcesses(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsbookingreplicatormodes/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsbookingreplicatormodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsBookingReplicatorModesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsBookingReplicatorModes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsbookingreplicatormodes/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsbookingreplicatormodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsBookingReplicatorModesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsBookingReplicatorModes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsemailvouchers/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsemailvouchers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsEmailVouchersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsEmailVouchers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsemailvouchers/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsemailvouchers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsEmailVouchersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsEmailVouchers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsenablemultidays/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsenablemultidays/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsEnableMultiDaysToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsEnableMultiDays(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsenablemultidays/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsenablemultidays/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsEnableMultiDaysToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsEnableMultiDays(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsgenerals/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsgenerals/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsGeneralsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsGenerals(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsgenerals/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsgenerals/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsGeneralsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsGenerals(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingshelpsupports/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingshelpsupports/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsHelpSupportsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsHelpSupports(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingshelpsupports/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingshelpsupports/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsHelpSupportsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsHelpSupports(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsinvoices/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsinvoices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsInvoicesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsInvoices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsinvoices/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsinvoices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsInvoicesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsInvoices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsothers/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsothers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsOthersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsOthers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsothers/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsothers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsOthersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsOthers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingspaymetoptions/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingspaymetoptions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsPaymetOptionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsPaymetOptions(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingspaymetoptions/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingspaymetoptions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsPaymetOptionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsPaymetOptions(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsrequestinvoices/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsrequestinvoices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsRequestInvoicesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsRequestInvoices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsrequestinvoices/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsrequestinvoices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsRequestInvoicesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsRequestInvoices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsrequiredpassengers/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsrequiredpassengers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsRequiredPassengersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsRequiredPassengers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingsrequiredpassengers/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingsrequiredpassengers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsRequiredPassengersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsRequiredPassengers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingssearchengines/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingssearchengines/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsSearchEnginesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsSearchEngines(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingssearchengines/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingssearchengines/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsSearchEnginesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsSearchEngines(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingssearchsettings/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingssearchsettings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsSearchSettingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsSearchSettings(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingssearchsettings/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingssearchsettings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsSearchSettingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsSearchSettings(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingssorttypes/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingssorttypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsSortTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsSortTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingssorttypes/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingssorttypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsSortTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsSortTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingstermsconditions/csv")]
        [HttpGet("/export/zaren_test/agencymicrositesettingstermsconditions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsTermsConditionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsTermsConditions(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositesettingstermsconditions/excel")]
        [HttpGet("/export/zaren_test/agencymicrositesettingstermsconditions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsTermsConditionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsTermsConditions(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositessettingsemailconfigurations/csv")]
        [HttpGet("/export/zaren_test/agencymicrositessettingsemailconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSitesSettingsEmailConfigurationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSitesSettingsEmailConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencymicrositessettingsemailconfigurations/excel")]
        [HttpGet("/export/zaren_test/agencymicrositessettingsemailconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSitesSettingsEmailConfigurationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSitesSettingsEmailConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencysupplementcommissions/csv")]
        [HttpGet("/export/zaren_test/agencysupplementcommissions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencySupplementCommissionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencySupplementCommissions(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencysupplementcommissions/excel")]
        [HttpGet("/export/zaren_test/agencysupplementcommissions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencySupplementCommissionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencySupplementCommissions(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencyusers/csv")]
        [HttpGet("/export/zaren_test/agencyusers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyUsersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyUsers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencyusers/excel")]
        [HttpGet("/export/zaren_test/agencyusers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyUsersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyUsers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/apiproducts/csv")]
        [HttpGet("/export/zaren_test/apiproducts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApiProductsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetApiProducts(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/apiproducts/excel")]
        [HttpGet("/export/zaren_test/apiproducts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApiProductsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetApiProducts(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/apiresults/csv")]
        [HttpGet("/export/zaren_test/apiresults/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApiResultsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetApiResults(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/apiresults/excel")]
        [HttpGet("/export/zaren_test/apiresults/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApiResultsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetApiResults(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/autocompletes/csv")]
        [HttpGet("/export/zaren_test/autocompletes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompletesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAutoCompletes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/autocompletes/excel")]
        [HttpGet("/export/zaren_test/autocompletes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompletesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAutoCompletes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/autocompletetypes/csv")]
        [HttpGet("/export/zaren_test/autocompletetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompleteTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAutoCompleteTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/autocompletetypes/excel")]
        [HttpGet("/export/zaren_test/autocompletetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompleteTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAutoCompleteTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/boards/csv")]
        [HttpGet("/export/zaren_test/boards/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBoardsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBoards(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/boards/excel")]
        [HttpGet("/export/zaren_test/boards/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBoardsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBoards(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/cancellationpolicies/csv")]
        [HttpGet("/export/zaren_test/cancellationpolicies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCancellationPoliciesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCancellationPolicies(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/cancellationpolicies/excel")]
        [HttpGet("/export/zaren_test/cancellationpolicies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCancellationPoliciesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCancellationPolicies(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/cities/csv")]
        [HttpGet("/export/zaren_test/cities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCities(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/cities/excel")]
        [HttpGet("/export/zaren_test/cities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCities(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/countries/csv")]
        [HttpGet("/export/zaren_test/countries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/countries/excel")]
        [HttpGet("/export/zaren_test/countries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/country1s/csv")]
        [HttpGet("/export/zaren_test/country1s/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountry1SToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountry1S(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/country1s/excel")]
        [HttpGet("/export/zaren_test/country1s/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountry1SToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountry1S(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/currencies/csv")]
        [HttpGet("/export/zaren_test/currencies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrenciesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCurrencies(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/currencies/excel")]
        [HttpGet("/export/zaren_test/currencies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrenciesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCurrencies(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/currency1s/csv")]
        [HttpGet("/export/zaren_test/currency1s/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrency1SToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCurrency1S(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/currency1s/excel")]
        [HttpGet("/export/zaren_test/currency1s/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrency1SToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCurrency1S(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/facilities/csv")]
        [HttpGet("/export/zaren_test/facilities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFacilitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFacilities(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/facilities/excel")]
        [HttpGet("/export/zaren_test/facilities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFacilitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFacilities(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/facilitiesselectedcategories/csv")]
        [HttpGet("/export/zaren_test/facilitiesselectedcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFacilitiesSelectedCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFacilitiesSelectedCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/facilitiesselectedcategories/excel")]
        [HttpGet("/export/zaren_test/facilitiesselectedcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFacilitiesSelectedCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFacilitiesSelectedCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/facilitycategories/csv")]
        [HttpGet("/export/zaren_test/facilitycategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFacilityCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFacilityCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/facilitycategories/excel")]
        [HttpGet("/export/zaren_test/facilitycategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFacilityCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFacilityCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/geolocations/csv")]
        [HttpGet("/export/zaren_test/geolocations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGeolocationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGeolocations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/geolocations/excel")]
        [HttpGet("/export/zaren_test/geolocations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGeolocationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGeolocations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/giatainfos/csv")]
        [HttpGet("/export/zaren_test/giatainfos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGiataInfosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGiataInfos(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/giatainfos/excel")]
        [HttpGet("/export/zaren_test/giatainfos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGiataInfosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGiataInfos(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/hotelboards/csv")]
        [HttpGet("/export/zaren_test/hotelboards/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelBoardsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelBoards(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/hotelboards/excel")]
        [HttpGet("/export/zaren_test/hotelboards/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelBoardsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelBoards(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/hotelcategories/csv")]
        [HttpGet("/export/zaren_test/hotelcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/hotelcategories/excel")]
        [HttpGet("/export/zaren_test/hotelcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/hoteloffers/csv")]
        [HttpGet("/export/zaren_test/hoteloffers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelOffersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelOffers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/hoteloffers/excel")]
        [HttpGet("/export/zaren_test/hoteloffers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelOffersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelOffers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/hotelpaymentplans/csv")]
        [HttpGet("/export/zaren_test/hotelpaymentplans/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelPaymentPlansToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelPaymentPlans(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/hotelpaymentplans/excel")]
        [HttpGet("/export/zaren_test/hotelpaymentplans/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelPaymentPlansToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelPaymentPlans(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/hotels/csv")]
        [HttpGet("/export/zaren_test/hotels/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotels(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/hotels/excel")]
        [HttpGet("/export/zaren_test/hotels/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotels(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/hotelseasons/csv")]
        [HttpGet("/export/zaren_test/hotelseasons/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelSeasonsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelSeasons(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/hotelseasons/excel")]
        [HttpGet("/export/zaren_test/hotelseasons/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelSeasonsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelSeasons(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/hotelselectedseasons/csv")]
        [HttpGet("/export/zaren_test/hotelselectedseasons/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelSelectedSeasonsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelSelectedSeasons(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/hotelselectedseasons/excel")]
        [HttpGet("/export/zaren_test/hotelselectedseasons/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelSelectedSeasonsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelSelectedSeasons(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/hotelthemes/csv")]
        [HttpGet("/export/zaren_test/hotelthemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelThemesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelThemes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/hotelthemes/excel")]
        [HttpGet("/export/zaren_test/hotelthemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelThemesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelThemes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/informations/csv")]
        [HttpGet("/export/zaren_test/informations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportInformationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetInformations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/informations/excel")]
        [HttpGet("/export/zaren_test/informations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportInformationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetInformations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/items/csv")]
        [HttpGet("/export/zaren_test/items/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportItemsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetItems(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/items/excel")]
        [HttpGet("/export/zaren_test/items/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportItemsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetItems(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/languages/csv")]
        [HttpGet("/export/zaren_test/languages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/languages/excel")]
        [HttpGet("/export/zaren_test/languages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/limittypes/csv")]
        [HttpGet("/export/zaren_test/limittypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLimitTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLimitTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/limittypes/excel")]
        [HttpGet("/export/zaren_test/limittypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLimitTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLimitTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/mediafiles/csv")]
        [HttpGet("/export/zaren_test/mediafiles/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMediaFilesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetMediaFiles(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/mediafiles/excel")]
        [HttpGet("/export/zaren_test/mediafiles/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportMediaFilesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetMediaFiles(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/offercancellationpolicies/csv")]
        [HttpGet("/export/zaren_test/offercancellationpolicies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOfferCancellationPoliciesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOfferCancellationPolicies(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/offercancellationpolicies/excel")]
        [HttpGet("/export/zaren_test/offercancellationpolicies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOfferCancellationPoliciesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOfferCancellationPolicies(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/offerpricebreakdowns/csv")]
        [HttpGet("/export/zaren_test/offerpricebreakdowns/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOfferPriceBreakDownsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOfferPriceBreakDowns(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/offerpricebreakdowns/excel")]
        [HttpGet("/export/zaren_test/offerpricebreakdowns/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOfferPriceBreakDownsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOfferPriceBreakDowns(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/offers/csv")]
        [HttpGet("/export/zaren_test/offers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOffersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetOffers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/offers/excel")]
        [HttpGet("/export/zaren_test/offers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportOffersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetOffers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/passengeramounts/csv")]
        [HttpGet("/export/zaren_test/passengeramounts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPassengerAmountsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPassengerAmounts(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/passengeramounts/excel")]
        [HttpGet("/export/zaren_test/passengeramounts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPassengerAmountsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPassengerAmounts(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/paymentplaninfos/csv")]
        [HttpGet("/export/zaren_test/paymentplaninfos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentPlanInfosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPaymentPlanInfos(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/paymentplaninfos/excel")]
        [HttpGet("/export/zaren_test/paymentplaninfos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentPlanInfosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPaymentPlanInfos(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/paymenttypes/csv")]
        [HttpGet("/export/zaren_test/paymenttypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPaymentTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/paymenttypes/excel")]
        [HttpGet("/export/zaren_test/paymenttypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPaymentTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/possiblequeries/csv")]
        [HttpGet("/export/zaren_test/possiblequeries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPossibleQueriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPossibleQueries(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/possiblequeries/excel")]
        [HttpGet("/export/zaren_test/possiblequeries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPossibleQueriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPossibleQueries(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/presentations/csv")]
        [HttpGet("/export/zaren_test/presentations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPresentationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPresentations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/presentations/excel")]
        [HttpGet("/export/zaren_test/presentations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPresentationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPresentations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/pricebreakdowns/csv")]
        [HttpGet("/export/zaren_test/pricebreakdowns/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPriceBreakDownsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPriceBreakDowns(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/pricebreakdowns/excel")]
        [HttpGet("/export/zaren_test/pricebreakdowns/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPriceBreakDownsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPriceBreakDowns(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/prices/csv")]
        [HttpGet("/export/zaren_test/prices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPricesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPrices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/prices/excel")]
        [HttpGet("/export/zaren_test/prices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPricesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPrices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/producttypes/csv")]
        [HttpGet("/export/zaren_test/producttypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProductTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProductTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/producttypes/excel")]
        [HttpGet("/export/zaren_test/producttypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProductTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProductTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/resources/csv")]
        [HttpGet("/export/zaren_test/resources/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportResourcesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetResources(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/resources/excel")]
        [HttpGet("/export/zaren_test/resources/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportResourcesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetResources(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/roomfacilities/csv")]
        [HttpGet("/export/zaren_test/roomfacilities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomFacilitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRoomFacilities(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/roomfacilities/excel")]
        [HttpGet("/export/zaren_test/roomfacilities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomFacilitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRoomFacilities(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/roominfofacilities/csv")]
        [HttpGet("/export/zaren_test/roominfofacilities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomInfoFacilitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRoomInfoFacilities(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/roominfofacilities/excel")]
        [HttpGet("/export/zaren_test/roominfofacilities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomInfoFacilitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRoomInfoFacilities(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/roominfos/csv")]
        [HttpGet("/export/zaren_test/roominfos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomInfosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRoomInfos(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/roominfos/excel")]
        [HttpGet("/export/zaren_test/roominfos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomInfosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRoomInfos(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/roominfosmediafiles/csv")]
        [HttpGet("/export/zaren_test/roominfosmediafiles/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomInfosMediaFilesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRoomInfosMediaFiles(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/roominfosmediafiles/excel")]
        [HttpGet("/export/zaren_test/roominfosmediafiles/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomInfosMediaFilesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRoomInfosMediaFiles(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/roommediafiles/csv")]
        [HttpGet("/export/zaren_test/roommediafiles/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomMediaFilesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRoomMediaFiles(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/roommediafiles/excel")]
        [HttpGet("/export/zaren_test/roommediafiles/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomMediaFilesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRoomMediaFiles(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/roompresentations/csv")]
        [HttpGet("/export/zaren_test/roompresentations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomPresentationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRoomPresentations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/roompresentations/excel")]
        [HttpGet("/export/zaren_test/roompresentations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomPresentationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRoomPresentations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/rooms/csv")]
        [HttpGet("/export/zaren_test/rooms/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRooms(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/rooms/excel")]
        [HttpGet("/export/zaren_test/rooms/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportRoomsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRooms(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/seasonmediafiles/csv")]
        [HttpGet("/export/zaren_test/seasonmediafiles/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSeasonMediaFilesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSeasonMediaFiles(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/seasonmediafiles/excel")]
        [HttpGet("/export/zaren_test/seasonmediafiles/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSeasonMediaFilesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSeasonMediaFiles(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/seasons/csv")]
        [HttpGet("/export/zaren_test/seasons/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSeasonsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSeasons(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/seasons/excel")]
        [HttpGet("/export/zaren_test/seasons/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSeasonsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSeasons(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/seasontextcategories/csv")]
        [HttpGet("/export/zaren_test/seasontextcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSeasonTextCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSeasonTextCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/seasontextcategories/excel")]
        [HttpGet("/export/zaren_test/seasontextcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSeasonTextCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSeasonTextCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/seasonthemes/csv")]
        [HttpGet("/export/zaren_test/seasonthemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSeasonThemesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSeasonThemes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/seasonthemes/excel")]
        [HttpGet("/export/zaren_test/seasonthemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSeasonThemesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSeasonThemes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/states/csv")]
        [HttpGet("/export/zaren_test/states/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportStatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetStates(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/states/excel")]
        [HttpGet("/export/zaren_test/states/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportStatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetStates(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/textcategories/csv")]
        [HttpGet("/export/zaren_test/textcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTextCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTextCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/textcategories/excel")]
        [HttpGet("/export/zaren_test/textcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTextCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTextCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/themes/csv")]
        [HttpGet("/export/zaren_test/themes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportThemesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetThemes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/themes/excel")]
        [HttpGet("/export/zaren_test/themes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportThemesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetThemes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/towns/csv")]
        [HttpGet("/export/zaren_test/towns/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTownsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTowns(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/towns/excel")]
        [HttpGet("/export/zaren_test/towns/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTownsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTowns(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/villages/csv")]
        [HttpGet("/export/zaren_test/villages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportVillagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetVillages(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/villages/excel")]
        [HttpGet("/export/zaren_test/villages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportVillagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetVillages(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/resource1s/csv")]
        [HttpGet("/export/zaren_test/resource1s/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportResource1SToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetResource1S(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/resource1s/excel")]
        [HttpGet("/export/zaren_test/resource1s/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportResource1SToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetResource1S(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/tests/csv")]
        [HttpGet("/export/zaren_test/tests/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTestsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTests(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/tests/excel")]
        [HttpGet("/export/zaren_test/tests/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTestsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTests(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractsconfigurationbyhotels/csv")]
        [HttpGet("/export/zaren_test/agencycontractsconfigurationbyhotels/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsConfigurationByHotelsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsConfigurationByHotels(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_test/agencycontractsconfigurationbyhotels/excel")]
        [HttpGet("/export/zaren_test/agencycontractsconfigurationbyhotels/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsConfigurationByHotelsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsConfigurationByHotels(), Request.Query), fileName);
        }
    }
}
