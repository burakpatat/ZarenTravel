using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("Arrivals", Schema = "dbo")]
    public partial class Arrival
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? Date { get; set; }

        public int? CountryId { get; set; }

        public string CitySystemId { get; set; }

        public int? AirPortsId { get; set; }

        public int? ApiId { get; set; }

        public int? LanguageId { get; set; }

        public string SystemId { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public int? FlightItemsId { get; set; }

        public int? FlightId { get; set; }

    }
}