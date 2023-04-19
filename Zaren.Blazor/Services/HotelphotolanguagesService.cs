using Microsoft.EntityFrameworkCore;
using Zaren.Blazor.Data;
using ZarenBlazorAdmin.Model;
using Zaren.Blazor.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Services
{
    public class HotelphotolanguagesService
    {
        private readonly AppDBContext _appDBContext;
        public HotelphotolanguagesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Hotelphotolanguages>> GetAllHotelphotolanguagesForDropDownAsync()
        {
            return await _appDBContext.Hotelphotolanguages.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Hotelphotolanguages>> GetAllHotelphotolanguagesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Hotelphotolanguages.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountHotelphotolanguagesAsync()
        {
            return await _appDBContext.Hotelphotolanguages.CountAsync();
        }
        public async Task<List<Hotelphotolanguages>> SearchAllHotelphotolanguagesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Hotelphotolanguages.Where(i=> i.Description.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountHotelphotolanguagesAsync(string searchKey)
        {
            return await _appDBContext.Hotelphotolanguages.Where(i=> i.Description.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertHotelphotolanguagesAsync(Hotelphotolanguages data)
        {
            await _appDBContext.Hotelphotolanguages.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Hotelphotolanguages> GetHotelphotolanguagesAsync(int Id)
        {
            Hotelphotolanguages data = await _appDBContext.Hotelphotolanguages.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateHotelphotolanguagesAsync(Hotelphotolanguages data)
        {
            _appDBContext.Hotelphotolanguages.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteHotelphotolanguagesAsync(Hotelphotolanguages data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

