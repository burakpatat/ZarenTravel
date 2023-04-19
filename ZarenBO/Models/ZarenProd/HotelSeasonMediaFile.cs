using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("HotelSeasonMediaFiles", Schema = "dbo")]
    public partial class HotelSeasonMediaFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? ApiId { get; set; }

        public string SystemId { get; set; }

        public int? LanguageId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public string UrlFull { get; set; }

        public string Url { get; set; }

        public int? FileType { get; set; }

        public int? SeasonId { get; set; }

        public int? Type { get; set; }

    }
}