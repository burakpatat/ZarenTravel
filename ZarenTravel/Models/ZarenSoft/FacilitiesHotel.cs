using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("FacilitiesHotels", Schema = "dbo")]
    public partial class FacilitiesHotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? HotelId { get; set; }

        public int? HotelRoomId { get; set; }

        public int? FacilityId { get; set; }

        public Facility Facility { get; set; }

        public Hotel Hotel { get; set; }

        public HotelRoom HotelRoom { get; set; }

    }
}