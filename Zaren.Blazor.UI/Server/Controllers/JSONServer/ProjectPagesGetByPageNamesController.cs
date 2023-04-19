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
    public partial class ProjectPagesGetByPageNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByPageNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByPageNamesFunc(PageName={PageName})")]
        public IActionResult ProjectPagesGetByPageNamesFunc([FromODataUri] string PageName)
        {
            this.OnProjectPagesGetByPageNamesDefaultParams(ref PageName);

            var items = this.context.ProjectPagesGetByPageNames.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByPageName] @PageName={0}", PageName).ToList().AsQueryable();

            this.OnProjectPagesGetByPageNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByPageNamesDefaultParams(ref string PageName);

        partial void OnProjectPagesGetByPageNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByPageName> items);
    }
}
