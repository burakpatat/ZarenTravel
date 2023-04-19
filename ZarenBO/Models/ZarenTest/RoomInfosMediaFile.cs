using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("RoomInfosMediaFiles", Schema = "dbo")]
    public partial class RoomInfosMediaFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? MedaFileId { get; set; }

        public int? RoomInfoId { get; set; }

        public int? ApiId { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? LanguageId { get; set; }

        public string SystemId { get; set; }

        public Agency Agency { get; set; }

        public Language Language { get; set; }

    }
}