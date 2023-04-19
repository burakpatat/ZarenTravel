using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("CancellationPolicies", Schema = "dbo")]
    public partial class CancellationPolicy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime? DueDate { get; set; }

        public int? PriceId { get; set; }

        public int? Provider { get; set; }

        public int? SystemId { get; set; }

        public int? ApiId { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? LanguageId { get; set; }

        public int? OfferId { get; set; }

        public decimal? Amount { get; set; }

        public string Currency { get; set; }

        public Agency Agency { get; set; }

        public Language Language { get; set; }

    }
}