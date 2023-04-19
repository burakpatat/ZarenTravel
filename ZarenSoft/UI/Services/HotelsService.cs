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
    public class HotelsService
    {
        private readonly AppDBContext _appDBContext;
        public HotelsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Hotels>> GetAllHotelsForDropDownAsync()
        {
            return await _appDBContext.Hotels.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Hotels>> GetAllHotelsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Hotels.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountHotelsAsync()
        {
            return await _appDBContext.Hotels.CountAsync();
        }
        public async Task<List<Hotels>> SearchAllHotelsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Hotels.Where(i=> i.Name.Contains(searchKey) || i.Address.Contains(searchKey) || i.ZipCode.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountHotelsAsync(string searchKey)
        {
            return await _appDBContext.Hotels.Where(i=> i.Name.Contains(searchKey) || i.Address.Contains(searchKey) || i.ZipCode.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertHotelsAsync(Hotels data)
        {
            await _appDBContext.Hotels.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Hotels> GetHotelsAsync(int Id)
        {
            Hotels data = await _appDBContext.Hotels.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateHotelsAsync(Hotels data)
        {
            _appDBContext.Hotels.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteHotelsAsync(Hotels data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

