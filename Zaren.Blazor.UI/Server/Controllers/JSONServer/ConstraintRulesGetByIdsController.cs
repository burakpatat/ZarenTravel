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
    public partial class ConstraintRulesGetByIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ConstraintRulesGetByIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ConstraintRulesGetByIdsFunc(Id={Id})")]
        public IActionResult ConstraintRulesGetByIdsFunc([FromODataUri] long? Id)
        {
            this.OnConstraintRulesGetByIdsDefaultParams(ref Id);

            var items = this.context.ConstraintRulesGetByIds.FromSqlRaw("EXEC [dbo].[ConstraintRulesGetByID] @Id={0}", Id).ToList().AsQueryable();

            this.OnConstraintRulesGetByIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnConstraintRulesGetByIdsDefaultParams(ref long? Id);

        partial void OnConstraintRulesGetByIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetById> items);
    }
}
