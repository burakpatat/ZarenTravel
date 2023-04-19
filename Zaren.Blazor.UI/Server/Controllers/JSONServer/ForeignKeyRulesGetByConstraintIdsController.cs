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
    public partial class ForeignKeyRulesGetByConstraintIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ForeignKeyRulesGetByConstraintIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ForeignKeyRulesGetByConstraintIdsFunc(ConstraintId={ConstraintId})")]
        public IActionResult ForeignKeyRulesGetByConstraintIdsFunc([FromODataUri] long? ConstraintId)
        {
            this.OnForeignKeyRulesGetByConstraintIdsDefaultParams(ref ConstraintId);

            var items = this.context.ForeignKeyRulesGetByConstraintIds.FromSqlRaw("EXEC [dbo].[ForeignKeyRulesGetByConstraintId] @ConstraintId={0}", ConstraintId).ToList().AsQueryable();

            this.OnForeignKeyRulesGetByConstraintIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnForeignKeyRulesGetByConstraintIdsDefaultParams(ref long? ConstraintId);

        partial void OnForeignKeyRulesGetByConstraintIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByConstraintId> items);
    }
}
