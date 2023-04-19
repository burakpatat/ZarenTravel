using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("Api", Schema = "dbo")]
    public partial class Api
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string ApiName { get; set; }

        [ConcurrencyCheck]
        public string UserKey { get; set; }

        [ConcurrencyCheck]
        public string Password { get; set; }

        public ICollection<ApiProduct> ApiProducts { get; set; }

        public ICollection<AutoComplete> AutoCompletes { get; set; }

        public ICollection<HotelCategory> HotelCategories { get; set; }

        public ICollection<Hotel> Hotels { get; set; }

        public ICollection<MicroSiteApiProvider> MicroSiteApiProviders { get; set; }

    }
}