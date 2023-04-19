using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("PaymentTransactionResponseType", Schema = "dbo")]
    public partial class PaymentTransactionResponseType
    {
        public int? Id { get; set; }

        public string Description { get; set; }

    }
}