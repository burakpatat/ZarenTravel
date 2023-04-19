using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class ContactsGetByEmail
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string TelNumber { get; set; }

        public string FaxNumber { get; set; }

        public string Email { get; set; }

    }
}