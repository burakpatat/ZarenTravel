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
    public partial class ProjectFunctionsGetByEventTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByEventTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByEventTypesFunc(EventType={EventType})")]
        public IActionResult ProjectFunctionsGetByEventTypesFunc([FromODataUri] int? EventType)
        {
            this.OnProjectFunctionsGetByEventTypesDefaultParams(ref EventType);

            var items = this.context.ProjectFunctionsGetByEventTypes.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByEventType] @EventType={0}", EventType).ToList().AsQueryable();

            this.OnProjectFunctionsGetByEventTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByEventTypesDefaultParams(ref int? EventType);

        partial void OnProjectFunctionsGetByEventTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByEventType> items);
    }
}
