using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class HotelAgencyMarkupsGetByStartDate
    {
        public int Id { get; set; }

        public int? AgencyId { get; set; }

        public int? HotelId { get; set; }

        public decimal? MarkUp { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

    }
}