using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("Statu", Schema = "dbo")]
    public partial class Statu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }

        public ICollection<Agency> Agencies { get; set; }

        public ICollection<AgencyManager> AgencyManagers { get; set; }

        public ICollection<AgencyUser> AgencyUsers { get; set; }

        public ICollection<Hotel> Hotels { get; set; }

    }
}