using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ProjectPageComponentsGetByUserId
    {
        public int Id { get; set; }

        public int? WebSitePagesId { get; set; }

        public string ComponentName { get; set; }

        public int? CrudType { get; set; }

        public string Query { get; set; }

        public int? DatabaseId { get; set; }

        public string RequestScheme { get; set; }

        public string ResponseScheme { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public DateTime? LastScanDate { get; set; }

        public int? UserId { get; set; }

        public string UserAgent { get; set; }

        public DateTime? LastValidDate { get; set; }

        public bool? HasForm { get; set; }

        public int? ParentWebSitePartsId { get; set; }

        public string HasMultiLanguage { get; set; }

        public int? DefaultLanguage { get; set; }

        public int? ScannedLanguage { get; set; }

        public bool? HasFinishedSuccessfully { get; set; }

        public bool? OnHover { get; set; }

        public string ApiRequestUrl { get; set; }

        public string FormActionUrl { get; set; }

        public decimal? Price { get; set; }

        public int? CurrencyId { get; set; }

        public decimal? Commission { get; set; }

    }
}