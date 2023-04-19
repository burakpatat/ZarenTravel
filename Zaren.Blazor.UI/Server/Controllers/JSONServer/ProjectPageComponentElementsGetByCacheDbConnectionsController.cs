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
    public partial class ProjectPageComponentElementsGetByCacheDbConnectionsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByCacheDbConnectionsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByCacheDbConnectionsFunc(CacheDBConnection={CacheDBConnection})")]
        public IActionResult ProjectPageComponentElementsGetByCacheDbConnectionsFunc([FromODataUri] int? CacheDBConnection)
        {
            this.OnProjectPageComponentElementsGetByCacheDbConnectionsDefaultParams(ref CacheDBConnection);

            var items = this.context.ProjectPageComponentElementsGetByCacheDbConnections.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByCacheDBConnection] @CacheDBConnection={0}", CacheDBConnection).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByCacheDbConnectionsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByCacheDbConnectionsDefaultParams(ref int? CacheDBConnection);

        partial void OnProjectPageComponentElementsGetByCacheDbConnectionsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCacheDbConnection> items);
    }
}
