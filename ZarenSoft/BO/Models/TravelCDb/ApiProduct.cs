using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("ApiProducts", Schema = "dbo")]
    public partial class ApiProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public int? ApiId { get; set; }

        [ConcurrencyCheck]
        public int? ProductType { get; set; }

        public Api Api { get; set; }

        public ProductType ProductType1 { get; set; }

        public ICollection<MicroSiteApiProvider> MicroSiteApiProviders { get; set; }

    }
}