using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AgencyMicroSiteSettingsHelpSupport", Schema = "zaren")]
    public partial class AgencyMicroSiteSettingsHelpSupport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool? HideFeedback { get; set; }

        public bool? OpenHelpVideosModalNewTab { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

    }
}