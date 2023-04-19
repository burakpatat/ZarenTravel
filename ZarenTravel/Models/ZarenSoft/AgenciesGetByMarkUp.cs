using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class AgenciesGetByMarkUp
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PaymentPolitics { get; set; }

        public decimal? MarkUp { get; set; }

        public int? ComercialContactId { get; set; }

        public int? ReservationContactId { get; set; }

        public int? FinanceContactId { get; set; }

    }
}