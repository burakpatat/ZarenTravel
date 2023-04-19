using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.Core.Entities.BaseModels
{
    /// <summary>
    /// payment hash model ve request modeldeki ortak alanlar
    /// </summary>
    public abstract class BasePaymentModel
    {
        public string UserCode { get; set; } = "test";
        public string Rnd { get; set; } = "random";
        public long MemberId { get; set; } = 1;
        public long MerchantId { get; set; } = 1894;
        public string txnType { get; set; } = "Auth";
        public string TotalAmount { get; set; } = "100"; //1 tl anlamına geliyor.
        public string CustomerId { get; set; } = "murat.karayilan@dotto.com.tr"; // İster bir id ister bir email olabilir.
        public string OrderId { get; set; } = "order1"; // order bulamadım dokümandaki veriyi yazdım.

    }
}
