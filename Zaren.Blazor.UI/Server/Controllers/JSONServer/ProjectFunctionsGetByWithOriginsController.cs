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
    public partial class ProjectFunctionsGetByWithOriginsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByWithOriginsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByWithOriginsFunc(WithOrigins={WithOrigins})")]
        public IActionResult ProjectFunctionsGetByWithOriginsFunc([FromODataUri] string WithOrigins)
        {
            this.OnProjectFunctionsGetByWithOriginsDefaultParams(ref WithOrigins);

            var items = this.context.ProjectFunctionsGetByWithOrigins.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByWithOrigins] @WithOrigins={0}", WithOrigins).ToList().AsQueryable();

            this.OnProjectFunctionsGetByWithOriginsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByWithOriginsDefaultParams(ref string WithOrigins);

        partial void OnProjectFunctionsGetByWithOriginsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWithOrigin> items);
    }
}
