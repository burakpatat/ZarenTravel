using System;

using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("Resources")]
    public class Resources 
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _SourceKey;
        [JsonPropertyName("sourcekey")]
        public string SourceKey
        {
            get { return _SourceKey; }
            set { _SourceKey = value; }
        }
        private int? _LanguageId;
        [JsonPropertyName("languageid")]
        public int? LanguageId
        {
            get { return _LanguageId; }
            set { _LanguageId = value; }
        }
        private string _SourceValue;
        [JsonPropertyName("sourcevalue")]
        public string SourceValue
        {
            get { return _SourceValue; }
            set { _SourceValue = value; }
        }
    }
}
