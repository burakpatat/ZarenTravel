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
    public partial class ConstraintRulesGetByProjectIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ConstraintRulesGetByProjectIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ConstraintRulesGetByProjectIdsFunc(ProjectId={ProjectId})")]
        public IActionResult ConstraintRulesGetByProjectIdsFunc([FromODataUri] long? ProjectId)
        {
            this.OnConstraintRulesGetByProjectIdsDefaultParams(ref ProjectId);

            var items = this.context.ConstraintRulesGetByProjectIds.FromSqlRaw("EXEC [dbo].[ConstraintRulesGetByProjectId] @ProjectId={0}", ProjectId).ToList().AsQueryable();

            this.OnConstraintRulesGetByProjectIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnConstraintRulesGetByProjectIdsDefaultParams(ref long? ProjectId);

        partial void OnConstraintRulesGetByProjectIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByProjectId> items);
    }
}
