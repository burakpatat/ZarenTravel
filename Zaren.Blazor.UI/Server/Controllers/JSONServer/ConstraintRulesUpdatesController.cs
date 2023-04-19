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
    public partial class ConstraintRulesUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ConstraintRulesUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ConstraintRulesUpdatesFunc(Id={Id},Name={Name},Comment={Comment},CheckConstraint={CheckConstraint},AddWithCheck={AddWithCheck},AddWithNoCheck={AddWithNoCheck},ColumnId={ColumnId},TableName={TableName},ProjectName={ProjectName},TableId={TableId},ProjectId={ProjectId})")]
        public IActionResult ConstraintRulesUpdatesFunc([FromODataUri] long? Id, [FromODataUri] string Name, [FromODataUri] string Comment, [FromODataUri] string CheckConstraint, [FromODataUri] string AddWithCheck, [FromODataUri] string AddWithNoCheck, [FromODataUri] long? ColumnId, [FromODataUri] string TableName, [FromODataUri] string ProjectName, [FromODataUri] long? TableId, [FromODataUri] long? ProjectId)
        {
            this.OnConstraintRulesUpdatesDefaultParams(ref Id, ref Name, ref Comment, ref CheckConstraint, ref AddWithCheck, ref AddWithNoCheck, ref ColumnId, ref TableName, ref ProjectName, ref TableId, ref ProjectId);

            var items = this.context.ConstraintRulesUpdates.FromSqlRaw("EXEC [dbo].[ConstraintRulesUpdate] @Id={0}, @Name={1}, @Comment={2}, @CheckConstraint={3}, @AddWithCheck={4}, @AddWithNoCheck={5}, @ColumnId={6}, @TableName={7}, @ProjectName={8}, @TableId={9}, @ProjectId={10}", Id, Name, Comment, CheckConstraint, AddWithCheck, AddWithNoCheck, ColumnId, TableName, ProjectName, TableId, ProjectId).ToList().AsQueryable();

            this.OnConstraintRulesUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnConstraintRulesUpdatesDefaultParams(ref long? Id, ref string Name, ref string Comment, ref string CheckConstraint, ref string AddWithCheck, ref string AddWithNoCheck, ref long? ColumnId, ref string TableName, ref string ProjectName, ref long? TableId, ref long? ProjectId);

        partial void OnConstraintRulesUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ConstraintRulesUpdate> items);
    }
}
