using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class HotelTypeLanguagesGetByHotelTypeId
    {
        public int Id { get; set; }

        public int? HotelTypeId { get; set; }

        public int? LanguageId { get; set; }

        public string Name { get; set; }

    }
}