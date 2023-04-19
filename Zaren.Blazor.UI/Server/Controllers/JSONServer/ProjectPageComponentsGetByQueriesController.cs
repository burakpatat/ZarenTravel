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
    public partial class ProjectPageComponentsGetByQueriesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByQueriesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByQueriesFunc(Query={Query})")]
        public IActionResult ProjectPageComponentsGetByQueriesFunc([FromODataUri] string Query)
        {
            this.OnProjectPageComponentsGetByQueriesDefaultParams(ref Query);

            var items = this.context.ProjectPageComponentsGetByQueries.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByQuery] @Query={0}", Query).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByQueriesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByQueriesDefaultParams(ref string Query);

        partial void OnProjectPageComponentsGetByQueriesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByQuery> items);
    }
}
