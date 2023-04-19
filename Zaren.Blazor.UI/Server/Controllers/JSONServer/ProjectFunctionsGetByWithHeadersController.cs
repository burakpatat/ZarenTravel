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
    public partial class ProjectFunctionsGetByWithHeadersController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByWithHeadersController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByWithHeadersFunc(WithHeaders={WithHeaders})")]
        public IActionResult ProjectFunctionsGetByWithHeadersFunc([FromODataUri] string WithHeaders)
        {
            this.OnProjectFunctionsGetByWithHeadersDefaultParams(ref WithHeaders);

            var items = this.context.ProjectFunctionsGetByWithHeaders.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByWithHeaders] @WithHeaders={0}", WithHeaders).ToList().AsQueryable();

            this.OnProjectFunctionsGetByWithHeadersInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByWithHeadersDefaultParams(ref string WithHeaders);

        partial void OnProjectFunctionsGetByWithHeadersInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWithHeader> items);
    }
}
