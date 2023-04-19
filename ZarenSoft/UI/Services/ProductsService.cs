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
    public class ProductsService
    {
        private readonly AppDBContext _appDBContext;
        public ProductsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Products>> GetAllProductsForDropDownAsync()
        {
            return await _appDBContext.Products.OrderBy(i => i.product_id).ToListAsync();
        }
        public async Task<List<Products>> GetAllProductsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Products.OrderBy(i=>i.product_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountProductsAsync()
        {
            return await _appDBContext.Products.CountAsync();
        }
        public async Task<List<Products>> SearchAllProductsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Products.Where(i=> i.product_name.Contains(searchKey)).OrderBy(i => i.product_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountProductsAsync(string searchKey)
        {
            return await _appDBContext.Products.Where(i=> i.product_name.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertProductsAsync(Products data)
        {
            await _appDBContext.Products.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Products> GetProductsAsync(int product_id)
        {
            Products data = await _appDBContext.Products.FirstOrDefaultAsync(c => c.product_id.Equals(product_id));
            return data;
        }
        public async Task<bool> UpdateProductsAsync(Products data)
        {
            _appDBContext.Products.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteProductsAsync(Products data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

