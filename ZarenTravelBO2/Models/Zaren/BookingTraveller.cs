using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("BookingTravellers", Schema = "dbo")]
    public partial class BookingTraveller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ReservationNumber { get; set; }

        public string TransactionId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string GovernmentId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public string MobileNumber { get; set; }

        public bool? IsFirstContact { get; set; }

        public string PassportInfoSerial { get; set; }

        public string PassportInfoNumber { get; set; }

        public DateTime? PassportExpireDate { get; set; }

        public DateTime? PassportIssueDate { get; set; }

        public string PassportCountryCode { get; set; }

        public int? PassengerType { get; set; }

        public int? Type { get; set; }

        public int? Title { get; set; }

        public string NationalityTwoLetter { get; set; }

        public string Note { get; set; }

    }
}