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
    public class ProvidersService
    {
        private readonly AppDBContext _appDBContext;
        public ProvidersService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Providers>> GetAllProvidersForDropDownAsync()
        {
            return await _appDBContext.Providers.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Providers>> GetAllProvidersAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Providers.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountProvidersAsync()
        {
            return await _appDBContext.Providers.CountAsync();
        }
        public async Task<List<Providers>> SearchAllProvidersAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Providers.Where(i=> i.Name.Contains(searchKey) || i.Address.Contains(searchKey) || i.Website.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountProvidersAsync(string searchKey)
        {
            return await _appDBContext.Providers.Where(i=> i.Name.Contains(searchKey) || i.Address.Contains(searchKey) || i.Website.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertProvidersAsync(Providers data)
        {
            await _appDBContext.Providers.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Providers> GetProvidersAsync(int Id)
        {
            Providers data = await _appDBContext.Providers.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateProvidersAsync(Providers data)
        {
            _appDBContext.Providers.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteProvidersAsync(Providers data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

