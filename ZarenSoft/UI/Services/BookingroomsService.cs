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
    public class BookingroomsService
    {
        private readonly AppDBContext _appDBContext;
        public BookingroomsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Bookingrooms>> GetAllBookingroomsForDropDownAsync()
        {
            return await _appDBContext.Bookingrooms.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Bookingrooms>> GetAllBookingroomsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Bookingrooms.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountBookingroomsAsync()
        {
            return await _appDBContext.Bookingrooms.CountAsync();
        }
        public async Task<List<Bookingrooms>> SearchAllBookingroomsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Bookingrooms.Where(i=> i.Id== Convert.ToInt32(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountBookingroomsAsync(string searchKey)
        {
            return await _appDBContext.Bookingrooms.Where(i=> i.Id== Convert.ToInt32(searchKey)).CountAsync();
        }
        public async Task<bool> InsertBookingroomsAsync(Bookingrooms data)
        {
            await _appDBContext.Bookingrooms.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Bookingrooms> GetBookingroomsAsync(int Id)
        {
            Bookingrooms data = await _appDBContext.Bookingrooms.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateBookingroomsAsync(Bookingrooms data)
        {
            _appDBContext.Bookingrooms.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteBookingroomsAsync(Bookingrooms data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

