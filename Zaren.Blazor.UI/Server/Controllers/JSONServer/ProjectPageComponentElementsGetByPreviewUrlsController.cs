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
    public partial class ProjectPageComponentElementsGetByPreviewUrlsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByPreviewUrlsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByPreviewUrlsFunc(PreviewUrl={PreviewUrl})")]
        public IActionResult ProjectPageComponentElementsGetByPreviewUrlsFunc([FromODataUri] string PreviewUrl)
        {
            this.OnProjectPageComponentElementsGetByPreviewUrlsDefaultParams(ref PreviewUrl);

            var items = this.context.ProjectPageComponentElementsGetByPreviewUrls.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByPreviewUrl] @PreviewUrl={0}", PreviewUrl).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByPreviewUrlsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByPreviewUrlsDefaultParams(ref string PreviewUrl);

        partial void OnProjectPageComponentElementsGetByPreviewUrlsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByPreviewUrl> items);
    }
}
