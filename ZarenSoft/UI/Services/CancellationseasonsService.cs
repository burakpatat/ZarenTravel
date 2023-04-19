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
    public class CancellationseasonsService
    {
        private readonly AppDBContext _appDBContext;
        public CancellationseasonsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Cancellationseasons>> GetAllCancellationseasonsForDropDownAsync()
        {
            return await _appDBContext.Cancellationseasons.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Cancellationseasons>> GetAllCancellationseasonsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Cancellationseasons.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountCancellationseasonsAsync()
        {
            return await _appDBContext.Cancellationseasons.CountAsync();
        }
        public async Task<List<Cancellationseasons>> SearchAllCancellationseasonsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Cancellationseasons.Where(i=> i.Id== Convert.ToInt32(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountCancellationseasonsAsync(string searchKey)
        {
            return await _appDBContext.Cancellationseasons.Where(i=> i.Id== Convert.ToInt32(searchKey)).CountAsync();
        }
        public async Task<bool> InsertCancellationseasonsAsync(Cancellationseasons data)
        {
            await _appDBContext.Cancellationseasons.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Cancellationseasons> GetCancellationseasonsAsync(int Id)
        {
            Cancellationseasons data = await _appDBContext.Cancellationseasons.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateCancellationseasonsAsync(Cancellationseasons data)
        {
            _appDBContext.Cancellationseasons.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCancellationseasonsAsync(Cancellationseasons data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

