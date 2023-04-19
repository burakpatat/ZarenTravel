using Microsoft.EntityFrameworkCore;
using Zaren.Blazor.Data;
using ZarenBlazorAdmin.Model;
using Zaren.Blazor.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZarenBlazorAdmin.Services
{
    public class DealtypelanguagesService
    {
        private readonly AppDBContext _appDBContext;
        public DealtypelanguagesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Dealtypelanguages>> GetAllDealtypelanguagesForDropDownAsync()
        {
            return await _appDBContext.Dealtypelanguages.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Dealtypelanguages>> GetAllDealtypelanguagesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Dealtypelanguages.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountDealtypelanguagesAsync()
        {
            return await _appDBContext.Dealtypelanguages.CountAsync();
        }
        public async Task<List<Dealtypelanguages>> SearchAllDealtypelanguagesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Dealtypelanguages.Where(i=> i.Name.Contains(searchKey) || i.Description.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountDealtypelanguagesAsync(string searchKey)
        {
            return await _appDBContext.Dealtypelanguages.Where(i=> i.Name.Contains(searchKey) || i.Description.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertDealtypelanguagesAsync(Dealtypelanguages data)
        {
            await _appDBContext.Dealtypelanguages.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Dealtypelanguages> GetDealtypelanguagesAsync(int Id)
        {
            Dealtypelanguages data = await _appDBContext.Dealtypelanguages.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateDealtypelanguagesAsync(Dealtypelanguages data)
        {
            _appDBContext.Dealtypelanguages.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteDealtypelanguagesAsync(Dealtypelanguages data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

