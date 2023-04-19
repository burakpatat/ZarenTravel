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
    public class HotelagencymarkupsService
    {
        private readonly AppDBContext _appDBContext;
        public HotelagencymarkupsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Hotelagencymarkups>> GetAllHotelagencymarkupsForDropDownAsync()
        {
            return await _appDBContext.Hotelagencymarkups.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Hotelagencymarkups>> GetAllHotelagencymarkupsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Hotelagencymarkups.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountHotelagencymarkupsAsync()
        {
            return await _appDBContext.Hotelagencymarkups.CountAsync();
        }
        public async Task<List<Hotelagencymarkups>> SearchAllHotelagencymarkupsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Hotelagencymarkups.Where(i=> i.Id== Convert.ToInt32(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountHotelagencymarkupsAsync(string searchKey)
        {
            return await _appDBContext.Hotelagencymarkups.Where(i=> i.Id== Convert.ToInt32(searchKey)).CountAsync();
        }
        public async Task<bool> InsertHotelagencymarkupsAsync(Hotelagencymarkups data)
        {
            await _appDBContext.Hotelagencymarkups.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Hotelagencymarkups> GetHotelagencymarkupsAsync(int Id)
        {
            Hotelagencymarkups data = await _appDBContext.Hotelagencymarkups.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateHotelagencymarkupsAsync(Hotelagencymarkups data)
        {
            _appDBContext.Hotelagencymarkups.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteHotelagencymarkupsAsync(Hotelagencymarkups data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

