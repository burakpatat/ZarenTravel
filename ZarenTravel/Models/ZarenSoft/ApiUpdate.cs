using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class ApiUpdate
    {
        public int Id { get; set; }

        public string ApiName { get; set; }

        public string UserKey { get; set; }

        public string Password { get; set; }

    }
}