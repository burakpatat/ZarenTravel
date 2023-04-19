using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class PnrCustomFieldsGetAll
    {
        public int Id { get; set; }

        public int? FiTyId { get; set; }

        public int? PNRId { get; set; }

        public string PnCuValue { get; set; }

        public DateTime? FiTyTimestamp { get; set; }

        public bool? FiTyActive { get; set; }

    }
}