using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ProjectPageComponentElementsInsert
    {
        public int Id { get; set; }

        public int? WebSitePageComponentsId { get; set; }

        public int? DatabaseTypesId { get; set; }

        public int? FunctionTriggerGroupId { get; set; }

        public int? FunctionTriggerRank { get; set; }

        public int? FunctionTriggerCallAfterSuccessfullTrigger { get; set; }

        public int? CrudType { get; set; }

        public string Query { get; set; }

        public int? UserId { get; set; }

        public string UserAgent { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastScanDate { get; set; }

        public string ExampleRequest { get; set; }

        public string ExampleHtmlCode { get; set; }

        public string PreviewCode { get; set; }

        public string PreviewUrl { get; set; }

        public string HasCodeBuild { get; set; }

        public string ExampleResponse { get; set; }

        public string RequestScheme { get; set; }

        public string ResponseScheme { get; set; }

        public string ApiRequestUrl { get; set; }

        public string RequestHeader { get; set; }

        public string WithMethods { get; set; }

        public string WithHeaders { get; set; }

        public string WithOrigins { get; set; }

        public int? CacheDBConnection { get; set; }

        public int? CacheType { get; set; }

        public string DocumentUrl { get; set; }

        public bool? HasAsync { get; set; }

        public bool? HasCacheMethod { get; set; }

        public bool? ResponseHasMultiModel { get; set; }

        public bool? ResponseHasReturnValue { get; set; }

        public int? LogCodeMergeDateDBType { get; set; }

        public string LogCodeMergeDateDBConnection { get; set; }

        public bool? WillLogAllRequest { get; set; }

        public bool? WillLogCodeMergeDate { get; set; }

        public bool? WillLogAllResponse { get; set; }

        public bool? IsDeleted { get; set; }

        public int? Statu { get; set; }

        public DateTime? PublishedDate { get; set; }

        public int? EventType { get; set; }

        public bool? HasBusEvent { get; set; }

        public string i18Json { get; set; }

        public int? IfResponseIsSuccessCallThisComponentPartId { get; set; }

        public string SuccessNotificationTemplate { get; set; }

        public string Comment { get; set; }

        public string UserDescriptionForComponent { get; set; }

        public string NameSpaceList { get; set; }

        public int? SoftwareLanguageId { get; set; }

        public int? ComponentGroupId { get; set; }

        public bool? ComponentIsParentInGroup { get; set; }

        public int? ComponentCallRankInGroup { get; set; }

        public string CustomCode { get; set; }

        public string CustomCss { get; set; }

        public string CustomScript { get; set; }

        public string CustomScheme { get; set; }

        public string CustomAnimationScheme { get; set; }

        public decimal? Price { get; set; }

        public int? CurrencyId { get; set; }

        public int? BusEventConnectionId { get; set; }

        public decimal? Commission { get; set; }

    }
}