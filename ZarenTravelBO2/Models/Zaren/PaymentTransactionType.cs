using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("PaymentTransactionTypes", Schema = "dbo")]
    public partial class PaymentTransactionType
    {
        public int? Id { get; set; }

        public string Description { get; set; }

        public string About { get; set; }

    }
}