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
    public class BookingsService
    {
        private readonly AppDBContext _appDBContext;
        public BookingsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Bookings>> GetAllBookingsForDropDownAsync()
        {
            return await _appDBContext.Bookings.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Bookings>> GetAllBookingsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Bookings.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountBookingsAsync()
        {
            return await _appDBContext.Bookings.CountAsync();
        }
        public async Task<List<Bookings>> SearchAllBookingsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Bookings.Where(i=> i.Reference.Contains(searchKey) || i.ClientTitle.Contains(searchKey) || i.ClientName.Contains(searchKey) || i.ClientSurname.Contains(searchKey) || i.ClientEmail.Contains(searchKey) || i.ClientNotes.Contains(searchKey) || i.ClientAddress.Contains(searchKey) || i.ClientContact.Contains(searchKey) || i.ChildrenAges.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountBookingsAsync(string searchKey)
        {
            return await _appDBContext.Bookings.Where(i=> i.Reference.Contains(searchKey) || i.ClientTitle.Contains(searchKey) || i.ClientName.Contains(searchKey) || i.ClientSurname.Contains(searchKey) || i.ClientEmail.Contains(searchKey) || i.ClientNotes.Contains(searchKey) || i.ClientAddress.Contains(searchKey) || i.ClientContact.Contains(searchKey) || i.ChildrenAges.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertBookingsAsync(Bookings data)
        {
            await _appDBContext.Bookings.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Bookings> GetBookingsAsync(int Id)
        {
            Bookings data = await _appDBContext.Bookings.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateBookingsAsync(Bookings data)
        {
            _appDBContext.Bookings.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteBookingsAsync(Bookings data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

