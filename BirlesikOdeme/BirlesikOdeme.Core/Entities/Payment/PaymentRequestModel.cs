using BirlesikOdeme.Core.Entities.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.Core.Entities.Payment
{
    public class PaymentRequestModel : BasePaymentModel
    {
        public string cardNumber { get; set; }
        public string expiryDateMonth { get; set; }
        public string expiryDateYear { get; set; }
        public string installementCount { get; set; } = "1";
        public string currency { get; set; } = "1";
        public string hash { get; set; } //şifrelenecek metot kullanılacak.
        public string productId { get; set; } = "000032";
        public string amount { get; set; } = "100";
        public string productName { get; set; } = "Bilgisayar";
        public string commissionRate { get; set; } = "10.00";//Örneğin, %10 komisyon alınacaksa, 10.00 olarak gönderilmelidir.

    }

}
