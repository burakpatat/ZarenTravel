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
    public partial class DynamicTableSearchAllsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DynamicTableSearchAllsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DynamicTableSearchAllsFunc(SearchStr={SearchStr})")]
        public IActionResult DynamicTableSearchAllsFunc([FromODataUri] string SearchStr)
        {
            this.OnDynamicTableSearchAllsDefaultParams(ref SearchStr);

            var items = this.context.DynamicTableSearchAlls.FromSqlRaw("EXEC [dbo].[DynamicTableSearchAll] @SearchStr={0}", SearchStr).ToList().AsQueryable();

            this.OnDynamicTableSearchAllsInvoke(ref items);

            return Ok(items);
        }

        partial void OnDynamicTableSearchAllsDefaultParams(ref string SearchStr);

        partial void OnDynamicTableSearchAllsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DynamicTableSearchAll> items);
    }
}
