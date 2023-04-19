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
    public class BrandsService
    {
        private readonly AppDBContext _appDBContext;
        public BrandsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Brands>> GetAllBrandsForDropDownAsync()
        {
            return await _appDBContext.Brands.OrderBy(i => i.brand_id).ToListAsync();
        }
        public async Task<List<Brands>> GetAllBrandsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Brands.OrderBy(i=>i.brand_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountBrandsAsync()
        {
            return await _appDBContext.Brands.CountAsync();
        }
        public async Task<List<Brands>> SearchAllBrandsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Brands.Where(i=> i.brand_name.Contains(searchKey)).OrderBy(i => i.brand_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountBrandsAsync(string searchKey)
        {
            return await _appDBContext.Brands.Where(i=> i.brand_name.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertBrandsAsync(Brands data)
        {
            await _appDBContext.Brands.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Brands> GetBrandsAsync(int brand_id)
        {
            Brands data = await _appDBContext.Brands.FirstOrDefaultAsync(c => c.brand_id.Equals(brand_id));
            return data;
        }
        public async Task<bool> UpdateBrandsAsync(Brands data)
        {
            _appDBContext.Brands.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteBrandsAsync(Brands data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

