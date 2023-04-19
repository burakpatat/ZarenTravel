using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class FacilitiesHotelsGetByHotelRoomId
    {
        public int Id { get; set; }

        public int? HotelId { get; set; }

        public int? HotelRoomId { get; set; }

        public int? FacilityId { get; set; }

    }
}