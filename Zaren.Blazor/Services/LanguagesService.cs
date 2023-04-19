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
    public class LanguagesService
    {
        private readonly AppDBContext _appDBContext;
        public LanguagesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Languages>> GetAllLanguagesForDropDownAsync()
        {
            return await _appDBContext.Languages.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Languages>> GetAllLanguagesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Languages.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountLanguagesAsync()
        {
            return await _appDBContext.Languages.CountAsync();
        }
        public async Task<List<Languages>> SearchAllLanguagesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Languages.Where(i=> i.Name.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountLanguagesAsync(string searchKey)
        {
            return await _appDBContext.Languages.Where(i=> i.Name.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertLanguagesAsync(Languages data)
        {
            await _appDBContext.Languages.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Languages> GetLanguagesAsync(int Id)
        {
            Languages data = await _appDBContext.Languages.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateLanguagesAsync(Languages data)
        {
            _appDBContext.Languages.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteLanguagesAsync(Languages data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

