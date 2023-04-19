using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AgencyMicroSiteSettingsBookingReplicatorMode", Schema = "zaren")]
    public partial class AgencyMicroSiteSettingsBookingReplicatorMode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool? CustomizeIt { get; set; }

        public bool? DirectBookingWithoutChanges { get; set; }

        public bool? IWantIt { get; set; }

    }
}