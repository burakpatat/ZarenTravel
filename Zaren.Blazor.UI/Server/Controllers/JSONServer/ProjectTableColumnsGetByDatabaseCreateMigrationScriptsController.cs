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
    public partial class ProjectTableColumnsGetByDatabaseCreateMigrationScriptsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsGetByDatabaseCreateMigrationScriptsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsGetByDatabaseCreateMigrationScriptsFunc(DatabaseCreateMigrationScript={DatabaseCreateMigrationScript})")]
        public IActionResult ProjectTableColumnsGetByDatabaseCreateMigrationScriptsFunc([FromODataUri] string DatabaseCreateMigrationScript)
        {
            this.OnProjectTableColumnsGetByDatabaseCreateMigrationScriptsDefaultParams(ref DatabaseCreateMigrationScript);

            var items = this.context.ProjectTableColumnsGetByDatabaseCreateMigrationScripts.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsGetByDatabaseCreateMigrationScript] @DatabaseCreateMigrationScript={0}", DatabaseCreateMigrationScript).ToList().AsQueryable();

            this.OnProjectTableColumnsGetByDatabaseCreateMigrationScriptsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsGetByDatabaseCreateMigrationScriptsDefaultParams(ref string DatabaseCreateMigrationScript);

        partial void OnProjectTableColumnsGetByDatabaseCreateMigrationScriptsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByDatabaseCreateMigrationScript> items);
    }
}
