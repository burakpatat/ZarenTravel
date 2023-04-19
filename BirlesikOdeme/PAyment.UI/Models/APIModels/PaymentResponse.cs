using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdemeTest.Core.Models.APIModels
{
    public class PaymentResponse
    {
       
        public bool fail { get; set; }
        public int statusCode { get; set; }
        public ResultPayment result { get; set; }
    }

    public partial class ResultPayment
    {
        public string authCode { get; set; }
        public string hostReference { get; set; }
        public string responseCode { get; set; }
        public string responseMessage { get; set; }
        public string orderId { get; set; }
        public string bankOrderNo { get; set; }
        public string txnType { get; set; }
        public string txnStatus { get; set; }
        public string vposId { get; set; }
        public string vposName { get; set; }
        public string totalAmount { get; set; }
    }
}
