using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("PaymentOptions", Schema = "dbo")]
    public partial class PaymentOption
    {
        public int? Id { get; set; }

        public string Description { get; set; }

        public bool? IsActive { get; set; }

    }
}