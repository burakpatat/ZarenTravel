using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class BrokerGetByBrokerCode
    {
        public int Id { get; set; }

        public string BrokerCode { get; set; }

        public string BrokerName { get; set; }

        public DateTime? BrokerTimestamp { get; set; }

        public bool? BrokerActive { get; set; }

    }
}