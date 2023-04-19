using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Companies", Schema = "dbo")]
    public partial class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CompanyCode { get; set; }

        public int? AgencyId { get; set; }

        public int? CountryId { get; set; }

        public string CompanyRepresentative { get; set; }

        public int? CoGrId { get; set; }

        public int? CoDiId { get; set; }

        public int? LanguagesId { get; set; }

        public int? CurrencyId { get; set; }

        public int? InSeId { get; set; }

        public DateTime? CompanyTimestamp { get; set; }

        public bool? CompanyActive { get; set; }

        public Agency Agency { get; set; }

        public Country Country { get; set; }

        public Currency1 Currency1 { get; set; }

        public Language Language { get; set; }

        public ICollection<PnR> PnRs { get; set; }

    }
}