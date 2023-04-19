using Microsoft.EntityFrameworkCore;
using ZarenBlazorAdmin.Data;
using ZarenBlazorAdmin.Model;
using ZarenBlazorAdmin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Services
{
    public class CustomersService
    {
        private readonly AppDBContext _appDBContext;
        public CustomersService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Customers>> GetAllCustomersForDropDownAsync()
        {
            return await _appDBContext.Customers.OrderBy(i => i.customer_id).ToListAsync();
        }
        public async Task<List<Customers>> GetAllCustomersAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Customers.OrderBy(i=>i.customer_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountCustomersAsync()
        {
            return await _appDBContext.Customers.CountAsync();
        }
        public async Task<List<Customers>> SearchAllCustomersAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Customers.Where(i=> i.first_name.Contains(searchKey) || i.last_name.Contains(searchKey) || i.phone.Contains(searchKey) || i.email.Contains(searchKey) || i.street.Contains(searchKey) || i.city.Contains(searchKey) || i.state.Contains(searchKey) || i.zip_code.Contains(searchKey)).OrderBy(i => i.customer_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountCustomersAsync(string searchKey)
        {
            return await _appDBContext.Customers.Where(i=> i.first_name.Contains(searchKey) || i.last_name.Contains(searchKey) || i.phone.Contains(searchKey) || i.email.Contains(searchKey) || i.street.Contains(searchKey) || i.city.Contains(searchKey) || i.state.Contains(searchKey) || i.zip_code.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertCustomersAsync(Customers data)
        {
            await _appDBContext.Customers.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Customers> GetCustomersAsync(int customer_id)
        {
            Customers data = await _appDBContext.Customers.FirstOrDefaultAsync(c => c.customer_id.Equals(customer_id));
            return data;
        }
        public async Task<bool> UpdateCustomersAsync(Customers data)
        {
            _appDBContext.Customers.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCustomersAsync(Customers data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

