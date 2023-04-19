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
    public partial class ProjectsGetByNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectsGetByNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectsGetByNamesFunc(Name={Name})")]
        public IActionResult ProjectsGetByNamesFunc([FromODataUri] string Name)
        {
            this.OnProjectsGetByNamesDefaultParams(ref Name);

            var items = this.context.ProjectsGetByNames.FromSqlRaw("EXEC [dbo].[ProjectsGetByName] @Name={0}", Name).ToList().AsQueryable();

            this.OnProjectsGetByNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectsGetByNamesDefaultParams(ref string Name);

        partial void OnProjectsGetByNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectsGetByName> items);
    }
}
