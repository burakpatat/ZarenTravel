using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace ZarenUI.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        [JsonIgnore, IgnoreDataMember]
        public override string PasswordHash { get; set; }

        [NotMapped]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [JsonIgnore, IgnoreDataMember, NotMapped]
        public string Name
        {
            get
            {
                return UserName;
            }
            set
            {
                UserName = value;
            }
        }
        public string FullName { get; set; }
        public int CountryId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string ProfilePhoto { get; set; }
        public string FacebookId { get; set; }
        public string GoogleId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public ICollection<ApplicationRole> Roles { get; set; }
    }
}