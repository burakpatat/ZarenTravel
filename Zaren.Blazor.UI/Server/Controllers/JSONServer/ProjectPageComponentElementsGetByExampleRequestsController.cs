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
    public partial class ProjectPageComponentElementsGetByExampleRequestsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByExampleRequestsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByExampleRequestsFunc(ExampleRequest={ExampleRequest})")]
        public IActionResult ProjectPageComponentElementsGetByExampleRequestsFunc([FromODataUri] string ExampleRequest)
        {
            this.OnProjectPageComponentElementsGetByExampleRequestsDefaultParams(ref ExampleRequest);

            var items = this.context.ProjectPageComponentElementsGetByExampleRequests.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByExampleRequest] @ExampleRequest={0}", ExampleRequest).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByExampleRequestsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByExampleRequestsDefaultParams(ref string ExampleRequest);

        partial void OnProjectPageComponentElementsGetByExampleRequestsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByExampleRequest> items);
    }
}
