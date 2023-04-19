using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("PaymentLogs", Schema = "dbo")]
    public partial class PaymentLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? TransactionId { get; set; }

        public string Request { get; set; }

        public DateTime? RequestDate { get; set; }

        public string Response { get; set; }

        public DateTime? ResponseDate { get; set; }

        public Transaction Transaction { get; set; }

    }
}