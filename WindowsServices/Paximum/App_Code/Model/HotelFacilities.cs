﻿using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("HotelFacilities")]
    public class HotelFacilities : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int? _ApiId;
        [JsonPropertyName("apiid")]
        public int? ApiId
        {
            get { return _ApiId; }
            set { _ApiId = value; }
        }
        private string _SystemId;
        [JsonPropertyName("systemid")]
        public string SystemId
        {
            get { return _SystemId; }
            set { _SystemId = value; }
        }
        private int? _LanguageId;
        [JsonPropertyName("languageid")]
        public int? LanguageId
        {
            get { return _LanguageId; }
            set { _LanguageId = value; }
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
        private string _Name;
        [JsonPropertyName("name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Note;
        [JsonPropertyName("note")]
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
        private bool? _IsPriced;
        [JsonPropertyName("ispriced")]
        public bool? IsPriced
        {
            get { return _IsPriced; }
            set { _IsPriced = value; }
        }
        private bool? _Highlighted;
        [JsonPropertyName("highlighted")]
        public bool? Highlighted
        {
            get { return _Highlighted; }
            set { _Highlighted = value; }
        }
        private int? _Type;
        [JsonPropertyName("type")]
        public int? Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        //private int? _FacilityCategoryId;
        //[JsonPropertyName("FacilityCategoryId")]
        //public int? FacilityCategoryId
        //{
        //    get { return _FacilityCategoryId; }
        //    set { _FacilityCategoryId = value; }
        //}

        private int? _FacilityCategoryId;
        [JsonPropertyName("FacilityCategoryId")]
        public int? FacilityCategoryId
        {
            get { return _FacilityCategoryId; }
            set { _FacilityCategoryId = value; }
        }
        private int? _SesonId;
        [JsonPropertyName("SesonId")]
        public int? SesonId
        {
            get { return _SesonId; }
            set { _SesonId = value; }
        }
        private int? _HotelId;
        [JsonPropertyName("HotelId")]
        public int? HotelId
        {
            get { return _HotelId; }
            set { _HotelId = value; }
        }

        public string Unit { get;  set; }
    }
}
