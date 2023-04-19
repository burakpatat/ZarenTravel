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
    public partial class ProjectPageComponentElementsInsertsController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectPageComponentElementsInsertsController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectPageComponentElementsInsertsFunc(WebSitePageComponentsId={WebSitePageComponentsId},DatabaseTypesId={DatabaseTypesId},FunctionTriggerGroupId={FunctionTriggerGroupId},FunctionTriggerRank={FunctionTriggerRank},FunctionTriggerCallAfterSuccessfullTrigger={FunctionTriggerCallAfterSuccessfullTrigger},CrudType={CrudType},Query={Query},UserId={UserId},UserAgent={UserAgent},CreatedDate={CreatedDate},LastScanDate={LastScanDate},ExampleRequest={ExampleRequest},ExampleHtmlCode={ExampleHtmlCode},PreviewCode={PreviewCode},PreviewUrl={PreviewUrl},HasCodeBuild={HasCodeBuild},ExampleResponse={ExampleResponse},RequestScheme={RequestScheme},ResponseScheme={ResponseScheme},ApiRequestUrl={ApiRequestUrl},RequestHeader={RequestHeader},WithMethods={WithMethods},WithHeaders={WithHeaders},WithOrigins={WithOrigins},CacheDBConnection={CacheDBConnection},CacheType={CacheType},DocumentUrl={DocumentUrl},HasAsync={HasAsync},HasCacheMethod={HasCacheMethod},ResponseHasMultiModel={ResponseHasMultiModel},ResponseHasReturnValue={ResponseHasReturnValue},LogCodeMergeDateDBType={LogCodeMergeDateDBType},LogCodeMergeDateDBConnection={LogCodeMergeDateDBConnection},WillLogAllRequest={WillLogAllRequest},WillLogCodeMergeDate={WillLogCodeMergeDate},WillLogAllResponse={WillLogAllResponse},IsDeleted={IsDeleted},Statu={Statu},PublishedDate={PublishedDate},EventType={EventType},HasBusEvent={HasBusEvent},i18Json={i18Json},IfResponseIsSuccessCallThisComponentPartId={IfResponseIsSuccessCallThisComponentPartId},SuccessNotificationTemplate={SuccessNotificationTemplate},Comment={Comment},UserDescriptionForComponent={UserDescriptionForComponent},NameSpaceList={NameSpaceList},SoftwareLanguageId={SoftwareLanguageId},ComponentGroupId={ComponentGroupId},ComponentIsParentInGroup={ComponentIsParentInGroup},ComponentCallRankInGroup={ComponentCallRankInGroup},CustomCode={CustomCode},CustomCss={CustomCss},CustomScript={CustomScript},CustomScheme={CustomScheme},CustomAnimationScheme={CustomAnimationScheme},Price={Price},CurrencyId={CurrencyId},BusEventConnectionId={BusEventConnectionId},Commission={Commission})")]
        public IActionResult ProjectPageComponentElementsInsertsFunc([FromODataUri] int? WebSitePageComponentsId, [FromODataUri] int? DatabaseTypesId, [FromODataUri] int? FunctionTriggerGroupId, [FromODataUri] int? FunctionTriggerRank, [FromODataUri] int? FunctionTriggerCallAfterSuccessfullTrigger, [FromODataUri] int? CrudType, [FromODataUri] string Query, [FromODataUri] int? UserId, [FromODataUri] string UserAgent, [FromODataUri] string CreatedDate, [FromODataUri] string LastScanDate, [FromODataUri] string ExampleRequest, [FromODataUri] string ExampleHtmlCode, [FromODataUri] string PreviewCode, [FromODataUri] string PreviewUrl, [FromODataUri] string HasCodeBuild, [FromODataUri] string ExampleResponse, [FromODataUri] string RequestScheme, [FromODataUri] string ResponseScheme, [FromODataUri] string ApiRequestUrl, [FromODataUri] string RequestHeader, [FromODataUri] string WithMethods, [FromODataUri] string WithHeaders, [FromODataUri] string WithOrigins, [FromODataUri] int? CacheDBConnection, [FromODataUri] int? CacheType, [FromODataUri] string DocumentUrl, [FromODataUri] bool? HasAsync, [FromODataUri] bool? HasCacheMethod, [FromODataUri] bool? ResponseHasMultiModel, [FromODataUri] bool? ResponseHasReturnValue, [FromODataUri] int? LogCodeMergeDateDBType, [FromODataUri] string LogCodeMergeDateDBConnection, [FromODataUri] bool? WillLogAllRequest, [FromODataUri] bool? WillLogCodeMergeDate, [FromODataUri] bool? WillLogAllResponse, [FromODataUri] bool? IsDeleted, [FromODataUri] int? Statu, [FromODataUri] string PublishedDate, [FromODataUri] int? EventType, [FromODataUri] bool? HasBusEvent, [FromODataUri] string i18Json, [FromODataUri] int? IfResponseIsSuccessCallThisComponentPartId, [FromODataUri] string SuccessNotificationTemplate, [FromODataUri] string Comment, [FromODataUri] string UserDescriptionForComponent, [FromODataUri] string NameSpaceList, [FromODataUri] int? SoftwareLanguageId, [FromODataUri] int? ComponentGroupId, [FromODataUri] bool? ComponentIsParentInGroup, [FromODataUri] int? ComponentCallRankInGroup, [FromODataUri] string CustomCode, [FromODataUri] string CustomCss, [FromODataUri] string CustomScript, [FromODataUri] string CustomScheme, [FromODataUri] string CustomAnimationScheme, [FromODataUri] decimal? Price, [FromODataUri] int? CurrencyId, [FromODataUri] int? BusEventConnectionId, [FromODataUri] decimal? Commission)
        {
            this.OnProjectPageComponentElementsInsertsDefaultParams(ref WebSitePageComponentsId, ref DatabaseTypesId, ref FunctionTriggerGroupId, ref FunctionTriggerRank, ref FunctionTriggerCallAfterSuccessfullTrigger, ref CrudType, ref Query, ref UserId, ref UserAgent, ref CreatedDate, ref LastScanDate, ref ExampleRequest, ref ExampleHtmlCode, ref PreviewCode, ref PreviewUrl, ref HasCodeBuild, ref ExampleResponse, ref RequestScheme, ref ResponseScheme, ref ApiRequestUrl, ref RequestHeader, ref WithMethods, ref WithHeaders, ref WithOrigins, ref CacheDBConnection, ref CacheType, ref DocumentUrl, ref HasAsync, ref HasCacheMethod, ref ResponseHasMultiModel, ref ResponseHasReturnValue, ref LogCodeMergeDateDBType, ref LogCodeMergeDateDBConnection, ref WillLogAllRequest, ref WillLogCodeMergeDate, ref WillLogAllResponse, ref IsDeleted, ref Statu, ref PublishedDate, ref EventType, ref HasBusEvent, ref i18Json, ref IfResponseIsSuccessCallThisComponentPartId, ref SuccessNotificationTemplate, ref Comment, ref UserDescriptionForComponent, ref NameSpaceList, ref SoftwareLanguageId, ref ComponentGroupId, ref ComponentIsParentInGroup, ref ComponentCallRankInGroup, ref CustomCode, ref CustomCss, ref CustomScript, ref CustomScheme, ref CustomAnimationScheme, ref Price, ref CurrencyId, ref BusEventConnectionId, ref Commission);

            var items = this.context.ProjectPageComponentElementsInserts.FromSqlRaw("EXEC [dbo].[ProjectPageComponentElementsInsert] @WebSitePageComponentsId={0}, @DatabaseTypesId={1}, @FunctionTriggerGroupId={2}, @FunctionTriggerRank={3}, @FunctionTriggerCallAfterSuccessfullTrigger={4}, @CrudType={5}, @Query={6}, @UserId={7}, @UserAgent={8}, @CreatedDate={9}, @LastScanDate={10}, @ExampleRequest={11}, @ExampleHtmlCode={12}, @PreviewCode={13}, @PreviewUrl={14}, @HasCodeBuild={15}, @ExampleResponse={16}, @RequestScheme={17}, @ResponseScheme={18}, @ApiRequestUrl={19}, @RequestHeader={20}, @WithMethods={21}, @WithHeaders={22}, @WithOrigins={23}, @CacheDBConnection={24}, @CacheType={25}, @DocumentUrl={26}, @HasAsync={27}, @HasCacheMethod={28}, @ResponseHasMultiModel={29}, @ResponseHasReturnValue={30}, @LogCodeMergeDateDBType={31}, @LogCodeMergeDateDBConnection={32}, @WillLogAllRequest={33}, @WillLogCodeMergeDate={34}, @WillLogAllResponse={35}, @IsDeleted={36}, @Statu={37}, @PublishedDate={38}, @EventType={39}, @HasBusEvent={40}, @i18Json={41}, @IfResponseIsSuccessCallThisComponentPartId={42}, @SuccessNotificationTemplate={43}, @Comment={44}, @UserDescriptionForComponent={45}, @NameSpaceList={46}, @SoftwareLanguageId={47}, @ComponentGroupId={48}, @ComponentIsParentInGroup={49}, @ComponentCallRankInGroup={50}, @CustomCode={51}, @CustomCss={52}, @CustomScript={53}, @CustomScheme={54}, @CustomAnimationScheme={55}, @Price={56}, @CurrencyId={57}, @BusEventConnectionId={58}, @Commission={59}", WebSitePageComponentsId, DatabaseTypesId, FunctionTriggerGroupId, FunctionTriggerRank, FunctionTriggerCallAfterSuccessfullTrigger, CrudType, Query, UserId, UserAgent, CreatedDate, LastScanDate, ExampleRequest, ExampleHtmlCode, PreviewCode, PreviewUrl, HasCodeBuild, ExampleResponse, RequestScheme, ResponseScheme, ApiRequestUrl, RequestHeader, WithMethods, WithHeaders, WithOrigins, CacheDBConnection, CacheType, DocumentUrl, HasAsync, HasCacheMethod, ResponseHasMultiModel, ResponseHasReturnValue, LogCodeMergeDateDBType, LogCodeMergeDateDBConnection, WillLogAllRequest, WillLogCodeMergeDate, WillLogAllResponse, IsDeleted, Statu, PublishedDate, EventType, HasBusEvent, i18Json, IfResponseIsSuccessCallThisComponentPartId, SuccessNotificationTemplate, Comment, UserDescriptionForComponent, NameSpaceList, SoftwareLanguageId, ComponentGroupId, ComponentIsParentInGroup, ComponentCallRankInGroup, CustomCode, CustomCss, CustomScript, CustomScheme, CustomAnimationScheme, Price, CurrencyId, BusEventConnectionId, Commission).ToList().AsQueryable();

            this.OnProjectPageComponentElementsInsertsInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectPageComponentElementsInsertsDefaultParams(ref int? WebSitePageComponentsId, ref int? DatabaseTypesId, ref int? FunctionTriggerGroupId, ref int? FunctionTriggerRank, ref int? FunctionTriggerCallAfterSuccessfullTrigger, ref int? CrudType, ref string Query, ref int? UserId, ref string UserAgent, ref string CreatedDate, ref string LastScanDate, ref string ExampleRequest, ref string ExampleHtmlCode, ref string PreviewCode, ref string PreviewUrl, ref string HasCodeBuild, ref string ExampleResponse, ref string RequestScheme, ref string ResponseScheme, ref string ApiRequestUrl, ref string RequestHeader, ref string WithMethods, ref string WithHeaders, ref string WithOrigins, ref int? CacheDBConnection, ref int? CacheType, ref string DocumentUrl, ref bool? HasAsync, ref bool? HasCacheMethod, ref bool? ResponseHasMultiModel, ref bool? ResponseHasReturnValue, ref int? LogCodeMergeDateDBType, ref string LogCodeMergeDateDBConnection, ref bool? WillLogAllRequest, ref bool? WillLogCodeMergeDate, ref bool? WillLogAllResponse, ref bool? IsDeleted, ref int? Statu, ref string PublishedDate, ref int? EventType, ref bool? HasBusEvent, ref string i18Json, ref int? IfResponseIsSuccessCallThisComponentPartId, ref string SuccessNotificationTemplate, ref string Comment, ref string UserDescriptionForComponent, ref string NameSpaceList, ref int? SoftwareLanguageId, ref int? ComponentGroupId, ref bool? ComponentIsParentInGroup, ref int? ComponentCallRankInGroup, ref string CustomCode, ref string CustomCss, ref string CustomScript, ref string CustomScheme, ref string CustomAnimationScheme, ref decimal? Price, ref int? CurrencyId, ref int? BusEventConnectionId, ref decimal? Commission);

        partial void OnProjectPageComponentElementsInsertsInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsInsert> items);
    }
}