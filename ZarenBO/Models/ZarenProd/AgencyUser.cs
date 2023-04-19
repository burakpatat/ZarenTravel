using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("AgencyUsers", Schema = "dbo")]
    public partial class AgencyUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserName { get; set; }

        public bool? IsB2C { get; set; }

        public bool? IsB2B { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string ForwardToEmail { get; set; }

        public string Phone { get; set; }

        public int? Gender { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int? Country { get; set; }

        public DateTime? BirthDate { get; set; }

        public string DocumentNumber { get; set; }

        public string ExternalCode { get; set; }

        public string Remark { get; set; }

        public int? AgencyId { get; set; }

        public int? Statu { get; set; }

        public decimal? ManagementFeeAmount { get; set; }

        public bool? ManagementFeeByPercentage { get; set; }

        public int? ManagementFeeCurrencyId { get; set; }

    }
}