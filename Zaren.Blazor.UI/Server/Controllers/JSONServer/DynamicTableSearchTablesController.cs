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
    public partial class DynamicTableSearchTablesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DynamicTableSearchTablesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DynamicTableSearchTablesFunc(SearchStr={SearchStr},TableName={TableName})")]
        public IActionResult DynamicTableSearchTablesFunc([FromODataUri] string SearchStr, [FromODataUri] string TableName)
        {
            this.OnDynamicTableSearchTablesDefaultParams(ref SearchStr, ref TableName);

            var items = this.context.DynamicTableSearchTables.FromSqlRaw("EXEC [dbo].[DynamicTableSearchTable] @SearchStr={0}, @TableName={1}", SearchStr, TableName).ToList().AsQueryable();

            this.OnDynamicTableSearchTablesInvoke(ref items);

            return Ok(items);
        }

        partial void OnDynamicTableSearchTablesDefaultParams(ref string SearchStr, ref string TableName);

        partial void OnDynamicTableSearchTablesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DynamicTableSearchTable> items);
    }
}
