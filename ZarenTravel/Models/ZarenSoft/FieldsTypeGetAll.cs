using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class FieldsTypeGetAll
    {
        public int Id { get; set; }

        public string FiTyCode { get; set; }

        public string FiTyName { get; set; }

        public DateTime? FiTyTimestamp { get; set; }

        public bool? FiTyActive { get; set; }

    }
}