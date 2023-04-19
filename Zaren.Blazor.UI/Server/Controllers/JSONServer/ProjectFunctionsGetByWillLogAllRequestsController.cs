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
    public partial class ProjectFunctionsGetByWillLogAllRequestsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByWillLogAllRequestsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByWillLogAllRequestsFunc(WillLogAllRequest={WillLogAllRequest})")]
        public IActionResult ProjectFunctionsGetByWillLogAllRequestsFunc([FromODataUri] bool? WillLogAllRequest)
        {
            this.OnProjectFunctionsGetByWillLogAllRequestsDefaultParams(ref WillLogAllRequest);

            var items = this.context.ProjectFunctionsGetByWillLogAllRequests.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByWillLogAllRequest] @WillLogAllRequest={0}", WillLogAllRequest).ToList().AsQueryable();

            this.OnProjectFunctionsGetByWillLogAllRequestsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByWillLogAllRequestsDefaultParams(ref bool? WillLogAllRequest);

        partial void OnProjectFunctionsGetByWillLogAllRequestsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWillLogAllRequest> items);
    }
}
