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
    public partial class ProjectsGetByEndpointsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectsGetByEndpointsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectsGetByEndpointsFunc(Endpoints={Endpoints})")]
        public IActionResult ProjectsGetByEndpointsFunc([FromODataUri] object Endpoints)
        {
            this.OnProjectsGetByEndpointsDefaultParams(ref Endpoints);

            var items = this.context.ProjectsGetByEndpoints.FromSqlRaw("EXEC [dbo].[ProjectsGetByEndpoints] @Endpoints={0}", Endpoints).ToList().AsQueryable();

            this.OnProjectsGetByEndpointsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectsGetByEndpointsDefaultParams(ref object Endpoints);

        partial void OnProjectsGetByEndpointsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectsGetByEndpoint> items);
    }
}
