using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("AgencyMicroSiteDesign", Schema = "dbo")]
    public partial class AgencyMicroSiteDesign
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AgencyMicroSiteId { get; set; }

        public int? ProductType { get; set; }

        public int? TableOrder { get; set; }

        public int? Statu { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

    }
}