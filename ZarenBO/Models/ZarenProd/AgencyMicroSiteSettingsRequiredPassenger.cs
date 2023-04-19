using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("AgencyMicroSiteSettingsRequiredPassenger", Schema = "dbo")]
    public partial class AgencyMicroSiteSettingsRequiredPassenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool? IsActive { get; set; }

    }
}