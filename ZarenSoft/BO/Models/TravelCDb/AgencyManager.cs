using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("AgencyManager", Schema = "dbo")]
    public partial class AgencyManager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public int? UserId { get; set; }

        [ConcurrencyCheck]
        public int? Statu { get; set; }

        [ConcurrencyCheck]
        public int? MicrositeId { get; set; }

        public ICollection<Agency> Agencies { get; set; }

        public MicroSite MicroSite { get; set; }

        public Statu Statu1 { get; set; }

        public AgencyUser AgencyUser { get; set; }

    }
}