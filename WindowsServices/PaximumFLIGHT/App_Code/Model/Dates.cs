using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Model.Concrete
{
    [Table("Dates")]
    public class Dates:IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
      
        private DateTime _Date;
        [JsonPropertyName("date")]
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        private string _DepartureCode;
        [JsonPropertyName("departureCode")]
        public string DepartureCode
        {
            get { return _DepartureCode; }
            set { _DepartureCode = value; }
        }

        private string _ArrivalCode;
        [JsonPropertyName("arrivalCode")]
        public string ArrivalCode
        {
            get { return _ArrivalCode; }
            set { _ArrivalCode = value; }
        }

        private int _DepartureType;
        [JsonPropertyName("departureType")]
        public int DepartureType
        {
            get { return _DepartureType; }
            set { _DepartureType = value; }
        }

        private int _ArrivalType;
        [JsonPropertyName("arrivalType")]
        public int ArrivalType
        {
            get { return _ArrivalType; }
            set { _ArrivalType = value; }
        }

        private int? _LanguageId;
        [JsonPropertyName("languageId")]
        public int? LanguageId
        {
            get { return _LanguageId; }
            set { _LanguageId = value; }
        }
        private int? _ApiId;
        [JsonPropertyName("apiid")]
        public int? ApiId
        {
            get { return _ApiId; }
            set { _ApiId = value; }
        }
    }
}
