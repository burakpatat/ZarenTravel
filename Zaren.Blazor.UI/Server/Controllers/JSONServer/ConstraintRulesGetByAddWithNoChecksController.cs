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
    public partial class ConstraintRulesGetByAddWithNoChecksController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ConstraintRulesGetByAddWithNoChecksController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ConstraintRulesGetByAddWithNoChecksFunc(AddWithNoCheck={AddWithNoCheck})")]
        public IActionResult ConstraintRulesGetByAddWithNoChecksFunc([FromODataUri] string AddWithNoCheck)
        {
            this.OnConstraintRulesGetByAddWithNoChecksDefaultParams(ref AddWithNoCheck);

            var items = this.context.ConstraintRulesGetByAddWithNoChecks.FromSqlRaw("EXEC [dbo].[ConstraintRulesGetByAddWithNoCheck] @AddWithNoCheck={0}", AddWithNoCheck).ToList().AsQueryable();

            this.OnConstraintRulesGetByAddWithNoChecksInvoke(ref items);

            return Ok(items);
        }

        partial void OnConstraintRulesGetByAddWithNoChecksDefaultParams(ref string AddWithNoCheck);

        partial void OnConstraintRulesGetByAddWithNoChecksInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByAddWithNoCheck> items);
    }
}
