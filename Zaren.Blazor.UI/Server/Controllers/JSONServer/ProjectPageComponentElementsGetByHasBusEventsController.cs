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
    public partial class ProjectPageComponentElementsGetByHasBusEventsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByHasBusEventsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByHasBusEventsFunc(HasBusEvent={HasBusEvent})")]
        public IActionResult ProjectPageComponentElementsGetByHasBusEventsFunc([FromODataUri] bool? HasBusEvent)
        {
            this.OnProjectPageComponentElementsGetByHasBusEventsDefaultParams(ref HasBusEvent);

            var items = this.context.ProjectPageComponentElementsGetByHasBusEvents.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByHasBusEvent] @HasBusEvent={0}", HasBusEvent).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByHasBusEventsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByHasBusEventsDefaultParams(ref bool? HasBusEvent);

        partial void OnProjectPageComponentElementsGetByHasBusEventsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByHasBusEvent> items);
    }
}
