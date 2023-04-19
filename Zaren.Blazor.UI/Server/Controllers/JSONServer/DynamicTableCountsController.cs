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
    public partial class DynamicTableCountsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DynamicTableCountsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DynamicTableCountsFunc()")]
        public IActionResult DynamicTableCountsFunc()
        {
            this.OnDynamicTableCountsDefaultParams();

            var items = this.context.DynamicTableCounts.FromSqlRaw("EXEC [dbo].[DynamicTableCount] ").ToList().AsQueryable();

            this.OnDynamicTableCountsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDynamicTableCountsDefaultParams();

        partial void OnDynamicTableCountsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DynamicTableCount> items);
    }
}
