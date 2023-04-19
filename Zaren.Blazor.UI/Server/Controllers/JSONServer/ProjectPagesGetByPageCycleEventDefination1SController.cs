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
    public partial class ProjectPagesGetByPageCycleEventDefination1SController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByPageCycleEventDefination1SController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByPageCycleEventDefination1SFunc(PageCycleEventDefination1={PageCycleEventDefination1})")]
        public IActionResult ProjectPagesGetByPageCycleEventDefination1SFunc([FromODataUri] string PageCycleEventDefination1)
        {
            this.OnProjectPagesGetByPageCycleEventDefination1SDefaultParams(ref PageCycleEventDefination1);

            var items = this.context.ProjectPagesGetByPageCycleEventDefination1S.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByPageCycleEventDefination1] @PageCycleEventDefination1={0}", PageCycleEventDefination1).ToList().AsQueryable();

            this.OnProjectPagesGetByPageCycleEventDefination1SInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByPageCycleEventDefination1SDefaultParams(ref string PageCycleEventDefination1);

        partial void OnProjectPagesGetByPageCycleEventDefination1SInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByPageCycleEventDefination1> items);
    }
}
