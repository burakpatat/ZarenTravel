using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("BaggageInformations", Schema = "dbo")]
    public partial class BaggageInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? SegmentsId { get; set; }

        public int? Weight { get; set; }

        public int? Piece { get; set; }

        public int? BaggageTypesId { get; set; }

        public int? BaggageUnitTypesId { get; set; }

        public int? PassengerTypesId { get; set; }

        public string Descriptions { get; set; }

        public int? FlightId { get; set; }

        public int? ItemsId { get; set; }

        public int? OffersId { get; set; }

        public int? ApiId { get; set; }

        public int? LanguageId { get; set; }

        public string SystemId { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

    }
}