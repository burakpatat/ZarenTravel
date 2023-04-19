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
    public class StoresService
    {
        private readonly AppDBContext _appDBContext;
        public StoresService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Stores>> GetAllStoresForDropDownAsync()
        {
            return await _appDBContext.Stores.OrderBy(i => i.store_id).ToListAsync();
        }
        public async Task<List<Stores>> GetAllStoresAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Stores.OrderBy(i=>i.store_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountStoresAsync()
        {
            return await _appDBContext.Stores.CountAsync();
        }
        public async Task<List<Stores>> SearchAllStoresAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Stores.Where(i=> i.store_name.Contains(searchKey) || i.phone.Contains(searchKey) || i.email.Contains(searchKey) || i.street.Contains(searchKey) || i.city.Contains(searchKey) || i.state.Contains(searchKey) || i.zip_code.Contains(searchKey)).OrderBy(i => i.store_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountStoresAsync(string searchKey)
        {
            return await _appDBContext.Stores.Where(i=> i.store_name.Contains(searchKey) || i.phone.Contains(searchKey) || i.email.Contains(searchKey) || i.street.Contains(searchKey) || i.city.Contains(searchKey) || i.state.Contains(searchKey) || i.zip_code.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertStoresAsync(Stores data)
        {
            await _appDBContext.Stores.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Stores> GetStoresAsync(int store_id)
        {
            Stores data = await _appDBContext.Stores.FirstOrDefaultAsync(c => c.store_id.Equals(store_id));
            return data;
        }
        public async Task<bool> UpdateStoresAsync(Stores data)
        {
            _appDBContext.Stores.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteStoresAsync(Stores data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

