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
    public class BuyroomsService
    {
        private readonly AppDBContext _appDBContext;
        public BuyroomsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Buyrooms>> GetAllBuyroomsForDropDownAsync()
        {
            return await _appDBContext.Buyrooms.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Buyrooms>> GetAllBuyroomsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Buyrooms.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountBuyroomsAsync()
        {
            return await _appDBContext.Buyrooms.CountAsync();
        }
        public async Task<List<Buyrooms>> SearchAllBuyroomsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Buyrooms.Where(i=> i.Name.Contains(searchKey) || i.Description.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountBuyroomsAsync(string searchKey)
        {
            return await _appDBContext.Buyrooms.Where(i=> i.Name.Contains(searchKey) || i.Description.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertBuyroomsAsync(Buyrooms data)
        {
            await _appDBContext.Buyrooms.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Buyrooms> GetBuyroomsAsync(int Id)
        {
            Buyrooms data = await _appDBContext.Buyrooms.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateBuyroomsAsync(Buyrooms data)
        {
            _appDBContext.Buyrooms.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteBuyroomsAsync(Buyrooms data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

