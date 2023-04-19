using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("Rooms", Schema = "dbo")]
    public partial class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SystemId { get; set; }

        public string OfferId { get; set; }

        public string Name { get; set; }

        public int? AccomId { get; set; }

        public string AccomName { get; set; }

        public int? BoardId { get; set; }

        public string BoardName { get; set; }

        public int? Allotment { get; set; }

        public int? StopSaleGuaranteed { get; set; }

        public int? StopSaleStandart { get; set; }

        public int? PriceId { get; set; }

        public string Code { get; set; }

        public int? RoomMediaFileId { get; set; }

        public int? PresentationId { get; set; }

        public int? RoomFacilityId { get; set; }

        public int? ApiId { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? LanguageId { get; set; }

        public int? HotelId { get; set; }

        public int? Type { get; set; }

    }
}