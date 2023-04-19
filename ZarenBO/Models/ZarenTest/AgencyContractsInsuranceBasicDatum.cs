using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("AgencyContractsInsuranceBasicData", Schema = "dbo")]
    public partial class AgencyContractsInsuranceBasicDatum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int? CreateBy { get; set; }

        public int? UpdateBy { get; set; }

        public bool? IsActive { get; set; }

        public string PolicyName { get; set; }

        public string PolicyNumber { get; set; }

        public int? InsuranceTypeId { get; set; }

        public bool? SelectByDefault { get; set; }

        public int? SupplierId { get; set; }

        public int? ServiceProviderId { get; set; }

        public int? SelectedInsuranceLanguageId { get; set; }

        public int? InsuranceSelectedProductTypeId { get; set; }

        public string ImageUrl { get; set; }

        public string ImagePath { get; set; }

    }
}