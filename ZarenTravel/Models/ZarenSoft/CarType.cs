using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("CarTypes", Schema = "dbo")]
    public partial class CarType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CaTyCode { get; set; }

        public string CaTyDescription { get; set; }

        public DateTime? CaTyTimestamp { get; set; }

        public bool? CaTyActive { get; set; }

        public ICollection<CarRent> CarRents { get; set; }

    }
}