using Microsoft.EntityFrameworkCore;
using ZarenBlazorAdmin.Data;
using ZarenBlazorAdmin.Model;
using ZarenBlazorAdmin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZarenBlazorAdmin.Data;

namespace ZarenBlazorAdmin.Services
{
    public class HotelroomlanguagesService
    {
        private readonly AppDBContext _appDBContext;
        public HotelroomlanguagesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Hotelroomlanguages>> GetAllHotelroomlanguagesForDropDownAsync()
        {
            return await _appDBContext.Hotelroomlanguages.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Hotelroomlanguages>> GetAllHotelroomlanguagesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Hotelroomlanguages.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountHotelroomlanguagesAsync()
        {
            return await _appDBContext.Hotelroomlanguages.CountAsync();
        }
        public async Task<List<Hotelroomlanguages>> SearchAllHotelroomlanguagesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Hotelroomlanguages.Where(i=> i.Name.Contains(searchKey) || i.Description.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountHotelroomlanguagesAsync(string searchKey)
        {
            return await _appDBContext.Hotelroomlanguages.Where(i=> i.Name.Contains(searchKey) || i.Description.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertHotelroomlanguagesAsync(Hotelroomlanguages data)
        {
            await _appDBContext.Hotelroomlanguages.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Hotelroomlanguages> GetHotelroomlanguagesAsync(int Id)
        {
            Hotelroomlanguages data = await _appDBContext.Hotelroomlanguages.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateHotelroomlanguagesAsync(Hotelroomlanguages data)
        {
            _appDBContext.Hotelroomlanguages.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteHotelroomlanguagesAsync(Hotelroomlanguages data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

