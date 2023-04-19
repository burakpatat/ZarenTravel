using Microsoft.EntityFrameworkCore;
using Zaren.Blazor.Data;
using Zaren.Blazor.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zaren.Blazor.Model;
using Microsoft.Data.SqlClient;
using Dapper;

public class HotelsService
{
    private readonly AppDBContext _appDBContext;
    IConfiguration _config;
    public HotelsService(AppDBContext appDBContext, IConfiguration config)
    {
        _appDBContext = appDBContext;
        _config = config;
    }
    public async Task<List<Hotels>> GetAllHotelsForDropDownAsync()
    {
        return await _appDBContext.Hotels.OrderBy(i => i.Id).ToListAsync();
    }
    public async Task<List<Hotels>> GetAllHotelsAsync(int pageNo = 1, int pageSize = 20)
    {
        var cnn = new SqlConnection(_config.GetConnectionString("conString"));
        cnn.Open();


        var hotels = cnn.Query<Hotels>("select * from hotels", commandType: System.Data.CommandType.Text).ToList();

        return hotels.OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
    }
    public async Task<int> GetTotalCountHotelsAsync()
    {
        return await _appDBContext.Hotels.CountAsync();
    }
    public async Task<List<Hotels>> SearchAllHotelsAsync(string searchKey, int pageNo = 1, int pageSize = 20)
    {
        return await _appDBContext.Hotels.Where(i => i.Name.Contains(searchKey) || i.Address.Contains(searchKey) || i.ZipCode.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
    }
    public async Task<int> GetTotalSearchCountHotelsAsync(string searchKey)
    {
        return await _appDBContext.Hotels.Where(i => i.Name.Contains(searchKey) || i.Address.Contains(searchKey) || i.ZipCode.Contains(searchKey)).CountAsync();
    }
    public async Task<bool> InsertHotelsAsync(Hotels data)
    {
        await _appDBContext.Hotels.AddAsync(data);
        await _appDBContext.SaveChangesAsync();
        return true;
    }
    public async Task<Hotels> GetHotelsAsync(int Id)
    {
        Hotels data = await _appDBContext.Hotels.FirstOrDefaultAsync(c => c.Id.Equals(Id));
        return data;
    }
    public async Task<bool> UpdateHotelsAsync(Hotels data)
    {
        _appDBContext.Hotels.Update(data);
        await _appDBContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteHotelsAsync(Hotels data)
    {
        _appDBContext.Remove(data);
        await _appDBContext.SaveChangesAsync();
        return true;
    }
}


