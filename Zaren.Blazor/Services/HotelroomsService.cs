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
    public class HotelroomsService
    {
        private readonly AppDBContext _appDBContext;
        public HotelroomsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Hotelrooms>> GetAllHotelroomsForDropDownAsync()
        {
            return await _appDBContext.Hotelrooms.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Hotelrooms>> GetAllHotelroomsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Hotelrooms.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountHotelroomsAsync()
        {
            return await _appDBContext.Hotelrooms.CountAsync();
        }
        public async Task<List<Hotelrooms>> SearchAllHotelroomsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Hotelrooms.Where(i=> i.Name.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountHotelroomsAsync(string searchKey)
        {
            return await _appDBContext.Hotelrooms.Where(i=> i.Name.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertHotelroomsAsync(Hotelrooms data)
        {
            await _appDBContext.Hotelrooms.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Hotelrooms> GetHotelroomsAsync(int Id)
        {
            Hotelrooms data = await _appDBContext.Hotelrooms.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateHotelroomsAsync(Hotelrooms data)
        {
            _appDBContext.Hotelrooms.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteHotelroomsAsync(Hotelrooms data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

