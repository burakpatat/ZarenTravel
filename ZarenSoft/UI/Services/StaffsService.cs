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
    public class StaffsService
    {
        private readonly AppDBContext _appDBContext;
        public StaffsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Staffs>> GetAllStaffsForDropDownAsync()
        {
            return await _appDBContext.Staffs.OrderBy(i => i.staff_id).ToListAsync();
        }
        public async Task<List<Staffs>> GetAllStaffsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Staffs.OrderBy(i=>i.staff_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountStaffsAsync()
        {
            return await _appDBContext.Staffs.CountAsync();
        }
        public async Task<List<Staffs>> SearchAllStaffsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Staffs.Where(i=> i.first_name.Contains(searchKey) || i.last_name.Contains(searchKey) || i.email.Contains(searchKey) || i.phone.Contains(searchKey)).OrderBy(i => i.staff_id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountStaffsAsync(string searchKey)
        {
            return await _appDBContext.Staffs.Where(i=> i.first_name.Contains(searchKey) || i.last_name.Contains(searchKey) || i.email.Contains(searchKey) || i.phone.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertStaffsAsync(Staffs data)
        {
            await _appDBContext.Staffs.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Staffs> GetStaffsAsync(int staff_id)
        {
            Staffs data = await _appDBContext.Staffs.FirstOrDefaultAsync(c => c.staff_id.Equals(staff_id));
            return data;
        }
        public async Task<bool> UpdateStaffsAsync(Staffs data)
        {
            _appDBContext.Staffs.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteStaffsAsync(Staffs data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

