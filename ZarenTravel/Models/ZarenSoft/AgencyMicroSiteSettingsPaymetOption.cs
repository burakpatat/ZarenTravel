using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AgencyMicroSiteSettingsPaymetOptions", Schema = "zaren")]
    public partial class AgencyMicroSiteSettingsPaymetOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string OptionsName { get; set; }

    }
}