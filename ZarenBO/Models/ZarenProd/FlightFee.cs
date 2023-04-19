using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("FlightFees", Schema = "dbo")]
    public partial class FlightFee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Keys { get; set; }

        public int? OneRoundMultiWaysId { get; set; }

        public int? CurrencyId { get; set; }

        public int? ApiId { get; set; }

        public int? LanguageId { get; set; }

        public string SystemId { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

    }
}