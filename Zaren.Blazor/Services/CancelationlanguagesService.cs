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
    public class CancelationlanguagesService
    {
        private readonly AppDBContext _appDBContext;
        public CancelationlanguagesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Cancelationlanguages>> GetAllCancelationlanguagesForDropDownAsync()
        {
            return await _appDBContext.Cancelationlanguages.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Cancelationlanguages>> GetAllCancelationlanguagesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Cancelationlanguages.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountCancelationlanguagesAsync()
        {
            return await _appDBContext.Cancelationlanguages.CountAsync();
        }
        public async Task<List<Cancelationlanguages>> SearchAllCancelationlanguagesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Cancelationlanguages.Where(i=> i.Name.Contains(searchKey) || i.Description.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountCancelationlanguagesAsync(string searchKey)
        {
            return await _appDBContext.Cancelationlanguages.Where(i=> i.Name.Contains(searchKey) || i.Description.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertCancelationlanguagesAsync(Cancelationlanguages data)
        {
            await _appDBContext.Cancelationlanguages.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Cancelationlanguages> GetCancelationlanguagesAsync(int Id)
        {
            Cancelationlanguages data = await _appDBContext.Cancelationlanguages.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateCancelationlanguagesAsync(Cancelationlanguages data)
        {
            _appDBContext.Cancelationlanguages.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCancelationlanguagesAsync(Cancelationlanguages data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

