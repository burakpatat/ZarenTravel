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
    public class CancellationrulesService
    {
        private readonly AppDBContext _appDBContext;
        public CancellationrulesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Cancellationrules>> GetAllCancellationrulesForDropDownAsync()
        {
            return await _appDBContext.Cancellationrules.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Cancellationrules>> GetAllCancellationrulesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Cancellationrules.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountCancellationrulesAsync()
        {
            return await _appDBContext.Cancellationrules.CountAsync();
        }
        public async Task<List<Cancellationrules>> SearchAllCancellationrulesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Cancellationrules.Where(i=> i.Id== Convert.ToInt32(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountCancellationrulesAsync(string searchKey)
        {
            return await _appDBContext.Cancellationrules.Where(i=> i.Id== Convert.ToInt32(searchKey)).CountAsync();
        }
        public async Task<bool> InsertCancellationrulesAsync(Cancellationrules data)
        {
            await _appDBContext.Cancellationrules.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Cancellationrules> GetCancellationrulesAsync(int Id)
        {
            Cancellationrules data = await _appDBContext.Cancellationrules.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateCancellationrulesAsync(Cancellationrules data)
        {
            _appDBContext.Cancellationrules.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCancellationrulesAsync(Cancellationrules data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

