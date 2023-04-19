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
    public partial class ForeignKeyRulesGetByProjectIdsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ForeignKeyRulesGetByProjectIdsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ForeignKeyRulesGetByProjectIdsFunc(ProjectId={ProjectId})")]
        public IActionResult ForeignKeyRulesGetByProjectIdsFunc([FromODataUri] long? ProjectId)
        {
            this.OnForeignKeyRulesGetByProjectIdsDefaultParams(ref ProjectId);

            var items = this.context.ForeignKeyRulesGetByProjectIds.FromSqlRaw("EXEC [dbo].[ForeignKeyRulesGetByProjectId] @ProjectId={0}", ProjectId).ToList().AsQueryable();

            this.OnForeignKeyRulesGetByProjectIdsInvoke(ref items);

            return Ok(items);
        }

        partial void OnForeignKeyRulesGetByProjectIdsDefaultParams(ref long? ProjectId);

        partial void OnForeignKeyRulesGetByProjectIdsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByProjectId> items);
    }
}
