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
    public partial class ConstraintRulesGetByNamesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ConstraintRulesGetByNamesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ConstraintRulesGetByNamesFunc(Name={Name})")]
        public IActionResult ConstraintRulesGetByNamesFunc([FromODataUri] string Name)
        {
            this.OnConstraintRulesGetByNamesDefaultParams(ref Name);

            var items = this.context.ConstraintRulesGetByNames.FromSqlRaw("EXEC [dbo].[ConstraintRulesGetByName] @Name={0}", Name).ToList().AsQueryable();

            this.OnConstraintRulesGetByNamesInvoke(ref items);

            return Ok(items);
        }

        partial void OnConstraintRulesGetByNamesDefaultParams(ref string Name);

        partial void OnConstraintRulesGetByNamesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByName> items);
    }
}
