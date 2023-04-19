using System;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;


namespace Model.Concrete
{
    

    public class BookingTravellersDto
    {

        private string _FirstName;
        [JsonPropertyName("FirstName")]
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        private string _LastName;
        [JsonPropertyName("LastName")]
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        private string _Email;
        [JsonPropertyName("Email")]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _MobileNumber;
        [JsonPropertyName("MobileNumber")]
        public string MobileNumber
        {
            get { return _MobileNumber; }
            set { _MobileNumber = value; }
        }
        private string _GovernmentId;
        [JsonPropertyName("GovernmentId")]
        public string GovernmentId
        {
            get { return _GovernmentId; }
            set { _GovernmentId = value; }
        }
        private int? _Gender;
        [JsonPropertyName("gender")]
        public int? Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        } 
        private string _BirthDate;
        [JsonPropertyName("BirthDate")]
        public string? BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; }
        }
 
        private string _Note;
        [JsonPropertyName("note")]
        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
 
    }

    public class BookingTravellersPost
    {
        [JsonPropertyName("BookingTravellers")]
        public List<BookingTravellersDto> BookingTravellers { get; set; }
    }
}
