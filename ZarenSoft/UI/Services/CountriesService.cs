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
    public class CountriesService
    {
        private readonly AppDBContext _appDBContext;
        public CountriesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Countries>> GetAllCountriesForDropDownAsync()
        {
            return await _appDBContext.Countries.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Countries>> GetAllCountriesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Countries.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountCountriesAsync()
        {
            return await _appDBContext.Countries.CountAsync();
        }
        public async Task<List<Countries>> SearchAllCountriesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Countries.Where(i=> i.Name.Contains(searchKey) || i.LatLongBounds.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountCountriesAsync(string searchKey)
        {
            return await _appDBContext.Countries.Where(i=> i.Name.Contains(searchKey) || i.LatLongBounds.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertCountriesAsync(Countries data)
        {
            await _appDBContext.Countries.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Countries> GetCountriesAsync(int Id)
        {
            Countries data = await _appDBContext.Countries.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateCountriesAsync(Countries data)
        {
            _appDBContext.Countries.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCountriesAsync(Countries data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

