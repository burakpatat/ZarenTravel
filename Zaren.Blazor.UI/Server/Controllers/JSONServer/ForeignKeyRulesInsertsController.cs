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
    public partial class ForeignKeyRulesInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ForeignKeyRulesInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ForeignKeyRulesInsertsFunc(ColumnName={ColumnName},ReferencedTableName={ReferencedTableName},ReferencedColumnName={ReferencedColumnName},ReferencedColumnDbTypeCompare={ReferencedColumnDbTypeCompare},DeleteRule={DeleteRule},UpdateRule={UpdateRule},TableName={TableName},ProjectName={ProjectName},ConstraintId={ConstraintId},ColumnId={ColumnId},ProjectId={ProjectId},TableId={TableId})")]
        public IActionResult ForeignKeyRulesInsertsFunc([FromODataUri] string ColumnName, [FromODataUri] string ReferencedTableName, [FromODataUri] string ReferencedColumnName, [FromODataUri] string ReferencedColumnDbTypeCompare, [FromODataUri] int? DeleteRule, [FromODataUri] int? UpdateRule, [FromODataUri] string TableName, [FromODataUri] string ProjectName, [FromODataUri] long? ConstraintId, [FromODataUri] long? ColumnId, [FromODataUri] long? ProjectId, [FromODataUri] long? TableId)
        {
            this.OnForeignKeyRulesInsertsDefaultParams(ref ColumnName, ref ReferencedTableName, ref ReferencedColumnName, ref ReferencedColumnDbTypeCompare, ref DeleteRule, ref UpdateRule, ref TableName, ref ProjectName, ref ConstraintId, ref ColumnId, ref ProjectId, ref TableId);

            var items = this.context.ForeignKeyRulesInserts.FromSqlRaw("EXEC [dbo].[ForeignKeyRulesInsert] @ColumnName={0}, @ReferencedTableName={1}, @ReferencedColumnName={2}, @ReferencedColumnDbTypeCompare={3}, @DeleteRule={4}, @UpdateRule={5}, @TableName={6}, @ProjectName={7}, @ConstraintId={8}, @ColumnId={9}, @ProjectId={10}, @TableId={11}", ColumnName, ReferencedTableName, ReferencedColumnName, ReferencedColumnDbTypeCompare, DeleteRule, UpdateRule, TableName, ProjectName, ConstraintId, ColumnId, ProjectId, TableId).ToList().AsQueryable();

            this.OnForeignKeyRulesInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnForeignKeyRulesInsertsDefaultParams(ref string ColumnName, ref string ReferencedTableName, ref string ReferencedColumnName, ref string ReferencedColumnDbTypeCompare, ref int? DeleteRule, ref int? UpdateRule, ref string TableName, ref string ProjectName, ref long? ConstraintId, ref long? ColumnId, ref long? ProjectId, ref long? TableId);

        partial void OnForeignKeyRulesInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesInsert> items);
    }
}
