using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Providers", Schema = "dbo")]
    public partial class Provider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Website { get; set; }

        public int? ComercialContactId { get; set; }

        public int? ReservationContactId { get; set; }

        public int? FinanceContactId { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public Contact Contact { get; set; }

        public Contact Contact1 { get; set; }

        public Contact Contact2 { get; set; }

    }
}