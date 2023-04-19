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
    public partial class ProjectPagesGetByUserIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByUserIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByUserIdsFunc(UserId={UserId})")]
        public IActionResult ProjectPagesGetByUserIdsFunc([FromODataUri] int? UserId)
        {
            this.OnProjectPagesGetByUserIdsDefaultParams(ref UserId);

            var items = this.context.ProjectPagesGetByUserIds.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByUserId] @UserId={0}", UserId).ToList().AsQueryable();

            this.OnProjectPagesGetByUserIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByUserIdsDefaultParams(ref int? UserId);

        partial void OnProjectPagesGetByUserIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByUserId> items);
    }
}
