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
    public partial class ProjectPageComponentsGetByFormActionUrlsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsGetByFormActionUrlsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsGetByFormActionUrlsFunc(FormActionUrl={FormActionUrl})")]
        public IActionResult ProjectPageComponentsGetByFormActionUrlsFunc([FromODataUri] string FormActionUrl)
        {
            this.OnProjectPageComponentsGetByFormActionUrlsDefaultParams(ref FormActionUrl);

            var items = this.context.ProjectPageComponentsGetByFormActionUrls.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsGetByFormActionUrl] @FormActionUrl={0}", FormActionUrl).ToList().AsQueryable();

            this.OnProjectPageComponentsGetByFormActionUrlsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsGetByFormActionUrlsDefaultParams(ref string FormActionUrl);

        partial void OnProjectPageComponentsGetByFormActionUrlsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByFormActionUrl> items);
    }
}
