using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
    [Table("BookingTravellers")]
    public class BookingTravellers : IEntity
    {
        private int _Id;
        [Key]
        [JsonPropertyName("id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _ReservationNumber;
        [JsonPropertyName("reservationnumber")]
        public string ReservationNumber
        {
            get { return _ReservationNumber; }
            set { _ReservationNumber = value; }
        }

        private string _TransactionId;
        [JsonPropertyName("transactionId")]
        public string TransactionId
        {
            get { return _TransactionId; }
            set { _TransactionId = value; }
        }

        private string _FirstName;
        [JsonPropertyName("firstname")]
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        private string _LastName;
        [JsonPropertyName("lastname")]
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        private string _Email;
        [JsonPropertyName("email")]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private string _GovernmentId;
        [JsonPropertyName("governmentid")]
        public string GovernmentId
        {
            get { return _GovernmentId; }
            set { _GovernmentId = value; }
        }
        private DateTime? _CreatedDate;
        [JsonPropertyName("createddate")]
        public DateTime? CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        private int? _Gender;
        [JsonPropertyName("gender")]
        public int? Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        private DateTime? _BirthDate;
        [JsonPropertyName("birthdate")]
        public DateTime? BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; }
        }
        private string _MobileNumber;
        [JsonPropertyName("mobilenumber")]
        public string MobileNumber
        {
            get { return _MobileNumber; }
            set { _MobileNumber = value; }
        }
        private bool? _IsFirstContact;
        [JsonPropertyName("isfirstcontact")]
        public bool? IsFirstContact
        {
            get { return _IsFirstContact; }
            set { _IsFirstContact = value; }
        }
        private string _PassportInfoSerial;
        [JsonPropertyName("passportinfoserial")]
        public string PassportInfoSerial
        {
            get { return _PassportInfoSerial; }
            set { _PassportInfoSerial = value; }
        }
        private string _PassportInfoNumber;
        [JsonPropertyName("passportinfonumber")]
        public string PassportInfoNumber
        {
            get { return _PassportInfoNumber; }
            set { _PassportInfoNumber = value; }
        }
        private DateTime? _PassportExpireDate;
        [JsonPropertyName("passportexpiredate")]
        public DateTime? PassportExpireDate
        {
            get { return _PassportExpireDate; }
            set { _PassportExpireDate = value; }
        }
        private DateTime? _PassportIssueDate;
        [JsonPropertyName("passportissuedate")]
        public DateTime? PassportIssueDate
        {
            get { return _PassportIssueDate; }
            set { _PassportIssueDate = value; }
        }
        private string _PassportCountryCode;
        [JsonPropertyName("passportcountrycode")]
        public string PassportCountryCode
        {
            get { return _PassportCountryCode; }
            set { _PassportCountryCode = value; }
        }
        private int? _PassengerType;
        [JsonPropertyName("passengertype")]
        public int? PassengerType
        {
            get { return _PassengerType; }
            set { _PassengerType = value; }
        }
        private int? _Type;
        [JsonPropertyName("type")]
        public int? Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        private int? _Title;
        [JsonPropertyName("title")]
        public int? Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        private string _NationalityTwoLetter;
        [JsonPropertyName("nationalitytwoletter")]
        public string NationalityTwoLetter
        {
            get { return _NationalityTwoLetter; }
            set { _NationalityTwoLetter = value; }
        }
        private string _Note;
        [JsonPropertyName("note")]
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
    }
}
