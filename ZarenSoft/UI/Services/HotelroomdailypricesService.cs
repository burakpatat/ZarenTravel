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
    public class HotelroomdailypricesService
    {
        private readonly AppDBContext _appDBContext;
        public HotelroomdailypricesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Hotelroomdailyprices>> GetAllHotelroomdailypricesForDropDownAsync()
        {
            return await _appDBContext.Hotelroomdailyprices.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Hotelroomdailyprices>> GetAllHotelroomdailypricesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Hotelroomdailyprices.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountHotelroomdailypricesAsync()
        {
            return await _appDBContext.Hotelroomdailyprices.CountAsync();
        }
        public async Task<List<Hotelroomdailyprices>> SearchAllHotelroomdailypricesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Hotelroomdailyprices.Where(i=> i.Id== Convert.ToInt32(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountHotelroomdailypricesAsync(string searchKey)
        {
            return await _appDBContext.Hotelroomdailyprices.Where(i=> i.Id== Convert.ToInt32(searchKey)).CountAsync();
        }
        public async Task<bool> InsertHotelroomdailypricesAsync(Hotelroomdailyprices data)
        {
            await _appDBContext.Hotelroomdailyprices.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Hotelroomdailyprices> GetHotelroomdailypricesAsync(int Id)
        {
            Hotelroomdailyprices data = await _appDBContext.Hotelroomdailyprices.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateHotelroomdailypricesAsync(Hotelroomdailyprices data)
        {
            _appDBContext.Hotelroomdailyprices.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteHotelroomdailypricesAsync(Hotelroomdailyprices data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

