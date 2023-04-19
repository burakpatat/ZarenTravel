using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("AirLines", Schema = "dbo")]
    public partial class AirLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool? IsMarketing { get; set; }

        public string InterNationalCode { get; set; }

        public string Thumbnail { get; set; }

        public string ThumbnailFull { get; set; }

        public string Logo { get; set; }

        public string LogoFull { get; set; }

        public string Name { get; set; }

        public int? ItemsId { get; set; }

        public int? ApiId { get; set; }

        public int? LanguageId { get; set; }

        public string SystemId { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? FlightId { get; set; }

    }
}