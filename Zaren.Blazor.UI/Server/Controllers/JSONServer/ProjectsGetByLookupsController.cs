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
    public partial class ProjectsGetByLookupsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectsGetByLookupsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectsGetByLookupsFunc(Lookups={Lookups})")]
        public IActionResult ProjectsGetByLookupsFunc([FromODataUri] object Lookups)
        {
            this.OnProjectsGetByLookupsDefaultParams(ref Lookups);

            var items = this.context.ProjectsGetByLookups.FromSqlRaw("EXEC [dbo].[ProjectsGetByLookups] @Lookups={0}", Lookups).ToList().AsQueryable();

            this.OnProjectsGetByLookupsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectsGetByLookupsDefaultParams(ref object Lookups);

        partial void OnProjectsGetByLookupsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectsGetByLookup> items);
    }
}
