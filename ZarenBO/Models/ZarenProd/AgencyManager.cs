using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("AgencyManager", Schema = "dbo")]
    public partial class AgencyManager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? Statu { get; set; }

        public int? MicrositeId { get; set; }

        public ICollection<Agency> Agencies { get; set; }

        public AgencyMicroSite AgencyMicroSite { get; set; }

    }
}