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
    public partial class ProjectsGetByUserIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectsGetByUserIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectsGetByUserIdsFunc(UserId={UserId})")]
        public IActionResult ProjectsGetByUserIdsFunc([FromODataUri] int? UserId)
        {
            this.OnProjectsGetByUserIdsDefaultParams(ref UserId);

            var items = this.context.ProjectsGetByUserIds.FromSqlRaw("EXEC [dbo].[ProjectsGetByUserId] @UserId={0}", UserId).ToList().AsQueryable();

            this.OnProjectsGetByUserIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectsGetByUserIdsDefaultParams(ref int? UserId);

        partial void OnProjectsGetByUserIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectsGetByUserId> items);
    }
}
