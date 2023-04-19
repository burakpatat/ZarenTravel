using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class PassengerInformationGetAll
    {
        public int Id { get; set; }

        public string PnrpaxId { get; set; }

        public string Pnr { get; set; }

        public int? PaxSequence { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? AdultId { get; set; }

        public int? NationalityCode { get; set; }

        public decimal? TotalFare { get; set; }

        public decimal? TotalTaxchg { get; set; }

        public decimal? TotalPaid { get; set; }

        public int? FILE_ID { get; set; }

        public string FILE_NAME { get; set; }

        public DateTime? RecordDateStamp { get; set; }

    }
}