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
    public partial class ReferenceWebSitesGetByRankingsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByRankingsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByRankingsFunc(Ranking={Ranking})")]
        public IActionResult ReferenceWebSitesGetByRankingsFunc([FromODataUri] int? Ranking)
        {
            this.OnReferenceWebSitesGetByRankingsDefaultParams(ref Ranking);

            var items = this.context.ReferenceWebSitesGetByRankings.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByRanking] @Ranking={0}", Ranking).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByRankingsInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByRankingsDefaultParams(ref int? Ranking);

        partial void OnReferenceWebSitesGetByRankingsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByRanking> items);
    }
}
