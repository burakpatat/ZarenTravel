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
    public partial class ProjectTablesGetByAuditConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByAuditConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByAuditConfigurationsFunc(AuditConfiguration={AuditConfiguration})")]
        public IActionResult ProjectTablesGetByAuditConfigurationsFunc([FromODataUri] string AuditConfiguration)
        {
            this.OnProjectTablesGetByAuditConfigurationsDefaultParams(ref AuditConfiguration);

            var items = this.context.ProjectTablesGetByAuditConfigurations.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByAuditConfiguration] @AuditConfiguration={0}", AuditConfiguration).ToList().AsQueryable();

            this.OnProjectTablesGetByAuditConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByAuditConfigurationsDefaultParams(ref string AuditConfiguration);

        partial void OnProjectTablesGetByAuditConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByAuditConfiguration> items);
    }
}
