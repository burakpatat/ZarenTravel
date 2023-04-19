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
    public partial class ConstraintRulesGetByTableNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ConstraintRulesGetByTableNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ConstraintRulesGetByTableNamesFunc(TableName={TableName})")]
        public IActionResult ConstraintRulesGetByTableNamesFunc([FromODataUri] string TableName)
        {
            this.OnConstraintRulesGetByTableNamesDefaultParams(ref TableName);

            var items = this.context.ConstraintRulesGetByTableNames.FromSqlRaw("EXEC [dbo].[ConstraintRulesGetByTableName] @TableName={0}", TableName).ToList().AsQueryable();

            this.OnConstraintRulesGetByTableNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnConstraintRulesGetByTableNamesDefaultParams(ref string TableName);

        partial void OnConstraintRulesGetByTableNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByTableName> items);
    }
}
