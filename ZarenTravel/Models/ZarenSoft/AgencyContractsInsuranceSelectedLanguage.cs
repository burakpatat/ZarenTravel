using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AgencyContractsInsuranceSelectedLanguage", Schema = "zaren")]
    public partial class AgencyContractsInsuranceSelectedLanguage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? LangId { get; set; }

        public int? InsurancesId { get; set; }

        public string InsuranceDescription { get; set; }

        public string VoucherRemarks { get; set; }

    }
}