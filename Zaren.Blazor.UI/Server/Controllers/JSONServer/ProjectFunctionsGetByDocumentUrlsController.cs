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
    public partial class ProjectFunctionsGetByDocumentUrlsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectFunctionsGetByDocumentUrlsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectFunctionsGetByDocumentUrlsFunc(DocumentUrl={DocumentUrl})")]
        public IActionResult ProjectFunctionsGetByDocumentUrlsFunc([FromODataUri] string DocumentUrl)
        {
            this.OnProjectFunctionsGetByDocumentUrlsDefaultParams(ref DocumentUrl);

            var items = this.context.ProjectFunctionsGetByDocumentUrls.FromSqlRaw("EXEC [dbo].[ProjectFunctionsGetByDocumentUrl] @DocumentUrl={0}", DocumentUrl).ToList().AsQueryable();

            this.OnProjectFunctionsGetByDocumentUrlsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectFunctionsGetByDocumentUrlsDefaultParams(ref string DocumentUrl);

        partial void OnProjectFunctionsGetByDocumentUrlsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByDocumentUrl> items);
    }
}
