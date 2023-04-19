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
    public partial class ProjectPagesInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPagesInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPagesInsertsFunc(PageUrl={PageUrl},ProjectId={ProjectId},CreatedDate={CreatedDate},LastScanDate={LastScanDate},UserId={UserId},HasPaid={HasPaid},ReferralUrl={ReferralUrl},HtmlCode={HtmlCode},JsonCode={JsonCode},PageName={PageName},Route={Route},DefaultLanguage={DefaultLanguage},HasMultipleLanguage={HasMultipleLanguage},ScannedLanguage={ScannedLanguage},HasFinishedSuccessfully={HasFinishedSuccessfully},Price={Price},CurrencyId={CurrencyId},Commission={Commission},CustomCode={CustomCode},CssCode={CssCode},JsCode={JsCode},PageCycleEventDefination={PageCycleEventDefination},PageCycleEventDefination1={PageCycleEventDefination1})")]
        public IActionResult ProjectPagesInsertsFunc([FromODataUri] string PageUrl, [FromODataUri] int? ProjectId, [FromODataUri] string CreatedDate, [FromODataUri] string LastScanDate, [FromODataUri] int? UserId, [FromODataUri] bool? HasPaid, [FromODataUri] string ReferralUrl, [FromODataUri] string HtmlCode, [FromODataUri] string JsonCode, [FromODataUri] string PageName, [FromODataUri] string Route, [FromODataUri] int? DefaultLanguage, [FromODataUri] bool? HasMultipleLanguage, [FromODataUri] int? ScannedLanguage, [FromODataUri] bool? HasFinishedSuccessfully, [FromODataUri] decimal? Price, [FromODataUri] int? CurrencyId, [FromODataUri] decimal? Commission, [FromODataUri] string CustomCode, [FromODataUri] string CssCode, [FromODataUri] string JsCode, [FromODataUri] string PageCycleEventDefination, [FromODataUri] string PageCycleEventDefination1)
        {
            this.OnProjectPagesInsertsDefaultParams(ref PageUrl, ref ProjectId, ref CreatedDate, ref LastScanDate, ref UserId, ref HasPaid, ref ReferralUrl, ref HtmlCode, ref JsonCode, ref PageName, ref Route, ref DefaultLanguage, ref HasMultipleLanguage, ref ScannedLanguage, ref HasFinishedSuccessfully, ref Price, ref CurrencyId, ref Commission, ref CustomCode, ref CssCode, ref JsCode, ref PageCycleEventDefination, ref PageCycleEventDefination1);

            var items = this.context.ProjectPagesInserts.FromSqlRaw("EXEC [dbo].[ProjectPagesInsert] @PageUrl={0}, @ProjectId={1}, @CreatedDate={2}, @LastScanDate={3}, @UserId={4}, @HasPaid={5}, @ReferralUrl={6}, @HtmlCode={7}, @JsonCode={8}, @PageName={9}, @Route={10}, @DefaultLanguage={11}, @HasMultipleLanguage={12}, @ScannedLanguage={13}, @HasFinishedSuccessfully={14}, @Price={15}, @CurrencyId={16}, @Commission={17}, @CustomCode={18}, @CssCode={19}, @JsCode={20}, @PageCycleEventDefination={21}, @PageCycleEventDefination1={22}", PageUrl, ProjectId, CreatedDate, LastScanDate, UserId, HasPaid, ReferralUrl, HtmlCode, JsonCode, PageName, Route, DefaultLanguage, HasMultipleLanguage, ScannedLanguage, HasFinishedSuccessfully, Price, CurrencyId, Commission, CustomCode, CssCode, JsCode, PageCycleEventDefination, PageCycleEventDefination1).ToList().AsQueryable();

            this.OnProjectPagesInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPagesInsertsDefaultParams(ref string PageUrl, ref int? ProjectId, ref string CreatedDate, ref string LastScanDate, ref int? UserId, ref bool? HasPaid, ref string ReferralUrl, ref string HtmlCode, ref string JsonCode, ref string PageName, ref string Route, ref int? DefaultLanguage, ref bool? HasMultipleLanguage, ref int? ScannedLanguage, ref bool? HasFinishedSuccessfully, ref decimal? Price, ref int? CurrencyId, ref decimal? Commission, ref string CustomCode, ref string CssCode, ref string JsCode, ref string PageCycleEventDefination, ref string PageCycleEventDefination1);

        partial void OnProjectPagesInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPagesInsert> items);
    }
}
