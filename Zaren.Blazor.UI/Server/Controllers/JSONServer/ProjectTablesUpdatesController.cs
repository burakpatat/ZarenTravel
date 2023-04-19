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
    public partial class ProjectTablesUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectTablesUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectTablesUpdatesFunc(Id={Id},TableName={TableName},TableNameCrypto={TableNameCrypto},UniqueColumns={UniqueColumns},DataIndex={DataIndex},ProjectName={ProjectName},UserProjectConnections={UserProjectConnections},Columns={Columns},ProjectTableConfiguration={ProjectTableConfiguration},DiagramConfiguration={DiagramConfiguration},AuditConfiguration={AuditConfiguration},Comment={Comment},CMSMenuConfiguration={CMSMenuConfiguration},CMSPermissionConfiguration={CMSPermissionConfiguration},CMSExportConfiguration={CMSExportConfiguration},CMSCustomFilterConfiguration={CMSCustomFilterConfiguration},Price={Price},CurrencyId={CurrencyId},Commission={Commission},CustomCode={CustomCode},CMSRouteConfiguration={CMSRouteConfiguration},ApiConfiguration={ApiConfiguration},ProgrammingLanguageId={ProgrammingLanguageId},I18Configuration={I18Configuration})")]
        public IActionResult ProjectTablesUpdatesFunc([FromODataUri] int? Id, [FromODataUri] string TableName, [FromODataUri] string TableNameCrypto, [FromODataUri] string UniqueColumns, [FromODataUri] string DataIndex, [FromODataUri] string ProjectName, [FromODataUri] string UserProjectConnections, [FromODataUri] string Columns, [FromODataUri] string ProjectTableConfiguration, [FromODataUri] string DiagramConfiguration, [FromODataUri] string AuditConfiguration, [FromODataUri] string Comment, [FromODataUri] string CMSMenuConfiguration, [FromODataUri] string CMSPermissionConfiguration, [FromODataUri] string CMSExportConfiguration, [FromODataUri] string CMSCustomFilterConfiguration, [FromODataUri] decimal? Price, [FromODataUri] int? CurrencyId, [FromODataUri] decimal? Commission, [FromODataUri] string CustomCode, [FromODataUri] string CMSRouteConfiguration, [FromODataUri] string ApiConfiguration, [FromODataUri] int? ProgrammingLanguageId, [FromODataUri] string I18Configuration)
        {
            this.OnProjectTablesUpdatesDefaultParams(ref Id, ref TableName, ref TableNameCrypto, ref UniqueColumns, ref DataIndex, ref ProjectName, ref UserProjectConnections, ref Columns, ref ProjectTableConfiguration, ref DiagramConfiguration, ref AuditConfiguration, ref Comment, ref CMSMenuConfiguration, ref CMSPermissionConfiguration, ref CMSExportConfiguration, ref CMSCustomFilterConfiguration, ref Price, ref CurrencyId, ref Commission, ref CustomCode, ref CMSRouteConfiguration, ref ApiConfiguration, ref ProgrammingLanguageId, ref I18Configuration);

            var items = this.context.ProjectTablesUpdates.FromSqlRaw("EXEC [dbo].[ProjectTablesUpdate] @Id={0}, @TableName={1}, @TableNameCrypto={2}, @UniqueColumns={3}, @DataIndex={4}, @ProjectName={5}, @UserProjectConnections={6}, @Columns={7}, @ProjectTableConfiguration={8}, @DiagramConfiguration={9}, @AuditConfiguration={10}, @Comment={11}, @CMSMenuConfiguration={12}, @CMSPermissionConfiguration={13}, @CMSExportConfiguration={14}, @CMSCustomFilterConfiguration={15}, @Price={16}, @CurrencyId={17}, @Commission={18}, @CustomCode={19}, @CMSRouteConfiguration={20}, @ApiConfiguration={21}, @ProgrammingLanguageId={22}, @I18Configuration={23}", Id, TableName, TableNameCrypto, UniqueColumns, DataIndex, ProjectName, UserProjectConnections, Columns, ProjectTableConfiguration, DiagramConfiguration, AuditConfiguration, Comment, CMSMenuConfiguration, CMSPermissionConfiguration, CMSExportConfiguration, CMSCustomFilterConfiguration, Price, CurrencyId, Commission, CustomCode, CMSRouteConfiguration, ApiConfiguration, ProgrammingLanguageId, I18Configuration).ToList().AsQueryable();

            this.OnProjectTablesUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectTablesUpdatesDefaultParams(ref int? Id, ref string TableName, ref string TableNameCrypto, ref string UniqueColumns, ref string DataIndex, ref string ProjectName, ref string UserProjectConnections, ref string Columns, ref string ProjectTableConfiguration, ref string DiagramConfiguration, ref string AuditConfiguration, ref string Comment, ref string CMSMenuConfiguration, ref string CMSPermissionConfiguration, ref string CMSExportConfiguration, ref string CMSCustomFilterConfiguration, ref decimal? Price, ref int? CurrencyId, ref decimal? Commission, ref string CustomCode, ref string CMSRouteConfiguration, ref string ApiConfiguration, ref int? ProgrammingLanguageId, ref string I18Configuration);

        partial void OnProjectTablesUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectTablesUpdate> items);
    }
}
