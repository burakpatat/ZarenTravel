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
    public partial class ReferenceWebSitesGetByCreatedDatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesGetByCreatedDatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesGetByCreatedDatesFunc(CreatedDate={CreatedDate})")]
        public IActionResult ReferenceWebSitesGetByCreatedDatesFunc([FromODataUri] string CreatedDate)
        {
            this.OnReferenceWebSitesGetByCreatedDatesDefaultParams(ref CreatedDate);

            var items = this.context.ReferenceWebSitesGetByCreatedDates.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesGetByCreatedDate] @CreatedDate={0}", CreatedDate).ToList().AsQueryable();

            this.OnReferenceWebSitesGetByCreatedDatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesGetByCreatedDatesDefaultParams(ref string CreatedDate);

        partial void OnReferenceWebSitesGetByCreatedDatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByCreatedDate> items);
    }
}
