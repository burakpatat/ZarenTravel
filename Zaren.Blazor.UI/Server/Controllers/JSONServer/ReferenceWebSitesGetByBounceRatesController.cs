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
    public partial class ReferenceWebSitesGetByBounceRatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByBounceRatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByBounceRatesFunc(BounceRate={BounceRate})")]
        public IActionResult ReferenceWebSitesGetByBounceRatesFunc([FromODataUri] string BounceRate)
        {
            this.OnReferenceWebSitesGetByBounceRatesDefaultParams(ref BounceRate);

            var items = this.context.ReferenceWebSitesGetByBounceRates.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByBounceRate] @BounceRate={0}", BounceRate).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByBounceRatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByBounceRatesDefaultParams(ref string BounceRate);

        partial void OnReferenceWebSitesGetByBounceRatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByBounceRate> items);
    }
}
