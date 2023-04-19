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
    public class CitiesService
    {
        private readonly AppDBContext _appDBContext;
        public CitiesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Cities>> GetAllCitiesForDropDownAsync()
        {
            return await _appDBContext.Cities.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Cities>> GetAllCitiesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Cities.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountCitiesAsync()
        {
            return await _appDBContext.Cities.CountAsync();
        }
        public async Task<List<Cities>> SearchAllCitiesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Cities.Where(i=> i.Name.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountCitiesAsync(string searchKey)
        {
            return await _appDBContext.Cities.Where(i=> i.Name.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertCitiesAsync(Cities data)
        {
            await _appDBContext.Cities.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Cities> GetCitiesAsync(int Id)
        {
            Cities data = await _appDBContext.Cities.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateCitiesAsync(Cities data)
        {
            _appDBContext.Cities.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCitiesAsync(Cities data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

