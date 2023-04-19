using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("SupplierRegisteredProducts", Schema = "dbo")]
    public partial class SupplierRegisteredProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ContractInfo { get; set; }

        [Required]
        public int SupplierId { get; set; }

        public int? ProductTypeId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int? Fee { get; set; }

        public Supplier Supplier { get; set; }

    }
}