using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("SeasonMediaFiles", Schema = "dbo")]
    public partial class SeasonMediaFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? SeasonId { get; set; }

        public int? MediaFileId { get; set; }

        public int? ApiId { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? LanguageId { get; set; }

        public string SystemId { get; set; }

        public string Url { get; set; }

        public string UrlFull { get; set; }

        public int? FileType { get; set; }

        public int? Type { get; set; }

    }
}