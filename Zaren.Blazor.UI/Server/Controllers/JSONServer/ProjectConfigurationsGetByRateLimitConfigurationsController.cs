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
    public partial class ProjectConfigurationsGetByRateLimitConfigurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsGetByRateLimitConfigurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsGetByRateLimitConfigurationsFunc(RateLimitConfiguration={RateLimitConfiguration})")]
        public IActionResult ProjectConfigurationsGetByRateLimitConfigurationsFunc([FromODataUri] string RateLimitConfiguration)
        {
            this.OnProjectConfigurationsGetByRateLimitConfigurationsDefaultParams(ref RateLimitConfiguration);

            var items = this.context.ProjectConfigurationsGetByRateLimitConfigurations.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsGetByRateLimitConfiguration] @RateLimitConfiguration={0}", RateLimitConfiguration).ToList().AsQueryable();

            this.OnProjectConfigurationsGetByRateLimitConfigurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsGetByRateLimitConfigurationsDefaultParams(ref string RateLimitConfiguration);

        partial void OnProjectConfigurationsGetByRateLimitConfigurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByRateLimitConfiguration> items);
    }
}
