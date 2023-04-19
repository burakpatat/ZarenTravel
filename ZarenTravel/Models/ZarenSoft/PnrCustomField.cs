using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("PNRCustomFields", Schema = "dbo")]
    public partial class PnrCustomField
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? FiTyId { get; set; }

        public int? PNRId { get; set; }

        public string PnCuValue { get; set; }

        public DateTime? FiTyTimestamp { get; set; }

        public bool? FiTyActive { get; set; }

        public FieldsType FieldsType { get; set; }

        public PnR Pnr { get; set; }

    }
}