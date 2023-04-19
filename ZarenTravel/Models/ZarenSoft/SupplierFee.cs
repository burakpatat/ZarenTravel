using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("SupplierFees", Schema = "dbo")]
    public partial class SupplierFee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? SupplierId { get; set; }

        public int? ProductId { get; set; }

        public int? Amount { get; set; }

        public int? CurrencyId { get; set; }

        public bool? ByPercentage { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public Supplier Supplier { get; set; }

    }
}