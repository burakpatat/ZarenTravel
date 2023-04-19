using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AgencyMicroSiteDomainLanguageSettings", Schema = "zaren")]
    public partial class AgencyMicroSiteDomainLanguageSetting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public int? LanguageId { get; set; }

        public bool? IsDefault { get; set; }

        public int? TableOrder { get; set; }

        public int? DomainId { get; set; }

    }
}