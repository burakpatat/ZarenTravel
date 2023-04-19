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
    public class FacilitieshotelsService
    {
        private readonly AppDBContext _appDBContext;
        public FacilitieshotelsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Facilitieshotels>> GetAllFacilitieshotelsForDropDownAsync()
        {
            return await _appDBContext.Facilitieshotels.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Facilitieshotels>> GetAllFacilitieshotelsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Facilitieshotels.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountFacilitieshotelsAsync()
        {
            return await _appDBContext.Facilitieshotels.CountAsync();
        }
        public async Task<List<Facilitieshotels>> SearchAllFacilitieshotelsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Facilitieshotels.Where(i=> i.Id== Convert.ToInt32(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountFacilitieshotelsAsync(string searchKey)
        {
            return await _appDBContext.Facilitieshotels.Where(i=> i.Id== Convert.ToInt32(searchKey)).CountAsync();
        }
        public async Task<bool> InsertFacilitieshotelsAsync(Facilitieshotels data)
        {
            await _appDBContext.Facilitieshotels.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Facilitieshotels> GetFacilitieshotelsAsync(int Id)
        {
            Facilitieshotels data = await _appDBContext.Facilitieshotels.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateFacilitieshotelsAsync(Facilitieshotels data)
        {
            _appDBContext.Facilitieshotels.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteFacilitieshotelsAsync(Facilitieshotels data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

