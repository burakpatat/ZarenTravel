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
    public class DealtypesService
    {
        private readonly AppDBContext _appDBContext;
        public DealtypesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Dealtypes>> GetAllDealtypesForDropDownAsync()
        {
            return await _appDBContext.Dealtypes.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Dealtypes>> GetAllDealtypesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Dealtypes.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountDealtypesAsync()
        {
            return await _appDBContext.Dealtypes.CountAsync();
        }
        public async Task<List<Dealtypes>> SearchAllDealtypesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Dealtypes.Where(i=> i.Id== Convert.ToInt32(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountDealtypesAsync(string searchKey)
        {
            return await _appDBContext.Dealtypes.Where(i=> i.Id== Convert.ToInt32(searchKey)).CountAsync();
        }
        public async Task<bool> InsertDealtypesAsync(Dealtypes data)
        {
            await _appDBContext.Dealtypes.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Dealtypes> GetDealtypesAsync(int Id)
        {
            Dealtypes data = await _appDBContext.Dealtypes.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateDealtypesAsync(Dealtypes data)
        {
            _appDBContext.Dealtypes.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteDealtypesAsync(Dealtypes data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

