using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class ExtrasTypeGetByExTyActive
    {
        public int Id { get; set; }

        public string ExTyCode { get; set; }

        public string ExTyName { get; set; }

        public DateTime? ExTyTimestamp { get; set; }

        public bool? ExTyActive { get; set; }

    }
}