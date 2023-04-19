using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class CountryGetByLandlocked
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Temperature { get; set; }

        public string Area { get; set; }

        public string Religion { get; set; }

        public string Location { get; set; }

        public string Population { get; set; }

        public string Density { get; set; }

        public string Symbol { get; set; }

        public string Abbreviation { get; set; }

        public string FlagBase64 { get; set; }

        public string Expectancy { get; set; }

        public string Dish { get; set; }

        public string LanguagesJSON { get; set; }

        public string Landlocked { get; set; }

        public string Iso { get; set; }

        public string Independence { get; set; }

        public string Government { get; set; }

        public string North { get; set; }

        public string South { get; set; }

        public string West { get; set; }

        public string East { get; set; }

        public string Elevation { get; set; }

        public string DomainTld { get; set; }

        public string CurrencyName { get; set; }

        public string CurrencyCode { get; set; }

        public string CostLine { get; set; }

        public string Continent { get; set; }

        public string City { get; set; }

        public string CallingCode { get; set; }

        public string Barcode { get; set; }

        public string Height { get; set; }

        public int? DefaultLanguageId { get; set; }

    }
}