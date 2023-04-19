using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payzee.Models.Payment3
{
    [Table("TestCards", Schema = "dbo")]
    public partial class TestCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? PaymentConfigurationId { get; set; }

        public string BankName { get; set; }

        public string CardNo { get; set; }

        public string ValidDate { get; set; }

        public string CVV { get; set; }

        public string ThreeDPassword { get; set; }

        public string CardType { get; set; }

        public string CardScheme { get; set; }

        public string ResponseType { get; set; }

        public PaymentConfiguration PaymentConfiguration { get; set; }

    }
}