using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("AgencyMicroSiteSettingsBookingReplicatorMode", Schema = "dbo")]
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