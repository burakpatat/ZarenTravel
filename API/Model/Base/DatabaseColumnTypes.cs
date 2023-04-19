using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Model.Concrete
{
    [Table("DatabaseColumnTypes")]
    public class DatabaseColumnTypes : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _Name;
        [JsonPropertyName("name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _SystemTypeİd;
        [JsonPropertyName("system_type_id")]
        public string SystemTypeİd
        {
            get { return _SystemTypeİd; }
            set { _SystemTypeİd = value; }
        }
        private string _UserTypeId;
        [JsonPropertyName("user_type_id")]
        public string UserTypeId
        {
            get { return _UserTypeId; }
            set { _UserTypeId = value; }
        }
        private int _Schemaİd;
        [JsonPropertyName("schema_id")]
        public int Schemaİd
        {
            get { return _Schemaİd; }
            set { _Schemaİd = value; }
        }
        private int _Principalİd;
        [JsonPropertyName("principal_id")]
        public int Principalİd
        {
            get { return _Principalİd; }
            set { _Principalİd = value; }
        }
        private string _MaxLength;
        [JsonPropertyName("max_length")]
        public string MaxLength
        {
            get { return _MaxLength; }
            set { _MaxLength = value; }
        }
        private string _Precision;
        [JsonPropertyName("precision")]
        public string Precision
        {
            get { return _Precision; }
            set { _Precision = value; }
        }
        private string _Scale;
        [JsonPropertyName("scale")]
        public string Scale
        {
            get { return _Scale; }
            set { _Scale = value; }
        }
        private string _CollationName;
        [JsonPropertyName("collation_name")]
        public string CollationName
        {
            get { return _CollationName; }
            set { _CollationName = value; }
        }
        private int _İsNullable;
        [JsonPropertyName("is_nullable")]
        public int İsNullable
        {
            get { return _İsNullable; }
            set { _İsNullable = value; }
        }
        private int _İsUserDefined;
        [JsonPropertyName("is_user_defined")]
        public int İsUserDefined
        {
            get { return _İsUserDefined; }
            set { _İsUserDefined = value; }
        }
        private int _İsAssemblyType;
        [JsonPropertyName("is_assembly_type")]
        public int İsAssemblyType
        {
            get { return _İsAssemblyType; }
            set { _İsAssemblyType = value; }
        }
        private string _DefaultObjectİd;
        [JsonPropertyName("default_object_id")]
        public string DefaultObjectİd
        {
            get { return _DefaultObjectİd; }
            set { _DefaultObjectİd = value; }
        }
        private string _RuleObjectİd;
        [JsonPropertyName("rule_object_id")]
        public string RuleObjectİd
        {
            get { return _RuleObjectİd; }
            set { _RuleObjectİd = value; }
        }
        private int _İsTableType;
        [JsonPropertyName("is_table_type")]
        public int İsTableType
        {
            get { return _İsTableType; }
            set { _İsTableType = value; }
        }
    }
}
