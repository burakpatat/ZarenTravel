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
    public partial class ProjectPageComponentElementsGetByApiRequestUrlsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByApiRequestUrlsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByApiRequestUrlsFunc(ApiRequestUrl={ApiRequestUrl})")]
        public IActionResult ProjectPageComponentElementsGetByApiRequestUrlsFunc([FromODataUri] string ApiRequestUrl)
        {
            this.OnProjectPageComponentElementsGetByApiRequestUrlsDefaultParams(ref ApiRequestUrl);

            var items = this.context.ProjectPageComponentElementsGetByApiRequestUrls.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByApiRequestUrl] @ApiRequestUrl={0}", ApiRequestUrl).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByApiRequestUrlsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByApiRequestUrlsDefaultParams(ref string ApiRequestUrl);

        partial void OnProjectPageComponentElementsGetByApiRequestUrlsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByApiRequestUrl> items);
    }
}
