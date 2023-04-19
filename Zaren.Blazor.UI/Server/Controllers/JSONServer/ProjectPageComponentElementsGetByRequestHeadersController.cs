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
    public partial class ProjectPageComponentElementsGetByRequestHeadersController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByRequestHeadersController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByRequestHeadersFunc(RequestHeader={RequestHeader})")]
        public IActionResult ProjectPageComponentElementsGetByRequestHeadersFunc([FromODataUri] string RequestHeader)
        {
            this.OnProjectPageComponentElementsGetByRequestHeadersDefaultParams(ref RequestHeader);

            var items = this.context.ProjectPageComponentElementsGetByRequestHeaders.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByRequestHeader] @RequestHeader={0}", RequestHeader).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByRequestHeadersInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByRequestHeadersDefaultParams(ref string RequestHeader);

        partial void OnProjectPageComponentElementsGetByRequestHeadersInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByRequestHeader> items);
    }
}
