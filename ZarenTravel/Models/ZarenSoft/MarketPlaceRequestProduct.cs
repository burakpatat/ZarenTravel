using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("MarketPlaceRequestProducts", Schema = "dbo")]
    public partial class MarketPlaceRequestProduct
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int? RequestProcessId { get; set; }

        public int? ProductId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

    }
}