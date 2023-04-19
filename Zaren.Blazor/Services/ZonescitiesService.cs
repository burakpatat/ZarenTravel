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
    public class ZonescitiesService
    {
        private readonly AppDBContext _appDBContext;
        public ZonescitiesService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Zonescities>> GetAllZonescitiesForDropDownAsync()
        {
            return await _appDBContext.Zonescities.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Zonescities>> GetAllZonescitiesAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Zonescities.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountZonescitiesAsync()
        {
            return await _appDBContext.Zonescities.CountAsync();
        }
        public async Task<List<Zonescities>> SearchAllZonescitiesAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Zonescities.Where(i=> i.MainZone.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountZonescitiesAsync(string searchKey)
        {
            return await _appDBContext.Zonescities.Where(i=> i.MainZone.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertZonescitiesAsync(Zonescities data)
        {
            await _appDBContext.Zonescities.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Zonescities> GetZonescitiesAsync(int Id)
        {
            Zonescities data = await _appDBContext.Zonescities.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateZonescitiesAsync(Zonescities data)
        {
            _appDBContext.Zonescities.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteZonescitiesAsync(Zonescities data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

