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
    public class HoteldescriptionsService
    {
        private readonly AppDBContext _appDBContext;
        public HoteldescriptionsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Hoteldescriptions>> GetAllHoteldescriptionsForDropDownAsync()
        {
            return await _appDBContext.Hoteldescriptions.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Hoteldescriptions>> GetAllHoteldescriptionsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Hoteldescriptions.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountHoteldescriptionsAsync()
        {
            return await _appDBContext.Hoteldescriptions.CountAsync();
        }
        public async Task<List<Hoteldescriptions>> SearchAllHoteldescriptionsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Hoteldescriptions.Where(i=> i.Description.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountHoteldescriptionsAsync(string searchKey)
        {
            return await _appDBContext.Hoteldescriptions.Where(i=> i.Description.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertHoteldescriptionsAsync(Hoteldescriptions data)
        {
            await _appDBContext.Hoteldescriptions.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Hoteldescriptions> GetHoteldescriptionsAsync(int Id)
        {
            Hoteldescriptions data = await _appDBContext.Hoteldescriptions.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateHoteldescriptionsAsync(Hoteldescriptions data)
        {
            _appDBContext.Hoteldescriptions.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteHoteldescriptionsAsync(Hoteldescriptions data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

