using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using ZarenTravelBO.Data;

namespace ZarenTravelBO.Controllers
{
    public partial class Exportzaren_prodController : ExportController
    {
        private readonly zaren_prodContext context;
        private readonly zaren_prodService service;

        public Exportzaren_prodController(zaren_prodContext context, zaren_prodService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/zaren_prod/agencies/csv")]
        [HttpGet("/export/zaren_prod/agencies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgenciesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencies(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencies/excel")]
        [HttpGet("/export/zaren_prod/agencies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgenciesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencies(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycmsdevices/csv")]
        [HttpGet("/export/zaren_prod/agencycmsdevices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCmsDevicesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyCmsDevices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycmsdevices/excel")]
        [HttpGet("/export/zaren_prod/agencycmsdevices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCmsDevicesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyCmsDevices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycmssectiontypes/csv")]
        [HttpGet("/export/zaren_prod/agencycmssectiontypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCmsSectionTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyCmsSectionTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycmssectiontypes/excel")]
        [HttpGet("/export/zaren_prod/agencycmssectiontypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCmsSectionTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyCmsSectionTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycmssocialmediaurls/csv")]
        [HttpGet("/export/zaren_prod/agencycmssocialmediaurls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCmsSocialMediaUrlsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyCmsSocialMediaUrls(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycmssocialmediaurls/excel")]
        [HttpGet("/export/zaren_prod/agencycmssocialmediaurls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCmsSocialMediaUrlsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyCmsSocialMediaUrls(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycmsthemes/csv")]
        [HttpGet("/export/zaren_prod/agencycmsthemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCmsThemesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyCmsThemes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycmsthemes/excel")]
        [HttpGet("/export/zaren_prod/agencycmsthemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCmsThemesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyCmsThemes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractsclosedtours/csv")]
        [HttpGet("/export/zaren_prod/agencycontractsclosedtours/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsClosedToursToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsClosedTours(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractsclosedtours/excel")]
        [HttpGet("/export/zaren_prod/agencycontractsclosedtours/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsClosedToursToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsClosedTours(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractshotelcategories/csv")]
        [HttpGet("/export/zaren_prod/agencycontractshotelcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsHotelCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractshotelcategories/excel")]
        [HttpGet("/export/zaren_prod/agencycontractshotelcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsHotelCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractshotelinformations/csv")]
        [HttpGet("/export/zaren_prod/agencycontractshotelinformations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelInformationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsHotelInformations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractshotelinformations/excel")]
        [HttpGet("/export/zaren_prod/agencycontractshotelinformations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelInformationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsHotelInformations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractshotelinformationimages/csv")]
        [HttpGet("/export/zaren_prod/agencycontractshotelinformationimages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelInformationImagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsHotelInformationImages(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractshotelinformationimages/excel")]
        [HttpGet("/export/zaren_prod/agencycontractshotelinformationimages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelInformationImagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsHotelInformationImages(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractshotelsconfigurations/csv")]
        [HttpGet("/export/zaren_prod/agencycontractshotelsconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelsConfigurationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsHotelsConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractshotelsconfigurations/excel")]
        [HttpGet("/export/zaren_prod/agencycontractshotelsconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelsConfigurationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsHotelsConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractshotelsconfigurationdays/csv")]
        [HttpGet("/export/zaren_prod/agencycontractshotelsconfigurationdays/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelsConfigurationDaysToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsHotelsConfigurationDays(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractshotelsconfigurationdays/excel")]
        [HttpGet("/export/zaren_prod/agencycontractshotelsconfigurationdays/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelsConfigurationDaysToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsHotelsConfigurationDays(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractshotelsmenus/csv")]
        [HttpGet("/export/zaren_prod/agencycontractshotelsmenus/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelsMenusToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsHotelsMenus(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractshotelsmenus/excel")]
        [HttpGet("/export/zaren_prod/agencycontractshotelsmenus/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsHotelsMenusToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsHotelsMenus(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractsinsurancebasicdata/csv")]
        [HttpGet("/export/zaren_prod/agencycontractsinsurancebasicdata/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsInsuranceBasicDataToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsInsuranceBasicData(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractsinsurancebasicdata/excel")]
        [HttpGet("/export/zaren_prod/agencycontractsinsurancebasicdata/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsInsuranceBasicDataToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsInsuranceBasicData(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractsinsuranceselectedlanguages/csv")]
        [HttpGet("/export/zaren_prod/agencycontractsinsuranceselectedlanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsInsuranceSelectedLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsInsuranceSelectedLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractsinsuranceselectedlanguages/excel")]
        [HttpGet("/export/zaren_prod/agencycontractsinsuranceselectedlanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsInsuranceSelectedLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsInsuranceSelectedLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractsinsuranceselectedproducttypes/csv")]
        [HttpGet("/export/zaren_prod/agencycontractsinsuranceselectedproducttypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsInsuranceSelectedProductTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsInsuranceSelectedProductTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractsinsuranceselectedproducttypes/excel")]
        [HttpGet("/export/zaren_prod/agencycontractsinsuranceselectedproducttypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsInsuranceSelectedProductTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsInsuranceSelectedProductTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractsinsurancetypes/csv")]
        [HttpGet("/export/zaren_prod/agencycontractsinsurancetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsInsuranceTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsInsuranceTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractsinsurancetypes/excel")]
        [HttpGet("/export/zaren_prod/agencycontractsinsurancetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsInsuranceTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsInsuranceTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycreditdeposits/csv")]
        [HttpGet("/export/zaren_prod/agencycreditdeposits/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCreditDepositsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyCreditDeposits(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycreditdeposits/excel")]
        [HttpGet("/export/zaren_prod/agencycreditdeposits/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyCreditDepositsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyCreditDeposits(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymanagers/csv")]
        [HttpGet("/export/zaren_prod/agencymanagers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyManagersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyManagers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymanagers/excel")]
        [HttpGet("/export/zaren_prod/agencymanagers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyManagersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyManagers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositeapiproductproviders/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositeapiproductproviders/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteApiProductProvidersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteApiProductProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositeapiproductproviders/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositeapiproductproviders/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteApiProductProvidersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteApiProductProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositedesigns/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositedesigns/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteDesignsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteDesigns(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositedesigns/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositedesigns/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteDesignsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteDesigns(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositedomainlanguagesettings/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositedomainlanguagesettings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteDomainLanguageSettingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteDomainLanguageSettings(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositedomainlanguagesettings/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositedomainlanguagesettings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteDomainLanguageSettingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteDomainLanguageSettings(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositedomains/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositedomains/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteDomainsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteDomains(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositedomains/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositedomains/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteDomainsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteDomains(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositepaymentproviders/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositepaymentproviders/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSitePaymentProvidersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSitePaymentProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositepaymentproviders/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositepaymentproviders/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSitePaymentProvidersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSitePaymentProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositeproperties/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositeproperties/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSitePropertiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteProperties(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositeproperties/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositeproperties/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSitePropertiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteProperties(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrosites/csv")]
        [HttpGet("/export/zaren_prod/agencymicrosites/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSitesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSites(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrosites/excel")]
        [HttpGet("/export/zaren_prod/agencymicrosites/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSitesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSites(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingpassengerdata/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingpassengerdata/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingPassengerDataToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingPassengerData(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingpassengerdata/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingpassengerdata/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingPassengerDataToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingPassengerData(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsaccommodationsearchresults/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsaccommodationsearchresults/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsAccommodationSearchResultsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsAccommodationSearchResults(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsaccommodationsearchresults/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsaccommodationsearchresults/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsAccommodationSearchResultsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsAccommodationSearchResults(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsbookingprocesses/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsbookingprocesses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsBookingProcessesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsBookingProcesses(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsbookingprocesses/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsbookingprocesses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsBookingProcessesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsBookingProcesses(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsbookingreplicatormodes/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsbookingreplicatormodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsBookingReplicatorModesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsBookingReplicatorModes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsbookingreplicatormodes/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsbookingreplicatormodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsBookingReplicatorModesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsBookingReplicatorModes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsemailvouchers/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsemailvouchers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsEmailVouchersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsEmailVouchers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsemailvouchers/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsemailvouchers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsEmailVouchersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsEmailVouchers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsenablemultidays/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsenablemultidays/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsEnableMultiDaysToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsEnableMultiDays(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsenablemultidays/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsenablemultidays/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsEnableMultiDaysToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsEnableMultiDays(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsgenerals/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsgenerals/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsGeneralsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsGenerals(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsgenerals/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsgenerals/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsGeneralsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsGenerals(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingshelpsupports/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingshelpsupports/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsHelpSupportsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsHelpSupports(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingshelpsupports/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingshelpsupports/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsHelpSupportsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsHelpSupports(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsinvoices/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsinvoices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsInvoicesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsInvoices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsinvoices/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsinvoices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsInvoicesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsInvoices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsothers/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsothers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsOthersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsOthers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsothers/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsothers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsOthersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsOthers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingspaymetoptions/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingspaymetoptions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsPaymetOptionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsPaymetOptions(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingspaymetoptions/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingspaymetoptions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsPaymetOptionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsPaymetOptions(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsrequestinvoices/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsrequestinvoices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsRequestInvoicesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsRequestInvoices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsrequestinvoices/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsrequestinvoices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsRequestInvoicesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsRequestInvoices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsrequiredpassengers/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsrequiredpassengers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsRequiredPassengersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsRequiredPassengers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingsrequiredpassengers/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingsrequiredpassengers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsRequiredPassengersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsRequiredPassengers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingssearchengines/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingssearchengines/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsSearchEnginesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsSearchEngines(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingssearchengines/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingssearchengines/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsSearchEnginesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsSearchEngines(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingssearchsettings/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingssearchsettings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsSearchSettingsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsSearchSettings(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingssearchsettings/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingssearchsettings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsSearchSettingsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsSearchSettings(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingssorttypes/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingssorttypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsSortTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsSortTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingssorttypes/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingssorttypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsSortTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsSortTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingstermsconditions/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingstermsconditions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsTermsConditionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSiteSettingsTermsConditions(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositesettingstermsconditions/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositesettingstermsconditions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSiteSettingsTermsConditionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSiteSettingsTermsConditions(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositessettingsemailconfigurations/csv")]
        [HttpGet("/export/zaren_prod/agencymicrositessettingsemailconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSitesSettingsEmailConfigurationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyMicroSitesSettingsEmailConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencymicrositessettingsemailconfigurations/excel")]
        [HttpGet("/export/zaren_prod/agencymicrositessettingsemailconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyMicroSitesSettingsEmailConfigurationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyMicroSitesSettingsEmailConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencyusers/csv")]
        [HttpGet("/export/zaren_prod/agencyusers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyUsersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyUsers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencyusers/excel")]
        [HttpGet("/export/zaren_prod/agencyusers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyUsersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyUsers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/airlines/csv")]
        [HttpGet("/export/zaren_prod/airlines/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAirLinesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAirLines(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/airlines/excel")]
        [HttpGet("/export/zaren_prod/airlines/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAirLinesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAirLines(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/airports/csv")]
        [HttpGet("/export/zaren_prod/airports/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAirPortsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAirPorts(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/airports/excel")]
        [HttpGet("/export/zaren_prod/airports/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAirPortsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAirPorts(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/airporttaxes/csv")]
        [HttpGet("/export/zaren_prod/airporttaxes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAirPortTaxesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAirPortTaxes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/airporttaxes/excel")]
        [HttpGet("/export/zaren_prod/airporttaxes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAirPortTaxesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAirPortTaxes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/apiproducts/csv")]
        [HttpGet("/export/zaren_prod/apiproducts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApiProductsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetApiProducts(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/apiproducts/excel")]
        [HttpGet("/export/zaren_prod/apiproducts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApiProductsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetApiProducts(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/apiresults/csv")]
        [HttpGet("/export/zaren_prod/apiresults/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApiResultsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetApiResults(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/apiresults/excel")]
        [HttpGet("/export/zaren_prod/apiresults/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApiResultsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetApiResults(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/apis/csv")]
        [HttpGet("/export/zaren_prod/apis/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApisToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetApis(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/apis/excel")]
        [HttpGet("/export/zaren_prod/apis/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportApisToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetApis(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/arrivals/csv")]
        [HttpGet("/export/zaren_prod/arrivals/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportArrivalsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetArrivals(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/arrivals/excel")]
        [HttpGet("/export/zaren_prod/arrivals/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportArrivalsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetArrivals(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/autocompletes/csv")]
        [HttpGet("/export/zaren_prod/autocompletes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompletesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAutoCompletes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/autocompletes/excel")]
        [HttpGet("/export/zaren_prod/autocompletes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompletesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAutoCompletes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/autocompletetypes/csv")]
        [HttpGet("/export/zaren_prod/autocompletetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompleteTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAutoCompleteTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/autocompletetypes/excel")]
        [HttpGet("/export/zaren_prod/autocompletetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAutoCompleteTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAutoCompleteTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/baggageinformations/csv")]
        [HttpGet("/export/zaren_prod/baggageinformations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBaggageInformationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBaggageInformations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/baggageinformations/excel")]
        [HttpGet("/export/zaren_prod/baggageinformations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBaggageInformationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBaggageInformations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/baggagetypes/csv")]
        [HttpGet("/export/zaren_prod/baggagetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBaggageTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBaggageTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/baggagetypes/excel")]
        [HttpGet("/export/zaren_prod/baggagetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBaggageTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBaggageTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/baggageunittypes/csv")]
        [HttpGet("/export/zaren_prod/baggageunittypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBaggageUnitTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetBaggageUnitTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/baggageunittypes/excel")]
        [HttpGet("/export/zaren_prod/baggageunittypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportBaggageUnitTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetBaggageUnitTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/cities/csv")]
        [HttpGet("/export/zaren_prod/cities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCities(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/cities/excel")]
        [HttpGet("/export/zaren_prod/cities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCities(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/citymodels/csv")]
        [HttpGet("/export/zaren_prod/citymodels/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCityModelsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCityModels(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/citymodels/excel")]
        [HttpGet("/export/zaren_prod/citymodels/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCityModelsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCityModels(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/countries/csv")]
        [HttpGet("/export/zaren_prod/countries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/countries/excel")]
        [HttpGet("/export/zaren_prod/countries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/country1s/csv")]
        [HttpGet("/export/zaren_prod/country1s/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountry1SToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountry1S(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/country1s/excel")]
        [HttpGet("/export/zaren_prod/country1s/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountry1SToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountry1S(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/currencies/csv")]
        [HttpGet("/export/zaren_prod/currencies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrenciesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCurrencies(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/currencies/excel")]
        [HttpGet("/export/zaren_prod/currencies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrenciesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCurrencies(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/currency1s/csv")]
        [HttpGet("/export/zaren_prod/currency1s/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrency1SToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCurrency1S(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/currency1s/excel")]
        [HttpGet("/export/zaren_prod/currency1s/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCurrency1SToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCurrency1S(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/dates/csv")]
        [HttpGet("/export/zaren_prod/dates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDates(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/dates/excel")]
        [HttpGet("/export/zaren_prod/dates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDates(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/departures/csv")]
        [HttpGet("/export/zaren_prod/departures/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDeparturesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDepartures(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/departures/excel")]
        [HttpGet("/export/zaren_prod/departures/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDeparturesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDepartures(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/explanations/csv")]
        [HttpGet("/export/zaren_prod/explanations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportExplanationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetExplanations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/explanations/excel")]
        [HttpGet("/export/zaren_prod/explanations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportExplanationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetExplanations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/features/csv")]
        [HttpGet("/export/zaren_prod/features/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFeaturesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFeatures(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/features/excel")]
        [HttpGet("/export/zaren_prod/features/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFeaturesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFeatures(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/flightbrands/csv")]
        [HttpGet("/export/zaren_prod/flightbrands/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFlightBrandsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFlightBrands(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/flightbrands/excel")]
        [HttpGet("/export/zaren_prod/flightbrands/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFlightBrandsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFlightBrands(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/flightclasses/csv")]
        [HttpGet("/export/zaren_prod/flightclasses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFlightClassesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFlightClasses(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/flightclasses/excel")]
        [HttpGet("/export/zaren_prod/flightclasses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFlightClassesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFlightClasses(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/flightfees/csv")]
        [HttpGet("/export/zaren_prod/flightfees/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFlightFeesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFlightFees(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/flightfees/excel")]
        [HttpGet("/export/zaren_prod/flightfees/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFlightFeesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFlightFees(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/flightgeolocations/csv")]
        [HttpGet("/export/zaren_prod/flightgeolocations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFlightGeoLocationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFlightGeoLocations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/flightgeolocations/excel")]
        [HttpGet("/export/zaren_prod/flightgeolocations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFlightGeoLocationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFlightGeoLocations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/flightitems/csv")]
        [HttpGet("/export/zaren_prod/flightitems/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFlightItemsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFlightItems(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/flightitems/excel")]
        [HttpGet("/export/zaren_prod/flightitems/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFlightItemsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFlightItems(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/flightoffers/csv")]
        [HttpGet("/export/zaren_prod/flightoffers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFlightOffersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFlightOffers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/flightoffers/excel")]
        [HttpGet("/export/zaren_prod/flightoffers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFlightOffersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFlightOffers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/flightproviders/csv")]
        [HttpGet("/export/zaren_prod/flightproviders/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFlightProvidersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFlightProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/flightproviders/excel")]
        [HttpGet("/export/zaren_prod/flightproviders/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFlightProvidersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFlightProviders(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/flights/csv")]
        [HttpGet("/export/zaren_prod/flights/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFlightsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFlights(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/flights/excel")]
        [HttpGet("/export/zaren_prod/flights/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFlightsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFlights(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/genders/csv")]
        [HttpGet("/export/zaren_prod/genders/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGendersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGenders(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/genders/excel")]
        [HttpGet("/export/zaren_prod/genders/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGendersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGenders(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/groupkeys/csv")]
        [HttpGet("/export/zaren_prod/groupkeys/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGroupKeysToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGroupKeys(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/groupkeys/excel")]
        [HttpGet("/export/zaren_prod/groupkeys/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGroupKeysToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGroupKeys(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelcategories/csv")]
        [HttpGet("/export/zaren_prod/hotelcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelcategories/excel")]
        [HttpGet("/export/zaren_prod/hotelcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelfacilities/csv")]
        [HttpGet("/export/zaren_prod/hotelfacilities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelFacilitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelFacilities(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelfacilities/excel")]
        [HttpGet("/export/zaren_prod/hotelfacilities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelFacilitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelFacilities(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelfacilitycategories/csv")]
        [HttpGet("/export/zaren_prod/hotelfacilitycategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelFacilityCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelFacilityCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelfacilitycategories/excel")]
        [HttpGet("/export/zaren_prod/hotelfacilitycategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelFacilityCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelFacilityCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelfacilitycategoryselectedfacilities/csv")]
        [HttpGet("/export/zaren_prod/hotelfacilitycategoryselectedfacilities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelFacilityCategorySelectedFacilitiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelFacilityCategorySelectedFacilities(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelfacilitycategoryselectedfacilities/excel")]
        [HttpGet("/export/zaren_prod/hotelfacilitycategoryselectedfacilities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelFacilityCategorySelectedFacilitiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelFacilityCategorySelectedFacilities(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelpresentations/csv")]
        [HttpGet("/export/zaren_prod/hotelpresentations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelPresentationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelPresentations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelpresentations/excel")]
        [HttpGet("/export/zaren_prod/hotelpresentations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelPresentationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelPresentations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotels/csv")]
        [HttpGet("/export/zaren_prod/hotels/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotels(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotels/excel")]
        [HttpGet("/export/zaren_prod/hotels/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotels(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelseasonmediafiles/csv")]
        [HttpGet("/export/zaren_prod/hotelseasonmediafiles/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelSeasonMediaFilesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelSeasonMediaFiles(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelseasonmediafiles/excel")]
        [HttpGet("/export/zaren_prod/hotelseasonmediafiles/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelSeasonMediaFilesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelSeasonMediaFiles(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelseasons/csv")]
        [HttpGet("/export/zaren_prod/hotelseasons/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelSeasonsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelSeasons(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelseasons/excel")]
        [HttpGet("/export/zaren_prod/hotelseasons/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelSeasonsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelSeasons(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelseasonselectedtextcategories/csv")]
        [HttpGet("/export/zaren_prod/hotelseasonselectedtextcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelSeasonSelectedTextCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelSeasonSelectedTextCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelseasonselectedtextcategories/excel")]
        [HttpGet("/export/zaren_prod/hotelseasonselectedtextcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelSeasonSelectedTextCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelSeasonSelectedTextCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelselectedcategories/csv")]
        [HttpGet("/export/zaren_prod/hotelselectedcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelSelectedCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelSelectedCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hotelselectedcategories/excel")]
        [HttpGet("/export/zaren_prod/hotelselectedcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelSelectedCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelSelectedCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hoteltextcategories/csv")]
        [HttpGet("/export/zaren_prod/hoteltextcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelTextCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelTextCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hoteltextcategories/excel")]
        [HttpGet("/export/zaren_prod/hoteltextcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelTextCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelTextCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hoteltextcategoriesselectedpresentations/csv")]
        [HttpGet("/export/zaren_prod/hoteltextcategoriesselectedpresentations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelTextCategoriesSelectedPresentationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetHotelTextCategoriesSelectedPresentations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/hoteltextcategoriesselectedpresentations/excel")]
        [HttpGet("/export/zaren_prod/hoteltextcategoriesselectedpresentations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportHotelTextCategoriesSelectedPresentationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetHotelTextCategoriesSelectedPresentations(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/insuranceselectedlangs/csv")]
        [HttpGet("/export/zaren_prod/insuranceselectedlangs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportInsuranceSelectedLangsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetInsuranceSelectedLangs(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/insuranceselectedlangs/excel")]
        [HttpGet("/export/zaren_prod/insuranceselectedlangs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportInsuranceSelectedLangsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetInsuranceSelectedLangs(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/invoicetypes/csv")]
        [HttpGet("/export/zaren_prod/invoicetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportInvoiceTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetInvoiceTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/invoicetypes/excel")]
        [HttpGet("/export/zaren_prod/invoicetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportInvoiceTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetInvoiceTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/languages/csv")]
        [HttpGet("/export/zaren_prod/languages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/languages/excel")]
        [HttpGet("/export/zaren_prod/languages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/language1s/csv")]
        [HttpGet("/export/zaren_prod/language1s/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLanguage1SToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLanguage1S(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/language1s/excel")]
        [HttpGet("/export/zaren_prod/language1s/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLanguage1SToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLanguage1S(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/limittypes/csv")]
        [HttpGet("/export/zaren_prod/limittypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLimitTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetLimitTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/limittypes/excel")]
        [HttpGet("/export/zaren_prod/limittypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportLimitTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetLimitTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/passengers/csv")]
        [HttpGet("/export/zaren_prod/passengers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPassengersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPassengers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/passengers/excel")]
        [HttpGet("/export/zaren_prod/passengers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPassengersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPassengers(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/passengertypes/csv")]
        [HttpGet("/export/zaren_prod/passengertypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPassengerTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPassengerTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/passengertypes/excel")]
        [HttpGet("/export/zaren_prod/passengertypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPassengerTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPassengerTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/paymenttypes/csv")]
        [HttpGet("/export/zaren_prod/paymenttypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPaymentTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/paymenttypes/excel")]
        [HttpGet("/export/zaren_prod/paymenttypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPaymentTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPaymentTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/possiblequeries/csv")]
        [HttpGet("/export/zaren_prod/possiblequeries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPossibleQueriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPossibleQueries(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/possiblequeries/excel")]
        [HttpGet("/export/zaren_prod/possiblequeries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPossibleQueriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPossibleQueries(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/pricebreakdowns/csv")]
        [HttpGet("/export/zaren_prod/pricebreakdowns/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPriceBreakDownsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPriceBreakDowns(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/pricebreakdowns/excel")]
        [HttpGet("/export/zaren_prod/pricebreakdowns/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPriceBreakDownsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPriceBreakDowns(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/prices/csv")]
        [HttpGet("/export/zaren_prod/prices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPricesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPrices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/prices/excel")]
        [HttpGet("/export/zaren_prod/prices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPricesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPrices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/producttypes/csv")]
        [HttpGet("/export/zaren_prod/producttypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProductTypesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProductTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/producttypes/excel")]
        [HttpGet("/export/zaren_prod/producttypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProductTypesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProductTypes(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/seatinfos/csv")]
        [HttpGet("/export/zaren_prod/seatinfos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSeatInfosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSeatInfos(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/seatinfos/excel")]
        [HttpGet("/export/zaren_prod/seatinfos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSeatInfosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSeatInfos(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/segments/csv")]
        [HttpGet("/export/zaren_prod/segments/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSegmentsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSegments(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/segments/excel")]
        [HttpGet("/export/zaren_prod/segments/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSegmentsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSegments(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/servicefees/csv")]
        [HttpGet("/export/zaren_prod/servicefees/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportServiceFeesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetServiceFees(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/servicefees/excel")]
        [HttpGet("/export/zaren_prod/servicefees/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportServiceFeesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetServiceFees(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/services/csv")]
        [HttpGet("/export/zaren_prod/services/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportServicesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetServices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/services/excel")]
        [HttpGet("/export/zaren_prod/services/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportServicesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetServices(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/status/csv")]
        [HttpGet("/export/zaren_prod/status/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportStatusToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetStatus(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/status/excel")]
        [HttpGet("/export/zaren_prod/status/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportStatusToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetStatus(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractsconfigurationbyhotels/csv")]
        [HttpGet("/export/zaren_prod/agencycontractsconfigurationbyhotels/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsConfigurationByHotelsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAgencyContractsConfigurationByHotels(), Request.Query), fileName);
        }

        [HttpGet("/export/zaren_prod/agencycontractsconfigurationbyhotels/excel")]
        [HttpGet("/export/zaren_prod/agencycontractsconfigurationbyhotels/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAgencyContractsConfigurationByHotelsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAgencyContractsConfigurationByHotels(), Request.Query), fileName);
        }
    }
}
