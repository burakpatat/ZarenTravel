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
    public partial class ProjectPagesGetByReferralUrlsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesGetByReferralUrlsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesGetByReferralUrlsFunc(ReferralUrl={ReferralUrl})")]
        public IActionResult ProjectPagesGetByReferralUrlsFunc([FromODataUri] string ReferralUrl)
        {
            this.OnProjectPagesGetByReferralUrlsDefaultParams(ref ReferralUrl);

            var items = this.context.ProjectPagesGetByReferralUrls.FromSqlRaw("EXEC [dbo].[ProjectPagesGetByReferralUrl] @ReferralUrl={0}", ReferralUrl).ToList().AsQueryable();

            this.OnProjectPagesGetByReferralUrlsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesGetByReferralUrlsDefaultParams(ref string ReferralUrl);

        partial void OnProjectPagesGetByReferralUrlsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByReferralUrl> items);
    }
}
