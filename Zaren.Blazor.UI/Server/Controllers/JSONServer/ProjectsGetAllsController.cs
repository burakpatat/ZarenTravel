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
    public partial class ProjectsGetAllsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectsGetAllsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectsGetAllsFunc()")]
        public IActionResult ProjectsGetAllsFunc()
        {
            this.OnProjectsGetAllsDefaultParams();

            var items = this.context.ProjectsGetAlls.FromSqlRaw("EXEC [dbo].[ProjectsGetAll] ").ToList().AsQueryable();

            this.OnProjectsGetAllsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectsGetAllsDefaultParams();

        partial void OnProjectsGetAllsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectsGetAll> items);
    }
}
