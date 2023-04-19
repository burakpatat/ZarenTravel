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
    public partial class ProjectFunctionsGetByHasAuditEventsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByHasAuditEventsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByHasAuditEventsFunc(HasAuditEvents={HasAuditEvents})")]
        public IActionResult ProjectFunctionsGetByHasAuditEventsFunc([FromODataUri] bool? HasAuditEvents)
        {
            this.OnProjectFunctionsGetByHasAuditEventsDefaultParams(ref HasAuditEvents);

            var items = this.context.ProjectFunctionsGetByHasAuditEvents.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByHasAuditEvents] @HasAuditEvents={0}", HasAuditEvents).ToList().AsQueryable();

            this.OnProjectFunctionsGetByHasAuditEventsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByHasAuditEventsDefaultParams(ref bool? HasAuditEvents);

        partial void OnProjectFunctionsGetByHasAuditEventsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHasAuditEvent> items);
    }
}
