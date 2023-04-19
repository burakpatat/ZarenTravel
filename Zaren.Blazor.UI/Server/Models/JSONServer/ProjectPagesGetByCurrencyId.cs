using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ProjectPagesGetByCurrencyId
    {
        public int Id { get; set; }

        public string PageUrl { get; set; }

        public int? ProjectId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastScanDate { get; set; }

        public int? UserId { get; set; }

        public bool? HasPaid { get; set; }

        public string ReferralUrl { get; set; }

        public string HtmlCode { get; set; }

        public string JsonCode { get; set; }

        public string PageName { get; set; }

        public string Route { get; set; }

        public int? DefaultLanguage { get; set; }

        public bool? HasMultipleLanguage { get; set; }

        public int? ScannedLanguage { get; set; }

        public bool? HasFinishedSuccessfully { get; set; }

        public decimal? Price { get; set; }

        public int? CurrencyId { get; set; }

        public decimal? Commission { get; set; }

        public string CustomCode { get; set; }

        public string CssCode { get; set; }

        public string JsCode { get; set; }

        public string PageCycleEventDefination { get; set; }

        public string PageCycleEventDefination1 { get; set; }

    }
}