using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("Hotels", Schema = "dbo")]
    public partial class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ApiId { get; set; }

        public string SystemId { get; set; }

        public string GiataId { get; set; }

        public string FaxNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string HomePage { get; set; }

        public int? StopSaleGuaranteed { get; set; }

        public int? StopSaleStandart { get; set; }

        public double? Stars { get; set; }

        public double? Rating { get; set; }

        public string Provider { get; set; }

        public string Thumbnail { get; set; }

        public string ThumbnailFull { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? Statu { get; set; }

    }
}