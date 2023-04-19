using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("ReservationDetails", Schema = "dbo")]
    public partial class ReservationDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? RezervationID { get; set; }

        public int? PropertID { get; set; }

        public decimal? PropertPrice { get; set; }

        public string ApartPrice { get; set; }

        public Reservation Reservation { get; set; }

    }
}