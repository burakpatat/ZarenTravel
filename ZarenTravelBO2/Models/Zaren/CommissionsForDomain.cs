using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("CommissionsForDomain", Schema = "dbo")]
    public partial class CommissionsForDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Domain { get; set; }

        public string AgentName { get; set; }

        public decimal? HotelCommission { get; set; }

        public decimal? FlightCommission { get; set; }

    }
}