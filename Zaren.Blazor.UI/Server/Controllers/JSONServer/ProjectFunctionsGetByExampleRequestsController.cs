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
    public partial class ProjectFunctionsGetByExampleRequestsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByExampleRequestsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByExampleRequestsFunc(ExampleRequest={ExampleRequest})")]
        public IActionResult ProjectFunctionsGetByExampleRequestsFunc([FromODataUri] string ExampleRequest)
        {
            this.OnProjectFunctionsGetByExampleRequestsDefaultParams(ref ExampleRequest);

            var items = this.context.ProjectFunctionsGetByExampleRequests.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByExampleRequest] @ExampleRequest={0}", ExampleRequest).ToList().AsQueryable();

            this.OnProjectFunctionsGetByExampleRequestsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByExampleRequestsDefaultParams(ref string ExampleRequest);

        partial void OnProjectFunctionsGetByExampleRequestsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByExampleRequest> items);
    }
}
