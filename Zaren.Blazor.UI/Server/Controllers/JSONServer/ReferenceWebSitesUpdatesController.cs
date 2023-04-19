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
    public partial class ReferenceWebSitesUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesUpdatesFunc(Id={Id},SiteName={SiteName},Url={Url},ProjectCategoryId={ProjectCategoryId},Ranking={Ranking},AvgVisitDuration={AvgVisitDuration},PageVisit={PageVisit},BounceRate={BounceRate},Logo={Logo},Price={Price},Commission={Commission},CurrencyId={CurrencyId},CreatedDate={CreatedDate},ValidDate={ValidDate},ModifyDate={ModifyDate},LastCompileDate={LastCompileDate},SoftwareLanguageId={SoftwareLanguageId},IsLastPublishSuccessfully={IsLastPublishSuccessfully},DefaultLanguage={DefaultLanguage},UserId={UserId},Guid={Guid})")]
        public IActionResult ReferenceWebSitesUpdatesFunc([FromODataUri] int? Id, [FromODataUri] string SiteName, [FromODataUri] string Url, [FromODataUri] int? ProjectCategoryId, [FromODataUri] int? Ranking, [FromODataUri] string AvgVisitDuration, [FromODataUri] string PageVisit, [FromODataUri] string BounceRate, [FromODataUri] string Logo, [FromODataUri] decimal? Price, [FromODataUri] decimal? Commission, [FromODataUri] int? CurrencyId, [FromODataUri] string CreatedDate, [FromODataUri] string ValidDate, [FromODataUri] string ModifyDate, [FromODataUri] string LastCompileDate, [FromODataUri] int? SoftwareLanguageId, [FromODataUri] bool? IsLastPublishSuccessfully, [FromODataUri] int? DefaultLanguage, [FromODataUri] int? UserId, [FromODataUri] string Guid)
        {
            this.OnReferenceWebSitesUpdatesDefaultParams(ref Id, ref SiteName, ref Url, ref ProjectCategoryId, ref Ranking, ref AvgVisitDuration, ref PageVisit, ref BounceRate, ref Logo, ref Price, ref Commission, ref CurrencyId, ref CreatedDate, ref ValidDate, ref ModifyDate, ref LastCompileDate, ref SoftwareLanguageId, ref IsLastPublishSuccessfully, ref DefaultLanguage, ref UserId, ref Guid);

            var items = this.context.ReferenceWebSitesUpdates.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesUpdate] @Id={0}, @SiteName={1}, @Url={2}, @ProjectCategoryId={3}, @Ranking={4}, @AvgVisitDuration={5}, @PageVisit={6}, @BounceRate={7}, @Logo={8}, @Price={9}, @Commission={10}, @CurrencyId={11}, @CreatedDate={12}, @ValidDate={13}, @ModifyDate={14}, @LastCompileDate={15}, @SoftwareLanguageId={16}, @IsLastPublishSuccessfully={17}, @DefaultLanguage={18}, @UserId={19}, @Guid={20}", Id, SiteName, Url, ProjectCategoryId, Ranking, AvgVisitDuration, PageVisit, BounceRate, Logo, Price, Commission, CurrencyId, CreatedDate, ValidDate, ModifyDate, LastCompileDate, SoftwareLanguageId, IsLastPublishSuccessfully, DefaultLanguage, UserId, Guid).ToList().AsQueryable();

            this.OnReferenceWebSitesUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesUpdatesDefaultParams(ref int? Id, ref string SiteName, ref string Url, ref int? ProjectCategoryId, ref int? Ranking, ref string AvgVisitDuration, ref string PageVisit, ref string BounceRate, ref string Logo, ref decimal? Price, ref decimal? Commission, ref int? CurrencyId, ref string CreatedDate, ref string ValidDate, ref string ModifyDate, ref string LastCompileDate, ref int? SoftwareLanguageId, ref bool? IsLastPublishSuccessfully, ref int? DefaultLanguage, ref int? UserId, ref string Guid);

        partial void OnReferenceWebSitesUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesUpdate> items);
    }
}
