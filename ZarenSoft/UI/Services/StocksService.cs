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
    public class StocksService
    {
        private readonly AppDBContext _appDBContext;
        public StocksService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Stocks>> GetAllStocksForDropDownAsync()
        {
            return await _appDBContext.Stocks.OrderBy(i => i.store_id).ToListAsync();
        }
        public async Task<List<Stocks>> GetAllStocksAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Stocks.OrderBy(i=>i.store_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountStocksAsync()
        {
            return await _appDBContext.Stocks.CountAsync();
        }
        public async Task<List<Stocks>> SearchAllStocksAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Stocks.Where(i=> i.store_id== Convert.ToInt32(searchKey) || i.product_id== Convert.ToInt32(searchKey)).OrderBy(i => i.store_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountStocksAsync(string searchKey)
        {
            return await _appDBContext.Stocks.Where(i=> i.store_id== Convert.ToInt32(searchKey) || i.product_id== Convert.ToInt32(searchKey)).CountAsync();
        }
        public async Task<bool> InsertStocksAsync(Stocks data)
        {
            await _appDBContext.Stocks.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Stocks> GetStocksAsync(int store_id,int product_id)
        {
            Stocks data = await _appDBContext.Stocks.FirstOrDefaultAsync(c => c.store_id.Equals(store_id) && c.product_id.Equals(product_id));
            return data;
        }
        public async Task<bool> UpdateStocksAsync(Stocks data)
        {
            _appDBContext.Stocks.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteStocksAsync(Stocks data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

