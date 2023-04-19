using System;
using System.Collections.Generic;
using System.Text;

namespace Zaren.Shared.BookingModels
{
    public class BookingFormsViewModel
    {
        public List<Zaren.Domain.SetReservation.Traveller> travellers { get; set; }
        public int travellernumber { get; set; }
        public string offerId { get; set; }
        public string currency { get; set; }
        public string culture { get; set; }
    }
}
