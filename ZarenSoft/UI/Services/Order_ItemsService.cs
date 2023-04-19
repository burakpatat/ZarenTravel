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
    public class Order_ItemsService
    {
        private readonly AppDBContext _appDBContext;
        public Order_ItemsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Order_Items>> GetAllOrder_ItemsForDropDownAsync()
        {
            return await _appDBContext.Order_Items.OrderBy(i => i.order_id).ToListAsync();
        }
        public async Task<List<Order_Items>> GetAllOrder_ItemsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Order_Items.OrderBy(i=>i.order_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountOrder_ItemsAsync()
        {
            return await _appDBContext.Order_Items.CountAsync();
        }
        public async Task<List<Order_Items>> SearchAllOrder_ItemsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Order_Items.Where(i=> i.order_id== Convert.ToInt32(searchKey) || i.item_id== Convert.ToInt32(searchKey)).OrderBy(i => i.order_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountOrder_ItemsAsync(string searchKey)
        {
            return await _appDBContext.Order_Items.Where(i=> i.order_id== Convert.ToInt32(searchKey) || i.item_id== Convert.ToInt32(searchKey)).CountAsync();
        }
        public async Task<bool> InsertOrder_ItemsAsync(Order_Items data)
        {
            await _appDBContext.Order_Items.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Order_Items> GetOrder_ItemsAsync(int order_id,int item_id)
        {
            Order_Items data = await _appDBContext.Order_Items.FirstOrDefaultAsync(c => c.order_id.Equals(order_id) && c.item_id.Equals(item_id));
            return data;
        }
        public async Task<bool> UpdateOrder_ItemsAsync(Order_Items data)
        {
            _appDBContext.Order_Items.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteOrder_ItemsAsync(Order_Items data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

