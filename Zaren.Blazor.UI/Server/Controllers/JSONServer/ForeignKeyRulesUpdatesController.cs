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
    public partial class ForeignKeyRulesUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ForeignKeyRulesUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ForeignKeyRulesUpdatesFunc(Id={Id},ColumnName={ColumnName},ReferencedTableName={ReferencedTableName},ReferencedColumnName={ReferencedColumnName},ReferencedColumnDbTypeCompare={ReferencedColumnDbTypeCompare},DeleteRule={DeleteRule},UpdateRule={UpdateRule},TableName={TableName},ProjectName={ProjectName},ConstraintId={ConstraintId},ColumnId={ColumnId},ProjectId={ProjectId},TableId={TableId})")]
        public IActionResult ForeignKeyRulesUpdatesFunc([FromODataUri] long? Id, [FromODataUri] string ColumnName, [FromODataUri] string ReferencedTableName, [FromODataUri] string ReferencedColumnName, [FromODataUri] string ReferencedColumnDbTypeCompare, [FromODataUri] int? DeleteRule, [FromODataUri] int? UpdateRule, [FromODataUri] string TableName, [FromODataUri] string ProjectName, [FromODataUri] long? ConstraintId, [FromODataUri] long? ColumnId, [FromODataUri] long? ProjectId, [FromODataUri] long? TableId)
        {
            this.OnForeignKeyRulesUpdatesDefaultParams(ref Id, ref ColumnName, ref ReferencedTableName, ref ReferencedColumnName, ref ReferencedColumnDbTypeCompare, ref DeleteRule, ref UpdateRule, ref TableName, ref ProjectName, ref ConstraintId, ref ColumnId, ref ProjectId, ref TableId);

            var items = this.context.ForeignKeyRulesUpdates.FromSqlRaw("EXEC [dbo].[ForeignKeyRulesUpdate] @Id={0}, @ColumnName={1}, @ReferencedTableName={2}, @ReferencedColumnName={3}, @ReferencedColumnDbTypeCompare={4}, @DeleteRule={5}, @UpdateRule={6}, @TableName={7}, @ProjectName={8}, @ConstraintId={9}, @ColumnId={10}, @ProjectId={11}, @TableId={12}", Id, ColumnName, ReferencedTableName, ReferencedColumnName, ReferencedColumnDbTypeCompare, DeleteRule, UpdateRule, TableName, ProjectName, ConstraintId, ColumnId, ProjectId, TableId).ToList().AsQueryable();

            this.OnForeignKeyRulesUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnForeignKeyRulesUpdatesDefaultParams(ref long? Id, ref string ColumnName, ref string ReferencedTableName, ref string ReferencedColumnName, ref string ReferencedColumnDbTypeCompare, ref int? DeleteRule, ref int? UpdateRule, ref string TableName, ref string ProjectName, ref long? ConstraintId, ref long? ColumnId, ref long? ProjectId, ref long? TableId);

        partial void OnForeignKeyRulesUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesUpdate> items);
    }
}
