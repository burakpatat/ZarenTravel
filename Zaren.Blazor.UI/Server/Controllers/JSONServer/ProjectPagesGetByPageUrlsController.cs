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
    public partial class ProjectPagesGetByPageUrlsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByPageUrlsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByPageUrlsFunc(PageUrl={PageUrl})")]
        public IActionResult ProjectPagesGetByPageUrlsFunc([FromODataUri] string PageUrl)
        {
            this.OnProjectPagesGetByPageUrlsDefaultParams(ref PageUrl);

            var items = this.context.ProjectPagesGetByPageUrls.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByPageUrl] @PageUrl={0}", PageUrl).ToList().AsQueryable();

            this.OnProjectPagesGetByPageUrlsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByPageUrlsDefaultParams(ref string PageUrl);

        partial void OnProjectPagesGetByPageUrlsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByPageUrl> items);
    }
}
