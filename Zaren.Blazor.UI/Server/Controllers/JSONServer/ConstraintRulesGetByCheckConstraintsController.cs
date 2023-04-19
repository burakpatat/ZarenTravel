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
    public partial class ConstraintRulesGetByCheckConstraintsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ConstraintRulesGetByCheckConstraintsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ConstraintRulesGetByCheckConstraintsFunc(CheckConstraint={CheckConstraint})")]
        public IActionResult ConstraintRulesGetByCheckConstraintsFunc([FromODataUri] string CheckConstraint)
        {
            this.OnConstraintRulesGetByCheckConstraintsDefaultParams(ref CheckConstraint);

            var items = this.context.ConstraintRulesGetByCheckConstraints.FromSqlRaw("EXEC [dbo].[ConstraintRulesGetByCheckConstraint] @CheckConstraint={0}", CheckConstraint).ToList().AsQueryable();

            this.OnConstraintRulesGetByCheckConstraintsInvoke(ref items);

            return Ok(items);
        }

        partial void OnConstraintRulesGetByCheckConstraintsDefaultParams(ref string CheckConstraint);

        partial void OnConstraintRulesGetByCheckConstraintsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByCheckConstraint> items);
    }
}
