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
    public partial class ProjectFunctionsGetByRateLimitPropertiesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByRateLimitPropertiesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByRateLimitPropertiesFunc(RateLimitProperty={RateLimitProperty})")]
        public IActionResult ProjectFunctionsGetByRateLimitPropertiesFunc([FromODataUri] string RateLimitProperty)
        {
            this.OnProjectFunctionsGetByRateLimitPropertiesDefaultParams(ref RateLimitProperty);

            var items = this.context.ProjectFunctionsGetByRateLimitProperties.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByRateLimitProperty] @RateLimitProperty={0}", RateLimitProperty).ToList().AsQueryable();

            this.OnProjectFunctionsGetByRateLimitPropertiesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByRateLimitPropertiesDefaultParams(ref string RateLimitProperty);

        partial void OnProjectFunctionsGetByRateLimitPropertiesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByRateLimitProperty> items);
    }
}
