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
    public class HotelbuyroomsService
    {
        private readonly AppDBContext _appDBContext;
        public HotelbuyroomsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Hotelbuyrooms>> GetAllHotelbuyroomsForDropDownAsync()
        {
            return await _appDBContext.Hotelbuyrooms.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Hotelbuyrooms>> GetAllHotelbuyroomsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Hotelbuyrooms.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountHotelbuyroomsAsync()
        {
            return await _appDBContext.Hotelbuyrooms.CountAsync();
        }
        public async Task<List<Hotelbuyrooms>> SearchAllHotelbuyroomsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Hotelbuyrooms.Where(i=> i.Id== Convert.ToInt32(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountHotelbuyroomsAsync(string searchKey)
        {
            return await _appDBContext.Hotelbuyrooms.Where(i=> i.Id== Convert.ToInt32(searchKey)).CountAsync();
        }
        public async Task<bool> InsertHotelbuyroomsAsync(Hotelbuyrooms data)
        {
            await _appDBContext.Hotelbuyrooms.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Hotelbuyrooms> GetHotelbuyroomsAsync(int Id)
        {
            Hotelbuyrooms data = await _appDBContext.Hotelbuyrooms.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateHotelbuyroomsAsync(Hotelbuyrooms data)
        {
            _appDBContext.Hotelbuyrooms.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteHotelbuyroomsAsync(Hotelbuyrooms data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

