using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenBO2.Models.Zaren
{
    [Table("AspNetUsers", Schema = "zaren")]
    public partial class AspNetUser
    {
        [Key]
        [Required]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string ConcurrencyStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public bool LockoutEnabled { get; set; }

        [Required]
        public int AccessFailedCount { get; set; }

        public string FullName { get; set; }

        public int? CountryId { get; set; }

        [Column(TypeName="datetime2")]
        public DateTime? DateOfBirth { get; set; }

        public int? Gender { get; set; }

        public string Address { get; set; }

        public string ProfilePhoto { get; set; }

        public string FacebookId { get; set; }

        public string GoogleId { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public ICollection<BookingReservation> BookingReservations { get; set; }

        public ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }

        public ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }

        public ICollection<AspNetUserRole> AspNetUserRoles { get; set; }

    }
}