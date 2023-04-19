using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class HotelRoomLanguagesGetAll
    {
        public int Id { get; set; }

        public int? HotelRoomId { get; set; }

        public int? LanguageId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

    }
}