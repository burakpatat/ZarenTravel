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
    public partial class ProjectConfigurationsGetByColumnConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByColumnConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByColumnConfigurationsFunc(ColumnConfiguration={ColumnConfiguration})")]
        public IActionResult ProjectConfigurationsGetByColumnConfigurationsFunc([FromODataUri] string ColumnConfiguration)
        {
            this.OnProjectConfigurationsGetByColumnConfigurationsDefaultParams(ref ColumnConfiguration);

            var items = this.context.ProjectConfigurationsGetByColumnConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByColumnConfiguration] @ColumnConfiguration={0}", ColumnConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByColumnConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByColumnConfigurationsDefaultParams(ref string ColumnConfiguration);

        partial void OnProjectConfigurationsGetByColumnConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByColumnConfiguration> items);
    }
}
