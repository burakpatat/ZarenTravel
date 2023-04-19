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
    public class RoomsService
    {
        private readonly AppDBContext _appDBContext;
        public RoomsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Rooms>> GetAllRoomsForDropDownAsync()
        {
            return await _appDBContext.Rooms.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Rooms>> GetAllRoomsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Rooms.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountRoomsAsync()
        {
            return await _appDBContext.Rooms.CountAsync();
        }
        public async Task<List<Rooms>> SearchAllRoomsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Rooms.Where(i=> i.Name.Contains(searchKey) || i.Description.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountRoomsAsync(string searchKey)
        {
            return await _appDBContext.Rooms.Where(i=> i.Name.Contains(searchKey) || i.Description.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertRoomsAsync(Rooms data)
        {
            await _appDBContext.Rooms.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Rooms> GetRoomsAsync(int Id)
        {
            Rooms data = await _appDBContext.Rooms.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateRoomsAsync(Rooms data)
        {
            _appDBContext.Rooms.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteRoomsAsync(Rooms data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

