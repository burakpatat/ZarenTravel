using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("FlightClasses", Schema = "dbo")]
    public partial class FlightClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Type { get; set; }

        public string Code { get; set; }

        public int? SegmentId { get; set; }

        public int? FlightItemId { get; set; }

        public int? FlightId { get; set; }

        public string SystemId { get; set; }

        public int? ApiId { get; set; }

        public int? LanguageId { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

    }
}