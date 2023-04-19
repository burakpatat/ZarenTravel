using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("Country", Schema = "dbo")]
    public partial class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }

        [ConcurrencyCheck]
        public string ShortName { get; set; }

        [ConcurrencyCheck]
        public string Temperature { get; set; }

        [ConcurrencyCheck]
        public string Area { get; set; }

        [ConcurrencyCheck]
        public string Religion { get; set; }

        [ConcurrencyCheck]
        public string Location { get; set; }

        [ConcurrencyCheck]
        public int? Population { get; set; }

        [ConcurrencyCheck]
        public string Density { get; set; }

        [ConcurrencyCheck]
        public string Symbol { get; set; }

        [ConcurrencyCheck]
        public string Abbreviation { get; set; }

        [ConcurrencyCheck]
        public string FlagBase64 { get; set; }

        [ConcurrencyCheck]
        public string Expectancy { get; set; }

        [ConcurrencyCheck]
        public string Dish { get; set; }

        [ConcurrencyCheck]
        public string LanguagesJSON { get; set; }

        [ConcurrencyCheck]
        public string Landlocked { get; set; }

        [ConcurrencyCheck]
        public string Iso { get; set; }

        [ConcurrencyCheck]
        public string Independence { get; set; }

        [ConcurrencyCheck]
        public string Government { get; set; }

        [ConcurrencyCheck]
        public string North { get; set; }

        [ConcurrencyCheck]
        public string South { get; set; }

        [ConcurrencyCheck]
        public string West { get; set; }

        [ConcurrencyCheck]
        public string East { get; set; }

        [ConcurrencyCheck]
        public string Elevation { get; set; }

        [ConcurrencyCheck]
        public string DomainTld { get; set; }

        [ConcurrencyCheck]
        public string CurrencyName { get; set; }

        [ConcurrencyCheck]
        public string CurrencyCode { get; set; }

        [ConcurrencyCheck]
        public string CostLine { get; set; }

        [ConcurrencyCheck]
        public string Continent { get; set; }

        [ConcurrencyCheck]
        public string City { get; set; }

        [ConcurrencyCheck]
        public string CallingCode { get; set; }

        [ConcurrencyCheck]
        public string Barcode { get; set; }

        [ConcurrencyCheck]
        public string Height { get; set; }

        [ConcurrencyCheck]
        public int? DefaultLanguageId { get; set; }

        [ConcurrencyCheck]
        public int? HasFraudRiskId { get; set; }

        [ConcurrencyCheck]
        public bool? HasManuelRegistration { get; set; }

        [ConcurrencyCheck]
        public string Logo { get; set; }

        public ICollection<Agency> Agencies { get; set; }

        public ICollection<AgencyUser> AgencyUsers { get; set; }

        public ICollection<City> Cities { get; set; }

        public Language Language { get; set; }

        public MicroSiteCountriesFraudRisk MicroSiteCountriesFraudRisk { get; set; }

        public ICollection<MicroSiteInvoice> MicroSiteInvoices { get; set; }

    }
}