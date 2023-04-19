using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("CarRentals", Schema = "dbo")]
    public partial class CarRental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CaRtCode { get; set; }

        public string CaRtName { get; set; }

        public DateTime? CaRtTimestamp { get; set; }

        public bool? CaRtActive { get; set; }

        public ICollection<CarRent> CarRents { get; set; }

    }
}