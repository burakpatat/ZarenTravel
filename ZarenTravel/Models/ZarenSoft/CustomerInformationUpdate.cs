using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class CustomerInformationUpdate
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string EmailId { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string AlternativeEmailId { get; set; }

        public string Telephone { get; set; }

        public string Mobile { get; set; }

        public string CountryCode { get; set; }

        public string LanguageCode { get; set; }

        public string OfficeTelephone { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Fax { get; set; }

        public int? NationalityCode { get; set; }

        public string AgentCode { get; set; }

        public int? CustomerId_N { get; set; }

        public decimal? Totalpaxcount { get; set; }

        public decimal? TotalInfantcount { get; set; }

        public decimal? TotalFare { get; set; }

        public decimal? TotalTaxChg { get; set; }

        public int? BookingStatus { get; set; }

        public DateTime? ModificationDate { get; set; }

        public int? FILE_ID { get; set; }

        public string FILE_NAME { get; set; }

        public DateTime? RecordDateStamp { get; set; }

    }
}