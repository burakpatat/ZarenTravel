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
    public partial class ReferenceWebSitesGetByUserIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByUserIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByUserIdsFunc(UserId={UserId})")]
        public IActionResult ReferenceWebSitesGetByUserIdsFunc([FromODataUri] int? UserId)
        {
            this.OnReferenceWebSitesGetByUserIdsDefaultParams(ref UserId);

            var items = this.context.ReferenceWebSitesGetByUserIds.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByUserId] @UserId={0}", UserId).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByUserIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByUserIdsDefaultParams(ref int? UserId);

        partial void OnReferenceWebSitesGetByUserIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByUserId> items);
    }
}
