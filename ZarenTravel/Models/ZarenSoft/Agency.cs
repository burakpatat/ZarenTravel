using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Agencies", Schema = "dbo")]
    public partial class Agency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PaymentPolitics { get; set; }

        public decimal? MarkUp { get; set; }

        public int? ComercialContactId { get; set; }

        public int? ReservationContactId { get; set; }

        public int? FinanceContactId { get; set; }

        public Contact Contact { get; set; }

        public Contact Contact1 { get; set; }

        public AgencyGroup AgencyGroup { get; set; }

        public Contact Contact2 { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public ICollection<Company> Companies { get; set; }

        public ICollection<HotelAgencyMarkup> HotelAgencyMarkups { get; set; }

        public ICollection<PnR> PnRs { get; set; }

    }
}