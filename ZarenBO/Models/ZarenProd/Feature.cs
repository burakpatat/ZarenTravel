using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("Features", Schema = "dbo")]
    public partial class Feature
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CommercialName { get; set; }

        public int? ServiceGroupId { get; set; }

        public int? PricingTypeId { get; set; }

        public int? ApiId { get; set; }

        public int? LanguageId { get; set; }

        public string SystemId { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? FlightBrandsId { get; set; }

    }
}