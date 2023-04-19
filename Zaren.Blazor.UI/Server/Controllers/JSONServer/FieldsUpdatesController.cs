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
    public partial class FieldsUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public FieldsUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/FieldsUpdatesFunc(Id={Id},ColumnName={ColumnName},DbType={DbType},PrimitiveType={PrimitiveType},IsNullable={IsNullable},MaxLength={MaxLength},ConstraintRules={ConstraintRules},IsPrimary={IsPrimary},Comment={Comment},DefaultValue={DefaultValue},TableName={TableName},ProjectName={ProjectName},TableId={TableId},ProjectId={ProjectId})")]
        public IActionResult FieldsUpdatesFunc([FromODataUri] long? Id, [FromODataUri] string ColumnName, [FromODataUri] string DbType, [FromODataUri] string PrimitiveType, [FromODataUri] bool? IsNullable, [FromODataUri] int? MaxLength, [FromODataUri] string ConstraintRules, [FromODataUri] bool? IsPrimary, [FromODataUri] string Comment, [FromODataUri] string DefaultValue, [FromODataUri] string TableName, [FromODataUri] string ProjectName, [FromODataUri] long? TableId, [FromODataUri] long? ProjectId)
        {
            this.OnFieldsUpdatesDefaultParams(ref Id, ref ColumnName, ref DbType, ref PrimitiveType, ref IsNullable, ref MaxLength, ref ConstraintRules, ref IsPrimary, ref Comment, ref DefaultValue, ref TableName, ref ProjectName, ref TableId, ref ProjectId);

            var items = this.context.FieldsUpdates.FromSqlRaw("EXEC [dbo].[FieldsUpdate] @Id={0}, @ColumnName={1}, @DbType={2}, @PrimitiveType={3}, @IsNullable={4}, @MaxLength={5}, @ConstraintRules={6}, @IsPrimary={7}, @Comment={8}, @DefaultValue={9}, @TableName={10}, @ProjectName={11}, @TableId={12}, @ProjectId={13}", Id, ColumnName, DbType, PrimitiveType, IsNullable, MaxLength, ConstraintRules, IsPrimary, Comment, DefaultValue, TableName, ProjectName, TableId, ProjectId).ToList().AsQueryable();

            this.OnFieldsUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnFieldsUpdatesDefaultParams(ref long? Id, ref string ColumnName, ref string DbType, ref string PrimitiveType, ref bool? IsNullable, ref int? MaxLength, ref string ConstraintRules, ref bool? IsPrimary, ref string Comment, ref string DefaultValue, ref string TableName, ref string ProjectName, ref long? TableId, ref long? ProjectId);

        partial void OnFieldsUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.FieldsUpdate> items);
    }
}
