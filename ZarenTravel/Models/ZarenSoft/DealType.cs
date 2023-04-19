using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("DealTypes", Schema = "dbo")]
    public partial class DealType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? Name { get; set; }

        public ICollection<Deal> Deals { get; set; }

        public ICollection<DealTypeLanguage> DealTypeLanguages { get; set; }

    }
}