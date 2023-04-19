using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AgencyContractsHotelsConfigurationDays", Schema = "zaren")]
    public partial class AgencyContractsHotelsConfigurationDay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool? Monday { get; set; }

        public bool? Tuesday { get; set; }

        public bool? Wednesday { get; set; }

        public bool? Thursday { get; set; }

        public bool? Friday { get; set; }

        public bool? Saturday { get; set; }

        public bool? Sunday { get; set; }

    }
}