using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("Hotels", Schema = "dbo")]
    public partial class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }

        [ConcurrencyCheck]
        public int? ApiId { get; set; }

        [ConcurrencyCheck]
        public string SystemId { get; set; }

        [ConcurrencyCheck]
        public string GiataId { get; set; }

        [ConcurrencyCheck]
        public string FaxNumber { get; set; }

        [ConcurrencyCheck]
        public string PhoneNumber { get; set; }

        [ConcurrencyCheck]
        public string HomePage { get; set; }

        [ConcurrencyCheck]
        public int? StopSaleGuaranteed { get; set; }

        [ConcurrencyCheck]
        public int? StopSaleStandart { get; set; }

        [ConcurrencyCheck]
        public double? Stars { get; set; }

        [ConcurrencyCheck]
        public double? Rating { get; set; }

        [ConcurrencyCheck]
        public string Provider { get; set; }

        [ConcurrencyCheck]
        public string Thumbnail { get; set; }

        [ConcurrencyCheck]
        public string ThumbnailFull { get; set; }

        [ConcurrencyCheck]
        public DateTime? CreatedDate { get; set; }

        [ConcurrencyCheck]
        public DateTime? UpdatedDate { get; set; }

        [ConcurrencyCheck]
        public int? CreatedBy { get; set; }

        [ConcurrencyCheck]
        public int? UpdatedBy { get; set; }

        [ConcurrencyCheck]
        public int? Statu { get; set; }

        [ConcurrencyCheck]
        public string Code { get; set; }

        [ConcurrencyCheck]
        public int? AgencyId { get; set; }

        [ConcurrencyCheck]
        public int? MicroSiteId { get; set; }

        [ConcurrencyCheck]
        public string Adress { get; set; }

        [ConcurrencyCheck]
        public int? FraudRiskId { get; set; }

        [ConcurrencyCheck]
        public int? ManuelRegistrationId { get; set; }

        public ICollection<Description> Descriptions { get; set; }

        public Agency Agency { get; set; }

        public Api Api { get; set; }

        public FraudRisk FraudRisk { get; set; }

        public ManuelRegistration ManuelRegistration { get; set; }

        public MicroSite MicroSite { get; set; }

        public Statu Statu1 { get; set; }

        public ICollection<RoomsSelectedHotel> RoomsSelectedHotels { get; set; }

    }
}