using BirlesikOdeme.Core.Entities.Payment;

namespace BirlesikOdeme.Core.Services.Interfaces
{
    public interface IRestService
    {
        Task<PaymentResponseModel> Sales(SalesModel salesModel);
    }
}