using System;

using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("TransactionDetails")]
    public class TransactionDetails 

    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private int? _TransactionId;
        [JsonPropertyName("transactionid")]
        public int? TransactionId
        {
            get { return _TransactionId; }
            set { _TransactionId = value; }
        }
        private string _UserAgent;
        [JsonPropertyName("useragent")]
        public string UserAgent
        {
            get { return _UserAgent; }
            set { _UserAgent = value; }
        }
        private string _IP;
        [JsonPropertyName("ip")]
        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }
        private string _CardNumber;
        [JsonPropertyName("cardnumber")]
        public string CardNumber
        {
            get { return _CardNumber; }
            set { _CardNumber = value; }
        }
        private string _CardHolderNameSurname;
        [JsonPropertyName("cardholdernamesurname")]
        public string CardHolderNameSurname
        {
            get { return _CardHolderNameSurname; }
            set { _CardHolderNameSurname = value; }
        }
    }
}
