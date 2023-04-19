using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AgencyContractsInsuranceSelectedProductType", Schema = "zaren")]
    public partial class AgencyContractsInsuranceSelectedProductType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? InsuranceId { get; set; }

        public int? ProductTypeId { get; set; }

    }
}