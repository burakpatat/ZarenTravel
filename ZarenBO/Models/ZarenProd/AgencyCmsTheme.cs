using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("AgencyCmsThemes", Schema = "dbo")]
    public partial class AgencyCmsTheme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int? Orders { get; set; }

        public string ImagePath { get; set; }

        public string ImageLink { get; set; }

        public bool? IsMainTheme { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public Agency Agency { get; set; }

    }
}