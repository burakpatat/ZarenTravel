using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("Descriptions", Schema = "dbo")]
    public partial class Description
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public int? HotelId { get; set; }

        [ConcurrencyCheck]
        public string Text { get; set; }

        public Hotel Hotel { get; set; }

    }
}