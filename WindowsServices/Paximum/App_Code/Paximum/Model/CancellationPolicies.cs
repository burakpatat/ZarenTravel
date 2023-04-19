﻿using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("CancellationPolicies")]
    public class CancellationPolicies : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private DateTime? _DueDate;
        [JsonPropertyName("duedate")]
        public DateTime? DueDate
        {
            get { return _DueDate; }
            set { _DueDate = value; }
        }
        private int? _PriceId;
        [JsonPropertyName("priceid")]
        public int? PriceId
        {
            get { return _PriceId; }
            set { _PriceId = value; }
        }
        private int? _Provider;
        [JsonPropertyName("provider")]
        public int? Provider
        {
            get { return _Provider; }
            set { _Provider = value; }
        }
        private int? _SystemId;
        [JsonPropertyName("systemid")]
        public int? SystemId
        {
            get { return _SystemId; }
            set { _SystemId = value; }
        }
        private int? _ApiId;
        [JsonPropertyName("apiid")]
        public int? ApiId
        {
            get { return _ApiId; }
            set { _ApiId = value; }
        }
        private int? _AgencyId;
        [JsonPropertyName("agencyid")]
        public int? AgencyId
        {
            get { return _AgencyId; }
            set { _AgencyId = value; }
        }
        private int? _MicroSiteId;
        [JsonPropertyName("micrositeid")]
        public int? MicroSiteId
        {
            get { return _MicroSiteId; }
            set { _MicroSiteId = value; }
        }
        private DateTime? _CreatedDate;
        [JsonPropertyName("createddate")]
        public DateTime? CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        private DateTime? _UpdatedDate;
        [JsonPropertyName("updateddate")]
        public DateTime? UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        private int? _CreatedBy;
        [JsonPropertyName("createdby")]
        public int? CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        private int? _UpdatedBy;
        [JsonPropertyName("updatedby")]
        public int? UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
        private int? _LanguageId;
        [JsonPropertyName("languageid")]
        public int? LanguageId
        {
            get { return _LanguageId; }
            set { _LanguageId = value; }
        }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int OfferId { get; set; }
    }
}
