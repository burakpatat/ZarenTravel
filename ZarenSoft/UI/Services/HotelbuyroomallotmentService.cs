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
    public class HotelbuyroomallotmentService
    {
        private readonly AppDBContext _appDBContext;
        public HotelbuyroomallotmentService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Hotelbuyroomallotment>> GetAllHotelbuyroomallotmentForDropDownAsync()
        {
            return await _appDBContext.Hotelbuyroomallotment.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Hotelbuyroomallotment>> GetAllHotelbuyroomallotmentAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Hotelbuyroomallotment.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountHotelbuyroomallotmentAsync()
        {
            return await _appDBContext.Hotelbuyroomallotment.CountAsync();
        }
        public async Task<List<Hotelbuyroomallotment>> SearchAllHotelbuyroomallotmentAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Hotelbuyroomallotment.Where(i=> i.Id== Convert.ToInt32(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountHotelbuyroomallotmentAsync(string searchKey)
        {
            return await _appDBContext.Hotelbuyroomallotment.Where(i=> i.Id== Convert.ToInt32(searchKey)).CountAsync();
        }
        public async Task<bool> InsertHotelbuyroomallotmentAsync(Hotelbuyroomallotment data)
        {
            await _appDBContext.Hotelbuyroomallotment.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Hotelbuyroomallotment> GetHotelbuyroomallotmentAsync(int Id)
        {
            Hotelbuyroomallotment data = await _appDBContext.Hotelbuyroomallotment.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateHotelbuyroomallotmentAsync(Hotelbuyroomallotment data)
        {
            _appDBContext.Hotelbuyroomallotment.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteHotelbuyroomallotmentAsync(Hotelbuyroomallotment data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

