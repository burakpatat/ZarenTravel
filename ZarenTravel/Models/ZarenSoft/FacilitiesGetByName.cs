using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class FacilitiesGetByName
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}