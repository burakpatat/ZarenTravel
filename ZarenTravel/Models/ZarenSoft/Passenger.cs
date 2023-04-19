using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("Passengers", Schema = "dbo")]
    public partial class Passenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PassengerFullName { get; set; }

        public string PassengerPhone { get; set; }

        public string PassengerCelPhone { get; set; }

        public string PassengerEmail { get; set; }

        public string PassengerJobPosition { get; set; }

        public bool? PassengerVIP { get; set; }

        public DateTime? PassemgerTimestamp { get; set; }

        public bool? PassengerActive { get; set; }

        public ICollection<PnR> PnRs { get; set; }

    }
}