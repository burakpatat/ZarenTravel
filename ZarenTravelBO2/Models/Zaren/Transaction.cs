using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("Transactions", Schema = "dbo")]
    public partial class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string IdGuid { get; set; }

        public DateTime? CreatedDate { get; set; }

        public decimal? TotalAmount { get; set; }

        public string UserId { get; set; }

        public bool? IsSuccess { get; set; }

        public string NameSurname { get; set; }

        public int? Language { get; set; }

        public bool? Is3D { get; set; }

        public int? Currency { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string BillingAddress { get; set; }

        public string City { get; set; }

        public string Provience { get; set; }

        public string CompanyName { get; set; }

        public bool? HasKvkkPermission { get; set; }

        public bool? HasPrivacy { get; set; }

        public int? PaymentConfigurationId { get; set; }

        public string PaymentUrl { get; set; }

        public int? ReservationId { get; set; }

        public ICollection<PaymentLog> PaymentLogs { get; set; }

        public ICollection<TransactionDetail> TransactionDetails { get; set; }

        public Currency Currency1 { get; set; }

        public Language Language1 { get; set; }

        public PaymentConfiguration PaymentConfiguration { get; set; }

    }
}