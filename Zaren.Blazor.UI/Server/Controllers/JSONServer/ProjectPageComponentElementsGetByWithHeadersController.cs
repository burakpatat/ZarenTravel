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
    public partial class ProjectPageComponentElementsGetByWithHeadersController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByWithHeadersController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByWithHeadersFunc(WithHeaders={WithHeaders})")]
        public IActionResult ProjectPageComponentElementsGetByWithHeadersFunc([FromODataUri] string WithHeaders)
        {
            this.OnProjectPageComponentElementsGetByWithHeadersDefaultParams(ref WithHeaders);

            var items = this.context.ProjectPageComponentElementsGetByWithHeaders.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByWithHeaders] @WithHeaders={0}", WithHeaders).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByWithHeadersInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByWithHeadersDefaultParams(ref string WithHeaders);

        partial void OnProjectPageComponentElementsGetByWithHeadersInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWithHeader> items);
    }
}
