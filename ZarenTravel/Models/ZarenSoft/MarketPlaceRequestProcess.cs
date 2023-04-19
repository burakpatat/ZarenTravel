using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("MarketPlaceRequestProcess", Schema = "dbo")]
    public partial class MarketPlaceRequestProcess
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? FromId { get; set; }

        public int? ToId { get; set; }

        public int? SystemApprovalStatuId { get; set; }

        public DateTime? RequestDate { get; set; }

        public DateTime? SystemResponseDate { get; set; }

        public int? ResponseStatuId { get; set; }

        public DateTime? ResponseDate { get; set; }

        public bool? Type { get; set; }

    }
}