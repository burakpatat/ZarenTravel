using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("PaymentReservationStatus", Schema = "dbo")]
    public partial class PaymentReservationStatus
    {
        public int? Id { get; set; }

        public string Description { get; set; }

        public string About { get; set; }

    }
}