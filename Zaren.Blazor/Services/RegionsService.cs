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
    public class RegionsService
    {
        private readonly AppDBContext _appDBContext;
        public RegionsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Regions>> GetAllRegionsForDropDownAsync()
        {
            return await _appDBContext.Regions.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Regions>> GetAllRegionsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Regions.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountRegionsAsync()
        {
            return await _appDBContext.Regions.CountAsync();
        }
        public async Task<List<Regions>> SearchAllRegionsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Regions.Where(i=> i.Name.Contains(searchKey) || i.LatLongBounds.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountRegionsAsync(string searchKey)
        {
            return await _appDBContext.Regions.Where(i=> i.Name.Contains(searchKey) || i.LatLongBounds.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertRegionsAsync(Regions data)
        {
            await _appDBContext.Regions.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Regions> GetRegionsAsync(int Id)
        {
            Regions data = await _appDBContext.Regions.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateRegionsAsync(Regions data)
        {
            _appDBContext.Regions.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteRegionsAsync(Regions data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

