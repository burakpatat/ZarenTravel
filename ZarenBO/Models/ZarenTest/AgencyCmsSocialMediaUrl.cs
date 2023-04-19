using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("AgencyCmsSocialMediaUrls", Schema = "dbo")]
    public partial class AgencyCmsSocialMediaUrl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public string HomeUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string YoutubeUrl { get; set; }

        public string PinterestUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string LinkedInUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string ViemoUrl { get; set; }

        public Agency Agency { get; set; }

    }
}