using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("HotelAgencyMarkups", Schema = "dbo")]
    public partial class HotelAgencyMarkup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AgencyId { get; set; }

        public int? HotelId { get; set; }

        public decimal? MarkUp { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Agency Agency { get; set; }

        public Hotel Hotel { get; set; }

    }
}