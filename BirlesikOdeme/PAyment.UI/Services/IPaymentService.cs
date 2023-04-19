using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirlesikOdemeTest.Core.Models.APIModels;

namespace BirlesikOdemeTest.Core.Services
{
    public interface IPaymentService
    {

        public Task<IServiceResponse> MakePayment(string cardNumber,string expiryDateMonth, string expiryDateYear,string cvv,string cardAlias, int customerId);
        public string CreateHash(PaymentRequest req);
       
        

    }
}
