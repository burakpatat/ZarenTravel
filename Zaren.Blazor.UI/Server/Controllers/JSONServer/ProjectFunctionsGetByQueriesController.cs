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
    public partial class ProjectFunctionsGetByQueriesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByQueriesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByQueriesFunc(Query={Query})")]
        public IActionResult ProjectFunctionsGetByQueriesFunc([FromODataUri] string Query)
        {
            this.OnProjectFunctionsGetByQueriesDefaultParams(ref Query);

            var items = this.context.ProjectFunctionsGetByQueries.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByQuery] @Query={0}", Query).ToList().AsQueryable();

            this.OnProjectFunctionsGetByQueriesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByQueriesDefaultParams(ref string Query);

        partial void OnProjectFunctionsGetByQueriesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByQuery> items);
    }
}
