using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models.TravelCDb
{
    [Table("AgencyUsers", Schema = "dbo")]
    public partial class AgencyUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string UserName { get; set; }

        [ConcurrencyCheck]
        public bool? IsB2C { get; set; }

        [ConcurrencyCheck]
        public bool? IsB2B { get; set; }

        [ConcurrencyCheck]
        public DateTime? CreatedDate { get; set; }

        [ConcurrencyCheck]
        public DateTime? UpdatedDate { get; set; }

        [ConcurrencyCheck]
        public int? CreatedBy { get; set; }

        [ConcurrencyCheck]
        public int? UpdatedBy { get; set; }

        [ConcurrencyCheck]
        public string Password { get; set; }

        [ConcurrencyCheck]
        public string Email { get; set; }

        [ConcurrencyCheck]
        public string ForwardToEmail { get; set; }

        [ConcurrencyCheck]
        public string Phone { get; set; }

        [ConcurrencyCheck]
        public int? Gender { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }

        [ConcurrencyCheck]
        public string Surname { get; set; }

        [ConcurrencyCheck]
        public int? Country { get; set; }

        [ConcurrencyCheck]
        public DateTime? BirthDate { get; set; }

        [ConcurrencyCheck]
        public string DocumentNumber { get; set; }

        [ConcurrencyCheck]
        public string ExternalCode { get; set; }

        [ConcurrencyCheck]
        public string Remark { get; set; }

        [ConcurrencyCheck]
        public int? AgencyId { get; set; }

        [ConcurrencyCheck]
        public int? Statu { get; set; }

        [ConcurrencyCheck]
        public decimal? ManagementFeeAmount { get; set; }

        [ConcurrencyCheck]
        public bool? ManagementFeeByPercentage { get; set; }

        [ConcurrencyCheck]
        public int? ManagementFeeCurrencyId { get; set; }

        public ICollection<AgencyManager> AgencyManagers { get; set; }

        public Agency Agency { get; set; }

        public Country Country1 { get; set; }

        public Gender Gender1 { get; set; }

        public Currency Currency { get; set; }

        public Statu Statu1 { get; set; }

    }
}