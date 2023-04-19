using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("AgencyMicroSiteSettingPassengerData", Schema = "dbo")]
    public partial class AgencyMicroSiteSettingPassengerDatum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? MicroSiteId { get; set; }

        public int? AgencyId { get; set; }

        public int? RequiredPassengerData { get; set; }

        public bool? ExcludeMrs { get; set; }

        public bool? ExcludeMiss { get; set; }

        public bool? ExcludeNie { get; set; }

        public bool? SearchCustomer { get; set; }

    }
}