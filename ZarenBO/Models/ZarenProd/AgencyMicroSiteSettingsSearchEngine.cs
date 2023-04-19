using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("AgencyMicroSiteSettingsSearchEngine", Schema = "dbo")]
    public partial class AgencyMicroSiteSettingsSearchEngine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? MicroSiteId { get; set; }

        public int? AgencyId { get; set; }

        public int? DefaultAvailabilityTimeoutDuration { get; set; }

        public int? DefaultReleaseDaysForEarlyBooking { get; set; }

        public int? DefaultReleaseDaysB2BUsers { get; set; }

        public int? DefaultReleaseDaysOtherUsers { get; set; }

        public int? MinimumNightAllowed { get; set; }

        public Agency Agency { get; set; }

        public AgencyMicroSite AgencyMicroSite { get; set; }

    }
}