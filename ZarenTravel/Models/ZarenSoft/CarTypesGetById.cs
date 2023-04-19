using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class CarTypesGetById
    {
        public int Id { get; set; }

        public string CaTyCode { get; set; }

        public string CaTyDescription { get; set; }

        public DateTime? CaTyTimestamp { get; set; }

        public bool? CaTyActive { get; set; }

    }
}