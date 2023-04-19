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
    public partial class ProjectPagesGetAllsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetAllsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetAllsFunc()")]
        public IActionResult ProjectPagesGetAllsFunc()
        {
            this.OnProjectPagesGetAllsDefaultParams();

            var items = this.context.ProjectPagesGetAlls.FromSqlRaw("EXEC [dbo].[ProjectPagesGetAll] ").ToList().AsQueryable();

            this.OnProjectPagesGetAllsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetAllsDefaultParams();

        partial void OnProjectPagesGetAllsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetAll> items);
    }
}
