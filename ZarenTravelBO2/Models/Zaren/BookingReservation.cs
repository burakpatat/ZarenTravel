using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("BookingReservations", Schema = "dbo")]
    public partial class BookingReservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ReservationNumber { get; set; }

        public string OfferId { get; set; }

        public string Note { get; set; }

        public string CookieId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string Guid { get; set; }

        public string UserId { get; set; }

        public int? ProductType { get; set; }

        public DateTime? BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string ProductId { get; set; }

        public DateTime? ExpireDate { get; set; }

        public int? HasPaid { get; set; }

        public string Currency { get; set; }

        public string Culture { get; set; }

        public string UserAgent { get; set; }

        public string UserIp { get; set; }

        public int? Status { get; set; }

        public string TransactionId { get; set; }

        public bool? OnBasket { get; set; }

        public string JsonData { get; set; }

        public AspNetUser AspNetUser { get; set; }

    }
}