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
    public partial class ProjectsGetByDatabaseSchemasController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectsGetByDatabaseSchemasController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectsGetByDatabaseSchemasFunc(DatabaseSchemas={DatabaseSchemas})")]
        public IActionResult ProjectsGetByDatabaseSchemasFunc([FromODataUri] string DatabaseSchemas)
        {
            this.OnProjectsGetByDatabaseSchemasDefaultParams(ref DatabaseSchemas);

            var items = this.context.ProjectsGetByDatabaseSchemas.FromSqlRaw("EXEC [dbo].[ProjectsGetByDatabaseSchemas] @DatabaseSchemas={0}", DatabaseSchemas).ToList().AsQueryable();

            this.OnProjectsGetByDatabaseSchemasInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectsGetByDatabaseSchemasDefaultParams(ref string DatabaseSchemas);

        partial void OnProjectsGetByDatabaseSchemasInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectsGetByDatabaseSchema> items);
    }
}
