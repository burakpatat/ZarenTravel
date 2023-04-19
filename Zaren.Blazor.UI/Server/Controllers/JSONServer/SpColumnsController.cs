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
    public partial class SpColumnsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public SpColumnsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/SpColumnsFunc(table_name={table_name},table_owner={table_owner},table_qualifier={table_qualifier},column_name={column_name},ODBCVer={ODBCVer})")]
        public IActionResult SpColumnsFunc([FromODataUri] string table_name, [FromODataUri] string table_owner, [FromODataUri] string table_qualifier, [FromODataUri] string column_name, [FromODataUri] int? ODBCVer)
        {
            this.OnSpColumnsDefaultParams(ref table_name, ref table_owner, ref table_qualifier, ref column_name, ref ODBCVer);

            var items = this.context.SpColumns.FromSqlRaw("EXEC [dbo].[sp_columns] @table_name={0}, @table_owner={1}, @table_qualifier={2}, @column_name={3}, @ODBCVer={4}", table_name, table_owner, table_qualifier, column_name, ODBCVer).ToList().AsQueryable();

            this.OnSpColumnsInvoke(ref items);

            return Ok(items);
        }

        partial void OnSpColumnsDefaultParams(ref string table_name, ref string table_owner, ref string table_qualifier, ref string column_name, ref int? ODBCVer);

        partial void OnSpColumnsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.SpColumn> items);
    }
}
