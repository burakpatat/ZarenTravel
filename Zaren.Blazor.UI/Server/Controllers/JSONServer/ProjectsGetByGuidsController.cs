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
    public partial class ProjectsGetByGuidsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectsGetByGuidsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectsGetByGuidsFunc(Guid={Guid})")]
        public IActionResult ProjectsGetByGuidsFunc([FromODataUri] string Guid)
        {
            this.OnProjectsGetByGuidsDefaultParams(ref Guid);

            var items = this.context.ProjectsGetByGuids.FromSqlRaw("EXEC [dbo].[ProjectsGetByGuid] @Guid={0}", Guid).ToList().AsQueryable();

            this.OnProjectsGetByGuidsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectsGetByGuidsDefaultParams(ref string Guid);

        partial void OnProjectsGetByGuidsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectsGetByGuid> items);
    }
}
