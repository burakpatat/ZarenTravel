using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("ApiResults", Schema = "dbo")]
    public partial class ApiResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string RequestData { get; set; }

        [ConcurrencyCheck]
        public string ResponseData { get; set; }

        [ConcurrencyCheck]
        public DateTime? RequestDate { get; set; }

        [ConcurrencyCheck]
        public DateTime? ResponseDate { get; set; }

        [ConcurrencyCheck]
        public string Currency { get; set; }

        [ConcurrencyCheck]
        public string CheckIn { get; set; }

        [ConcurrencyCheck]
        public string Nationality { get; set; }

        [ConcurrencyCheck]
        public int? ApiId { get; set; }

        [ConcurrencyCheck]
        public bool? IsSuccessfull { get; set; }

        [ConcurrencyCheck]
        public int? LocationId { get; set; }

        [ConcurrencyCheck]
        public string Query { get; set; }

        [ConcurrencyCheck]
        public int? ProductType { get; set; }

        public ProductType ProductType1 { get; set; }

    }
}