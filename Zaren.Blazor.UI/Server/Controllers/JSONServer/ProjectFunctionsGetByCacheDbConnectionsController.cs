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
    public partial class ProjectFunctionsGetByCacheDbConnectionsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByCacheDbConnectionsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByCacheDbConnectionsFunc(CacheDBConnection={CacheDBConnection})")]
        public IActionResult ProjectFunctionsGetByCacheDbConnectionsFunc([FromODataUri] int? CacheDBConnection)
        {
            this.OnProjectFunctionsGetByCacheDbConnectionsDefaultParams(ref CacheDBConnection);

            var items = this.context.ProjectFunctionsGetByCacheDbConnections.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByCacheDBConnection] @CacheDBConnection={0}", CacheDBConnection).ToList().AsQueryable();

            this.OnProjectFunctionsGetByCacheDbConnectionsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByCacheDbConnectionsDefaultParams(ref int? CacheDBConnection);

        partial void OnProjectFunctionsGetByCacheDbConnectionsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCacheDbConnection> items);
    }
}
