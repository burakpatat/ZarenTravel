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
    public partial class DynamicSpaceReportsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DynamicSpaceReportsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DynamicSpaceReportsFunc()")]
        public IActionResult DynamicSpaceReportsFunc()
        {
            this.OnDynamicSpaceReportsDefaultParams();

            var items = this.context.DynamicSpaceReports.FromSqlRaw("EXEC [dbo].[DynamicSpaceReport] ").ToList().AsQueryable();

            this.OnDynamicSpaceReportsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDynamicSpaceReportsDefaultParams();

        partial void OnDynamicSpaceReportsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DynamicSpaceReport> items);
    }
}
