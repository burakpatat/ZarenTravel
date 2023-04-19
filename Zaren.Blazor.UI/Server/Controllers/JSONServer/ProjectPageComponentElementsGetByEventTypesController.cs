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
    public partial class ProjectPageComponentElementsGetByEventTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByEventTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByEventTypesFunc(EventType={EventType})")]
        public IActionResult ProjectPageComponentElementsGetByEventTypesFunc([FromODataUri] int? EventType)
        {
            this.OnProjectPageComponentElementsGetByEventTypesDefaultParams(ref EventType);

            var items = this.context.ProjectPageComponentElementsGetByEventTypes.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByEventType] @EventType={0}", EventType).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByEventTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByEventTypesDefaultParams(ref int? EventType);

        partial void OnProjectPageComponentElementsGetByEventTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByEventType> items);
    }
}
