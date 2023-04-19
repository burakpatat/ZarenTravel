using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravelBO.Models.zaren_prod
{
    [Table("AgencyCreditDeposit", Schema = "dbo")]
    public partial class AgencyCreditDeposit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? AgencyId { get; set; }

        public int? BalanceCurrencyId { get; set; }

        public decimal? BalanceAmount { get; set; }

        public bool? SendBalanceWarning { get; set; }

        public decimal? AgencyBalanceWarningAmount { get; set; }

        public int? AgencyBalanceWarningIsByPercentage { get; set; }

        public int? AgencyBalanceWarningCurrencyId { get; set; }

    }
}