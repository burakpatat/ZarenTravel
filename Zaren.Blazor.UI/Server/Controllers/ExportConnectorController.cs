using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using ZarenUI.Server.Data;

namespace ZarenUI.Server.Controllers
{
    public partial class ExportConnectorController : ExportController
    {
        private readonly ConnectorContext context;
        private readonly ConnectorService service;

        public ExportConnectorController(ConnectorContext context, ConnectorService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/Connector/colorgroups/csv")]
        [HttpGet("/export/Connector/colorgroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetColorGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/colorgroups/excel")]
        [HttpGet("/export/Connector/colorgroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportColorGroupsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetColorGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/countries/csv")]
        [HttpGet("/export/Connector/countries/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/countries/excel")]
        [HttpGet("/export/Connector/countries/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountries(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/countrylanguages/csv")]
        [HttpGet("/export/Connector/countrylanguages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCountryLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/countrylanguages/excel")]
        [HttpGet("/export/Connector/countrylanguages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCountryLanguagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCountryLanguages(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/devicegroups/csv")]
        [HttpGet("/export/Connector/devicegroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDeviceGroupsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDeviceGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/devicegroups/excel")]
        [HttpGet("/export/Connector/devicegroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDeviceGroupsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDeviceGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/devices/csv")]
        [HttpGet("/export/Connector/devices/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDevices(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/devices/excel")]
        [HttpGet("/export/Connector/devices/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDevicesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDevices(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/distributedservercaches/csv")]
        [HttpGet("/export/Connector/distributedservercaches/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDistributedServerCachesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDistributedServerCaches(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/distributedservercaches/excel")]
        [HttpGet("/export/Connector/distributedservercaches/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDistributedServerCachesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDistributedServerCaches(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/fields/csv")]
        [HttpGet("/export/Connector/fields/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetFields(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/fields/excel")]
        [HttpGet("/export/Connector/fields/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportFieldsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetFields(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/programmingcategories/csv")]
        [HttpGet("/export/Connector/programmingcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/programmingcategories/excel")]
        [HttpGet("/export/Connector/programmingcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/programmingcodes/csv")]
        [HttpGet("/export/Connector/programmingcodes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodes(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/programmingcodes/excel")]
        [HttpGet("/export/Connector/programmingcodes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodes(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/programmingcodetemplates/csv")]
        [HttpGet("/export/Connector/programmingcodetemplates/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingCodeTemplates(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/programmingcodetemplates/excel")]
        [HttpGet("/export/Connector/programmingcodetemplates/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingCodeTemplatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingCodeTemplates(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/programmingtechnologies/csv")]
        [HttpGet("/export/Connector/programmingtechnologies/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologiesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProgrammingTechnologies(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/programmingtechnologies/excel")]
        [HttpGet("/export/Connector/programmingtechnologies/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProgrammingTechnologiesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProgrammingTechnologies(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projectcategories/csv")]
        [HttpGet("/export/Connector/projectcategories/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projectcategories/excel")]
        [HttpGet("/export/Connector/projectcategories/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectCategoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectCategories(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projectconfigurationkeyandvalues/csv")]
        [HttpGet("/export/Connector/projectconfigurationkeyandvalues/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValuesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurationKeyAndValues(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projectconfigurationkeyandvalues/excel")]
        [HttpGet("/export/Connector/projectconfigurationkeyandvalues/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationKeyAndValuesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurationKeyAndValues(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projectconfigurations/csv")]
        [HttpGet("/export/Connector/projectconfigurations/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projectconfigurations/excel")]
        [HttpGet("/export/Connector/projectconfigurations/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectConfigurationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectConfigurations(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projectfunctiongroups/csv")]
        [HttpGet("/export/Connector/projectfunctiongroups/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctionGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projectfunctiongroups/excel")]
        [HttpGet("/export/Connector/projectfunctiongroups/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionGroupsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctionGroups(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projectfunctions/csv")]
        [HttpGet("/export/Connector/projectfunctions/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectFunctions(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projectfunctions/excel")]
        [HttpGet("/export/Connector/projectfunctions/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectFunctionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectFunctions(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projectpagecomponentelements/csv")]
        [HttpGet("/export/Connector/projectpagecomponentelements/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponentElements(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projectpagecomponentelements/excel")]
        [HttpGet("/export/Connector/projectpagecomponentelements/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentElementsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponentElements(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projectpagecomponents/csv")]
        [HttpGet("/export/Connector/projectpagecomponents/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPageComponents(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projectpagecomponents/excel")]
        [HttpGet("/export/Connector/projectpagecomponents/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPageComponentsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPageComponents(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projectpages/csv")]
        [HttpGet("/export/Connector/projectpages/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectPages(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projectpages/excel")]
        [HttpGet("/export/Connector/projectpages/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectPagesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectPages(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projects/csv")]
        [HttpGet("/export/Connector/projects/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjects(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projects/excel")]
        [HttpGet("/export/Connector/projects/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjects(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projecttablecolumns/csv")]
        [HttpGet("/export/Connector/projecttablecolumns/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTableColumns(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projecttablecolumns/excel")]
        [HttpGet("/export/Connector/projecttablecolumns/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTableColumnsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTableColumns(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projecttables/csv")]
        [HttpGet("/export/Connector/projecttables/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectTables(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/projecttables/excel")]
        [HttpGet("/export/Connector/projecttables/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportProjectTablesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectTables(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/referencewebsites/csv")]
        [HttpGet("/export/Connector/referencewebsites/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetReferenceWebSites(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/referencewebsites/excel")]
        [HttpGet("/export/Connector/referencewebsites/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportReferenceWebSitesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetReferenceWebSites(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/schemes/csv")]
        [HttpGet("/export/Connector/schemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSchemesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSchemes(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/schemes/excel")]
        [HttpGet("/export/Connector/schemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSchemesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSchemes(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/tables/csv")]
        [HttpGet("/export/Connector/tables/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTablesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTables(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/tables/excel")]
        [HttpGet("/export/Connector/tables/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTablesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTables(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/designschemes/csv")]
        [HttpGet("/export/Connector/designschemes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignSchemesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetDesignSchemes(), Request.Query), fileName);
        }

        [HttpGet("/export/Connector/designschemes/excel")]
        [HttpGet("/export/Connector/designschemes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportDesignSchemesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetDesignSchemes(), Request.Query), fileName);
        }
    }
}
