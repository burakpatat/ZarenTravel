using System;
using System.Text.Json.Serialization;
using Core.Entities;
using Dapper;
using Dapper.Contrib.Extensions;



    [Table("zaren.AspNetUsers")]
    public class AspNetUsers : IEntity
    {
        private string _Id;
        [Key]
        [JsonPropertyName("id")]
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _UserName;
        [JsonPropertyName("username")]
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private string _NormalizedUserName;
        [JsonPropertyName("normalizedusername")]
        public string NormalizedUserName
        {
            get { return _NormalizedUserName; }
            set { _NormalizedUserName = value; }
        }
        private string _Email;
        [JsonPropertyName("email")]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private string _NormalizedEmail;
        [JsonPropertyName("normalizedemail")]
        public string NormalizedEmail
        {
            get { return _NormalizedEmail; }
            set { _NormalizedEmail = value; }
        }
        private bool _EmailConfirmed;

        [JsonPropertyName("emailconfirmed")]
        public bool EmailConfirmed
        {
            get { return _EmailConfirmed; }
            set { _EmailConfirmed = value; }
        }
        private string _PasswordHash;
        [JsonPropertyName("passwordhash")]
        public string PasswordHash
        {
            get { return _PasswordHash; }
            set { _PasswordHash = value; }
        }
        private string _SecurityStamp;
        [JsonPropertyName("securitystamp")]
        public string SecurityStamp
        {
            get { return _SecurityStamp; }
            set { _SecurityStamp = value; }
        }
        private string _ConcurrencyStamp;
        [JsonPropertyName("concurrencystamp")]
        public string ConcurrencyStamp
        {
            get { return _ConcurrencyStamp; }
            set { _ConcurrencyStamp = value; }
        }
        private string _PhoneNumber;
        [JsonPropertyName("phonenumber")]
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }
        private bool _PhoneNumberConfirmed;

        [JsonPropertyName("phonenumberconfirmed")]
        public bool PhoneNumberConfirmed
        {
            get { return _PhoneNumberConfirmed; }
            set { _PhoneNumberConfirmed = value; }
        }
        private bool _TwoFactorEnabled;

        [JsonPropertyName("twofactorenabled")]
        public bool TwoFactorEnabled
        {
            get { return _TwoFactorEnabled; }
            set { _TwoFactorEnabled = value; }
        }

        private int _AccessFailedCount;

        [JsonPropertyName("accessfailedcount")]
        public int AccessFailedCount
        {
            get { return _AccessFailedCount; }
            set { _AccessFailedCount = value; }
        }

        public string Address { get; set; }
        public string ProfilePhoto { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? CountryId { get; set; }
        public string FullName { get; set; }

    public string GoogleId{ get; set; }
    public string FacebookId { get; set; }

    public DateTime? CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }

}
