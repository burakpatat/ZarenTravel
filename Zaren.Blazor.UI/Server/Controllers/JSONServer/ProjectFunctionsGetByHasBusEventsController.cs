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
    public partial class ProjectFunctionsGetByHasBusEventsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByHasBusEventsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByHasBusEventsFunc(HasBusEvent={HasBusEvent})")]
        public IActionResult ProjectFunctionsGetByHasBusEventsFunc([FromODataUri] bool? HasBusEvent)
        {
            this.OnProjectFunctionsGetByHasBusEventsDefaultParams(ref HasBusEvent);

            var items = this.context.ProjectFunctionsGetByHasBusEvents.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByHasBusEvent] @HasBusEvent={0}", HasBusEvent).ToList().AsQueryable();

            this.OnProjectFunctionsGetByHasBusEventsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByHasBusEventsDefaultParams(ref bool? HasBusEvent);

        partial void OnProjectFunctionsGetByHasBusEventsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHasBusEvent> items);
    }
}
