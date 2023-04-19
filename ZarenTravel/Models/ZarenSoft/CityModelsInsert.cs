using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class CityModelsInsert
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

    }
}