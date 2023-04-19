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
    public partial class ProjectTablesGetByCmsExportConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByCmsExportConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByCmsExportConfigurationsFunc(CMSExportConfiguration={CMSExportConfiguration})")]
        public IActionResult ProjectTablesGetByCmsExportConfigurationsFunc([FromODataUri] string CMSExportConfiguration)
        {
            this.OnProjectTablesGetByCmsExportConfigurationsDefaultParams(ref CMSExportConfiguration);

            var items = this.context.ProjectTablesGetByCmsExportConfigurations.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByCMSExportConfiguration] @CMSExportConfiguration={0}", CMSExportConfiguration).ToList().AsQueryable();

            this.OnProjectTablesGetByCmsExportConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByCmsExportConfigurationsDefaultParams(ref string CMSExportConfiguration);

        partial void OnProjectTablesGetByCmsExportConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCmsExportConfiguration> items);
    }
}
