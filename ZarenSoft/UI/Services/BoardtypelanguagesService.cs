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
    public class BoardtypelanguagesService
    {
        private readonly AppDBContext _appDBContext;
        public BoardtypelanguagesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Boardtypelanguages>> GetAllBoardtypelanguagesForDropDownAsync()
        {
            return await _appDBContext.Boardtypelanguages.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Boardtypelanguages>> GetAllBoardtypelanguagesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Boardtypelanguages.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountBoardtypelanguagesAsync()
        {
            return await _appDBContext.Boardtypelanguages.CountAsync();
        }
        public async Task<List<Boardtypelanguages>> SearchAllBoardtypelanguagesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Boardtypelanguages.Where(i=> i.Name.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountBoardtypelanguagesAsync(string searchKey)
        {
            return await _appDBContext.Boardtypelanguages.Where(i=> i.Name.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertBoardtypelanguagesAsync(Boardtypelanguages data)
        {
            await _appDBContext.Boardtypelanguages.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Boardtypelanguages> GetBoardtypelanguagesAsync(int Id)
        {
            Boardtypelanguages data = await _appDBContext.Boardtypelanguages.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateBoardtypelanguagesAsync(Boardtypelanguages data)
        {
            _appDBContext.Boardtypelanguages.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteBoardtypelanguagesAsync(Boardtypelanguages data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

