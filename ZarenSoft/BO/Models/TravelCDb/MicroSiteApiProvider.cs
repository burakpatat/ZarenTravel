using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("MicroSiteApiProviders", Schema = "dbo")]
    public partial class MicroSiteApiProvider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public int? ApiId { get; set; }

        [ConcurrencyCheck]
        public int? ApiProductId { get; set; }

        [ConcurrencyCheck]
        public int? MicroSiteId { get; set; }

        [ConcurrencyCheck]
        public int? AgencyId { get; set; }

        [ConcurrencyCheck]
        public int? CreatedBy { get; set; }

        [ConcurrencyCheck]
        public int? UpdateBy { get; set; }

        [ConcurrencyCheck]
        public int? Priority { get; set; }

        [ConcurrencyCheck]
        public bool? HasConsolidate { get; set; }

        [ConcurrencyCheck]
        public DateTime? CreatedDate { get; set; }

        [ConcurrencyCheck]
        public DateTime? UpdatedDate { get; set; }

        public Agency Agency { get; set; }

        public Api Api { get; set; }

        public ApiProduct ApiProduct { get; set; }

        public MicroSite MicroSite { get; set; }

    }
}