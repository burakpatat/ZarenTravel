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
    public partial class ForeignKeyRulesGetByTableIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ForeignKeyRulesGetByTableIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ForeignKeyRulesGetByTableIdsFunc(TableId={TableId})")]
        public IActionResult ForeignKeyRulesGetByTableIdsFunc([FromODataUri] long? TableId)
        {
            this.OnForeignKeyRulesGetByTableIdsDefaultParams(ref TableId);

            var items = this.context.ForeignKeyRulesGetByTableIds.FromSqlRaw("EXEC [dbo].[ForeignKeyRulesGetByTableId] @TableId={0}", TableId).ToList().AsQueryable();

            this.OnForeignKeyRulesGetByTableIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnForeignKeyRulesGetByTableIdsDefaultParams(ref long? TableId);

        partial void OnForeignKeyRulesGetByTableIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByTableId> items);
    }
}
