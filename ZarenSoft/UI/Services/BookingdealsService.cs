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
    public class BookingdealsService
    {
        private readonly AppDBContext _appDBContext;
        public BookingdealsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Bookingdeals>> GetAllBookingdealsForDropDownAsync()
        {
            return await _appDBContext.Bookingdeals.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Bookingdeals>> GetAllBookingdealsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Bookingdeals.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountBookingdealsAsync()
        {
            return await _appDBContext.Bookingdeals.CountAsync();
        }
        public async Task<List<Bookingdeals>> SearchAllBookingdealsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Bookingdeals.Where(i=> i.Id== Convert.ToInt32(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountBookingdealsAsync(string searchKey)
        {
            return await _appDBContext.Bookingdeals.Where(i=> i.Id== Convert.ToInt32(searchKey)).CountAsync();
        }
        public async Task<bool> InsertBookingdealsAsync(Bookingdeals data)
        {
            await _appDBContext.Bookingdeals.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Bookingdeals> GetBookingdealsAsync(int Id)
        {
            Bookingdeals data = await _appDBContext.Bookingdeals.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateBookingdealsAsync(Bookingdeals data)
        {
            _appDBContext.Bookingdeals.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteBookingdealsAsync(Bookingdeals data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

