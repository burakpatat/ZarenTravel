using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class HotelsGetAll
    {
        public int Id { get; set; }

        public int? HotelChainId { get; set; }

        public string Name { get; set; }

        public int? HotelTypeId { get; set; }

        public int? CountryId { get; set; }

        public int? RegionId { get; set; }

        public int? ZoneId { get; set; }

        public int? CityId { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public int? CommercialContactId { get; set; }

        public int? ReservationContactId { get; set; }

        public int? FinanceContactId { get; set; }

        public int? Release { get; set; }

        public int? NumberRooms { get; set; }

    }
}