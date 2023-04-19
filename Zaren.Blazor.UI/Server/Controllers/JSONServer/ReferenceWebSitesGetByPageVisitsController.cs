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
    public partial class ReferenceWebSitesGetByPageVisitsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByPageVisitsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByPageVisitsFunc(PageVisit={PageVisit})")]
        public IActionResult ReferenceWebSitesGetByPageVisitsFunc([FromODataUri] string PageVisit)
        {
            this.OnReferenceWebSitesGetByPageVisitsDefaultParams(ref PageVisit);

            var items = this.context.ReferenceWebSitesGetByPageVisits.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByPageVisit] @PageVisit={0}", PageVisit).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByPageVisitsInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByPageVisitsDefaultParams(ref string PageVisit);

        partial void OnReferenceWebSitesGetByPageVisitsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByPageVisit> items);
    }
}
