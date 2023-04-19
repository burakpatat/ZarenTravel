using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("PossibleQuery", Schema = "dbo")]
    public partial class PossibleQuery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Query { get; set; }

        public string SystemId { get; set; }

        public int? Heavy { get; set; }

    }
}