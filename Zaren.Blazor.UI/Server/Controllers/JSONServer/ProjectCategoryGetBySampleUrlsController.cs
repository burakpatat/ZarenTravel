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
    public partial class ProjectCategoryGetBySampleUrlsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectCategoryGetBySampleUrlsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectCategoryGetBySampleUrlsFunc(SampleUrl={SampleUrl})")]
        public IActionResult ProjectCategoryGetBySampleUrlsFunc([FromODataUri] string SampleUrl)
        {
            this.OnProjectCategoryGetBySampleUrlsDefaultParams(ref SampleUrl);

            var items = this.context.ProjectCategoryGetBySampleUrls.FromSqlRaw("EXEC [dbo].[ProjectCategoryGetBySampleUrl] @SampleUrl={0}", SampleUrl).ToList().AsQueryable();

            this.OnProjectCategoryGetBySampleUrlsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectCategoryGetBySampleUrlsDefaultParams(ref string SampleUrl);

        partial void OnProjectCategoryGetBySampleUrlsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetBySampleUrl> items);
    }
}
