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
    public partial class ReferenceWebSitesGetByUrlsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByUrlsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByUrlsFunc(Url={Url})")]
        public IActionResult ReferenceWebSitesGetByUrlsFunc([FromODataUri] string Url)
        {
            this.OnReferenceWebSitesGetByUrlsDefaultParams(ref Url);

            var items = this.context.ReferenceWebSitesGetByUrls.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByUrl] @Url={0}", Url).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByUrlsInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByUrlsDefaultParams(ref string Url);

        partial void OnReferenceWebSitesGetByUrlsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByUrl> items);
    }
}
