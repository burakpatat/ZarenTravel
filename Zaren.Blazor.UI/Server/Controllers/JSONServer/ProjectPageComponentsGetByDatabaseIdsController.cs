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
    public partial class ProjectPageComponentsGetByDatabaseIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByDatabaseIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByDatabaseIdsFunc(DatabaseId={DatabaseId})")]
        public IActionResult ProjectPageComponentsGetByDatabaseIdsFunc([FromODataUri] int? DatabaseId)
        {
            this.OnProjectPageComponentsGetByDatabaseIdsDefaultParams(ref DatabaseId);

            var items = this.context.ProjectPageComponentsGetByDatabaseIds.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByDatabaseId] @DatabaseId={0}", DatabaseId).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByDatabaseIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByDatabaseIdsDefaultParams(ref int? DatabaseId);

        partial void OnProjectPageComponentsGetByDatabaseIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByDatabaseId> items);
    }
}
