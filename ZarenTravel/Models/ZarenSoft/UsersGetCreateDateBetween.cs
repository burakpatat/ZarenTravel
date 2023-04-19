using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class UsersGetCreateDateBetween
    {
        public int ID { get; set; }

        public string GovernmentID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int? Status { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool? IsMaster { get; set; }

        public int? Gender { get; set; }

        public int? UserType { get; set; }

        public DateTime? CreateDate { get; set; }

        public string BirthPlace { get; set; }

        public int? MaritalStatus { get; set; }

        public DateTime? BirthDate { get; set; }

        public string MotherName { get; set; }

        public bool? IsSuperAdmin { get; set; }

        public int? Products { get; set; }

    }
}