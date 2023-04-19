using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AgencyMicroSitesSettingsEmailConfiguration", Schema = "zaren")]
    public partial class AgencyMicroSitesSettingsEmailConfiguration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? MicroSiteId { get; set; }

        public int? AgencyId { get; set; }

        public string Email { get; set; }

        public bool? IsValid { get; set; }

    }
}