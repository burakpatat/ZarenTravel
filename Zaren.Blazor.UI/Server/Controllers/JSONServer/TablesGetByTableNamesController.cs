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
    public partial class TablesGetByTableNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public TablesGetByTableNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/TablesGetByTableNamesFunc(TableName={TableName})")]
        public IActionResult TablesGetByTableNamesFunc([FromODataUri] string TableName)
        {
            this.OnTablesGetByTableNamesDefaultParams(ref TableName);

            var items = this.context.TablesGetByTableNames.FromSqlRaw("EXEC [dbo].[TablesGetByTableName] @TableName={0}", TableName).ToList().AsQueryable();

            this.OnTablesGetByTableNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnTablesGetByTableNamesDefaultParams(ref string TableName);

        partial void OnTablesGetByTableNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.TablesGetByTableName> items);
    }
}
