using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("AgencyMicroSiteSettingsHelpSupport", Schema = "dbo")]
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