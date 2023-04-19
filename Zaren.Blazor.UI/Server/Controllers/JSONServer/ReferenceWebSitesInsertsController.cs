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
    public partial class ReferenceWebSitesInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ReferenceWebSitesInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ReferenceWebSitesInsertsFunc(SiteName={SiteName},Url={Url},ProjectCategoryId={ProjectCategoryId},Ranking={Ranking},AvgVisitDuration={AvgVisitDuration},PageVisit={PageVisit},BounceRate={BounceRate},Logo={Logo},Price={Price},Commission={Commission},CurrencyId={CurrencyId},CreatedDate={CreatedDate},ValidDate={ValidDate},ModifyDate={ModifyDate},LastCompileDate={LastCompileDate},SoftwareLanguageId={SoftwareLanguageId},IsLastPublishSuccessfully={IsLastPublishSuccessfully},DefaultLanguage={DefaultLanguage},UserId={UserId},Guid={Guid})")]
        public IActionResult ReferenceWebSitesInsertsFunc([FromODataUri] string SiteName, [FromODataUri] string Url, [FromODataUri] int? ProjectCategoryId, [FromODataUri] int? Ranking, [FromODataUri] string AvgVisitDuration, [FromODataUri] string PageVisit, [FromODataUri] string BounceRate, [FromODataUri] string Logo, [FromODataUri] decimal? Price, [FromODataUri] decimal? Commission, [FromODataUri] int? CurrencyId, [FromODataUri] string CreatedDate, [FromODataUri] string ValidDate, [FromODataUri] string ModifyDate, [FromODataUri] string LastCompileDate, [FromODataUri] int? SoftwareLanguageId, [FromODataUri] bool? IsLastPublishSuccessfully, [FromODataUri] int? DefaultLanguage, [FromODataUri] int? UserId, [FromODataUri] string Guid)
        {
            this.OnReferenceWebSitesInsertsDefaultParams(ref SiteName, ref Url, ref ProjectCategoryId, ref Ranking, ref AvgVisitDuration, ref PageVisit, ref BounceRate, ref Logo, ref Price, ref Commission, ref CurrencyId, ref CreatedDate, ref ValidDate, ref ModifyDate, ref LastCompileDate, ref SoftwareLanguageId, ref IsLastPublishSuccessfully, ref DefaultLanguage, ref UserId, ref Guid);

            var items = this.context.ReferenceWebSitesInserts.FromSqlRaw("EXEC [dbo].[ReferenceWebSitesInsert] @SiteName={0}, @Url={1}, @ProjectCategoryId={2}, @Ranking={3}, @AvgVisitDuration={4}, @PageVisit={5}, @BounceRate={6}, @Logo={7}, @Price={8}, @Commission={9}, @CurrencyId={10}, @CreatedDate={11}, @ValidDate={12}, @ModifyDate={13}, @LastCompileDate={14}, @SoftwareLanguageId={15}, @IsLastPublishSuccessfully={16}, @DefaultLanguage={17}, @UserId={18}, @Guid={19}", SiteName, Url, ProjectCategoryId, Ranking, AvgVisitDuration, PageVisit, BounceRate, Logo, Price, Commission, CurrencyId, CreatedDate, ValidDate, ModifyDate, LastCompileDate, SoftwareLanguageId, IsLastPublishSuccessfully, DefaultLanguage, UserId, Guid).ToList().AsQueryable();

            this.OnReferenceWebSitesInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnReferenceWebSitesInsertsDefaultParams(ref string SiteName, ref string Url, ref int? ProjectCategoryId, ref int? Ranking, ref string AvgVisitDuration, ref string PageVisit, ref string BounceRate, ref string Logo, ref decimal? Price, ref decimal? Commission, ref int? CurrencyId, ref string CreatedDate, ref string ValidDate, ref string ModifyDate, ref string LastCompileDate, ref int? SoftwareLanguageId, ref bool? IsLastPublishSuccessfully, ref int? DefaultLanguage, ref int? UserId, ref string Guid);

        partial void OnReferenceWebSitesInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesInsert> items);
    }
}
