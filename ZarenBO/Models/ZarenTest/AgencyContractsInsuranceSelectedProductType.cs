using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("AgencyContractsInsuranceSelectedProductType", Schema = "dbo")]
    public partial class AgencyContractsInsuranceSelectedProductType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? InsuranceId { get; set; }

        public int? ProductTypeId { get; set; }

    }
}