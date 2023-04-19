using Dapper.Contrib.Extensions;
using System.Text.Json.Serialization;

namespace ZarenUI.Models
{
    [Table("AccountLikes")]
    public class AccountLikes
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private DateTime? _CreatedDate;
        [JsonPropertyName("createddate")]
        public DateTime? CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }

        private string _UserId;
        [JsonPropertyName("userid")]
        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        private string _ProductId;
        [JsonPropertyName("productid")]
        public string ProductId
        {
            get { return _ProductId; }
            set { _ProductId = value; }
        }

        private string _ProductType;
        [JsonPropertyName("producttype")]
        public string ProductType
        {
            get { return _ProductType; }
            set { _ProductType = value; }
        }

        private bool? _IsActive;
        [JsonPropertyName("isactive")]
        public bool? IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        private string _CookieId;
        [JsonPropertyName("cookieid")]
        public string CookieId
        {
            get { return _CookieId; }
            set { _CookieId = value; }
        }
    }
}
