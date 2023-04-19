using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace ZarenBO2.Models
{
    public partial class ApplicationRole : IdentityRole
    {
        [JsonIgnore]
        public ICollection<ApplicationUser> Users { get; set; }

    }
}