using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ProjectFunctionsGetByCacheType
    {
        public int Id { get; set; }

        public int? DatabaseTypesId { get; set; }

        public int? CrudType { get; set; }

        public string Query { get; set; }

        public int? UserId { get; set; }

        public string UserAgent { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastScanDate { get; set; }

        public int? UserConnectionsId { get; set; }

        public string RequestScheme { get; set; }

        public string ResponseScheme { get; set; }

        public string Route { get; set; }

        public string HeaderScheme { get; set; }

        public string WithMethods { get; set; }

        public string WithHeaders { get; set; }

        public string WithOrigins { get; set; }

        public int? CacheDBConnection { get; set; }

        public int? CacheType { get; set; }

        public string DocumentUrl { get; set; }

        public string ExampleRequest { get; set; }

        public string ExampleResponse { get; set; }

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

        public int? AccessModifierId { get; set; }

        public string AcceptableQuerystrings { get; set; }

        public bool? HasRateLimit { get; set; }

        public string RateLimitProperty { get; set; }

        public bool? HasAuditEvents { get; set; }

        public bool? HasBusEvent { get; set; }

        public string i18Json { get; set; }

        public int? IfResponseIsSuccessCallThisFunctionId { get; set; }

        public string SuccessNotificationTemplate { get; set; }

        public string ApiMethodComment { get; set; }

        public string UserDescriptionForMethod { get; set; }

        public string NameSpaceList { get; set; }

        public int? SoftwareLanguageId { get; set; }

        public int? FunctionGroupId { get; set; }

        public bool? FunctionIsParentInGroup { get; set; }

        public int? FunctionCallRankInGroup { get; set; }

        public string CustomCode { get; set; }

        public decimal? Price { get; set; }

        public int? CurrencyId { get; set; }

        public decimal? Commission { get; set; }

    }
}