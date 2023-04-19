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
    public partial class ProjectPageComponentsInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsInsertsFunc(WebSitePagesId={WebSitePagesId},ComponentName={ComponentName},CrudType={CrudType},Query={Query},DatabaseId={DatabaseId},RequestScheme={RequestScheme},ResponseScheme={ResponseScheme},CreatedDate={CreatedDate},ModifyDate={ModifyDate},LastScanDate={LastScanDate},UserId={UserId},UserAgent={UserAgent},LastValidDate={LastValidDate},HasForm={HasForm},ParentWebSitePartsId={ParentWebSitePartsId},HasMultiLanguage={HasMultiLanguage},DefaultLanguage={DefaultLanguage},ScannedLanguage={ScannedLanguage},HasFinishedSuccessfully={HasFinishedSuccessfully},OnHover={OnHover},ApiRequestUrl={ApiRequestUrl},FormActionUrl={FormActionUrl},Price={Price},CurrencyId={CurrencyId},Commission={Commission})")]
        public IActionResult ProjectPageComponentsInsertsFunc([FromODataUri] int? WebSitePagesId, [FromODataUri] string ComponentName, [FromODataUri] int? CrudType, [FromODataUri] string Query, [FromODataUri] int? DatabaseId, [FromODataUri] string RequestScheme, [FromODataUri] string ResponseScheme, [FromODataUri] string CreatedDate, [FromODataUri] string ModifyDate, [FromODataUri] string LastScanDate, [FromODataUri] int? UserId, [FromODataUri] string UserAgent, [FromODataUri] string LastValidDate, [FromODataUri] bool? HasForm, [FromODataUri] int? ParentWebSitePartsId, [FromODataUri] string HasMultiLanguage, [FromODataUri] int? DefaultLanguage, [FromODataUri] int? ScannedLanguage, [FromODataUri] bool? HasFinishedSuccessfully, [FromODataUri] bool? OnHover, [FromODataUri] string ApiRequestUrl, [FromODataUri] string FormActionUrl, [FromODataUri] decimal? Price, [FromODataUri] int? CurrencyId, [FromODataUri] decimal? Commission)
        {
            this.OnProjectPageComponentsInsertsDefaultParams(ref WebSitePagesId, ref ComponentName, ref CrudType, ref Query, ref DatabaseId, ref RequestScheme, ref ResponseScheme, ref CreatedDate, ref ModifyDate, ref LastScanDate, ref UserId, ref UserAgent, ref LastValidDate, ref HasForm, ref ParentWebSitePartsId, ref HasMultiLanguage, ref DefaultLanguage, ref ScannedLanguage, ref HasFinishedSuccessfully, ref OnHover, ref ApiRequestUrl, ref FormActionUrl, ref Price, ref CurrencyId, ref Commission);

            var items = this.context.ProjectPageComponentsInserts.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsInsert] @WebSitePagesId={0}, @ComponentName={1}, @CrudType={2}, @Query={3}, @DatabaseId={4}, @RequestScheme={5}, @ResponseScheme={6}, @CreatedDate={7}, @ModifyDate={8}, @LastScanDate={9}, @UserId={10}, @UserAgent={11}, @LastValidDate={12}, @HasForm={13}, @ParentWebSitePartsId={14}, @HasMultiLanguage={15}, @DefaultLanguage={16}, @ScannedLanguage={17}, @HasFinishedSuccessfully={18}, @OnHover={19}, @ApiRequestUrl={20}, @FormActionUrl={21}, @Price={22}, @CurrencyId={23}, @Commission={24}", WebSitePagesId, ComponentName, CrudType, Query, DatabaseId, RequestScheme, ResponseScheme, CreatedDate, ModifyDate, LastScanDate, UserId, UserAgent, LastValidDate, HasForm, ParentWebSitePartsId, HasMultiLanguage, DefaultLanguage, ScannedLanguage, HasFinishedSuccessfully, OnHover, ApiRequestUrl, FormActionUrl, Price, CurrencyId, Commission).ToList().AsQueryable();

            this.OnProjectPageComponentsInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsInsertsDefaultParams(ref int? WebSitePagesId, ref string ComponentName, ref int? CrudType, ref string Query, ref int? DatabaseId, ref string RequestScheme, ref string ResponseScheme, ref string CreatedDate, ref string ModifyDate, ref string LastScanDate, ref int? UserId, ref string UserAgent, ref string LastValidDate, ref bool? HasForm, ref int? ParentWebSitePartsId, ref string HasMultiLanguage, ref int? DefaultLanguage, ref int? ScannedLanguage, ref bool? HasFinishedSuccessfully, ref bool? OnHover, ref string ApiRequestUrl, ref string FormActionUrl, ref decimal? Price, ref int? CurrencyId, ref decimal? Commission);

        partial void OnProjectPageComponentsInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsInsert> items);
    }
}
