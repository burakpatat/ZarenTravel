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
    public partial class ReferenceWebSitesGetBySiteNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetBySiteNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetBySiteNamesFunc(SiteName={SiteName})")]
        public IActionResult ReferenceWebSitesGetBySiteNamesFunc([FromODataUri] string SiteName)
        {
            this.OnReferenceWebSitesGetBySiteNamesDefaultParams(ref SiteName);

            var items = this.context.ReferenceWebSitesGetBySiteNames.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetBySiteName] @SiteName={0}", SiteName).ToList().AsQueryable();

            this.OnReferenceWebSitesGetBySiteNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetBySiteNamesDefaultParams(ref string SiteName);

        partial void OnReferenceWebSitesGetBySiteNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetBySiteName> items);
    }
}
