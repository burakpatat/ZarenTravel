using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_test
{
    [Table("AgencyManager", Schema = "dbo")]
    public partial class AgencyManager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AgencyUserId { get; set; }

        public int? Statu { get; set; }

        public int? MicrositeId { get; set; }

        public int? AgencyId { get; set; }

        public Agency Agency { get; set; }

        public AgencyUser AgencyUser { get; set; }

    }
}