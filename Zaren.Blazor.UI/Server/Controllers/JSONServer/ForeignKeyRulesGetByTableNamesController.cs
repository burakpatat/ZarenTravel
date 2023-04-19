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
    public partial class ForeignKeyRulesGetByTableNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ForeignKeyRulesGetByTableNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ForeignKeyRulesGetByTableNamesFunc(TableName={TableName})")]
        public IActionResult ForeignKeyRulesGetByTableNamesFunc([FromODataUri] string TableName)
        {
            this.OnForeignKeyRulesGetByTableNamesDefaultParams(ref TableName);

            var items = this.context.ForeignKeyRulesGetByTableNames.FromSqlRaw("EXEC [dbo].[ForeignKeyRulesGetByTableName] @TableName={0}", TableName).ToList().AsQueryable();

            this.OnForeignKeyRulesGetByTableNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnForeignKeyRulesGetByTableNamesDefaultParams(ref string TableName);

        partial void OnForeignKeyRulesGetByTableNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByTableName> items);
    }
}
