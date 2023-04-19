using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("Rooms", Schema = "dbo")]
    public partial class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }

        [ConcurrencyCheck]
        public int? BoardId { get; set; }

        [ConcurrencyCheck]
        public string BoardName { get; set; }

        [ConcurrencyCheck]
        public int? StopSaleGuaranteed { get; set; }

        [ConcurrencyCheck]
        public int? StopSaleStandart { get; set; }

        [ConcurrencyCheck]
        public int? PriceId { get; set; }

        [ConcurrencyCheck]
        public int? TravellerId { get; set; }

        [ConcurrencyCheck]
        public int? FacilityId { get; set; }

        public ICollection<RoomsSelectedHotel> RoomsSelectedHotels { get; set; }

    }
}