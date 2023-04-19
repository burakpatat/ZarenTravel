using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("InsuranceSelectedLang", Schema = "dbo")]
    public partial class InsuranceSelectedLang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? LangId { get; set; }

        public int? InsurancesId { get; set; }

    }
}