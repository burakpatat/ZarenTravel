using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("Hotels", Schema = "dbo")]
    public partial class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? HotelId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public int? Provider { get; set; }

        public string Thumbnail { get; set; }

        public string ThumbnailFull { get; set; }

        public int? VillageId { get; set; }

        public int? TownId { get; set; }

        public int? CityId { get; set; }

        public int? CountryId { get; set; }

        public int? GiataInfoId { get; set; }

        public string FaxNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string HomePage { get; set; }

        public int? HotelCategoryId { get; set; }

        public string SystemId { get; set; }

        public int? ApiId { get; set; }

        public int? AgencyId { get; set; }

        public int? MicroSiteId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? LanguageId { get; set; }

        public double? Latitude { get; set; }

        public double? Longtitude { get; set; }

    }
}