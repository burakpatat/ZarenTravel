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
    public class FacilitylanguagesService
    {
        private readonly AppDBContext _appDBContext;
        public FacilitylanguagesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Facilitylanguages>> GetAllFacilitylanguagesForDropDownAsync()
        {
            return await _appDBContext.Facilitylanguages.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Facilitylanguages>> GetAllFacilitylanguagesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Facilitylanguages.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountFacilitylanguagesAsync()
        {
            return await _appDBContext.Facilitylanguages.CountAsync();
        }
        public async Task<List<Facilitylanguages>> SearchAllFacilitylanguagesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Facilitylanguages.Where(i=> i.Name.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountFacilitylanguagesAsync(string searchKey)
        {
            return await _appDBContext.Facilitylanguages.Where(i=> i.Name.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertFacilitylanguagesAsync(Facilitylanguages data)
        {
            await _appDBContext.Facilitylanguages.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Facilitylanguages> GetFacilitylanguagesAsync(int Id)
        {
            Facilitylanguages data = await _appDBContext.Facilitylanguages.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateFacilitylanguagesAsync(Facilitylanguages data)
        {
            _appDBContext.Facilitylanguages.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteFacilitylanguagesAsync(Facilitylanguages data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

