using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("AgencyMicroSiteApiProductProviders", Schema = "dbo")]
    public partial class AgencyMicroSiteApiProductProvider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? ApiId { get; set; }

        public int? ApiProductId { get; set; }

        public int? MicroSiteId { get; set; }

        public int? Priority { get; set; }

        public int? AgencyId { get; set; }

        public bool? HasConsolidate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public Agency Agency { get; set; }

        public AgencyMicroSite AgencyMicroSite { get; set; }

    }
}