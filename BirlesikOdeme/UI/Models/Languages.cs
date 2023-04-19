using System;

using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("Languages")]
    public class Languages
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _LanguageName;
        [JsonPropertyName("languagename")]
        public string LanguageName
        {
            get { return _LanguageName; }
            set { _LanguageName = value; }
        }
        private string _LanguageCode;
        [JsonPropertyName("languagecode")]
        public string LanguageCode
        {
            get { return _LanguageCode; }
            set { _LanguageCode = value; }
        }
    }
}
