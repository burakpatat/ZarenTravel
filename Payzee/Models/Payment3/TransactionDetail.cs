using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payzee.Models.Payment3
{
    [Table("TransactionDetails", Schema = "dbo")]
    public partial class TransactionDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? TransactionId { get; set; }

        public string UserAgent { get; set; }

        public string IP { get; set; }

        public string CardNumber { get; set; }

        public string CardHolderNameSurname { get; set; }

        public Transaction Transaction { get; set; }

    }
}