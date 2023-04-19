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
    public class HoteltypelanguagesService
    {
        private readonly AppDBContext _appDBContext;
        public HoteltypelanguagesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Hoteltypelanguages>> GetAllHoteltypelanguagesForDropDownAsync()
        {
            return await _appDBContext.Hoteltypelanguages.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Hoteltypelanguages>> GetAllHoteltypelanguagesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Hoteltypelanguages.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountHoteltypelanguagesAsync()
        {
            return await _appDBContext.Hoteltypelanguages.CountAsync();
        }
        public async Task<List<Hoteltypelanguages>> SearchAllHoteltypelanguagesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Hoteltypelanguages.Where(i=> i.Name.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountHoteltypelanguagesAsync(string searchKey)
        {
            return await _appDBContext.Hoteltypelanguages.Where(i=> i.Name.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertHoteltypelanguagesAsync(Hoteltypelanguages data)
        {
            await _appDBContext.Hoteltypelanguages.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Hoteltypelanguages> GetHoteltypelanguagesAsync(int Id)
        {
            Hoteltypelanguages data = await _appDBContext.Hoteltypelanguages.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateHoteltypelanguagesAsync(Hoteltypelanguages data)
        {
            _appDBContext.Hoteltypelanguages.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteHoteltypelanguagesAsync(Hoteltypelanguages data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

