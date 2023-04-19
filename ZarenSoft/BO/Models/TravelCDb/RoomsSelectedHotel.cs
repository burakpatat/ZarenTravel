using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("RoomsSelectedHotel", Schema = "dbo")]
    public partial class RoomsSelectedHotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public int? HotelId { get; set; }

        [ConcurrencyCheck]
        public int? RoomId { get; set; }

        public Hotel Hotel { get; set; }

        public Room Room { get; set; }

    }
}