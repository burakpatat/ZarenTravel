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
    public partial class ProjectPageComponentElementsGetByDocumentUrlsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsGetByDocumentUrlsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsGetByDocumentUrlsFunc(DocumentUrl={DocumentUrl})")]
        public IActionResult ProjectPageComponentElementsGetByDocumentUrlsFunc([FromODataUri] string DocumentUrl)
        {
            this.OnProjectPageComponentElementsGetByDocumentUrlsDefaultParams(ref DocumentUrl);

            var items = this.context.ProjectPageComponentElementsGetByDocumentUrls.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsGetByDocumentUrl] @DocumentUrl={0}", DocumentUrl).ToList().AsQueryable();

            this.OnProjectPageComponentElementsGetByDocumentUrlsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsGetByDocumentUrlsDefaultParams(ref string DocumentUrl);

        partial void OnProjectPageComponentElementsGetByDocumentUrlsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByDocumentUrl> items);
    }
}
