using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Suppliers", Schema = "dbo")]
    public partial class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? SupplierId { get; set; }

        public string Name { get; set; }

        [Required]
        public string BriefDescription { get; set; }

        public string Website { get; set; }

        public int? SourceMarketCountryId { get; set; }

        public string Logo { get; set; }

        public bool? AcceptSupplier { get; set; }

        public bool? AcceptReseller { get; set; }

        public bool? AcceptProducts { get; set; }

        public int? SupplierTypeId { get; set; }

        public bool? IsSupplier { get; set; }

        public bool? IsReseller { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public ICollection<SupplierBuyingDestination> SupplierBuyingDestinations { get; set; }

        public ICollection<SupplierFee> SupplierFees { get; set; }

        public ICollection<SupplierRegisteredProduct> SupplierRegisteredProducts { get; set; }

        public Supplier Supplier1 { get; set; }

        public ICollection<Supplier> Suppliers1 { get; set; }

        public SupplierType SupplierType { get; set; }

        public ICollection<SupplierSellingDestination> SupplierSellingDestinations { get; set; }

    }
}