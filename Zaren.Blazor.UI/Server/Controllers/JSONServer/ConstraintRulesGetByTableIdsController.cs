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
    public partial class ConstraintRulesGetByTableIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ConstraintRulesGetByTableIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ConstraintRulesGetByTableIdsFunc(TableId={TableId})")]
        public IActionResult ConstraintRulesGetByTableIdsFunc([FromODataUri] long? TableId)
        {
            this.OnConstraintRulesGetByTableIdsDefaultParams(ref TableId);

            var items = this.context.ConstraintRulesGetByTableIds.FromSqlRaw("EXEC [dbo].[ConstraintRulesGetByTableId] @TableId={0}", TableId).ToList().AsQueryable();

            this.OnConstraintRulesGetByTableIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnConstraintRulesGetByTableIdsDefaultParams(ref long? TableId);

        partial void OnConstraintRulesGetByTableIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByTableId> items);
    }
}
