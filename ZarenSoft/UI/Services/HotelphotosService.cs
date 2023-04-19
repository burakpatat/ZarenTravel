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
    public class HotelphotosService
    {
        private readonly AppDBContext _appDBContext;
        public HotelphotosService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Hotelphotos>> GetAllHotelphotosForDropDownAsync()
        {
            return await _appDBContext.Hotelphotos.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Hotelphotos>> GetAllHotelphotosAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Hotelphotos.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountHotelphotosAsync()
        {
            return await _appDBContext.Hotelphotos.CountAsync();
        }
        public async Task<List<Hotelphotos>> SearchAllHotelphotosAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Hotelphotos.Where(i=> i.Path.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountHotelphotosAsync(string searchKey)
        {
            return await _appDBContext.Hotelphotos.Where(i=> i.Path.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertHotelphotosAsync(Hotelphotos data)
        {
            await _appDBContext.Hotelphotos.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Hotelphotos> GetHotelphotosAsync(int Id)
        {
            Hotelphotos data = await _appDBContext.Hotelphotos.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateHotelphotosAsync(Hotelphotos data)
        {
            _appDBContext.Hotelphotos.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteHotelphotosAsync(Hotelphotos data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

