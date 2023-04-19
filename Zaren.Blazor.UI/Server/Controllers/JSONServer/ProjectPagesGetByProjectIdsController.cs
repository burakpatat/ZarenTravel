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
    public partial class ProjectPagesGetByProjectIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByProjectIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByProjectIdsFunc(ProjectId={ProjectId})")]
        public IActionResult ProjectPagesGetByProjectIdsFunc([FromODataUri] int? ProjectId)
        {
            this.OnProjectPagesGetByProjectIdsDefaultParams(ref ProjectId);

            var items = this.context.ProjectPagesGetByProjectIds.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByProjectId] @ProjectId={0}", ProjectId).ToList().AsQueryable();

            this.OnProjectPagesGetByProjectIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByProjectIdsDefaultParams(ref int? ProjectId);

        partial void OnProjectPagesGetByProjectIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByProjectId> items);
    }
}
