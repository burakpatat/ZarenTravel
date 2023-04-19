using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("FieldsType", Schema = "dbo")]
    public partial class FieldsType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FiTyCode { get; set; }

        public string FiTyName { get; set; }

        public DateTime? FiTyTimestamp { get; set; }

        public bool? FiTyActive { get; set; }

        public ICollection<PnrCustomField> PnrCustomFields { get; set; }

    }
}