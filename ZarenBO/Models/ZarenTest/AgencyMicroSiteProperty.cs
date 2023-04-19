using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("AgencyMicroSiteProperties", Schema = "dbo")]
    public partial class AgencyMicroSiteProperty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AgencyMicroSiteId { get; set; }

        public string DefaultLogo { get; set; }

        public bool? HasLogoOnHeader { get; set; }

        public string WhiteLogo { get; set; }

        public string MobileLogo { get; set; }

        public string Favicon { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string OgImage { get; set; }

        public string OgDescription { get; set; }

        public string OgTitle { get; set; }

    }
}