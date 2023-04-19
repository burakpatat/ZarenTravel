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
    public partial class ProjectFunctionsGetByHasRateLimitsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByHasRateLimitsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByHasRateLimitsFunc(HasRateLimit={HasRateLimit})")]
        public IActionResult ProjectFunctionsGetByHasRateLimitsFunc([FromODataUri] bool? HasRateLimit)
        {
            this.OnProjectFunctionsGetByHasRateLimitsDefaultParams(ref HasRateLimit);

            var items = this.context.ProjectFunctionsGetByHasRateLimits.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByHasRateLimit] @HasRateLimit={0}", HasRateLimit).ToList().AsQueryable();

            this.OnProjectFunctionsGetByHasRateLimitsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByHasRateLimitsDefaultParams(ref bool? HasRateLimit);

        partial void OnProjectFunctionsGetByHasRateLimitsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHasRateLimit> items);
    }
}
