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
    public class OrdersService
    {
        private readonly AppDBContext _appDBContext;
        public OrdersService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Orders>> GetAllOrdersForDropDownAsync()
        {
            return await _appDBContext.Orders.OrderBy(i => i.order_id).ToListAsync();
        }
        public async Task<List<Orders>> GetAllOrdersAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Orders.OrderBy(i=>i.order_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountOrdersAsync()
        {
            return await _appDBContext.Orders.CountAsync();
        }
        public async Task<List<Orders>> SearchAllOrdersAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Orders.Where(i=> i.order_id== Convert.ToInt32(searchKey)).OrderBy(i => i.order_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountOrdersAsync(string searchKey)
        {
            return await _appDBContext.Orders.Where(i=> i.order_id== Convert.ToInt32(searchKey)).CountAsync();
        }
        public async Task<bool> InsertOrdersAsync(Orders data)
        {
            await _appDBContext.Orders.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Orders> GetOrdersAsync(int order_id)
        {
            Orders data = await _appDBContext.Orders.FirstOrDefaultAsync(c => c.order_id.Equals(order_id));
            return data;
        }
        public async Task<bool> UpdateOrdersAsync(Orders data)
        {
            _appDBContext.Orders.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteOrdersAsync(Orders data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

