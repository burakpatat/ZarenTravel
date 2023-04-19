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
    public partial class ProjectFunctionsGetByDatabaseTypesIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByDatabaseTypesIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByDatabaseTypesIdsFunc(DatabaseTypesId={DatabaseTypesId})")]
        public IActionResult ProjectFunctionsGetByDatabaseTypesIdsFunc([FromODataUri] int? DatabaseTypesId)
        {
            this.OnProjectFunctionsGetByDatabaseTypesIdsDefaultParams(ref DatabaseTypesId);

            var items = this.context.ProjectFunctionsGetByDatabaseTypesIds.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByDatabaseTypesId] @DatabaseTypesId={0}", DatabaseTypesId).ToList().AsQueryable();

            this.OnProjectFunctionsGetByDatabaseTypesIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByDatabaseTypesIdsDefaultParams(ref int? DatabaseTypesId);

        partial void OnProjectFunctionsGetByDatabaseTypesIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByDatabaseTypesId> items);
    }
}
