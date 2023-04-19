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
    public partial class ConstraintRulesGetByAddWithChecksController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ConstraintRulesGetByAddWithChecksController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ConstraintRulesGetByAddWithChecksFunc(AddWithCheck={AddWithCheck})")]
        public IActionResult ConstraintRulesGetByAddWithChecksFunc([FromODataUri] string AddWithCheck)
        {
            this.OnConstraintRulesGetByAddWithChecksDefaultParams(ref AddWithCheck);

            var items = this.context.ConstraintRulesGetByAddWithChecks.FromSqlRaw("EXEC [dbo].[ConstraintRulesGetByAddWithCheck] @AddWithCheck={0}", AddWithCheck).ToList().AsQueryable();

            this.OnConstraintRulesGetByAddWithChecksInvoke(ref items);

            return Ok(items);
        }

        partial void OnConstraintRulesGetByAddWithChecksDefaultParams(ref string AddWithCheck);

        partial void OnConstraintRulesGetByAddWithChecksInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByAddWithCheck> items);
    }
}
