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
    public partial class ProjectPagesGetByCommissionsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByCommissionsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByCommissionsFunc(Commission={Commission})")]
        public IActionResult ProjectPagesGetByCommissionsFunc([FromODataUri] decimal? Commission)
        {
            this.OnProjectPagesGetByCommissionsDefaultParams(ref Commission);

            var items = this.context.ProjectPagesGetByCommissions.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByCommission] @Commission={0}", Commission).ToList().AsQueryable();

            this.OnProjectPagesGetByCommissionsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByCommissionsDefaultParams(ref decimal? Commission);

        partial void OnProjectPagesGetByCommissionsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByCommission> items);
    }
}
