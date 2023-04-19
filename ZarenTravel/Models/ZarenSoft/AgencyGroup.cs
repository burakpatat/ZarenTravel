using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AgencyGroup", Schema = "dbo")]
    public partial class AgencyGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? Timestamp { get; set; }

        public bool? Active { get; set; }

        public ICollection<Agency> Agencies { get; set; }

    }
}