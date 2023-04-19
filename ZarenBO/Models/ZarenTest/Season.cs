using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("Seasons", Schema = "dbo")]
    public partial class Season
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? SeasonTextCategoryId { get; set; }

        public int? FacilitySelectedCategoryId { get; set; }

        public int? SeasonMediaFileId { get; set; }

        public int? SeasonThemeId { get; set; }

        public int? ApiId { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? LanguageId { get; set; }

        public string SystemId { get; set; }

        public int? Type { get; set; }

    }
}