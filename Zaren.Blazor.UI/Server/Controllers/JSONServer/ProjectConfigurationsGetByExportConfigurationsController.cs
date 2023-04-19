using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ZarenUI.Server.Controllers.JSONServer
{
    public partial class ProjectConfigurationsGetByExportConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByExportConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByExportConfigurationsFunc(ExportConfiguration={ExportConfiguration})")]
        public IActionResult ProjectConfigurationsGetByExportConfigurationsFunc([FromODataUri] string ExportConfiguration)
        {
            this.OnProjectConfigurationsGetByExportConfigurationsDefaultParams(ref ExportConfiguration);

            var items = this.context.ProjectConfigurationsGetByExportConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByExportConfiguration] @ExportConfiguration={0}", ExportConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByExportConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByExportConfigurationsDefaultParams(ref string ExportConfiguration);

        partial void OnProjectConfigurationsGetByExportConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByExportConfiguration> items);
    }
}
