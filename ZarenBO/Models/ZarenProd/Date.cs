using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("Dates", Schema = "dbo")]
    public partial class Date
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Date")]
        public DateTime? Date1 { get; set; }

        public string DepartureCode { get; set; }

        public string ArrivalCode { get; set; }

        public int? DepartureType { get; set; }

        public int? ArrivalType { get; set; }

        public int? ApiId { get; set; }

        public int? LanguageId { get; set; }

    }
}