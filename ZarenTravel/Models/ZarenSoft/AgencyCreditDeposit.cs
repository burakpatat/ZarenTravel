using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    [Table("AgencyCreditDeposit", Schema = "zaren")]
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