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
    public partial class SchemesGetByDatabaseTypesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public SchemesGetByDatabaseTypesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/SchemesGetByDatabaseTypesFunc(DatabaseType={DatabaseType})")]
        public IActionResult SchemesGetByDatabaseTypesFunc([FromODataUri] int? DatabaseType)
        {
            this.OnSchemesGetByDatabaseTypesDefaultParams(ref DatabaseType);

            var items = this.context.SchemesGetByDatabaseTypes.FromSqlRaw("EXEC [dbo].[SchemesGetByDatabaseType] @DatabaseType={0}", DatabaseType).ToList().AsQueryable();

            this.OnSchemesGetByDatabaseTypesInvoke(ref items);

            return Ok(items);
        }

        partial void OnSchemesGetByDatabaseTypesDefaultParams(ref int? DatabaseType);

        partial void OnSchemesGetByDatabaseTypesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.SchemesGetByDatabaseType> items);
    }
}
