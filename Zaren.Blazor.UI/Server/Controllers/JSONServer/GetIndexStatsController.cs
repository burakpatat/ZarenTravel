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
    public partial class GetIndexStatsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public GetIndexStatsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/GetIndexStatsFunc(table_name={table_name})")]
        public IActionResult GetIndexStatsFunc([FromODataUri] string table_name)
        {
            this.OnGetIndexStatsDefaultParams(ref table_name);

            var items = this.context.GetIndexStats.FromSqlRaw("EXEC [dbo].[GetIndexStats] @table_name={0}", table_name).ToList().AsQueryable();

            this.OnGetIndexStatsInvoke(ref items);

            return Ok(items);
        }

        partial void OnGetIndexStatsDefaultParams(ref string table_name);

        partial void OnGetIndexStatsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.GetIndexStat> items);
    }
}
