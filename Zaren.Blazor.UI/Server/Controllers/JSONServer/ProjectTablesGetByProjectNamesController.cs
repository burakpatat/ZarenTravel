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
    public partial class ProjectTablesGetByProjectNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesGetByProjectNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesGetByProjectNamesFunc(ProjectName={ProjectName})")]
        public IActionResult ProjectTablesGetByProjectNamesFunc([FromODataUri] string ProjectName)
        {
            this.OnProjectTablesGetByProjectNamesDefaultParams(ref ProjectName);

            var items = this.context.ProjectTablesGetByProjectNames.FromSqlRaw("EXEC [dbo].[ProjectTablesGetByProjectName] @ProjectName={0}", ProjectName).ToList().AsQueryable();

            this.OnProjectTablesGetByProjectNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesGetByProjectNamesDefaultParams(ref string ProjectName);

        partial void OnProjectTablesGetByProjectNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByProjectName> items);
    }
}
