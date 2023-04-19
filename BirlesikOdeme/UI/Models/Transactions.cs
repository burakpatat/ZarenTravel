using System;

using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("Transactions")]
    public class Transactions 
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _IdGuid;
        [JsonPropertyName("idguid")]
        public string IdGuid
        {
            get { return _IdGuid; }
            set { _IdGuid = value; }
        }
        private DateTime? _CreatedDate;
        [JsonPropertyName("createddate")]
        public DateTime? CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        private decimal? _TotalAmount;
        [JsonPropertyName("totalamount")]
        public decimal? TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }
        private string _UserId;
        [JsonPropertyName("userid")]
        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        private bool? _IsSuccess;
        [JsonPropertyName("issuccess")]
        public bool? IsSuccess
        {
            get { return _IsSuccess; }
            set { _IsSuccess = value; }
        }
        private string _NameSurname;
        [JsonPropertyName("namesurname")]
        public string NameSurname
        {
            get { return _NameSurname; }
            set { _NameSurname = value; }
        }
        private string _Language;
        [JsonPropertyName("language")]
        public string Language
        {
            get { return _Language; }
            set { _Language = value; }
        }
        private bool? _Is3D;
        [JsonPropertyName("is3d")]
        public bool? Is3D
        {
            get { return _Is3D; }
            set { _Is3D = value; }
        }
        private int? _Currency;
        [JsonPropertyName("currency")]
        public int? Currency
        {
            get { return _Currency; }
            set { _Currency = value; }
        }
    }
}
