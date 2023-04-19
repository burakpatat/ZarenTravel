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
    public partial class ReferenceWebSitesGetByIsLastPublishSuccessfulliesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByIsLastPublishSuccessfulliesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByIsLastPublishSuccessfulliesFunc(IsLastPublishSuccessfully={IsLastPublishSuccessfully})")]
        public IActionResult ReferenceWebSitesGetByIsLastPublishSuccessfulliesFunc([FromODataUri] bool? IsLastPublishSuccessfully)
        {
            this.OnReferenceWebSitesGetByIsLastPublishSuccessfulliesDefaultParams(ref IsLastPublishSuccessfully);

            var items = this.context.ReferenceWebSitesGetByIsLastPublishSuccessfullies.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByIsLastPublishSuccessfully] @IsLastPublishSuccessfully={0}", IsLastPublishSuccessfully).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByIsLastPublishSuccessfulliesInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByIsLastPublishSuccessfulliesDefaultParams(ref bool? IsLastPublishSuccessfully);

        partial void OnReferenceWebSitesGetByIsLastPublishSuccessfulliesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByIsLastPublishSuccessfully> items);
    }
}
