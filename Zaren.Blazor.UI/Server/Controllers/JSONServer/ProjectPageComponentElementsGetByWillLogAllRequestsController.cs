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
    public partial class ProjectPageComponentElementsGetByWillLogAllRequestsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByWillLogAllRequestsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByWillLogAllRequestsFunc(WillLogAllRequest={WillLogAllRequest})")]
        public IActionResult ProjectPageComponentElementsGetByWillLogAllRequestsFunc([FromODataUri] bool? WillLogAllRequest)
        {
            this.OnProjectPageComponentElementsGetByWillLogAllRequestsDefaultParams(ref WillLogAllRequest);

            var items = this.context.ProjectPageComponentElementsGetByWillLogAllRequests.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByWillLogAllRequest] @WillLogAllRequest={0}", WillLogAllRequest).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByWillLogAllRequestsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByWillLogAllRequestsDefaultParams(ref bool? WillLogAllRequest);

        partial void OnProjectPageComponentElementsGetByWillLogAllRequestsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWillLogAllRequest> items);
    }
}
