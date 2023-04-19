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
    public partial class ConstraintRulesInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ConstraintRulesInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ConstraintRulesInsertsFunc(Name={Name},Comment={Comment},CheckConstraint={CheckConstraint},AddWithCheck={AddWithCheck},AddWithNoCheck={AddWithNoCheck},ColumnId={ColumnId},TableName={TableName},ProjectName={ProjectName},TableId={TableId},ProjectId={ProjectId})")]
        public IActionResult ConstraintRulesInsertsFunc([FromODataUri] string Name, [FromODataUri] string Comment, [FromODataUri] string CheckConstraint, [FromODataUri] string AddWithCheck, [FromODataUri] string AddWithNoCheck, [FromODataUri] long? ColumnId, [FromODataUri] string TableName, [FromODataUri] string ProjectName, [FromODataUri] long? TableId, [FromODataUri] long? ProjectId)
        {
            this.OnConstraintRulesInsertsDefaultParams(ref Name, ref Comment, ref CheckConstraint, ref AddWithCheck, ref AddWithNoCheck, ref ColumnId, ref TableName, ref ProjectName, ref TableId, ref ProjectId);

            var items = this.context.ConstraintRulesInserts.FromSqlRaw("EXEC [dbo].[ConstraintRulesInsert] @Name={0}, @Comment={1}, @CheckConstraint={2}, @AddWithCheck={3}, @AddWithNoCheck={4}, @ColumnId={5}, @TableName={6}, @ProjectName={7}, @TableId={8}, @ProjectId={9}", Name, Comment, CheckConstraint, AddWithCheck, AddWithNoCheck, ColumnId, TableName, ProjectName, TableId, ProjectId).ToList().AsQueryable();

            this.OnConstraintRulesInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnConstraintRulesInsertsDefaultParams(ref string Name, ref string Comment, ref string CheckConstraint, ref string AddWithCheck, ref string AddWithNoCheck, ref long? ColumnId, ref string TableName, ref string ProjectName, ref long? TableId, ref long? ProjectId);

        partial void OnConstraintRulesInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ConstraintRulesInsert> items);
    }
}
