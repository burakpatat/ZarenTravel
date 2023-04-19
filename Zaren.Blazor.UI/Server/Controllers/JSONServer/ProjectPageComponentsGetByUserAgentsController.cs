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
    public partial class ProjectPageComponentsGetByUserAgentsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByUserAgentsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByUserAgentsFunc(UserAgent={UserAgent})")]
        public IActionResult ProjectPageComponentsGetByUserAgentsFunc([FromODataUri] string UserAgent)
        {
            this.OnProjectPageComponentsGetByUserAgentsDefaultParams(ref UserAgent);

            var items = this.context.ProjectPageComponentsGetByUserAgents.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByUserAgent] @UserAgent={0}", UserAgent).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByUserAgentsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByUserAgentsDefaultParams(ref string UserAgent);

        partial void OnProjectPageComponentsGetByUserAgentsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByUserAgent> items);
    }
}
