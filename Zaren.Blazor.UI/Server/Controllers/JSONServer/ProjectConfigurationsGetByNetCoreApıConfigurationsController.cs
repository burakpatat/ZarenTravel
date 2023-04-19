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
    public partial class ProjectConfigurationsGetByNetCoreApıConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByNetCoreApıConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByNetCoreApıConfigurationsFunc(NetCoreAPIConfiguration={NetCoreAPIConfiguration})")]
        public IActionResult ProjectConfigurationsGetByNetCoreApıConfigurationsFunc([FromODataUri] string NetCoreAPIConfiguration)
        {
            this.OnProjectConfigurationsGetByNetCoreApıConfigurationsDefaultParams(ref NetCoreAPIConfiguration);

            var items = this.context.ProjectConfigurationsGetByNetCoreApıConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByNetCoreAPIConfiguration] @NetCoreAPIConfiguration={0}", NetCoreAPIConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByNetCoreApıConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByNetCoreApıConfigurationsDefaultParams(ref string NetCoreAPIConfiguration);

        partial void OnProjectConfigurationsGetByNetCoreApıConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByNetCoreApıConfiguration> items);
    }
}
