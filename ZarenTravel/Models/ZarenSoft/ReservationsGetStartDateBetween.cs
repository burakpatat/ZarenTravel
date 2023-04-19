using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class ReservationsGetStartDateBetween
    {
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

    }
}