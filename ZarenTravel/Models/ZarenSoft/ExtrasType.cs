using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("ExtrasType", Schema = "dbo")]
    public partial class ExtrasType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ExTyCode { get; set; }

        public string ExTyName { get; set; }

        public DateTime? ExTyTimestamp { get; set; }

        public bool? ExTyActive { get; set; }

        public ICollection<AirExtra> AirExtras { get; set; }

    }
}