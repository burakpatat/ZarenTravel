using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Broker", Schema = "dbo")]
    public partial class Broker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string BrokerCode { get; set; }

        public string BrokerName { get; set; }

        public DateTime? BrokerTimestamp { get; set; }

        public bool? BrokerActive { get; set; }

        public ICollection<Air> Airs { get; set; }

    }
}