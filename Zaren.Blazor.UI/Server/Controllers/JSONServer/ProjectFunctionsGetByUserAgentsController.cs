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
    public partial class ProjectFunctionsGetByUserAgentsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByUserAgentsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByUserAgentsFunc(UserAgent={UserAgent})")]
        public IActionResult ProjectFunctionsGetByUserAgentsFunc([FromODataUri] string UserAgent)
        {
            this.OnProjectFunctionsGetByUserAgentsDefaultParams(ref UserAgent);

            var items = this.context.ProjectFunctionsGetByUserAgents.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByUserAgent] @UserAgent={0}", UserAgent).ToList().AsQueryable();

            this.OnProjectFunctionsGetByUserAgentsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByUserAgentsDefaultParams(ref string UserAgent);

        partial void OnProjectFunctionsGetByUserAgentsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByUserAgent> items);
    }
}
