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
    public class HotelchainsService
    {
        private readonly AppDBContext _appDBContext;
        public HotelchainsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Hotelchains>> GetAllHotelchainsForDropDownAsync()
        {
            return await _appDBContext.Hotelchains.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Hotelchains>> GetAllHotelchainsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Hotelchains.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountHotelchainsAsync()
        {
            return await _appDBContext.Hotelchains.CountAsync();
        }
        public async Task<List<Hotelchains>> SearchAllHotelchainsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Hotelchains.Where(i=> i.Name.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountHotelchainsAsync(string searchKey)
        {
            return await _appDBContext.Hotelchains.Where(i=> i.Name.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertHotelchainsAsync(Hotelchains data)
        {
            await _appDBContext.Hotelchains.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Hotelchains> GetHotelchainsAsync(int Id)
        {
            Hotelchains data = await _appDBContext.Hotelchains.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateHotelchainsAsync(Hotelchains data)
        {
            _appDBContext.Hotelchains.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteHotelchainsAsync(Hotelchains data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

