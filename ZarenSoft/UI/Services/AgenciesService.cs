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
    public class AgenciesService
    {
        private readonly AppDBContext _appDBContext;
        public AgenciesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Agencies>> GetAllAgenciesForDropDownAsync()
        {
            return await _appDBContext.Agencies.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Agencies>> GetAllAgenciesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Agencies.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountAgenciesAsync()
        {
            return await _appDBContext.Agencies.CountAsync();
        }
        public async Task<List<Agencies>> SearchAllAgenciesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Agencies.Where(i=> i.Name.Contains(searchKey) || i.Address.Contains(searchKey) || i.PaymentPolitics.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountAgenciesAsync(string searchKey)
        {
            return await _appDBContext.Agencies.Where(i=> i.Name.Contains(searchKey) || i.Address.Contains(searchKey) || i.PaymentPolitics.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertAgenciesAsync(Agencies data)
        {
            await _appDBContext.Agencies.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Agencies> GetAgenciesAsync(int Id)
        {
            Agencies data = await _appDBContext.Agencies.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateAgenciesAsync(Agencies data)
        {
            _appDBContext.Agencies.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAgenciesAsync(Agencies data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

