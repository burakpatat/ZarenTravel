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
    public partial class DynamicTableForeignKeysController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public DynamicTableForeignKeysController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/DynamicTableForeignKeysFunc()")]
        public IActionResult DynamicTableForeignKeysFunc()
        {
            this.OnDynamicTableForeignKeysDefaultParams();

            var items = this.context.DynamicTableForeignKeys.FromSqlRaw("EXEC [dbo].[DynamicTableForeignKeys] ").ToList().AsQueryable();

            this.OnDynamicTableForeignKeysInvoke(ref items);

            return Ok(items);
        }

        partial void OnDynamicTableForeignKeysDefaultParams();

        partial void OnDynamicTableForeignKeysInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.DynamicTableForeignKey> items);
    }
}
