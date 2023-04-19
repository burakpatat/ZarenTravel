using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ReferenceWebSitesGetByCommission
    {
        public int Id { get; set; }

        public string SiteName { get; set; }

        public string Url { get; set; }

        public int? ProjectCategoryId { get; set; }

        public int? Ranking { get; set; }

        public string AvgVisitDuration { get; set; }

        public string PageVisit { get; set; }

        public string BounceRate { get; set; }

        public string Logo { get; set; }

        public decimal? Price { get; set; }

        public decimal? Commission { get; set; }

        public int? CurrencyId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ValidDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public DateTime? LastCompileDate { get; set; }

        public int? SoftwareLanguageId { get; set; }

        public bool? IsLastPublishSuccessfully { get; set; }

        public int? DefaultLanguage { get; set; }

        public int? UserId { get; set; }

        public string Guid { get; set; }

    }
}