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
    public partial class ForeignKeyRulesGetByColumnNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ForeignKeyRulesGetByColumnNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ForeignKeyRulesGetByColumnNamesFunc(ColumnName={ColumnName})")]
        public IActionResult ForeignKeyRulesGetByColumnNamesFunc([FromODataUri] string ColumnName)
        {
            this.OnForeignKeyRulesGetByColumnNamesDefaultParams(ref ColumnName);

            var items = this.context.ForeignKeyRulesGetByColumnNames.FromSqlRaw("EXEC [dbo].[ForeignKeyRulesGetByColumnName] @ColumnName={0}", ColumnName).ToList().AsQueryable();

            this.OnForeignKeyRulesGetByColumnNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnForeignKeyRulesGetByColumnNamesDefaultParams(ref string ColumnName);

        partial void OnForeignKeyRulesGetByColumnNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByColumnName> items);
    }
}
