using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class TerminalGetByTerminalCode
    {
        public int Id { get; set; }

        public string TerminalName { get; set; }

        public string TerminalCode { get; set; }

        public int? AirportId { get; set; }

        public DateTime? TerminalTimestamp { get; set; }

        public bool? TerminalActive { get; set; }

    }
}