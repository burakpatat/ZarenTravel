using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Reservations", Schema = "dbo")]
    public partial class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string ReferenceCode { get; set; }

        public int? CustomerID { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? FinishDate { get; set; }

        public int? PaymentType { get; set; }

        public decimal? TotalPrice { get; set; }

        public int? ApartID { get; set; }

        public bool? PaymentCompleted { get; set; }

        public string Notes { get; set; }

        public ICollection<ReservationDetail> ReservationDetails { get; set; }

    }
}