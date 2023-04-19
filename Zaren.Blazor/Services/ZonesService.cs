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
    public class ZonesService
    {
        private readonly AppDBContext _appDBContext;
        public ZonesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Zones>> GetAllZonesForDropDownAsync()
        {
            return await _appDBContext.Zones.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Zones>> GetAllZonesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Zones.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountZonesAsync()
        {
            return await _appDBContext.Zones.CountAsync();
        }
        public async Task<List<Zones>> SearchAllZonesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Zones.Where(i=> i.Name.Contains(searchKey) || i.LatLongBounds.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountZonesAsync(string searchKey)
        {
            return await _appDBContext.Zones.Where(i=> i.Name.Contains(searchKey) || i.LatLongBounds.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertZonesAsync(Zones data)
        {
            await _appDBContext.Zones.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Zones> GetZonesAsync(int Id)
        {
            Zones data = await _appDBContext.Zones.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateZonesAsync(Zones data)
        {
            _appDBContext.Zones.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteZonesAsync(Zones data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

