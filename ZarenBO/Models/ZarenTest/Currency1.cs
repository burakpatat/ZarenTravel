using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("Currency", Schema = "dbo")]
    public partial class Currency1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CurrencyCode { get; set; }

        public string CurrencyCodeIata { get; set; }

        public string CurrencyName { get; set; }

        public DateTime? CurrencyTimeStamp { get; set; }

        public bool? CurrencyActive { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public int? UpdateBy { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? Updated { get; set; }

        public DateTime? Created { get; set; }

        public Agency Agency { get; set; }

    }
}