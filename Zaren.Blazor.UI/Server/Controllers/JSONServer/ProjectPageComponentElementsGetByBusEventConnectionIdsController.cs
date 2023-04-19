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
    public partial class ProjectPageComponentElementsGetByBusEventConnectionIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByBusEventConnectionIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByBusEventConnectionIdsFunc(BusEventConnectionId={BusEventConnectionId})")]
        public IActionResult ProjectPageComponentElementsGetByBusEventConnectionIdsFunc([FromODataUri] int? BusEventConnectionId)
        {
            this.OnProjectPageComponentElementsGetByBusEventConnectionIdsDefaultParams(ref BusEventConnectionId);

            var items = this.context.ProjectPageComponentElementsGetByBusEventConnectionIds.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByBusEventConnectionId] @BusEventConnectionId={0}", BusEventConnectionId).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByBusEventConnectionIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByBusEventConnectionIdsDefaultParams(ref int? BusEventConnectionId);

        partial void OnProjectPageComponentElementsGetByBusEventConnectionIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByBusEventConnectionId> items);
    }
}
