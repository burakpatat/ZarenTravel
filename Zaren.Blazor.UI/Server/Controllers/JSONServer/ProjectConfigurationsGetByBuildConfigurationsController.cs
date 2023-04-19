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
    public partial class ProjectConfigurationsGetByBuildConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByBuildConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByBuildConfigurationsFunc(BuildConfiguration={BuildConfiguration})")]
        public IActionResult ProjectConfigurationsGetByBuildConfigurationsFunc([FromODataUri] string BuildConfiguration)
        {
            this.OnProjectConfigurationsGetByBuildConfigurationsDefaultParams(ref BuildConfiguration);

            var items = this.context.ProjectConfigurationsGetByBuildConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByBuildConfiguration] @BuildConfiguration={0}", BuildConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByBuildConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByBuildConfigurationsDefaultParams(ref string BuildConfiguration);

        partial void OnProjectConfigurationsGetByBuildConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByBuildConfiguration> items);
    }
}
