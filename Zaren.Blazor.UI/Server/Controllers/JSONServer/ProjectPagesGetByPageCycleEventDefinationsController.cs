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
    public partial class ProjectPagesGetByPageCycleEventDefinationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByPageCycleEventDefinationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByPageCycleEventDefinationsFunc(PageCycleEventDefination={PageCycleEventDefination})")]
        public IActionResult ProjectPagesGetByPageCycleEventDefinationsFunc([FromODataUri] string PageCycleEventDefination)
        {
            this.OnProjectPagesGetByPageCycleEventDefinationsDefaultParams(ref PageCycleEventDefination);

            var items = this.context.ProjectPagesGetByPageCycleEventDefinations.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByPageCycleEventDefination] @PageCycleEventDefination={0}", PageCycleEventDefination).ToList().AsQueryable();

            this.OnProjectPagesGetByPageCycleEventDefinationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByPageCycleEventDefinationsDefaultParams(ref string PageCycleEventDefination);

        partial void OnProjectPagesGetByPageCycleEventDefinationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByPageCycleEventDefination> items);
    }
}
