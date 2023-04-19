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
    public partial class SchemesInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public SchemesInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/SchemesInsertsFunc(Name={Name},DatabaseType={DatabaseType})")]
        public IActionResult SchemesInsertsFunc([FromODataUri] string Name, [FromODataUri] int? DatabaseType)
        {
            this.OnSchemesInsertsDefaultParams(ref Name, ref DatabaseType);

            var items = this.context.SchemesInserts.FromSqlRaw("EXEC [dbo].[SchemesInsert] @Name={0}, @DatabaseType={1}", Name, DatabaseType).ToList().AsQueryable();

            this.OnSchemesInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnSchemesInsertsDefaultParams(ref string Name, ref int? DatabaseType);

        partial void OnSchemesInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.SchemesInsert> items);
    }
}
