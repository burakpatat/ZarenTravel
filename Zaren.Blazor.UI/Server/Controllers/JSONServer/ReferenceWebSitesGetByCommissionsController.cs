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
    public partial class ReferenceWebSitesGetByCommissionsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByCommissionsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByCommissionsFunc(Commission={Commission})")]
        public IActionResult ReferenceWebSitesGetByCommissionsFunc([FromODataUri] decimal? Commission)
        {
            this.OnReferenceWebSitesGetByCommissionsDefaultParams(ref Commission);

            var items = this.context.ReferenceWebSitesGetByCommissions.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByCommission] @Commission={0}", Commission).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByCommissionsInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByCommissionsDefaultParams(ref decimal? Commission);

        partial void OnReferenceWebSitesGetByCommissionsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByCommission> items);
    }
}
