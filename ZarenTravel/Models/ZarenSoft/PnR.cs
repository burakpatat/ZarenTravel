using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("PNRs", Schema = "dbo")]
    public partial class PnR
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AgencyId { get; set; }

        public int? PCCId { get; set; }

        public int? CompanyId { get; set; }

        public int? PassengerId { get; set; }

        public string PNRRecord { get; set; }

        public DateTime? PNRTimestamp { get; set; }

        public bool? PNRActive { get; set; }

        public ICollection<Air> Airs { get; set; }

        public ICollection<CarRent> CarRents { get; set; }

        public ICollection<PnrCustomField> PnrCustomFields { get; set; }

        public Agency Agency { get; set; }

        public Company Company { get; set; }

        public Passenger Passenger { get; set; }

    }
}