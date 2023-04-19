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
    public partial class SchemesUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public SchemesUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/SchemesUpdatesFunc(Id={Id},Name={Name},DatabaseType={DatabaseType})")]
        public IActionResult SchemesUpdatesFunc([FromODataUri] long? Id, [FromODataUri] string Name, [FromODataUri] int? DatabaseType)
        {
            this.OnSchemesUpdatesDefaultParams(ref Id, ref Name, ref DatabaseType);

            var items = this.context.SchemesUpdates.FromSqlRaw("EXEC [dbo].[SchemesUpdate] @Id={0}, @Name={1}, @DatabaseType={2}", Id, Name, DatabaseType).ToList().AsQueryable();

            this.OnSchemesUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnSchemesUpdatesDefaultParams(ref long? Id, ref string Name, ref int? DatabaseType);

        partial void OnSchemesUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.SchemesUpdate> items);
    }
}
