using BirlesikOdemeTest.Core.Models.DBModels;
using BirlesikOdemeTest.Data.Entities.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdemeTest.Core.Services
{
   public interface ICustomerService
    {
      
        public Task<IServiceResponse> InsertCustomer(Customer customer);
        public Task<IServiceResponse> VerifyCustomer(CustomerRequestModel customer);
        public IServiceDataResponse<Customer> GetCustomerByIdentityNumber(long identityNo);
        
        

    }
}
