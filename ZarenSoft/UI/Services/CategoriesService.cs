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
    public class CategoriesService
    {
        private readonly AppDBContext _appDBContext;
        public CategoriesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Categories>> GetAllCategoriesForDropDownAsync()
        {
            return await _appDBContext.Categories.OrderBy(i => i.category_id).ToListAsync();
        }
        public async Task<List<Categories>> GetAllCategoriesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Categories.OrderBy(i=>i.category_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountCategoriesAsync()
        {
            return await _appDBContext.Categories.CountAsync();
        }
        public async Task<List<Categories>> SearchAllCategoriesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Categories.Where(i=> i.category_name.Contains(searchKey)).OrderBy(i => i.category_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountCategoriesAsync(string searchKey)
        {
            return await _appDBContext.Categories.Where(i=> i.category_name.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertCategoriesAsync(Categories data)
        {
            await _appDBContext.Categories.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Categories> GetCategoriesAsync(int category_id)
        {
            Categories data = await _appDBContext.Categories.FirstOrDefaultAsync(c => c.category_id.Equals(category_id));
            return data;
        }
        public async Task<bool> UpdateCategoriesAsync(Categories data)
        {
            _appDBContext.Categories.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCategoriesAsync(Categories data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

