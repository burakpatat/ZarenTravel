using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("PaymentTransactionStatus", Schema = "dbo")]
    public partial class PaymentTransactionStatus
    {
        public int? Id { get; set; }

        public string Description { get; set; }

    }
}