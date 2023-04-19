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
    public class BoardtypesService
    {
        private readonly AppDBContext _appDBContext;
        public BoardtypesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Boardtypes>> GetAllBoardtypesForDropDownAsync()
        {
            return await _appDBContext.Boardtypes.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Boardtypes>> GetAllBoardtypesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Boardtypes.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountBoardtypesAsync()
        {
            return await _appDBContext.Boardtypes.CountAsync();
        }
        public async Task<List<Boardtypes>> SearchAllBoardtypesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Boardtypes.Where(i=> i.Name.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountBoardtypesAsync(string searchKey)
        {
            return await _appDBContext.Boardtypes.Where(i=> i.Name.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertBoardtypesAsync(Boardtypes data)
        {
            await _appDBContext.Boardtypes.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Boardtypes> GetBoardtypesAsync(int Id)
        {
            Boardtypes data = await _appDBContext.Boardtypes.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateBoardtypesAsync(Boardtypes data)
        {
            _appDBContext.Boardtypes.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteBoardtypesAsync(Boardtypes data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

