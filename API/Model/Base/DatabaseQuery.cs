using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("GenerateQuery")]
    public class GenerateQuery : IEntity
    {
        private int _ID;
        [Key]
        [JsonPropertyName("iD")]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private int? _QueryType;
        [JsonPropertyName("queryType")]
        public int? QueryType
        {
            get { return _QueryType; }
            set { _QueryType = value; }
        }
        private string _Name;
        [JsonPropertyName("name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _NameSpace;
        [JsonPropertyName("nameSpace")]
        public string NameSpace
        {
            get { return _NameSpace; }
            set { _NameSpace = value; }
        }
        private string _Query;
        [JsonPropertyName("query")]
        public string Query
        {
            get { return _Query; }
            set { _Query = value; }
        }
        private bool? _HasGenerated;
        [JsonPropertyName("hasGenerated")]
        public bool? HasGenerated
        {
            get { return _HasGenerated; }
            set { _HasGenerated = value; }
        }
        private DateTime? _CreatedDate;
        [JsonPropertyName("createdDate")]
        public DateTime? CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        private int? _Project;
        [JsonPropertyName("project")]
        public int? Project
        {
            get { return _Project; }
            set { _Project = value; }
        }
        private int? _Users;
        [JsonPropertyName("users")]
        public int? Users
        {
            get { return _Users; }
            set { _Users = value; }
        }
    }
    public class GenerateQueryGetByID : IEntity
    {
        private int _ID;
        [JsonPropertyName("iD")]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private int? _QueryType;
        [JsonPropertyName("queryType")]
        public int? QueryType
        {
            get { return _QueryType; }
            set { _QueryType = value; }
        }
        private string _Name;
        [JsonPropertyName("name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _NameSpace;
        [JsonPropertyName("nameSpace")]
        public string NameSpace
        {
            get { return _NameSpace; }
            set { _NameSpace = value; }
        }
        private string _Query;
        [JsonPropertyName("query")]
        public string Query
        {
            get { return _Query; }
            set { _Query = value; }
        }
        private bool? _HasGenerated;
        [JsonPropertyName("hasGenerated")]
        public bool? HasGenerated
        {
            get { return _HasGenerated; }
            set { _HasGenerated = value; }
        }
        private DateTime? _CreatedDate;
        [JsonPropertyName("createdDate")]
        public DateTime? CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        private int? _Project;
        [JsonPropertyName("project")]
        public int? Project
        {
            get { return _Project; }
            set { _Project = value; }
        }
        private int? _Users;
        [JsonPropertyName("users")]
        public int? Users
        {
            get { return _Users; }
            set { _Users = value; }
        }
    }
}
