using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class PnRsGetByPassengerId
    {
        public int Id { get; set; }

        public int? AgencyId { get; set; }

        public int? PCCId { get; set; }

        public int? CompanyId { get; set; }

        public int? PassengerId { get; set; }

        public string PNRRecord { get; set; }

        public DateTime? PNRTimestamp { get; set; }

        public bool? PNRActive { get; set; }

    }
}