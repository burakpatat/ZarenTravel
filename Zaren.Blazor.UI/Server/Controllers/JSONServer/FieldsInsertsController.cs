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
    public partial class FieldsInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public FieldsInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/FieldsInsertsFunc(ColumnName={ColumnName},DbType={DbType},PrimitiveType={PrimitiveType},IsNullable={IsNullable},MaxLength={MaxLength},ConstraintRules={ConstraintRules},IsPrimary={IsPrimary},Comment={Comment},DefaultValue={DefaultValue},TableName={TableName},ProjectName={ProjectName},TableId={TableId},ProjectId={ProjectId})")]
        public IActionResult FieldsInsertsFunc([FromODataUri] string ColumnName, [FromODataUri] string DbType, [FromODataUri] string PrimitiveType, [FromODataUri] bool? IsNullable, [FromODataUri] int? MaxLength, [FromODataUri] string ConstraintRules, [FromODataUri] bool? IsPrimary, [FromODataUri] string Comment, [FromODataUri] string DefaultValue, [FromODataUri] string TableName, [FromODataUri] string ProjectName, [FromODataUri] long? TableId, [FromODataUri] long? ProjectId)
        {
            this.OnFieldsInsertsDefaultParams(ref ColumnName, ref DbType, ref PrimitiveType, ref IsNullable, ref MaxLength, ref ConstraintRules, ref IsPrimary, ref Comment, ref DefaultValue, ref TableName, ref ProjectName, ref TableId, ref ProjectId);

            var items = this.context.FieldsInserts.FromSqlRaw("EXEC [dbo].[FieldsInsert] @ColumnName={0}, @DbType={1}, @PrimitiveType={2}, @IsNullable={3}, @MaxLength={4}, @ConstraintRules={5}, @IsPrimary={6}, @Comment={7}, @DefaultValue={8}, @TableName={9}, @ProjectName={10}, @TableId={11}, @ProjectId={12}", ColumnName, DbType, PrimitiveType, IsNullable, MaxLength, ConstraintRules, IsPrimary, Comment, DefaultValue, TableName, ProjectName, TableId, ProjectId).ToList().AsQueryable();

            this.OnFieldsInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnFieldsInsertsDefaultParams(ref string ColumnName, ref string DbType, ref string PrimitiveType, ref bool? IsNullable, ref int? MaxLength, ref string ConstraintRules, ref bool? IsPrimary, ref string Comment, ref string DefaultValue, ref string TableName, ref string ProjectName, ref long? TableId, ref long? ProjectId);

        partial void OnFieldsInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.FieldsInsert> items);
    }
}
