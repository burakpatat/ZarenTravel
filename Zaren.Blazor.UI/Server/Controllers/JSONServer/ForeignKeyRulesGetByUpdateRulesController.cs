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
    public partial class ForeignKeyRulesGetByUpdateRulesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ForeignKeyRulesGetByUpdateRulesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ForeignKeyRulesGetByUpdateRulesFunc(UpdateRule={UpdateRule})")]
        public IActionResult ForeignKeyRulesGetByUpdateRulesFunc([FromODataUri] int? UpdateRule)
        {
            this.OnForeignKeyRulesGetByUpdateRulesDefaultParams(ref UpdateRule);

            var items = this.context.ForeignKeyRulesGetByUpdateRules.FromSqlRaw("EXEC [dbo].[ForeignKeyRulesGetByUpdateRule] @UpdateRule={0}", UpdateRule).ToList().AsQueryable();

            this.OnForeignKeyRulesGetByUpdateRulesInvoke(ref items);

            return Ok(items);
        }

        partial void OnForeignKeyRulesGetByUpdateRulesDefaultParams(ref int? UpdateRule);

        partial void OnForeignKeyRulesGetByUpdateRulesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByUpdateRule> items);
    }
}
