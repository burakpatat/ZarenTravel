using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Radzen;

using Travel.Data;

namespace Travel
{
    public partial class TravelCDbService
    {
        TravelCDbContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly TravelCDbContext context;
        private readonly NavigationManager navigationManager;

        public TravelCDbService(TravelCDbContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);


        public async Task ExportAgenciesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/agencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/agencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgenciesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/agencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/agencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgenciesRead(ref IQueryable<Travel.Models.TravelCDb.Agency> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.Agency>> GetAgencies(Query query = null)
        {
            var items = Context.Agencies.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAgenciesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyGet(Travel.Models.TravelCDb.Agency item);

        public async Task<Travel.Models.TravelCDb.Agency> GetAgencyById(int id)
        {
            var items = Context.Agencies
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.AgencyManager);
                items = items.Include(i => i.Country);
                items = items.Include(i => i.InvoiceType);
                items = items.Include(i => i.Statu1);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyCreated(Travel.Models.TravelCDb.Agency item);
        partial void OnAfterAgencyCreated(Travel.Models.TravelCDb.Agency item);

        public async Task<Travel.Models.TravelCDb.Agency> CreateAgency(Travel.Models.TravelCDb.Agency agency)
        {
            OnAgencyCreated(agency);

            var existingItem = Context.Agencies
                              .Where(i => i.Id == agency.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Agencies.Add(agency);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agency).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyCreated(agency);

            return agency;
        }

        public async Task<Travel.Models.TravelCDb.Agency> CancelAgencyChanges(Travel.Models.TravelCDb.Agency item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyUpdated(Travel.Models.TravelCDb.Agency item);
        partial void OnAfterAgencyUpdated(Travel.Models.TravelCDb.Agency item);

        public async Task<Travel.Models.TravelCDb.Agency> UpdateAgency(int id, Travel.Models.TravelCDb.Agency agency)
        {
            OnAgencyUpdated(agency);

            var itemToUpdate = Context.Agencies
                              .Where(i => i.Id == agency.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            agency.AgencyManager = null;
            agency.Country = null;
            agency.InvoiceType = null;
            agency.Statu1 = null;

            Context.Attach(agency).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyUpdated(agency);

            return agency;
        }

        partial void OnAgencyDeleted(Travel.Models.TravelCDb.Agency item);
        partial void OnAfterAgencyDeleted(Travel.Models.TravelCDb.Agency item);

        public async Task<Travel.Models.TravelCDb.Agency> DeleteAgency(int id)
        {
            var itemToDelete = Context.Agencies
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyDeleted(itemToDelete);

            Reset();

            Context.Agencies.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyManagersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/agencymanagers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/agencymanagers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyManagersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/agencymanagers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/agencymanagers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyManagersRead(ref IQueryable<Travel.Models.TravelCDb.AgencyManager> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.AgencyManager>> GetAgencyManagers(Query query = null)
        {
            var items = Context.AgencyManagers.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAgencyManagersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyManagerGet(Travel.Models.TravelCDb.AgencyManager item);

        public async Task<Travel.Models.TravelCDb.AgencyManager> GetAgencyManagerById(int id)
        {
            var items = Context.AgencyManagers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.MicroSite);
                items = items.Include(i => i.Statu1);
                items = items.Include(i => i.AgencyUser);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyManagerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyManagerCreated(Travel.Models.TravelCDb.AgencyManager item);
        partial void OnAfterAgencyManagerCreated(Travel.Models.TravelCDb.AgencyManager item);

        public async Task<Travel.Models.TravelCDb.AgencyManager> CreateAgencyManager(Travel.Models.TravelCDb.AgencyManager agencymanager)
        {
            OnAgencyManagerCreated(agencymanager);

            var existingItem = Context.AgencyManagers
                              .Where(i => i.Id == agencymanager.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyManagers.Add(agencymanager);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymanager).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyManagerCreated(agencymanager);

            return agencymanager;
        }

        public async Task<Travel.Models.TravelCDb.AgencyManager> CancelAgencyManagerChanges(Travel.Models.TravelCDb.AgencyManager item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyManagerUpdated(Travel.Models.TravelCDb.AgencyManager item);
        partial void OnAfterAgencyManagerUpdated(Travel.Models.TravelCDb.AgencyManager item);

        public async Task<Travel.Models.TravelCDb.AgencyManager> UpdateAgencyManager(int id, Travel.Models.TravelCDb.AgencyManager agencymanager)
        {
            OnAgencyManagerUpdated(agencymanager);

            var itemToUpdate = Context.AgencyManagers
                              .Where(i => i.Id == agencymanager.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            agencymanager.MicroSite = null;
            agencymanager.Statu1 = null;
            agencymanager.AgencyUser = null;

            Context.Attach(agencymanager).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyManagerUpdated(agencymanager);

            return agencymanager;
        }

        partial void OnAgencyManagerDeleted(Travel.Models.TravelCDb.AgencyManager item);
        partial void OnAfterAgencyManagerDeleted(Travel.Models.TravelCDb.AgencyManager item);

        public async Task<Travel.Models.TravelCDb.AgencyManager> DeleteAgencyManager(int id)
        {
            var itemToDelete = Context.AgencyManagers
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyManagerDeleted(itemToDelete);

            Reset();

            Context.AgencyManagers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyManagerDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyUsersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/agencyusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/agencyusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyUsersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/agencyusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/agencyusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyUsersRead(ref IQueryable<Travel.Models.TravelCDb.AgencyUser> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.AgencyUser>> GetAgencyUsers(Query query = null)
        {
            var items = Context.AgencyUsers.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAgencyUsersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyUserGet(Travel.Models.TravelCDb.AgencyUser item);

        public async Task<Travel.Models.TravelCDb.AgencyUser> GetAgencyUserById(int id)
        {
            var items = Context.AgencyUsers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Agency);
                items = items.Include(i => i.Country1);
                items = items.Include(i => i.Gender1);
                items = items.Include(i => i.Currency);
                items = items.Include(i => i.Statu1);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyUserGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyUserCreated(Travel.Models.TravelCDb.AgencyUser item);
        partial void OnAfterAgencyUserCreated(Travel.Models.TravelCDb.AgencyUser item);

        public async Task<Travel.Models.TravelCDb.AgencyUser> CreateAgencyUser(Travel.Models.TravelCDb.AgencyUser agencyuser)
        {
            OnAgencyUserCreated(agencyuser);

            var existingItem = Context.AgencyUsers
                              .Where(i => i.Id == agencyuser.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyUsers.Add(agencyuser);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencyuser).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyUserCreated(agencyuser);

            return agencyuser;
        }

        public async Task<Travel.Models.TravelCDb.AgencyUser> CancelAgencyUserChanges(Travel.Models.TravelCDb.AgencyUser item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyUserUpdated(Travel.Models.TravelCDb.AgencyUser item);
        partial void OnAfterAgencyUserUpdated(Travel.Models.TravelCDb.AgencyUser item);

        public async Task<Travel.Models.TravelCDb.AgencyUser> UpdateAgencyUser(int id, Travel.Models.TravelCDb.AgencyUser agencyuser)
        {
            OnAgencyUserUpdated(agencyuser);

            var itemToUpdate = Context.AgencyUsers
                              .Where(i => i.Id == agencyuser.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            agencyuser.Agency = null;
            agencyuser.Country1 = null;
            agencyuser.Gender1 = null;
            agencyuser.Currency = null;
            agencyuser.Statu1 = null;

            Context.Attach(agencyuser).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyUserUpdated(agencyuser);

            return agencyuser;
        }

        partial void OnAgencyUserDeleted(Travel.Models.TravelCDb.AgencyUser item);
        partial void OnAfterAgencyUserDeleted(Travel.Models.TravelCDb.AgencyUser item);

        public async Task<Travel.Models.TravelCDb.AgencyUser> DeleteAgencyUser(int id)
        {
            var itemToDelete = Context.AgencyUsers
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyUserDeleted(itemToDelete);

            Reset();

            Context.AgencyUsers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyUserDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportApisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/apis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/apis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportApisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/apis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/apis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnApisRead(ref IQueryable<Travel.Models.TravelCDb.Api> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.Api>> GetApis(Query query = null)
        {
            var items = Context.Apis.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnApisRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnApiGet(Travel.Models.TravelCDb.Api item);

        public async Task<Travel.Models.TravelCDb.Api> GetApiById(int id)
        {
            var items = Context.Apis
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnApiGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnApiCreated(Travel.Models.TravelCDb.Api item);
        partial void OnAfterApiCreated(Travel.Models.TravelCDb.Api item);

        public async Task<Travel.Models.TravelCDb.Api> CreateApi(Travel.Models.TravelCDb.Api api)
        {
            OnApiCreated(api);

            var existingItem = Context.Apis
                              .Where(i => i.Id == api.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Apis.Add(api);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(api).State = EntityState.Detached;
                throw;
            }

            OnAfterApiCreated(api);

            return api;
        }

        public async Task<Travel.Models.TravelCDb.Api> CancelApiChanges(Travel.Models.TravelCDb.Api item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnApiUpdated(Travel.Models.TravelCDb.Api item);
        partial void OnAfterApiUpdated(Travel.Models.TravelCDb.Api item);

        public async Task<Travel.Models.TravelCDb.Api> UpdateApi(int id, Travel.Models.TravelCDb.Api api)
        {
            OnApiUpdated(api);

            var itemToUpdate = Context.Apis
                              .Where(i => i.Id == api.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(api).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterApiUpdated(api);

            return api;
        }

        partial void OnApiDeleted(Travel.Models.TravelCDb.Api item);
        partial void OnAfterApiDeleted(Travel.Models.TravelCDb.Api item);

        public async Task<Travel.Models.TravelCDb.Api> DeleteApi(int id)
        {
            var itemToDelete = Context.Apis
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnApiDeleted(itemToDelete);

            Reset();

            Context.Apis.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterApiDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportApiProductsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/apiproducts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/apiproducts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportApiProductsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/apiproducts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/apiproducts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnApiProductsRead(ref IQueryable<Travel.Models.TravelCDb.ApiProduct> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.ApiProduct>> GetApiProducts(Query query = null)
        {
            var items = Context.ApiProducts.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnApiProductsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnApiProductGet(Travel.Models.TravelCDb.ApiProduct item);

        public async Task<Travel.Models.TravelCDb.ApiProduct> GetApiProductById(int id)
        {
            var items = Context.ApiProducts
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Api);
                items = items.Include(i => i.ProductType1);
  
            var itemToReturn = items.FirstOrDefault();

            OnApiProductGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnApiProductCreated(Travel.Models.TravelCDb.ApiProduct item);
        partial void OnAfterApiProductCreated(Travel.Models.TravelCDb.ApiProduct item);

        public async Task<Travel.Models.TravelCDb.ApiProduct> CreateApiProduct(Travel.Models.TravelCDb.ApiProduct apiproduct)
        {
            OnApiProductCreated(apiproduct);

            var existingItem = Context.ApiProducts
                              .Where(i => i.Id == apiproduct.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ApiProducts.Add(apiproduct);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(apiproduct).State = EntityState.Detached;
                throw;
            }

            OnAfterApiProductCreated(apiproduct);

            return apiproduct;
        }

        public async Task<Travel.Models.TravelCDb.ApiProduct> CancelApiProductChanges(Travel.Models.TravelCDb.ApiProduct item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnApiProductUpdated(Travel.Models.TravelCDb.ApiProduct item);
        partial void OnAfterApiProductUpdated(Travel.Models.TravelCDb.ApiProduct item);

        public async Task<Travel.Models.TravelCDb.ApiProduct> UpdateApiProduct(int id, Travel.Models.TravelCDb.ApiProduct apiproduct)
        {
            OnApiProductUpdated(apiproduct);

            var itemToUpdate = Context.ApiProducts
                              .Where(i => i.Id == apiproduct.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            apiproduct.Api = null;
            apiproduct.ProductType1 = null;

            Context.Attach(apiproduct).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterApiProductUpdated(apiproduct);

            return apiproduct;
        }

        partial void OnApiProductDeleted(Travel.Models.TravelCDb.ApiProduct item);
        partial void OnAfterApiProductDeleted(Travel.Models.TravelCDb.ApiProduct item);

        public async Task<Travel.Models.TravelCDb.ApiProduct> DeleteApiProduct(int id)
        {
            var itemToDelete = Context.ApiProducts
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnApiProductDeleted(itemToDelete);

            Reset();

            Context.ApiProducts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterApiProductDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportApiResultsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/apiresults/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/apiresults/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportApiResultsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/apiresults/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/apiresults/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnApiResultsRead(ref IQueryable<Travel.Models.TravelCDb.ApiResult> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.ApiResult>> GetApiResults(Query query = null)
        {
            var items = Context.ApiResults.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnApiResultsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnApiResultGet(Travel.Models.TravelCDb.ApiResult item);

        public async Task<Travel.Models.TravelCDb.ApiResult> GetApiResultById(int id)
        {
            var items = Context.ApiResults
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.ProductType1);
  
            var itemToReturn = items.FirstOrDefault();

            OnApiResultGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnApiResultCreated(Travel.Models.TravelCDb.ApiResult item);
        partial void OnAfterApiResultCreated(Travel.Models.TravelCDb.ApiResult item);

        public async Task<Travel.Models.TravelCDb.ApiResult> CreateApiResult(Travel.Models.TravelCDb.ApiResult apiresult)
        {
            OnApiResultCreated(apiresult);

            var existingItem = Context.ApiResults
                              .Where(i => i.Id == apiresult.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ApiResults.Add(apiresult);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(apiresult).State = EntityState.Detached;
                throw;
            }

            OnAfterApiResultCreated(apiresult);

            return apiresult;
        }

        public async Task<Travel.Models.TravelCDb.ApiResult> CancelApiResultChanges(Travel.Models.TravelCDb.ApiResult item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnApiResultUpdated(Travel.Models.TravelCDb.ApiResult item);
        partial void OnAfterApiResultUpdated(Travel.Models.TravelCDb.ApiResult item);

        public async Task<Travel.Models.TravelCDb.ApiResult> UpdateApiResult(int id, Travel.Models.TravelCDb.ApiResult apiresult)
        {
            OnApiResultUpdated(apiresult);

            var itemToUpdate = Context.ApiResults
                              .Where(i => i.Id == apiresult.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            apiresult.ProductType1 = null;

            Context.Attach(apiresult).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterApiResultUpdated(apiresult);

            return apiresult;
        }

        partial void OnApiResultDeleted(Travel.Models.TravelCDb.ApiResult item);
        partial void OnAfterApiResultDeleted(Travel.Models.TravelCDb.ApiResult item);

        public async Task<Travel.Models.TravelCDb.ApiResult> DeleteApiResult(int id)
        {
            var itemToDelete = Context.ApiResults
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnApiResultDeleted(itemToDelete);

            Reset();

            Context.ApiResults.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterApiResultDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAutoCompletesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/autocompletes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/autocompletes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAutoCompletesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/autocompletes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/autocompletes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAutoCompletesRead(ref IQueryable<Travel.Models.TravelCDb.AutoComplete> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.AutoComplete>> GetAutoCompletes(Query query = null)
        {
            var items = Context.AutoCompletes.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAutoCompletesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAutoCompleteGet(Travel.Models.TravelCDb.AutoComplete item);

        public async Task<Travel.Models.TravelCDb.AutoComplete> GetAutoCompleteById(int id)
        {
            var items = Context.AutoCompletes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Api);
                items = items.Include(i => i.AutoCompleteType);
  
            var itemToReturn = items.FirstOrDefault();

            OnAutoCompleteGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAutoCompleteCreated(Travel.Models.TravelCDb.AutoComplete item);
        partial void OnAfterAutoCompleteCreated(Travel.Models.TravelCDb.AutoComplete item);

        public async Task<Travel.Models.TravelCDb.AutoComplete> CreateAutoComplete(Travel.Models.TravelCDb.AutoComplete autocomplete)
        {
            OnAutoCompleteCreated(autocomplete);

            var existingItem = Context.AutoCompletes
                              .Where(i => i.Id == autocomplete.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AutoCompletes.Add(autocomplete);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(autocomplete).State = EntityState.Detached;
                throw;
            }

            OnAfterAutoCompleteCreated(autocomplete);

            return autocomplete;
        }

        public async Task<Travel.Models.TravelCDb.AutoComplete> CancelAutoCompleteChanges(Travel.Models.TravelCDb.AutoComplete item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAutoCompleteUpdated(Travel.Models.TravelCDb.AutoComplete item);
        partial void OnAfterAutoCompleteUpdated(Travel.Models.TravelCDb.AutoComplete item);

        public async Task<Travel.Models.TravelCDb.AutoComplete> UpdateAutoComplete(int id, Travel.Models.TravelCDb.AutoComplete autocomplete)
        {
            OnAutoCompleteUpdated(autocomplete);

            var itemToUpdate = Context.AutoCompletes
                              .Where(i => i.Id == autocomplete.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            autocomplete.Api = null;
            autocomplete.AutoCompleteType = null;

            Context.Attach(autocomplete).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAutoCompleteUpdated(autocomplete);

            return autocomplete;
        }

        partial void OnAutoCompleteDeleted(Travel.Models.TravelCDb.AutoComplete item);
        partial void OnAfterAutoCompleteDeleted(Travel.Models.TravelCDb.AutoComplete item);

        public async Task<Travel.Models.TravelCDb.AutoComplete> DeleteAutoComplete(int id)
        {
            var itemToDelete = Context.AutoCompletes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAutoCompleteDeleted(itemToDelete);

            Reset();

            Context.AutoCompletes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAutoCompleteDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAutoCompleteTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/autocompletetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/autocompletetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAutoCompleteTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/autocompletetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/autocompletetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAutoCompleteTypesRead(ref IQueryable<Travel.Models.TravelCDb.AutoCompleteType> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.AutoCompleteType>> GetAutoCompleteTypes(Query query = null)
        {
            var items = Context.AutoCompleteTypes.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAutoCompleteTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAutoCompleteTypeGet(Travel.Models.TravelCDb.AutoCompleteType item);

        public async Task<Travel.Models.TravelCDb.AutoCompleteType> GetAutoCompleteTypeById(int id)
        {
            var items = Context.AutoCompleteTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAutoCompleteTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAutoCompleteTypeCreated(Travel.Models.TravelCDb.AutoCompleteType item);
        partial void OnAfterAutoCompleteTypeCreated(Travel.Models.TravelCDb.AutoCompleteType item);

        public async Task<Travel.Models.TravelCDb.AutoCompleteType> CreateAutoCompleteType(Travel.Models.TravelCDb.AutoCompleteType autocompletetype)
        {
            OnAutoCompleteTypeCreated(autocompletetype);

            var existingItem = Context.AutoCompleteTypes
                              .Where(i => i.Id == autocompletetype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AutoCompleteTypes.Add(autocompletetype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(autocompletetype).State = EntityState.Detached;
                throw;
            }

            OnAfterAutoCompleteTypeCreated(autocompletetype);

            return autocompletetype;
        }

        public async Task<Travel.Models.TravelCDb.AutoCompleteType> CancelAutoCompleteTypeChanges(Travel.Models.TravelCDb.AutoCompleteType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAutoCompleteTypeUpdated(Travel.Models.TravelCDb.AutoCompleteType item);
        partial void OnAfterAutoCompleteTypeUpdated(Travel.Models.TravelCDb.AutoCompleteType item);

        public async Task<Travel.Models.TravelCDb.AutoCompleteType> UpdateAutoCompleteType(int id, Travel.Models.TravelCDb.AutoCompleteType autocompletetype)
        {
            OnAutoCompleteTypeUpdated(autocompletetype);

            var itemToUpdate = Context.AutoCompleteTypes
                              .Where(i => i.Id == autocompletetype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(autocompletetype).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAutoCompleteTypeUpdated(autocompletetype);

            return autocompletetype;
        }

        partial void OnAutoCompleteTypeDeleted(Travel.Models.TravelCDb.AutoCompleteType item);
        partial void OnAfterAutoCompleteTypeDeleted(Travel.Models.TravelCDb.AutoCompleteType item);

        public async Task<Travel.Models.TravelCDb.AutoCompleteType> DeleteAutoCompleteType(int id)
        {
            var itemToDelete = Context.AutoCompleteTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAutoCompleteTypeDeleted(itemToDelete);

            Reset();

            Context.AutoCompleteTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAutoCompleteTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/cities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/cities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/cities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/cities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCitiesRead(ref IQueryable<Travel.Models.TravelCDb.City> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.City>> GetCities(Query query = null)
        {
            var items = Context.Cities.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCitiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCityGet(Travel.Models.TravelCDb.City item);

        public async Task<Travel.Models.TravelCDb.City> GetCityById(int id)
        {
            var items = Context.Cities
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Country);
  
            var itemToReturn = items.FirstOrDefault();

            OnCityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCityCreated(Travel.Models.TravelCDb.City item);
        partial void OnAfterCityCreated(Travel.Models.TravelCDb.City item);

        public async Task<Travel.Models.TravelCDb.City> CreateCity(Travel.Models.TravelCDb.City city)
        {
            OnCityCreated(city);

            var existingItem = Context.Cities
                              .Where(i => i.Id == city.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Cities.Add(city);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(city).State = EntityState.Detached;
                throw;
            }

            OnAfterCityCreated(city);

            return city;
        }

        public async Task<Travel.Models.TravelCDb.City> CancelCityChanges(Travel.Models.TravelCDb.City item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCityUpdated(Travel.Models.TravelCDb.City item);
        partial void OnAfterCityUpdated(Travel.Models.TravelCDb.City item);

        public async Task<Travel.Models.TravelCDb.City> UpdateCity(int id, Travel.Models.TravelCDb.City city)
        {
            OnCityUpdated(city);

            var itemToUpdate = Context.Cities
                              .Where(i => i.Id == city.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            city.Country = null;

            Context.Attach(city).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCityUpdated(city);

            return city;
        }

        partial void OnCityDeleted(Travel.Models.TravelCDb.City item);
        partial void OnAfterCityDeleted(Travel.Models.TravelCDb.City item);

        public async Task<Travel.Models.TravelCDb.City> DeleteCity(int id)
        {
            var itemToDelete = Context.Cities
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCityDeleted(itemToDelete);

            Reset();

            Context.Cities.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCityDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCountriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/countries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/countries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCountriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/countries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/countries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCountriesRead(ref IQueryable<Travel.Models.TravelCDb.Country> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.Country>> GetCountries(Query query = null)
        {
            var items = Context.Countries.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCountriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCountryGet(Travel.Models.TravelCDb.Country item);

        public async Task<Travel.Models.TravelCDb.Country> GetCountryById(int id)
        {
            var items = Context.Countries
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Language);
                items = items.Include(i => i.MicroSiteCountriesFraudRisk);
  
            var itemToReturn = items.FirstOrDefault();

            OnCountryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCountryCreated(Travel.Models.TravelCDb.Country item);
        partial void OnAfterCountryCreated(Travel.Models.TravelCDb.Country item);

        public async Task<Travel.Models.TravelCDb.Country> CreateCountry(Travel.Models.TravelCDb.Country country)
        {
            OnCountryCreated(country);

            var existingItem = Context.Countries
                              .Where(i => i.Id == country.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Countries.Add(country);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(country).State = EntityState.Detached;
                throw;
            }

            OnAfterCountryCreated(country);

            return country;
        }

        public async Task<Travel.Models.TravelCDb.Country> CancelCountryChanges(Travel.Models.TravelCDb.Country item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCountryUpdated(Travel.Models.TravelCDb.Country item);
        partial void OnAfterCountryUpdated(Travel.Models.TravelCDb.Country item);

        public async Task<Travel.Models.TravelCDb.Country> UpdateCountry(int id, Travel.Models.TravelCDb.Country country)
        {
            OnCountryUpdated(country);

            var itemToUpdate = Context.Countries
                              .Where(i => i.Id == country.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            country.Language = null;
            country.MicroSiteCountriesFraudRisk = null;

            Context.Attach(country).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCountryUpdated(country);

            return country;
        }

        partial void OnCountryDeleted(Travel.Models.TravelCDb.Country item);
        partial void OnAfterCountryDeleted(Travel.Models.TravelCDb.Country item);

        public async Task<Travel.Models.TravelCDb.Country> DeleteCountry(int id)
        {
            var itemToDelete = Context.Countries
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCountryDeleted(itemToDelete);

            Reset();

            Context.Countries.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCountryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCurrenciesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/currencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/currencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCurrenciesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/currencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/currencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCurrenciesRead(ref IQueryable<Travel.Models.TravelCDb.Currency> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.Currency>> GetCurrencies(Query query = null)
        {
            var items = Context.Currencies.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCurrenciesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCurrencyGet(Travel.Models.TravelCDb.Currency item);

        public async Task<Travel.Models.TravelCDb.Currency> GetCurrencyById(int id)
        {
            var items = Context.Currencies
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCurrencyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCurrencyCreated(Travel.Models.TravelCDb.Currency item);
        partial void OnAfterCurrencyCreated(Travel.Models.TravelCDb.Currency item);

        public async Task<Travel.Models.TravelCDb.Currency> CreateCurrency(Travel.Models.TravelCDb.Currency currency)
        {
            OnCurrencyCreated(currency);

            var existingItem = Context.Currencies
                              .Where(i => i.Id == currency.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Currencies.Add(currency);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(currency).State = EntityState.Detached;
                throw;
            }

            OnAfterCurrencyCreated(currency);

            return currency;
        }

        public async Task<Travel.Models.TravelCDb.Currency> CancelCurrencyChanges(Travel.Models.TravelCDb.Currency item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCurrencyUpdated(Travel.Models.TravelCDb.Currency item);
        partial void OnAfterCurrencyUpdated(Travel.Models.TravelCDb.Currency item);

        public async Task<Travel.Models.TravelCDb.Currency> UpdateCurrency(int id, Travel.Models.TravelCDb.Currency currency)
        {
            OnCurrencyUpdated(currency);

            var itemToUpdate = Context.Currencies
                              .Where(i => i.Id == currency.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(currency).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCurrencyUpdated(currency);

            return currency;
        }

        partial void OnCurrencyDeleted(Travel.Models.TravelCDb.Currency item);
        partial void OnAfterCurrencyDeleted(Travel.Models.TravelCDb.Currency item);

        public async Task<Travel.Models.TravelCDb.Currency> DeleteCurrency(int id)
        {
            var itemToDelete = Context.Currencies
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCurrencyDeleted(itemToDelete);

            Reset();

            Context.Currencies.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCurrencyDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDescriptionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/descriptions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/descriptions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDescriptionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/descriptions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/descriptions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDescriptionsRead(ref IQueryable<Travel.Models.TravelCDb.Description> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.Description>> GetDescriptions(Query query = null)
        {
            var items = Context.Descriptions.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnDescriptionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDescriptionGet(Travel.Models.TravelCDb.Description item);

        public async Task<Travel.Models.TravelCDb.Description> GetDescriptionById(int id)
        {
            var items = Context.Descriptions
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Hotel);
  
            var itemToReturn = items.FirstOrDefault();

            OnDescriptionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDescriptionCreated(Travel.Models.TravelCDb.Description item);
        partial void OnAfterDescriptionCreated(Travel.Models.TravelCDb.Description item);

        public async Task<Travel.Models.TravelCDb.Description> CreateDescription(Travel.Models.TravelCDb.Description description)
        {
            OnDescriptionCreated(description);

            var existingItem = Context.Descriptions
                              .Where(i => i.Id == description.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Descriptions.Add(description);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(description).State = EntityState.Detached;
                throw;
            }

            OnAfterDescriptionCreated(description);

            return description;
        }

        public async Task<Travel.Models.TravelCDb.Description> CancelDescriptionChanges(Travel.Models.TravelCDb.Description item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDescriptionUpdated(Travel.Models.TravelCDb.Description item);
        partial void OnAfterDescriptionUpdated(Travel.Models.TravelCDb.Description item);

        public async Task<Travel.Models.TravelCDb.Description> UpdateDescription(int id, Travel.Models.TravelCDb.Description description)
        {
            OnDescriptionUpdated(description);

            var itemToUpdate = Context.Descriptions
                              .Where(i => i.Id == description.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            description.Hotel = null;

            Context.Attach(description).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDescriptionUpdated(description);

            return description;
        }

        partial void OnDescriptionDeleted(Travel.Models.TravelCDb.Description item);
        partial void OnAfterDescriptionDeleted(Travel.Models.TravelCDb.Description item);

        public async Task<Travel.Models.TravelCDb.Description> DeleteDescription(int id)
        {
            var itemToDelete = Context.Descriptions
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDescriptionDeleted(itemToDelete);

            Reset();

            Context.Descriptions.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDescriptionDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFraudRisksToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/fraudrisks/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/fraudrisks/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFraudRisksToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/fraudrisks/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/fraudrisks/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFraudRisksRead(ref IQueryable<Travel.Models.TravelCDb.FraudRisk> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.FraudRisk>> GetFraudRisks(Query query = null)
        {
            var items = Context.FraudRisks.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnFraudRisksRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFraudRiskGet(Travel.Models.TravelCDb.FraudRisk item);

        public async Task<Travel.Models.TravelCDb.FraudRisk> GetFraudRiskById(int id)
        {
            var items = Context.FraudRisks
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnFraudRiskGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFraudRiskCreated(Travel.Models.TravelCDb.FraudRisk item);
        partial void OnAfterFraudRiskCreated(Travel.Models.TravelCDb.FraudRisk item);

        public async Task<Travel.Models.TravelCDb.FraudRisk> CreateFraudRisk(Travel.Models.TravelCDb.FraudRisk fraudrisk)
        {
            OnFraudRiskCreated(fraudrisk);

            var existingItem = Context.FraudRisks
                              .Where(i => i.Id == fraudrisk.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.FraudRisks.Add(fraudrisk);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(fraudrisk).State = EntityState.Detached;
                throw;
            }

            OnAfterFraudRiskCreated(fraudrisk);

            return fraudrisk;
        }

        public async Task<Travel.Models.TravelCDb.FraudRisk> CancelFraudRiskChanges(Travel.Models.TravelCDb.FraudRisk item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFraudRiskUpdated(Travel.Models.TravelCDb.FraudRisk item);
        partial void OnAfterFraudRiskUpdated(Travel.Models.TravelCDb.FraudRisk item);

        public async Task<Travel.Models.TravelCDb.FraudRisk> UpdateFraudRisk(int id, Travel.Models.TravelCDb.FraudRisk fraudrisk)
        {
            OnFraudRiskUpdated(fraudrisk);

            var itemToUpdate = Context.FraudRisks
                              .Where(i => i.Id == fraudrisk.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(fraudrisk).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFraudRiskUpdated(fraudrisk);

            return fraudrisk;
        }

        partial void OnFraudRiskDeleted(Travel.Models.TravelCDb.FraudRisk item);
        partial void OnAfterFraudRiskDeleted(Travel.Models.TravelCDb.FraudRisk item);

        public async Task<Travel.Models.TravelCDb.FraudRisk> DeleteFraudRisk(int id)
        {
            var itemToDelete = Context.FraudRisks
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFraudRiskDeleted(itemToDelete);

            Reset();

            Context.FraudRisks.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFraudRiskDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportGendersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/genders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/genders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportGendersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/genders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/genders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGendersRead(ref IQueryable<Travel.Models.TravelCDb.Gender> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.Gender>> GetGenders(Query query = null)
        {
            var items = Context.Genders.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnGendersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnGenderGet(Travel.Models.TravelCDb.Gender item);

        public async Task<Travel.Models.TravelCDb.Gender> GetGenderById(int id)
        {
            var items = Context.Genders
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnGenderGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnGenderCreated(Travel.Models.TravelCDb.Gender item);
        partial void OnAfterGenderCreated(Travel.Models.TravelCDb.Gender item);

        public async Task<Travel.Models.TravelCDb.Gender> CreateGender(Travel.Models.TravelCDb.Gender gender)
        {
            OnGenderCreated(gender);

            var existingItem = Context.Genders
                              .Where(i => i.Id == gender.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Genders.Add(gender);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(gender).State = EntityState.Detached;
                throw;
            }

            OnAfterGenderCreated(gender);

            return gender;
        }

        public async Task<Travel.Models.TravelCDb.Gender> CancelGenderChanges(Travel.Models.TravelCDb.Gender item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnGenderUpdated(Travel.Models.TravelCDb.Gender item);
        partial void OnAfterGenderUpdated(Travel.Models.TravelCDb.Gender item);

        public async Task<Travel.Models.TravelCDb.Gender> UpdateGender(int id, Travel.Models.TravelCDb.Gender gender)
        {
            OnGenderUpdated(gender);

            var itemToUpdate = Context.Genders
                              .Where(i => i.Id == gender.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(gender).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterGenderUpdated(gender);

            return gender;
        }

        partial void OnGenderDeleted(Travel.Models.TravelCDb.Gender item);
        partial void OnAfterGenderDeleted(Travel.Models.TravelCDb.Gender item);

        public async Task<Travel.Models.TravelCDb.Gender> DeleteGender(int id)
        {
            var itemToDelete = Context.Genders
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnGenderDeleted(itemToDelete);

            Reset();

            Context.Genders.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterGenderDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/hotelcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/hotelcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/hotelcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/hotelcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelCategoriesRead(ref IQueryable<Travel.Models.TravelCDb.HotelCategory> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.HotelCategory>> GetHotelCategories(Query query = null)
        {
            var items = Context.HotelCategories.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnHotelCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelCategoryGet(Travel.Models.TravelCDb.HotelCategory item);

        public async Task<Travel.Models.TravelCDb.HotelCategory> GetHotelCategoryById(int id)
        {
            var items = Context.HotelCategories
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Api);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelCategoryCreated(Travel.Models.TravelCDb.HotelCategory item);
        partial void OnAfterHotelCategoryCreated(Travel.Models.TravelCDb.HotelCategory item);

        public async Task<Travel.Models.TravelCDb.HotelCategory> CreateHotelCategory(Travel.Models.TravelCDb.HotelCategory hotelcategory)
        {
            OnHotelCategoryCreated(hotelcategory);

            var existingItem = Context.HotelCategories
                              .Where(i => i.Id == hotelcategory.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelCategories.Add(hotelcategory);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelcategory).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelCategoryCreated(hotelcategory);

            return hotelcategory;
        }

        public async Task<Travel.Models.TravelCDb.HotelCategory> CancelHotelCategoryChanges(Travel.Models.TravelCDb.HotelCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelCategoryUpdated(Travel.Models.TravelCDb.HotelCategory item);
        partial void OnAfterHotelCategoryUpdated(Travel.Models.TravelCDb.HotelCategory item);

        public async Task<Travel.Models.TravelCDb.HotelCategory> UpdateHotelCategory(int id, Travel.Models.TravelCDb.HotelCategory hotelcategory)
        {
            OnHotelCategoryUpdated(hotelcategory);

            var itemToUpdate = Context.HotelCategories
                              .Where(i => i.Id == hotelcategory.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            hotelcategory.Api = null;

            Context.Attach(hotelcategory).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelCategoryUpdated(hotelcategory);

            return hotelcategory;
        }

        partial void OnHotelCategoryDeleted(Travel.Models.TravelCDb.HotelCategory item);
        partial void OnAfterHotelCategoryDeleted(Travel.Models.TravelCDb.HotelCategory item);

        public async Task<Travel.Models.TravelCDb.HotelCategory> DeleteHotelCategory(int id)
        {
            var itemToDelete = Context.HotelCategories
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelCategoryDeleted(itemToDelete);

            Reset();

            Context.HotelCategories.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelCategoryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelFacilitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/hotelfacilities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/hotelfacilities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelFacilitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/hotelfacilities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/hotelfacilities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelFacilitiesRead(ref IQueryable<Travel.Models.TravelCDb.HotelFacility> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.HotelFacility>> GetHotelFacilities(Query query = null)
        {
            var items = Context.HotelFacilities.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnHotelFacilitiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelFacilityGet(Travel.Models.TravelCDb.HotelFacility item);

        public async Task<Travel.Models.TravelCDb.HotelFacility> GetHotelFacilityById(int id)
        {
            var items = Context.HotelFacilities
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelFacilityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelFacilityCreated(Travel.Models.TravelCDb.HotelFacility item);
        partial void OnAfterHotelFacilityCreated(Travel.Models.TravelCDb.HotelFacility item);

        public async Task<Travel.Models.TravelCDb.HotelFacility> CreateHotelFacility(Travel.Models.TravelCDb.HotelFacility hotelfacility)
        {
            OnHotelFacilityCreated(hotelfacility);

            var existingItem = Context.HotelFacilities
                              .Where(i => i.Id == hotelfacility.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelFacilities.Add(hotelfacility);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelfacility).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelFacilityCreated(hotelfacility);

            return hotelfacility;
        }

        public async Task<Travel.Models.TravelCDb.HotelFacility> CancelHotelFacilityChanges(Travel.Models.TravelCDb.HotelFacility item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelFacilityUpdated(Travel.Models.TravelCDb.HotelFacility item);
        partial void OnAfterHotelFacilityUpdated(Travel.Models.TravelCDb.HotelFacility item);

        public async Task<Travel.Models.TravelCDb.HotelFacility> UpdateHotelFacility(int id, Travel.Models.TravelCDb.HotelFacility hotelfacility)
        {
            OnHotelFacilityUpdated(hotelfacility);

            var itemToUpdate = Context.HotelFacilities
                              .Where(i => i.Id == hotelfacility.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(hotelfacility).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelFacilityUpdated(hotelfacility);

            return hotelfacility;
        }

        partial void OnHotelFacilityDeleted(Travel.Models.TravelCDb.HotelFacility item);
        partial void OnAfterHotelFacilityDeleted(Travel.Models.TravelCDb.HotelFacility item);

        public async Task<Travel.Models.TravelCDb.HotelFacility> DeleteHotelFacility(int id)
        {
            var itemToDelete = Context.HotelFacilities
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelFacilityDeleted(itemToDelete);

            Reset();

            Context.HotelFacilities.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelFacilityDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelFacilityCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/hotelfacilitycategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/hotelfacilitycategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelFacilityCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/hotelfacilitycategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/hotelfacilitycategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelFacilityCategoriesRead(ref IQueryable<Travel.Models.TravelCDb.HotelFacilityCategory> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.HotelFacilityCategory>> GetHotelFacilityCategories(Query query = null)
        {
            var items = Context.HotelFacilityCategories.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnHotelFacilityCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelFacilityCategoryGet(Travel.Models.TravelCDb.HotelFacilityCategory item);

        public async Task<Travel.Models.TravelCDb.HotelFacilityCategory> GetHotelFacilityCategoryById(int id)
        {
            var items = Context.HotelFacilityCategories
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelFacilityCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelFacilityCategoryCreated(Travel.Models.TravelCDb.HotelFacilityCategory item);
        partial void OnAfterHotelFacilityCategoryCreated(Travel.Models.TravelCDb.HotelFacilityCategory item);

        public async Task<Travel.Models.TravelCDb.HotelFacilityCategory> CreateHotelFacilityCategory(Travel.Models.TravelCDb.HotelFacilityCategory hotelfacilitycategory)
        {
            OnHotelFacilityCategoryCreated(hotelfacilitycategory);

            var existingItem = Context.HotelFacilityCategories
                              .Where(i => i.Id == hotelfacilitycategory.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelFacilityCategories.Add(hotelfacilitycategory);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelfacilitycategory).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelFacilityCategoryCreated(hotelfacilitycategory);

            return hotelfacilitycategory;
        }

        public async Task<Travel.Models.TravelCDb.HotelFacilityCategory> CancelHotelFacilityCategoryChanges(Travel.Models.TravelCDb.HotelFacilityCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelFacilityCategoryUpdated(Travel.Models.TravelCDb.HotelFacilityCategory item);
        partial void OnAfterHotelFacilityCategoryUpdated(Travel.Models.TravelCDb.HotelFacilityCategory item);

        public async Task<Travel.Models.TravelCDb.HotelFacilityCategory> UpdateHotelFacilityCategory(int id, Travel.Models.TravelCDb.HotelFacilityCategory hotelfacilitycategory)
        {
            OnHotelFacilityCategoryUpdated(hotelfacilitycategory);

            var itemToUpdate = Context.HotelFacilityCategories
                              .Where(i => i.Id == hotelfacilitycategory.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(hotelfacilitycategory).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelFacilityCategoryUpdated(hotelfacilitycategory);

            return hotelfacilitycategory;
        }

        partial void OnHotelFacilityCategoryDeleted(Travel.Models.TravelCDb.HotelFacilityCategory item);
        partial void OnAfterHotelFacilityCategoryDeleted(Travel.Models.TravelCDb.HotelFacilityCategory item);

        public async Task<Travel.Models.TravelCDb.HotelFacilityCategory> DeleteHotelFacilityCategory(int id)
        {
            var itemToDelete = Context.HotelFacilityCategories
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelFacilityCategoryDeleted(itemToDelete);

            Reset();

            Context.HotelFacilityCategories.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelFacilityCategoryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelPresentationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/hotelpresentations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/hotelpresentations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelPresentationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/hotelpresentations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/hotelpresentations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelPresentationsRead(ref IQueryable<Travel.Models.TravelCDb.HotelPresentation> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.HotelPresentation>> GetHotelPresentations(Query query = null)
        {
            var items = Context.HotelPresentations.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnHotelPresentationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelPresentationGet(Travel.Models.TravelCDb.HotelPresentation item);

        public async Task<Travel.Models.TravelCDb.HotelPresentation> GetHotelPresentationById(int id)
        {
            var items = Context.HotelPresentations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelPresentationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelPresentationCreated(Travel.Models.TravelCDb.HotelPresentation item);
        partial void OnAfterHotelPresentationCreated(Travel.Models.TravelCDb.HotelPresentation item);

        public async Task<Travel.Models.TravelCDb.HotelPresentation> CreateHotelPresentation(Travel.Models.TravelCDb.HotelPresentation hotelpresentation)
        {
            OnHotelPresentationCreated(hotelpresentation);

            var existingItem = Context.HotelPresentations
                              .Where(i => i.Id == hotelpresentation.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelPresentations.Add(hotelpresentation);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelpresentation).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelPresentationCreated(hotelpresentation);

            return hotelpresentation;
        }

        public async Task<Travel.Models.TravelCDb.HotelPresentation> CancelHotelPresentationChanges(Travel.Models.TravelCDb.HotelPresentation item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelPresentationUpdated(Travel.Models.TravelCDb.HotelPresentation item);
        partial void OnAfterHotelPresentationUpdated(Travel.Models.TravelCDb.HotelPresentation item);

        public async Task<Travel.Models.TravelCDb.HotelPresentation> UpdateHotelPresentation(int id, Travel.Models.TravelCDb.HotelPresentation hotelpresentation)
        {
            OnHotelPresentationUpdated(hotelpresentation);

            var itemToUpdate = Context.HotelPresentations
                              .Where(i => i.Id == hotelpresentation.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(hotelpresentation).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelPresentationUpdated(hotelpresentation);

            return hotelpresentation;
        }

        partial void OnHotelPresentationDeleted(Travel.Models.TravelCDb.HotelPresentation item);
        partial void OnAfterHotelPresentationDeleted(Travel.Models.TravelCDb.HotelPresentation item);

        public async Task<Travel.Models.TravelCDb.HotelPresentation> DeleteHotelPresentation(int id)
        {
            var itemToDelete = Context.HotelPresentations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelPresentationDeleted(itemToDelete);

            Reset();

            Context.HotelPresentations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelPresentationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/hotels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/hotels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/hotels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/hotels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelsRead(ref IQueryable<Travel.Models.TravelCDb.Hotel> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.Hotel>> GetHotels(Query query = null)
        {
            var items = Context.Hotels.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnHotelsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelGet(Travel.Models.TravelCDb.Hotel item);

        public async Task<Travel.Models.TravelCDb.Hotel> GetHotelById(int id)
        {
            var items = Context.Hotels
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Agency);
                items = items.Include(i => i.Api);
                items = items.Include(i => i.FraudRisk);
                items = items.Include(i => i.ManuelRegistration);
                items = items.Include(i => i.MicroSite);
                items = items.Include(i => i.Statu1);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelCreated(Travel.Models.TravelCDb.Hotel item);
        partial void OnAfterHotelCreated(Travel.Models.TravelCDb.Hotel item);

        public async Task<Travel.Models.TravelCDb.Hotel> CreateHotel(Travel.Models.TravelCDb.Hotel hotel)
        {
            OnHotelCreated(hotel);

            var existingItem = Context.Hotels
                              .Where(i => i.Id == hotel.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Hotels.Add(hotel);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotel).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelCreated(hotel);

            return hotel;
        }

        public async Task<Travel.Models.TravelCDb.Hotel> CancelHotelChanges(Travel.Models.TravelCDb.Hotel item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelUpdated(Travel.Models.TravelCDb.Hotel item);
        partial void OnAfterHotelUpdated(Travel.Models.TravelCDb.Hotel item);

        public async Task<Travel.Models.TravelCDb.Hotel> UpdateHotel(int id, Travel.Models.TravelCDb.Hotel hotel)
        {
            OnHotelUpdated(hotel);

            var itemToUpdate = Context.Hotels
                              .Where(i => i.Id == hotel.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            hotel.Agency = null;
            hotel.Api = null;
            hotel.FraudRisk = null;
            hotel.ManuelRegistration = null;
            hotel.MicroSite = null;
            hotel.Statu1 = null;

            Context.Attach(hotel).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelUpdated(hotel);

            return hotel;
        }

        partial void OnHotelDeleted(Travel.Models.TravelCDb.Hotel item);
        partial void OnAfterHotelDeleted(Travel.Models.TravelCDb.Hotel item);

        public async Task<Travel.Models.TravelCDb.Hotel> DeleteHotel(int id)
        {
            var itemToDelete = Context.Hotels
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelDeleted(itemToDelete);

            Reset();

            Context.Hotels.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportInvoiceTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/invoicetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/invoicetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInvoiceTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/invoicetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/invoicetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInvoiceTypesRead(ref IQueryable<Travel.Models.TravelCDb.InvoiceType> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.InvoiceType>> GetInvoiceTypes(Query query = null)
        {
            var items = Context.InvoiceTypes.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInvoiceTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnInvoiceTypeGet(Travel.Models.TravelCDb.InvoiceType item);

        public async Task<Travel.Models.TravelCDb.InvoiceType> GetInvoiceTypeById(int id)
        {
            var items = Context.InvoiceTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnInvoiceTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnInvoiceTypeCreated(Travel.Models.TravelCDb.InvoiceType item);
        partial void OnAfterInvoiceTypeCreated(Travel.Models.TravelCDb.InvoiceType item);

        public async Task<Travel.Models.TravelCDb.InvoiceType> CreateInvoiceType(Travel.Models.TravelCDb.InvoiceType invoicetype)
        {
            OnInvoiceTypeCreated(invoicetype);

            var existingItem = Context.InvoiceTypes
                              .Where(i => i.Id == invoicetype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.InvoiceTypes.Add(invoicetype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(invoicetype).State = EntityState.Detached;
                throw;
            }

            OnAfterInvoiceTypeCreated(invoicetype);

            return invoicetype;
        }

        public async Task<Travel.Models.TravelCDb.InvoiceType> CancelInvoiceTypeChanges(Travel.Models.TravelCDb.InvoiceType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnInvoiceTypeUpdated(Travel.Models.TravelCDb.InvoiceType item);
        partial void OnAfterInvoiceTypeUpdated(Travel.Models.TravelCDb.InvoiceType item);

        public async Task<Travel.Models.TravelCDb.InvoiceType> UpdateInvoiceType(int id, Travel.Models.TravelCDb.InvoiceType invoicetype)
        {
            OnInvoiceTypeUpdated(invoicetype);

            var itemToUpdate = Context.InvoiceTypes
                              .Where(i => i.Id == invoicetype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(invoicetype).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterInvoiceTypeUpdated(invoicetype);

            return invoicetype;
        }

        partial void OnInvoiceTypeDeleted(Travel.Models.TravelCDb.InvoiceType item);
        partial void OnAfterInvoiceTypeDeleted(Travel.Models.TravelCDb.InvoiceType item);

        public async Task<Travel.Models.TravelCDb.InvoiceType> DeleteInvoiceType(int id)
        {
            var itemToDelete = Context.InvoiceTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnInvoiceTypeDeleted(itemToDelete);

            Reset();

            Context.InvoiceTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterInvoiceTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportManuelRegistrationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/manuelregistrations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/manuelregistrations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportManuelRegistrationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/manuelregistrations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/manuelregistrations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnManuelRegistrationsRead(ref IQueryable<Travel.Models.TravelCDb.ManuelRegistration> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.ManuelRegistration>> GetManuelRegistrations(Query query = null)
        {
            var items = Context.ManuelRegistrations.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnManuelRegistrationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnManuelRegistrationGet(Travel.Models.TravelCDb.ManuelRegistration item);

        public async Task<Travel.Models.TravelCDb.ManuelRegistration> GetManuelRegistrationById(int id)
        {
            var items = Context.ManuelRegistrations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnManuelRegistrationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnManuelRegistrationCreated(Travel.Models.TravelCDb.ManuelRegistration item);
        partial void OnAfterManuelRegistrationCreated(Travel.Models.TravelCDb.ManuelRegistration item);

        public async Task<Travel.Models.TravelCDb.ManuelRegistration> CreateManuelRegistration(Travel.Models.TravelCDb.ManuelRegistration manuelregistration)
        {
            OnManuelRegistrationCreated(manuelregistration);

            var existingItem = Context.ManuelRegistrations
                              .Where(i => i.Id == manuelregistration.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ManuelRegistrations.Add(manuelregistration);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(manuelregistration).State = EntityState.Detached;
                throw;
            }

            OnAfterManuelRegistrationCreated(manuelregistration);

            return manuelregistration;
        }

        public async Task<Travel.Models.TravelCDb.ManuelRegistration> CancelManuelRegistrationChanges(Travel.Models.TravelCDb.ManuelRegistration item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnManuelRegistrationUpdated(Travel.Models.TravelCDb.ManuelRegistration item);
        partial void OnAfterManuelRegistrationUpdated(Travel.Models.TravelCDb.ManuelRegistration item);

        public async Task<Travel.Models.TravelCDb.ManuelRegistration> UpdateManuelRegistration(int id, Travel.Models.TravelCDb.ManuelRegistration manuelregistration)
        {
            OnManuelRegistrationUpdated(manuelregistration);

            var itemToUpdate = Context.ManuelRegistrations
                              .Where(i => i.Id == manuelregistration.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(manuelregistration).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterManuelRegistrationUpdated(manuelregistration);

            return manuelregistration;
        }

        partial void OnManuelRegistrationDeleted(Travel.Models.TravelCDb.ManuelRegistration item);
        partial void OnAfterManuelRegistrationDeleted(Travel.Models.TravelCDb.ManuelRegistration item);

        public async Task<Travel.Models.TravelCDb.ManuelRegistration> DeleteManuelRegistration(int id)
        {
            var itemToDelete = Context.ManuelRegistrations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnManuelRegistrationDeleted(itemToDelete);

            Reset();

            Context.ManuelRegistrations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterManuelRegistrationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportMicroSiteApiProvidersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/micrositeapiproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/micrositeapiproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMicroSiteApiProvidersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/micrositeapiproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/micrositeapiproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMicroSiteApiProvidersRead(ref IQueryable<Travel.Models.TravelCDb.MicroSiteApiProvider> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.MicroSiteApiProvider>> GetMicroSiteApiProviders(Query query = null)
        {
            var items = Context.MicroSiteApiProviders.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnMicroSiteApiProvidersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMicroSiteApiProviderGet(Travel.Models.TravelCDb.MicroSiteApiProvider item);

        public async Task<Travel.Models.TravelCDb.MicroSiteApiProvider> GetMicroSiteApiProviderById(int id)
        {
            var items = Context.MicroSiteApiProviders
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Agency);
                items = items.Include(i => i.Api);
                items = items.Include(i => i.ApiProduct);
                items = items.Include(i => i.MicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnMicroSiteApiProviderGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMicroSiteApiProviderCreated(Travel.Models.TravelCDb.MicroSiteApiProvider item);
        partial void OnAfterMicroSiteApiProviderCreated(Travel.Models.TravelCDb.MicroSiteApiProvider item);

        public async Task<Travel.Models.TravelCDb.MicroSiteApiProvider> CreateMicroSiteApiProvider(Travel.Models.TravelCDb.MicroSiteApiProvider micrositeapiprovider)
        {
            OnMicroSiteApiProviderCreated(micrositeapiprovider);

            var existingItem = Context.MicroSiteApiProviders
                              .Where(i => i.Id == micrositeapiprovider.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.MicroSiteApiProviders.Add(micrositeapiprovider);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(micrositeapiprovider).State = EntityState.Detached;
                throw;
            }

            OnAfterMicroSiteApiProviderCreated(micrositeapiprovider);

            return micrositeapiprovider;
        }

        public async Task<Travel.Models.TravelCDb.MicroSiteApiProvider> CancelMicroSiteApiProviderChanges(Travel.Models.TravelCDb.MicroSiteApiProvider item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMicroSiteApiProviderUpdated(Travel.Models.TravelCDb.MicroSiteApiProvider item);
        partial void OnAfterMicroSiteApiProviderUpdated(Travel.Models.TravelCDb.MicroSiteApiProvider item);

        public async Task<Travel.Models.TravelCDb.MicroSiteApiProvider> UpdateMicroSiteApiProvider(int id, Travel.Models.TravelCDb.MicroSiteApiProvider micrositeapiprovider)
        {
            OnMicroSiteApiProviderUpdated(micrositeapiprovider);

            var itemToUpdate = Context.MicroSiteApiProviders
                              .Where(i => i.Id == micrositeapiprovider.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            micrositeapiprovider.Agency = null;
            micrositeapiprovider.Api = null;
            micrositeapiprovider.ApiProduct = null;
            micrositeapiprovider.MicroSite = null;

            Context.Attach(micrositeapiprovider).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMicroSiteApiProviderUpdated(micrositeapiprovider);

            return micrositeapiprovider;
        }

        partial void OnMicroSiteApiProviderDeleted(Travel.Models.TravelCDb.MicroSiteApiProvider item);
        partial void OnAfterMicroSiteApiProviderDeleted(Travel.Models.TravelCDb.MicroSiteApiProvider item);

        public async Task<Travel.Models.TravelCDb.MicroSiteApiProvider> DeleteMicroSiteApiProvider(int id)
        {
            var itemToDelete = Context.MicroSiteApiProviders
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMicroSiteApiProviderDeleted(itemToDelete);

            Reset();

            Context.MicroSiteApiProviders.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMicroSiteApiProviderDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportMicrositeCountriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/micrositecountries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/micrositecountries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMicrositeCountriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/micrositecountries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/micrositecountries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMicrositeCountriesRead(ref IQueryable<Travel.Models.TravelCDb.MicrositeCountry> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.MicrositeCountry>> GetMicrositeCountries(Query query = null)
        {
            var items = Context.MicrositeCountries.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnMicrositeCountriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMicrositeCountryGet(Travel.Models.TravelCDb.MicrositeCountry item);

        public async Task<Travel.Models.TravelCDb.MicrositeCountry> GetMicrositeCountryById(int id)
        {
            var items = Context.MicrositeCountries
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Agency);
                items = items.Include(i => i.MicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnMicrositeCountryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMicrositeCountryCreated(Travel.Models.TravelCDb.MicrositeCountry item);
        partial void OnAfterMicrositeCountryCreated(Travel.Models.TravelCDb.MicrositeCountry item);

        public async Task<Travel.Models.TravelCDb.MicrositeCountry> CreateMicrositeCountry(Travel.Models.TravelCDb.MicrositeCountry micrositecountry)
        {
            OnMicrositeCountryCreated(micrositecountry);

            var existingItem = Context.MicrositeCountries
                              .Where(i => i.Id == micrositecountry.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.MicrositeCountries.Add(micrositecountry);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(micrositecountry).State = EntityState.Detached;
                throw;
            }

            OnAfterMicrositeCountryCreated(micrositecountry);

            return micrositecountry;
        }

        public async Task<Travel.Models.TravelCDb.MicrositeCountry> CancelMicrositeCountryChanges(Travel.Models.TravelCDb.MicrositeCountry item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMicrositeCountryUpdated(Travel.Models.TravelCDb.MicrositeCountry item);
        partial void OnAfterMicrositeCountryUpdated(Travel.Models.TravelCDb.MicrositeCountry item);

        public async Task<Travel.Models.TravelCDb.MicrositeCountry> UpdateMicrositeCountry(int id, Travel.Models.TravelCDb.MicrositeCountry micrositecountry)
        {
            OnMicrositeCountryUpdated(micrositecountry);

            var itemToUpdate = Context.MicrositeCountries
                              .Where(i => i.Id == micrositecountry.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            micrositecountry.Agency = null;
            micrositecountry.MicroSite = null;

            Context.Attach(micrositecountry).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMicrositeCountryUpdated(micrositecountry);

            return micrositecountry;
        }

        partial void OnMicrositeCountryDeleted(Travel.Models.TravelCDb.MicrositeCountry item);
        partial void OnAfterMicrositeCountryDeleted(Travel.Models.TravelCDb.MicrositeCountry item);

        public async Task<Travel.Models.TravelCDb.MicrositeCountry> DeleteMicrositeCountry(int id)
        {
            var itemToDelete = Context.MicrositeCountries
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMicrositeCountryDeleted(itemToDelete);

            Reset();

            Context.MicrositeCountries.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMicrositeCountryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportMicroSiteCountriesFraudRisksToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/micrositecountriesfraudrisks/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/micrositecountriesfraudrisks/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMicroSiteCountriesFraudRisksToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/micrositecountriesfraudrisks/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/micrositecountriesfraudrisks/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMicroSiteCountriesFraudRisksRead(ref IQueryable<Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk>> GetMicroSiteCountriesFraudRisks(Query query = null)
        {
            var items = Context.MicroSiteCountriesFraudRisks.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnMicroSiteCountriesFraudRisksRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMicroSiteCountriesFraudRiskGet(Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk item);

        public async Task<Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk> GetMicroSiteCountriesFraudRiskById(int id)
        {
            var items = Context.MicroSiteCountriesFraudRisks
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnMicroSiteCountriesFraudRiskGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMicroSiteCountriesFraudRiskCreated(Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk item);
        partial void OnAfterMicroSiteCountriesFraudRiskCreated(Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk item);

        public async Task<Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk> CreateMicroSiteCountriesFraudRisk(Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk micrositecountriesfraudrisk)
        {
            OnMicroSiteCountriesFraudRiskCreated(micrositecountriesfraudrisk);

            var existingItem = Context.MicroSiteCountriesFraudRisks
                              .Where(i => i.Id == micrositecountriesfraudrisk.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.MicroSiteCountriesFraudRisks.Add(micrositecountriesfraudrisk);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(micrositecountriesfraudrisk).State = EntityState.Detached;
                throw;
            }

            OnAfterMicroSiteCountriesFraudRiskCreated(micrositecountriesfraudrisk);

            return micrositecountriesfraudrisk;
        }

        public async Task<Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk> CancelMicroSiteCountriesFraudRiskChanges(Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMicroSiteCountriesFraudRiskUpdated(Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk item);
        partial void OnAfterMicroSiteCountriesFraudRiskUpdated(Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk item);

        public async Task<Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk> UpdateMicroSiteCountriesFraudRisk(int id, Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk micrositecountriesfraudrisk)
        {
            OnMicroSiteCountriesFraudRiskUpdated(micrositecountriesfraudrisk);

            var itemToUpdate = Context.MicroSiteCountriesFraudRisks
                              .Where(i => i.Id == micrositecountriesfraudrisk.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(micrositecountriesfraudrisk).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMicroSiteCountriesFraudRiskUpdated(micrositecountriesfraudrisk);

            return micrositecountriesfraudrisk;
        }

        partial void OnMicroSiteCountriesFraudRiskDeleted(Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk item);
        partial void OnAfterMicroSiteCountriesFraudRiskDeleted(Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk item);

        public async Task<Travel.Models.TravelCDb.MicroSiteCountriesFraudRisk> DeleteMicroSiteCountriesFraudRisk(int id)
        {
            var itemToDelete = Context.MicroSiteCountriesFraudRisks
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMicroSiteCountriesFraudRiskDeleted(itemToDelete);

            Reset();

            Context.MicroSiteCountriesFraudRisks.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMicroSiteCountriesFraudRiskDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportMicroSiteInvoicesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/micrositeinvoices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/micrositeinvoices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMicroSiteInvoicesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/micrositeinvoices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/micrositeinvoices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMicroSiteInvoicesRead(ref IQueryable<Travel.Models.TravelCDb.MicroSiteInvoice> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.MicroSiteInvoice>> GetMicroSiteInvoices(Query query = null)
        {
            var items = Context.MicroSiteInvoices.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnMicroSiteInvoicesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMicroSiteInvoiceGet(Travel.Models.TravelCDb.MicroSiteInvoice item);

        public async Task<Travel.Models.TravelCDb.MicroSiteInvoice> GetMicroSiteInvoiceById(int id)
        {
            var items = Context.MicroSiteInvoices
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Agency);
                items = items.Include(i => i.City);
                items = items.Include(i => i.Country);
                items = items.Include(i => i.MicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnMicroSiteInvoiceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMicroSiteInvoiceCreated(Travel.Models.TravelCDb.MicroSiteInvoice item);
        partial void OnAfterMicroSiteInvoiceCreated(Travel.Models.TravelCDb.MicroSiteInvoice item);

        public async Task<Travel.Models.TravelCDb.MicroSiteInvoice> CreateMicroSiteInvoice(Travel.Models.TravelCDb.MicroSiteInvoice micrositeinvoice)
        {
            OnMicroSiteInvoiceCreated(micrositeinvoice);

            var existingItem = Context.MicroSiteInvoices
                              .Where(i => i.Id == micrositeinvoice.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.MicroSiteInvoices.Add(micrositeinvoice);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(micrositeinvoice).State = EntityState.Detached;
                throw;
            }

            OnAfterMicroSiteInvoiceCreated(micrositeinvoice);

            return micrositeinvoice;
        }

        public async Task<Travel.Models.TravelCDb.MicroSiteInvoice> CancelMicroSiteInvoiceChanges(Travel.Models.TravelCDb.MicroSiteInvoice item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMicroSiteInvoiceUpdated(Travel.Models.TravelCDb.MicroSiteInvoice item);
        partial void OnAfterMicroSiteInvoiceUpdated(Travel.Models.TravelCDb.MicroSiteInvoice item);

        public async Task<Travel.Models.TravelCDb.MicroSiteInvoice> UpdateMicroSiteInvoice(int id, Travel.Models.TravelCDb.MicroSiteInvoice micrositeinvoice)
        {
            OnMicroSiteInvoiceUpdated(micrositeinvoice);

            var itemToUpdate = Context.MicroSiteInvoices
                              .Where(i => i.Id == micrositeinvoice.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            micrositeinvoice.Agency = null;
            micrositeinvoice.City = null;
            micrositeinvoice.Country = null;
            micrositeinvoice.MicroSite = null;

            Context.Attach(micrositeinvoice).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMicroSiteInvoiceUpdated(micrositeinvoice);

            return micrositeinvoice;
        }

        partial void OnMicroSiteInvoiceDeleted(Travel.Models.TravelCDb.MicroSiteInvoice item);
        partial void OnAfterMicroSiteInvoiceDeleted(Travel.Models.TravelCDb.MicroSiteInvoice item);

        public async Task<Travel.Models.TravelCDb.MicroSiteInvoice> DeleteMicroSiteInvoice(int id)
        {
            var itemToDelete = Context.MicroSiteInvoices
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMicroSiteInvoiceDeleted(itemToDelete);

            Reset();

            Context.MicroSiteInvoices.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMicroSiteInvoiceDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportMicroSitesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/microsites/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/microsites/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMicroSitesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/microsites/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/microsites/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMicroSitesRead(ref IQueryable<Travel.Models.TravelCDb.MicroSite> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.MicroSite>> GetMicroSites(Query query = null)
        {
            var items = Context.MicroSites.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnMicroSitesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMicroSiteGet(Travel.Models.TravelCDb.MicroSite item);

        public async Task<Travel.Models.TravelCDb.MicroSite> GetMicroSiteById(int id)
        {
            var items = Context.MicroSites
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnMicroSiteGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMicroSiteCreated(Travel.Models.TravelCDb.MicroSite item);
        partial void OnAfterMicroSiteCreated(Travel.Models.TravelCDb.MicroSite item);

        public async Task<Travel.Models.TravelCDb.MicroSite> CreateMicroSite(Travel.Models.TravelCDb.MicroSite microsite)
        {
            OnMicroSiteCreated(microsite);

            var existingItem = Context.MicroSites
                              .Where(i => i.Id == microsite.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.MicroSites.Add(microsite);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(microsite).State = EntityState.Detached;
                throw;
            }

            OnAfterMicroSiteCreated(microsite);

            return microsite;
        }

        public async Task<Travel.Models.TravelCDb.MicroSite> CancelMicroSiteChanges(Travel.Models.TravelCDb.MicroSite item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMicroSiteUpdated(Travel.Models.TravelCDb.MicroSite item);
        partial void OnAfterMicroSiteUpdated(Travel.Models.TravelCDb.MicroSite item);

        public async Task<Travel.Models.TravelCDb.MicroSite> UpdateMicroSite(int id, Travel.Models.TravelCDb.MicroSite microsite)
        {
            OnMicroSiteUpdated(microsite);

            var itemToUpdate = Context.MicroSites
                              .Where(i => i.Id == microsite.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(microsite).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMicroSiteUpdated(microsite);

            return microsite;
        }

        partial void OnMicroSiteDeleted(Travel.Models.TravelCDb.MicroSite item);
        partial void OnAfterMicroSiteDeleted(Travel.Models.TravelCDb.MicroSite item);

        public async Task<Travel.Models.TravelCDb.MicroSite> DeleteMicroSite(int id)
        {
            var itemToDelete = Context.MicroSites
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMicroSiteDeleted(itemToDelete);

            Reset();

            Context.MicroSites.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMicroSiteDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProductTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/producttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/producttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProductTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/producttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/producttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProductTypesRead(ref IQueryable<Travel.Models.TravelCDb.ProductType> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.ProductType>> GetProductTypes(Query query = null)
        {
            var items = Context.ProductTypes.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnProductTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProductTypeGet(Travel.Models.TravelCDb.ProductType item);

        public async Task<Travel.Models.TravelCDb.ProductType> GetProductTypeById(int id)
        {
            var items = Context.ProductTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProductTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProductTypeCreated(Travel.Models.TravelCDb.ProductType item);
        partial void OnAfterProductTypeCreated(Travel.Models.TravelCDb.ProductType item);

        public async Task<Travel.Models.TravelCDb.ProductType> CreateProductType(Travel.Models.TravelCDb.ProductType producttype)
        {
            OnProductTypeCreated(producttype);

            var existingItem = Context.ProductTypes
                              .Where(i => i.Id == producttype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProductTypes.Add(producttype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(producttype).State = EntityState.Detached;
                throw;
            }

            OnAfterProductTypeCreated(producttype);

            return producttype;
        }

        public async Task<Travel.Models.TravelCDb.ProductType> CancelProductTypeChanges(Travel.Models.TravelCDb.ProductType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProductTypeUpdated(Travel.Models.TravelCDb.ProductType item);
        partial void OnAfterProductTypeUpdated(Travel.Models.TravelCDb.ProductType item);

        public async Task<Travel.Models.TravelCDb.ProductType> UpdateProductType(int id, Travel.Models.TravelCDb.ProductType producttype)
        {
            OnProductTypeUpdated(producttype);

            var itemToUpdate = Context.ProductTypes
                              .Where(i => i.Id == producttype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(producttype).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProductTypeUpdated(producttype);

            return producttype;
        }

        partial void OnProductTypeDeleted(Travel.Models.TravelCDb.ProductType item);
        partial void OnAfterProductTypeDeleted(Travel.Models.TravelCDb.ProductType item);

        public async Task<Travel.Models.TravelCDb.ProductType> DeleteProductType(int id)
        {
            var itemToDelete = Context.ProductTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProductTypeDeleted(itemToDelete);

            Reset();

            Context.ProductTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProductTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportRoomsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/rooms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/rooms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRoomsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/rooms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/rooms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRoomsRead(ref IQueryable<Travel.Models.TravelCDb.Room> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.Room>> GetRooms(Query query = null)
        {
            var items = Context.Rooms.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnRoomsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRoomGet(Travel.Models.TravelCDb.Room item);

        public async Task<Travel.Models.TravelCDb.Room> GetRoomById(int id)
        {
            var items = Context.Rooms
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnRoomGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnRoomCreated(Travel.Models.TravelCDb.Room item);
        partial void OnAfterRoomCreated(Travel.Models.TravelCDb.Room item);

        public async Task<Travel.Models.TravelCDb.Room> CreateRoom(Travel.Models.TravelCDb.Room room)
        {
            OnRoomCreated(room);

            var existingItem = Context.Rooms
                              .Where(i => i.Id == room.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Rooms.Add(room);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(room).State = EntityState.Detached;
                throw;
            }

            OnAfterRoomCreated(room);

            return room;
        }

        public async Task<Travel.Models.TravelCDb.Room> CancelRoomChanges(Travel.Models.TravelCDb.Room item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRoomUpdated(Travel.Models.TravelCDb.Room item);
        partial void OnAfterRoomUpdated(Travel.Models.TravelCDb.Room item);

        public async Task<Travel.Models.TravelCDb.Room> UpdateRoom(int id, Travel.Models.TravelCDb.Room room)
        {
            OnRoomUpdated(room);

            var itemToUpdate = Context.Rooms
                              .Where(i => i.Id == room.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(room).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterRoomUpdated(room);

            return room;
        }

        partial void OnRoomDeleted(Travel.Models.TravelCDb.Room item);
        partial void OnAfterRoomDeleted(Travel.Models.TravelCDb.Room item);

        public async Task<Travel.Models.TravelCDb.Room> DeleteRoom(int id)
        {
            var itemToDelete = Context.Rooms
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRoomDeleted(itemToDelete);

            Reset();

            Context.Rooms.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRoomDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportRoomsSelectedHotelsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/roomsselectedhotels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/roomsselectedhotels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRoomsSelectedHotelsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/roomsselectedhotels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/roomsselectedhotels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRoomsSelectedHotelsRead(ref IQueryable<Travel.Models.TravelCDb.RoomsSelectedHotel> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.RoomsSelectedHotel>> GetRoomsSelectedHotels(Query query = null)
        {
            var items = Context.RoomsSelectedHotels.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnRoomsSelectedHotelsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRoomsSelectedHotelGet(Travel.Models.TravelCDb.RoomsSelectedHotel item);

        public async Task<Travel.Models.TravelCDb.RoomsSelectedHotel> GetRoomsSelectedHotelById(int id)
        {
            var items = Context.RoomsSelectedHotels
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Hotel);
                items = items.Include(i => i.Room);
  
            var itemToReturn = items.FirstOrDefault();

            OnRoomsSelectedHotelGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnRoomsSelectedHotelCreated(Travel.Models.TravelCDb.RoomsSelectedHotel item);
        partial void OnAfterRoomsSelectedHotelCreated(Travel.Models.TravelCDb.RoomsSelectedHotel item);

        public async Task<Travel.Models.TravelCDb.RoomsSelectedHotel> CreateRoomsSelectedHotel(Travel.Models.TravelCDb.RoomsSelectedHotel roomsselectedhotel)
        {
            OnRoomsSelectedHotelCreated(roomsselectedhotel);

            var existingItem = Context.RoomsSelectedHotels
                              .Where(i => i.Id == roomsselectedhotel.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.RoomsSelectedHotels.Add(roomsselectedhotel);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(roomsselectedhotel).State = EntityState.Detached;
                throw;
            }

            OnAfterRoomsSelectedHotelCreated(roomsselectedhotel);

            return roomsselectedhotel;
        }

        public async Task<Travel.Models.TravelCDb.RoomsSelectedHotel> CancelRoomsSelectedHotelChanges(Travel.Models.TravelCDb.RoomsSelectedHotel item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRoomsSelectedHotelUpdated(Travel.Models.TravelCDb.RoomsSelectedHotel item);
        partial void OnAfterRoomsSelectedHotelUpdated(Travel.Models.TravelCDb.RoomsSelectedHotel item);

        public async Task<Travel.Models.TravelCDb.RoomsSelectedHotel> UpdateRoomsSelectedHotel(int id, Travel.Models.TravelCDb.RoomsSelectedHotel roomsselectedhotel)
        {
            OnRoomsSelectedHotelUpdated(roomsselectedhotel);

            var itemToUpdate = Context.RoomsSelectedHotels
                              .Where(i => i.Id == roomsselectedhotel.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            roomsselectedhotel.Hotel = null;
            roomsselectedhotel.Room = null;

            Context.Attach(roomsselectedhotel).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterRoomsSelectedHotelUpdated(roomsselectedhotel);

            return roomsselectedhotel;
        }

        partial void OnRoomsSelectedHotelDeleted(Travel.Models.TravelCDb.RoomsSelectedHotel item);
        partial void OnAfterRoomsSelectedHotelDeleted(Travel.Models.TravelCDb.RoomsSelectedHotel item);

        public async Task<Travel.Models.TravelCDb.RoomsSelectedHotel> DeleteRoomsSelectedHotel(int id)
        {
            var itemToDelete = Context.RoomsSelectedHotels
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRoomsSelectedHotelDeleted(itemToDelete);

            Reset();

            Context.RoomsSelectedHotels.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRoomsSelectedHotelDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportStatusToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/status/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/status/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportStatusToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/status/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/status/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnStatusRead(ref IQueryable<Travel.Models.TravelCDb.Statu> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.Statu>> GetStatus(Query query = null)
        {
            var items = Context.Status.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnStatusRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnStatuGet(Travel.Models.TravelCDb.Statu item);

        public async Task<Travel.Models.TravelCDb.Statu> GetStatuById(int id)
        {
            var items = Context.Status
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnStatuGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnStatuCreated(Travel.Models.TravelCDb.Statu item);
        partial void OnAfterStatuCreated(Travel.Models.TravelCDb.Statu item);

        public async Task<Travel.Models.TravelCDb.Statu> CreateStatu(Travel.Models.TravelCDb.Statu statu)
        {
            OnStatuCreated(statu);

            var existingItem = Context.Status
                              .Where(i => i.Id == statu.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Status.Add(statu);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(statu).State = EntityState.Detached;
                throw;
            }

            OnAfterStatuCreated(statu);

            return statu;
        }

        public async Task<Travel.Models.TravelCDb.Statu> CancelStatuChanges(Travel.Models.TravelCDb.Statu item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnStatuUpdated(Travel.Models.TravelCDb.Statu item);
        partial void OnAfterStatuUpdated(Travel.Models.TravelCDb.Statu item);

        public async Task<Travel.Models.TravelCDb.Statu> UpdateStatu(int id, Travel.Models.TravelCDb.Statu statu)
        {
            OnStatuUpdated(statu);

            var itemToUpdate = Context.Status
                              .Where(i => i.Id == statu.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(statu).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterStatuUpdated(statu);

            return statu;
        }

        partial void OnStatuDeleted(Travel.Models.TravelCDb.Statu item);
        partial void OnAfterStatuDeleted(Travel.Models.TravelCDb.Statu item);

        public async Task<Travel.Models.TravelCDb.Statu> DeleteStatu(int id)
        {
            var itemToDelete = Context.Status
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnStatuDeleted(itemToDelete);

            Reset();

            Context.Status.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterStatuDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/languages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/languages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/travelcdb/languages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/travelcdb/languages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLanguagesRead(ref IQueryable<Travel.Models.TravelCDb.Language> items);

        public async Task<IQueryable<Travel.Models.TravelCDb.Language>> GetLanguages(Query query = null)
        {
            var items = Context.Languages.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnLanguagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLanguageGet(Travel.Models.TravelCDb.Language item);

        public async Task<Travel.Models.TravelCDb.Language> GetLanguageById(int id)
        {
            var items = Context.Languages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnLanguageCreated(Travel.Models.TravelCDb.Language item);
        partial void OnAfterLanguageCreated(Travel.Models.TravelCDb.Language item);

        public async Task<Travel.Models.TravelCDb.Language> CreateLanguage(Travel.Models.TravelCDb.Language language)
        {
            OnLanguageCreated(language);

            var existingItem = Context.Languages
                              .Where(i => i.Id == language.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Languages.Add(language);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(language).State = EntityState.Detached;
                throw;
            }

            OnAfterLanguageCreated(language);

            return language;
        }

        public async Task<Travel.Models.TravelCDb.Language> CancelLanguageChanges(Travel.Models.TravelCDb.Language item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLanguageUpdated(Travel.Models.TravelCDb.Language item);
        partial void OnAfterLanguageUpdated(Travel.Models.TravelCDb.Language item);

        public async Task<Travel.Models.TravelCDb.Language> UpdateLanguage(int id, Travel.Models.TravelCDb.Language language)
        {
            OnLanguageUpdated(language);

            var itemToUpdate = Context.Languages
                              .Where(i => i.Id == language.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(language).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterLanguageUpdated(language);

            return language;
        }

        partial void OnLanguageDeleted(Travel.Models.TravelCDb.Language item);
        partial void OnAfterLanguageDeleted(Travel.Models.TravelCDb.Language item);

        public async Task<Travel.Models.TravelCDb.Language> DeleteLanguage(int id)
        {
            var itemToDelete = Context.Languages
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLanguageDeleted(itemToDelete);

            Reset();

            Context.Languages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterLanguageDeleted(itemToDelete);

            return itemToDelete;
        }
        }
}