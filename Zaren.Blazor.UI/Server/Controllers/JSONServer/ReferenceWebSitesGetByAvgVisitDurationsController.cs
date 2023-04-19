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
    public partial class ReferenceWebSitesGetByAvgVisitDurationsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByAvgVisitDurationsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByAvgVisitDurationsFunc(AvgVisitDuration={AvgVisitDuration})")]
        public IActionResult ReferenceWebSitesGetByAvgVisitDurationsFunc([FromODataUri] string AvgVisitDuration)
        {
            this.OnReferenceWebSitesGetByAvgVisitDurationsDefaultParams(ref AvgVisitDuration);

            var items = this.context.ReferenceWebSitesGetByAvgVisitDurations.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByAvgVisitDuration] @AvgVisitDuration={0}", AvgVisitDuration).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByAvgVisitDurationsInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByAvgVisitDurationsDefaultParams(ref string AvgVisitDuration);

        partial void OnReferenceWebSitesGetByAvgVisitDurationsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByAvgVisitDuration> items);
    }
}
