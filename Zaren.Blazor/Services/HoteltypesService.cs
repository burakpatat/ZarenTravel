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
    public class HoteltypesService
    {
        private readonly AppDBContext _appDBContext;
        public HoteltypesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Hoteltypes>> GetAllHoteltypesForDropDownAsync()
        {
            return await _appDBContext.Hoteltypes.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Hoteltypes>> GetAllHoteltypesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Hoteltypes.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountHoteltypesAsync()
        {
            return await _appDBContext.Hoteltypes.CountAsync();
        }
        public async Task<List<Hoteltypes>> SearchAllHoteltypesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Hoteltypes.Where(i=> i.Name.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountHoteltypesAsync(string searchKey)
        {
            return await _appDBContext.Hoteltypes.Where(i=> i.Name.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertHoteltypesAsync(Hoteltypes data)
        {
            await _appDBContext.Hoteltypes.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Hoteltypes> GetHoteltypesAsync(int Id)
        {
            Hoteltypes data = await _appDBContext.Hoteltypes.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateHoteltypesAsync(Hoteltypes data)
        {
            _appDBContext.Hoteltypes.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteHoteltypesAsync(Hoteltypes data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

