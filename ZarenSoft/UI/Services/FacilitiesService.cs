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
    public class FacilitiesService
    {
        private readonly AppDBContext _appDBContext;
        public FacilitiesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Facilities>> GetAllFacilitiesForDropDownAsync()
        {
            return await _appDBContext.Facilities.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Facilities>> GetAllFacilitiesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Facilities.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountFacilitiesAsync()
        {
            return await _appDBContext.Facilities.CountAsync();
        }
        public async Task<List<Facilities>> SearchAllFacilitiesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Facilities.Where(i=> i.Name.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountFacilitiesAsync(string searchKey)
        {
            return await _appDBContext.Facilities.Where(i=> i.Name.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertFacilitiesAsync(Facilities data)
        {
            await _appDBContext.Facilities.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Facilities> GetFacilitiesAsync(int Id)
        {
            Facilities data = await _appDBContext.Facilities.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateFacilitiesAsync(Facilities data)
        {
            _appDBContext.Facilities.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteFacilitiesAsync(Facilities data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

