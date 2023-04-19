using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("AgencyContractsHotelInformation", Schema = "dbo")]
    public partial class AgencyContractsHotelInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? Agencyıd { get; set; }

        public int? MicroSiteId { get; set; }

        public int? LangId { get; set; }

        public int? HotelCategoryId { get; set; }

        public int? HotelImageId { get; set; }

        public int? HotelFacilityId { get; set; }

        public bool? IsActive { get; set; }

        public bool? OnlyHolidayPackage { get; set; }

        public int? CreatedByUser { get; set; }

        public int? SupplierBy { get; set; }

        public string HotelCode { get; set; }

        public string Name { get; set; }

        public int? HotelChainId { get; set; }

        public string Address { get; set; }

        public string LocationName { get; set; }

        public string PostalCode { get; set; }

        public int? CountryId { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public string PossibleDestinations { get; set; }

        public string Description { get; set; }

        public string Remark { get; set; }

    }
}