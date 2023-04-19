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
    public class ContactsService
    {
        private readonly AppDBContext _appDBContext;
        public ContactsService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
         public async Task<List<Contacts>> GetAllContactsForDropDownAsync()
        {
            return await _appDBContext.Contacts.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<List<Contacts>> GetAllContactsAsync(int pageNo=1,int pageSize=20)
        {
            return await _appDBContext.Contacts.OrderBy(i=>i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(); 
        }
        public async Task<int> GetTotalCountContactsAsync()
        {
            return await _appDBContext.Contacts.CountAsync();
        }
        public async Task<List<Contacts>> SearchAllContactsAsync(string searchKey,int pageNo = 1, int pageSize = 20)
        {
            return await _appDBContext.Contacts.Where(i=> i.Name.Contains(searchKey) || i.TelNumber.Contains(searchKey) || i.FaxNumber.Contains(searchKey) || i.Email.Contains(searchKey)).OrderBy(i => i.Id).Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<int> GetTotalSearchCountContactsAsync(string searchKey)
        {
            return await _appDBContext.Contacts.Where(i=> i.Name.Contains(searchKey) || i.TelNumber.Contains(searchKey) || i.FaxNumber.Contains(searchKey) || i.Email.Contains(searchKey)).CountAsync();
        }
        public async Task<bool> InsertContactsAsync(Contacts data)
        {
            await _appDBContext.Contacts.AddAsync(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<Contacts> GetContactsAsync(int Id)
        {
            Contacts data = await _appDBContext.Contacts.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return data;
        }
        public async Task<bool> UpdateContactsAsync(Contacts data)
        {
            _appDBContext.Contacts.Update(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteContactsAsync(Contacts data)
        {
            _appDBContext.Remove(data);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    }
}

