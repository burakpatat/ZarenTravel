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
    public partial class ProjectPageComponentsUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentsUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentsUpdatesFunc(Id={Id},WebSitePagesId={WebSitePagesId},ComponentName={ComponentName},CrudType={CrudType},Query={Query},DatabaseId={DatabaseId},RequestScheme={RequestScheme},ResponseScheme={ResponseScheme},CreatedDate={CreatedDate},ModifyDate={ModifyDate},LastScanDate={LastScanDate},UserId={UserId},UserAgent={UserAgent},LastValidDate={LastValidDate},HasForm={HasForm},ParentWebSitePartsId={ParentWebSitePartsId},HasMultiLanguage={HasMultiLanguage},DefaultLanguage={DefaultLanguage},ScannedLanguage={ScannedLanguage},HasFinishedSuccessfully={HasFinishedSuccessfully},OnHover={OnHover},ApiRequestUrl={ApiRequestUrl},FormActionUrl={FormActionUrl},Price={Price},CurrencyId={CurrencyId},Commission={Commission})")]
        public IActionResult ProjectPageComponentsUpdatesFunc([FromODataUri] int? Id, [FromODataUri] int? WebSitePagesId, [FromODataUri] string ComponentName, [FromODataUri] int? CrudType, [FromODataUri] string Query, [FromODataUri] int? DatabaseId, [FromODataUri] string RequestScheme, [FromODataUri] string ResponseScheme, [FromODataUri] string CreatedDate, [FromODataUri] string ModifyDate, [FromODataUri] string LastScanDate, [FromODataUri] int? UserId, [FromODataUri] string UserAgent, [FromODataUri] string LastValidDate, [FromODataUri] bool? HasForm, [FromODataUri] int? ParentWebSitePartsId, [FromODataUri] string HasMultiLanguage, [FromODataUri] int? DefaultLanguage, [FromODataUri] int? ScannedLanguage, [FromODataUri] bool? HasFinishedSuccessfully, [FromODataUri] bool? OnHover, [FromODataUri] string ApiRequestUrl, [FromODataUri] string FormActionUrl, [FromODataUri] decimal? Price, [FromODataUri] int? CurrencyId, [FromODataUri] decimal? Commission)
        {
            this.OnProjectPageComponentsUpdatesDefaultParams(ref Id, ref WebSitePagesId, ref ComponentName, ref CrudType, ref Query, ref DatabaseId, ref RequestScheme, ref ResponseScheme, ref CreatedDate, ref ModifyDate, ref LastScanDate, ref UserId, ref UserAgent, ref LastValidDate, ref HasForm, ref ParentWebSitePartsId, ref HasMultiLanguage, ref DefaultLanguage, ref ScannedLanguage, ref HasFinishedSuccessfully, ref OnHover, ref ApiRequestUrl, ref FormActionUrl, ref Price, ref CurrencyId, ref Commission);

            var items = this.context.ProjectPageComponentsUpdates.FromSqlRaw("EXEC [dbo].[ProjectPageComponentsUpdate] @Id={0}, @WebSitePagesId={1}, @ComponentName={2}, @CrudType={3}, @Query={4}, @DatabaseId={5}, @RequestScheme={6}, @ResponseScheme={7}, @CreatedDate={8}, @ModifyDate={9}, @LastScanDate={10}, @UserId={11}, @UserAgent={12}, @LastValidDate={13}, @HasForm={14}, @ParentWebSitePartsId={15}, @HasMultiLanguage={16}, @DefaultLanguage={17}, @ScannedLanguage={18}, @HasFinishedSuccessfully={19}, @OnHover={20}, @ApiRequestUrl={21}, @FormActionUrl={22}, @Price={23}, @CurrencyId={24}, @Commission={25}", Id, WebSitePagesId, ComponentName, CrudType, Query, DatabaseId, RequestScheme, ResponseScheme, CreatedDate, ModifyDate, LastScanDate, UserId, UserAgent, LastValidDate, HasForm, ParentWebSitePartsId, HasMultiLanguage, DefaultLanguage, ScannedLanguage, HasFinishedSuccessfully, OnHover, ApiRequestUrl, FormActionUrl, Price, CurrencyId, Commission).ToList().AsQueryable();

            this.OnProjectPageComponentsUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentsUpdatesDefaultParams(ref int? Id, ref int? WebSitePagesId, ref string ComponentName, ref int? CrudType, ref string Query, ref int? DatabaseId, ref string RequestScheme, ref string ResponseScheme, ref string CreatedDate, ref string ModifyDate, ref string LastScanDate, ref int? UserId, ref string UserAgent, ref string LastValidDate, ref bool? HasForm, ref int? ParentWebSitePartsId, ref string HasMultiLanguage, ref int? DefaultLanguage, ref int? ScannedLanguage, ref bool? HasFinishedSuccessfully, ref bool? OnHover, ref string ApiRequestUrl, ref string FormActionUrl, ref decimal? Price, ref int? CurrencyId, ref decimal? Commission);

        partial void OnProjectPageComponentsUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsUpdate> items);
    }
}
