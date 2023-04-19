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
    public partial class ProjectPagesGetByRoutesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByRoutesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByRoutesFunc(Route={Route})")]
        public IActionResult ProjectPagesGetByRoutesFunc([FromODataUri] string Route)
        {
            this.OnProjectPagesGetByRoutesDefaultParams(ref Route);

            var items = this.context.ProjectPagesGetByRoutes.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByRoute] @Route={0}", Route).ToList().AsQueryable();

            this.OnProjectPagesGetByRoutesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByRoutesDefaultParams(ref string Route);

        partial void OnProjectPagesGetByRoutesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByRoute> items);
    }
}
