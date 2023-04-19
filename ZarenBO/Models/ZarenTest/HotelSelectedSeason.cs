using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("HotelSelectedSeasons", Schema = "dbo")]
    public partial class HotelSelectedSeason
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? HotelId { get; set; }

        public int? SeasonId { get; set; }

    }
}