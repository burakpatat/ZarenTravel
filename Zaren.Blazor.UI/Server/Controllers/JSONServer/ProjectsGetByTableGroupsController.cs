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
    public partial class ProjectsGetByTableGroupsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectsGetByTableGroupsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectsGetByTableGroupsFunc(TableGroups={TableGroups})")]
        public IActionResult ProjectsGetByTableGroupsFunc([FromODataUri] object TableGroups)
        {
            this.OnProjectsGetByTableGroupsDefaultParams(ref TableGroups);

            var items = this.context.ProjectsGetByTableGroups.FromSqlRaw("EXEC [dbo].[ProjectsGetByTableGroups] @TableGroups={0}", TableGroups).ToList().AsQueryable();

            this.OnProjectsGetByTableGroupsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectsGetByTableGroupsDefaultParams(ref object TableGroups);

        partial void OnProjectsGetByTableGroupsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectsGetByTableGroup> items);
    }
}
