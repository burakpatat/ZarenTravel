using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("AgencyContractsInsuranceSelectedLanguage", Schema = "dbo")]
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