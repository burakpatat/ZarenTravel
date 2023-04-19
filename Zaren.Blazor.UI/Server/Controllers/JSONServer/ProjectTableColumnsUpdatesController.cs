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
    public partial class ProjectTableColumnsUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTableColumnsUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTableColumnsUpdatesFunc(Id={Id},ColumnName={ColumnName},ColumnNameCrypto={ColumnNameCrypto},DbType={DbType},PrimitiveType={PrimitiveType},DefaultValue={DefaultValue},IsNullable={IsNullable},MaxLength={MaxLength},FKDetails={FKDetails},TableName={TableName},TableId={TableId},IsPrimary={IsPrimary},InputType={InputType},KeyConfiguration={KeyConfiguration},Extra={Extra},Comment={Comment},DataTypeMapping={DataTypeMapping},ColumnsConfiguration={ColumnsConfiguration},MappingConfiguration={MappingConfiguration},DependencyConfiguration={DependencyConfiguration},Price={Price},CurrencyId={CurrencyId},Commission={Commission},CustomCode={CustomCode},ComponentConfiguration={ComponentConfiguration},CMSListPageConfiguration={CMSListPageConfiguration},CMSEditPageConfiguration={CMSEditPageConfiguration},CMSCreatePageConfiguration={CMSCreatePageConfiguration},CMSDeletePageConfiguration={CMSDeletePageConfiguration},DatabaseCreateMigrationScript={DatabaseCreateMigrationScript},ColumnNameI18={ColumnNameI18})")]
        public IActionResult ProjectTableColumnsUpdatesFunc([FromODataUri] int? Id, [FromODataUri] string ColumnName, [FromODataUri] string ColumnNameCrypto, [FromODataUri] string DbType, [FromODataUri] string PrimitiveType, [FromODataUri] string DefaultValue, [FromODataUri] bool? IsNullable, [FromODataUri] string MaxLength, [FromODataUri] string FKDetails, [FromODataUri] string TableName, [FromODataUri] int? TableId, [FromODataUri] bool? IsPrimary, [FromODataUri] int? InputType, [FromODataUri] string KeyConfiguration, [FromODataUri] string Extra, [FromODataUri] string Comment, [FromODataUri] string DataTypeMapping, [FromODataUri] string ColumnsConfiguration, [FromODataUri] string MappingConfiguration, [FromODataUri] string DependencyConfiguration, [FromODataUri] decimal? Price, [FromODataUri] int? CurrencyId, [FromODataUri] decimal? Commission, [FromODataUri] string CustomCode, [FromODataUri] string ComponentConfiguration, [FromODataUri] string CMSListPageConfiguration, [FromODataUri] string CMSEditPageConfiguration, [FromODataUri] string CMSCreatePageConfiguration, [FromODataUri] string CMSDeletePageConfiguration, [FromODataUri] string DatabaseCreateMigrationScript, [FromODataUri] string ColumnNameI18)
        {
            this.OnProjectTableColumnsUpdatesDefaultParams(ref Id, ref ColumnName, ref ColumnNameCrypto, ref DbType, ref PrimitiveType, ref DefaultValue, ref IsNullable, ref MaxLength, ref FKDetails, ref TableName, ref TableId, ref IsPrimary, ref InputType, ref KeyConfiguration, ref Extra, ref Comment, ref DataTypeMapping, ref ColumnsConfiguration, ref MappingConfiguration, ref DependencyConfiguration, ref Price, ref CurrencyId, ref Commission, ref CustomCode, ref ComponentConfiguration, ref CMSListPageConfiguration, ref CMSEditPageConfiguration, ref CMSCreatePageConfiguration, ref CMSDeletePageConfiguration, ref DatabaseCreateMigrationScript, ref ColumnNameI18);

            var items = this.context.ProjectTableColumnsUpdates.FromSqlRaw("EXEC [dbo].[ProjectTableColumnsUpdate] @Id={0}, @ColumnName={1}, @ColumnNameCrypto={2}, @DbType={3}, @PrimitiveType={4}, @DefaultValue={5}, @IsNullable={6}, @MaxLength={7}, @FKDetails={8}, @TableName={9}, @TableId={10}, @IsPrimary={11}, @InputType={12}, @KeyConfiguration={13}, @Extra={14}, @Comment={15}, @DataTypeMapping={16}, @ColumnsConfiguration={17}, @MappingConfiguration={18}, @DependencyConfiguration={19}, @Price={20}, @CurrencyId={21}, @Commission={22}, @CustomCode={23}, @ComponentConfiguration={24}, @CMSListPageConfiguration={25}, @CMSEditPageConfiguration={26}, @CMSCreatePageConfiguration={27}, @CMSDeletePageConfiguration={28}, @DatabaseCreateMigrationScript={29}, @ColumnNameI18={30}", Id, ColumnName, ColumnNameCrypto, DbType, PrimitiveType, DefaultValue, IsNullable, MaxLength, FKDetails, TableName, TableId, IsPrimary, InputType, KeyConfiguration, Extra, Comment, DataTypeMapping, ColumnsConfiguration, MappingConfiguration, DependencyConfiguration, Price, CurrencyId, Commission, CustomCode, ComponentConfiguration, CMSListPageConfiguration, CMSEditPageConfiguration, CMSCreatePageConfiguration, CMSDeletePageConfiguration, DatabaseCreateMigrationScript, ColumnNameI18).ToList().AsQueryable();

            this.OnProjectTableColumnsUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTableColumnsUpdatesDefaultParams(ref int? Id, ref string ColumnName, ref string ColumnNameCrypto, ref string DbType, ref string PrimitiveType, ref string DefaultValue, ref bool? IsNullable, ref string MaxLength, ref string FKDetails, ref string TableName, ref int? TableId, ref bool? IsPrimary, ref int? InputType, ref string KeyConfiguration, ref string Extra, ref string Comment, ref string DataTypeMapping, ref string ColumnsConfiguration, ref string MappingConfiguration, ref string DependencyConfiguration, ref decimal? Price, ref int? CurrencyId, ref decimal? Commission, ref string CustomCode, ref string ComponentConfiguration, ref string CMSListPageConfiguration, ref string CMSEditPageConfiguration, ref string CMSCreatePageConfiguration, ref string CMSDeletePageConfiguration, ref string DatabaseCreateMigrationScript, ref string ColumnNameI18);

        partial void OnProjectTableColumnsUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsUpdate> items);
    }
}
