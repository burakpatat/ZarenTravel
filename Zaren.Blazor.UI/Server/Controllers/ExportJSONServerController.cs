using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using ZarenUI.Server.Data;

namespace ZarenUI.Server.Controllers
{
    public partial class ExportJSONServerController : ExportController
    {
        private readonly JSONServerContext context;
        private readonly JSONServerService service;

        public ExportJSONServerController(JSONServerContext context, JSONServerService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/JSONServer/auditcolorgroups/csv")]
        [HttpGet("/export/JSONServer/auditcolorgroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditColorGroupsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditColorGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditcolorgroups/excel")]
        [HttpGet("/export/JSONServer/auditcolorgroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditColorGroupsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditColorGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditconstraintrules/csv")]
        [HttpGet("/export/JSONServer/auditconstraintrules/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditConstraintRulesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditConstraintRules(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditconstraintrules/excel")]
        [HttpGet("/export/JSONServer/auditconstraintrules/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditConstraintRulesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditConstraintRules(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditcountries/csv")]
        [HttpGet("/export/JSONServer/auditcountries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditCountriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditcountries/excel")]
        [HttpGet("/export/JSONServer/auditcountries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditCountriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditcountrylanguages/csv")]
        [HttpGet("/export/JSONServer/auditcountrylanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditCountryLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditCountryLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditcountrylanguages/excel")]
        [HttpGet("/export/JSONServer/auditcountrylanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditCountryLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditCountryLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditdesignschemes/csv")]
        [HttpGet("/export/JSONServer/auditdesignschemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditDesignSchemesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditDesignSchemes(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditdesignschemes/excel")]
        [HttpGet("/export/JSONServer/auditdesignschemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditDesignSchemesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditDesignSchemes(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditdevicegroups/csv")]
        [HttpGet("/export/JSONServer/auditdevicegroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditDeviceGroupsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditDeviceGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditdevicegroups/excel")]
        [HttpGet("/export/JSONServer/auditdevicegroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditDeviceGroupsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditDeviceGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditdevices/csv")]
        [HttpGet("/export/JSONServer/auditdevices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditDevicesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditDevices(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditdevices/excel")]
        [HttpGet("/export/JSONServer/auditdevices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditDevicesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditDevices(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditfields/csv")]
        [HttpGet("/export/JSONServer/auditfields/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditFieldsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditFields(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditfields/excel")]
        [HttpGet("/export/JSONServer/auditfields/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditFieldsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditFields(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditforeignkeyrules/csv")]
        [HttpGet("/export/JSONServer/auditforeignkeyrules/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditForeignKeyRulesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditForeignKeyRules(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditforeignkeyrules/excel")]
        [HttpGet("/export/JSONServer/auditforeignkeyrules/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditForeignKeyRulesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditForeignKeyRules(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprogrammingcategories/csv")]
        [HttpGet("/export/JSONServer/auditprogrammingcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProgrammingCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditProgrammingCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprogrammingcategories/excel")]
        [HttpGet("/export/JSONServer/auditprogrammingcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProgrammingCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditProgrammingCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprogrammingcodes/csv")]
        [HttpGet("/export/JSONServer/auditprogrammingcodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProgrammingCodesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditProgrammingCodes(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprogrammingcodes/excel")]
        [HttpGet("/export/JSONServer/auditprogrammingcodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProgrammingCodesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditProgrammingCodes(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprogrammingcodetemplates/csv")]
        [HttpGet("/export/JSONServer/auditprogrammingcodetemplates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProgrammingCodeTemplatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditProgrammingCodeTemplates(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprogrammingcodetemplates/excel")]
        [HttpGet("/export/JSONServer/auditprogrammingcodetemplates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProgrammingCodeTemplatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditProgrammingCodeTemplates(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprogrammingtechnologies/csv")]
        [HttpGet("/export/JSONServer/auditprogrammingtechnologies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProgrammingTechnologiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditProgrammingTechnologies(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprogrammingtechnologies/excel")]
        [HttpGet("/export/JSONServer/auditprogrammingtechnologies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProgrammingTechnologiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditProgrammingTechnologies(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojectcategories/csv")]
        [HttpGet("/export/JSONServer/auditprojectcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditProjectCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojectcategories/excel")]
        [HttpGet("/export/JSONServer/auditprojectcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditProjectCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojectconfigurationkeyandvalues/csv")]
        [HttpGet("/export/JSONServer/auditprojectconfigurationkeyandvalues/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectConfigurationKeyAndValuesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditProjectConfigurationKeyAndValues(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojectconfigurationkeyandvalues/excel")]
        [HttpGet("/export/JSONServer/auditprojectconfigurationkeyandvalues/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectConfigurationKeyAndValuesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditProjectConfigurationKeyAndValues(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojectconfigurations/csv")]
        [HttpGet("/export/JSONServer/auditprojectconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectConfigurationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditProjectConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojectconfigurations/excel")]
        [HttpGet("/export/JSONServer/auditprojectconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectConfigurationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditProjectConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojectfunctiongroups/csv")]
        [HttpGet("/export/JSONServer/auditprojectfunctiongroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectFunctionGroupsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditProjectFunctionGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojectfunctiongroups/excel")]
        [HttpGet("/export/JSONServer/auditprojectfunctiongroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectFunctionGroupsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditProjectFunctionGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojectfunctions/csv")]
        [HttpGet("/export/JSONServer/auditprojectfunctions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectFunctionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditProjectFunctions(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojectfunctions/excel")]
        [HttpGet("/export/JSONServer/auditprojectfunctions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectFunctionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditProjectFunctions(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojectpagecomponentelements/csv")]
        [HttpGet("/export/JSONServer/auditprojectpagecomponentelements/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectPageComponentElementsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditProjectPageComponentElements(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojectpagecomponentelements/excel")]
        [HttpGet("/export/JSONServer/auditprojectpagecomponentelements/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectPageComponentElementsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditProjectPageComponentElements(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojectpagecomponents/csv")]
        [HttpGet("/export/JSONServer/auditprojectpagecomponents/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectPageComponentsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditProjectPageComponents(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojectpagecomponents/excel")]
        [HttpGet("/export/JSONServer/auditprojectpagecomponents/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectPageComponentsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditProjectPageComponents(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojectpages/csv")]
        [HttpGet("/export/JSONServer/auditprojectpages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectPagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditProjectPages(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojectpages/excel")]
        [HttpGet("/export/JSONServer/auditprojectpages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectPagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditProjectPages(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojects/csv")]
        [HttpGet("/export/JSONServer/auditprojects/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditProjects(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojects/excel")]
        [HttpGet("/export/JSONServer/auditprojects/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditProjects(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojecttablecolumns/csv")]
        [HttpGet("/export/JSONServer/auditprojecttablecolumns/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectTableColumnsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditProjectTableColumns(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojecttablecolumns/excel")]
        [HttpGet("/export/JSONServer/auditprojecttablecolumns/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectTableColumnsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditProjectTableColumns(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojecttables/csv")]
        [HttpGet("/export/JSONServer/auditprojecttables/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectTablesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditProjectTables(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditprojecttables/excel")]
        [HttpGet("/export/JSONServer/auditprojecttables/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditProjectTablesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditProjectTables(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditreferencewebsites/csv")]
        [HttpGet("/export/JSONServer/auditreferencewebsites/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditReferenceWebSitesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditReferenceWebSites(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditreferencewebsites/excel")]
        [HttpGet("/export/JSONServer/auditreferencewebsites/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditReferenceWebSitesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditReferenceWebSites(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditschemes/csv")]
        [HttpGet("/export/JSONServer/auditschemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditSchemesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditSchemes(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/auditschemes/excel")]
        [HttpGet("/export/JSONServer/auditschemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditSchemesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditSchemes(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/audittables/csv")]
        [HttpGet("/export/JSONServer/audittables/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditTablesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAuditTables(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/audittables/excel")]
        [HttpGet("/export/JSONServer/audittables/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportAuditTablesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAuditTables(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroups/csv")]
        [HttpGet("/export/JSONServer/colorgroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetColorGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroups/excel")]
        [HttpGet("/export/JSONServer/colorgroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetColorGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrules/csv")]
        [HttpGet("/export/JSONServer/constraintrules/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConstraintRules(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrules/excel")]
        [HttpGet("/export/JSONServer/constraintrules/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConstraintRules(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countries/csv")]
        [HttpGet("/export/JSONServer/countries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countries/excel")]
        [HttpGet("/export/JSONServer/countries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrylanguages/csv")]
        [HttpGet("/export/JSONServer/countrylanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrylanguages/excel")]
        [HttpGet("/export/JSONServer/countrylanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicegroups/csv")]
        [HttpGet("/export/JSONServer/devicegroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDeviceGroupsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDeviceGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicegroups/excel")]
        [HttpGet("/export/JSONServer/devicegroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDeviceGroupsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDeviceGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devices/csv")]
        [HttpGet("/export/JSONServer/devices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDevices(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devices/excel")]
        [HttpGet("/export/JSONServer/devices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDevices(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/distributedservercaches/csv")]
        [HttpGet("/export/JSONServer/distributedservercaches/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDistributedServerCachesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDistributedServerCaches(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/distributedservercaches/excel")]
        [HttpGet("/export/JSONServer/distributedservercaches/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDistributedServerCachesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDistributedServerCaches(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fields/csv")]
        [HttpGet("/export/JSONServer/fields/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFields(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fields/excel")]
        [HttpGet("/export/JSONServer/fields/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFields(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrules/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrules/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRules(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrules/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrules/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRules(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcategories/csv")]
        [HttpGet("/export/JSONServer/programmingcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcategories/excel")]
        [HttpGet("/export/JSONServer/programmingcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodes/csv")]
        [HttpGet("/export/JSONServer/programmingcodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodes(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodes/excel")]
        [HttpGet("/export/JSONServer/programmingcodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodes(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodetemplates/csv")]
        [HttpGet("/export/JSONServer/programmingcodetemplates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodeTemplates(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodetemplates/excel")]
        [HttpGet("/export/JSONServer/programmingcodetemplates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodeTemplates(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingtechnologies/csv")]
        [HttpGet("/export/JSONServer/programmingtechnologies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingTechnologies(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingtechnologies/excel")]
        [HttpGet("/export/JSONServer/programmingtechnologies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingTechnologies(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategories/csv")]
        [HttpGet("/export/JSONServer/projectcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategories/excel")]
        [HttpGet("/export/JSONServer/projectcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvalues/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvalues/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValuesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationKeyAndValues(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvalues/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvalues/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValuesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationKeyAndValues(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroups/csv")]
        [HttpGet("/export/JSONServer/projectfunctiongroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroups/excel")]
        [HttpGet("/export/JSONServer/projectfunctiongroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctions/csv")]
        [HttpGet("/export/JSONServer/projectfunctions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctions(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctions/excel")]
        [HttpGet("/export/JSONServer/projectfunctions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctions(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelements/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelements/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElements(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelements/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelements/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElements(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponents/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponents/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponents(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponents/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponents/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponents(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpages/csv")]
        [HttpGet("/export/JSONServer/projectpages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPages(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpages/excel")]
        [HttpGet("/export/JSONServer/projectpages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPages(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projects/csv")]
        [HttpGet("/export/JSONServer/projects/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjects(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projects/excel")]
        [HttpGet("/export/JSONServer/projects/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjects(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumns/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumns/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumns(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumns/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumns/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumns(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttables/csv")]
        [HttpGet("/export/JSONServer/projecttables/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTables(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttables/excel")]
        [HttpGet("/export/JSONServer/projecttables/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTables(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsites/csv")]
        [HttpGet("/export/JSONServer/referencewebsites/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSites(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsites/excel")]
        [HttpGet("/export/JSONServer/referencewebsites/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSites(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/schemes/csv")]
        [HttpGet("/export/JSONServer/schemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSchemesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSchemes(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/schemes/excel")]
        [HttpGet("/export/JSONServer/schemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSchemesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSchemes(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/tables/csv")]
        [HttpGet("/export/JSONServer/tables/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTablesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTables(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/tables/excel")]
        [HttpGet("/export/JSONServer/tables/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTablesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTables(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemes/csv")]
        [HttpGet("/export/JSONServer/designschemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignSchemesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignSchemes(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemes/excel")]
        [HttpGet("/export/JSONServer/designschemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignSchemesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignSchemes(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsgetalls/csv")]
        [HttpGet("/export/JSONServer/colorgroupsgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetColorGroupsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsgetalls/excel")]
        [HttpGet("/export/JSONServer/colorgroupsgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetColorGroupsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsgetbybrightnessvalues/csv")]
        [HttpGet("/export/JSONServer/colorgroupsgetbybrightnessvalues/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsGetByBrightnessValuesToCSV(double? BrightnessValue, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetColorGroupsGetByBrightnessValues(BrightnessValue), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsgetbybrightnessvalues/excel")]
        [HttpGet("/export/JSONServer/colorgroupsgetbybrightnessvalues/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsGetByBrightnessValuesToExcel(double? BrightnessValue, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetColorGroupsGetByBrightnessValues(BrightnessValue), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsgetbygrouplists/csv")]
        [HttpGet("/export/JSONServer/colorgroupsgetbygrouplists/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsGetByGroupListsToCSV(string GroupList, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetColorGroupsGetByGroupLists(GroupList), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsgetbygrouplists/excel")]
        [HttpGet("/export/JSONServer/colorgroupsgetbygrouplists/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsGetByGroupListsToExcel(string GroupList, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetColorGroupsGetByGroupLists(GroupList), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsgetbyhexcodes/csv")]
        [HttpGet("/export/JSONServer/colorgroupsgetbyhexcodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsGetByHexCodesToCSV(string HexCode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetColorGroupsGetByHexCodes(HexCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsgetbyhexcodes/excel")]
        [HttpGet("/export/JSONServer/colorgroupsgetbyhexcodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsGetByHexCodesToExcel(string HexCode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetColorGroupsGetByHexCodes(HexCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsgetbyids/csv")]
        [HttpGet("/export/JSONServer/colorgroupsgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetColorGroupsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsgetbyids/excel")]
        [HttpGet("/export/JSONServer/colorgroupsgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetColorGroupsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsgetbyisdarks/csv")]
        [HttpGet("/export/JSONServer/colorgroupsgetbyisdarks/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsGetByIsDarksToCSV(bool? IsDark, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetColorGroupsGetByIsDarks(IsDark), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsgetbyisdarks/excel")]
        [HttpGet("/export/JSONServer/colorgroupsgetbyisdarks/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsGetByIsDarksToExcel(bool? IsDark, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetColorGroupsGetByIsDarks(IsDark), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsgetbypossiblenames/csv")]
        [HttpGet("/export/JSONServer/colorgroupsgetbypossiblenames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsGetByPossibleNamesToCSV(string PossibleName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetColorGroupsGetByPossibleNames(PossibleName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsgetbypossiblenames/excel")]
        [HttpGet("/export/JSONServer/colorgroupsgetbypossiblenames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsGetByPossibleNamesToExcel(string PossibleName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetColorGroupsGetByPossibleNames(PossibleName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsgetbyrgbcodes/csv")]
        [HttpGet("/export/JSONServer/colorgroupsgetbyrgbcodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsGetByRgbCodesToCSV(string RGBCode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetColorGroupsGetByRgbCodes(RGBCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsgetbyrgbcodes/excel")]
        [HttpGet("/export/JSONServer/colorgroupsgetbyrgbcodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsGetByRgbCodesToExcel(string RGBCode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetColorGroupsGetByRgbCodes(RGBCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsinserts/csv")]
        [HttpGet("/export/JSONServer/colorgroupsinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsInsertsToCSV(string HexCode, string RGBCode, string GroupList, double? BrightnessValue, bool? IsDark, string PossibleName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetColorGroupsInserts(HexCode, RGBCode, GroupList, BrightnessValue, IsDark, PossibleName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsinserts/excel")]
        [HttpGet("/export/JSONServer/colorgroupsinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsInsertsToExcel(string HexCode, string RGBCode, string GroupList, double? BrightnessValue, bool? IsDark, string PossibleName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetColorGroupsInserts(HexCode, RGBCode, GroupList, BrightnessValue, IsDark, PossibleName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsupdates/csv")]
        [HttpGet("/export/JSONServer/colorgroupsupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsUpdatesToCSV(int? Id, string HexCode, string RGBCode, string GroupList, double? BrightnessValue, bool? IsDark, string PossibleName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetColorGroupsUpdates(Id, HexCode, RGBCode, GroupList, BrightnessValue, IsDark, PossibleName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/colorgroupsupdates/excel")]
        [HttpGet("/export/JSONServer/colorgroupsupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsUpdatesToExcel(int? Id, string HexCode, string RGBCode, string GroupList, double? BrightnessValue, bool? IsDark, string PossibleName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetColorGroupsUpdates(Id, HexCode, RGBCode, GroupList, BrightnessValue, IsDark, PossibleName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetalls/csv")]
        [HttpGet("/export/JSONServer/constraintrulesgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConstraintRulesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetalls/excel")]
        [HttpGet("/export/JSONServer/constraintrulesgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConstraintRulesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbyaddwithchecks/csv")]
        [HttpGet("/export/JSONServer/constraintrulesgetbyaddwithchecks/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByAddWithChecksToCSV(string AddWithCheck, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConstraintRulesGetByAddWithChecks(AddWithCheck), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbyaddwithchecks/excel")]
        [HttpGet("/export/JSONServer/constraintrulesgetbyaddwithchecks/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByAddWithChecksToExcel(string AddWithCheck, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConstraintRulesGetByAddWithChecks(AddWithCheck), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbyaddwithnochecks/csv")]
        [HttpGet("/export/JSONServer/constraintrulesgetbyaddwithnochecks/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByAddWithNoChecksToCSV(string AddWithNoCheck, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConstraintRulesGetByAddWithNoChecks(AddWithNoCheck), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbyaddwithnochecks/excel")]
        [HttpGet("/export/JSONServer/constraintrulesgetbyaddwithnochecks/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByAddWithNoChecksToExcel(string AddWithNoCheck, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConstraintRulesGetByAddWithNoChecks(AddWithNoCheck), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbycheckconstraints/csv")]
        [HttpGet("/export/JSONServer/constraintrulesgetbycheckconstraints/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByCheckConstraintsToCSV(string CheckConstraint, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConstraintRulesGetByCheckConstraints(CheckConstraint), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbycheckconstraints/excel")]
        [HttpGet("/export/JSONServer/constraintrulesgetbycheckconstraints/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByCheckConstraintsToExcel(string CheckConstraint, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConstraintRulesGetByCheckConstraints(CheckConstraint), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbycolumnids/csv")]
        [HttpGet("/export/JSONServer/constraintrulesgetbycolumnids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByColumnIdsToCSV(long? ColumnId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConstraintRulesGetByColumnIds(ColumnId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbycolumnids/excel")]
        [HttpGet("/export/JSONServer/constraintrulesgetbycolumnids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByColumnIdsToExcel(long? ColumnId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConstraintRulesGetByColumnIds(ColumnId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbycomments/csv")]
        [HttpGet("/export/JSONServer/constraintrulesgetbycomments/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByCommentsToCSV(string Comment, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConstraintRulesGetByComments(Comment), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbycomments/excel")]
        [HttpGet("/export/JSONServer/constraintrulesgetbycomments/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByCommentsToExcel(string Comment, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConstraintRulesGetByComments(Comment), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbyids/csv")]
        [HttpGet("/export/JSONServer/constraintrulesgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByIdsToCSV(long? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConstraintRulesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbyids/excel")]
        [HttpGet("/export/JSONServer/constraintrulesgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByIdsToExcel(long? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConstraintRulesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbynames/csv")]
        [HttpGet("/export/JSONServer/constraintrulesgetbynames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByNamesToCSV(string Name, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConstraintRulesGetByNames(Name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbynames/excel")]
        [HttpGet("/export/JSONServer/constraintrulesgetbynames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByNamesToExcel(string Name, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConstraintRulesGetByNames(Name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbyprojectids/csv")]
        [HttpGet("/export/JSONServer/constraintrulesgetbyprojectids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByProjectIdsToCSV(long? ProjectId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConstraintRulesGetByProjectIds(ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbyprojectids/excel")]
        [HttpGet("/export/JSONServer/constraintrulesgetbyprojectids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByProjectIdsToExcel(long? ProjectId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConstraintRulesGetByProjectIds(ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbyprojectnames/csv")]
        [HttpGet("/export/JSONServer/constraintrulesgetbyprojectnames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByProjectNamesToCSV(string ProjectName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConstraintRulesGetByProjectNames(ProjectName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbyprojectnames/excel")]
        [HttpGet("/export/JSONServer/constraintrulesgetbyprojectnames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByProjectNamesToExcel(string ProjectName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConstraintRulesGetByProjectNames(ProjectName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbytableids/csv")]
        [HttpGet("/export/JSONServer/constraintrulesgetbytableids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByTableIdsToCSV(long? TableId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConstraintRulesGetByTableIds(TableId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbytableids/excel")]
        [HttpGet("/export/JSONServer/constraintrulesgetbytableids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByTableIdsToExcel(long? TableId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConstraintRulesGetByTableIds(TableId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbytablenames/csv")]
        [HttpGet("/export/JSONServer/constraintrulesgetbytablenames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByTableNamesToCSV(string TableName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConstraintRulesGetByTableNames(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesgetbytablenames/excel")]
        [HttpGet("/export/JSONServer/constraintrulesgetbytablenames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesGetByTableNamesToExcel(string TableName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConstraintRulesGetByTableNames(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesinserts/csv")]
        [HttpGet("/export/JSONServer/constraintrulesinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesInsertsToCSV(string Name, string Comment, string CheckConstraint, string AddWithCheck, string AddWithNoCheck, long? ColumnId, string TableName, string ProjectName, long? TableId, long? ProjectId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConstraintRulesInserts(Name, Comment, CheckConstraint, AddWithCheck, AddWithNoCheck, ColumnId, TableName, ProjectName, TableId, ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesinserts/excel")]
        [HttpGet("/export/JSONServer/constraintrulesinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesInsertsToExcel(string Name, string Comment, string CheckConstraint, string AddWithCheck, string AddWithNoCheck, long? ColumnId, string TableName, string ProjectName, long? TableId, long? ProjectId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConstraintRulesInserts(Name, Comment, CheckConstraint, AddWithCheck, AddWithNoCheck, ColumnId, TableName, ProjectName, TableId, ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesupdates/csv")]
        [HttpGet("/export/JSONServer/constraintrulesupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesUpdatesToCSV(long? Id, string Name, string Comment, string CheckConstraint, string AddWithCheck, string AddWithNoCheck, long? ColumnId, string TableName, string ProjectName, long? TableId, long? ProjectId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetConstraintRulesUpdates(Id, Name, Comment, CheckConstraint, AddWithCheck, AddWithNoCheck, ColumnId, TableName, ProjectName, TableId, ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/constraintrulesupdates/excel")]
        [HttpGet("/export/JSONServer/constraintrulesupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportConstraintRulesUpdatesToExcel(long? Id, string Name, string Comment, string CheckConstraint, string AddWithCheck, string AddWithNoCheck, long? ColumnId, string TableName, string ProjectName, long? TableId, long? ProjectId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetConstraintRulesUpdates(Id, Name, Comment, CheckConstraint, AddWithCheck, AddWithNoCheck, ColumnId, TableName, ProjectName, TableId, ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetalls/csv")]
        [HttpGet("/export/JSONServer/countrygetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetalls/excel")]
        [HttpGet("/export/JSONServer/countrygetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyabbreviations/csv")]
        [HttpGet("/export/JSONServer/countrygetbyabbreviations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByAbbreviationsToCSV(string Abbreviation, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByAbbreviations(Abbreviation), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyabbreviations/excel")]
        [HttpGet("/export/JSONServer/countrygetbyabbreviations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByAbbreviationsToExcel(string Abbreviation, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByAbbreviations(Abbreviation), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyareas/csv")]
        [HttpGet("/export/JSONServer/countrygetbyareas/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByAreasToCSV(string Area, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByAreas(Area), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyareas/excel")]
        [HttpGet("/export/JSONServer/countrygetbyareas/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByAreasToExcel(string Area, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByAreas(Area), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbybarcodes/csv")]
        [HttpGet("/export/JSONServer/countrygetbybarcodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByBarcodesToCSV(string Barcode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByBarcodes(Barcode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbybarcodes/excel")]
        [HttpGet("/export/JSONServer/countrygetbybarcodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByBarcodesToExcel(string Barcode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByBarcodes(Barcode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbycallingcodes/csv")]
        [HttpGet("/export/JSONServer/countrygetbycallingcodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByCallingCodesToCSV(string CallingCode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByCallingCodes(CallingCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbycallingcodes/excel")]
        [HttpGet("/export/JSONServer/countrygetbycallingcodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByCallingCodesToExcel(string CallingCode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByCallingCodes(CallingCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbycities/csv")]
        [HttpGet("/export/JSONServer/countrygetbycities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByCitiesToCSV(string City, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByCities(City), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbycities/excel")]
        [HttpGet("/export/JSONServer/countrygetbycities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByCitiesToExcel(string City, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByCities(City), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbycontinents/csv")]
        [HttpGet("/export/JSONServer/countrygetbycontinents/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByContinentsToCSV(string Continent, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByContinents(Continent), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbycontinents/excel")]
        [HttpGet("/export/JSONServer/countrygetbycontinents/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByContinentsToExcel(string Continent, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByContinents(Continent), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbycostlines/csv")]
        [HttpGet("/export/JSONServer/countrygetbycostlines/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByCostLinesToCSV(string CostLine, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByCostLines(CostLine), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbycostlines/excel")]
        [HttpGet("/export/JSONServer/countrygetbycostlines/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByCostLinesToExcel(string CostLine, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByCostLines(CostLine), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbycurrencycodes/csv")]
        [HttpGet("/export/JSONServer/countrygetbycurrencycodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByCurrencyCodesToCSV(string CurrencyCode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByCurrencyCodes(CurrencyCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbycurrencycodes/excel")]
        [HttpGet("/export/JSONServer/countrygetbycurrencycodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByCurrencyCodesToExcel(string CurrencyCode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByCurrencyCodes(CurrencyCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbycurrencynames/csv")]
        [HttpGet("/export/JSONServer/countrygetbycurrencynames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByCurrencyNamesToCSV(string CurrencyName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByCurrencyNames(CurrencyName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbycurrencynames/excel")]
        [HttpGet("/export/JSONServer/countrygetbycurrencynames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByCurrencyNamesToExcel(string CurrencyName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByCurrencyNames(CurrencyName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbydefaultlanguageids/csv")]
        [HttpGet("/export/JSONServer/countrygetbydefaultlanguageids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByDefaultLanguageIdsToCSV(int? DefaultLanguageId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByDefaultLanguageIds(DefaultLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbydefaultlanguageids/excel")]
        [HttpGet("/export/JSONServer/countrygetbydefaultlanguageids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByDefaultLanguageIdsToExcel(int? DefaultLanguageId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByDefaultLanguageIds(DefaultLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbydensities/csv")]
        [HttpGet("/export/JSONServer/countrygetbydensities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByDensitiesToCSV(string Density, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByDensities(Density), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbydensities/excel")]
        [HttpGet("/export/JSONServer/countrygetbydensities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByDensitiesToExcel(string Density, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByDensities(Density), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbydishes/csv")]
        [HttpGet("/export/JSONServer/countrygetbydishes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByDishesToCSV(string Dish, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByDishes(Dish), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbydishes/excel")]
        [HttpGet("/export/JSONServer/countrygetbydishes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByDishesToExcel(string Dish, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByDishes(Dish), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbydomaintlds/csv")]
        [HttpGet("/export/JSONServer/countrygetbydomaintlds/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByDomainTldsToCSV(string DomainTld, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByDomainTlds(DomainTld), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbydomaintlds/excel")]
        [HttpGet("/export/JSONServer/countrygetbydomaintlds/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByDomainTldsToExcel(string DomainTld, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByDomainTlds(DomainTld), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyeasts/csv")]
        [HttpGet("/export/JSONServer/countrygetbyeasts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByEastsToCSV(string East, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByEasts(East), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyeasts/excel")]
        [HttpGet("/export/JSONServer/countrygetbyeasts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByEastsToExcel(string East, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByEasts(East), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyelevations/csv")]
        [HttpGet("/export/JSONServer/countrygetbyelevations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByElevationsToCSV(string Elevation, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByElevations(Elevation), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyelevations/excel")]
        [HttpGet("/export/JSONServer/countrygetbyelevations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByElevationsToExcel(string Elevation, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByElevations(Elevation), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyexpectancies/csv")]
        [HttpGet("/export/JSONServer/countrygetbyexpectancies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByExpectanciesToCSV(string Expectancy, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByExpectancies(Expectancy), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyexpectancies/excel")]
        [HttpGet("/export/JSONServer/countrygetbyexpectancies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByExpectanciesToExcel(string Expectancy, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByExpectancies(Expectancy), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyflagbase64s/csv")]
        [HttpGet("/export/JSONServer/countrygetbyflagbase64s/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByFlagBase64SToCSV(string FlagBase64, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByFlagBase64S(FlagBase64), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyflagbase64s/excel")]
        [HttpGet("/export/JSONServer/countrygetbyflagbase64s/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByFlagBase64SToExcel(string FlagBase64, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByFlagBase64S(FlagBase64), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbygovernments/csv")]
        [HttpGet("/export/JSONServer/countrygetbygovernments/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByGovernmentsToCSV(string Government, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByGovernments(Government), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbygovernments/excel")]
        [HttpGet("/export/JSONServer/countrygetbygovernments/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByGovernmentsToExcel(string Government, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByGovernments(Government), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyheights/csv")]
        [HttpGet("/export/JSONServer/countrygetbyheights/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByHeightsToCSV(string Height, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByHeights(Height), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyheights/excel")]
        [HttpGet("/export/JSONServer/countrygetbyheights/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByHeightsToExcel(string Height, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByHeights(Height), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyids/csv")]
        [HttpGet("/export/JSONServer/countrygetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyids/excel")]
        [HttpGet("/export/JSONServer/countrygetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyindependences/csv")]
        [HttpGet("/export/JSONServer/countrygetbyindependences/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByIndependencesToCSV(string Independence, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByIndependences(Independence), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyindependences/excel")]
        [HttpGet("/export/JSONServer/countrygetbyindependences/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByIndependencesToExcel(string Independence, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByIndependences(Independence), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyisos/csv")]
        [HttpGet("/export/JSONServer/countrygetbyisos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByIsosToCSV(string Iso, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByIsos(Iso), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyisos/excel")]
        [HttpGet("/export/JSONServer/countrygetbyisos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByIsosToExcel(string Iso, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByIsos(Iso), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbylandlockeds/csv")]
        [HttpGet("/export/JSONServer/countrygetbylandlockeds/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByLandlockedsToCSV(string Landlocked, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByLandlockeds(Landlocked), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbylandlockeds/excel")]
        [HttpGet("/export/JSONServer/countrygetbylandlockeds/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByLandlockedsToExcel(string Landlocked, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByLandlockeds(Landlocked), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbylanguagesjsons/csv")]
        [HttpGet("/export/JSONServer/countrygetbylanguagesjsons/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByLanguagesJsonsToCSV(string LanguagesJSON, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByLanguagesJsons(LanguagesJSON), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbylanguagesjsons/excel")]
        [HttpGet("/export/JSONServer/countrygetbylanguagesjsons/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByLanguagesJsonsToExcel(string LanguagesJSON, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByLanguagesJsons(LanguagesJSON), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbylocations/csv")]
        [HttpGet("/export/JSONServer/countrygetbylocations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByLocationsToCSV(string Location, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByLocations(Location), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbylocations/excel")]
        [HttpGet("/export/JSONServer/countrygetbylocations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByLocationsToExcel(string Location, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByLocations(Location), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbynames/csv")]
        [HttpGet("/export/JSONServer/countrygetbynames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByNamesToCSV(string Name, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByNames(Name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbynames/excel")]
        [HttpGet("/export/JSONServer/countrygetbynames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByNamesToExcel(string Name, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByNames(Name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbynorths/csv")]
        [HttpGet("/export/JSONServer/countrygetbynorths/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByNorthsToCSV(string North, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByNorths(North), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbynorths/excel")]
        [HttpGet("/export/JSONServer/countrygetbynorths/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByNorthsToExcel(string North, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByNorths(North), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbypopulations/csv")]
        [HttpGet("/export/JSONServer/countrygetbypopulations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByPopulationsToCSV(string Population, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByPopulations(Population), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbypopulations/excel")]
        [HttpGet("/export/JSONServer/countrygetbypopulations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByPopulationsToExcel(string Population, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByPopulations(Population), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyreligions/csv")]
        [HttpGet("/export/JSONServer/countrygetbyreligions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByReligionsToCSV(string Religion, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByReligions(Religion), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyreligions/excel")]
        [HttpGet("/export/JSONServer/countrygetbyreligions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByReligionsToExcel(string Religion, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByReligions(Religion), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyshortnames/csv")]
        [HttpGet("/export/JSONServer/countrygetbyshortnames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByShortNamesToCSV(string ShortName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByShortNames(ShortName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbyshortnames/excel")]
        [HttpGet("/export/JSONServer/countrygetbyshortnames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByShortNamesToExcel(string ShortName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByShortNames(ShortName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbysouths/csv")]
        [HttpGet("/export/JSONServer/countrygetbysouths/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetBySouthsToCSV(string South, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetBySouths(South), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbysouths/excel")]
        [HttpGet("/export/JSONServer/countrygetbysouths/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetBySouthsToExcel(string South, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetBySouths(South), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbysymbols/csv")]
        [HttpGet("/export/JSONServer/countrygetbysymbols/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetBySymbolsToCSV(string Symbol, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetBySymbols(Symbol), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbysymbols/excel")]
        [HttpGet("/export/JSONServer/countrygetbysymbols/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetBySymbolsToExcel(string Symbol, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetBySymbols(Symbol), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbytemperatures/csv")]
        [HttpGet("/export/JSONServer/countrygetbytemperatures/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByTemperaturesToCSV(string Temperature, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByTemperatures(Temperature), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbytemperatures/excel")]
        [HttpGet("/export/JSONServer/countrygetbytemperatures/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByTemperaturesToExcel(string Temperature, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByTemperatures(Temperature), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbywests/csv")]
        [HttpGet("/export/JSONServer/countrygetbywests/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByWestsToCSV(string West, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryGetByWests(West), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrygetbywests/excel")]
        [HttpGet("/export/JSONServer/countrygetbywests/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryGetByWestsToExcel(string West, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryGetByWests(West), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countryinserts/csv")]
        [HttpGet("/export/JSONServer/countryinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryInsertsToCSV(string Name, string ShortName, string Temperature, string Area, string Religion, string Location, string Population, string Density, string Symbol, string Abbreviation, string FlagBase64, string Expectancy, string Dish, string LanguagesJSON, string Landlocked, string Iso, string Independence, string Government, string North, string South, string West, string East, string Elevation, string DomainTld, string CurrencyName, string CurrencyCode, string CostLine, string Continent, string City, string CallingCode, string Barcode, string Height, int? DefaultLanguageId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryInserts(Name, ShortName, Temperature, Area, Religion, Location, Population, Density, Symbol, Abbreviation, FlagBase64, Expectancy, Dish, LanguagesJSON, Landlocked, Iso, Independence, Government, North, South, West, East, Elevation, DomainTld, CurrencyName, CurrencyCode, CostLine, Continent, City, CallingCode, Barcode, Height, DefaultLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countryinserts/excel")]
        [HttpGet("/export/JSONServer/countryinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryInsertsToExcel(string Name, string ShortName, string Temperature, string Area, string Religion, string Location, string Population, string Density, string Symbol, string Abbreviation, string FlagBase64, string Expectancy, string Dish, string LanguagesJSON, string Landlocked, string Iso, string Independence, string Government, string North, string South, string West, string East, string Elevation, string DomainTld, string CurrencyName, string CurrencyCode, string CostLine, string Continent, string City, string CallingCode, string Barcode, string Height, int? DefaultLanguageId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryInserts(Name, ShortName, Temperature, Area, Religion, Location, Population, Density, Symbol, Abbreviation, FlagBase64, Expectancy, Dish, LanguagesJSON, Landlocked, Iso, Independence, Government, North, South, West, East, Elevation, DomainTld, CurrencyName, CurrencyCode, CostLine, Continent, City, CallingCode, Barcode, Height, DefaultLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrylanguagesgetalls/csv")]
        [HttpGet("/export/JSONServer/countrylanguagesgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryLanguagesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrylanguagesgetalls/excel")]
        [HttpGet("/export/JSONServer/countrylanguagesgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryLanguagesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrylanguagesgetbycountryids/csv")]
        [HttpGet("/export/JSONServer/countrylanguagesgetbycountryids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesGetByCountryIdsToCSV(int? CountryId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryLanguagesGetByCountryIds(CountryId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrylanguagesgetbycountryids/excel")]
        [HttpGet("/export/JSONServer/countrylanguagesgetbycountryids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesGetByCountryIdsToExcel(int? CountryId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryLanguagesGetByCountryIds(CountryId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrylanguagesgetbycountrynames/csv")]
        [HttpGet("/export/JSONServer/countrylanguagesgetbycountrynames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesGetByCountryNamesToCSV(string CountryName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryLanguagesGetByCountryNames(CountryName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrylanguagesgetbycountrynames/excel")]
        [HttpGet("/export/JSONServer/countrylanguagesgetbycountrynames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesGetByCountryNamesToExcel(string CountryName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryLanguagesGetByCountryNames(CountryName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrylanguagesgetbyids/csv")]
        [HttpGet("/export/JSONServer/countrylanguagesgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryLanguagesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrylanguagesgetbyids/excel")]
        [HttpGet("/export/JSONServer/countrylanguagesgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryLanguagesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrylanguagesgetbylanguagenames/csv")]
        [HttpGet("/export/JSONServer/countrylanguagesgetbylanguagenames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesGetByLanguageNamesToCSV(string LanguageName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryLanguagesGetByLanguageNames(LanguageName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrylanguagesgetbylanguagenames/excel")]
        [HttpGet("/export/JSONServer/countrylanguagesgetbylanguagenames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesGetByLanguageNamesToExcel(string LanguageName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryLanguagesGetByLanguageNames(LanguageName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrylanguagesinserts/csv")]
        [HttpGet("/export/JSONServer/countrylanguagesinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesInsertsToCSV(int? CountryId, string CountryName, string LanguageName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryLanguagesInserts(CountryId, CountryName, LanguageName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrylanguagesinserts/excel")]
        [HttpGet("/export/JSONServer/countrylanguagesinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesInsertsToExcel(int? CountryId, string CountryName, string LanguageName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryLanguagesInserts(CountryId, CountryName, LanguageName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrylanguagesupdates/csv")]
        [HttpGet("/export/JSONServer/countrylanguagesupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesUpdatesToCSV(int? Id, int? CountryId, string CountryName, string LanguageName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryLanguagesUpdates(Id, CountryId, CountryName, LanguageName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countrylanguagesupdates/excel")]
        [HttpGet("/export/JSONServer/countrylanguagesupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesUpdatesToExcel(int? Id, int? CountryId, string CountryName, string LanguageName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryLanguagesUpdates(Id, CountryId, CountryName, LanguageName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countryupdates/csv")]
        [HttpGet("/export/JSONServer/countryupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryUpdatesToCSV(int? Id, string Name, string ShortName, string Temperature, string Area, string Religion, string Location, string Population, string Density, string Symbol, string Abbreviation, string FlagBase64, string Expectancy, string Dish, string LanguagesJSON, string Landlocked, string Iso, string Independence, string Government, string North, string South, string West, string East, string Elevation, string DomainTld, string CurrencyName, string CurrencyCode, string CostLine, string Continent, string City, string CallingCode, string Barcode, string Height, int? DefaultLanguageId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryUpdates(Id, Name, ShortName, Temperature, Area, Religion, Location, Population, Density, Symbol, Abbreviation, FlagBase64, Expectancy, Dish, LanguagesJSON, Landlocked, Iso, Independence, Government, North, South, West, East, Elevation, DomainTld, CurrencyName, CurrencyCode, CostLine, Continent, City, CallingCode, Barcode, Height, DefaultLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/countryupdates/excel")]
        [HttpGet("/export/JSONServer/countryupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryUpdatesToExcel(int? Id, string Name, string ShortName, string Temperature, string Area, string Religion, string Location, string Population, string Density, string Symbol, string Abbreviation, string FlagBase64, string Expectancy, string Dish, string LanguagesJSON, string Landlocked, string Iso, string Independence, string Government, string North, string South, string West, string East, string Elevation, string DomainTld, string CurrencyName, string CurrencyCode, string CostLine, string Continent, string City, string CallingCode, string Barcode, string Height, int? DefaultLanguageId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryUpdates(Id, Name, ShortName, Temperature, Area, Religion, Location, Population, Density, Symbol, Abbreviation, FlagBase64, Expectancy, Dish, LanguagesJSON, Landlocked, Iso, Independence, Government, North, South, West, East, Elevation, DomainTld, CurrencyName, CurrencyCode, CostLine, Continent, City, CallingCode, Barcode, Height, DefaultLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetalls/csv")]
        [HttpGet("/export/JSONServer/designschemesgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignSchemesGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignSchemesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetalls/excel")]
        [HttpGet("/export/JSONServer/designschemesgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignSchemesGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignSchemesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsbodybackgrounds/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsbodybackgrounds/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsBodyBackgroundsToCSV(string colors_body_background, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsBodyBackgrounds(colors_body_background), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsbodybackgrounds/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsbodybackgrounds/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsBodyBackgroundsToExcel(string colors_body_background, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsBodyBackgrounds(colors_body_background), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsbodyfonts/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsbodyfonts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsBodyFontsToCSV(string colors_body_font, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsBodyFonts(colors_body_font), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsbodyfonts/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsbodyfonts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsBodyFontsToExcel(string colors_body_font, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsBodyFonts(colors_body_font), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsbodyfontcolors/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsbodyfontcolors/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsBodyFontColorsToCSV(string colors_body_font_color, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsBodyFontColors(colors_body_font_color), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsbodyfontcolors/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsbodyfontcolors/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsBodyFontColorsToExcel(string colors_body_font_color, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsBodyFontColors(colors_body_font_color), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsbodyfontsizes/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsbodyfontsizes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsBodyFontSizesToCSV(int? colors_body_font_size, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsBodyFontSizes(colors_body_font_size), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsbodyfontsizes/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsbodyfontsizes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsBodyFontSizesToExcel(int? colors_body_font_size, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsBodyFontSizes(colors_body_font_size), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor1brightnesses/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor1brightnesses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor1BrightnessesToCSV(decimal? colors_color1_brightness, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor1Brightnesses(colors_color1_brightness), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor1brightnesses/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor1brightnesses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor1BrightnessesToExcel(decimal? colors_color1_brightness, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor1Brightnesses(colors_color1_brightness), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor1isdarks/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor1isdarks/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor1IsdarksToCSV(string colors_color1_isDark, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor1Isdarks(colors_color1_isDark), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor1isdarks/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor1isdarks/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor1IsdarksToExcel(string colors_color1_isDark, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor1Isdarks(colors_color1_isDark), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor1rgbs/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor1rgbs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor1RgbsToCSV(int? colors_color1_rgb, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor1Rgbs(colors_color1_rgb), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor1rgbs/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor1rgbs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor1RgbsToExcel(int? colors_color1_rgb, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor1Rgbs(colors_color1_rgb), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor2brightnesses/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor2brightnesses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor2BrightnessesToCSV(decimal? colors_color2_brightness, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor2Brightnesses(colors_color2_brightness), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor2brightnesses/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor2brightnesses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor2BrightnessesToExcel(decimal? colors_color2_brightness, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor2Brightnesses(colors_color2_brightness), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor2hexes/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor2hexes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor2HexesToCSV(int? colors_color2_hex, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor2Hexes(colors_color2_hex), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor2hexes/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor2hexes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor2HexesToExcel(int? colors_color2_hex, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor2Hexes(colors_color2_hex), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor2isdarks/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor2isdarks/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor2IsdarksToCSV(string colors_color2_isDark, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor2Isdarks(colors_color2_isDark), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor2isdarks/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor2isdarks/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor2IsdarksToExcel(string colors_color2_isDark, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor2Isdarks(colors_color2_isDark), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor2rgbs/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor2rgbs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor2RgbsToCSV(int? colors_color2_rgb, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor2Rgbs(colors_color2_rgb), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor2rgbs/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor2rgbs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor2RgbsToExcel(int? colors_color2_rgb, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor2Rgbs(colors_color2_rgb), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor3brightnesses/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor3brightnesses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor3BrightnessesToCSV(decimal? colors_color3_brightness, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor3Brightnesses(colors_color3_brightness), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor3brightnesses/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor3brightnesses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor3BrightnessesToExcel(decimal? colors_color3_brightness, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor3Brightnesses(colors_color3_brightness), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor3hexes/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor3hexes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor3HexesToCSV(int? colors_color3_hex, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor3Hexes(colors_color3_hex), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor3hexes/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor3hexes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor3HexesToExcel(int? colors_color3_hex, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor3Hexes(colors_color3_hex), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor3isdarks/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor3isdarks/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor3IsdarksToCSV(string colors_color3_isDark, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor3Isdarks(colors_color3_isDark), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor3isdarks/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor3isdarks/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor3IsdarksToExcel(string colors_color3_isDark, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor3Isdarks(colors_color3_isDark), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor3rgbs/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor3rgbs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor3RgbsToCSV(int? colors_color3_rgb, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor3Rgbs(colors_color3_rgb), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor3rgbs/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor3rgbs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor3RgbsToExcel(int? colors_color3_rgb, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor3Rgbs(colors_color3_rgb), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor4brightnesses/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor4brightnesses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor4BrightnessesToCSV(decimal? colors_color4_brightness, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor4Brightnesses(colors_color4_brightness), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor4brightnesses/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor4brightnesses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor4BrightnessesToExcel(decimal? colors_color4_brightness, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor4Brightnesses(colors_color4_brightness), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor4hexes/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor4hexes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor4HexesToCSV(int? colors_color4_hex, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor4Hexes(colors_color4_hex), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor4hexes/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor4hexes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor4HexesToExcel(int? colors_color4_hex, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor4Hexes(colors_color4_hex), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor4isdarks/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor4isdarks/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor4IsdarksToCSV(string colors_color4_isDark, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor4Isdarks(colors_color4_isDark), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor4isdarks/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor4isdarks/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor4IsdarksToExcel(string colors_color4_isDark, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor4Isdarks(colors_color4_isDark), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor4rgbs/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor4rgbs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor4RgbsToCSV(int? colors_color4_rgb, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor4Rgbs(colors_color4_rgb), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor4rgbs/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor4rgbs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor4RgbsToExcel(int? colors_color4_rgb, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor4Rgbs(colors_color4_rgb), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor5brightnesses/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor5brightnesses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor5BrightnessesToCSV(decimal? colors_color5_brightness, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor5Brightnesses(colors_color5_brightness), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor5brightnesses/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor5brightnesses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor5BrightnessesToExcel(decimal? colors_color5_brightness, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor5Brightnesses(colors_color5_brightness), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor5hexes/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor5hexes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor5HexesToCSV(int? colors_color5_hex, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor5Hexes(colors_color5_hex), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor5hexes/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor5hexes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor5HexesToExcel(int? colors_color5_hex, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor5Hexes(colors_color5_hex), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor5isdarks/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor5isdarks/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor5IsdarksToCSV(string colors_color5_isDark, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor5Isdarks(colors_color5_isDark), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor5isdarks/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor5isdarks/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor5IsdarksToExcel(string colors_color5_isDark, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor5Isdarks(colors_color5_isDark), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor5rgbs/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor5rgbs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor5RgbsToCSV(int? colors_color5_rgb, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsColor5Rgbs(colors_color5_rgb), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor5rgbs/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscolor5rgbs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsColor5RgbsToExcel(int? colors_color5_rgb, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsColor5Rgbs(colors_color5_rgb), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscontentbackgrounds/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscontentbackgrounds/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsContentBackgroundsToCSV(string colors_content_background, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsContentBackgrounds(colors_content_background), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscontentbackgrounds/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscontentbackgrounds/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsContentBackgroundsToExcel(string colors_content_background, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsContentBackgrounds(colors_content_background), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscontentbordercolors/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscontentbordercolors/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsContentBorderColorsToCSV(string colors_content_border_color, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsContentBorderColors(colors_content_border_color), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscontentbordercolors/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscontentbordercolors/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsContentBorderColorsToExcel(string colors_content_border_color, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsContentBorderColors(colors_content_border_color), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscontentmargins/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscontentmargins/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsContentMarginsToCSV(string colors_content_margin, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsContentMargins(colors_content_margin), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscontentmargins/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscontentmargins/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsContentMarginsToExcel(string colors_content_margin, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsContentMargins(colors_content_margin), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscontentpaddings/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscontentpaddings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsContentPaddingsToCSV(string colors_content_padding, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsContentPaddings(colors_content_padding), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscontentpaddings/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscontentpaddings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsContentPaddingsToExcel(string colors_content_padding, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsContentPaddings(colors_content_padding), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscontenttextcolors/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscontenttextcolors/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsContentTextColorsToCSV(string colors_content_text_color, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsContentTextColors(colors_content_text_color), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorscontenttextcolors/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorscontenttextcolors/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsContentTextColorsToExcel(string colors_content_text_color, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsContentTextColors(colors_content_text_color), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsfooterbackgrounds/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsfooterbackgrounds/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsFooterBackgroundsToCSV(string colors_footer_background, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsFooterBackgrounds(colors_footer_background), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsfooterbackgrounds/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsfooterbackgrounds/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsFooterBackgroundsToExcel(string colors_footer_background, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsFooterBackgrounds(colors_footer_background), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsfooterfontsizes/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsfooterfontsizes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsFooterFontSizesToCSV(int? colors_footer_font_size, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsFooterFontSizes(colors_footer_font_size), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsfooterfontsizes/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsfooterfontsizes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsFooterFontSizesToExcel(int? colors_footer_font_size, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsFooterFontSizes(colors_footer_font_size), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsfootermargins/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsfootermargins/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsFooterMarginsToCSV(string colors_footer_margin, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsFooterMargins(colors_footer_margin), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsfootermargins/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsfootermargins/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsFooterMarginsToExcel(string colors_footer_margin, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsFooterMargins(colors_footer_margin), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsfooterpaddings/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsfooterpaddings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsFooterPaddingsToCSV(string colors_footer_padding, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsFooterPaddings(colors_footer_padding), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsfooterpaddings/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsfooterpaddings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsFooterPaddingsToExcel(string colors_footer_padding, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsFooterPaddings(colors_footer_padding), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsgroups/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsgroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsGroupsToCSV(string colors_group, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsGroups(colors_group), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsgroups/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsgroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsGroupsToExcel(string colors_group, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsGroups(colors_group), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsheaderbackgrounds/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsheaderbackgrounds/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsHeaderBackgroundsToCSV(string colors_header_background, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsHeaderBackgrounds(colors_header_background), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsheaderbackgrounds/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsheaderbackgrounds/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsHeaderBackgroundsToExcel(string colors_header_background, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsHeaderBackgrounds(colors_header_background), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsheaderfontsizes/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsheaderfontsizes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsHeaderFontSizesToCSV(int? colors_header_font_size, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsHeaderFontSizes(colors_header_font_size), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsheaderfontsizes/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsheaderfontsizes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsHeaderFontSizesToExcel(int? colors_header_font_size, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsHeaderFontSizes(colors_header_font_size), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsheadermargins/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsheadermargins/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsHeaderMarginsToCSV(string colors_header_margin, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsHeaderMargins(colors_header_margin), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsheadermargins/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsheadermargins/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsHeaderMarginsToExcel(string colors_header_margin, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsHeaderMargins(colors_header_margin), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsheaderpaddings/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsheaderpaddings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsHeaderPaddingsToCSV(string colors_header_padding, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsHeaderPaddings(colors_header_padding), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsheaderpaddings/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsheaderpaddings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsHeaderPaddingsToExcel(string colors_header_padding, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsHeaderPaddings(colors_header_padding), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsmenubackgrounds/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsmenubackgrounds/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsMenuBackgroundsToCSV(string colors_menu_background, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsMenuBackgrounds(colors_menu_background), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsmenubackgrounds/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsmenubackgrounds/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsMenuBackgroundsToExcel(string colors_menu_background, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsMenuBackgrounds(colors_menu_background), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsmenufontsizes/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsmenufontsizes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsMenuFontSizesToCSV(int? colors_menu_font_size, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsMenuFontSizes(colors_menu_font_size), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsmenufontsizes/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsmenufontsizes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsMenuFontSizesToExcel(int? colors_menu_font_size, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsMenuFontSizes(colors_menu_font_size), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsmenumargins/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsmenumargins/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsMenuMarginsToCSV(string colors_menu_margin, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsMenuMargins(colors_menu_margin), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsmenumargins/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsmenumargins/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsMenuMarginsToExcel(string colors_menu_margin, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsMenuMargins(colors_menu_margin), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsmenupaddings/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsmenupaddings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsMenuPaddingsToCSV(string colors_menu_padding, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsMenuPaddings(colors_menu_padding), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorsmenupaddings/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorsmenupaddings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsMenuPaddingsToExcel(string colors_menu_padding, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsMenuPaddings(colors_menu_padding), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorswrapperbackgrounds/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorswrapperbackgrounds/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsWrapperBackgroundsToCSV(string colors_wrapper_background, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsWrapperBackgrounds(colors_wrapper_background), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorswrapperbackgrounds/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorswrapperbackgrounds/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsWrapperBackgroundsToExcel(string colors_wrapper_background, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsWrapperBackgrounds(colors_wrapper_background), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorswrapperfontsizes/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorswrapperfontsizes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsWrapperFontSizesToCSV(int? colors_wrapper_font_size, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsWrapperFontSizes(colors_wrapper_font_size), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorswrapperfontsizes/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorswrapperfontsizes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsWrapperFontSizesToExcel(int? colors_wrapper_font_size, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsWrapperFontSizes(colors_wrapper_font_size), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorswrappermargins/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorswrappermargins/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsWrapperMarginsToCSV(string colors_wrapper_margin, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsWrapperMargins(colors_wrapper_margin), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorswrappermargins/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorswrappermargins/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsWrapperMarginsToExcel(string colors_wrapper_margin, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsWrapperMargins(colors_wrapper_margin), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorswrapperpaddings/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorswrapperpaddings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsWrapperPaddingsToCSV(string colors_wrapper_padding, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsWrapperPaddings(colors_wrapper_padding), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorswrapperpaddings/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorswrapperpaddings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsWrapperPaddingsToExcel(string colors_wrapper_padding, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsWrapperPaddings(colors_wrapper_padding), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorswrapperwidths/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorswrapperwidths/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsWrapperWidthsToCSV(int? colors_wrapper_width, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignschemesgetbycolorsWrapperWidths(colors_wrapper_width), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbycolorswrapperwidths/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbycolorswrapperwidths/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignschemesgetbycolorsWrapperWidthsToExcel(int? colors_wrapper_width, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignschemesgetbycolorsWrapperWidths(colors_wrapper_width), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbyids/csv")]
        [HttpGet("/export/JSONServer/designschemesgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignSchemesGetByIdsToCSV(string colors_body_background, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignSchemesGetByIds(colors_body_background), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesgetbyids/excel")]
        [HttpGet("/export/JSONServer/designschemesgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignSchemesGetByIdsToExcel(string colors_body_background, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignSchemesGetByIds(colors_body_background), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesinserts/csv")]
        [HttpGet("/export/JSONServer/designschemesinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignSchemesInsertsToCSV(string colors_body_background, string colors_body_font, int? colors_body_font_size, string colors_body_font_color, string colors_content_text_color, string colors_content_border_color, string colors_content_background, string colors_content_padding, string colors_content_margin, string colors_menu_padding, int? colors_menu_font_size, string colors_menu_background, string colors_menu_margin, string colors_header_padding, int? colors_header_font_size, string colors_header_background, string colors_header_margin, string colors_footer_padding, int? colors_footer_font_size, string colors_footer_background, string colors_footer_margin, string colors_wrapper_padding, int? colors_wrapper_font_size, string colors_wrapper_background, string colors_wrapper_margin, string colors_group, int? colors_color1_rgb, decimal? colors_color1_brightness, string colors_color1_isDark, int? colors_color2_hex, int? colors_color2_rgb, decimal? colors_color2_brightness, string colors_color2_isDark, int? colors_color3_hex, int? colors_color3_rgb, decimal? colors_color3_brightness, string colors_color3_isDark, int? colors_color4_hex, int? colors_color4_rgb, decimal? colors_color4_brightness, string colors_color4_isDark, int? colors_color5_hex, int? colors_color5_rgb, decimal? colors_color5_brightness, string colors_color5_isDark, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignSchemesInserts(colors_body_background, colors_body_font, colors_body_font_size, colors_body_font_color, colors_content_text_color, colors_content_border_color, colors_content_background, colors_content_padding, colors_content_margin, colors_menu_padding, colors_menu_font_size, colors_menu_background, colors_menu_margin, colors_header_padding, colors_header_font_size, colors_header_background, colors_header_margin, colors_footer_padding, colors_footer_font_size, colors_footer_background, colors_footer_margin, colors_wrapper_padding, colors_wrapper_font_size, colors_wrapper_background, colors_wrapper_margin, colors_group, colors_color1_rgb, colors_color1_brightness, colors_color1_isDark, colors_color2_hex, colors_color2_rgb, colors_color2_brightness, colors_color2_isDark, colors_color3_hex, colors_color3_rgb, colors_color3_brightness, colors_color3_isDark, colors_color4_hex, colors_color4_rgb, colors_color4_brightness, colors_color4_isDark, colors_color5_hex, colors_color5_rgb, colors_color5_brightness, colors_color5_isDark), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesinserts/excel")]
        [HttpGet("/export/JSONServer/designschemesinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignSchemesInsertsToExcel(string colors_body_background, string colors_body_font, int? colors_body_font_size, string colors_body_font_color, string colors_content_text_color, string colors_content_border_color, string colors_content_background, string colors_content_padding, string colors_content_margin, string colors_menu_padding, int? colors_menu_font_size, string colors_menu_background, string colors_menu_margin, string colors_header_padding, int? colors_header_font_size, string colors_header_background, string colors_header_margin, string colors_footer_padding, int? colors_footer_font_size, string colors_footer_background, string colors_footer_margin, string colors_wrapper_padding, int? colors_wrapper_font_size, string colors_wrapper_background, string colors_wrapper_margin, string colors_group, int? colors_color1_rgb, decimal? colors_color1_brightness, string colors_color1_isDark, int? colors_color2_hex, int? colors_color2_rgb, decimal? colors_color2_brightness, string colors_color2_isDark, int? colors_color3_hex, int? colors_color3_rgb, decimal? colors_color3_brightness, string colors_color3_isDark, int? colors_color4_hex, int? colors_color4_rgb, decimal? colors_color4_brightness, string colors_color4_isDark, int? colors_color5_hex, int? colors_color5_rgb, decimal? colors_color5_brightness, string colors_color5_isDark, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignSchemesInserts(colors_body_background, colors_body_font, colors_body_font_size, colors_body_font_color, colors_content_text_color, colors_content_border_color, colors_content_background, colors_content_padding, colors_content_margin, colors_menu_padding, colors_menu_font_size, colors_menu_background, colors_menu_margin, colors_header_padding, colors_header_font_size, colors_header_background, colors_header_margin, colors_footer_padding, colors_footer_font_size, colors_footer_background, colors_footer_margin, colors_wrapper_padding, colors_wrapper_font_size, colors_wrapper_background, colors_wrapper_margin, colors_group, colors_color1_rgb, colors_color1_brightness, colors_color1_isDark, colors_color2_hex, colors_color2_rgb, colors_color2_brightness, colors_color2_isDark, colors_color3_hex, colors_color3_rgb, colors_color3_brightness, colors_color3_isDark, colors_color4_hex, colors_color4_rgb, colors_color4_brightness, colors_color4_isDark, colors_color5_hex, colors_color5_rgb, colors_color5_brightness, colors_color5_isDark), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesupdates/csv")]
        [HttpGet("/export/JSONServer/designschemesupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignSchemesUpdatesToCSV(string colors_body_background, string colors_body_font, int? colors_body_font_size, string colors_body_font_color, string colors_content_text_color, string colors_content_border_color, string colors_content_background, string colors_content_padding, string colors_content_margin, string colors_menu_padding, int? colors_menu_font_size, string colors_menu_background, string colors_menu_margin, string colors_header_padding, int? colors_header_font_size, string colors_header_background, string colors_header_margin, string colors_footer_padding, int? colors_footer_font_size, string colors_footer_background, string colors_footer_margin, string colors_wrapper_padding, int? colors_wrapper_font_size, string colors_wrapper_background, string colors_wrapper_margin, int? colors_wrapper_width, string colors_group, int? colors_color1_rgb, decimal? colors_color1_brightness, string colors_color1_isDark, int? colors_color2_hex, int? colors_color2_rgb, decimal? colors_color2_brightness, string colors_color2_isDark, int? colors_color3_hex, int? colors_color3_rgb, decimal? colors_color3_brightness, string colors_color3_isDark, int? colors_color4_hex, int? colors_color4_rgb, decimal? colors_color4_brightness, string colors_color4_isDark, int? colors_color5_hex, int? colors_color5_rgb, decimal? colors_color5_brightness, string colors_color5_isDark, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignSchemesUpdates(colors_body_background, colors_body_font, colors_body_font_size, colors_body_font_color, colors_content_text_color, colors_content_border_color, colors_content_background, colors_content_padding, colors_content_margin, colors_menu_padding, colors_menu_font_size, colors_menu_background, colors_menu_margin, colors_header_padding, colors_header_font_size, colors_header_background, colors_header_margin, colors_footer_padding, colors_footer_font_size, colors_footer_background, colors_footer_margin, colors_wrapper_padding, colors_wrapper_font_size, colors_wrapper_background, colors_wrapper_margin, colors_wrapper_width, colors_group, colors_color1_rgb, colors_color1_brightness, colors_color1_isDark, colors_color2_hex, colors_color2_rgb, colors_color2_brightness, colors_color2_isDark, colors_color3_hex, colors_color3_rgb, colors_color3_brightness, colors_color3_isDark, colors_color4_hex, colors_color4_rgb, colors_color4_brightness, colors_color4_isDark, colors_color5_hex, colors_color5_rgb, colors_color5_brightness, colors_color5_isDark), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/designschemesupdates/excel")]
        [HttpGet("/export/JSONServer/designschemesupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignSchemesUpdatesToExcel(string colors_body_background, string colors_body_font, int? colors_body_font_size, string colors_body_font_color, string colors_content_text_color, string colors_content_border_color, string colors_content_background, string colors_content_padding, string colors_content_margin, string colors_menu_padding, int? colors_menu_font_size, string colors_menu_background, string colors_menu_margin, string colors_header_padding, int? colors_header_font_size, string colors_header_background, string colors_header_margin, string colors_footer_padding, int? colors_footer_font_size, string colors_footer_background, string colors_footer_margin, string colors_wrapper_padding, int? colors_wrapper_font_size, string colors_wrapper_background, string colors_wrapper_margin, int? colors_wrapper_width, string colors_group, int? colors_color1_rgb, decimal? colors_color1_brightness, string colors_color1_isDark, int? colors_color2_hex, int? colors_color2_rgb, decimal? colors_color2_brightness, string colors_color2_isDark, int? colors_color3_hex, int? colors_color3_rgb, decimal? colors_color3_brightness, string colors_color3_isDark, int? colors_color4_hex, int? colors_color4_rgb, decimal? colors_color4_brightness, string colors_color4_isDark, int? colors_color5_hex, int? colors_color5_rgb, decimal? colors_color5_brightness, string colors_color5_isDark, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignSchemesUpdates(colors_body_background, colors_body_font, colors_body_font_size, colors_body_font_color, colors_content_text_color, colors_content_border_color, colors_content_background, colors_content_padding, colors_content_margin, colors_menu_padding, colors_menu_font_size, colors_menu_background, colors_menu_margin, colors_header_padding, colors_header_font_size, colors_header_background, colors_header_margin, colors_footer_padding, colors_footer_font_size, colors_footer_background, colors_footer_margin, colors_wrapper_padding, colors_wrapper_font_size, colors_wrapper_background, colors_wrapper_margin, colors_wrapper_width, colors_group, colors_color1_rgb, colors_color1_brightness, colors_color1_isDark, colors_color2_hex, colors_color2_rgb, colors_color2_brightness, colors_color2_isDark, colors_color3_hex, colors_color3_rgb, colors_color3_brightness, colors_color3_isDark, colors_color4_hex, colors_color4_rgb, colors_color4_brightness, colors_color4_isDark, colors_color5_hex, colors_color5_rgb, colors_color5_brightness, colors_color5_isDark), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicegroupsgetalls/csv")]
        [HttpGet("/export/JSONServer/devicegroupsgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDeviceGroupsGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDeviceGroupsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicegroupsgetalls/excel")]
        [HttpGet("/export/JSONServer/devicegroupsgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDeviceGroupsGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDeviceGroupsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicegroupsgetbyids/csv")]
        [HttpGet("/export/JSONServer/devicegroupsgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDeviceGroupsGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDeviceGroupsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicegroupsgetbyids/excel")]
        [HttpGet("/export/JSONServer/devicegroupsgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDeviceGroupsGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDeviceGroupsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicegroupsgetbynames/csv")]
        [HttpGet("/export/JSONServer/devicegroupsgetbynames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDeviceGroupsGetByNamesToCSV(string Name, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDeviceGroupsGetByNames(Name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicegroupsgetbynames/excel")]
        [HttpGet("/export/JSONServer/devicegroupsgetbynames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDeviceGroupsGetByNamesToExcel(string Name, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDeviceGroupsGetByNames(Name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicegroupsinserts/csv")]
        [HttpGet("/export/JSONServer/devicegroupsinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDeviceGroupsInsertsToCSV(string Name, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDeviceGroupsInserts(Name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicegroupsinserts/excel")]
        [HttpGet("/export/JSONServer/devicegroupsinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDeviceGroupsInsertsToExcel(string Name, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDeviceGroupsInserts(Name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicegroupsupdates/csv")]
        [HttpGet("/export/JSONServer/devicegroupsupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDeviceGroupsUpdatesToCSV(int? Id, string Name, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDeviceGroupsUpdates(Id, Name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicegroupsupdates/excel")]
        [HttpGet("/export/JSONServer/devicegroupsupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDeviceGroupsUpdatesToExcel(int? Id, string Name, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDeviceGroupsUpdates(Id, Name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetalls/csv")]
        [HttpGet("/export/JSONServer/devicesgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDevicesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetalls/excel")]
        [HttpGet("/export/JSONServer/devicesgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDevicesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbybrands/csv")]
        [HttpGet("/export/JSONServer/devicesgetbybrands/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByBrandsToCSV(string Brand, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDevicesGetByBrands(Brand), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbybrands/excel")]
        [HttpGet("/export/JSONServer/devicesgetbybrands/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByBrandsToExcel(string Brand, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDevicesGetByBrands(Brand), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbydevicegroupids/csv")]
        [HttpGet("/export/JSONServer/devicesgetbydevicegroupids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByDeviceGroupIdsToCSV(int? DeviceGroupId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDevicesGetByDeviceGroupIds(DeviceGroupId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbydevicegroupids/excel")]
        [HttpGet("/export/JSONServer/devicesgetbydevicegroupids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByDeviceGroupIdsToExcel(int? DeviceGroupId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDevicesGetByDeviceGroupIds(DeviceGroupId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbydevicenames/csv")]
        [HttpGet("/export/JSONServer/devicesgetbydevicenames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByDeviceNamesToCSV(string DeviceName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDevicesGetByDeviceNames(DeviceName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbydevicenames/excel")]
        [HttpGet("/export/JSONServer/devicesgetbydevicenames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByDeviceNamesToExcel(string DeviceName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDevicesGetByDeviceNames(DeviceName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbyheights/csv")]
        [HttpGet("/export/JSONServer/devicesgetbyheights/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByHeightsToCSV(int? Height, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDevicesGetByHeights(Height), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbyheights/excel")]
        [HttpGet("/export/JSONServer/devicesgetbyheights/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByHeightsToExcel(int? Height, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDevicesGetByHeights(Height), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbyids/csv")]
        [HttpGet("/export/JSONServer/devicesgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDevicesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbyids/excel")]
        [HttpGet("/export/JSONServer/devicesgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDevicesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbyimgs/csv")]
        [HttpGet("/export/JSONServer/devicesgetbyimgs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByImgsToCSV(string Img, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDevicesGetByImgs(Img), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbyimgs/excel")]
        [HttpGet("/export/JSONServer/devicesgetbyimgs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByImgsToExcel(string Img, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDevicesGetByImgs(Img), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbyislandscapes/csv")]
        [HttpGet("/export/JSONServer/devicesgetbyislandscapes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByIsLandScapesToCSV(bool? IsLandScape, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDevicesGetByIsLandScapes(IsLandScape), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbyislandscapes/excel")]
        [HttpGet("/export/JSONServer/devicesgetbyislandscapes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByIsLandScapesToExcel(bool? IsLandScape, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDevicesGetByIsLandScapes(IsLandScape), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbyresulation1xes/csv")]
        [HttpGet("/export/JSONServer/devicesgetbyresulation1xes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByResulation1xesToCSV(string Resulation1x, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDevicesGetByResulation1xes(Resulation1x), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbyresulation1xes/excel")]
        [HttpGet("/export/JSONServer/devicesgetbyresulation1xes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByResulation1xesToExcel(string Resulation1x, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDevicesGetByResulation1xes(Resulation1x), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbyresulation2xes/csv")]
        [HttpGet("/export/JSONServer/devicesgetbyresulation2xes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByResulation2xesToCSV(string Resulation2x, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDevicesGetByResulation2xes(Resulation2x), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbyresulation2xes/excel")]
        [HttpGet("/export/JSONServer/devicesgetbyresulation2xes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByResulation2xesToExcel(string Resulation2x, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDevicesGetByResulation2xes(Resulation2x), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbyresulation3xes/csv")]
        [HttpGet("/export/JSONServer/devicesgetbyresulation3xes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByResulation3xesToCSV(string Resulation3x, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDevicesGetByResulation3xes(Resulation3x), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbyresulation3xes/excel")]
        [HttpGet("/export/JSONServer/devicesgetbyresulation3xes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByResulation3xesToExcel(string Resulation3x, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDevicesGetByResulation3xes(Resulation3x), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbywidths/csv")]
        [HttpGet("/export/JSONServer/devicesgetbywidths/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByWidthsToCSV(int? Width, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDevicesGetByWidths(Width), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesgetbywidths/excel")]
        [HttpGet("/export/JSONServer/devicesgetbywidths/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesGetByWidthsToExcel(int? Width, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDevicesGetByWidths(Width), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesinserts/csv")]
        [HttpGet("/export/JSONServer/devicesinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesInsertsToCSV(string DeviceName, int? DeviceGroupId, int? Width, int? Height, string Brand, string Img, bool? IsLandScape, string Resulation1x, string Resulation2x, string Resulation3x, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDevicesInserts(DeviceName, DeviceGroupId, Width, Height, Brand, Img, IsLandScape, Resulation1x, Resulation2x, Resulation3x), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesinserts/excel")]
        [HttpGet("/export/JSONServer/devicesinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesInsertsToExcel(string DeviceName, int? DeviceGroupId, int? Width, int? Height, string Brand, string Img, bool? IsLandScape, string Resulation1x, string Resulation2x, string Resulation3x, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDevicesInserts(DeviceName, DeviceGroupId, Width, Height, Brand, Img, IsLandScape, Resulation1x, Resulation2x, Resulation3x), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesupdates/csv")]
        [HttpGet("/export/JSONServer/devicesupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesUpdatesToCSV(int? Id, string DeviceName, int? DeviceGroupId, int? Width, int? Height, string Brand, string Img, bool? IsLandScape, string Resulation1x, string Resulation2x, string Resulation3x, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDevicesUpdates(Id, DeviceName, DeviceGroupId, Width, Height, Brand, Img, IsLandScape, Resulation1x, Resulation2x, Resulation3x), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/devicesupdates/excel")]
        [HttpGet("/export/JSONServer/devicesupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesUpdatesToExcel(int? Id, string DeviceName, int? DeviceGroupId, int? Width, int? Height, string Brand, string Img, bool? IsLandScape, string Resulation1x, string Resulation2x, string Resulation3x, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDevicesUpdates(Id, DeviceName, DeviceGroupId, Width, Height, Brand, Img, IsLandScape, Resulation1x, Resulation2x, Resulation3x), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamicqueuelists/csv")]
        [HttpGet("/export/JSONServer/dynamicqueuelists/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicQueueListsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDynamicQueueLists(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamicqueuelists/excel")]
        [HttpGet("/export/JSONServer/dynamicqueuelists/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicQueueListsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDynamicQueueLists(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamicspacereports/csv")]
        [HttpGet("/export/JSONServer/dynamicspacereports/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicSpaceReportsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDynamicSpaceReports(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamicspacereports/excel")]
        [HttpGet("/export/JSONServer/dynamicspacereports/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicSpaceReportsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDynamicSpaceReports(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamictablecounts/csv")]
        [HttpGet("/export/JSONServer/dynamictablecounts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicTableCountsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDynamicTableCounts(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamictablecounts/excel")]
        [HttpGet("/export/JSONServer/dynamictablecounts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicTableCountsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDynamicTableCounts(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamictableforeignkeys/csv")]
        [HttpGet("/export/JSONServer/dynamictableforeignkeys/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicTableForeignKeysToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDynamicTableForeignKeys(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamictableforeignkeys/excel")]
        [HttpGet("/export/JSONServer/dynamictableforeignkeys/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicTableForeignKeysToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDynamicTableForeignKeys(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamictablereports/csv")]
        [HttpGet("/export/JSONServer/dynamictablereports/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicTableReportsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDynamicTableReports(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamictablereports/excel")]
        [HttpGet("/export/JSONServer/dynamictablereports/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicTableReportsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDynamicTableReports(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamictablesearchalls/csv")]
        [HttpGet("/export/JSONServer/dynamictablesearchalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicTableSearchAllsToCSV(string SearchStr, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDynamicTableSearchAlls(SearchStr), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamictablesearchalls/excel")]
        [HttpGet("/export/JSONServer/dynamictablesearchalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicTableSearchAllsToExcel(string SearchStr, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDynamicTableSearchAlls(SearchStr), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamictablesearchtables/csv")]
        [HttpGet("/export/JSONServer/dynamictablesearchtables/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicTableSearchTablesToCSV(string SearchStr, string TableName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDynamicTableSearchTables(SearchStr, TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamictablesearchtables/excel")]
        [HttpGet("/export/JSONServer/dynamictablesearchtables/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicTableSearchTablesToExcel(string SearchStr, string TableName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDynamicTableSearchTables(SearchStr, TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamictransactionreports/csv")]
        [HttpGet("/export/JSONServer/dynamictransactionreports/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicTransactionReportsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDynamicTransactionReports(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamictransactionreports/excel")]
        [HttpGet("/export/JSONServer/dynamictransactionreports/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicTransactionReportsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDynamicTransactionReports(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamicviewdtos/csv")]
        [HttpGet("/export/JSONServer/dynamicviewdtos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicViewDtosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDynamicViewDtos(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamicviewdtos/excel")]
        [HttpGet("/export/JSONServer/dynamicviewdtos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicViewDtosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDynamicViewDtos(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamicviewreports/csv")]
        [HttpGet("/export/JSONServer/dynamicviewreports/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicViewReportsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDynamicViewReports(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/dynamicviewreports/excel")]
        [HttpGet("/export/JSONServer/dynamicviewreports/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDynamicViewReportsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDynamicViewReports(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetalls/csv")]
        [HttpGet("/export/JSONServer/fieldsgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetalls/excel")]
        [HttpGet("/export/JSONServer/fieldsgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbycolumnnames/csv")]
        [HttpGet("/export/JSONServer/fieldsgetbycolumnnames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByColumnNamesToCSV(string ColumnName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsGetByColumnNames(ColumnName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbycolumnnames/excel")]
        [HttpGet("/export/JSONServer/fieldsgetbycolumnnames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByColumnNamesToExcel(string ColumnName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsGetByColumnNames(ColumnName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbycomments/csv")]
        [HttpGet("/export/JSONServer/fieldsgetbycomments/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByCommentsToCSV(string Comment, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsGetByComments(Comment), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbycomments/excel")]
        [HttpGet("/export/JSONServer/fieldsgetbycomments/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByCommentsToExcel(string Comment, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsGetByComments(Comment), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbyconstraintrules/csv")]
        [HttpGet("/export/JSONServer/fieldsgetbyconstraintrules/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByConstraintRulesToCSV(string ConstraintRules, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsGetByConstraintRules(ConstraintRules), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbyconstraintrules/excel")]
        [HttpGet("/export/JSONServer/fieldsgetbyconstraintrules/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByConstraintRulesToExcel(string ConstraintRules, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsGetByConstraintRules(ConstraintRules), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbydbtypes/csv")]
        [HttpGet("/export/JSONServer/fieldsgetbydbtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByDbTypesToCSV(string DbType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsGetByDbTypes(DbType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbydbtypes/excel")]
        [HttpGet("/export/JSONServer/fieldsgetbydbtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByDbTypesToExcel(string DbType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsGetByDbTypes(DbType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbydefaultvalues/csv")]
        [HttpGet("/export/JSONServer/fieldsgetbydefaultvalues/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByDefaultValuesToCSV(string DefaultValue, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsGetByDefaultValues(DefaultValue), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbydefaultvalues/excel")]
        [HttpGet("/export/JSONServer/fieldsgetbydefaultvalues/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByDefaultValuesToExcel(string DefaultValue, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsGetByDefaultValues(DefaultValue), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbyids/csv")]
        [HttpGet("/export/JSONServer/fieldsgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByIdsToCSV(long? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbyids/excel")]
        [HttpGet("/export/JSONServer/fieldsgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByIdsToExcel(long? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbyisnullables/csv")]
        [HttpGet("/export/JSONServer/fieldsgetbyisnullables/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByIsNullablesToCSV(bool? IsNullable, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsGetByIsNullables(IsNullable), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbyisnullables/excel")]
        [HttpGet("/export/JSONServer/fieldsgetbyisnullables/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByIsNullablesToExcel(bool? IsNullable, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsGetByIsNullables(IsNullable), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbyisprimaries/csv")]
        [HttpGet("/export/JSONServer/fieldsgetbyisprimaries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByIsPrimariesToCSV(bool? IsPrimary, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsGetByIsPrimaries(IsPrimary), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbyisprimaries/excel")]
        [HttpGet("/export/JSONServer/fieldsgetbyisprimaries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByIsPrimariesToExcel(bool? IsPrimary, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsGetByIsPrimaries(IsPrimary), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbymaxlengths/csv")]
        [HttpGet("/export/JSONServer/fieldsgetbymaxlengths/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByMaxLengthsToCSV(int? MaxLength, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsGetByMaxLengths(MaxLength), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbymaxlengths/excel")]
        [HttpGet("/export/JSONServer/fieldsgetbymaxlengths/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByMaxLengthsToExcel(int? MaxLength, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsGetByMaxLengths(MaxLength), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbyprimitivetypes/csv")]
        [HttpGet("/export/JSONServer/fieldsgetbyprimitivetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByPrimitiveTypesToCSV(string PrimitiveType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsGetByPrimitiveTypes(PrimitiveType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbyprimitivetypes/excel")]
        [HttpGet("/export/JSONServer/fieldsgetbyprimitivetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByPrimitiveTypesToExcel(string PrimitiveType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsGetByPrimitiveTypes(PrimitiveType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbyprojectids/csv")]
        [HttpGet("/export/JSONServer/fieldsgetbyprojectids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByProjectIdsToCSV(long? ProjectId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsGetByProjectIds(ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbyprojectids/excel")]
        [HttpGet("/export/JSONServer/fieldsgetbyprojectids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByProjectIdsToExcel(long? ProjectId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsGetByProjectIds(ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbyprojectnames/csv")]
        [HttpGet("/export/JSONServer/fieldsgetbyprojectnames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByProjectNamesToCSV(string ProjectName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsGetByProjectNames(ProjectName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbyprojectnames/excel")]
        [HttpGet("/export/JSONServer/fieldsgetbyprojectnames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByProjectNamesToExcel(string ProjectName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsGetByProjectNames(ProjectName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbytableids/csv")]
        [HttpGet("/export/JSONServer/fieldsgetbytableids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByTableIdsToCSV(long? TableId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsGetByTableIds(TableId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbytableids/excel")]
        [HttpGet("/export/JSONServer/fieldsgetbytableids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByTableIdsToExcel(long? TableId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsGetByTableIds(TableId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbytablenames/csv")]
        [HttpGet("/export/JSONServer/fieldsgetbytablenames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByTableNamesToCSV(string TableName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsGetByTableNames(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsgetbytablenames/excel")]
        [HttpGet("/export/JSONServer/fieldsgetbytablenames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsGetByTableNamesToExcel(string TableName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsGetByTableNames(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsinserts/csv")]
        [HttpGet("/export/JSONServer/fieldsinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsInsertsToCSV(string ColumnName, string DbType, string PrimitiveType, bool? IsNullable, int? MaxLength, string ConstraintRules, bool? IsPrimary, string Comment, string DefaultValue, string TableName, string ProjectName, long? TableId, long? ProjectId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsInserts(ColumnName, DbType, PrimitiveType, IsNullable, MaxLength, ConstraintRules, IsPrimary, Comment, DefaultValue, TableName, ProjectName, TableId, ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsinserts/excel")]
        [HttpGet("/export/JSONServer/fieldsinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsInsertsToExcel(string ColumnName, string DbType, string PrimitiveType, bool? IsNullable, int? MaxLength, string ConstraintRules, bool? IsPrimary, string Comment, string DefaultValue, string TableName, string ProjectName, long? TableId, long? ProjectId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsInserts(ColumnName, DbType, PrimitiveType, IsNullable, MaxLength, ConstraintRules, IsPrimary, Comment, DefaultValue, TableName, ProjectName, TableId, ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsupdates/csv")]
        [HttpGet("/export/JSONServer/fieldsupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsUpdatesToCSV(long? Id, string ColumnName, string DbType, string PrimitiveType, bool? IsNullable, int? MaxLength, string ConstraintRules, bool? IsPrimary, string Comment, string DefaultValue, string TableName, string ProjectName, long? TableId, long? ProjectId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFieldsUpdates(Id, ColumnName, DbType, PrimitiveType, IsNullable, MaxLength, ConstraintRules, IsPrimary, Comment, DefaultValue, TableName, ProjectName, TableId, ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/fieldsupdates/excel")]
        [HttpGet("/export/JSONServer/fieldsupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsUpdatesToExcel(long? Id, string ColumnName, string DbType, string PrimitiveType, bool? IsNullable, int? MaxLength, string ConstraintRules, bool? IsPrimary, string Comment, string DefaultValue, string TableName, string ProjectName, long? TableId, long? ProjectId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFieldsUpdates(Id, ColumnName, DbType, PrimitiveType, IsNullable, MaxLength, ConstraintRules, IsPrimary, Comment, DefaultValue, TableName, ProjectName, TableId, ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetalls/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRulesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetalls/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRulesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbycolumnids/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbycolumnids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByColumnIdsToCSV(long? ColumnId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRulesGetByColumnIds(ColumnId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbycolumnids/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbycolumnids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByColumnIdsToExcel(long? ColumnId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRulesGetByColumnIds(ColumnId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbycolumnnames/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbycolumnnames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByColumnNamesToCSV(string ColumnName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRulesGetByColumnNames(ColumnName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbycolumnnames/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbycolumnnames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByColumnNamesToExcel(string ColumnName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRulesGetByColumnNames(ColumnName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyconstraintids/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyconstraintids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByConstraintIdsToCSV(long? ConstraintId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRulesGetByConstraintIds(ConstraintId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyconstraintids/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyconstraintids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByConstraintIdsToExcel(long? ConstraintId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRulesGetByConstraintIds(ConstraintId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbydeleterules/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbydeleterules/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByDeleteRulesToCSV(int? DeleteRule, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRulesGetByDeleteRules(DeleteRule), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbydeleterules/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbydeleterules/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByDeleteRulesToExcel(int? DeleteRule, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRulesGetByDeleteRules(DeleteRule), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyids/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByIdsToCSV(long? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRulesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyids/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByIdsToExcel(long? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRulesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyprojectids/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyprojectids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByProjectIdsToCSV(long? ProjectId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRulesGetByProjectIds(ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyprojectids/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyprojectids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByProjectIdsToExcel(long? ProjectId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRulesGetByProjectIds(ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyprojectnames/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyprojectnames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByProjectNamesToCSV(string ProjectName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRulesGetByProjectNames(ProjectName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyprojectnames/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyprojectnames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByProjectNamesToExcel(string ProjectName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRulesGetByProjectNames(ProjectName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyreferencedcolumndbtypecompares/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyreferencedcolumndbtypecompares/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByReferencedColumnDbTypeComparesToCSV(string ReferencedColumnDbTypeCompare, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRulesGetByReferencedColumnDbTypeCompares(ReferencedColumnDbTypeCompare), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyreferencedcolumndbtypecompares/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyreferencedcolumndbtypecompares/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByReferencedColumnDbTypeComparesToExcel(string ReferencedColumnDbTypeCompare, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRulesGetByReferencedColumnDbTypeCompares(ReferencedColumnDbTypeCompare), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyreferencedcolumnnames/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyreferencedcolumnnames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByReferencedColumnNamesToCSV(string ReferencedColumnName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRulesGetByReferencedColumnNames(ReferencedColumnName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyreferencedcolumnnames/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyreferencedcolumnnames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByReferencedColumnNamesToExcel(string ReferencedColumnName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRulesGetByReferencedColumnNames(ReferencedColumnName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyreferencedtablenames/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyreferencedtablenames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByReferencedTableNamesToCSV(string ReferencedTableName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRulesGetByReferencedTableNames(ReferencedTableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyreferencedtablenames/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyreferencedtablenames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByReferencedTableNamesToExcel(string ReferencedTableName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRulesGetByReferencedTableNames(ReferencedTableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbytableids/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbytableids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByTableIdsToCSV(long? TableId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRulesGetByTableIds(TableId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbytableids/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbytableids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByTableIdsToExcel(long? TableId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRulesGetByTableIds(TableId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbytablenames/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbytablenames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByTableNamesToCSV(string TableName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRulesGetByTableNames(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbytablenames/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbytablenames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByTableNamesToExcel(string TableName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRulesGetByTableNames(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyupdaterules/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyupdaterules/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByUpdateRulesToCSV(int? UpdateRule, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRulesGetByUpdateRules(UpdateRule), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyupdaterules/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrulesgetbyupdaterules/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesGetByUpdateRulesToExcel(int? UpdateRule, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRulesGetByUpdateRules(UpdateRule), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesinserts/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrulesinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesInsertsToCSV(string ColumnName, string ReferencedTableName, string ReferencedColumnName, string ReferencedColumnDbTypeCompare, int? DeleteRule, int? UpdateRule, string TableName, string ProjectName, long? ConstraintId, long? ColumnId, long? ProjectId, long? TableId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRulesInserts(ColumnName, ReferencedTableName, ReferencedColumnName, ReferencedColumnDbTypeCompare, DeleteRule, UpdateRule, TableName, ProjectName, ConstraintId, ColumnId, ProjectId, TableId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesinserts/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrulesinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesInsertsToExcel(string ColumnName, string ReferencedTableName, string ReferencedColumnName, string ReferencedColumnDbTypeCompare, int? DeleteRule, int? UpdateRule, string TableName, string ProjectName, long? ConstraintId, long? ColumnId, long? ProjectId, long? TableId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRulesInserts(ColumnName, ReferencedTableName, ReferencedColumnName, ReferencedColumnDbTypeCompare, DeleteRule, UpdateRule, TableName, ProjectName, ConstraintId, ColumnId, ProjectId, TableId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesupdates/csv")]
        [HttpGet("/export/JSONServer/foreignkeyrulesupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesUpdatesToCSV(long? Id, string ColumnName, string ReferencedTableName, string ReferencedColumnName, string ReferencedColumnDbTypeCompare, int? DeleteRule, int? UpdateRule, string TableName, string ProjectName, long? ConstraintId, long? ColumnId, long? ProjectId, long? TableId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetForeignKeyRulesUpdates(Id, ColumnName, ReferencedTableName, ReferencedColumnName, ReferencedColumnDbTypeCompare, DeleteRule, UpdateRule, TableName, ProjectName, ConstraintId, ColumnId, ProjectId, TableId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/foreignkeyrulesupdates/excel")]
        [HttpGet("/export/JSONServer/foreignkeyrulesupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportForeignKeyRulesUpdatesToExcel(long? Id, string ColumnName, string ReferencedTableName, string ReferencedColumnName, string ReferencedColumnDbTypeCompare, int? DeleteRule, int? UpdateRule, string TableName, string ProjectName, long? ConstraintId, long? ColumnId, long? ProjectId, long? TableId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetForeignKeyRulesUpdates(Id, ColumnName, ReferencedTableName, ReferencedColumnName, ReferencedColumnDbTypeCompare, DeleteRule, UpdateRule, TableName, ProjectName, ConstraintId, ColumnId, ProjectId, TableId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getaccesscontrols/csv")]
        [HttpGet("/export/JSONServer/getaccesscontrols/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetAccessControlsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetAccessControls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getaccesscontrols/excel")]
        [HttpGet("/export/JSONServer/getaccesscontrols/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetAccessControlsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetAccessControls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getcolumns/csv")]
        [HttpGet("/export/JSONServer/getcolumns/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetColumnsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetColumns(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getcolumns/excel")]
        [HttpGet("/export/JSONServer/getcolumns/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetColumnsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetColumns(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getcolumnswithoutidentities/csv")]
        [HttpGet("/export/JSONServer/getcolumnswithoutidentities/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetColumnsWithOutIdentitiesToCSV(string name, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetColumnsWithOutIdentities(name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getcolumnswithoutidentities/excel")]
        [HttpGet("/export/JSONServer/getcolumnswithoutidentities/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetColumnsWithOutIdentitiesToExcel(string name, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetColumnsWithOutIdentities(name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getdependencies/csv")]
        [HttpGet("/export/JSONServer/getdependencies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetDependenciesToCSV(string Schema, string Table, string Column, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetDependencies(Schema, Table, Column), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getdependencies/excel")]
        [HttpGet("/export/JSONServer/getdependencies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetDependenciesToExcel(string Schema, string Table, string Column, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetDependencies(Schema, Table, Column), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getextendeds/csv")]
        [HttpGet("/export/JSONServer/getextendeds/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetExtendedsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetExtendeds(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getextendeds/excel")]
        [HttpGet("/export/JSONServer/getextendeds/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetExtendedsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetExtendeds(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getidentitylists/csv")]
        [HttpGet("/export/JSONServer/getidentitylists/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetIdentityListsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetIdentityLists(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getidentitylists/excel")]
        [HttpGet("/export/JSONServer/getidentitylists/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetIdentityListsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetIdentityLists(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getindexstats/csv")]
        [HttpGet("/export/JSONServer/getindexstats/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetIndexStatsToCSV(string table_name, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetIndexStats(table_name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getindexstats/excel")]
        [HttpGet("/export/JSONServer/getindexstats/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetIndexStatsToExcel(string table_name, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetIndexStats(table_name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getmodifydates/csv")]
        [HttpGet("/export/JSONServer/getmodifydates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetModifyDatesToCSV(string name, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetModifyDates(name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getmodifydates/excel")]
        [HttpGet("/export/JSONServer/getmodifydates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetModifyDatesToExcel(string name, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetModifyDates(name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getparameternames/csv")]
        [HttpGet("/export/JSONServer/getparameternames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetParameterNamesToCSV(string Procedure, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetParameterNames(Procedure), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getparameternames/excel")]
        [HttpGet("/export/JSONServer/getparameternames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetParameterNamesToExcel(string Procedure, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetParameterNames(Procedure), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getprocedurenames/csv")]
        [HttpGet("/export/JSONServer/getprocedurenames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetProcedureNamesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetProcedureNames(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getprocedurenames/excel")]
        [HttpGet("/export/JSONServer/getprocedurenames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetProcedureNamesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetProcedureNames(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getrequestparameternames/csv")]
        [HttpGet("/export/JSONServer/getrequestparameternames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetRequestParameterNamesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetRequestParameterNames(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getrequestparameternames/excel")]
        [HttpGet("/export/JSONServer/getrequestparameternames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetRequestParameterNamesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetRequestParameterNames(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getreturnparameternames/csv")]
        [HttpGet("/export/JSONServer/getreturnparameternames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetReturnParameterNamesToCSV(string ProcedureName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetReturnParameterNames(ProcedureName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getreturnparameternames/excel")]
        [HttpGet("/export/JSONServer/getreturnparameternames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetReturnParameterNamesToExcel(string ProcedureName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetReturnParameterNames(ProcedureName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getserverinfos/csv")]
        [HttpGet("/export/JSONServer/getserverinfos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetServerInfosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetServerInfos(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getserverinfos/excel")]
        [HttpGet("/export/JSONServer/getserverinfos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetServerInfosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetServerInfos(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getsplogs/csv")]
        [HttpGet("/export/JSONServer/getsplogs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetSpLogsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetSpLogs(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getsplogs/excel")]
        [HttpGet("/export/JSONServer/getsplogs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetSpLogsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetSpLogs(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getstoredproceduresforatables/csv")]
        [HttpGet("/export/JSONServer/getstoredproceduresforatables/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetStoredProceduresForATablesToCSV(string TableName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetStoredProceduresForATables(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getstoredproceduresforatables/excel")]
        [HttpGet("/export/JSONServer/getstoredproceduresforatables/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetStoredProceduresForATablesToExcel(string TableName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetStoredProceduresForATables(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/gettablecolumns/csv")]
        [HttpGet("/export/JSONServer/gettablecolumns/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetTableColumnsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetTableColumns(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/gettablecolumns/excel")]
        [HttpGet("/export/JSONServer/gettablecolumns/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetTableColumnsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetTableColumns(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/gettableinfos/csv")]
        [HttpGet("/export/JSONServer/gettableinfos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetTableInfosToCSV(string TableName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetTableInfos(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/gettableinfos/excel")]
        [HttpGet("/export/JSONServer/gettableinfos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetTableInfosToExcel(string TableName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetTableInfos(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/gettablenames/csv")]
        [HttpGet("/export/JSONServer/gettablenames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetTableNamesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetTableNames(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/gettablenames/excel")]
        [HttpGet("/export/JSONServer/gettablenames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetTableNamesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetTableNames(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/gettables/csv")]
        [HttpGet("/export/JSONServer/gettables/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetTablesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetTables(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/gettables/excel")]
        [HttpGet("/export/JSONServer/gettables/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetTablesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetTables(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/gettablesizes/csv")]
        [HttpGet("/export/JSONServer/gettablesizes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetTableSizesToCSV(string TableName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetTableSizes(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/gettablesizes/excel")]
        [HttpGet("/export/JSONServer/gettablesizes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetTableSizesToExcel(string TableName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetTableSizes(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getviewbackuphistories/csv")]
        [HttpGet("/export/JSONServer/getviewbackuphistories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetViewBackupHistoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetViewBackupHistories(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getviewbackuphistories/excel")]
        [HttpGet("/export/JSONServer/getviewbackuphistories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetViewBackupHistoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetViewBackupHistories(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getviewlists/csv")]
        [HttpGet("/export/JSONServer/getviewlists/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetViewListsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetGetViewLists(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/getviewlists/excel")]
        [HttpGet("/export/JSONServer/getviewlists/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportGetViewListsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetGetViewLists(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcategorygetalls/csv")]
        [HttpGet("/export/JSONServer/programmingcategorygetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCategoryGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCategoryGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcategorygetalls/excel")]
        [HttpGet("/export/JSONServer/programmingcategorygetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCategoryGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCategoryGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcategorygetbyids/csv")]
        [HttpGet("/export/JSONServer/programmingcategorygetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCategoryGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCategoryGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcategorygetbyids/excel")]
        [HttpGet("/export/JSONServer/programmingcategorygetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCategoryGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCategoryGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcategorygetbytypenames/csv")]
        [HttpGet("/export/JSONServer/programmingcategorygetbytypenames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCategoryGetByTypeNamesToCSV(string TypeName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCategoryGetByTypeNames(TypeName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcategorygetbytypenames/excel")]
        [HttpGet("/export/JSONServer/programmingcategorygetbytypenames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCategoryGetByTypeNamesToExcel(string TypeName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCategoryGetByTypeNames(TypeName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcategoryinserts/csv")]
        [HttpGet("/export/JSONServer/programmingcategoryinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCategoryInsertsToCSV(string TypeName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCategoryInserts(TypeName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcategoryinserts/excel")]
        [HttpGet("/export/JSONServer/programmingcategoryinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCategoryInsertsToExcel(string TypeName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCategoryInserts(TypeName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcategoryupdates/csv")]
        [HttpGet("/export/JSONServer/programmingcategoryupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCategoryUpdatesToCSV(int? Id, string TypeName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCategoryUpdates(Id, TypeName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcategoryupdates/excel")]
        [HttpGet("/export/JSONServer/programmingcategoryupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCategoryUpdatesToExcel(int? Id, string TypeName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCategoryUpdates(Id, TypeName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesgetalls/csv")]
        [HttpGet("/export/JSONServer/programmingcodesgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesgetalls/excel")]
        [HttpGet("/export/JSONServer/programmingcodesgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesgetbycodes/csv")]
        [HttpGet("/export/JSONServer/programmingcodesgetbycodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesGetByCodesToCSV(string Code, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodesGetByCodes(Code), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesgetbycodes/excel")]
        [HttpGet("/export/JSONServer/programmingcodesgetbycodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesGetByCodesToExcel(string Code, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodesGetByCodes(Code), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesgetbyexamplecodes/csv")]
        [HttpGet("/export/JSONServer/programmingcodesgetbyexamplecodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesGetByExampleCodesToCSV(string ExampleCodes, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodesGetByExampleCodes(ExampleCodes), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesgetbyexamplecodes/excel")]
        [HttpGet("/export/JSONServer/programmingcodesgetbyexamplecodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesGetByExampleCodesToExcel(string ExampleCodes, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodesGetByExampleCodes(ExampleCodes), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesgetbyids/csv")]
        [HttpGet("/export/JSONServer/programmingcodesgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesgetbyids/excel")]
        [HttpGet("/export/JSONServer/programmingcodesgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesgetbylanguagetypes/csv")]
        [HttpGet("/export/JSONServer/programmingcodesgetbylanguagetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesGetByLanguageTypesToCSV(int? LanguageType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodesGetByLanguageTypes(LanguageType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesgetbylanguagetypes/excel")]
        [HttpGet("/export/JSONServer/programmingcodesgetbylanguagetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesGetByLanguageTypesToExcel(int? LanguageType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodesGetByLanguageTypes(LanguageType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesgetbytargetlanguagecodes/csv")]
        [HttpGet("/export/JSONServer/programmingcodesgetbytargetlanguagecodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesGetByTargetLanguageCodesToCSV(string TargetLanguageCode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodesGetByTargetLanguageCodes(TargetLanguageCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesgetbytargetlanguagecodes/excel")]
        [HttpGet("/export/JSONServer/programmingcodesgetbytargetlanguagecodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesGetByTargetLanguageCodesToExcel(string TargetLanguageCode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodesGetByTargetLanguageCodes(TargetLanguageCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesgetbytargetlanguagetypes/csv")]
        [HttpGet("/export/JSONServer/programmingcodesgetbytargetlanguagetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesGetByTargetLanguageTypesToCSV(int? TargetLanguageType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodesGetByTargetLanguageTypes(TargetLanguageType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesgetbytargetlanguagetypes/excel")]
        [HttpGet("/export/JSONServer/programmingcodesgetbytargetlanguagetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesGetByTargetLanguageTypesToExcel(int? TargetLanguageType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodesGetByTargetLanguageTypes(TargetLanguageType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesinserts/csv")]
        [HttpGet("/export/JSONServer/programmingcodesinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesInsertsToCSV(int? LanguageType, string Code, int? TargetLanguageType, string TargetLanguageCode, string ExampleCodes, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodesInserts(LanguageType, Code, TargetLanguageType, TargetLanguageCode, ExampleCodes), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesinserts/excel")]
        [HttpGet("/export/JSONServer/programmingcodesinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesInsertsToExcel(int? LanguageType, string Code, int? TargetLanguageType, string TargetLanguageCode, string ExampleCodes, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodesInserts(LanguageType, Code, TargetLanguageType, TargetLanguageCode, ExampleCodes), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesupdates/csv")]
        [HttpGet("/export/JSONServer/programmingcodesupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesUpdatesToCSV(int? Id, int? LanguageType, string Code, int? TargetLanguageType, string TargetLanguageCode, string ExampleCodes, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodesUpdates(Id, LanguageType, Code, TargetLanguageType, TargetLanguageCode, ExampleCodes), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodesupdates/excel")]
        [HttpGet("/export/JSONServer/programmingcodesupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesUpdatesToExcel(int? Id, int? LanguageType, string Code, int? TargetLanguageType, string TargetLanguageCode, string ExampleCodes, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodesUpdates(Id, LanguageType, Code, TargetLanguageType, TargetLanguageCode, ExampleCodes), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodetemplatesgetalls/csv")]
        [HttpGet("/export/JSONServer/programmingcodetemplatesgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodeTemplatesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodetemplatesgetalls/excel")]
        [HttpGet("/export/JSONServer/programmingcodetemplatesgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodeTemplatesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodetemplatesgetbyids/csv")]
        [HttpGet("/export/JSONServer/programmingcodetemplatesgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodeTemplatesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodetemplatesgetbyids/excel")]
        [HttpGet("/export/JSONServer/programmingcodetemplatesgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodeTemplatesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodetemplatesgetbyprogramminglanguages/csv")]
        [HttpGet("/export/JSONServer/programmingcodetemplatesgetbyprogramminglanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesGetByProgrammingLanguagesToCSV(int? ProgrammingLanguage, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodeTemplatesGetByProgrammingLanguages(ProgrammingLanguage), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodetemplatesgetbyprogramminglanguages/excel")]
        [HttpGet("/export/JSONServer/programmingcodetemplatesgetbyprogramminglanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesGetByProgrammingLanguagesToExcel(int? ProgrammingLanguage, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodeTemplatesGetByProgrammingLanguages(ProgrammingLanguage), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodetemplatesgetbyreplacedfields/csv")]
        [HttpGet("/export/JSONServer/programmingcodetemplatesgetbyreplacedfields/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesGetByReplacedFieldsToCSV(string ReplacedFields, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodeTemplatesGetByReplacedFields(ReplacedFields), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodetemplatesgetbyreplacedfields/excel")]
        [HttpGet("/export/JSONServer/programmingcodetemplatesgetbyreplacedfields/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesGetByReplacedFieldsToExcel(string ReplacedFields, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodeTemplatesGetByReplacedFields(ReplacedFields), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodetemplatesgetbytemplates/csv")]
        [HttpGet("/export/JSONServer/programmingcodetemplatesgetbytemplates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesGetByTemplatesToCSV(string Template, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodeTemplatesGetByTemplates(Template), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodetemplatesgetbytemplates/excel")]
        [HttpGet("/export/JSONServer/programmingcodetemplatesgetbytemplates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesGetByTemplatesToExcel(string Template, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodeTemplatesGetByTemplates(Template), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodetemplatesinserts/csv")]
        [HttpGet("/export/JSONServer/programmingcodetemplatesinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesInsertsToCSV(int? ProgrammingLanguage, string Template, string ReplacedFields, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodeTemplatesInserts(ProgrammingLanguage, Template, ReplacedFields), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodetemplatesinserts/excel")]
        [HttpGet("/export/JSONServer/programmingcodetemplatesinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesInsertsToExcel(int? ProgrammingLanguage, string Template, string ReplacedFields, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodeTemplatesInserts(ProgrammingLanguage, Template, ReplacedFields), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodetemplatesupdates/csv")]
        [HttpGet("/export/JSONServer/programmingcodetemplatesupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesUpdatesToCSV(int? Id, int? ProgrammingLanguage, string Template, string ReplacedFields, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodeTemplatesUpdates(Id, ProgrammingLanguage, Template, ReplacedFields), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingcodetemplatesupdates/excel")]
        [HttpGet("/export/JSONServer/programmingcodetemplatesupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesUpdatesToExcel(int? Id, int? ProgrammingLanguage, string Template, string ReplacedFields, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodeTemplatesUpdates(Id, ProgrammingLanguage, Template, ReplacedFields), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingtechnologygetalls/csv")]
        [HttpGet("/export/JSONServer/programmingtechnologygetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologyGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingTechnologyGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingtechnologygetalls/excel")]
        [HttpGet("/export/JSONServer/programmingtechnologygetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologyGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingTechnologyGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingtechnologygetbycodefamilynames/csv")]
        [HttpGet("/export/JSONServer/programmingtechnologygetbycodefamilynames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologyGetByCodeFamilyNamesToCSV(string CodeFamilyName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingTechnologyGetByCodeFamilyNames(CodeFamilyName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingtechnologygetbycodefamilynames/excel")]
        [HttpGet("/export/JSONServer/programmingtechnologygetbycodefamilynames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologyGetByCodeFamilyNamesToExcel(string CodeFamilyName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingTechnologyGetByCodeFamilyNames(CodeFamilyName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingtechnologygetbycodetypes/csv")]
        [HttpGet("/export/JSONServer/programmingtechnologygetbycodetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologyGetByCodeTypesToCSV(string CodeType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingTechnologyGetByCodeTypes(CodeType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingtechnologygetbycodetypes/excel")]
        [HttpGet("/export/JSONServer/programmingtechnologygetbycodetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologyGetByCodeTypesToExcel(string CodeType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingTechnologyGetByCodeTypes(CodeType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingtechnologygetbyids/csv")]
        [HttpGet("/export/JSONServer/programmingtechnologygetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologyGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingTechnologyGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingtechnologygetbyids/excel")]
        [HttpGet("/export/JSONServer/programmingtechnologygetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologyGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingTechnologyGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingtechnologygetbyides/csv")]
        [HttpGet("/export/JSONServer/programmingtechnologygetbyides/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologyGetByIdesToCSV(string IDE, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingTechnologyGetByIdes(IDE), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingtechnologygetbyides/excel")]
        [HttpGet("/export/JSONServer/programmingtechnologygetbyides/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologyGetByIdesToExcel(string IDE, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingTechnologyGetByIdes(IDE), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingtechnologyinserts/csv")]
        [HttpGet("/export/JSONServer/programmingtechnologyinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologyInsertsToCSV(string CodeFamilyName, string CodeType, string IDE, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingTechnologyInserts(CodeFamilyName, CodeType, IDE), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingtechnologyinserts/excel")]
        [HttpGet("/export/JSONServer/programmingtechnologyinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologyInsertsToExcel(string CodeFamilyName, string CodeType, string IDE, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingTechnologyInserts(CodeFamilyName, CodeType, IDE), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingtechnologyupdates/csv")]
        [HttpGet("/export/JSONServer/programmingtechnologyupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologyUpdatesToCSV(int? Id, string CodeFamilyName, string CodeType, string IDE, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingTechnologyUpdates(Id, CodeFamilyName, CodeType, IDE), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/programmingtechnologyupdates/excel")]
        [HttpGet("/export/JSONServer/programmingtechnologyupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologyUpdatesToExcel(int? Id, string CodeFamilyName, string CodeType, string IDE, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingTechnologyUpdates(Id, CodeFamilyName, CodeType, IDE), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategorygetalls/csv")]
        [HttpGet("/export/JSONServer/projectcategorygetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoryGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectCategoryGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategorygetalls/excel")]
        [HttpGet("/export/JSONServer/projectcategorygetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoryGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectCategoryGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategorygetbycategorynames/csv")]
        [HttpGet("/export/JSONServer/projectcategorygetbycategorynames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoryGetByCategoryNamesToCSV(string CategoryName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectCategoryGetByCategoryNames(CategoryName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategorygetbycategorynames/excel")]
        [HttpGet("/export/JSONServer/projectcategorygetbycategorynames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoryGetByCategoryNamesToExcel(string CategoryName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectCategoryGetByCategoryNames(CategoryName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategorygetbycategorynametrs/csv")]
        [HttpGet("/export/JSONServer/projectcategorygetbycategorynametrs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoryGetByCategoryNameTrsToCSV(string CategoryNameTr, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectCategoryGetByCategoryNameTrs(CategoryNameTr), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategorygetbycategorynametrs/excel")]
        [HttpGet("/export/JSONServer/projectcategorygetbycategorynametrs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoryGetByCategoryNameTrsToExcel(string CategoryNameTr, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectCategoryGetByCategoryNameTrs(CategoryNameTr), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategorygetbyids/csv")]
        [HttpGet("/export/JSONServer/projectcategorygetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoryGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectCategoryGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategorygetbyids/excel")]
        [HttpGet("/export/JSONServer/projectcategorygetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoryGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectCategoryGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategorygetbyparentids/csv")]
        [HttpGet("/export/JSONServer/projectcategorygetbyparentids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoryGetByParentIdsToCSV(int? ParentId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectCategoryGetByParentIds(ParentId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategorygetbyparentids/excel")]
        [HttpGet("/export/JSONServer/projectcategorygetbyparentids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoryGetByParentIdsToExcel(int? ParentId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectCategoryGetByParentIds(ParentId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategorygetbysampleurls/csv")]
        [HttpGet("/export/JSONServer/projectcategorygetbysampleurls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoryGetBySampleUrlsToCSV(string SampleUrl, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectCategoryGetBySampleUrls(SampleUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategorygetbysampleurls/excel")]
        [HttpGet("/export/JSONServer/projectcategorygetbysampleurls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoryGetBySampleUrlsToExcel(string SampleUrl, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectCategoryGetBySampleUrls(SampleUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategoryinserts/csv")]
        [HttpGet("/export/JSONServer/projectcategoryinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoryInsertsToCSV(string CategoryName, int? ParentId, string SampleUrl, string CategoryNameTr, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectCategoryInserts(CategoryName, ParentId, SampleUrl, CategoryNameTr), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategoryinserts/excel")]
        [HttpGet("/export/JSONServer/projectcategoryinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoryInsertsToExcel(string CategoryName, int? ParentId, string SampleUrl, string CategoryNameTr, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectCategoryInserts(CategoryName, ParentId, SampleUrl, CategoryNameTr), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategoryupdates/csv")]
        [HttpGet("/export/JSONServer/projectcategoryupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoryUpdatesToCSV(int? Id, string CategoryName, int? ParentId, string SampleUrl, string CategoryNameTr, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectCategoryUpdates(Id, CategoryName, ParentId, SampleUrl, CategoryNameTr), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectcategoryupdates/excel")]
        [HttpGet("/export/JSONServer/projectcategoryupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoryUpdatesToExcel(int? Id, string CategoryName, int? ParentId, string SampleUrl, string CategoryNameTr, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectCategoryUpdates(Id, CategoryName, ParentId, SampleUrl, CategoryNameTr), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetalls/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationKeyAndValueGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetalls/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationKeyAndValueGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationkeys/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationkeys/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueGetByConfigurationKeysToCSV(string ConfigurationKey, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationKeyAndValueGetByConfigurationKeys(ConfigurationKey), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationkeys/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationkeys/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueGetByConfigurationKeysToExcel(string ConfigurationKey, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationKeyAndValueGetByConfigurationKeys(ConfigurationKey), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationkeyfieldtypes/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationkeyfieldtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueGetByConfigurationKeyFieldTypesToCSV(string ConfigurationKeyFieldType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationKeyAndValueGetByConfigurationKeyFieldTypes(ConfigurationKeyFieldType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationkeyfieldtypes/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationkeyfieldtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueGetByConfigurationKeyFieldTypesToExcel(string ConfigurationKeyFieldType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationKeyAndValueGetByConfigurationKeyFieldTypes(ConfigurationKeyFieldType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationkeyfrominputtypes/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationkeyfrominputtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputTypesToCSV(int? ConfigurationKeyFromInputType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputTypes(ConfigurationKeyFromInputType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationkeyfrominputtypes/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationkeyfrominputtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputTypesToExcel(int? ConfigurationKeyFromInputType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputTypes(ConfigurationKeyFromInputType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationvalues/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationvalues/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueGetByConfigurationValuesToCSV(string ConfigurationValue, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationKeyAndValueGetByConfigurationValues(ConfigurationValue), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationvalues/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationvalues/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueGetByConfigurationValuesToExcel(string ConfigurationValue, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationKeyAndValueGetByConfigurationValues(ConfigurationValue), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationvaluetypes/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationvaluetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueGetByConfigurationValueTypesToCSV(int? ConfigurationValueType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationKeyAndValueGetByConfigurationValueTypes(ConfigurationValueType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationvaluetypes/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyconfigurationvaluetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueGetByConfigurationValueTypesToExcel(int? ConfigurationValueType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationKeyAndValueGetByConfigurationValueTypes(ConfigurationValueType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyids/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationKeyAndValueGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyids/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationKeyAndValueGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyparentconfigurationkeyids/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyparentconfigurationkeyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueGetByParentConfigurationKeyIdsToCSV(int? ParentConfigurationKeyId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationKeyAndValueGetByParentConfigurationKeyIds(ParentConfigurationKeyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyparentconfigurationkeyids/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvaluegetbyparentconfigurationkeyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueGetByParentConfigurationKeyIdsToExcel(int? ParentConfigurationKeyId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationKeyAndValueGetByParentConfigurationKeyIds(ParentConfigurationKeyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvalueinserts/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvalueinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueInsertsToCSV(string ConfigurationKey, string ConfigurationKeyFieldType, int? ConfigurationKeyFromInputType, string ConfigurationValue, int? ConfigurationValueType, int? ParentConfigurationKeyId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationKeyAndValueInserts(ConfigurationKey, ConfigurationKeyFieldType, ConfigurationKeyFromInputType, ConfigurationValue, ConfigurationValueType, ParentConfigurationKeyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvalueinserts/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvalueinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueInsertsToExcel(string ConfigurationKey, string ConfigurationKeyFieldType, int? ConfigurationKeyFromInputType, string ConfigurationValue, int? ConfigurationValueType, int? ParentConfigurationKeyId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationKeyAndValueInserts(ConfigurationKey, ConfigurationKeyFieldType, ConfigurationKeyFromInputType, ConfigurationValue, ConfigurationValueType, ParentConfigurationKeyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvalueupdates/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvalueupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueUpdatesToCSV(int? Id, string ConfigurationKey, string ConfigurationKeyFieldType, int? ConfigurationKeyFromInputType, string ConfigurationValue, int? ConfigurationValueType, int? ParentConfigurationKeyId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationKeyAndValueUpdates(Id, ConfigurationKey, ConfigurationKeyFieldType, ConfigurationKeyFromInputType, ConfigurationValue, ConfigurationValueType, ParentConfigurationKeyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationkeyandvalueupdates/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationkeyandvalueupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValueUpdatesToExcel(int? Id, string ConfigurationKey, string ConfigurationKeyFieldType, int? ConfigurationKeyFromInputType, string ConfigurationValue, int? ConfigurationValueType, int? ParentConfigurationKeyId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationKeyAndValueUpdates(Id, ConfigurationKey, ConfigurationKeyFieldType, ConfigurationKeyFromInputType, ConfigurationValue, ConfigurationValueType, ParentConfigurationKeyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetalls/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetalls/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyangularconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyangularconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByAngularConfigurationsToCSV(string AngularConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByAngularConfigurations(AngularConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyangularconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyangularconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByAngularConfigurationsToExcel(string AngularConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByAngularConfigurations(AngularConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbybackgroundjobconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbybackgroundjobconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByBackgroundJobConfigurationsToCSV(string BackgroundJobConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByBackgroundJobConfigurations(BackgroundJobConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbybackgroundjobconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbybackgroundjobconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByBackgroundJobConfigurationsToExcel(string BackgroundJobConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByBackgroundJobConfigurations(BackgroundJobConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbybackupconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbybackupconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByBackUpConfigurationsToCSV(string BackUpConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByBackUpConfigurations(BackUpConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbybackupconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbybackupconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByBackUpConfigurationsToExcel(string BackUpConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByBackUpConfigurations(BackUpConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbybootstrapconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbybootstrapconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByBootStrapConfigurationsToCSV(string BootStrapConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByBootStrapConfigurations(BootStrapConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbybootstrapconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbybootstrapconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByBootStrapConfigurationsToExcel(string BootStrapConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByBootStrapConfigurations(BootStrapConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbybuildconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbybuildconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByBuildConfigurationsToCSV(string BuildConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByBuildConfigurations(BuildConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbybuildconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbybuildconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByBuildConfigurationsToExcel(string BuildConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByBuildConfigurations(BuildConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbycacheconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbycacheconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByCacheConfigurationsToCSV(string CacheConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByCacheConfigurations(CacheConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbycacheconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbycacheconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByCacheConfigurationsToExcel(string CacheConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByCacheConfigurations(CacheConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbycanoverrides/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbycanoverrides/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByCanOverRidesToCSV(bool? CanOverRide, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByCanOverRides(CanOverRide), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbycanoverrides/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbycanoverrides/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByCanOverRidesToExcel(bool? CanOverRide, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByCanOverRides(CanOverRide), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbycmsconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbycmsconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByCmsConfigurationsToCSV(string CMSConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByCmsConfigurations(CMSConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbycmsconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbycmsconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByCmsConfigurationsToExcel(string CMSConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByCmsConfigurations(CMSConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbycolumnconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbycolumnconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByColumnConfigurationsToCSV(string ColumnConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByColumnConfigurations(ColumnConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbycolumnconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbycolumnconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByColumnConfigurationsToExcel(string ColumnConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByColumnConfigurations(ColumnConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbycomponentconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbycomponentconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByComponentConfigurationsToCSV(string ComponentConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByComponentConfigurations(ComponentConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbycomponentconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbycomponentconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByComponentConfigurationsToExcel(string ComponentConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByComponentConfigurations(ComponentConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyconfigurationjsonschemes/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyconfigurationjsonschemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByConfigurationJsonSchemesToCSV(string ConfigurationJsonScheme, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByConfigurationJsonSchemes(ConfigurationJsonScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyconfigurationjsonschemes/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyconfigurationjsonschemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByConfigurationJsonSchemesToExcel(string ConfigurationJsonScheme, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByConfigurationJsonSchemes(ConfigurationJsonScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyconsoleappconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyconsoleappconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByConsoleAppConfigurationsToCSV(string ConsoleAppConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByConsoleAppConfigurations(ConsoleAppConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyconsoleappconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyconsoleappconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByConsoleAppConfigurationsToExcel(string ConsoleAppConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByConsoleAppConfigurations(ConsoleAppConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbycreatedbyids/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbycreatedbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByCreatedByIdsToCSV(int? CreatedById, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByCreatedByIds(CreatedById), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbycreatedbyids/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbycreatedbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByCreatedByIdsToExcel(int? CreatedById, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByCreatedByIds(CreatedById), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbycreateddates/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbycreateddates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByCreatedDatesToCSV(string CreatedDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByCreatedDates(CreatedDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbycreateddates/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbycreateddates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByCreatedDatesToExcel(string CreatedDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByCreatedDates(CreatedDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbycssconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbycssconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByCssConfigurationsToCSV(string CssConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByCssConfigurations(CssConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbycssconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbycssconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByCssConfigurationsToExcel(string CssConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByCssConfigurations(CssConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbydapperconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbydapperconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByDapperConfigurationsToCSV(string DapperConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByDapperConfigurations(DapperConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbydapperconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbydapperconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByDapperConfigurationsToExcel(string DapperConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByDapperConfigurations(DapperConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbydatabaseconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbydatabaseconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByDataBaseConfigurationsToCSV(string DataBaseConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByDataBaseConfigurations(DataBaseConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbydatabaseconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbydatabaseconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByDataBaseConfigurationsToExcel(string DataBaseConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByDataBaseConfigurations(DataBaseConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbydatatypeconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbydatatypeconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByDataTypeConfigurationsToCSV(string DataTypeConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByDataTypeConfigurations(DataTypeConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbydatatypeconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbydatatypeconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByDataTypeConfigurationsToExcel(string DataTypeConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByDataTypeConfigurations(DataTypeConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbydbjobconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbydbjobconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByDbJobConfigurationsToCSV(string DBJobConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByDbJobConfigurations(DBJobConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbydbjobconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbydbjobconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByDbJobConfigurationsToExcel(string DBJobConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByDbJobConfigurations(DBJobConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbydescriptions/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbydescriptions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByDescriptionsToCSV(string Descriptions, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByDescriptions(Descriptions), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbydescriptions/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbydescriptions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByDescriptionsToExcel(string Descriptions, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByDescriptions(Descriptions), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbydeviceconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbydeviceconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByDeviceConfigurationsToCSV(string DeviceConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByDeviceConfigurations(DeviceConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbydeviceconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbydeviceconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByDeviceConfigurationsToExcel(string DeviceConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByDeviceConfigurations(DeviceConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbydiagramconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbydiagramconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByDiagramConfigurationsToCSV(string DiagramConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByDiagramConfigurations(DiagramConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbydiagramconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbydiagramconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByDiagramConfigurationsToExcel(string DiagramConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByDiagramConfigurations(DiagramConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyelasticsearchconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyelasticsearchconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByElasticSearchConfigurationsToCSV(string ElasticSearchConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByElasticSearchConfigurations(ElasticSearchConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyelasticsearchconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyelasticsearchconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByElasticSearchConfigurationsToExcel(string ElasticSearchConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByElasticSearchConfigurations(ElasticSearchConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyexceptionhandlingconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyexceptionhandlingconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByExceptionHandlingConfigurationsToCSV(string ExceptionHandlingConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByExceptionHandlingConfigurations(ExceptionHandlingConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyexceptionhandlingconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyexceptionhandlingconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByExceptionHandlingConfigurationsToExcel(string ExceptionHandlingConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByExceptionHandlingConfigurations(ExceptionHandlingConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyexportconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyexportconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByExportConfigurationsToCSV(string ExportConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByExportConfigurations(ExportConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyexportconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyexportconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByExportConfigurationsToExcel(string ExportConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByExportConfigurations(ExportConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyfigmaconfigirations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyfigmaconfigirations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByFigmaConfigirationsToCSV(string FigmaConfigiration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByFigmaConfigirations(FigmaConfigiration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyfigmaconfigirations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyfigmaconfigirations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByFigmaConfigirationsToExcel(string FigmaConfigiration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByFigmaConfigirations(FigmaConfigiration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyfilemanagementconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyfilemanagementconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByFileManagementConfigurationsToCSV(string FileManagementConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByFileManagementConfigurations(FileManagementConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyfilemanagementconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyfilemanagementconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByFileManagementConfigurationsToExcel(string FileManagementConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByFileManagementConfigurations(FileManagementConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyfileoutputextensionnames/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyfileoutputextensionnames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByFileOutputExtensionNamesToCSV(string FileOutputExtensionName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByFileOutputExtensionNames(FileOutputExtensionName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyfileoutputextensionnames/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyfileoutputextensionnames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByFileOutputExtensionNamesToExcel(string FileOutputExtensionName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByFileOutputExtensionNames(FileOutputExtensionName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyftpconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyftpconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByFtpConfigurationsToCSV(string FtpConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByFtpConfigurations(FtpConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyftpconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyftpconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByFtpConfigurationsToExcel(string FtpConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByFtpConfigurations(FtpConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyfunctionconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyfunctionconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByFunctionConfigurationsToCSV(string FunctionConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByFunctionConfigurations(FunctionConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyfunctionconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyfunctionconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByFunctionConfigurationsToExcel(string FunctionConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByFunctionConfigurations(FunctionConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyhasneedcompileonchanges/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyhasneedcompileonchanges/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByHasNeedCompileOnChangesToCSV(string HasNeedCompileOnChange, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByHasNeedCompileOnChanges(HasNeedCompileOnChange), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyhasneedcompileonchanges/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyhasneedcompileonchanges/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByHasNeedCompileOnChangesToExcel(string HasNeedCompileOnChange, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByHasNeedCompileOnChanges(HasNeedCompileOnChange), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyheaderconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyheaderconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByHeaderConfigurationsToCSV(string HeaderConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByHeaderConfigurations(HeaderConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyheaderconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyheaderconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByHeaderConfigurationsToExcel(string HeaderConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByHeaderConfigurations(HeaderConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyhelpdocumentconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyhelpdocumentconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByHelpDocumentConfigurationsToCSV(string HelpDocumentConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByHelpDocumentConfigurations(HelpDocumentConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyhelpdocumentconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyhelpdocumentconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByHelpDocumentConfigurationsToExcel(string HelpDocumentConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByHelpDocumentConfigurations(HelpDocumentConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyhostingconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyhostingconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByHostingConfigurationsToCSV(string HostingConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByHostingConfigurations(HostingConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyhostingconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyhostingconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByHostingConfigurationsToExcel(string HostingConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByHostingConfigurations(HostingConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyhtmlconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyhtmlconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByHtmlConfigurationsToCSV(string HtmlConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByHtmlConfigurations(HtmlConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyhtmlconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyhtmlconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByHtmlConfigurationsToExcel(string HtmlConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByHtmlConfigurations(HtmlConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyids/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyids/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyiısconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyiısconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByIısConfigurationsToCSV(string IISConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByIısConfigurations(IISConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyiısconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyiısconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByIısConfigurationsToExcel(string IISConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByIısConfigurations(IISConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyinputconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyinputconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByInputConfigurationsToCSV(string InputConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByInputConfigurations(InputConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyinputconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyinputconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByInputConfigurationsToExcel(string InputConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByInputConfigurations(InputConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyjsonconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyjsonconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByJsonConfigurationsToCSV(string JsonConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByJsonConfigurations(JsonConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyjsonconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyjsonconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByJsonConfigurationsToExcel(string JsonConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByJsonConfigurations(JsonConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbylastvaliddates/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbylastvaliddates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByLastValidDatesToCSV(string LastValidDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByLastValidDates(LastValidDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbylastvaliddates/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbylastvaliddates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByLastValidDatesToExcel(string LastValidDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByLastValidDates(LastValidDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbylayoutconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbylayoutconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByLayoutConfigurationsToCSV(string LayoutConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByLayoutConfigurations(LayoutConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbylayoutconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbylayoutconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByLayoutConfigurationsToExcel(string LayoutConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByLayoutConfigurations(LayoutConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbylogconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbylogconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByLogConfigurationsToCSV(string LogConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByLogConfigurations(LogConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbylogconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbylogconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByLogConfigurationsToExcel(string LogConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByLogConfigurations(LogConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbymailconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbymailconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByMailConfigurationsToCSV(string MailConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByMailConfigurations(MailConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbymailconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbymailconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByMailConfigurationsToExcel(string MailConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByMailConfigurations(MailConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbymongoconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbymongoconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByMongoConfigurationsToCSV(string MongoConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByMongoConfigurations(MongoConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbymongoconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbymongoconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByMongoConfigurationsToExcel(string MongoConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByMongoConfigurations(MongoConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbymssqlconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbymssqlconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByMsSqlConfigurationsToCSV(string MsSqlConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByMsSqlConfigurations(MsSqlConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbymssqlconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbymssqlconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByMsSqlConfigurationsToExcel(string MsSqlConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByMsSqlConfigurations(MsSqlConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbymysqlconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbymysqlconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByMySqlConfigurationsToCSV(string MySqlConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByMySqlConfigurations(MySqlConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbymysqlconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbymysqlconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByMySqlConfigurationsToExcel(string MySqlConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByMySqlConfigurations(MySqlConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbynames/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbynames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByNamesToCSV(string Name, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByNames(Name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbynames/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbynames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByNamesToExcel(string Name, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByNames(Name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbynamespaceconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbynamespaceconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByNameSpaceConfigurationsToCSV(string NameSpaceConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByNameSpaceConfigurations(NameSpaceConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbynamespaceconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbynamespaceconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByNameSpaceConfigurationsToExcel(string NameSpaceConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByNameSpaceConfigurations(NameSpaceConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbynetcoreapıconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbynetcoreapıconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByNetCoreApıConfigurationsToCSV(string NetCoreAPIConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByNetCoreApıConfigurations(NetCoreAPIConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbynetcoreapıconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbynetcoreapıconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByNetCoreApıConfigurationsToExcel(string NetCoreAPIConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByNetCoreApıConfigurations(NetCoreAPIConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbynginxconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbynginxconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByNginxConfigurationsToCSV(string NginxConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByNginxConfigurations(NginxConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbynginxconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbynginxconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByNginxConfigurationsToExcel(string NginxConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByNginxConfigurations(NginxConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbynodejsexpressconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbynodejsexpressconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByNodeJsExpressConfigurationsToCSV(string NodeJsExpressConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByNodeJsExpressConfigurations(NodeJsExpressConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbynodejsexpressconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbynodejsexpressconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByNodeJsExpressConfigurationsToExcel(string NodeJsExpressConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByNodeJsExpressConfigurations(NodeJsExpressConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbynotehistories/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbynotehistories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByNoteHistoriesToCSV(string NoteHistory, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByNoteHistories(NoteHistory), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbynotehistories/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbynotehistories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByNoteHistoriesToExcel(string NoteHistory, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByNoteHistories(NoteHistory), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbypackageconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbypackageconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByPackageConfigurationsToCSV(string PackageConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByPackageConfigurations(PackageConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbypackageconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbypackageconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByPackageConfigurationsToExcel(string PackageConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByPackageConfigurations(PackageConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbypaymentconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbypaymentconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByPaymentConfigurationsToCSV(string PaymentConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByPaymentConfigurations(PaymentConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbypaymentconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbypaymentconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByPaymentConfigurationsToExcel(string PaymentConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByPaymentConfigurations(PaymentConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyprismaconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyprismaconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByPrismaConfigurationsToCSV(string PrismaConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByPrismaConfigurations(PrismaConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyprismaconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyprismaconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByPrismaConfigurationsToExcel(string PrismaConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByPrismaConfigurations(PrismaConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbypublishpathconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbypublishpathconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByPublishPathConfigurationsToCSV(string PublishPathConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByPublishPathConfigurations(PublishPathConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbypublishpathconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbypublishpathconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByPublishPathConfigurationsToExcel(string PublishPathConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByPublishPathConfigurations(PublishPathConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbypurchasedtoolconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbypurchasedtoolconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByPurchasedToolConfigurationsToCSV(string PurchasedToolConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByPurchasedToolConfigurations(PurchasedToolConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbypurchasedtoolconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbypurchasedtoolconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByPurchasedToolConfigurationsToExcel(string PurchasedToolConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByPurchasedToolConfigurations(PurchasedToolConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyratelimitconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyratelimitconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByRateLimitConfigurationsToCSV(string RateLimitConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByRateLimitConfigurations(RateLimitConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyratelimitconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyratelimitconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByRateLimitConfigurationsToExcel(string RateLimitConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByRateLimitConfigurations(RateLimitConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyreactconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyreactconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByReactConfigurationsToCSV(string ReactConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByReactConfigurations(ReactConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyreactconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyreactconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByReactConfigurationsToExcel(string ReactConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByReactConfigurations(ReactConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyredisconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyredisconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByRedisConfigurationsToCSV(string RedisConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByRedisConfigurations(RedisConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyredisconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyredisconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByRedisConfigurationsToExcel(string RedisConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByRedisConfigurations(RedisConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyroleconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyroleconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByRoleConfigurationsToCSV(string RoleConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByRoleConfigurations(RoleConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyroleconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyroleconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByRoleConfigurationsToExcel(string RoleConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByRoleConfigurations(RoleConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbysecurityconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbysecurityconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetBySecurityConfigurationsToCSV(string SecurityConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetBySecurityConfigurations(SecurityConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbysecurityconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbysecurityconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetBySecurityConfigurationsToExcel(string SecurityConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetBySecurityConfigurations(SecurityConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbysoftwarelanguageids/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbysoftwarelanguageids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetBySoftwareLanguageIdsToCSV(int? SoftwareLanguageId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetBySoftwareLanguageIds(SoftwareLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbysoftwarelanguageids/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbysoftwarelanguageids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetBySoftwareLanguageIdsToExcel(int? SoftwareLanguageId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetBySoftwareLanguageIds(SoftwareLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbysoftwareversionconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbysoftwareversionconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetBySoftwareVersionConfigurationsToCSV(string SoftwareVersionConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetBySoftwareVersionConfigurations(SoftwareVersionConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbysoftwareversionconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbysoftwareversionconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetBySoftwareVersionConfigurationsToExcel(string SoftwareVersionConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetBySoftwareVersionConfigurations(SoftwareVersionConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbysslconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbysslconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetBySslConfigurationsToCSV(string SSLConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetBySslConfigurations(SSLConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbysslconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbysslconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetBySslConfigurationsToExcel(string SSLConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetBySslConfigurations(SSLConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbytableconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbytableconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByTableConfigurationsToCSV(string TableConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByTableConfigurations(TableConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbytableconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbytableconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByTableConfigurationsToExcel(string TableConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByTableConfigurations(TableConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbytenantapikeyconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbytenantapikeyconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByTenantApiKeyConfigurationsToCSV(string TenantApiKeyConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByTenantApiKeyConfigurations(TenantApiKeyConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbytenantapikeyconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbytenantapikeyconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByTenantApiKeyConfigurationsToExcel(string TenantApiKeyConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByTenantApiKeyConfigurations(TenantApiKeyConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbytenantconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbytenantconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByTenantConfigurationsToCSV(string TenantConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByTenantConfigurations(TenantConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbytenantconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbytenantconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByTenantConfigurationsToExcel(string TenantConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByTenantConfigurations(TenantConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbytenantpriceconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbytenantpriceconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByTenantPriceConfigurationsToCSV(string TenantPriceConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByTenantPriceConfigurations(TenantPriceConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbytenantpriceconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbytenantpriceconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByTenantPriceConfigurationsToExcel(string TenantPriceConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByTenantPriceConfigurations(TenantPriceConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbytenantwhitelistconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbytenantwhitelistconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByTenantWhiteListConfigurationsToCSV(string TenantWhiteListConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByTenantWhiteListConfigurations(TenantWhiteListConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbytenantwhitelistconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbytenantwhitelistconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByTenantWhiteListConfigurationsToExcel(string TenantWhiteListConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByTenantWhiteListConfigurations(TenantWhiteListConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbytestconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbytestconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByTestConfigurationsToCSV(string TestConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByTestConfigurations(TestConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbytestconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbytestconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByTestConfigurationsToExcel(string TestConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByTestConfigurations(TestConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbythemeconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbythemeconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByThemeConfigurationsToCSV(string ThemeConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByThemeConfigurations(ThemeConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbythemeconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbythemeconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByThemeConfigurationsToExcel(string ThemeConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByThemeConfigurations(ThemeConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbythirdpartyconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbythirdpartyconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByThirdPartyConfigurationsToCSV(string ThirdPartyConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByThirdPartyConfigurations(ThirdPartyConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbythirdpartyconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbythirdpartyconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByThirdPartyConfigurationsToExcel(string ThirdPartyConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByThirdPartyConfigurations(ThirdPartyConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbytokenconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbytokenconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByTokenConfigurationsToCSV(string TokenConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByTokenConfigurations(TokenConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbytokenconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbytokenconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByTokenConfigurationsToExcel(string TokenConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByTokenConfigurations(TokenConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbytsconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbytsconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByTsConfigurationsToCSV(string TsConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByTsConfigurations(TsConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbytsconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbytsconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByTsConfigurationsToExcel(string TsConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByTsConfigurations(TsConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbywcfconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbywcfconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByWcfConfigurationsToCSV(string WCFConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByWcfConfigurations(WCFConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbywcfconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbywcfconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByWcfConfigurationsToExcel(string WCFConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByWcfConfigurations(WCFConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbywindowsserviceconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbywindowsserviceconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByWindowsServiceConfigurationsToCSV(string WindowsServiceConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByWindowsServiceConfigurations(WindowsServiceConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbywindowsserviceconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbywindowsserviceconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByWindowsServiceConfigurationsToExcel(string WindowsServiceConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByWindowsServiceConfigurations(WindowsServiceConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyxmlconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyxmlconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByXmlConfigurationsToCSV(string XMLConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetByXmlConfigurations(XMLConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetbyxmlconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetbyxmlconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetByXmlConfigurationsToExcel(string XMLConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetByXmlConfigurations(XMLConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetcreateddatebetweens/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetcreateddatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetCreatedDateBetweensToCSV(string CreatedDateStart, string CreatedDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetCreatedDateBetweens(CreatedDateStart, CreatedDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetcreateddatebetweens/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetcreateddatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetCreatedDateBetweensToExcel(string CreatedDateStart, string CreatedDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetCreatedDateBetweens(CreatedDateStart, CreatedDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetlastvaliddatebetweens/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetlastvaliddatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetLastValidDateBetweensToCSV(string LastValidDateStart, string LastValidDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsGetLastValidDateBetweens(LastValidDateStart, LastValidDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsgetlastvaliddatebetweens/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsgetlastvaliddatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsGetLastValidDateBetweensToExcel(string LastValidDateStart, string LastValidDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsGetLastValidDateBetweens(LastValidDateStart, LastValidDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsinserts/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsInsertsToCSV(string Name, string ConfigurationJsonScheme, string NoteHistory, string Descriptions, bool? CanOverRide, string HasNeedCompileOnChange, int? CreatedById, string SecurityConfiguration, string LogConfiguration, string CacheConfiguration, string DataBaseConfiguration, string NameSpaceConfiguration, string ReactConfiguration, string AngularConfiguration, string NodeJsExpressConfiguration, string NetCoreAPIConfiguration, string IISConfiguration, string HostingConfiguration, string BuildConfiguration, string BackUpConfiguration, string DBJobConfiguration, string DataTypeConfiguration, string FileManagementConfiguration, string DapperConfiguration, string RateLimitConfiguration, string TenantConfiguration, string TenantApiKeyConfiguration, string TenantPriceConfiguration, string NginxConfiguration, string LastValidDate, string CreatedDate, string PublishPathConfiguration, string FtpConfiguration, string BackgroundJobConfiguration, string WindowsServiceConfiguration, string ConsoleAppConfiguration, string WCFConfiguration, string TokenConfiguration, string PaymentConfiguration, string PurchasedToolConfiguration, string TenantWhiteListConfiguration, string HelpDocumentConfiguration, string HeaderConfiguration, string RoleConfiguration, string MongoConfiguration, string MsSqlConfiguration, string MySqlConfiguration, string ElasticSearchConfiguration, string TableConfiguration, string ColumnConfiguration, string FunctionConfiguration, string InputConfiguration, string CMSConfiguration, string ThemeConfiguration, string SSLConfiguration, string SoftwareVersionConfiguration, string ExceptionHandlingConfiguration, string JsonConfiguration, string XMLConfiguration, int? SoftwareLanguageId, string CssConfiguration, string HtmlConfiguration, string TsConfiguration, string PackageConfiguration, string TestConfiguration, string DeviceConfiguration, string RedisConfiguration, string FileOutputExtensionName, string ExportConfiguration, string MailConfiguration, string ThirdPartyConfiguration, string DiagramConfiguration, string PrismaConfiguration, string BootStrapConfiguration, string LayoutConfiguration, string ComponentConfiguration, string FigmaConfigiration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsInserts(Name, ConfigurationJsonScheme, NoteHistory, Descriptions, CanOverRide, HasNeedCompileOnChange, CreatedById, SecurityConfiguration, LogConfiguration, CacheConfiguration, DataBaseConfiguration, NameSpaceConfiguration, ReactConfiguration, AngularConfiguration, NodeJsExpressConfiguration, NetCoreAPIConfiguration, IISConfiguration, HostingConfiguration, BuildConfiguration, BackUpConfiguration, DBJobConfiguration, DataTypeConfiguration, FileManagementConfiguration, DapperConfiguration, RateLimitConfiguration, TenantConfiguration, TenantApiKeyConfiguration, TenantPriceConfiguration, NginxConfiguration, LastValidDate, CreatedDate, PublishPathConfiguration, FtpConfiguration, BackgroundJobConfiguration, WindowsServiceConfiguration, ConsoleAppConfiguration, WCFConfiguration, TokenConfiguration, PaymentConfiguration, PurchasedToolConfiguration, TenantWhiteListConfiguration, HelpDocumentConfiguration, HeaderConfiguration, RoleConfiguration, MongoConfiguration, MsSqlConfiguration, MySqlConfiguration, ElasticSearchConfiguration, TableConfiguration, ColumnConfiguration, FunctionConfiguration, InputConfiguration, CMSConfiguration, ThemeConfiguration, SSLConfiguration, SoftwareVersionConfiguration, ExceptionHandlingConfiguration, JsonConfiguration, XMLConfiguration, SoftwareLanguageId, CssConfiguration, HtmlConfiguration, TsConfiguration, PackageConfiguration, TestConfiguration, DeviceConfiguration, RedisConfiguration, FileOutputExtensionName, ExportConfiguration, MailConfiguration, ThirdPartyConfiguration, DiagramConfiguration, PrismaConfiguration, BootStrapConfiguration, LayoutConfiguration, ComponentConfiguration, FigmaConfigiration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsinserts/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsInsertsToExcel(string Name, string ConfigurationJsonScheme, string NoteHistory, string Descriptions, bool? CanOverRide, string HasNeedCompileOnChange, int? CreatedById, string SecurityConfiguration, string LogConfiguration, string CacheConfiguration, string DataBaseConfiguration, string NameSpaceConfiguration, string ReactConfiguration, string AngularConfiguration, string NodeJsExpressConfiguration, string NetCoreAPIConfiguration, string IISConfiguration, string HostingConfiguration, string BuildConfiguration, string BackUpConfiguration, string DBJobConfiguration, string DataTypeConfiguration, string FileManagementConfiguration, string DapperConfiguration, string RateLimitConfiguration, string TenantConfiguration, string TenantApiKeyConfiguration, string TenantPriceConfiguration, string NginxConfiguration, string LastValidDate, string CreatedDate, string PublishPathConfiguration, string FtpConfiguration, string BackgroundJobConfiguration, string WindowsServiceConfiguration, string ConsoleAppConfiguration, string WCFConfiguration, string TokenConfiguration, string PaymentConfiguration, string PurchasedToolConfiguration, string TenantWhiteListConfiguration, string HelpDocumentConfiguration, string HeaderConfiguration, string RoleConfiguration, string MongoConfiguration, string MsSqlConfiguration, string MySqlConfiguration, string ElasticSearchConfiguration, string TableConfiguration, string ColumnConfiguration, string FunctionConfiguration, string InputConfiguration, string CMSConfiguration, string ThemeConfiguration, string SSLConfiguration, string SoftwareVersionConfiguration, string ExceptionHandlingConfiguration, string JsonConfiguration, string XMLConfiguration, int? SoftwareLanguageId, string CssConfiguration, string HtmlConfiguration, string TsConfiguration, string PackageConfiguration, string TestConfiguration, string DeviceConfiguration, string RedisConfiguration, string FileOutputExtensionName, string ExportConfiguration, string MailConfiguration, string ThirdPartyConfiguration, string DiagramConfiguration, string PrismaConfiguration, string BootStrapConfiguration, string LayoutConfiguration, string ComponentConfiguration, string FigmaConfigiration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsInserts(Name, ConfigurationJsonScheme, NoteHistory, Descriptions, CanOverRide, HasNeedCompileOnChange, CreatedById, SecurityConfiguration, LogConfiguration, CacheConfiguration, DataBaseConfiguration, NameSpaceConfiguration, ReactConfiguration, AngularConfiguration, NodeJsExpressConfiguration, NetCoreAPIConfiguration, IISConfiguration, HostingConfiguration, BuildConfiguration, BackUpConfiguration, DBJobConfiguration, DataTypeConfiguration, FileManagementConfiguration, DapperConfiguration, RateLimitConfiguration, TenantConfiguration, TenantApiKeyConfiguration, TenantPriceConfiguration, NginxConfiguration, LastValidDate, CreatedDate, PublishPathConfiguration, FtpConfiguration, BackgroundJobConfiguration, WindowsServiceConfiguration, ConsoleAppConfiguration, WCFConfiguration, TokenConfiguration, PaymentConfiguration, PurchasedToolConfiguration, TenantWhiteListConfiguration, HelpDocumentConfiguration, HeaderConfiguration, RoleConfiguration, MongoConfiguration, MsSqlConfiguration, MySqlConfiguration, ElasticSearchConfiguration, TableConfiguration, ColumnConfiguration, FunctionConfiguration, InputConfiguration, CMSConfiguration, ThemeConfiguration, SSLConfiguration, SoftwareVersionConfiguration, ExceptionHandlingConfiguration, JsonConfiguration, XMLConfiguration, SoftwareLanguageId, CssConfiguration, HtmlConfiguration, TsConfiguration, PackageConfiguration, TestConfiguration, DeviceConfiguration, RedisConfiguration, FileOutputExtensionName, ExportConfiguration, MailConfiguration, ThirdPartyConfiguration, DiagramConfiguration, PrismaConfiguration, BootStrapConfiguration, LayoutConfiguration, ComponentConfiguration, FigmaConfigiration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsupdates/csv")]
        [HttpGet("/export/JSONServer/projectconfigurationsupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsUpdatesToCSV(int? Id, string Name, string ConfigurationJsonScheme, string NoteHistory, string Descriptions, bool? CanOverRide, string HasNeedCompileOnChange, int? CreatedById, string SecurityConfiguration, string LogConfiguration, string CacheConfiguration, string DataBaseConfiguration, string NameSpaceConfiguration, string ReactConfiguration, string AngularConfiguration, string NodeJsExpressConfiguration, string NetCoreAPIConfiguration, string IISConfiguration, string HostingConfiguration, string BuildConfiguration, string BackUpConfiguration, string DBJobConfiguration, string DataTypeConfiguration, string FileManagementConfiguration, string DapperConfiguration, string RateLimitConfiguration, string TenantConfiguration, string TenantApiKeyConfiguration, string TenantPriceConfiguration, string NginxConfiguration, string LastValidDate, string CreatedDate, string PublishPathConfiguration, string FtpConfiguration, string BackgroundJobConfiguration, string WindowsServiceConfiguration, string ConsoleAppConfiguration, string WCFConfiguration, string TokenConfiguration, string PaymentConfiguration, string PurchasedToolConfiguration, string TenantWhiteListConfiguration, string HelpDocumentConfiguration, string HeaderConfiguration, string RoleConfiguration, string MongoConfiguration, string MsSqlConfiguration, string MySqlConfiguration, string ElasticSearchConfiguration, string TableConfiguration, string ColumnConfiguration, string FunctionConfiguration, string InputConfiguration, string CMSConfiguration, string ThemeConfiguration, string SSLConfiguration, string SoftwareVersionConfiguration, string ExceptionHandlingConfiguration, string JsonConfiguration, string XMLConfiguration, int? SoftwareLanguageId, string CssConfiguration, string HtmlConfiguration, string TsConfiguration, string PackageConfiguration, string TestConfiguration, string DeviceConfiguration, string RedisConfiguration, string FileOutputExtensionName, string ExportConfiguration, string MailConfiguration, string ThirdPartyConfiguration, string DiagramConfiguration, string PrismaConfiguration, string BootStrapConfiguration, string LayoutConfiguration, string ComponentConfiguration, string FigmaConfigiration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationsUpdates(Id, Name, ConfigurationJsonScheme, NoteHistory, Descriptions, CanOverRide, HasNeedCompileOnChange, CreatedById, SecurityConfiguration, LogConfiguration, CacheConfiguration, DataBaseConfiguration, NameSpaceConfiguration, ReactConfiguration, AngularConfiguration, NodeJsExpressConfiguration, NetCoreAPIConfiguration, IISConfiguration, HostingConfiguration, BuildConfiguration, BackUpConfiguration, DBJobConfiguration, DataTypeConfiguration, FileManagementConfiguration, DapperConfiguration, RateLimitConfiguration, TenantConfiguration, TenantApiKeyConfiguration, TenantPriceConfiguration, NginxConfiguration, LastValidDate, CreatedDate, PublishPathConfiguration, FtpConfiguration, BackgroundJobConfiguration, WindowsServiceConfiguration, ConsoleAppConfiguration, WCFConfiguration, TokenConfiguration, PaymentConfiguration, PurchasedToolConfiguration, TenantWhiteListConfiguration, HelpDocumentConfiguration, HeaderConfiguration, RoleConfiguration, MongoConfiguration, MsSqlConfiguration, MySqlConfiguration, ElasticSearchConfiguration, TableConfiguration, ColumnConfiguration, FunctionConfiguration, InputConfiguration, CMSConfiguration, ThemeConfiguration, SSLConfiguration, SoftwareVersionConfiguration, ExceptionHandlingConfiguration, JsonConfiguration, XMLConfiguration, SoftwareLanguageId, CssConfiguration, HtmlConfiguration, TsConfiguration, PackageConfiguration, TestConfiguration, DeviceConfiguration, RedisConfiguration, FileOutputExtensionName, ExportConfiguration, MailConfiguration, ThirdPartyConfiguration, DiagramConfiguration, PrismaConfiguration, BootStrapConfiguration, LayoutConfiguration, ComponentConfiguration, FigmaConfigiration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectconfigurationsupdates/excel")]
        [HttpGet("/export/JSONServer/projectconfigurationsupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsUpdatesToExcel(int? Id, string Name, string ConfigurationJsonScheme, string NoteHistory, string Descriptions, bool? CanOverRide, string HasNeedCompileOnChange, int? CreatedById, string SecurityConfiguration, string LogConfiguration, string CacheConfiguration, string DataBaseConfiguration, string NameSpaceConfiguration, string ReactConfiguration, string AngularConfiguration, string NodeJsExpressConfiguration, string NetCoreAPIConfiguration, string IISConfiguration, string HostingConfiguration, string BuildConfiguration, string BackUpConfiguration, string DBJobConfiguration, string DataTypeConfiguration, string FileManagementConfiguration, string DapperConfiguration, string RateLimitConfiguration, string TenantConfiguration, string TenantApiKeyConfiguration, string TenantPriceConfiguration, string NginxConfiguration, string LastValidDate, string CreatedDate, string PublishPathConfiguration, string FtpConfiguration, string BackgroundJobConfiguration, string WindowsServiceConfiguration, string ConsoleAppConfiguration, string WCFConfiguration, string TokenConfiguration, string PaymentConfiguration, string PurchasedToolConfiguration, string TenantWhiteListConfiguration, string HelpDocumentConfiguration, string HeaderConfiguration, string RoleConfiguration, string MongoConfiguration, string MsSqlConfiguration, string MySqlConfiguration, string ElasticSearchConfiguration, string TableConfiguration, string ColumnConfiguration, string FunctionConfiguration, string InputConfiguration, string CMSConfiguration, string ThemeConfiguration, string SSLConfiguration, string SoftwareVersionConfiguration, string ExceptionHandlingConfiguration, string JsonConfiguration, string XMLConfiguration, int? SoftwareLanguageId, string CssConfiguration, string HtmlConfiguration, string TsConfiguration, string PackageConfiguration, string TestConfiguration, string DeviceConfiguration, string RedisConfiguration, string FileOutputExtensionName, string ExportConfiguration, string MailConfiguration, string ThirdPartyConfiguration, string DiagramConfiguration, string PrismaConfiguration, string BootStrapConfiguration, string LayoutConfiguration, string ComponentConfiguration, string FigmaConfigiration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationsUpdates(Id, Name, ConfigurationJsonScheme, NoteHistory, Descriptions, CanOverRide, HasNeedCompileOnChange, CreatedById, SecurityConfiguration, LogConfiguration, CacheConfiguration, DataBaseConfiguration, NameSpaceConfiguration, ReactConfiguration, AngularConfiguration, NodeJsExpressConfiguration, NetCoreAPIConfiguration, IISConfiguration, HostingConfiguration, BuildConfiguration, BackUpConfiguration, DBJobConfiguration, DataTypeConfiguration, FileManagementConfiguration, DapperConfiguration, RateLimitConfiguration, TenantConfiguration, TenantApiKeyConfiguration, TenantPriceConfiguration, NginxConfiguration, LastValidDate, CreatedDate, PublishPathConfiguration, FtpConfiguration, BackgroundJobConfiguration, WindowsServiceConfiguration, ConsoleAppConfiguration, WCFConfiguration, TokenConfiguration, PaymentConfiguration, PurchasedToolConfiguration, TenantWhiteListConfiguration, HelpDocumentConfiguration, HeaderConfiguration, RoleConfiguration, MongoConfiguration, MsSqlConfiguration, MySqlConfiguration, ElasticSearchConfiguration, TableConfiguration, ColumnConfiguration, FunctionConfiguration, InputConfiguration, CMSConfiguration, ThemeConfiguration, SSLConfiguration, SoftwareVersionConfiguration, ExceptionHandlingConfiguration, JsonConfiguration, XMLConfiguration, SoftwareLanguageId, CssConfiguration, HtmlConfiguration, TsConfiguration, PackageConfiguration, TestConfiguration, DeviceConfiguration, RedisConfiguration, FileOutputExtensionName, ExportConfiguration, MailConfiguration, ThirdPartyConfiguration, DiagramConfiguration, PrismaConfiguration, BootStrapConfiguration, LayoutConfiguration, ComponentConfiguration, FigmaConfigiration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsgetalls/csv")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionGroupsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsgetalls/excel")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionGroupsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbycallafterfunctionssuccessfullresponses/csv")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbycallafterfunctionssuccessfullresponses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponsesToCSV(int? CallAfterFunctionsSuccessfullResponse, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponses(CallAfterFunctionsSuccessfullResponse), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbycallafterfunctionssuccessfullresponses/excel")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbycallafterfunctionssuccessfullresponses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponsesToExcel(int? CallAfterFunctionsSuccessfullResponse, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponses(CallAfterFunctionsSuccessfullResponse), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbycommissions/csv")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbycommissions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsGetByCommissionsToCSV(decimal? Commission, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionGroupsGetByCommissions(Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbycommissions/excel")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbycommissions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsGetByCommissionsToExcel(decimal? Commission, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionGroupsGetByCommissions(Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbycurrencyids/csv")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbycurrencyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsGetByCurrencyIdsToCSV(int? CurrencyId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionGroupsGetByCurrencyIds(CurrencyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbycurrencyids/excel")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbycurrencyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsGetByCurrencyIdsToExcel(int? CurrencyId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionGroupsGetByCurrencyIds(CurrencyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbyfunctiongroupnames/csv")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbyfunctiongroupnames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsGetByFunctionGroupNamesToCSV(string FunctionGroupName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionGroupsGetByFunctionGroupNames(FunctionGroupName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbyfunctiongroupnames/excel")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbyfunctiongroupnames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsGetByFunctionGroupNamesToExcel(string FunctionGroupName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionGroupsGetByFunctionGroupNames(FunctionGroupName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbyids/csv")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionGroupsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbyids/excel")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionGroupsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbyprices/csv")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbyprices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsGetByPricesToCSV(decimal? Price, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionGroupsGetByPrices(Price), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbyprices/excel")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbyprices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsGetByPricesToExcel(decimal? Price, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionGroupsGetByPrices(Price), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbysoftwarelanguageids/csv")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbysoftwarelanguageids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsGetBySoftWareLanguageIdsToCSV(int? SoftWareLanguageId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionGroupsGetBySoftWareLanguageIds(SoftWareLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbysoftwarelanguageids/excel")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsgetbysoftwarelanguageids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsGetBySoftWareLanguageIdsToExcel(int? SoftWareLanguageId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionGroupsGetBySoftWareLanguageIds(SoftWareLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsinserts/csv")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsInsertsToCSV(string FunctionGroupName, int? CallAfterFunctionsSuccessfullResponse, int? SoftWareLanguageId, int? CurrencyId, decimal? Price, decimal? Commission, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionGroupsInserts(FunctionGroupName, CallAfterFunctionsSuccessfullResponse, SoftWareLanguageId, CurrencyId, Price, Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsinserts/excel")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsInsertsToExcel(string FunctionGroupName, int? CallAfterFunctionsSuccessfullResponse, int? SoftWareLanguageId, int? CurrencyId, decimal? Price, decimal? Commission, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionGroupsInserts(FunctionGroupName, CallAfterFunctionsSuccessfullResponse, SoftWareLanguageId, CurrencyId, Price, Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsupdates/csv")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsUpdatesToCSV(int? Id, string FunctionGroupName, int? CallAfterFunctionsSuccessfullResponse, int? SoftWareLanguageId, int? CurrencyId, decimal? Price, decimal? Commission, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionGroupsUpdates(Id, FunctionGroupName, CallAfterFunctionsSuccessfullResponse, SoftWareLanguageId, CurrencyId, Price, Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctiongroupsupdates/excel")]
        [HttpGet("/export/JSONServer/projectfunctiongroupsupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsUpdatesToExcel(int? Id, string FunctionGroupName, int? CallAfterFunctionsSuccessfullResponse, int? SoftWareLanguageId, int? CurrencyId, decimal? Price, decimal? Commission, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionGroupsUpdates(Id, FunctionGroupName, CallAfterFunctionsSuccessfullResponse, SoftWareLanguageId, CurrencyId, Price, Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetalls/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetalls/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyacceptablequerystrings/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyacceptablequerystrings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByAcceptableQuerystringsToCSV(string AcceptableQuerystrings, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByAcceptableQuerystrings(AcceptableQuerystrings), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyacceptablequerystrings/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyacceptablequerystrings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByAcceptableQuerystringsToExcel(string AcceptableQuerystrings, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByAcceptableQuerystrings(AcceptableQuerystrings), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyaccessmodifierids/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyaccessmodifierids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByAccessModifierIdsToCSV(int? AccessModifierId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByAccessModifierIds(AccessModifierId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyaccessmodifierids/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyaccessmodifierids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByAccessModifierIdsToExcel(int? AccessModifierId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByAccessModifierIds(AccessModifierId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyapimethodcomments/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyapimethodcomments/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByApiMethodCommentsToCSV(string ApiMethodComment, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByApiMethodComments(ApiMethodComment), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyapimethodcomments/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyapimethodcomments/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByApiMethodCommentsToExcel(string ApiMethodComment, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByApiMethodComments(ApiMethodComment), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbycachedbconnections/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbycachedbconnections/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByCacheDbConnectionsToCSV(int? CacheDBConnection, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByCacheDbConnections(CacheDBConnection), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbycachedbconnections/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbycachedbconnections/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByCacheDbConnectionsToExcel(int? CacheDBConnection, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByCacheDbConnections(CacheDBConnection), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbycachetypes/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbycachetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByCacheTypesToCSV(int? CacheType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByCacheTypes(CacheType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbycachetypes/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbycachetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByCacheTypesToExcel(int? CacheType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByCacheTypes(CacheType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbycommissions/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbycommissions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByCommissionsToCSV(decimal? Commission, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByCommissions(Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbycommissions/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbycommissions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByCommissionsToExcel(decimal? Commission, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByCommissions(Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbycreateddates/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbycreateddates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByCreatedDatesToCSV(string CreatedDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByCreatedDates(CreatedDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbycreateddates/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbycreateddates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByCreatedDatesToExcel(string CreatedDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByCreatedDates(CreatedDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbycrudtypes/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbycrudtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByCrudTypesToCSV(int? CrudType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByCrudTypes(CrudType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbycrudtypes/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbycrudtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByCrudTypesToExcel(int? CrudType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByCrudTypes(CrudType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbycurrencyids/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbycurrencyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByCurrencyIdsToCSV(int? CurrencyId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByCurrencyIds(CurrencyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbycurrencyids/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbycurrencyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByCurrencyIdsToExcel(int? CurrencyId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByCurrencyIds(CurrencyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbycustomcodes/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbycustomcodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByCustomCodesToCSV(string CustomCode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByCustomCodes(CustomCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbycustomcodes/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbycustomcodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByCustomCodesToExcel(string CustomCode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByCustomCodes(CustomCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbydatabasetypesids/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbydatabasetypesids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByDatabaseTypesIdsToCSV(int? DatabaseTypesId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByDatabaseTypesIds(DatabaseTypesId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbydatabasetypesids/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbydatabasetypesids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByDatabaseTypesIdsToExcel(int? DatabaseTypesId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByDatabaseTypesIds(DatabaseTypesId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbydocumenturls/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbydocumenturls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByDocumentUrlsToCSV(string DocumentUrl, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByDocumentUrls(DocumentUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbydocumenturls/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbydocumenturls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByDocumentUrlsToExcel(string DocumentUrl, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByDocumentUrls(DocumentUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyeventtypes/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyeventtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByEventTypesToCSV(int? EventType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByEventTypes(EventType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyeventtypes/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyeventtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByEventTypesToExcel(int? EventType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByEventTypes(EventType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyexamplerequests/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyexamplerequests/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByExampleRequestsToCSV(string ExampleRequest, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByExampleRequests(ExampleRequest), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyexamplerequests/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyexamplerequests/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByExampleRequestsToExcel(string ExampleRequest, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByExampleRequests(ExampleRequest), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyexampleresponses/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyexampleresponses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByExampleResponsesToCSV(string ExampleResponse, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByExampleResponses(ExampleResponse), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyexampleresponses/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyexampleresponses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByExampleResponsesToExcel(string ExampleResponse, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByExampleResponses(ExampleResponse), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyfunctioncallrankingroups/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyfunctioncallrankingroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByFunctionCallRankInGroupsToCSV(int? FunctionCallRankInGroup, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByFunctionCallRankInGroups(FunctionCallRankInGroup), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyfunctioncallrankingroups/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyfunctioncallrankingroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByFunctionCallRankInGroupsToExcel(int? FunctionCallRankInGroup, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByFunctionCallRankInGroups(FunctionCallRankInGroup), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyfunctiongroupids/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyfunctiongroupids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByFunctionGroupIdsToCSV(int? FunctionGroupId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByFunctionGroupIds(FunctionGroupId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyfunctiongroupids/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyfunctiongroupids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByFunctionGroupIdsToExcel(int? FunctionGroupId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByFunctionGroupIds(FunctionGroupId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyfunctionisparentingroups/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyfunctionisparentingroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByFunctionIsParentInGroupsToCSV(bool? FunctionIsParentInGroup, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByFunctionIsParentInGroups(FunctionIsParentInGroup), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyfunctionisparentingroups/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyfunctionisparentingroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByFunctionIsParentInGroupsToExcel(bool? FunctionIsParentInGroup, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByFunctionIsParentInGroups(FunctionIsParentInGroup), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyhasasyncs/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyhasasyncs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByHasAsyncsToCSV(bool? HasAsync, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByHasAsyncs(HasAsync), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyhasasyncs/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyhasasyncs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByHasAsyncsToExcel(bool? HasAsync, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByHasAsyncs(HasAsync), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyhasauditevents/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyhasauditevents/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByHasAuditEventsToCSV(bool? HasAuditEvents, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByHasAuditEvents(HasAuditEvents), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyhasauditevents/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyhasauditevents/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByHasAuditEventsToExcel(bool? HasAuditEvents, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByHasAuditEvents(HasAuditEvents), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyhasbusevents/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyhasbusevents/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByHasBusEventsToCSV(bool? HasBusEvent, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByHasBusEvents(HasBusEvent), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyhasbusevents/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyhasbusevents/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByHasBusEventsToExcel(bool? HasBusEvent, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByHasBusEvents(HasBusEvent), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyhascachemethods/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyhascachemethods/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByHasCacheMethodsToCSV(bool? HasCacheMethod, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByHasCacheMethods(HasCacheMethod), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyhascachemethods/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyhascachemethods/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByHasCacheMethodsToExcel(bool? HasCacheMethod, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByHasCacheMethods(HasCacheMethod), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyhasratelimits/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyhasratelimits/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByHasRateLimitsToCSV(bool? HasRateLimit, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByHasRateLimits(HasRateLimit), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyhasratelimits/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyhasratelimits/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByHasRateLimitsToExcel(bool? HasRateLimit, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByHasRateLimits(HasRateLimit), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyheaderschemes/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyheaderschemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByHeaderSchemesToCSV(string HeaderScheme, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByHeaderSchemes(HeaderScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyheaderschemes/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyheaderschemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByHeaderSchemesToExcel(string HeaderScheme, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByHeaderSchemes(HeaderScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyi18jsons/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyi18jsons/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByi18JsonsToCSV(string i18Json, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByi18Jsons(i18Json), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyi18jsons/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyi18jsons/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByi18JsonsToExcel(string i18Json, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByi18Jsons(i18Json), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyids/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyids/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyifresponseissuccesscallthisfunctionids/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyifresponseissuccesscallthisfunctionids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionIdsToCSV(int? IfResponseIsSuccessCallThisFunctionId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionIds(IfResponseIsSuccessCallThisFunctionId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyifresponseissuccesscallthisfunctionids/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyifresponseissuccesscallthisfunctionids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionIdsToExcel(int? IfResponseIsSuccessCallThisFunctionId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionIds(IfResponseIsSuccessCallThisFunctionId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyisdeleteds/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyisdeleteds/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByIsDeletedsToCSV(bool? IsDeleted, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByIsDeleteds(IsDeleted), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyisdeleteds/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyisdeleteds/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByIsDeletedsToExcel(bool? IsDeleted, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByIsDeleteds(IsDeleted), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbylastscandates/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbylastscandates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByLastScanDatesToCSV(string LastScanDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByLastScanDates(LastScanDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbylastscandates/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbylastscandates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByLastScanDatesToExcel(string LastScanDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByLastScanDates(LastScanDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbylogcodemergedatedbconnections/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbylogcodemergedatedbconnections/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByLogCodeMergeDateDbConnectionsToCSV(string LogCodeMergeDateDBConnection, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByLogCodeMergeDateDbConnections(LogCodeMergeDateDBConnection), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbylogcodemergedatedbconnections/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbylogcodemergedatedbconnections/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByLogCodeMergeDateDbConnectionsToExcel(string LogCodeMergeDateDBConnection, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByLogCodeMergeDateDbConnections(LogCodeMergeDateDBConnection), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbylogcodemergedatedbtypes/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbylogcodemergedatedbtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByLogCodeMergeDateDbTypesToCSV(int? LogCodeMergeDateDBType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByLogCodeMergeDateDbTypes(LogCodeMergeDateDBType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbylogcodemergedatedbtypes/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbylogcodemergedatedbtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByLogCodeMergeDateDbTypesToExcel(int? LogCodeMergeDateDBType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByLogCodeMergeDateDbTypes(LogCodeMergeDateDBType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbynamespacelists/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbynamespacelists/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByNameSpaceListsToCSV(string NameSpaceList, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByNameSpaceLists(NameSpaceList), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbynamespacelists/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbynamespacelists/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByNameSpaceListsToExcel(string NameSpaceList, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByNameSpaceLists(NameSpaceList), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyprices/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyprices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByPricesToCSV(decimal? Price, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByPrices(Price), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyprices/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyprices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByPricesToExcel(decimal? Price, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByPrices(Price), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbypublisheddates/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbypublisheddates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByPublishedDatesToCSV(string PublishedDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByPublishedDates(PublishedDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbypublisheddates/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbypublisheddates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByPublishedDatesToExcel(string PublishedDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByPublishedDates(PublishedDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyqueries/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyqueries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByQueriesToCSV(string Query, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByQueries(Query), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyqueries/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyqueries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByQueriesToExcel(string Query, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByQueries(Query), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyratelimitproperties/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyratelimitproperties/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByRateLimitPropertiesToCSV(string RateLimitProperty, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByRateLimitProperties(RateLimitProperty), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyratelimitproperties/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyratelimitproperties/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByRateLimitPropertiesToExcel(string RateLimitProperty, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByRateLimitProperties(RateLimitProperty), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyrequestschemes/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyrequestschemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByRequestSchemesToCSV(string RequestScheme, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByRequestSchemes(RequestScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyrequestschemes/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyrequestschemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByRequestSchemesToExcel(string RequestScheme, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByRequestSchemes(RequestScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyresponsehasmultimodels/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyresponsehasmultimodels/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByResponseHasMultiModelsToCSV(bool? ResponseHasMultiModel, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByResponseHasMultiModels(ResponseHasMultiModel), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyresponsehasmultimodels/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyresponsehasmultimodels/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByResponseHasMultiModelsToExcel(bool? ResponseHasMultiModel, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByResponseHasMultiModels(ResponseHasMultiModel), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyresponsehasreturnvalues/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyresponsehasreturnvalues/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByResponseHasReturnValuesToCSV(bool? ResponseHasReturnValue, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByResponseHasReturnValues(ResponseHasReturnValue), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyresponsehasreturnvalues/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyresponsehasreturnvalues/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByResponseHasReturnValuesToExcel(bool? ResponseHasReturnValue, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByResponseHasReturnValues(ResponseHasReturnValue), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyresponseschemes/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyresponseschemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByResponseSchemesToCSV(string ResponseScheme, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByResponseSchemes(ResponseScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyresponseschemes/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyresponseschemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByResponseSchemesToExcel(string ResponseScheme, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByResponseSchemes(ResponseScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyroutes/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyroutes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByRoutesToCSV(string Route, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByRoutes(Route), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyroutes/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyroutes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByRoutesToExcel(string Route, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByRoutes(Route), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbysoftwarelanguageids/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbysoftwarelanguageids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetBySoftwareLanguageIdsToCSV(int? SoftwareLanguageId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetBySoftwareLanguageIds(SoftwareLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbysoftwarelanguageids/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbysoftwarelanguageids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetBySoftwareLanguageIdsToExcel(int? SoftwareLanguageId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetBySoftwareLanguageIds(SoftwareLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbystatus/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbystatus/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByStatusToCSV(int? Statu, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByStatus(Statu), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbystatus/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbystatus/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByStatusToExcel(int? Statu, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByStatus(Statu), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbysuccessnotificationtemplates/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbysuccessnotificationtemplates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetBySuccessNotificationTemplatesToCSV(string SuccessNotificationTemplate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetBySuccessNotificationTemplates(SuccessNotificationTemplate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbysuccessnotificationtemplates/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbysuccessnotificationtemplates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetBySuccessNotificationTemplatesToExcel(string SuccessNotificationTemplate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetBySuccessNotificationTemplates(SuccessNotificationTemplate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyuseragents/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyuseragents/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByUserAgentsToCSV(string UserAgent, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByUserAgents(UserAgent), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyuseragents/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyuseragents/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByUserAgentsToExcel(string UserAgent, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByUserAgents(UserAgent), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyuserconnectionsids/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyuserconnectionsids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByUserConnectionsIdsToCSV(int? UserConnectionsId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByUserConnectionsIds(UserConnectionsId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyuserconnectionsids/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyuserconnectionsids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByUserConnectionsIdsToExcel(int? UserConnectionsId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByUserConnectionsIds(UserConnectionsId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyuserdescriptionformethods/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyuserdescriptionformethods/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByUserDescriptionForMethodsToCSV(string UserDescriptionForMethod, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByUserDescriptionForMethods(UserDescriptionForMethod), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyuserdescriptionformethods/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyuserdescriptionformethods/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByUserDescriptionForMethodsToExcel(string UserDescriptionForMethod, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByUserDescriptionForMethods(UserDescriptionForMethod), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyuserids/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyuserids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByUserIdsToCSV(int? UserId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByUserIds(UserId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbyuserids/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbyuserids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByUserIdsToExcel(int? UserId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByUserIds(UserId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbywilllogallrequests/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbywilllogallrequests/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByWillLogAllRequestsToCSV(bool? WillLogAllRequest, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByWillLogAllRequests(WillLogAllRequest), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbywilllogallrequests/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbywilllogallrequests/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByWillLogAllRequestsToExcel(bool? WillLogAllRequest, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByWillLogAllRequests(WillLogAllRequest), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbywilllogallresponses/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbywilllogallresponses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByWillLogAllResponsesToCSV(bool? WillLogAllResponse, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByWillLogAllResponses(WillLogAllResponse), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbywilllogallresponses/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbywilllogallresponses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByWillLogAllResponsesToExcel(bool? WillLogAllResponse, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByWillLogAllResponses(WillLogAllResponse), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbywilllogcodemergedates/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbywilllogcodemergedates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByWillLogCodeMergeDatesToCSV(bool? WillLogCodeMergeDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByWillLogCodeMergeDates(WillLogCodeMergeDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbywilllogcodemergedates/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbywilllogcodemergedates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByWillLogCodeMergeDatesToExcel(bool? WillLogCodeMergeDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByWillLogCodeMergeDates(WillLogCodeMergeDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbywithheaders/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbywithheaders/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByWithHeadersToCSV(string WithHeaders, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByWithHeaders(WithHeaders), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbywithheaders/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbywithheaders/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByWithHeadersToExcel(string WithHeaders, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByWithHeaders(WithHeaders), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbywithmethods/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbywithmethods/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByWithMethodsToCSV(string WithMethods, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByWithMethods(WithMethods), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbywithmethods/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbywithmethods/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByWithMethodsToExcel(string WithMethods, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByWithMethods(WithMethods), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbywithorigins/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbywithorigins/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByWithOriginsToCSV(string WithOrigins, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetByWithOrigins(WithOrigins), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetbywithorigins/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetbywithorigins/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetByWithOriginsToExcel(string WithOrigins, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetByWithOrigins(WithOrigins), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetcreateddatebetweens/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetcreateddatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetCreatedDateBetweensToCSV(string CreatedDateStart, string CreatedDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetCreatedDateBetweens(CreatedDateStart, CreatedDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetcreateddatebetweens/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetcreateddatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetCreatedDateBetweensToExcel(string CreatedDateStart, string CreatedDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetCreatedDateBetweens(CreatedDateStart, CreatedDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetlastscandatebetweens/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetlastscandatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetLastScanDateBetweensToCSV(string LastScanDateStart, string LastScanDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetLastScanDateBetweens(LastScanDateStart, LastScanDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetlastscandatebetweens/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetlastscandatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetLastScanDateBetweensToExcel(string LastScanDateStart, string LastScanDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetLastScanDateBetweens(LastScanDateStart, LastScanDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetpublisheddatebetweens/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsgetpublisheddatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetPublishedDateBetweensToCSV(string PublishedDateStart, string PublishedDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsGetPublishedDateBetweens(PublishedDateStart, PublishedDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsgetpublisheddatebetweens/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsgetpublisheddatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsGetPublishedDateBetweensToExcel(string PublishedDateStart, string PublishedDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsGetPublishedDateBetweens(PublishedDateStart, PublishedDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsinserts/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsInsertsToCSV(int? DatabaseTypesId, int? CrudType, string Query, int? UserId, string UserAgent, string CreatedDate, string LastScanDate, int? UserConnectionsId, string RequestScheme, string ResponseScheme, string Route, string HeaderScheme, string WithMethods, string WithHeaders, string WithOrigins, int? CacheDBConnection, int? CacheType, string DocumentUrl, string ExampleRequest, string ExampleResponse, bool? HasAsync, bool? HasCacheMethod, bool? ResponseHasMultiModel, bool? ResponseHasReturnValue, int? LogCodeMergeDateDBType, string LogCodeMergeDateDBConnection, bool? WillLogAllRequest, bool? WillLogCodeMergeDate, bool? WillLogAllResponse, bool? IsDeleted, int? Statu, string PublishedDate, int? EventType, int? AccessModifierId, string AcceptableQuerystrings, bool? HasRateLimit, string RateLimitProperty, bool? HasAuditEvents, bool? HasBusEvent, string i18Json, int? IfResponseIsSuccessCallThisFunctionId, string SuccessNotificationTemplate, string ApiMethodComment, string UserDescriptionForMethod, string NameSpaceList, int? SoftwareLanguageId, int? FunctionGroupId, bool? FunctionIsParentInGroup, int? FunctionCallRankInGroup, string CustomCode, decimal? Price, int? CurrencyId, decimal? Commission, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsInserts(DatabaseTypesId, CrudType, Query, UserId, UserAgent, CreatedDate, LastScanDate, UserConnectionsId, RequestScheme, ResponseScheme, Route, HeaderScheme, WithMethods, WithHeaders, WithOrigins, CacheDBConnection, CacheType, DocumentUrl, ExampleRequest, ExampleResponse, HasAsync, HasCacheMethod, ResponseHasMultiModel, ResponseHasReturnValue, LogCodeMergeDateDBType, LogCodeMergeDateDBConnection, WillLogAllRequest, WillLogCodeMergeDate, WillLogAllResponse, IsDeleted, Statu, PublishedDate, EventType, AccessModifierId, AcceptableQuerystrings, HasRateLimit, RateLimitProperty, HasAuditEvents, HasBusEvent, i18Json, IfResponseIsSuccessCallThisFunctionId, SuccessNotificationTemplate, ApiMethodComment, UserDescriptionForMethod, NameSpaceList, SoftwareLanguageId, FunctionGroupId, FunctionIsParentInGroup, FunctionCallRankInGroup, CustomCode, Price, CurrencyId, Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsinserts/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsInsertsToExcel(int? DatabaseTypesId, int? CrudType, string Query, int? UserId, string UserAgent, string CreatedDate, string LastScanDate, int? UserConnectionsId, string RequestScheme, string ResponseScheme, string Route, string HeaderScheme, string WithMethods, string WithHeaders, string WithOrigins, int? CacheDBConnection, int? CacheType, string DocumentUrl, string ExampleRequest, string ExampleResponse, bool? HasAsync, bool? HasCacheMethod, bool? ResponseHasMultiModel, bool? ResponseHasReturnValue, int? LogCodeMergeDateDBType, string LogCodeMergeDateDBConnection, bool? WillLogAllRequest, bool? WillLogCodeMergeDate, bool? WillLogAllResponse, bool? IsDeleted, int? Statu, string PublishedDate, int? EventType, int? AccessModifierId, string AcceptableQuerystrings, bool? HasRateLimit, string RateLimitProperty, bool? HasAuditEvents, bool? HasBusEvent, string i18Json, int? IfResponseIsSuccessCallThisFunctionId, string SuccessNotificationTemplate, string ApiMethodComment, string UserDescriptionForMethod, string NameSpaceList, int? SoftwareLanguageId, int? FunctionGroupId, bool? FunctionIsParentInGroup, int? FunctionCallRankInGroup, string CustomCode, decimal? Price, int? CurrencyId, decimal? Commission, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsInserts(DatabaseTypesId, CrudType, Query, UserId, UserAgent, CreatedDate, LastScanDate, UserConnectionsId, RequestScheme, ResponseScheme, Route, HeaderScheme, WithMethods, WithHeaders, WithOrigins, CacheDBConnection, CacheType, DocumentUrl, ExampleRequest, ExampleResponse, HasAsync, HasCacheMethod, ResponseHasMultiModel, ResponseHasReturnValue, LogCodeMergeDateDBType, LogCodeMergeDateDBConnection, WillLogAllRequest, WillLogCodeMergeDate, WillLogAllResponse, IsDeleted, Statu, PublishedDate, EventType, AccessModifierId, AcceptableQuerystrings, HasRateLimit, RateLimitProperty, HasAuditEvents, HasBusEvent, i18Json, IfResponseIsSuccessCallThisFunctionId, SuccessNotificationTemplate, ApiMethodComment, UserDescriptionForMethod, NameSpaceList, SoftwareLanguageId, FunctionGroupId, FunctionIsParentInGroup, FunctionCallRankInGroup, CustomCode, Price, CurrencyId, Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsupdates/csv")]
        [HttpGet("/export/JSONServer/projectfunctionsupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsUpdatesToCSV(int? Id, int? DatabaseTypesId, int? CrudType, string Query, int? UserId, string UserAgent, string CreatedDate, string LastScanDate, int? UserConnectionsId, string RequestScheme, string ResponseScheme, string Route, string HeaderScheme, string WithMethods, string WithHeaders, string WithOrigins, int? CacheDBConnection, int? CacheType, string DocumentUrl, string ExampleRequest, string ExampleResponse, bool? HasAsync, bool? HasCacheMethod, bool? ResponseHasMultiModel, bool? ResponseHasReturnValue, int? LogCodeMergeDateDBType, string LogCodeMergeDateDBConnection, bool? WillLogAllRequest, bool? WillLogCodeMergeDate, bool? WillLogAllResponse, bool? IsDeleted, int? Statu, string PublishedDate, int? EventType, int? AccessModifierId, string AcceptableQuerystrings, bool? HasRateLimit, string RateLimitProperty, bool? HasAuditEvents, bool? HasBusEvent, string i18Json, int? IfResponseIsSuccessCallThisFunctionId, string SuccessNotificationTemplate, string ApiMethodComment, string UserDescriptionForMethod, string NameSpaceList, int? SoftwareLanguageId, int? FunctionGroupId, bool? FunctionIsParentInGroup, int? FunctionCallRankInGroup, string CustomCode, decimal? Price, int? CurrencyId, decimal? Commission, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionsUpdates(Id, DatabaseTypesId, CrudType, Query, UserId, UserAgent, CreatedDate, LastScanDate, UserConnectionsId, RequestScheme, ResponseScheme, Route, HeaderScheme, WithMethods, WithHeaders, WithOrigins, CacheDBConnection, CacheType, DocumentUrl, ExampleRequest, ExampleResponse, HasAsync, HasCacheMethod, ResponseHasMultiModel, ResponseHasReturnValue, LogCodeMergeDateDBType, LogCodeMergeDateDBConnection, WillLogAllRequest, WillLogCodeMergeDate, WillLogAllResponse, IsDeleted, Statu, PublishedDate, EventType, AccessModifierId, AcceptableQuerystrings, HasRateLimit, RateLimitProperty, HasAuditEvents, HasBusEvent, i18Json, IfResponseIsSuccessCallThisFunctionId, SuccessNotificationTemplate, ApiMethodComment, UserDescriptionForMethod, NameSpaceList, SoftwareLanguageId, FunctionGroupId, FunctionIsParentInGroup, FunctionCallRankInGroup, CustomCode, Price, CurrencyId, Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectfunctionsupdates/excel")]
        [HttpGet("/export/JSONServer/projectfunctionsupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsUpdatesToExcel(int? Id, int? DatabaseTypesId, int? CrudType, string Query, int? UserId, string UserAgent, string CreatedDate, string LastScanDate, int? UserConnectionsId, string RequestScheme, string ResponseScheme, string Route, string HeaderScheme, string WithMethods, string WithHeaders, string WithOrigins, int? CacheDBConnection, int? CacheType, string DocumentUrl, string ExampleRequest, string ExampleResponse, bool? HasAsync, bool? HasCacheMethod, bool? ResponseHasMultiModel, bool? ResponseHasReturnValue, int? LogCodeMergeDateDBType, string LogCodeMergeDateDBConnection, bool? WillLogAllRequest, bool? WillLogCodeMergeDate, bool? WillLogAllResponse, bool? IsDeleted, int? Statu, string PublishedDate, int? EventType, int? AccessModifierId, string AcceptableQuerystrings, bool? HasRateLimit, string RateLimitProperty, bool? HasAuditEvents, bool? HasBusEvent, string i18Json, int? IfResponseIsSuccessCallThisFunctionId, string SuccessNotificationTemplate, string ApiMethodComment, string UserDescriptionForMethod, string NameSpaceList, int? SoftwareLanguageId, int? FunctionGroupId, bool? FunctionIsParentInGroup, int? FunctionCallRankInGroup, string CustomCode, decimal? Price, int? CurrencyId, decimal? Commission, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionsUpdates(Id, DatabaseTypesId, CrudType, Query, UserId, UserAgent, CreatedDate, LastScanDate, UserConnectionsId, RequestScheme, ResponseScheme, Route, HeaderScheme, WithMethods, WithHeaders, WithOrigins, CacheDBConnection, CacheType, DocumentUrl, ExampleRequest, ExampleResponse, HasAsync, HasCacheMethod, ResponseHasMultiModel, ResponseHasReturnValue, LogCodeMergeDateDBType, LogCodeMergeDateDBConnection, WillLogAllRequest, WillLogCodeMergeDate, WillLogAllResponse, IsDeleted, Statu, PublishedDate, EventType, AccessModifierId, AcceptableQuerystrings, HasRateLimit, RateLimitProperty, HasAuditEvents, HasBusEvent, i18Json, IfResponseIsSuccessCallThisFunctionId, SuccessNotificationTemplate, ApiMethodComment, UserDescriptionForMethod, NameSpaceList, SoftwareLanguageId, FunctionGroupId, FunctionIsParentInGroup, FunctionCallRankInGroup, CustomCode, Price, CurrencyId, Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetalls/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetalls/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyapirequesturls/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyapirequesturls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByApiRequestUrlsToCSV(string ApiRequestUrl, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByApiRequestUrls(ApiRequestUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyapirequesturls/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyapirequesturls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByApiRequestUrlsToExcel(string ApiRequestUrl, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByApiRequestUrls(ApiRequestUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbybuseventconnectionids/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbybuseventconnectionids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByBusEventConnectionIdsToCSV(int? BusEventConnectionId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByBusEventConnectionIds(BusEventConnectionId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbybuseventconnectionids/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbybuseventconnectionids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByBusEventConnectionIdsToExcel(int? BusEventConnectionId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByBusEventConnectionIds(BusEventConnectionId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycachedbconnections/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycachedbconnections/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCacheDbConnectionsToCSV(int? CacheDBConnection, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByCacheDbConnections(CacheDBConnection), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycachedbconnections/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycachedbconnections/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCacheDbConnectionsToExcel(int? CacheDBConnection, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByCacheDbConnections(CacheDBConnection), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycachetypes/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycachetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCacheTypesToCSV(int? CacheType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByCacheTypes(CacheType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycachetypes/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycachetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCacheTypesToExcel(int? CacheType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByCacheTypes(CacheType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycomments/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycomments/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCommentsToCSV(string Comment, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByComments(Comment), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycomments/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycomments/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCommentsToExcel(string Comment, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByComments(Comment), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycommissions/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycommissions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCommissionsToCSV(decimal? Commission, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByCommissions(Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycommissions/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycommissions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCommissionsToExcel(decimal? Commission, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByCommissions(Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycomponentcallrankingroups/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycomponentcallrankingroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByComponentCallRankInGroupsToCSV(int? ComponentCallRankInGroup, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByComponentCallRankInGroups(ComponentCallRankInGroup), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycomponentcallrankingroups/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycomponentcallrankingroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByComponentCallRankInGroupsToExcel(int? ComponentCallRankInGroup, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByComponentCallRankInGroups(ComponentCallRankInGroup), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycomponentgroupids/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycomponentgroupids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByComponentGroupIdsToCSV(int? ComponentGroupId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByComponentGroupIds(ComponentGroupId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycomponentgroupids/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycomponentgroupids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByComponentGroupIdsToExcel(int? ComponentGroupId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByComponentGroupIds(ComponentGroupId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycomponentisparentingroups/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycomponentisparentingroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByComponentIsParentInGroupsToCSV(bool? ComponentIsParentInGroup, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByComponentIsParentInGroups(ComponentIsParentInGroup), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycomponentisparentingroups/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycomponentisparentingroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByComponentIsParentInGroupsToExcel(bool? ComponentIsParentInGroup, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByComponentIsParentInGroups(ComponentIsParentInGroup), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycreateddates/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycreateddates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCreatedDatesToCSV(string CreatedDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByCreatedDates(CreatedDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycreateddates/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycreateddates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCreatedDatesToExcel(string CreatedDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByCreatedDates(CreatedDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycrudtypes/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycrudtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCrudTypesToCSV(int? CrudType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByCrudTypes(CrudType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycrudtypes/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycrudtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCrudTypesToExcel(int? CrudType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByCrudTypes(CrudType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycurrencyids/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycurrencyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCurrencyIdsToCSV(int? CurrencyId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByCurrencyIds(CurrencyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycurrencyids/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycurrencyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCurrencyIdsToExcel(int? CurrencyId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByCurrencyIds(CurrencyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomanimationschemes/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomanimationschemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCustomAnimationSchemesToCSV(string CustomAnimationScheme, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByCustomAnimationSchemes(CustomAnimationScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomanimationschemes/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomanimationschemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCustomAnimationSchemesToExcel(string CustomAnimationScheme, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByCustomAnimationSchemes(CustomAnimationScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomcodes/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomcodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCustomCodesToCSV(string CustomCode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByCustomCodes(CustomCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomcodes/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomcodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCustomCodesToExcel(string CustomCode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByCustomCodes(CustomCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomcsses/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomcsses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCustomCssesToCSV(string CustomCss, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByCustomCsses(CustomCss), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomcsses/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomcsses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCustomCssesToExcel(string CustomCss, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByCustomCsses(CustomCss), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomschemes/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomschemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCustomSchemesToCSV(string CustomScheme, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByCustomSchemes(CustomScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomschemes/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomschemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCustomSchemesToExcel(string CustomScheme, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByCustomSchemes(CustomScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomscripts/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomscripts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCustomScriptsToCSV(string CustomScript, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByCustomScripts(CustomScript), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomscripts/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbycustomscripts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByCustomScriptsToExcel(string CustomScript, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByCustomScripts(CustomScript), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbydatabasetypesids/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbydatabasetypesids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByDatabaseTypesIdsToCSV(int? DatabaseTypesId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByDatabaseTypesIds(DatabaseTypesId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbydatabasetypesids/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbydatabasetypesids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByDatabaseTypesIdsToExcel(int? DatabaseTypesId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByDatabaseTypesIds(DatabaseTypesId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbydocumenturls/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbydocumenturls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByDocumentUrlsToCSV(string DocumentUrl, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByDocumentUrls(DocumentUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbydocumenturls/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbydocumenturls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByDocumentUrlsToExcel(string DocumentUrl, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByDocumentUrls(DocumentUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyeventtypes/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyeventtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByEventTypesToCSV(int? EventType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByEventTypes(EventType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyeventtypes/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyeventtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByEventTypesToExcel(int? EventType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByEventTypes(EventType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyexamplehtmlcodes/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyexamplehtmlcodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByExampleHtmlCodesToCSV(string ExampleHtmlCode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByExampleHtmlCodes(ExampleHtmlCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyexamplehtmlcodes/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyexamplehtmlcodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByExampleHtmlCodesToExcel(string ExampleHtmlCode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByExampleHtmlCodes(ExampleHtmlCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyexamplerequests/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyexamplerequests/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByExampleRequestsToCSV(string ExampleRequest, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByExampleRequests(ExampleRequest), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyexamplerequests/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyexamplerequests/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByExampleRequestsToExcel(string ExampleRequest, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByExampleRequests(ExampleRequest), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyexampleresponses/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyexampleresponses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByExampleResponsesToCSV(string ExampleResponse, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByExampleResponses(ExampleResponse), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyexampleresponses/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyexampleresponses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByExampleResponsesToExcel(string ExampleResponse, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByExampleResponses(ExampleResponse), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyfunctiontriggercallaftersuccessfulltriggers/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyfunctiontriggercallaftersuccessfulltriggers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTriggersToCSV(int? FunctionTriggerCallAfterSuccessfullTrigger, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTriggers(FunctionTriggerCallAfterSuccessfullTrigger), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyfunctiontriggercallaftersuccessfulltriggers/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyfunctiontriggercallaftersuccessfulltriggers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTriggersToExcel(int? FunctionTriggerCallAfterSuccessfullTrigger, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTriggers(FunctionTriggerCallAfterSuccessfullTrigger), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyfunctiontriggergroupids/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyfunctiontriggergroupids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByFunctionTriggerGroupIdsToCSV(int? FunctionTriggerGroupId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByFunctionTriggerGroupIds(FunctionTriggerGroupId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyfunctiontriggergroupids/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyfunctiontriggergroupids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByFunctionTriggerGroupIdsToExcel(int? FunctionTriggerGroupId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByFunctionTriggerGroupIds(FunctionTriggerGroupId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyfunctiontriggerranks/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyfunctiontriggerranks/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByFunctionTriggerRanksToCSV(int? FunctionTriggerRank, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByFunctionTriggerRanks(FunctionTriggerRank), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyfunctiontriggerranks/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyfunctiontriggerranks/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByFunctionTriggerRanksToExcel(int? FunctionTriggerRank, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByFunctionTriggerRanks(FunctionTriggerRank), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyhasasyncs/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyhasasyncs/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByHasAsyncsToCSV(bool? HasAsync, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByHasAsyncs(HasAsync), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyhasasyncs/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyhasasyncs/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByHasAsyncsToExcel(bool? HasAsync, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByHasAsyncs(HasAsync), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyhasbusevents/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyhasbusevents/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByHasBusEventsToCSV(bool? HasBusEvent, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByHasBusEvents(HasBusEvent), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyhasbusevents/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyhasbusevents/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByHasBusEventsToExcel(bool? HasBusEvent, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByHasBusEvents(HasBusEvent), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyhascachemethods/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyhascachemethods/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByHasCacheMethodsToCSV(bool? HasCacheMethod, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByHasCacheMethods(HasCacheMethod), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyhascachemethods/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyhascachemethods/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByHasCacheMethodsToExcel(bool? HasCacheMethod, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByHasCacheMethods(HasCacheMethod), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyhascodebuilds/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyhascodebuilds/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByHasCodeBuildsToCSV(string HasCodeBuild, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByHasCodeBuilds(HasCodeBuild), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyhascodebuilds/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyhascodebuilds/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByHasCodeBuildsToExcel(string HasCodeBuild, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByHasCodeBuilds(HasCodeBuild), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyi18jsons/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyi18jsons/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByi18JsonsToCSV(string i18Json, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByi18Jsons(i18Json), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyi18jsons/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyi18jsons/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByi18JsonsToExcel(string i18Json, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByi18Jsons(i18Json), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyids/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyids/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyifresponseissuccesscallthiscomponentpartids/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyifresponseissuccesscallthiscomponentpartids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartIdsToCSV(int? IfResponseIsSuccessCallThisComponentPartId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartIds(IfResponseIsSuccessCallThisComponentPartId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyifresponseissuccesscallthiscomponentpartids/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyifresponseissuccesscallthiscomponentpartids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartIdsToExcel(int? IfResponseIsSuccessCallThisComponentPartId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartIds(IfResponseIsSuccessCallThisComponentPartId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyisdeleteds/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyisdeleteds/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByIsDeletedsToCSV(bool? IsDeleted, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByIsDeleteds(IsDeleted), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyisdeleteds/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyisdeleteds/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByIsDeletedsToExcel(bool? IsDeleted, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByIsDeleteds(IsDeleted), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbylastscandates/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbylastscandates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByLastScanDatesToCSV(string LastScanDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByLastScanDates(LastScanDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbylastscandates/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbylastscandates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByLastScanDatesToExcel(string LastScanDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByLastScanDates(LastScanDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbylogcodemergedatedbconnections/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbylogcodemergedatedbconnections/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByLogCodeMergeDateDbConnectionsToCSV(string LogCodeMergeDateDBConnection, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByLogCodeMergeDateDbConnections(LogCodeMergeDateDBConnection), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbylogcodemergedatedbconnections/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbylogcodemergedatedbconnections/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByLogCodeMergeDateDbConnectionsToExcel(string LogCodeMergeDateDBConnection, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByLogCodeMergeDateDbConnections(LogCodeMergeDateDBConnection), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbylogcodemergedatedbtypes/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbylogcodemergedatedbtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByLogCodeMergeDateDbTypesToCSV(int? LogCodeMergeDateDBType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByLogCodeMergeDateDbTypes(LogCodeMergeDateDBType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbylogcodemergedatedbtypes/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbylogcodemergedatedbtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByLogCodeMergeDateDbTypesToExcel(int? LogCodeMergeDateDBType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByLogCodeMergeDateDbTypes(LogCodeMergeDateDBType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbynamespacelists/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbynamespacelists/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByNameSpaceListsToCSV(string NameSpaceList, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByNameSpaceLists(NameSpaceList), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbynamespacelists/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbynamespacelists/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByNameSpaceListsToExcel(string NameSpaceList, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByNameSpaceLists(NameSpaceList), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbypreviewcodes/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbypreviewcodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByPreviewCodesToCSV(string PreviewCode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByPreviewCodes(PreviewCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbypreviewcodes/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbypreviewcodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByPreviewCodesToExcel(string PreviewCode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByPreviewCodes(PreviewCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbypreviewurls/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbypreviewurls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByPreviewUrlsToCSV(string PreviewUrl, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByPreviewUrls(PreviewUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbypreviewurls/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbypreviewurls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByPreviewUrlsToExcel(string PreviewUrl, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByPreviewUrls(PreviewUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyprices/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyprices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByPricesToCSV(decimal? Price, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByPrices(Price), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyprices/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyprices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByPricesToExcel(decimal? Price, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByPrices(Price), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbypublisheddates/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbypublisheddates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByPublishedDatesToCSV(string PublishedDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByPublishedDates(PublishedDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbypublisheddates/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbypublisheddates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByPublishedDatesToExcel(string PublishedDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByPublishedDates(PublishedDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyqueries/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyqueries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByQueriesToCSV(string Query, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByQueries(Query), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyqueries/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyqueries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByQueriesToExcel(string Query, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByQueries(Query), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyrequestheaders/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyrequestheaders/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByRequestHeadersToCSV(string RequestHeader, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByRequestHeaders(RequestHeader), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyrequestheaders/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyrequestheaders/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByRequestHeadersToExcel(string RequestHeader, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByRequestHeaders(RequestHeader), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyrequestschemes/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyrequestschemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByRequestSchemesToCSV(string RequestScheme, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByRequestSchemes(RequestScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyrequestschemes/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyrequestschemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByRequestSchemesToExcel(string RequestScheme, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByRequestSchemes(RequestScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyresponsehasmultimodels/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyresponsehasmultimodels/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByResponseHasMultiModelsToCSV(bool? ResponseHasMultiModel, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByResponseHasMultiModels(ResponseHasMultiModel), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyresponsehasmultimodels/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyresponsehasmultimodels/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByResponseHasMultiModelsToExcel(bool? ResponseHasMultiModel, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByResponseHasMultiModels(ResponseHasMultiModel), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyresponsehasreturnvalues/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyresponsehasreturnvalues/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByResponseHasReturnValuesToCSV(bool? ResponseHasReturnValue, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByResponseHasReturnValues(ResponseHasReturnValue), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyresponsehasreturnvalues/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyresponsehasreturnvalues/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByResponseHasReturnValuesToExcel(bool? ResponseHasReturnValue, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByResponseHasReturnValues(ResponseHasReturnValue), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyresponseschemes/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyresponseschemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByResponseSchemesToCSV(string ResponseScheme, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByResponseSchemes(ResponseScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyresponseschemes/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyresponseschemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByResponseSchemesToExcel(string ResponseScheme, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByResponseSchemes(ResponseScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbysoftwarelanguageids/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbysoftwarelanguageids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetBySoftwareLanguageIdsToCSV(int? SoftwareLanguageId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetBySoftwareLanguageIds(SoftwareLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbysoftwarelanguageids/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbysoftwarelanguageids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetBySoftwareLanguageIdsToExcel(int? SoftwareLanguageId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetBySoftwareLanguageIds(SoftwareLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbystatus/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbystatus/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByStatusToCSV(int? Statu, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByStatus(Statu), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbystatus/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbystatus/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByStatusToExcel(int? Statu, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByStatus(Statu), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbysuccessnotificationtemplates/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbysuccessnotificationtemplates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetBySuccessNotificationTemplatesToCSV(string SuccessNotificationTemplate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetBySuccessNotificationTemplates(SuccessNotificationTemplate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbysuccessnotificationtemplates/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbysuccessnotificationtemplates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetBySuccessNotificationTemplatesToExcel(string SuccessNotificationTemplate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetBySuccessNotificationTemplates(SuccessNotificationTemplate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyuseragents/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyuseragents/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByUserAgentsToCSV(string UserAgent, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByUserAgents(UserAgent), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyuseragents/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyuseragents/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByUserAgentsToExcel(string UserAgent, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByUserAgents(UserAgent), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyuserdescriptionforcomponents/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyuserdescriptionforcomponents/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByUserDescriptionForComponentsToCSV(string UserDescriptionForComponent, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByUserDescriptionForComponents(UserDescriptionForComponent), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyuserdescriptionforcomponents/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyuserdescriptionforcomponents/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByUserDescriptionForComponentsToExcel(string UserDescriptionForComponent, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByUserDescriptionForComponents(UserDescriptionForComponent), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyuserids/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyuserids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByUserIdsToCSV(int? UserId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByUserIds(UserId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyuserids/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbyuserids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByUserIdsToExcel(int? UserId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByUserIds(UserId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywebsitepagecomponentsids/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywebsitepagecomponentsids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByWebSitePageComponentsIdsToCSV(int? WebSitePageComponentsId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByWebSitePageComponentsIds(WebSitePageComponentsId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywebsitepagecomponentsids/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywebsitepagecomponentsids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByWebSitePageComponentsIdsToExcel(int? WebSitePageComponentsId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByWebSitePageComponentsIds(WebSitePageComponentsId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywilllogallrequests/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywilllogallrequests/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByWillLogAllRequestsToCSV(bool? WillLogAllRequest, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByWillLogAllRequests(WillLogAllRequest), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywilllogallrequests/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywilllogallrequests/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByWillLogAllRequestsToExcel(bool? WillLogAllRequest, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByWillLogAllRequests(WillLogAllRequest), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywilllogallresponses/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywilllogallresponses/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByWillLogAllResponsesToCSV(bool? WillLogAllResponse, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByWillLogAllResponses(WillLogAllResponse), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywilllogallresponses/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywilllogallresponses/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByWillLogAllResponsesToExcel(bool? WillLogAllResponse, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByWillLogAllResponses(WillLogAllResponse), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywilllogcodemergedates/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywilllogcodemergedates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByWillLogCodeMergeDatesToCSV(bool? WillLogCodeMergeDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByWillLogCodeMergeDates(WillLogCodeMergeDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywilllogcodemergedates/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywilllogcodemergedates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByWillLogCodeMergeDatesToExcel(bool? WillLogCodeMergeDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByWillLogCodeMergeDates(WillLogCodeMergeDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywithheaders/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywithheaders/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByWithHeadersToCSV(string WithHeaders, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByWithHeaders(WithHeaders), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywithheaders/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywithheaders/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByWithHeadersToExcel(string WithHeaders, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByWithHeaders(WithHeaders), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywithmethods/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywithmethods/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByWithMethodsToCSV(string WithMethods, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByWithMethods(WithMethods), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywithmethods/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywithmethods/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByWithMethodsToExcel(string WithMethods, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByWithMethods(WithMethods), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywithorigins/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywithorigins/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByWithOriginsToCSV(string WithOrigins, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetByWithOrigins(WithOrigins), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywithorigins/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetbywithorigins/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetByWithOriginsToExcel(string WithOrigins, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetByWithOrigins(WithOrigins), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetcreateddatebetweens/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetcreateddatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetCreatedDateBetweensToCSV(string CreatedDateStart, string CreatedDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetCreatedDateBetweens(CreatedDateStart, CreatedDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetcreateddatebetweens/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetcreateddatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetCreatedDateBetweensToExcel(string CreatedDateStart, string CreatedDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetCreatedDateBetweens(CreatedDateStart, CreatedDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetlastscandatebetweens/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetlastscandatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetLastScanDateBetweensToCSV(string LastScanDateStart, string LastScanDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetLastScanDateBetweens(LastScanDateStart, LastScanDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetlastscandatebetweens/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetlastscandatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetLastScanDateBetweensToExcel(string LastScanDateStart, string LastScanDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetLastScanDateBetweens(LastScanDateStart, LastScanDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetpublisheddatebetweens/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetpublisheddatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetPublishedDateBetweensToCSV(string PublishedDateStart, string PublishedDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsGetPublishedDateBetweens(PublishedDateStart, PublishedDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetpublisheddatebetweens/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsgetpublisheddatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsGetPublishedDateBetweensToExcel(string PublishedDateStart, string PublishedDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsGetPublishedDateBetweens(PublishedDateStart, PublishedDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsinserts/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsInsertsToCSV(int? WebSitePageComponentsId, int? DatabaseTypesId, int? FunctionTriggerGroupId, int? FunctionTriggerRank, int? FunctionTriggerCallAfterSuccessfullTrigger, int? CrudType, string Query, int? UserId, string UserAgent, string CreatedDate, string LastScanDate, string ExampleRequest, string ExampleHtmlCode, string PreviewCode, string PreviewUrl, string HasCodeBuild, string ExampleResponse, string RequestScheme, string ResponseScheme, string ApiRequestUrl, string RequestHeader, string WithMethods, string WithHeaders, string WithOrigins, int? CacheDBConnection, int? CacheType, string DocumentUrl, bool? HasAsync, bool? HasCacheMethod, bool? ResponseHasMultiModel, bool? ResponseHasReturnValue, int? LogCodeMergeDateDBType, string LogCodeMergeDateDBConnection, bool? WillLogAllRequest, bool? WillLogCodeMergeDate, bool? WillLogAllResponse, bool? IsDeleted, int? Statu, string PublishedDate, int? EventType, bool? HasBusEvent, string i18Json, int? IfResponseIsSuccessCallThisComponentPartId, string SuccessNotificationTemplate, string Comment, string UserDescriptionForComponent, string NameSpaceList, int? SoftwareLanguageId, int? ComponentGroupId, bool? ComponentIsParentInGroup, int? ComponentCallRankInGroup, string CustomCode, string CustomCss, string CustomScript, string CustomScheme, string CustomAnimationScheme, decimal? Price, int? CurrencyId, int? BusEventConnectionId, decimal? Commission, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsInserts(WebSitePageComponentsId, DatabaseTypesId, FunctionTriggerGroupId, FunctionTriggerRank, FunctionTriggerCallAfterSuccessfullTrigger, CrudType, Query, UserId, UserAgent, CreatedDate, LastScanDate, ExampleRequest, ExampleHtmlCode, PreviewCode, PreviewUrl, HasCodeBuild, ExampleResponse, RequestScheme, ResponseScheme, ApiRequestUrl, RequestHeader, WithMethods, WithHeaders, WithOrigins, CacheDBConnection, CacheType, DocumentUrl, HasAsync, HasCacheMethod, ResponseHasMultiModel, ResponseHasReturnValue, LogCodeMergeDateDBType, LogCodeMergeDateDBConnection, WillLogAllRequest, WillLogCodeMergeDate, WillLogAllResponse, IsDeleted, Statu, PublishedDate, EventType, HasBusEvent, i18Json, IfResponseIsSuccessCallThisComponentPartId, SuccessNotificationTemplate, Comment, UserDescriptionForComponent, NameSpaceList, SoftwareLanguageId, ComponentGroupId, ComponentIsParentInGroup, ComponentCallRankInGroup, CustomCode, CustomCss, CustomScript, CustomScheme, CustomAnimationScheme, Price, CurrencyId, BusEventConnectionId, Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsinserts/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsInsertsToExcel(int? WebSitePageComponentsId, int? DatabaseTypesId, int? FunctionTriggerGroupId, int? FunctionTriggerRank, int? FunctionTriggerCallAfterSuccessfullTrigger, int? CrudType, string Query, int? UserId, string UserAgent, string CreatedDate, string LastScanDate, string ExampleRequest, string ExampleHtmlCode, string PreviewCode, string PreviewUrl, string HasCodeBuild, string ExampleResponse, string RequestScheme, string ResponseScheme, string ApiRequestUrl, string RequestHeader, string WithMethods, string WithHeaders, string WithOrigins, int? CacheDBConnection, int? CacheType, string DocumentUrl, bool? HasAsync, bool? HasCacheMethod, bool? ResponseHasMultiModel, bool? ResponseHasReturnValue, int? LogCodeMergeDateDBType, string LogCodeMergeDateDBConnection, bool? WillLogAllRequest, bool? WillLogCodeMergeDate, bool? WillLogAllResponse, bool? IsDeleted, int? Statu, string PublishedDate, int? EventType, bool? HasBusEvent, string i18Json, int? IfResponseIsSuccessCallThisComponentPartId, string SuccessNotificationTemplate, string Comment, string UserDescriptionForComponent, string NameSpaceList, int? SoftwareLanguageId, int? ComponentGroupId, bool? ComponentIsParentInGroup, int? ComponentCallRankInGroup, string CustomCode, string CustomCss, string CustomScript, string CustomScheme, string CustomAnimationScheme, decimal? Price, int? CurrencyId, int? BusEventConnectionId, decimal? Commission, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsInserts(WebSitePageComponentsId, DatabaseTypesId, FunctionTriggerGroupId, FunctionTriggerRank, FunctionTriggerCallAfterSuccessfullTrigger, CrudType, Query, UserId, UserAgent, CreatedDate, LastScanDate, ExampleRequest, ExampleHtmlCode, PreviewCode, PreviewUrl, HasCodeBuild, ExampleResponse, RequestScheme, ResponseScheme, ApiRequestUrl, RequestHeader, WithMethods, WithHeaders, WithOrigins, CacheDBConnection, CacheType, DocumentUrl, HasAsync, HasCacheMethod, ResponseHasMultiModel, ResponseHasReturnValue, LogCodeMergeDateDBType, LogCodeMergeDateDBConnection, WillLogAllRequest, WillLogCodeMergeDate, WillLogAllResponse, IsDeleted, Statu, PublishedDate, EventType, HasBusEvent, i18Json, IfResponseIsSuccessCallThisComponentPartId, SuccessNotificationTemplate, Comment, UserDescriptionForComponent, NameSpaceList, SoftwareLanguageId, ComponentGroupId, ComponentIsParentInGroup, ComponentCallRankInGroup, CustomCode, CustomCss, CustomScript, CustomScheme, CustomAnimationScheme, Price, CurrencyId, BusEventConnectionId, Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsupdates/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsUpdatesToCSV(int? Id, int? WebSitePageComponentsId, int? DatabaseTypesId, int? FunctionTriggerGroupId, int? FunctionTriggerRank, int? FunctionTriggerCallAfterSuccessfullTrigger, int? CrudType, string Query, int? UserId, string UserAgent, string CreatedDate, string LastScanDate, string ExampleRequest, string ExampleHtmlCode, string PreviewCode, string PreviewUrl, string HasCodeBuild, string ExampleResponse, string RequestScheme, string ResponseScheme, string ApiRequestUrl, string RequestHeader, string WithMethods, string WithHeaders, string WithOrigins, int? CacheDBConnection, int? CacheType, string DocumentUrl, bool? HasAsync, bool? HasCacheMethod, bool? ResponseHasMultiModel, bool? ResponseHasReturnValue, int? LogCodeMergeDateDBType, string LogCodeMergeDateDBConnection, bool? WillLogAllRequest, bool? WillLogCodeMergeDate, bool? WillLogAllResponse, bool? IsDeleted, int? Statu, string PublishedDate, int? EventType, bool? HasBusEvent, string i18Json, int? IfResponseIsSuccessCallThisComponentPartId, string SuccessNotificationTemplate, string Comment, string UserDescriptionForComponent, string NameSpaceList, int? SoftwareLanguageId, int? ComponentGroupId, bool? ComponentIsParentInGroup, int? ComponentCallRankInGroup, string CustomCode, string CustomCss, string CustomScript, string CustomScheme, string CustomAnimationScheme, decimal? Price, int? CurrencyId, int? BusEventConnectionId, decimal? Commission, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElementsUpdates(Id, WebSitePageComponentsId, DatabaseTypesId, FunctionTriggerGroupId, FunctionTriggerRank, FunctionTriggerCallAfterSuccessfullTrigger, CrudType, Query, UserId, UserAgent, CreatedDate, LastScanDate, ExampleRequest, ExampleHtmlCode, PreviewCode, PreviewUrl, HasCodeBuild, ExampleResponse, RequestScheme, ResponseScheme, ApiRequestUrl, RequestHeader, WithMethods, WithHeaders, WithOrigins, CacheDBConnection, CacheType, DocumentUrl, HasAsync, HasCacheMethod, ResponseHasMultiModel, ResponseHasReturnValue, LogCodeMergeDateDBType, LogCodeMergeDateDBConnection, WillLogAllRequest, WillLogCodeMergeDate, WillLogAllResponse, IsDeleted, Statu, PublishedDate, EventType, HasBusEvent, i18Json, IfResponseIsSuccessCallThisComponentPartId, SuccessNotificationTemplate, Comment, UserDescriptionForComponent, NameSpaceList, SoftwareLanguageId, ComponentGroupId, ComponentIsParentInGroup, ComponentCallRankInGroup, CustomCode, CustomCss, CustomScript, CustomScheme, CustomAnimationScheme, Price, CurrencyId, BusEventConnectionId, Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentelementsupdates/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentelementsupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsUpdatesToExcel(int? Id, int? WebSitePageComponentsId, int? DatabaseTypesId, int? FunctionTriggerGroupId, int? FunctionTriggerRank, int? FunctionTriggerCallAfterSuccessfullTrigger, int? CrudType, string Query, int? UserId, string UserAgent, string CreatedDate, string LastScanDate, string ExampleRequest, string ExampleHtmlCode, string PreviewCode, string PreviewUrl, string HasCodeBuild, string ExampleResponse, string RequestScheme, string ResponseScheme, string ApiRequestUrl, string RequestHeader, string WithMethods, string WithHeaders, string WithOrigins, int? CacheDBConnection, int? CacheType, string DocumentUrl, bool? HasAsync, bool? HasCacheMethod, bool? ResponseHasMultiModel, bool? ResponseHasReturnValue, int? LogCodeMergeDateDBType, string LogCodeMergeDateDBConnection, bool? WillLogAllRequest, bool? WillLogCodeMergeDate, bool? WillLogAllResponse, bool? IsDeleted, int? Statu, string PublishedDate, int? EventType, bool? HasBusEvent, string i18Json, int? IfResponseIsSuccessCallThisComponentPartId, string SuccessNotificationTemplate, string Comment, string UserDescriptionForComponent, string NameSpaceList, int? SoftwareLanguageId, int? ComponentGroupId, bool? ComponentIsParentInGroup, int? ComponentCallRankInGroup, string CustomCode, string CustomCss, string CustomScript, string CustomScheme, string CustomAnimationScheme, decimal? Price, int? CurrencyId, int? BusEventConnectionId, decimal? Commission, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElementsUpdates(Id, WebSitePageComponentsId, DatabaseTypesId, FunctionTriggerGroupId, FunctionTriggerRank, FunctionTriggerCallAfterSuccessfullTrigger, CrudType, Query, UserId, UserAgent, CreatedDate, LastScanDate, ExampleRequest, ExampleHtmlCode, PreviewCode, PreviewUrl, HasCodeBuild, ExampleResponse, RequestScheme, ResponseScheme, ApiRequestUrl, RequestHeader, WithMethods, WithHeaders, WithOrigins, CacheDBConnection, CacheType, DocumentUrl, HasAsync, HasCacheMethod, ResponseHasMultiModel, ResponseHasReturnValue, LogCodeMergeDateDBType, LogCodeMergeDateDBConnection, WillLogAllRequest, WillLogCodeMergeDate, WillLogAllResponse, IsDeleted, Statu, PublishedDate, EventType, HasBusEvent, i18Json, IfResponseIsSuccessCallThisComponentPartId, SuccessNotificationTemplate, Comment, UserDescriptionForComponent, NameSpaceList, SoftwareLanguageId, ComponentGroupId, ComponentIsParentInGroup, ComponentCallRankInGroup, CustomCode, CustomCss, CustomScript, CustomScheme, CustomAnimationScheme, Price, CurrencyId, BusEventConnectionId, Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetalls/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetalls/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyapirequesturls/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyapirequesturls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByApiRequestUrlsToCSV(string ApiRequestUrl, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByApiRequestUrls(ApiRequestUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyapirequesturls/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyapirequesturls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByApiRequestUrlsToExcel(string ApiRequestUrl, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByApiRequestUrls(ApiRequestUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycommissions/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycommissions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByCommissionsToCSV(decimal? Commission, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByCommissions(Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycommissions/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycommissions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByCommissionsToExcel(decimal? Commission, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByCommissions(Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycomponentnames/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycomponentnames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByComponentNamesToCSV(string ComponentName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByComponentNames(ComponentName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycomponentnames/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycomponentnames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByComponentNamesToExcel(string ComponentName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByComponentNames(ComponentName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycreateddates/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycreateddates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByCreatedDatesToCSV(string CreatedDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByCreatedDates(CreatedDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycreateddates/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycreateddates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByCreatedDatesToExcel(string CreatedDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByCreatedDates(CreatedDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycrudtypes/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycrudtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByCrudTypesToCSV(int? CrudType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByCrudTypes(CrudType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycrudtypes/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycrudtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByCrudTypesToExcel(int? CrudType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByCrudTypes(CrudType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycurrencyids/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycurrencyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByCurrencyIdsToCSV(int? CurrencyId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByCurrencyIds(CurrencyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycurrencyids/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbycurrencyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByCurrencyIdsToExcel(int? CurrencyId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByCurrencyIds(CurrencyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbydatabaseids/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbydatabaseids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByDatabaseIdsToCSV(int? DatabaseId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByDatabaseIds(DatabaseId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbydatabaseids/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbydatabaseids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByDatabaseIdsToExcel(int? DatabaseId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByDatabaseIds(DatabaseId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbydefaultlanguages/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbydefaultlanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByDefaultLanguagesToCSV(int? DefaultLanguage, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByDefaultLanguages(DefaultLanguage), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbydefaultlanguages/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbydefaultlanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByDefaultLanguagesToExcel(int? DefaultLanguage, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByDefaultLanguages(DefaultLanguage), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyformactionurls/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyformactionurls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByFormActionUrlsToCSV(string FormActionUrl, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByFormActionUrls(FormActionUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyformactionurls/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyformactionurls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByFormActionUrlsToExcel(string FormActionUrl, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByFormActionUrls(FormActionUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyhasfinishedsuccessfullies/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyhasfinishedsuccessfullies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByHasFinishedSuccessfulliesToCSV(bool? HasFinishedSuccessfully, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByHasFinishedSuccessfullies(HasFinishedSuccessfully), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyhasfinishedsuccessfullies/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyhasfinishedsuccessfullies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByHasFinishedSuccessfulliesToExcel(bool? HasFinishedSuccessfully, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByHasFinishedSuccessfullies(HasFinishedSuccessfully), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyhasforms/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyhasforms/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByHasFormsToCSV(bool? HasForm, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByHasForms(HasForm), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyhasforms/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyhasforms/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByHasFormsToExcel(bool? HasForm, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByHasForms(HasForm), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyhasmultilanguages/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyhasmultilanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByHasMultiLanguagesToCSV(string HasMultiLanguage, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByHasMultiLanguages(HasMultiLanguage), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyhasmultilanguages/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyhasmultilanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByHasMultiLanguagesToExcel(string HasMultiLanguage, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByHasMultiLanguages(HasMultiLanguage), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyids/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyids/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbylastscandates/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbylastscandates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByLastScanDatesToCSV(string LastScanDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByLastScanDates(LastScanDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbylastscandates/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbylastscandates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByLastScanDatesToExcel(string LastScanDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByLastScanDates(LastScanDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbylastvaliddates/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbylastvaliddates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByLastValidDatesToCSV(string LastValidDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByLastValidDates(LastValidDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbylastvaliddates/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbylastvaliddates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByLastValidDatesToExcel(string LastValidDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByLastValidDates(LastValidDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbymodifydates/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbymodifydates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByModifyDatesToCSV(string ModifyDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByModifyDates(ModifyDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbymodifydates/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbymodifydates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByModifyDatesToExcel(string ModifyDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByModifyDates(ModifyDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyonhovers/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyonhovers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByOnHoversToCSV(bool? OnHover, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByOnHovers(OnHover), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyonhovers/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyonhovers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByOnHoversToExcel(bool? OnHover, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByOnHovers(OnHover), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyparentwebsitepartsids/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyparentwebsitepartsids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByParentWebSitePartsIdsToCSV(int? ParentWebSitePartsId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByParentWebSitePartsIds(ParentWebSitePartsId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyparentwebsitepartsids/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyparentwebsitepartsids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByParentWebSitePartsIdsToExcel(int? ParentWebSitePartsId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByParentWebSitePartsIds(ParentWebSitePartsId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyprices/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyprices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByPricesToCSV(decimal? Price, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByPrices(Price), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyprices/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyprices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByPricesToExcel(decimal? Price, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByPrices(Price), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyqueries/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyqueries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByQueriesToCSV(string Query, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByQueries(Query), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyqueries/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyqueries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByQueriesToExcel(string Query, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByQueries(Query), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyrequestschemes/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyrequestschemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByRequestSchemesToCSV(string RequestScheme, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByRequestSchemes(RequestScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyrequestschemes/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyrequestschemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByRequestSchemesToExcel(string RequestScheme, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByRequestSchemes(RequestScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyresponseschemes/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyresponseschemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByResponseSchemesToCSV(string ResponseScheme, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByResponseSchemes(ResponseScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyresponseschemes/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyresponseschemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByResponseSchemesToExcel(string ResponseScheme, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByResponseSchemes(ResponseScheme), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyscannedlanguages/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyscannedlanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByScannedLanguagesToCSV(int? ScannedLanguage, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByScannedLanguages(ScannedLanguage), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyscannedlanguages/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyscannedlanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByScannedLanguagesToExcel(int? ScannedLanguage, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByScannedLanguages(ScannedLanguage), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyuseragents/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyuseragents/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByUserAgentsToCSV(string UserAgent, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByUserAgents(UserAgent), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyuseragents/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyuseragents/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByUserAgentsToExcel(string UserAgent, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByUserAgents(UserAgent), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyuserids/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyuserids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByUserIdsToCSV(int? UserId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByUserIds(UserId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyuserids/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbyuserids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByUserIdsToExcel(int? UserId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByUserIds(UserId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbywebsitepagesids/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbywebsitepagesids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByWebSitePagesIdsToCSV(int? WebSitePagesId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetByWebSitePagesIds(WebSitePagesId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetbywebsitepagesids/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetbywebsitepagesids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetByWebSitePagesIdsToExcel(int? WebSitePagesId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetByWebSitePagesIds(WebSitePagesId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetcreateddatebetweens/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetcreateddatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetCreatedDateBetweensToCSV(string CreatedDateStart, string CreatedDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetCreatedDateBetweens(CreatedDateStart, CreatedDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetcreateddatebetweens/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetcreateddatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetCreatedDateBetweensToExcel(string CreatedDateStart, string CreatedDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetCreatedDateBetweens(CreatedDateStart, CreatedDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetlastscandatebetweens/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetlastscandatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetLastScanDateBetweensToCSV(string LastScanDateStart, string LastScanDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetLastScanDateBetweens(LastScanDateStart, LastScanDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetlastscandatebetweens/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetlastscandatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetLastScanDateBetweensToExcel(string LastScanDateStart, string LastScanDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetLastScanDateBetweens(LastScanDateStart, LastScanDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetlastvaliddatebetweens/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetlastvaliddatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetLastValidDateBetweensToCSV(string LastValidDateStart, string LastValidDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetLastValidDateBetweens(LastValidDateStart, LastValidDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetlastvaliddatebetweens/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetlastvaliddatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetLastValidDateBetweensToExcel(string LastValidDateStart, string LastValidDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetLastValidDateBetweens(LastValidDateStart, LastValidDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetmodifydatebetweens/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetmodifydatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetModifyDateBetweensToCSV(string ModifyDateStart, string ModifyDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsGetModifyDateBetweens(ModifyDateStart, ModifyDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsgetmodifydatebetweens/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsgetmodifydatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsGetModifyDateBetweensToExcel(string ModifyDateStart, string ModifyDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsGetModifyDateBetweens(ModifyDateStart, ModifyDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsinserts/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsInsertsToCSV(int? WebSitePagesId, string ComponentName, int? CrudType, string Query, int? DatabaseId, string RequestScheme, string ResponseScheme, string CreatedDate, string ModifyDate, string LastScanDate, int? UserId, string UserAgent, string LastValidDate, bool? HasForm, int? ParentWebSitePartsId, string HasMultiLanguage, int? DefaultLanguage, int? ScannedLanguage, bool? HasFinishedSuccessfully, bool? OnHover, string ApiRequestUrl, string FormActionUrl, decimal? Price, int? CurrencyId, decimal? Commission, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsInserts(WebSitePagesId, ComponentName, CrudType, Query, DatabaseId, RequestScheme, ResponseScheme, CreatedDate, ModifyDate, LastScanDate, UserId, UserAgent, LastValidDate, HasForm, ParentWebSitePartsId, HasMultiLanguage, DefaultLanguage, ScannedLanguage, HasFinishedSuccessfully, OnHover, ApiRequestUrl, FormActionUrl, Price, CurrencyId, Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsinserts/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsInsertsToExcel(int? WebSitePagesId, string ComponentName, int? CrudType, string Query, int? DatabaseId, string RequestScheme, string ResponseScheme, string CreatedDate, string ModifyDate, string LastScanDate, int? UserId, string UserAgent, string LastValidDate, bool? HasForm, int? ParentWebSitePartsId, string HasMultiLanguage, int? DefaultLanguage, int? ScannedLanguage, bool? HasFinishedSuccessfully, bool? OnHover, string ApiRequestUrl, string FormActionUrl, decimal? Price, int? CurrencyId, decimal? Commission, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsInserts(WebSitePagesId, ComponentName, CrudType, Query, DatabaseId, RequestScheme, ResponseScheme, CreatedDate, ModifyDate, LastScanDate, UserId, UserAgent, LastValidDate, HasForm, ParentWebSitePartsId, HasMultiLanguage, DefaultLanguage, ScannedLanguage, HasFinishedSuccessfully, OnHover, ApiRequestUrl, FormActionUrl, Price, CurrencyId, Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsupdates/csv")]
        [HttpGet("/export/JSONServer/projectpagecomponentsupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsUpdatesToCSV(int? Id, int? WebSitePagesId, string ComponentName, int? CrudType, string Query, int? DatabaseId, string RequestScheme, string ResponseScheme, string CreatedDate, string ModifyDate, string LastScanDate, int? UserId, string UserAgent, string LastValidDate, bool? HasForm, int? ParentWebSitePartsId, string HasMultiLanguage, int? DefaultLanguage, int? ScannedLanguage, bool? HasFinishedSuccessfully, bool? OnHover, string ApiRequestUrl, string FormActionUrl, decimal? Price, int? CurrencyId, decimal? Commission, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentsUpdates(Id, WebSitePagesId, ComponentName, CrudType, Query, DatabaseId, RequestScheme, ResponseScheme, CreatedDate, ModifyDate, LastScanDate, UserId, UserAgent, LastValidDate, HasForm, ParentWebSitePartsId, HasMultiLanguage, DefaultLanguage, ScannedLanguage, HasFinishedSuccessfully, OnHover, ApiRequestUrl, FormActionUrl, Price, CurrencyId, Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagecomponentsupdates/excel")]
        [HttpGet("/export/JSONServer/projectpagecomponentsupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsUpdatesToExcel(int? Id, int? WebSitePagesId, string ComponentName, int? CrudType, string Query, int? DatabaseId, string RequestScheme, string ResponseScheme, string CreatedDate, string ModifyDate, string LastScanDate, int? UserId, string UserAgent, string LastValidDate, bool? HasForm, int? ParentWebSitePartsId, string HasMultiLanguage, int? DefaultLanguage, int? ScannedLanguage, bool? HasFinishedSuccessfully, bool? OnHover, string ApiRequestUrl, string FormActionUrl, decimal? Price, int? CurrencyId, decimal? Commission, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentsUpdates(Id, WebSitePagesId, ComponentName, CrudType, Query, DatabaseId, RequestScheme, ResponseScheme, CreatedDate, ModifyDate, LastScanDate, UserId, UserAgent, LastValidDate, HasForm, ParentWebSitePartsId, HasMultiLanguage, DefaultLanguage, ScannedLanguage, HasFinishedSuccessfully, OnHover, ApiRequestUrl, FormActionUrl, Price, CurrencyId, Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetalls/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetalls/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbycommissions/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbycommissions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByCommissionsToCSV(decimal? Commission, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByCommissions(Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbycommissions/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbycommissions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByCommissionsToExcel(decimal? Commission, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByCommissions(Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbycreateddates/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbycreateddates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByCreatedDatesToCSV(string CreatedDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByCreatedDates(CreatedDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbycreateddates/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbycreateddates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByCreatedDatesToExcel(string CreatedDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByCreatedDates(CreatedDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbycsscodes/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbycsscodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByCssCodesToCSV(string CssCode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByCssCodes(CssCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbycsscodes/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbycsscodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByCssCodesToExcel(string CssCode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByCssCodes(CssCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbycurrencyids/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbycurrencyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByCurrencyIdsToCSV(int? CurrencyId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByCurrencyIds(CurrencyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbycurrencyids/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbycurrencyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByCurrencyIdsToExcel(int? CurrencyId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByCurrencyIds(CurrencyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbycustomcodes/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbycustomcodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByCustomCodesToCSV(string CustomCode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByCustomCodes(CustomCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbycustomcodes/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbycustomcodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByCustomCodesToExcel(string CustomCode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByCustomCodes(CustomCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbydefaultlanguages/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbydefaultlanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByDefaultLanguagesToCSV(int? DefaultLanguage, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByDefaultLanguages(DefaultLanguage), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbydefaultlanguages/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbydefaultlanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByDefaultLanguagesToExcel(int? DefaultLanguage, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByDefaultLanguages(DefaultLanguage), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyhasfinishedsuccessfullies/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbyhasfinishedsuccessfullies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByHasFinishedSuccessfulliesToCSV(bool? HasFinishedSuccessfully, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByHasFinishedSuccessfullies(HasFinishedSuccessfully), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyhasfinishedsuccessfullies/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbyhasfinishedsuccessfullies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByHasFinishedSuccessfulliesToExcel(bool? HasFinishedSuccessfully, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByHasFinishedSuccessfullies(HasFinishedSuccessfully), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyhasmultiplelanguages/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbyhasmultiplelanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByHasMultipleLanguagesToCSV(bool? HasMultipleLanguage, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByHasMultipleLanguages(HasMultipleLanguage), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyhasmultiplelanguages/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbyhasmultiplelanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByHasMultipleLanguagesToExcel(bool? HasMultipleLanguage, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByHasMultipleLanguages(HasMultipleLanguage), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyhaspaids/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbyhaspaids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByHasPaidsToCSV(bool? HasPaid, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByHasPaids(HasPaid), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyhaspaids/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbyhaspaids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByHasPaidsToExcel(bool? HasPaid, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByHasPaids(HasPaid), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyhtmlcodes/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbyhtmlcodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByHtmlCodesToCSV(string HtmlCode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByHtmlCodes(HtmlCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyhtmlcodes/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbyhtmlcodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByHtmlCodesToExcel(string HtmlCode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByHtmlCodes(HtmlCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyids/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyids/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyjscodes/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbyjscodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByJsCodesToCSV(string JsCode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByJsCodes(JsCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyjscodes/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbyjscodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByJsCodesToExcel(string JsCode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByJsCodes(JsCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyjsoncodes/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbyjsoncodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByJsonCodesToCSV(string JsonCode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByJsonCodes(JsonCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyjsoncodes/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbyjsoncodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByJsonCodesToExcel(string JsonCode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByJsonCodes(JsonCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbylastscandates/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbylastscandates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByLastScanDatesToCSV(string LastScanDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByLastScanDates(LastScanDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbylastscandates/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbylastscandates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByLastScanDatesToExcel(string LastScanDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByLastScanDates(LastScanDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbypagecycleeventdefinations/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbypagecycleeventdefinations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByPageCycleEventDefinationsToCSV(string PageCycleEventDefination, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByPageCycleEventDefinations(PageCycleEventDefination), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbypagecycleeventdefinations/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbypagecycleeventdefinations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByPageCycleEventDefinationsToExcel(string PageCycleEventDefination, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByPageCycleEventDefinations(PageCycleEventDefination), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbypagecycleeventdefination1s/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbypagecycleeventdefination1s/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByPageCycleEventDefination1SToCSV(string PageCycleEventDefination1, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByPageCycleEventDefination1S(PageCycleEventDefination1), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbypagecycleeventdefination1s/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbypagecycleeventdefination1s/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByPageCycleEventDefination1SToExcel(string PageCycleEventDefination1, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByPageCycleEventDefination1S(PageCycleEventDefination1), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbypagenames/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbypagenames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByPageNamesToCSV(string PageName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByPageNames(PageName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbypagenames/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbypagenames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByPageNamesToExcel(string PageName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByPageNames(PageName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbypageurls/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbypageurls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByPageUrlsToCSV(string PageUrl, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByPageUrls(PageUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbypageurls/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbypageurls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByPageUrlsToExcel(string PageUrl, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByPageUrls(PageUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyprices/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbyprices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByPricesToCSV(decimal? Price, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByPrices(Price), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyprices/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbyprices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByPricesToExcel(decimal? Price, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByPrices(Price), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyprojectids/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbyprojectids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByProjectIdsToCSV(int? ProjectId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByProjectIds(ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyprojectids/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbyprojectids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByProjectIdsToExcel(int? ProjectId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByProjectIds(ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyreferralurls/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbyreferralurls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByReferralUrlsToCSV(string ReferralUrl, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByReferralUrls(ReferralUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyreferralurls/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbyreferralurls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByReferralUrlsToExcel(string ReferralUrl, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByReferralUrls(ReferralUrl), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyroutes/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbyroutes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByRoutesToCSV(string Route, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByRoutes(Route), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyroutes/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbyroutes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByRoutesToExcel(string Route, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByRoutes(Route), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyscannedlanguages/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbyscannedlanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByScannedLanguagesToCSV(int? ScannedLanguage, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByScannedLanguages(ScannedLanguage), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyscannedlanguages/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbyscannedlanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByScannedLanguagesToExcel(int? ScannedLanguage, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByScannedLanguages(ScannedLanguage), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyuserids/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetbyuserids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByUserIdsToCSV(int? UserId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetByUserIds(UserId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetbyuserids/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetbyuserids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetByUserIdsToExcel(int? UserId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetByUserIds(UserId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetcreateddatebetweens/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetcreateddatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetCreatedDateBetweensToCSV(string CreatedDateStart, string CreatedDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetCreatedDateBetweens(CreatedDateStart, CreatedDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetcreateddatebetweens/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetcreateddatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetCreatedDateBetweensToExcel(string CreatedDateStart, string CreatedDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetCreatedDateBetweens(CreatedDateStart, CreatedDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetlastscandatebetweens/csv")]
        [HttpGet("/export/JSONServer/projectpagesgetlastscandatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetLastScanDateBetweensToCSV(string LastScanDateStart, string LastScanDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesGetLastScanDateBetweens(LastScanDateStart, LastScanDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesgetlastscandatebetweens/excel")]
        [HttpGet("/export/JSONServer/projectpagesgetlastscandatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesGetLastScanDateBetweensToExcel(string LastScanDateStart, string LastScanDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesGetLastScanDateBetweens(LastScanDateStart, LastScanDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesinserts/csv")]
        [HttpGet("/export/JSONServer/projectpagesinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesInsertsToCSV(string PageUrl, int? ProjectId, string CreatedDate, string LastScanDate, int? UserId, bool? HasPaid, string ReferralUrl, string HtmlCode, string JsonCode, string PageName, string Route, int? DefaultLanguage, bool? HasMultipleLanguage, int? ScannedLanguage, bool? HasFinishedSuccessfully, decimal? Price, int? CurrencyId, decimal? Commission, string CustomCode, string CssCode, string JsCode, string PageCycleEventDefination, string PageCycleEventDefination1, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesInserts(PageUrl, ProjectId, CreatedDate, LastScanDate, UserId, HasPaid, ReferralUrl, HtmlCode, JsonCode, PageName, Route, DefaultLanguage, HasMultipleLanguage, ScannedLanguage, HasFinishedSuccessfully, Price, CurrencyId, Commission, CustomCode, CssCode, JsCode, PageCycleEventDefination, PageCycleEventDefination1), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesinserts/excel")]
        [HttpGet("/export/JSONServer/projectpagesinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesInsertsToExcel(string PageUrl, int? ProjectId, string CreatedDate, string LastScanDate, int? UserId, bool? HasPaid, string ReferralUrl, string HtmlCode, string JsonCode, string PageName, string Route, int? DefaultLanguage, bool? HasMultipleLanguage, int? ScannedLanguage, bool? HasFinishedSuccessfully, decimal? Price, int? CurrencyId, decimal? Commission, string CustomCode, string CssCode, string JsCode, string PageCycleEventDefination, string PageCycleEventDefination1, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesInserts(PageUrl, ProjectId, CreatedDate, LastScanDate, UserId, HasPaid, ReferralUrl, HtmlCode, JsonCode, PageName, Route, DefaultLanguage, HasMultipleLanguage, ScannedLanguage, HasFinishedSuccessfully, Price, CurrencyId, Commission, CustomCode, CssCode, JsCode, PageCycleEventDefination, PageCycleEventDefination1), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesupdates/csv")]
        [HttpGet("/export/JSONServer/projectpagesupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesUpdatesToCSV(int? Id, string PageUrl, int? ProjectId, string CreatedDate, string LastScanDate, int? UserId, bool? HasPaid, string ReferralUrl, string HtmlCode, string JsonCode, string PageName, string Route, int? DefaultLanguage, bool? HasMultipleLanguage, int? ScannedLanguage, bool? HasFinishedSuccessfully, decimal? Price, int? CurrencyId, decimal? Commission, string CustomCode, string CssCode, string JsCode, string PageCycleEventDefination, string PageCycleEventDefination1, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPagesUpdates(Id, PageUrl, ProjectId, CreatedDate, LastScanDate, UserId, HasPaid, ReferralUrl, HtmlCode, JsonCode, PageName, Route, DefaultLanguage, HasMultipleLanguage, ScannedLanguage, HasFinishedSuccessfully, Price, CurrencyId, Commission, CustomCode, CssCode, JsCode, PageCycleEventDefination, PageCycleEventDefination1), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectpagesupdates/excel")]
        [HttpGet("/export/JSONServer/projectpagesupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesUpdatesToExcel(int? Id, string PageUrl, int? ProjectId, string CreatedDate, string LastScanDate, int? UserId, bool? HasPaid, string ReferralUrl, string HtmlCode, string JsonCode, string PageName, string Route, int? DefaultLanguage, bool? HasMultipleLanguage, int? ScannedLanguage, bool? HasFinishedSuccessfully, decimal? Price, int? CurrencyId, decimal? Commission, string CustomCode, string CssCode, string JsCode, string PageCycleEventDefination, string PageCycleEventDefination1, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPagesUpdates(Id, PageUrl, ProjectId, CreatedDate, LastScanDate, UserId, HasPaid, ReferralUrl, HtmlCode, JsonCode, PageName, Route, DefaultLanguage, HasMultipleLanguage, ScannedLanguage, HasFinishedSuccessfully, Price, CurrencyId, Commission, CustomCode, CssCode, JsCode, PageCycleEventDefination, PageCycleEventDefination1), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetalls/csv")]
        [HttpGet("/export/JSONServer/projectsgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetalls/excel")]
        [HttpGet("/export/JSONServer/projectsgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbyconfigurations/csv")]
        [HttpGet("/export/JSONServer/projectsgetbyconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByConfigurationsToCSV(string Configuration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsGetByConfigurations(Configuration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbyconfigurations/excel")]
        [HttpGet("/export/JSONServer/projectsgetbyconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByConfigurationsToExcel(string Configuration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsGetByConfigurations(Configuration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbyconnectionsettings/csv")]
        [HttpGet("/export/JSONServer/projectsgetbyconnectionsettings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByConnectionSettingsToCSV(object ConnectionSettings, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsGetByConnectionSettings(ConnectionSettings), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbyconnectionsettings/excel")]
        [HttpGet("/export/JSONServer/projectsgetbyconnectionsettings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByConnectionSettingsToExcel(object ConnectionSettings, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsGetByConnectionSettings(ConnectionSettings), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbydatabaseschemas/csv")]
        [HttpGet("/export/JSONServer/projectsgetbydatabaseschemas/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByDatabaseSchemasToCSV(string DatabaseSchemas, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsGetByDatabaseSchemas(DatabaseSchemas), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbydatabaseschemas/excel")]
        [HttpGet("/export/JSONServer/projectsgetbydatabaseschemas/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByDatabaseSchemasToExcel(string DatabaseSchemas, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsGetByDatabaseSchemas(DatabaseSchemas), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbyendpoints/csv")]
        [HttpGet("/export/JSONServer/projectsgetbyendpoints/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByEndpointsToCSV(object Endpoints, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsGetByEndpoints(Endpoints), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbyendpoints/excel")]
        [HttpGet("/export/JSONServer/projectsgetbyendpoints/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByEndpointsToExcel(object Endpoints, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsGetByEndpoints(Endpoints), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbyenumlists/csv")]
        [HttpGet("/export/JSONServer/projectsgetbyenumlists/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByEnumListsToCSV(object EnumLists, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsGetByEnumLists(EnumLists), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbyenumlists/excel")]
        [HttpGet("/export/JSONServer/projectsgetbyenumlists/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByEnumListsToExcel(object EnumLists, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsGetByEnumLists(EnumLists), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbyguids/csv")]
        [HttpGet("/export/JSONServer/projectsgetbyguids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByGuidsToCSV(string Guid, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsGetByGuids(Guid), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbyguids/excel")]
        [HttpGet("/export/JSONServer/projectsgetbyguids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByGuidsToExcel(string Guid, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsGetByGuids(Guid), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbyids/csv")]
        [HttpGet("/export/JSONServer/projectsgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbyids/excel")]
        [HttpGet("/export/JSONServer/projectsgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbylanguagedefinations/csv")]
        [HttpGet("/export/JSONServer/projectsgetbylanguagedefinations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByLanguageDefinationsToCSV(object LanguageDefinations, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsGetByLanguageDefinations(LanguageDefinations), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbylanguagedefinations/excel")]
        [HttpGet("/export/JSONServer/projectsgetbylanguagedefinations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByLanguageDefinationsToExcel(object LanguageDefinations, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsGetByLanguageDefinations(LanguageDefinations), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbylookups/csv")]
        [HttpGet("/export/JSONServer/projectsgetbylookups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByLookupsToCSV(object Lookups, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsGetByLookups(Lookups), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbylookups/excel")]
        [HttpGet("/export/JSONServer/projectsgetbylookups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByLookupsToExcel(object Lookups, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsGetByLookups(Lookups), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbynames/csv")]
        [HttpGet("/export/JSONServer/projectsgetbynames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByNamesToCSV(string Name, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsGetByNames(Name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbynames/excel")]
        [HttpGet("/export/JSONServer/projectsgetbynames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByNamesToExcel(string Name, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsGetByNames(Name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbyrulegroups/csv")]
        [HttpGet("/export/JSONServer/projectsgetbyrulegroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByRuleGroupsToCSV(string RuleGroups, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsGetByRuleGroups(RuleGroups), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbyrulegroups/excel")]
        [HttpGet("/export/JSONServer/projectsgetbyrulegroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByRuleGroupsToExcel(string RuleGroups, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsGetByRuleGroups(RuleGroups), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbytablegroups/csv")]
        [HttpGet("/export/JSONServer/projectsgetbytablegroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByTableGroupsToCSV(object TableGroups, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsGetByTableGroups(TableGroups), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbytablegroups/excel")]
        [HttpGet("/export/JSONServer/projectsgetbytablegroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByTableGroupsToExcel(object TableGroups, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsGetByTableGroups(TableGroups), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbytables/csv")]
        [HttpGet("/export/JSONServer/projectsgetbytables/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByTablesToCSV(string Tables, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsGetByTables(Tables), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbytables/excel")]
        [HttpGet("/export/JSONServer/projectsgetbytables/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByTablesToExcel(string Tables, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsGetByTables(Tables), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbyuserids/csv")]
        [HttpGet("/export/JSONServer/projectsgetbyuserids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByUserIdsToCSV(int? UserId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsGetByUserIds(UserId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsgetbyuserids/excel")]
        [HttpGet("/export/JSONServer/projectsgetbyuserids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsGetByUserIdsToExcel(int? UserId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsGetByUserIds(UserId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsinserts/csv")]
        [HttpGet("/export/JSONServer/projectsinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsInsertsToCSV(int? UserId, string Name, string Guid, string Tables, string Configuration, object TableGroups, object EnumLists, object Endpoints, object LanguageDefinations, object Lookups, object ConnectionSettings, string DatabaseSchemas, string RuleGroups, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsInserts(UserId, Name, Guid, Tables, Configuration, TableGroups, EnumLists, Endpoints, LanguageDefinations, Lookups, ConnectionSettings, DatabaseSchemas, RuleGroups), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsinserts/excel")]
        [HttpGet("/export/JSONServer/projectsinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsInsertsToExcel(int? UserId, string Name, string Guid, string Tables, string Configuration, object TableGroups, object EnumLists, object Endpoints, object LanguageDefinations, object Lookups, object ConnectionSettings, string DatabaseSchemas, string RuleGroups, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsInserts(UserId, Name, Guid, Tables, Configuration, TableGroups, EnumLists, Endpoints, LanguageDefinations, Lookups, ConnectionSettings, DatabaseSchemas, RuleGroups), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsupdates/csv")]
        [HttpGet("/export/JSONServer/projectsupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsUpdatesToCSV(int? Id, int? UserId, string Name, string Guid, string Tables, string Configuration, object TableGroups, object EnumLists, object Endpoints, object LanguageDefinations, object Lookups, object ConnectionSettings, string DatabaseSchemas, string RuleGroups, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectsUpdates(Id, UserId, Name, Guid, Tables, Configuration, TableGroups, EnumLists, Endpoints, LanguageDefinations, Lookups, ConnectionSettings, DatabaseSchemas, RuleGroups), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projectsupdates/excel")]
        [HttpGet("/export/JSONServer/projectsupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsUpdatesToExcel(int? Id, int? UserId, string Name, string Guid, string Tables, string Configuration, object TableGroups, object EnumLists, object Endpoints, object LanguageDefinations, object Lookups, object ConnectionSettings, string DatabaseSchemas, string RuleGroups, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectsUpdates(Id, UserId, Name, Guid, Tables, Configuration, TableGroups, EnumLists, Endpoints, LanguageDefinations, Lookups, ConnectionSettings, DatabaseSchemas, RuleGroups), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetalls/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetalls/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycmscreatepageconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycmscreatepageconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByCmsCreatePageConfigurationsToCSV(string CMSCreatePageConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByCmsCreatePageConfigurations(CMSCreatePageConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycmscreatepageconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycmscreatepageconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByCmsCreatePageConfigurationsToExcel(string CMSCreatePageConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByCmsCreatePageConfigurations(CMSCreatePageConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycmsdeletepageconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycmsdeletepageconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByCmsDeletePageConfigurationsToCSV(string CMSDeletePageConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByCmsDeletePageConfigurations(CMSDeletePageConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycmsdeletepageconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycmsdeletepageconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByCmsDeletePageConfigurationsToExcel(string CMSDeletePageConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByCmsDeletePageConfigurations(CMSDeletePageConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycmseditpageconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycmseditpageconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByCmsEditPageConfigurationsToCSV(string CMSEditPageConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByCmsEditPageConfigurations(CMSEditPageConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycmseditpageconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycmseditpageconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByCmsEditPageConfigurationsToExcel(string CMSEditPageConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByCmsEditPageConfigurations(CMSEditPageConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycmslistpageconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycmslistpageconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByCmsListPageConfigurationsToCSV(string CMSListPageConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByCmsListPageConfigurations(CMSListPageConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycmslistpageconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycmslistpageconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByCmsListPageConfigurationsToExcel(string CMSListPageConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByCmsListPageConfigurations(CMSListPageConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycolumnnames/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycolumnnames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByColumnNamesToCSV(string ColumnName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByColumnNames(ColumnName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycolumnnames/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycolumnnames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByColumnNamesToExcel(string ColumnName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByColumnNames(ColumnName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycolumnnamecryptos/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycolumnnamecryptos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByColumnNameCryptosToCSV(string ColumnNameCrypto, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByColumnNameCryptos(ColumnNameCrypto), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycolumnnamecryptos/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycolumnnamecryptos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByColumnNameCryptosToExcel(string ColumnNameCrypto, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByColumnNameCryptos(ColumnNameCrypto), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycolumnnamei18s/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycolumnnamei18s/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByColumnNameI18SToCSV(string ColumnNameI18, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByColumnNameI18S(ColumnNameI18), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycolumnnamei18s/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycolumnnamei18s/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByColumnNameI18SToExcel(string ColumnNameI18, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByColumnNameI18S(ColumnNameI18), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycolumnsconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycolumnsconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByColumnsConfigurationsToCSV(string ColumnsConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByColumnsConfigurations(ColumnsConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycolumnsconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycolumnsconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByColumnsConfigurationsToExcel(string ColumnsConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByColumnsConfigurations(ColumnsConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycomments/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycomments/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByCommentsToCSV(string Comment, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByComments(Comment), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycomments/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycomments/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByCommentsToExcel(string Comment, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByComments(Comment), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycommissions/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycommissions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByCommissionsToCSV(decimal? Commission, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByCommissions(Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycommissions/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycommissions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByCommissionsToExcel(decimal? Commission, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByCommissions(Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycomponentconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycomponentconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByComponentConfigurationsToCSV(string ComponentConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByComponentConfigurations(ComponentConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycomponentconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycomponentconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByComponentConfigurationsToExcel(string ComponentConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByComponentConfigurations(ComponentConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycurrencyids/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycurrencyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByCurrencyIdsToCSV(int? CurrencyId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByCurrencyIds(CurrencyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycurrencyids/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycurrencyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByCurrencyIdsToExcel(int? CurrencyId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByCurrencyIds(CurrencyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycustomcodes/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycustomcodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByCustomCodesToCSV(string CustomCode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByCustomCodes(CustomCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycustomcodes/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbycustomcodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByCustomCodesToExcel(string CustomCode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByCustomCodes(CustomCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydatabasecreatemigrationscripts/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydatabasecreatemigrationscripts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByDatabaseCreateMigrationScriptsToCSV(string DatabaseCreateMigrationScript, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByDatabaseCreateMigrationScripts(DatabaseCreateMigrationScript), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydatabasecreatemigrationscripts/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydatabasecreatemigrationscripts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByDatabaseCreateMigrationScriptsToExcel(string DatabaseCreateMigrationScript, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByDatabaseCreateMigrationScripts(DatabaseCreateMigrationScript), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydatatypemappings/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydatatypemappings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByDataTypeMappingsToCSV(string DataTypeMapping, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByDataTypeMappings(DataTypeMapping), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydatatypemappings/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydatatypemappings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByDataTypeMappingsToExcel(string DataTypeMapping, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByDataTypeMappings(DataTypeMapping), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydbtypes/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydbtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByDbTypesToCSV(string DbType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByDbTypes(DbType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydbtypes/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydbtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByDbTypesToExcel(string DbType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByDbTypes(DbType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydefaultvalues/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydefaultvalues/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByDefaultValuesToCSV(string DefaultValue, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByDefaultValues(DefaultValue), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydefaultvalues/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydefaultvalues/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByDefaultValuesToExcel(string DefaultValue, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByDefaultValues(DefaultValue), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydependencyconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydependencyconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByDependencyConfigurationsToCSV(string DependencyConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByDependencyConfigurations(DependencyConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydependencyconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbydependencyconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByDependencyConfigurationsToExcel(string DependencyConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByDependencyConfigurations(DependencyConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyextras/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyextras/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByExtrasToCSV(string Extra, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByExtras(Extra), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyextras/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyextras/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByExtrasToExcel(string Extra, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByExtras(Extra), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyfkdetails/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyfkdetails/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByFkDetailsToCSV(string FKDetails, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByFkDetails(FKDetails), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyfkdetails/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyfkdetails/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByFkDetailsToExcel(string FKDetails, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByFkDetails(FKDetails), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyids/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyids/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyinputtypes/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyinputtypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByInputTypesToCSV(int? InputType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByInputTypes(InputType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyinputtypes/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyinputtypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByInputTypesToExcel(int? InputType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByInputTypes(InputType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyisnullables/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyisnullables/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByIsNullablesToCSV(bool? IsNullable, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByIsNullables(IsNullable), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyisnullables/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyisnullables/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByIsNullablesToExcel(bool? IsNullable, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByIsNullables(IsNullable), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyisprimaries/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyisprimaries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByIsPrimariesToCSV(bool? IsPrimary, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByIsPrimaries(IsPrimary), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyisprimaries/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyisprimaries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByIsPrimariesToExcel(bool? IsPrimary, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByIsPrimaries(IsPrimary), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbykeyconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbykeyconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByKeyConfigurationsToCSV(string KeyConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByKeyConfigurations(KeyConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbykeyconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbykeyconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByKeyConfigurationsToExcel(string KeyConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByKeyConfigurations(KeyConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbymappingconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbymappingconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByMappingConfigurationsToCSV(string MappingConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByMappingConfigurations(MappingConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbymappingconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbymappingconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByMappingConfigurationsToExcel(string MappingConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByMappingConfigurations(MappingConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbymaxlengths/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbymaxlengths/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByMaxLengthsToCSV(string MaxLength, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByMaxLengths(MaxLength), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbymaxlengths/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbymaxlengths/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByMaxLengthsToExcel(string MaxLength, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByMaxLengths(MaxLength), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyprices/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyprices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByPricesToCSV(decimal? Price, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByPrices(Price), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyprices/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyprices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByPricesToExcel(decimal? Price, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByPrices(Price), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyprimitivetypes/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyprimitivetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByPrimitiveTypesToCSV(string PrimitiveType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByPrimitiveTypes(PrimitiveType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyprimitivetypes/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbyprimitivetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByPrimitiveTypesToExcel(string PrimitiveType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByPrimitiveTypes(PrimitiveType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbytableids/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbytableids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByTableIdsToCSV(int? TableId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByTableIds(TableId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbytableids/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbytableids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByTableIdsToExcel(int? TableId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByTableIds(TableId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbytablenames/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbytablenames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByTableNamesToCSV(string TableName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsGetByTableNames(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsgetbytablenames/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsgetbytablenames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsGetByTableNamesToExcel(string TableName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsGetByTableNames(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsinserts/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsInsertsToCSV(string ColumnName, string ColumnNameCrypto, string DbType, string PrimitiveType, string DefaultValue, bool? IsNullable, string MaxLength, string FKDetails, string TableName, int? TableId, bool? IsPrimary, int? InputType, string KeyConfiguration, string Extra, string Comment, string DataTypeMapping, string ColumnsConfiguration, string MappingConfiguration, string DependencyConfiguration, decimal? Price, int? CurrencyId, decimal? Commission, string CustomCode, string ComponentConfiguration, string CMSListPageConfiguration, string CMSEditPageConfiguration, string CMSCreatePageConfiguration, string CMSDeletePageConfiguration, string DatabaseCreateMigrationScript, string ColumnNameI18, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsInserts(ColumnName, ColumnNameCrypto, DbType, PrimitiveType, DefaultValue, IsNullable, MaxLength, FKDetails, TableName, TableId, IsPrimary, InputType, KeyConfiguration, Extra, Comment, DataTypeMapping, ColumnsConfiguration, MappingConfiguration, DependencyConfiguration, Price, CurrencyId, Commission, CustomCode, ComponentConfiguration, CMSListPageConfiguration, CMSEditPageConfiguration, CMSCreatePageConfiguration, CMSDeletePageConfiguration, DatabaseCreateMigrationScript, ColumnNameI18), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsinserts/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsInsertsToExcel(string ColumnName, string ColumnNameCrypto, string DbType, string PrimitiveType, string DefaultValue, bool? IsNullable, string MaxLength, string FKDetails, string TableName, int? TableId, bool? IsPrimary, int? InputType, string KeyConfiguration, string Extra, string Comment, string DataTypeMapping, string ColumnsConfiguration, string MappingConfiguration, string DependencyConfiguration, decimal? Price, int? CurrencyId, decimal? Commission, string CustomCode, string ComponentConfiguration, string CMSListPageConfiguration, string CMSEditPageConfiguration, string CMSCreatePageConfiguration, string CMSDeletePageConfiguration, string DatabaseCreateMigrationScript, string ColumnNameI18, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsInserts(ColumnName, ColumnNameCrypto, DbType, PrimitiveType, DefaultValue, IsNullable, MaxLength, FKDetails, TableName, TableId, IsPrimary, InputType, KeyConfiguration, Extra, Comment, DataTypeMapping, ColumnsConfiguration, MappingConfiguration, DependencyConfiguration, Price, CurrencyId, Commission, CustomCode, ComponentConfiguration, CMSListPageConfiguration, CMSEditPageConfiguration, CMSCreatePageConfiguration, CMSDeletePageConfiguration, DatabaseCreateMigrationScript, ColumnNameI18), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsupdates/csv")]
        [HttpGet("/export/JSONServer/projecttablecolumnsupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsUpdatesToCSV(int? Id, string ColumnName, string ColumnNameCrypto, string DbType, string PrimitiveType, string DefaultValue, bool? IsNullable, string MaxLength, string FKDetails, string TableName, int? TableId, bool? IsPrimary, int? InputType, string KeyConfiguration, string Extra, string Comment, string DataTypeMapping, string ColumnsConfiguration, string MappingConfiguration, string DependencyConfiguration, decimal? Price, int? CurrencyId, decimal? Commission, string CustomCode, string ComponentConfiguration, string CMSListPageConfiguration, string CMSEditPageConfiguration, string CMSCreatePageConfiguration, string CMSDeletePageConfiguration, string DatabaseCreateMigrationScript, string ColumnNameI18, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumnsUpdates(Id, ColumnName, ColumnNameCrypto, DbType, PrimitiveType, DefaultValue, IsNullable, MaxLength, FKDetails, TableName, TableId, IsPrimary, InputType, KeyConfiguration, Extra, Comment, DataTypeMapping, ColumnsConfiguration, MappingConfiguration, DependencyConfiguration, Price, CurrencyId, Commission, CustomCode, ComponentConfiguration, CMSListPageConfiguration, CMSEditPageConfiguration, CMSCreatePageConfiguration, CMSDeletePageConfiguration, DatabaseCreateMigrationScript, ColumnNameI18), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablecolumnsupdates/excel")]
        [HttpGet("/export/JSONServer/projecttablecolumnsupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsUpdatesToExcel(int? Id, string ColumnName, string ColumnNameCrypto, string DbType, string PrimitiveType, string DefaultValue, bool? IsNullable, string MaxLength, string FKDetails, string TableName, int? TableId, bool? IsPrimary, int? InputType, string KeyConfiguration, string Extra, string Comment, string DataTypeMapping, string ColumnsConfiguration, string MappingConfiguration, string DependencyConfiguration, decimal? Price, int? CurrencyId, decimal? Commission, string CustomCode, string ComponentConfiguration, string CMSListPageConfiguration, string CMSEditPageConfiguration, string CMSCreatePageConfiguration, string CMSDeletePageConfiguration, string DatabaseCreateMigrationScript, string ColumnNameI18, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumnsUpdates(Id, ColumnName, ColumnNameCrypto, DbType, PrimitiveType, DefaultValue, IsNullable, MaxLength, FKDetails, TableName, TableId, IsPrimary, InputType, KeyConfiguration, Extra, Comment, DataTypeMapping, ColumnsConfiguration, MappingConfiguration, DependencyConfiguration, Price, CurrencyId, Commission, CustomCode, ComponentConfiguration, CMSListPageConfiguration, CMSEditPageConfiguration, CMSCreatePageConfiguration, CMSDeletePageConfiguration, DatabaseCreateMigrationScript, ColumnNameI18), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetalls/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetalls/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyapiconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbyapiconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByApiConfigurationsToCSV(string ApiConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByApiConfigurations(ApiConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyapiconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbyapiconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByApiConfigurationsToExcel(string ApiConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByApiConfigurations(ApiConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyauditconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbyauditconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByAuditConfigurationsToCSV(string AuditConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByAuditConfigurations(AuditConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyauditconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbyauditconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByAuditConfigurationsToExcel(string AuditConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByAuditConfigurations(AuditConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycmscustomfilterconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbycmscustomfilterconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCmsCustomFilterConfigurationsToCSV(string CMSCustomFilterConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByCmsCustomFilterConfigurations(CMSCustomFilterConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycmscustomfilterconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbycmscustomfilterconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCmsCustomFilterConfigurationsToExcel(string CMSCustomFilterConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByCmsCustomFilterConfigurations(CMSCustomFilterConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycmsexportconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbycmsexportconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCmsExportConfigurationsToCSV(string CMSExportConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByCmsExportConfigurations(CMSExportConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycmsexportconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbycmsexportconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCmsExportConfigurationsToExcel(string CMSExportConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByCmsExportConfigurations(CMSExportConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycmsmenuconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbycmsmenuconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCmsMenuConfigurationsToCSV(string CMSMenuConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByCmsMenuConfigurations(CMSMenuConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycmsmenuconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbycmsmenuconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCmsMenuConfigurationsToExcel(string CMSMenuConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByCmsMenuConfigurations(CMSMenuConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycmspermissionconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbycmspermissionconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCmsPermissionConfigurationsToCSV(string CMSPermissionConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByCmsPermissionConfigurations(CMSPermissionConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycmspermissionconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbycmspermissionconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCmsPermissionConfigurationsToExcel(string CMSPermissionConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByCmsPermissionConfigurations(CMSPermissionConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycmsrouteconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbycmsrouteconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCmsRouteConfigurationsToCSV(string CMSRouteConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByCmsRouteConfigurations(CMSRouteConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycmsrouteconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbycmsrouteconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCmsRouteConfigurationsToExcel(string CMSRouteConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByCmsRouteConfigurations(CMSRouteConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycolumns/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbycolumns/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByColumnsToCSV(string Columns, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByColumns(Columns), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycolumns/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbycolumns/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByColumnsToExcel(string Columns, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByColumns(Columns), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycomments/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbycomments/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCommentsToCSV(string Comment, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByComments(Comment), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycomments/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbycomments/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCommentsToExcel(string Comment, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByComments(Comment), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycommissions/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbycommissions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCommissionsToCSV(decimal? Commission, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByCommissions(Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycommissions/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbycommissions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCommissionsToExcel(decimal? Commission, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByCommissions(Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycurrencyids/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbycurrencyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCurrencyIdsToCSV(int? CurrencyId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByCurrencyIds(CurrencyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycurrencyids/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbycurrencyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCurrencyIdsToExcel(int? CurrencyId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByCurrencyIds(CurrencyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycustomcodes/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbycustomcodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCustomCodesToCSV(string CustomCode, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByCustomCodes(CustomCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbycustomcodes/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbycustomcodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByCustomCodesToExcel(string CustomCode, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByCustomCodes(CustomCode), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbydataindices/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbydataindices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByDataIndicesToCSV(string DataIndex, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByDataIndices(DataIndex), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbydataindices/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbydataindices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByDataIndicesToExcel(string DataIndex, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByDataIndices(DataIndex), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbydiagramconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbydiagramconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByDiagramConfigurationsToCSV(string DiagramConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByDiagramConfigurations(DiagramConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbydiagramconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbydiagramconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByDiagramConfigurationsToExcel(string DiagramConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByDiagramConfigurations(DiagramConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyi18configurations/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbyi18configurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByI18ConfigurationsToCSV(string I18Configuration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByI18Configurations(I18Configuration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyi18configurations/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbyi18configurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByI18ConfigurationsToExcel(string I18Configuration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByI18Configurations(I18Configuration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyids/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyids/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyprices/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbyprices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByPricesToCSV(decimal? Price, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByPrices(Price), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyprices/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbyprices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByPricesToExcel(decimal? Price, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByPrices(Price), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyprogramminglanguageids/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbyprogramminglanguageids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByProgrammingLanguageIdsToCSV(int? ProgrammingLanguageId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByProgrammingLanguageIds(ProgrammingLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyprogramminglanguageids/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbyprogramminglanguageids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByProgrammingLanguageIdsToExcel(int? ProgrammingLanguageId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByProgrammingLanguageIds(ProgrammingLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyprojectnames/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbyprojectnames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByProjectNamesToCSV(string ProjectName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByProjectNames(ProjectName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyprojectnames/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbyprojectnames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByProjectNamesToExcel(string ProjectName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByProjectNames(ProjectName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyprojecttableconfigurations/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbyprojecttableconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByProjectTableConfigurationsToCSV(string ProjectTableConfiguration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByProjectTableConfigurations(ProjectTableConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyprojecttableconfigurations/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbyprojecttableconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByProjectTableConfigurationsToExcel(string ProjectTableConfiguration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByProjectTableConfigurations(ProjectTableConfiguration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbytablenames/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbytablenames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByTableNamesToCSV(string TableName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByTableNames(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbytablenames/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbytablenames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByTableNamesToExcel(string TableName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByTableNames(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbytablenamecryptos/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbytablenamecryptos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByTableNameCryptosToCSV(string TableNameCrypto, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByTableNameCryptos(TableNameCrypto), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbytablenamecryptos/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbytablenamecryptos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByTableNameCryptosToExcel(string TableNameCrypto, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByTableNameCryptos(TableNameCrypto), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyuniquecolumns/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbyuniquecolumns/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByUniqueColumnsToCSV(string UniqueColumns, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByUniqueColumns(UniqueColumns), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyuniquecolumns/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbyuniquecolumns/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByUniqueColumnsToExcel(string UniqueColumns, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByUniqueColumns(UniqueColumns), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyuserprojectconnections/csv")]
        [HttpGet("/export/JSONServer/projecttablesgetbyuserprojectconnections/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByUserProjectConnectionsToCSV(string UserProjectConnections, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesGetByUserProjectConnections(UserProjectConnections), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesgetbyuserprojectconnections/excel")]
        [HttpGet("/export/JSONServer/projecttablesgetbyuserprojectconnections/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesGetByUserProjectConnectionsToExcel(string UserProjectConnections, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesGetByUserProjectConnections(UserProjectConnections), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesinserts/csv")]
        [HttpGet("/export/JSONServer/projecttablesinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesInsertsToCSV(string TableName, string TableNameCrypto, string UniqueColumns, string DataIndex, string ProjectName, string UserProjectConnections, string Columns, string ProjectTableConfiguration, string DiagramConfiguration, string AuditConfiguration, string Comment, string CMSMenuConfiguration, string CMSPermissionConfiguration, string CMSExportConfiguration, string CMSCustomFilterConfiguration, decimal? Price, int? CurrencyId, decimal? Commission, string CustomCode, string CMSRouteConfiguration, string ApiConfiguration, int? ProgrammingLanguageId, string I18Configuration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesInserts(TableName, TableNameCrypto, UniqueColumns, DataIndex, ProjectName, UserProjectConnections, Columns, ProjectTableConfiguration, DiagramConfiguration, AuditConfiguration, Comment, CMSMenuConfiguration, CMSPermissionConfiguration, CMSExportConfiguration, CMSCustomFilterConfiguration, Price, CurrencyId, Commission, CustomCode, CMSRouteConfiguration, ApiConfiguration, ProgrammingLanguageId, I18Configuration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesinserts/excel")]
        [HttpGet("/export/JSONServer/projecttablesinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesInsertsToExcel(string TableName, string TableNameCrypto, string UniqueColumns, string DataIndex, string ProjectName, string UserProjectConnections, string Columns, string ProjectTableConfiguration, string DiagramConfiguration, string AuditConfiguration, string Comment, string CMSMenuConfiguration, string CMSPermissionConfiguration, string CMSExportConfiguration, string CMSCustomFilterConfiguration, decimal? Price, int? CurrencyId, decimal? Commission, string CustomCode, string CMSRouteConfiguration, string ApiConfiguration, int? ProgrammingLanguageId, string I18Configuration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesInserts(TableName, TableNameCrypto, UniqueColumns, DataIndex, ProjectName, UserProjectConnections, Columns, ProjectTableConfiguration, DiagramConfiguration, AuditConfiguration, Comment, CMSMenuConfiguration, CMSPermissionConfiguration, CMSExportConfiguration, CMSCustomFilterConfiguration, Price, CurrencyId, Commission, CustomCode, CMSRouteConfiguration, ApiConfiguration, ProgrammingLanguageId, I18Configuration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesupdates/csv")]
        [HttpGet("/export/JSONServer/projecttablesupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesUpdatesToCSV(int? Id, string TableName, string TableNameCrypto, string UniqueColumns, string DataIndex, string ProjectName, string UserProjectConnections, string Columns, string ProjectTableConfiguration, string DiagramConfiguration, string AuditConfiguration, string Comment, string CMSMenuConfiguration, string CMSPermissionConfiguration, string CMSExportConfiguration, string CMSCustomFilterConfiguration, decimal? Price, int? CurrencyId, decimal? Commission, string CustomCode, string CMSRouteConfiguration, string ApiConfiguration, int? ProgrammingLanguageId, string I18Configuration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTablesUpdates(Id, TableName, TableNameCrypto, UniqueColumns, DataIndex, ProjectName, UserProjectConnections, Columns, ProjectTableConfiguration, DiagramConfiguration, AuditConfiguration, Comment, CMSMenuConfiguration, CMSPermissionConfiguration, CMSExportConfiguration, CMSCustomFilterConfiguration, Price, CurrencyId, Commission, CustomCode, CMSRouteConfiguration, ApiConfiguration, ProgrammingLanguageId, I18Configuration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/projecttablesupdates/excel")]
        [HttpGet("/export/JSONServer/projecttablesupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesUpdatesToExcel(int? Id, string TableName, string TableNameCrypto, string UniqueColumns, string DataIndex, string ProjectName, string UserProjectConnections, string Columns, string ProjectTableConfiguration, string DiagramConfiguration, string AuditConfiguration, string Comment, string CMSMenuConfiguration, string CMSPermissionConfiguration, string CMSExportConfiguration, string CMSCustomFilterConfiguration, decimal? Price, int? CurrencyId, decimal? Commission, string CustomCode, string CMSRouteConfiguration, string ApiConfiguration, int? ProgrammingLanguageId, string I18Configuration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTablesUpdates(Id, TableName, TableNameCrypto, UniqueColumns, DataIndex, ProjectName, UserProjectConnections, Columns, ProjectTableConfiguration, DiagramConfiguration, AuditConfiguration, Comment, CMSMenuConfiguration, CMSPermissionConfiguration, CMSExportConfiguration, CMSCustomFilterConfiguration, Price, CurrencyId, Commission, CustomCode, CMSRouteConfiguration, ApiConfiguration, ProgrammingLanguageId, I18Configuration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetalls/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetalls/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyavgvisitdurations/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyavgvisitdurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByAvgVisitDurationsToCSV(string AvgVisitDuration, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByAvgVisitDurations(AvgVisitDuration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyavgvisitdurations/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyavgvisitdurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByAvgVisitDurationsToExcel(string AvgVisitDuration, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByAvgVisitDurations(AvgVisitDuration), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbybouncerates/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbybouncerates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByBounceRatesToCSV(string BounceRate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByBounceRates(BounceRate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbybouncerates/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbybouncerates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByBounceRatesToExcel(string BounceRate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByBounceRates(BounceRate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbycommissions/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbycommissions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByCommissionsToCSV(decimal? Commission, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByCommissions(Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbycommissions/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbycommissions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByCommissionsToExcel(decimal? Commission, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByCommissions(Commission), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbycreateddates/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbycreateddates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByCreatedDatesToCSV(string CreatedDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByCreatedDates(CreatedDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbycreateddates/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbycreateddates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByCreatedDatesToExcel(string CreatedDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByCreatedDates(CreatedDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbycurrencyids/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbycurrencyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByCurrencyIdsToCSV(int? CurrencyId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByCurrencyIds(CurrencyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbycurrencyids/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbycurrencyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByCurrencyIdsToExcel(int? CurrencyId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByCurrencyIds(CurrencyId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbydefaultlanguages/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbydefaultlanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByDefaultLanguagesToCSV(int? DefaultLanguage, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByDefaultLanguages(DefaultLanguage), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbydefaultlanguages/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbydefaultlanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByDefaultLanguagesToExcel(int? DefaultLanguage, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByDefaultLanguages(DefaultLanguage), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyguids/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyguids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByGuidsToCSV(string Guid, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByGuids(Guid), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyguids/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyguids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByGuidsToExcel(string Guid, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByGuids(Guid), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyids/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByIdsToCSV(int? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyids/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByIdsToExcel(int? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyislastpublishsuccessfullies/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyislastpublishsuccessfullies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByIsLastPublishSuccessfulliesToCSV(bool? IsLastPublishSuccessfully, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByIsLastPublishSuccessfullies(IsLastPublishSuccessfully), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyislastpublishsuccessfullies/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyislastpublishsuccessfullies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByIsLastPublishSuccessfulliesToExcel(bool? IsLastPublishSuccessfully, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByIsLastPublishSuccessfullies(IsLastPublishSuccessfully), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbylastcompiledates/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbylastcompiledates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByLastCompileDatesToCSV(string LastCompileDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByLastCompileDates(LastCompileDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbylastcompiledates/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbylastcompiledates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByLastCompileDatesToExcel(string LastCompileDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByLastCompileDates(LastCompileDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbylogos/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbylogos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByLogosToCSV(string Logo, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByLogos(Logo), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbylogos/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbylogos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByLogosToExcel(string Logo, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByLogos(Logo), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbymodifydates/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbymodifydates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByModifyDatesToCSV(string ModifyDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByModifyDates(ModifyDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbymodifydates/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbymodifydates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByModifyDatesToExcel(string ModifyDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByModifyDates(ModifyDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbypagevisits/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbypagevisits/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByPageVisitsToCSV(string PageVisit, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByPageVisits(PageVisit), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbypagevisits/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbypagevisits/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByPageVisitsToExcel(string PageVisit, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByPageVisits(PageVisit), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyprices/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyprices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByPricesToCSV(decimal? Price, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByPrices(Price), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyprices/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyprices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByPricesToExcel(decimal? Price, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByPrices(Price), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyprojectcategoryids/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyprojectcategoryids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByProjectCategoryIdsToCSV(int? ProjectCategoryId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByProjectCategoryIds(ProjectCategoryId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyprojectcategoryids/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyprojectcategoryids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByProjectCategoryIdsToExcel(int? ProjectCategoryId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByProjectCategoryIds(ProjectCategoryId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyrankings/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyrankings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByRankingsToCSV(int? Ranking, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByRankings(Ranking), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyrankings/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyrankings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByRankingsToExcel(int? Ranking, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByRankings(Ranking), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbysitenames/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbysitenames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetBySiteNamesToCSV(string SiteName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetBySiteNames(SiteName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbysitenames/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbysitenames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetBySiteNamesToExcel(string SiteName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetBySiteNames(SiteName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbysoftwarelanguageids/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbysoftwarelanguageids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetBySoftwareLanguageIdsToCSV(int? SoftwareLanguageId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetBySoftwareLanguageIds(SoftwareLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbysoftwarelanguageids/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbysoftwarelanguageids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetBySoftwareLanguageIdsToExcel(int? SoftwareLanguageId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetBySoftwareLanguageIds(SoftwareLanguageId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyurls/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyurls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByUrlsToCSV(string Url, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByUrls(Url), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyurls/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyurls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByUrlsToExcel(string Url, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByUrls(Url), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyuserids/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyuserids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByUserIdsToCSV(int? UserId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByUserIds(UserId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyuserids/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyuserids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByUserIdsToExcel(int? UserId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByUserIds(UserId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyvaliddates/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyvaliddates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByValidDatesToCSV(string ValidDate, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetByValidDates(ValidDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetbyvaliddates/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetbyvaliddates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetByValidDatesToExcel(string ValidDate, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetByValidDates(ValidDate), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetcreateddatebetweens/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetcreateddatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetCreatedDateBetweensToCSV(string CreatedDateStart, string CreatedDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetCreatedDateBetweens(CreatedDateStart, CreatedDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetcreateddatebetweens/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetcreateddatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetCreatedDateBetweensToExcel(string CreatedDateStart, string CreatedDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetCreatedDateBetweens(CreatedDateStart, CreatedDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetlastcompiledatebetweens/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetlastcompiledatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetLastCompileDateBetweensToCSV(string LastCompileDateStart, string LastCompileDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetLastCompileDateBetweens(LastCompileDateStart, LastCompileDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetlastcompiledatebetweens/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetlastcompiledatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetLastCompileDateBetweensToExcel(string LastCompileDateStart, string LastCompileDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetLastCompileDateBetweens(LastCompileDateStart, LastCompileDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetmodifydatebetweens/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetmodifydatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetModifyDateBetweensToCSV(string ModifyDateStart, string ModifyDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetModifyDateBetweens(ModifyDateStart, ModifyDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetmodifydatebetweens/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetmodifydatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetModifyDateBetweensToExcel(string ModifyDateStart, string ModifyDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetModifyDateBetweens(ModifyDateStart, ModifyDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetvaliddatebetweens/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesgetvaliddatebetweens/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetValidDateBetweensToCSV(string ValidDateStart, string ValidDateEnd, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesGetValidDateBetweens(ValidDateStart, ValidDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesgetvaliddatebetweens/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesgetvaliddatebetweens/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesGetValidDateBetweensToExcel(string ValidDateStart, string ValidDateEnd, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesGetValidDateBetweens(ValidDateStart, ValidDateEnd), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesinserts/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesInsertsToCSV(string SiteName, string Url, int? ProjectCategoryId, int? Ranking, string AvgVisitDuration, string PageVisit, string BounceRate, string Logo, decimal? Price, decimal? Commission, int? CurrencyId, string CreatedDate, string ValidDate, string ModifyDate, string LastCompileDate, int? SoftwareLanguageId, bool? IsLastPublishSuccessfully, int? DefaultLanguage, int? UserId, string Guid, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesInserts(SiteName, Url, ProjectCategoryId, Ranking, AvgVisitDuration, PageVisit, BounceRate, Logo, Price, Commission, CurrencyId, CreatedDate, ValidDate, ModifyDate, LastCompileDate, SoftwareLanguageId, IsLastPublishSuccessfully, DefaultLanguage, UserId, Guid), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesinserts/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesInsertsToExcel(string SiteName, string Url, int? ProjectCategoryId, int? Ranking, string AvgVisitDuration, string PageVisit, string BounceRate, string Logo, decimal? Price, decimal? Commission, int? CurrencyId, string CreatedDate, string ValidDate, string ModifyDate, string LastCompileDate, int? SoftwareLanguageId, bool? IsLastPublishSuccessfully, int? DefaultLanguage, int? UserId, string Guid, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesInserts(SiteName, Url, ProjectCategoryId, Ranking, AvgVisitDuration, PageVisit, BounceRate, Logo, Price, Commission, CurrencyId, CreatedDate, ValidDate, ModifyDate, LastCompileDate, SoftwareLanguageId, IsLastPublishSuccessfully, DefaultLanguage, UserId, Guid), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesupdates/csv")]
        [HttpGet("/export/JSONServer/referencewebsitesupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesUpdatesToCSV(int? Id, string SiteName, string Url, int? ProjectCategoryId, int? Ranking, string AvgVisitDuration, string PageVisit, string BounceRate, string Logo, decimal? Price, decimal? Commission, int? CurrencyId, string CreatedDate, string ValidDate, string ModifyDate, string LastCompileDate, int? SoftwareLanguageId, bool? IsLastPublishSuccessfully, int? DefaultLanguage, int? UserId, string Guid, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSitesUpdates(Id, SiteName, Url, ProjectCategoryId, Ranking, AvgVisitDuration, PageVisit, BounceRate, Logo, Price, Commission, CurrencyId, CreatedDate, ValidDate, ModifyDate, LastCompileDate, SoftwareLanguageId, IsLastPublishSuccessfully, DefaultLanguage, UserId, Guid), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/referencewebsitesupdates/excel")]
        [HttpGet("/export/JSONServer/referencewebsitesupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesUpdatesToExcel(int? Id, string SiteName, string Url, int? ProjectCategoryId, int? Ranking, string AvgVisitDuration, string PageVisit, string BounceRate, string Logo, decimal? Price, decimal? Commission, int? CurrencyId, string CreatedDate, string ValidDate, string ModifyDate, string LastCompileDate, int? SoftwareLanguageId, bool? IsLastPublishSuccessfully, int? DefaultLanguage, int? UserId, string Guid, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSitesUpdates(Id, SiteName, Url, ProjectCategoryId, Ranking, AvgVisitDuration, PageVisit, BounceRate, Logo, Price, Commission, CurrencyId, CreatedDate, ValidDate, ModifyDate, LastCompileDate, SoftwareLanguageId, IsLastPublishSuccessfully, DefaultLanguage, UserId, Guid), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/schemesgetalls/csv")]
        [HttpGet("/export/JSONServer/schemesgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSchemesGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSchemesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/schemesgetalls/excel")]
        [HttpGet("/export/JSONServer/schemesgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSchemesGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSchemesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/schemesgetbydatabasetypes/csv")]
        [HttpGet("/export/JSONServer/schemesgetbydatabasetypes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSchemesGetByDatabaseTypesToCSV(int? DatabaseType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSchemesGetByDatabaseTypes(DatabaseType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/schemesgetbydatabasetypes/excel")]
        [HttpGet("/export/JSONServer/schemesgetbydatabasetypes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSchemesGetByDatabaseTypesToExcel(int? DatabaseType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSchemesGetByDatabaseTypes(DatabaseType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/schemesgetbyids/csv")]
        [HttpGet("/export/JSONServer/schemesgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSchemesGetByIdsToCSV(long? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSchemesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/schemesgetbyids/excel")]
        [HttpGet("/export/JSONServer/schemesgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSchemesGetByIdsToExcel(long? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSchemesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/schemesgetbynames/csv")]
        [HttpGet("/export/JSONServer/schemesgetbynames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSchemesGetByNamesToCSV(string Name, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSchemesGetByNames(Name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/schemesgetbynames/excel")]
        [HttpGet("/export/JSONServer/schemesgetbynames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSchemesGetByNamesToExcel(string Name, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSchemesGetByNames(Name), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/schemesinserts/csv")]
        [HttpGet("/export/JSONServer/schemesinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSchemesInsertsToCSV(string Name, int? DatabaseType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSchemesInserts(Name, DatabaseType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/schemesinserts/excel")]
        [HttpGet("/export/JSONServer/schemesinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSchemesInsertsToExcel(string Name, int? DatabaseType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSchemesInserts(Name, DatabaseType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/schemesupdates/csv")]
        [HttpGet("/export/JSONServer/schemesupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSchemesUpdatesToCSV(long? Id, string Name, int? DatabaseType, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSchemesUpdates(Id, Name, DatabaseType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/schemesupdates/excel")]
        [HttpGet("/export/JSONServer/schemesupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSchemesUpdatesToExcel(long? Id, string Name, int? DatabaseType, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSchemesUpdates(Id, Name, DatabaseType), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/spcolumns/csv")]
        [HttpGet("/export/JSONServer/spcolumns/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSpColumnsToCSV(string table_name, string table_owner, string table_qualifier, string column_name, int? ODBCVer, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSpColumns(table_name, table_owner, table_qualifier, column_name, ODBCVer), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/spcolumns/excel")]
        [HttpGet("/export/JSONServer/spcolumns/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSpColumnsToExcel(string table_name, string table_owner, string table_qualifier, string column_name, int? ODBCVer, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSpColumns(table_name, table_owner, table_qualifier, column_name, ODBCVer), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/spdatatypeinfos/csv")]
        [HttpGet("/export/JSONServer/spdatatypeinfos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSpDatatypeInfosToCSV(int? data_type, byte? ODBCVer, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSpDatatypeInfos(data_type, ODBCVer), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/spdatatypeinfos/excel")]
        [HttpGet("/export/JSONServer/spdatatypeinfos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSpDatatypeInfosToExcel(int? data_type, byte? ODBCVer, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSpDatatypeInfos(data_type, ODBCVer), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/spdbmmonitorhelpalerts/csv")]
        [HttpGet("/export/JSONServer/spdbmmonitorhelpalerts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSpDbmmonitorhelpalertsToCSV(string database_name, int? alert_id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSpDbmmonitorhelpalerts(database_name, alert_id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/spdbmmonitorhelpalerts/excel")]
        [HttpGet("/export/JSONServer/spdbmmonitorhelpalerts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSpDbmmonitorhelpalertsToExcel(string database_name, int? alert_id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSpDbmmonitorhelpalerts(database_name, alert_id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/sphelpdatatypemappings/csv")]
        [HttpGet("/export/JSONServer/sphelpdatatypemappings/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSpHelpDatatypeMappingsToCSV(string dbms_name, string dbms_version, string sql_type, int? source_prec, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSpHelpDatatypeMappings(dbms_name, dbms_version, sql_type, source_prec), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/sphelpdatatypemappings/excel")]
        [HttpGet("/export/JSONServer/sphelpdatatypemappings/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSpHelpDatatypeMappingsToExcel(string dbms_name, string dbms_version, string sql_type, int? source_prec, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSpHelpDatatypeMappings(dbms_name, dbms_version, sql_type, source_prec), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/spmonitors/csv")]
        [HttpGet("/export/JSONServer/spmonitors/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSpMonitorsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSpMonitors(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/spmonitors/excel")]
        [HttpGet("/export/JSONServer/spmonitors/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSpMonitorsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSpMonitors(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/tablesgetalls/csv")]
        [HttpGet("/export/JSONServer/tablesgetalls/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTablesGetAllsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTablesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/tablesgetalls/excel")]
        [HttpGet("/export/JSONServer/tablesgetalls/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTablesGetAllsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTablesGetAlls(), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/tablesgetbyids/csv")]
        [HttpGet("/export/JSONServer/tablesgetbyids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTablesGetByIdsToCSV(long? Id, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTablesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/tablesgetbyids/excel")]
        [HttpGet("/export/JSONServer/tablesgetbyids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTablesGetByIdsToExcel(long? Id, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTablesGetByIds(Id), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/tablesgetbyprojectids/csv")]
        [HttpGet("/export/JSONServer/tablesgetbyprojectids/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTablesGetByProjectIdsToCSV(long? ProjectId, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTablesGetByProjectIds(ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/tablesgetbyprojectids/excel")]
        [HttpGet("/export/JSONServer/tablesgetbyprojectids/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTablesGetByProjectIdsToExcel(long? ProjectId, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTablesGetByProjectIds(ProjectId), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/tablesgetbytablenames/csv")]
        [HttpGet("/export/JSONServer/tablesgetbytablenames/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTablesGetByTableNamesToCSV(string TableName, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTablesGetByTableNames(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/tablesgetbytablenames/excel")]
        [HttpGet("/export/JSONServer/tablesgetbytablenames/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTablesGetByTableNamesToExcel(string TableName, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTablesGetByTableNames(TableName), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/tablesinserts/csv")]
        [HttpGet("/export/JSONServer/tablesinserts/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTablesInsertsToCSV(long? ProjectId, string TableName, string Config, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTablesInserts(ProjectId, TableName, Config), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/tablesinserts/excel")]
        [HttpGet("/export/JSONServer/tablesinserts/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTablesInsertsToExcel(long? ProjectId, string TableName, string Config, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTablesInserts(ProjectId, TableName, Config), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/tablesupdates/csv")]
        [HttpGet("/export/JSONServer/tablesupdates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTablesUpdatesToCSV(long? Id, long? ProjectId, string TableName, string Config, string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTablesUpdates(Id, ProjectId, TableName, Config), Request.Query), fileName);
        }

        [HttpGet("/export/JSONServer/tablesupdates/excel")]
        [HttpGet("/export/JSONServer/tablesupdates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTablesUpdatesToExcel(long? Id, long? ProjectId, string TableName, string Config, string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTablesUpdates(Id, ProjectId, TableName, Config), Request.Query), fileName);
        }
    }
}
