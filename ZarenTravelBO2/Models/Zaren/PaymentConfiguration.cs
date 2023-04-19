using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("PaymentConfiguration", Schema = "dbo")]
    public partial class PaymentConfiguration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PaymentCompany { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int? Language { get; set; }

        public string TestSecurityUrl { get; set; }

        public string ProdSecurityUrl { get; set; }

        public string HashPassword { get; set; }

        public string OkUrl { get; set; }

        public string FailUrl { get; set; }

        public string UserId { get; set; }

        public string MemberId { get; set; }

        public string MerchantId { get; set; }

        public string UserCode { get; set; }

        public string TxnType { get; set; }

        public string TestPaymentUrl { get; set; }

        public string ProdPaymentUrl { get; set; }

        public Language Language1 { get; set; }

        public ICollection<TestCard> TestCards { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

    }
}