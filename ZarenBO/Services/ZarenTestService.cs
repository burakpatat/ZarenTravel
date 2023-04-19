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

using ZarenTravelBO.Data;

namespace ZarenTravelBO
{
    public partial class zaren_testService
    {
        zaren_testContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly zaren_testContext context;
        private readonly NavigationManager navigationManager;

        public zaren_testService(zaren_testContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);


        public async Task ExportAgenciesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgenciesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgenciesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Agency> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Agency>> GetAgencies(Query query = null)
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

        partial void OnAgencyGet(ZarenTravelBO.Models.zaren_test.Agency item);

        public async Task<ZarenTravelBO.Models.zaren_test.Agency> GetAgencyById(int id)
        {
            var items = Context.Agencies
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyCreated(ZarenTravelBO.Models.zaren_test.Agency item);
        partial void OnAfterAgencyCreated(ZarenTravelBO.Models.zaren_test.Agency item);

        public async Task<ZarenTravelBO.Models.zaren_test.Agency> CreateAgency(ZarenTravelBO.Models.zaren_test.Agency agency)
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

        public async Task<ZarenTravelBO.Models.zaren_test.Agency> CancelAgencyChanges(ZarenTravelBO.Models.zaren_test.Agency item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyUpdated(ZarenTravelBO.Models.zaren_test.Agency item);
        partial void OnAfterAgencyUpdated(ZarenTravelBO.Models.zaren_test.Agency item);

        public async Task<ZarenTravelBO.Models.zaren_test.Agency> UpdateAgency(int id, ZarenTravelBO.Models.zaren_test.Agency agency)
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

            Context.Attach(agency).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyUpdated(agency);

            return agency;
        }

        partial void OnAgencyDeleted(ZarenTravelBO.Models.zaren_test.Agency item);
        partial void OnAfterAgencyDeleted(ZarenTravelBO.Models.zaren_test.Agency item);

        public async Task<ZarenTravelBO.Models.zaren_test.Agency> DeleteAgency(int id)
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
    
        public async Task ExportAgencyCmsDevicesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycmsdevices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycmsdevices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyCmsDevicesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycmsdevices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycmsdevices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyCmsDevicesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyCmsDevice> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyCmsDevice>> GetAgencyCmsDevices(Query query = null)
        {
            var items = Context.AgencyCmsDevices.AsQueryable();


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

            OnAgencyCmsDevicesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyCmsDeviceGet(ZarenTravelBO.Models.zaren_test.AgencyCmsDevice item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsDevice> GetAgencyCmsDeviceById(int id)
        {
            var items = Context.AgencyCmsDevices
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyCmsDeviceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyCmsDeviceCreated(ZarenTravelBO.Models.zaren_test.AgencyCmsDevice item);
        partial void OnAfterAgencyCmsDeviceCreated(ZarenTravelBO.Models.zaren_test.AgencyCmsDevice item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsDevice> CreateAgencyCmsDevice(ZarenTravelBO.Models.zaren_test.AgencyCmsDevice agencycmsdevice)
        {
            OnAgencyCmsDeviceCreated(agencycmsdevice);

            var existingItem = Context.AgencyCmsDevices
                              .Where(i => i.Id == agencycmsdevice.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyCmsDevices.Add(agencycmsdevice);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycmsdevice).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyCmsDeviceCreated(agencycmsdevice);

            return agencycmsdevice;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsDevice> CancelAgencyCmsDeviceChanges(ZarenTravelBO.Models.zaren_test.AgencyCmsDevice item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyCmsDeviceUpdated(ZarenTravelBO.Models.zaren_test.AgencyCmsDevice item);
        partial void OnAfterAgencyCmsDeviceUpdated(ZarenTravelBO.Models.zaren_test.AgencyCmsDevice item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsDevice> UpdateAgencyCmsDevice(int id, ZarenTravelBO.Models.zaren_test.AgencyCmsDevice agencycmsdevice)
        {
            OnAgencyCmsDeviceUpdated(agencycmsdevice);

            var itemToUpdate = Context.AgencyCmsDevices
                              .Where(i => i.Id == agencycmsdevice.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencycmsdevice).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyCmsDeviceUpdated(agencycmsdevice);

            return agencycmsdevice;
        }

        partial void OnAgencyCmsDeviceDeleted(ZarenTravelBO.Models.zaren_test.AgencyCmsDevice item);
        partial void OnAfterAgencyCmsDeviceDeleted(ZarenTravelBO.Models.zaren_test.AgencyCmsDevice item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsDevice> DeleteAgencyCmsDevice(int id)
        {
            var itemToDelete = Context.AgencyCmsDevices
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyCmsDeviceDeleted(itemToDelete);

            Reset();

            Context.AgencyCmsDevices.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyCmsDeviceDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyCmsSectionTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycmssectiontypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycmssectiontypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyCmsSectionTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycmssectiontypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycmssectiontypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyCmsSectionTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType>> GetAgencyCmsSectionTypes(Query query = null)
        {
            var items = Context.AgencyCmsSectionTypes.AsQueryable();

            items = items.Include(i => i.Agency);

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

            OnAgencyCmsSectionTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyCmsSectionTypeGet(ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType> GetAgencyCmsSectionTypeById(int id)
        {
            var items = Context.AgencyCmsSectionTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyCmsSectionTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyCmsSectionTypeCreated(ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType item);
        partial void OnAfterAgencyCmsSectionTypeCreated(ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType> CreateAgencyCmsSectionType(ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType agencycmssectiontype)
        {
            OnAgencyCmsSectionTypeCreated(agencycmssectiontype);

            var existingItem = Context.AgencyCmsSectionTypes
                              .Where(i => i.Id == agencycmssectiontype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyCmsSectionTypes.Add(agencycmssectiontype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycmssectiontype).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyCmsSectionTypeCreated(agencycmssectiontype);

            return agencycmssectiontype;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType> CancelAgencyCmsSectionTypeChanges(ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyCmsSectionTypeUpdated(ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType item);
        partial void OnAfterAgencyCmsSectionTypeUpdated(ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType> UpdateAgencyCmsSectionType(int id, ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType agencycmssectiontype)
        {
            OnAgencyCmsSectionTypeUpdated(agencycmssectiontype);

            var itemToUpdate = Context.AgencyCmsSectionTypes
                              .Where(i => i.Id == agencycmssectiontype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            agencycmssectiontype.Agency = null;

            Context.Attach(agencycmssectiontype).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyCmsSectionTypeUpdated(agencycmssectiontype);

            return agencycmssectiontype;
        }

        partial void OnAgencyCmsSectionTypeDeleted(ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType item);
        partial void OnAfterAgencyCmsSectionTypeDeleted(ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsSectionType> DeleteAgencyCmsSectionType(int id)
        {
            var itemToDelete = Context.AgencyCmsSectionTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyCmsSectionTypeDeleted(itemToDelete);

            Reset();

            Context.AgencyCmsSectionTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyCmsSectionTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyCmsSocialMediaUrlsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycmssocialmediaurls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycmssocialmediaurls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyCmsSocialMediaUrlsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycmssocialmediaurls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycmssocialmediaurls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyCmsSocialMediaUrlsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl>> GetAgencyCmsSocialMediaUrls(Query query = null)
        {
            var items = Context.AgencyCmsSocialMediaUrls.AsQueryable();

            items = items.Include(i => i.Agency);

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

            OnAgencyCmsSocialMediaUrlsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyCmsSocialMediaUrlGet(ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl> GetAgencyCmsSocialMediaUrlById(int id)
        {
            var items = Context.AgencyCmsSocialMediaUrls
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyCmsSocialMediaUrlGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyCmsSocialMediaUrlCreated(ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl item);
        partial void OnAfterAgencyCmsSocialMediaUrlCreated(ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl> CreateAgencyCmsSocialMediaUrl(ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl agencycmssocialmediaurl)
        {
            OnAgencyCmsSocialMediaUrlCreated(agencycmssocialmediaurl);

            var existingItem = Context.AgencyCmsSocialMediaUrls
                              .Where(i => i.Id == agencycmssocialmediaurl.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyCmsSocialMediaUrls.Add(agencycmssocialmediaurl);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycmssocialmediaurl).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyCmsSocialMediaUrlCreated(agencycmssocialmediaurl);

            return agencycmssocialmediaurl;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl> CancelAgencyCmsSocialMediaUrlChanges(ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyCmsSocialMediaUrlUpdated(ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl item);
        partial void OnAfterAgencyCmsSocialMediaUrlUpdated(ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl> UpdateAgencyCmsSocialMediaUrl(int id, ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl agencycmssocialmediaurl)
        {
            OnAgencyCmsSocialMediaUrlUpdated(agencycmssocialmediaurl);

            var itemToUpdate = Context.AgencyCmsSocialMediaUrls
                              .Where(i => i.Id == agencycmssocialmediaurl.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            agencycmssocialmediaurl.Agency = null;

            Context.Attach(agencycmssocialmediaurl).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyCmsSocialMediaUrlUpdated(agencycmssocialmediaurl);

            return agencycmssocialmediaurl;
        }

        partial void OnAgencyCmsSocialMediaUrlDeleted(ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl item);
        partial void OnAfterAgencyCmsSocialMediaUrlDeleted(ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsSocialMediaUrl> DeleteAgencyCmsSocialMediaUrl(int id)
        {
            var itemToDelete = Context.AgencyCmsSocialMediaUrls
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyCmsSocialMediaUrlDeleted(itemToDelete);

            Reset();

            Context.AgencyCmsSocialMediaUrls.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyCmsSocialMediaUrlDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyCmsThemesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycmsthemes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycmsthemes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyCmsThemesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycmsthemes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycmsthemes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyCmsThemesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyCmsTheme> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyCmsTheme>> GetAgencyCmsThemes(Query query = null)
        {
            var items = Context.AgencyCmsThemes.AsQueryable();

            items = items.Include(i => i.Agency);

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

            OnAgencyCmsThemesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyCmsThemeGet(ZarenTravelBO.Models.zaren_test.AgencyCmsTheme item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsTheme> GetAgencyCmsThemeById(int id)
        {
            var items = Context.AgencyCmsThemes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyCmsThemeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyCmsThemeCreated(ZarenTravelBO.Models.zaren_test.AgencyCmsTheme item);
        partial void OnAfterAgencyCmsThemeCreated(ZarenTravelBO.Models.zaren_test.AgencyCmsTheme item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsTheme> CreateAgencyCmsTheme(ZarenTravelBO.Models.zaren_test.AgencyCmsTheme agencycmstheme)
        {
            OnAgencyCmsThemeCreated(agencycmstheme);

            var existingItem = Context.AgencyCmsThemes
                              .Where(i => i.Id == agencycmstheme.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyCmsThemes.Add(agencycmstheme);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycmstheme).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyCmsThemeCreated(agencycmstheme);

            return agencycmstheme;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsTheme> CancelAgencyCmsThemeChanges(ZarenTravelBO.Models.zaren_test.AgencyCmsTheme item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyCmsThemeUpdated(ZarenTravelBO.Models.zaren_test.AgencyCmsTheme item);
        partial void OnAfterAgencyCmsThemeUpdated(ZarenTravelBO.Models.zaren_test.AgencyCmsTheme item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsTheme> UpdateAgencyCmsTheme(int id, ZarenTravelBO.Models.zaren_test.AgencyCmsTheme agencycmstheme)
        {
            OnAgencyCmsThemeUpdated(agencycmstheme);

            var itemToUpdate = Context.AgencyCmsThemes
                              .Where(i => i.Id == agencycmstheme.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            agencycmstheme.Agency = null;

            Context.Attach(agencycmstheme).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyCmsThemeUpdated(agencycmstheme);

            return agencycmstheme;
        }

        partial void OnAgencyCmsThemeDeleted(ZarenTravelBO.Models.zaren_test.AgencyCmsTheme item);
        partial void OnAfterAgencyCmsThemeDeleted(ZarenTravelBO.Models.zaren_test.AgencyCmsTheme item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCmsTheme> DeleteAgencyCmsTheme(int id)
        {
            var itemToDelete = Context.AgencyCmsThemes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyCmsThemeDeleted(itemToDelete);

            Reset();

            Context.AgencyCmsThemes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyCmsThemeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyCommisionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycommisions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycommisions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyCommisionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycommisions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycommisions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyCommisionsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyCommision> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyCommision>> GetAgencyCommisions(Query query = null)
        {
            var items = Context.AgencyCommisions.AsQueryable();


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

            OnAgencyCommisionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyCommisionGet(ZarenTravelBO.Models.zaren_test.AgencyCommision item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCommision> GetAgencyCommisionById(int id)
        {
            var items = Context.AgencyCommisions
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyCommisionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyCommisionCreated(ZarenTravelBO.Models.zaren_test.AgencyCommision item);
        partial void OnAfterAgencyCommisionCreated(ZarenTravelBO.Models.zaren_test.AgencyCommision item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCommision> CreateAgencyCommision(ZarenTravelBO.Models.zaren_test.AgencyCommision agencycommision)
        {
            OnAgencyCommisionCreated(agencycommision);

            var existingItem = Context.AgencyCommisions
                              .Where(i => i.Id == agencycommision.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyCommisions.Add(agencycommision);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycommision).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyCommisionCreated(agencycommision);

            return agencycommision;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCommision> CancelAgencyCommisionChanges(ZarenTravelBO.Models.zaren_test.AgencyCommision item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyCommisionUpdated(ZarenTravelBO.Models.zaren_test.AgencyCommision item);
        partial void OnAfterAgencyCommisionUpdated(ZarenTravelBO.Models.zaren_test.AgencyCommision item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCommision> UpdateAgencyCommision(int id, ZarenTravelBO.Models.zaren_test.AgencyCommision agencycommision)
        {
            OnAgencyCommisionUpdated(agencycommision);

            var itemToUpdate = Context.AgencyCommisions
                              .Where(i => i.Id == agencycommision.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencycommision).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyCommisionUpdated(agencycommision);

            return agencycommision;
        }

        partial void OnAgencyCommisionDeleted(ZarenTravelBO.Models.zaren_test.AgencyCommision item);
        partial void OnAfterAgencyCommisionDeleted(ZarenTravelBO.Models.zaren_test.AgencyCommision item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCommision> DeleteAgencyCommision(int id)
        {
            var itemToDelete = Context.AgencyCommisions
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyCommisionDeleted(itemToDelete);

            Reset();

            Context.AgencyCommisions.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyCommisionDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyContractsClosedToursToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractsclosedtours/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractsclosedtours/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsClosedToursToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractsclosedtours/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractsclosedtours/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsClosedToursRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour>> GetAgencyContractsClosedTours(Query query = null)
        {
            var items = Context.AgencyContractsClosedTours.AsQueryable();


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

            OnAgencyContractsClosedToursRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyContractsClosedTourGet(ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour> GetAgencyContractsClosedTourById(int id)
        {
            var items = Context.AgencyContractsClosedTours
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsClosedTourGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsClosedTourCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour item);
        partial void OnAfterAgencyContractsClosedTourCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour> CreateAgencyContractsClosedTour(ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour agencycontractsclosedtour)
        {
            OnAgencyContractsClosedTourCreated(agencycontractsclosedtour);

            var existingItem = Context.AgencyContractsClosedTours
                              .Where(i => i.Id == agencycontractsclosedtour.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyContractsClosedTours.Add(agencycontractsclosedtour);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycontractsclosedtour).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyContractsClosedTourCreated(agencycontractsclosedtour);

            return agencycontractsclosedtour;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour> CancelAgencyContractsClosedTourChanges(ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsClosedTourUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour item);
        partial void OnAfterAgencyContractsClosedTourUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour> UpdateAgencyContractsClosedTour(int id, ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour agencycontractsclosedtour)
        {
            OnAgencyContractsClosedTourUpdated(agencycontractsclosedtour);

            var itemToUpdate = Context.AgencyContractsClosedTours
                              .Where(i => i.Id == agencycontractsclosedtour.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencycontractsclosedtour).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyContractsClosedTourUpdated(agencycontractsclosedtour);

            return agencycontractsclosedtour;
        }

        partial void OnAgencyContractsClosedTourDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour item);
        partial void OnAfterAgencyContractsClosedTourDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsClosedTour> DeleteAgencyContractsClosedTour(int id)
        {
            var itemToDelete = Context.AgencyContractsClosedTours
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyContractsClosedTourDeleted(itemToDelete);

            Reset();

            Context.AgencyContractsClosedTours.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyContractsClosedTourDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyContractsHotelCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractshotelcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractshotelcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsHotelCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractshotelcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractshotelcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsHotelCategoriesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory>> GetAgencyContractsHotelCategories(Query query = null)
        {
            var items = Context.AgencyContractsHotelCategories.AsQueryable();


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

            OnAgencyContractsHotelCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyContractsHotelCategoryGet(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory> GetAgencyContractsHotelCategoryById(int id)
        {
            var items = Context.AgencyContractsHotelCategories
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsHotelCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsHotelCategoryCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory item);
        partial void OnAfterAgencyContractsHotelCategoryCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory> CreateAgencyContractsHotelCategory(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory agencycontractshotelcategory)
        {
            OnAgencyContractsHotelCategoryCreated(agencycontractshotelcategory);

            var existingItem = Context.AgencyContractsHotelCategories
                              .Where(i => i.Id == agencycontractshotelcategory.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyContractsHotelCategories.Add(agencycontractshotelcategory);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycontractshotelcategory).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyContractsHotelCategoryCreated(agencycontractshotelcategory);

            return agencycontractshotelcategory;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory> CancelAgencyContractsHotelCategoryChanges(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsHotelCategoryUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory item);
        partial void OnAfterAgencyContractsHotelCategoryUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory> UpdateAgencyContractsHotelCategory(int id, ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory agencycontractshotelcategory)
        {
            OnAgencyContractsHotelCategoryUpdated(agencycontractshotelcategory);

            var itemToUpdate = Context.AgencyContractsHotelCategories
                              .Where(i => i.Id == agencycontractshotelcategory.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencycontractshotelcategory).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyContractsHotelCategoryUpdated(agencycontractshotelcategory);

            return agencycontractshotelcategory;
        }

        partial void OnAgencyContractsHotelCategoryDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory item);
        partial void OnAfterAgencyContractsHotelCategoryDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelCategory> DeleteAgencyContractsHotelCategory(int id)
        {
            var itemToDelete = Context.AgencyContractsHotelCategories
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyContractsHotelCategoryDeleted(itemToDelete);

            Reset();

            Context.AgencyContractsHotelCategories.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyContractsHotelCategoryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyContractsHotelInformationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractshotelinformations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractshotelinformations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsHotelInformationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractshotelinformations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractshotelinformations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsHotelInformationsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation>> GetAgencyContractsHotelInformations(Query query = null)
        {
            var items = Context.AgencyContractsHotelInformations.AsQueryable();


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

            OnAgencyContractsHotelInformationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyContractsHotelInformationGet(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation> GetAgencyContractsHotelInformationById(int id)
        {
            var items = Context.AgencyContractsHotelInformations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsHotelInformationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsHotelInformationCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation item);
        partial void OnAfterAgencyContractsHotelInformationCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation> CreateAgencyContractsHotelInformation(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation agencycontractshotelinformation)
        {
            OnAgencyContractsHotelInformationCreated(agencycontractshotelinformation);

            var existingItem = Context.AgencyContractsHotelInformations
                              .Where(i => i.Id == agencycontractshotelinformation.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyContractsHotelInformations.Add(agencycontractshotelinformation);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycontractshotelinformation).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyContractsHotelInformationCreated(agencycontractshotelinformation);

            return agencycontractshotelinformation;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation> CancelAgencyContractsHotelInformationChanges(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsHotelInformationUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation item);
        partial void OnAfterAgencyContractsHotelInformationUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation> UpdateAgencyContractsHotelInformation(int id, ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation agencycontractshotelinformation)
        {
            OnAgencyContractsHotelInformationUpdated(agencycontractshotelinformation);

            var itemToUpdate = Context.AgencyContractsHotelInformations
                              .Where(i => i.Id == agencycontractshotelinformation.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencycontractshotelinformation).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyContractsHotelInformationUpdated(agencycontractshotelinformation);

            return agencycontractshotelinformation;
        }

        partial void OnAgencyContractsHotelInformationDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation item);
        partial void OnAfterAgencyContractsHotelInformationDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformation> DeleteAgencyContractsHotelInformation(int id)
        {
            var itemToDelete = Context.AgencyContractsHotelInformations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyContractsHotelInformationDeleted(itemToDelete);

            Reset();

            Context.AgencyContractsHotelInformations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyContractsHotelInformationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyContractsHotelInformationImagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractshotelinformationimages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractshotelinformationimages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsHotelInformationImagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractshotelinformationimages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractshotelinformationimages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsHotelInformationImagesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage>> GetAgencyContractsHotelInformationImages(Query query = null)
        {
            var items = Context.AgencyContractsHotelInformationImages.AsQueryable();


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

            OnAgencyContractsHotelInformationImagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyContractsHotelInformationImageGet(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage> GetAgencyContractsHotelInformationImageById(int id)
        {
            var items = Context.AgencyContractsHotelInformationImages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsHotelInformationImageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsHotelInformationImageCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage item);
        partial void OnAfterAgencyContractsHotelInformationImageCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage> CreateAgencyContractsHotelInformationImage(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage agencycontractshotelinformationimage)
        {
            OnAgencyContractsHotelInformationImageCreated(agencycontractshotelinformationimage);

            var existingItem = Context.AgencyContractsHotelInformationImages
                              .Where(i => i.Id == agencycontractshotelinformationimage.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyContractsHotelInformationImages.Add(agencycontractshotelinformationimage);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycontractshotelinformationimage).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyContractsHotelInformationImageCreated(agencycontractshotelinformationimage);

            return agencycontractshotelinformationimage;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage> CancelAgencyContractsHotelInformationImageChanges(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsHotelInformationImageUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage item);
        partial void OnAfterAgencyContractsHotelInformationImageUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage> UpdateAgencyContractsHotelInformationImage(int id, ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage agencycontractshotelinformationimage)
        {
            OnAgencyContractsHotelInformationImageUpdated(agencycontractshotelinformationimage);

            var itemToUpdate = Context.AgencyContractsHotelInformationImages
                              .Where(i => i.Id == agencycontractshotelinformationimage.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencycontractshotelinformationimage).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyContractsHotelInformationImageUpdated(agencycontractshotelinformationimage);

            return agencycontractshotelinformationimage;
        }

        partial void OnAgencyContractsHotelInformationImageDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage item);
        partial void OnAfterAgencyContractsHotelInformationImageDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelInformationImage> DeleteAgencyContractsHotelInformationImage(int id)
        {
            var itemToDelete = Context.AgencyContractsHotelInformationImages
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyContractsHotelInformationImageDeleted(itemToDelete);

            Reset();

            Context.AgencyContractsHotelInformationImages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyContractsHotelInformationImageDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyContractsHotelsConfigurationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractshotelsconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractshotelsconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsHotelsConfigurationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractshotelsconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractshotelsconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsHotelsConfigurationsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration>> GetAgencyContractsHotelsConfigurations(Query query = null)
        {
            var items = Context.AgencyContractsHotelsConfigurations.AsQueryable();


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

            OnAgencyContractsHotelsConfigurationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyContractsHotelsConfigurationGet(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration> GetAgencyContractsHotelsConfigurationById(int id)
        {
            var items = Context.AgencyContractsHotelsConfigurations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsHotelsConfigurationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsHotelsConfigurationCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration item);
        partial void OnAfterAgencyContractsHotelsConfigurationCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration> CreateAgencyContractsHotelsConfiguration(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration agencycontractshotelsconfiguration)
        {
            OnAgencyContractsHotelsConfigurationCreated(agencycontractshotelsconfiguration);

            var existingItem = Context.AgencyContractsHotelsConfigurations
                              .Where(i => i.Id == agencycontractshotelsconfiguration.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyContractsHotelsConfigurations.Add(agencycontractshotelsconfiguration);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycontractshotelsconfiguration).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyContractsHotelsConfigurationCreated(agencycontractshotelsconfiguration);

            return agencycontractshotelsconfiguration;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration> CancelAgencyContractsHotelsConfigurationChanges(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsHotelsConfigurationUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration item);
        partial void OnAfterAgencyContractsHotelsConfigurationUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration> UpdateAgencyContractsHotelsConfiguration(int id, ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration agencycontractshotelsconfiguration)
        {
            OnAgencyContractsHotelsConfigurationUpdated(agencycontractshotelsconfiguration);

            var itemToUpdate = Context.AgencyContractsHotelsConfigurations
                              .Where(i => i.Id == agencycontractshotelsconfiguration.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencycontractshotelsconfiguration).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyContractsHotelsConfigurationUpdated(agencycontractshotelsconfiguration);

            return agencycontractshotelsconfiguration;
        }

        partial void OnAgencyContractsHotelsConfigurationDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration item);
        partial void OnAfterAgencyContractsHotelsConfigurationDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfiguration> DeleteAgencyContractsHotelsConfiguration(int id)
        {
            var itemToDelete = Context.AgencyContractsHotelsConfigurations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyContractsHotelsConfigurationDeleted(itemToDelete);

            Reset();

            Context.AgencyContractsHotelsConfigurations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyContractsHotelsConfigurationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyContractsHotelsConfigurationDaysToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractshotelsconfigurationdays/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractshotelsconfigurationdays/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsHotelsConfigurationDaysToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractshotelsconfigurationdays/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractshotelsconfigurationdays/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsHotelsConfigurationDaysRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay>> GetAgencyContractsHotelsConfigurationDays(Query query = null)
        {
            var items = Context.AgencyContractsHotelsConfigurationDays.AsQueryable();


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

            OnAgencyContractsHotelsConfigurationDaysRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyContractsHotelsConfigurationDayGet(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay> GetAgencyContractsHotelsConfigurationDayById(int id)
        {
            var items = Context.AgencyContractsHotelsConfigurationDays
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsHotelsConfigurationDayGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsHotelsConfigurationDayCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay item);
        partial void OnAfterAgencyContractsHotelsConfigurationDayCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay> CreateAgencyContractsHotelsConfigurationDay(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay agencycontractshotelsconfigurationday)
        {
            OnAgencyContractsHotelsConfigurationDayCreated(agencycontractshotelsconfigurationday);

            var existingItem = Context.AgencyContractsHotelsConfigurationDays
                              .Where(i => i.Id == agencycontractshotelsconfigurationday.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyContractsHotelsConfigurationDays.Add(agencycontractshotelsconfigurationday);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycontractshotelsconfigurationday).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyContractsHotelsConfigurationDayCreated(agencycontractshotelsconfigurationday);

            return agencycontractshotelsconfigurationday;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay> CancelAgencyContractsHotelsConfigurationDayChanges(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsHotelsConfigurationDayUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay item);
        partial void OnAfterAgencyContractsHotelsConfigurationDayUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay> UpdateAgencyContractsHotelsConfigurationDay(int id, ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay agencycontractshotelsconfigurationday)
        {
            OnAgencyContractsHotelsConfigurationDayUpdated(agencycontractshotelsconfigurationday);

            var itemToUpdate = Context.AgencyContractsHotelsConfigurationDays
                              .Where(i => i.Id == agencycontractshotelsconfigurationday.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencycontractshotelsconfigurationday).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyContractsHotelsConfigurationDayUpdated(agencycontractshotelsconfigurationday);

            return agencycontractshotelsconfigurationday;
        }

        partial void OnAgencyContractsHotelsConfigurationDayDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay item);
        partial void OnAfterAgencyContractsHotelsConfigurationDayDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsConfigurationDay> DeleteAgencyContractsHotelsConfigurationDay(int id)
        {
            var itemToDelete = Context.AgencyContractsHotelsConfigurationDays
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyContractsHotelsConfigurationDayDeleted(itemToDelete);

            Reset();

            Context.AgencyContractsHotelsConfigurationDays.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyContractsHotelsConfigurationDayDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyContractsHotelsMenusToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractshotelsmenus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractshotelsmenus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsHotelsMenusToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractshotelsmenus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractshotelsmenus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsHotelsMenusRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu>> GetAgencyContractsHotelsMenus(Query query = null)
        {
            var items = Context.AgencyContractsHotelsMenus.AsQueryable();


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

            OnAgencyContractsHotelsMenusRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyContractsHotelsMenuGet(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu> GetAgencyContractsHotelsMenuById(int id)
        {
            var items = Context.AgencyContractsHotelsMenus
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsHotelsMenuGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsHotelsMenuCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu item);
        partial void OnAfterAgencyContractsHotelsMenuCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu> CreateAgencyContractsHotelsMenu(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu agencycontractshotelsmenu)
        {
            OnAgencyContractsHotelsMenuCreated(agencycontractshotelsmenu);

            var existingItem = Context.AgencyContractsHotelsMenus
                              .Where(i => i.Id == agencycontractshotelsmenu.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyContractsHotelsMenus.Add(agencycontractshotelsmenu);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycontractshotelsmenu).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyContractsHotelsMenuCreated(agencycontractshotelsmenu);

            return agencycontractshotelsmenu;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu> CancelAgencyContractsHotelsMenuChanges(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsHotelsMenuUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu item);
        partial void OnAfterAgencyContractsHotelsMenuUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu> UpdateAgencyContractsHotelsMenu(int id, ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu agencycontractshotelsmenu)
        {
            OnAgencyContractsHotelsMenuUpdated(agencycontractshotelsmenu);

            var itemToUpdate = Context.AgencyContractsHotelsMenus
                              .Where(i => i.Id == agencycontractshotelsmenu.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencycontractshotelsmenu).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyContractsHotelsMenuUpdated(agencycontractshotelsmenu);

            return agencycontractshotelsmenu;
        }

        partial void OnAgencyContractsHotelsMenuDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu item);
        partial void OnAfterAgencyContractsHotelsMenuDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsHotelsMenu> DeleteAgencyContractsHotelsMenu(int id)
        {
            var itemToDelete = Context.AgencyContractsHotelsMenus
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyContractsHotelsMenuDeleted(itemToDelete);

            Reset();

            Context.AgencyContractsHotelsMenus.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyContractsHotelsMenuDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyContractsInsuranceBasicDataToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractsinsurancebasicdata/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractsinsurancebasicdata/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsInsuranceBasicDataToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractsinsurancebasicdata/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractsinsurancebasicdata/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsInsuranceBasicDataRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum>> GetAgencyContractsInsuranceBasicData(Query query = null)
        {
            var items = Context.AgencyContractsInsuranceBasicData.AsQueryable();


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

            OnAgencyContractsInsuranceBasicDataRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyContractsInsuranceBasicDatumGet(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum> GetAgencyContractsInsuranceBasicDatumById(int id)
        {
            var items = Context.AgencyContractsInsuranceBasicData
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsInsuranceBasicDatumGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsInsuranceBasicDatumCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum item);
        partial void OnAfterAgencyContractsInsuranceBasicDatumCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum> CreateAgencyContractsInsuranceBasicDatum(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum agencycontractsinsurancebasicdatum)
        {
            OnAgencyContractsInsuranceBasicDatumCreated(agencycontractsinsurancebasicdatum);

            var existingItem = Context.AgencyContractsInsuranceBasicData
                              .Where(i => i.Id == agencycontractsinsurancebasicdatum.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyContractsInsuranceBasicData.Add(agencycontractsinsurancebasicdatum);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycontractsinsurancebasicdatum).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyContractsInsuranceBasicDatumCreated(agencycontractsinsurancebasicdatum);

            return agencycontractsinsurancebasicdatum;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum> CancelAgencyContractsInsuranceBasicDatumChanges(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsInsuranceBasicDatumUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum item);
        partial void OnAfterAgencyContractsInsuranceBasicDatumUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum> UpdateAgencyContractsInsuranceBasicDatum(int id, ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum agencycontractsinsurancebasicdatum)
        {
            OnAgencyContractsInsuranceBasicDatumUpdated(agencycontractsinsurancebasicdatum);

            var itemToUpdate = Context.AgencyContractsInsuranceBasicData
                              .Where(i => i.Id == agencycontractsinsurancebasicdatum.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencycontractsinsurancebasicdatum).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyContractsInsuranceBasicDatumUpdated(agencycontractsinsurancebasicdatum);

            return agencycontractsinsurancebasicdatum;
        }

        partial void OnAgencyContractsInsuranceBasicDatumDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum item);
        partial void OnAfterAgencyContractsInsuranceBasicDatumDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceBasicDatum> DeleteAgencyContractsInsuranceBasicDatum(int id)
        {
            var itemToDelete = Context.AgencyContractsInsuranceBasicData
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyContractsInsuranceBasicDatumDeleted(itemToDelete);

            Reset();

            Context.AgencyContractsInsuranceBasicData.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyContractsInsuranceBasicDatumDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyContractsInsuranceSelectedLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractsinsuranceselectedlanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractsinsuranceselectedlanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsInsuranceSelectedLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractsinsuranceselectedlanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractsinsuranceselectedlanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsInsuranceSelectedLanguagesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage>> GetAgencyContractsInsuranceSelectedLanguages(Query query = null)
        {
            var items = Context.AgencyContractsInsuranceSelectedLanguages.AsQueryable();


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

            OnAgencyContractsInsuranceSelectedLanguagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyContractsInsuranceSelectedLanguageGet(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage> GetAgencyContractsInsuranceSelectedLanguageById(int id)
        {
            var items = Context.AgencyContractsInsuranceSelectedLanguages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsInsuranceSelectedLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsInsuranceSelectedLanguageCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage item);
        partial void OnAfterAgencyContractsInsuranceSelectedLanguageCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage> CreateAgencyContractsInsuranceSelectedLanguage(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage agencycontractsinsuranceselectedlanguage)
        {
            OnAgencyContractsInsuranceSelectedLanguageCreated(agencycontractsinsuranceselectedlanguage);

            var existingItem = Context.AgencyContractsInsuranceSelectedLanguages
                              .Where(i => i.Id == agencycontractsinsuranceselectedlanguage.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyContractsInsuranceSelectedLanguages.Add(agencycontractsinsuranceselectedlanguage);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycontractsinsuranceselectedlanguage).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyContractsInsuranceSelectedLanguageCreated(agencycontractsinsuranceselectedlanguage);

            return agencycontractsinsuranceselectedlanguage;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage> CancelAgencyContractsInsuranceSelectedLanguageChanges(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsInsuranceSelectedLanguageUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage item);
        partial void OnAfterAgencyContractsInsuranceSelectedLanguageUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage> UpdateAgencyContractsInsuranceSelectedLanguage(int id, ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage agencycontractsinsuranceselectedlanguage)
        {
            OnAgencyContractsInsuranceSelectedLanguageUpdated(agencycontractsinsuranceselectedlanguage);

            var itemToUpdate = Context.AgencyContractsInsuranceSelectedLanguages
                              .Where(i => i.Id == agencycontractsinsuranceselectedlanguage.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencycontractsinsuranceselectedlanguage).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyContractsInsuranceSelectedLanguageUpdated(agencycontractsinsuranceselectedlanguage);

            return agencycontractsinsuranceselectedlanguage;
        }

        partial void OnAgencyContractsInsuranceSelectedLanguageDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage item);
        partial void OnAfterAgencyContractsInsuranceSelectedLanguageDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedLanguage> DeleteAgencyContractsInsuranceSelectedLanguage(int id)
        {
            var itemToDelete = Context.AgencyContractsInsuranceSelectedLanguages
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyContractsInsuranceSelectedLanguageDeleted(itemToDelete);

            Reset();

            Context.AgencyContractsInsuranceSelectedLanguages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyContractsInsuranceSelectedLanguageDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyContractsInsuranceSelectedProductTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractsinsuranceselectedproducttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractsinsuranceselectedproducttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsInsuranceSelectedProductTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractsinsuranceselectedproducttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractsinsuranceselectedproducttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsInsuranceSelectedProductTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType>> GetAgencyContractsInsuranceSelectedProductTypes(Query query = null)
        {
            var items = Context.AgencyContractsInsuranceSelectedProductTypes.AsQueryable();


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

            OnAgencyContractsInsuranceSelectedProductTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyContractsInsuranceSelectedProductTypeGet(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType> GetAgencyContractsInsuranceSelectedProductTypeById(int id)
        {
            var items = Context.AgencyContractsInsuranceSelectedProductTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsInsuranceSelectedProductTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsInsuranceSelectedProductTypeCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType item);
        partial void OnAfterAgencyContractsInsuranceSelectedProductTypeCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType> CreateAgencyContractsInsuranceSelectedProductType(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType agencycontractsinsuranceselectedproducttype)
        {
            OnAgencyContractsInsuranceSelectedProductTypeCreated(agencycontractsinsuranceselectedproducttype);

            var existingItem = Context.AgencyContractsInsuranceSelectedProductTypes
                              .Where(i => i.Id == agencycontractsinsuranceselectedproducttype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyContractsInsuranceSelectedProductTypes.Add(agencycontractsinsuranceselectedproducttype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycontractsinsuranceselectedproducttype).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyContractsInsuranceSelectedProductTypeCreated(agencycontractsinsuranceselectedproducttype);

            return agencycontractsinsuranceselectedproducttype;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType> CancelAgencyContractsInsuranceSelectedProductTypeChanges(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsInsuranceSelectedProductTypeUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType item);
        partial void OnAfterAgencyContractsInsuranceSelectedProductTypeUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType> UpdateAgencyContractsInsuranceSelectedProductType(int id, ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType agencycontractsinsuranceselectedproducttype)
        {
            OnAgencyContractsInsuranceSelectedProductTypeUpdated(agencycontractsinsuranceselectedproducttype);

            var itemToUpdate = Context.AgencyContractsInsuranceSelectedProductTypes
                              .Where(i => i.Id == agencycontractsinsuranceselectedproducttype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencycontractsinsuranceselectedproducttype).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyContractsInsuranceSelectedProductTypeUpdated(agencycontractsinsuranceselectedproducttype);

            return agencycontractsinsuranceselectedproducttype;
        }

        partial void OnAgencyContractsInsuranceSelectedProductTypeDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType item);
        partial void OnAfterAgencyContractsInsuranceSelectedProductTypeDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceSelectedProductType> DeleteAgencyContractsInsuranceSelectedProductType(int id)
        {
            var itemToDelete = Context.AgencyContractsInsuranceSelectedProductTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyContractsInsuranceSelectedProductTypeDeleted(itemToDelete);

            Reset();

            Context.AgencyContractsInsuranceSelectedProductTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyContractsInsuranceSelectedProductTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyContractsInsuranceTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractsinsurancetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractsinsurancetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsInsuranceTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractsinsurancetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractsinsurancetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsInsuranceTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType>> GetAgencyContractsInsuranceTypes(Query query = null)
        {
            var items = Context.AgencyContractsInsuranceTypes.AsQueryable();


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

            OnAgencyContractsInsuranceTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyContractsInsuranceTypeGet(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType> GetAgencyContractsInsuranceTypeById(int id)
        {
            var items = Context.AgencyContractsInsuranceTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsInsuranceTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsInsuranceTypeCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType item);
        partial void OnAfterAgencyContractsInsuranceTypeCreated(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType> CreateAgencyContractsInsuranceType(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType agencycontractsinsurancetype)
        {
            OnAgencyContractsInsuranceTypeCreated(agencycontractsinsurancetype);

            var existingItem = Context.AgencyContractsInsuranceTypes
                              .Where(i => i.Id == agencycontractsinsurancetype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyContractsInsuranceTypes.Add(agencycontractsinsurancetype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycontractsinsurancetype).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyContractsInsuranceTypeCreated(agencycontractsinsurancetype);

            return agencycontractsinsurancetype;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType> CancelAgencyContractsInsuranceTypeChanges(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsInsuranceTypeUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType item);
        partial void OnAfterAgencyContractsInsuranceTypeUpdated(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType> UpdateAgencyContractsInsuranceType(int id, ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType agencycontractsinsurancetype)
        {
            OnAgencyContractsInsuranceTypeUpdated(agencycontractsinsurancetype);

            var itemToUpdate = Context.AgencyContractsInsuranceTypes
                              .Where(i => i.Id == agencycontractsinsurancetype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencycontractsinsurancetype).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyContractsInsuranceTypeUpdated(agencycontractsinsurancetype);

            return agencycontractsinsurancetype;
        }

        partial void OnAgencyContractsInsuranceTypeDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType item);
        partial void OnAfterAgencyContractsInsuranceTypeDeleted(ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyContractsInsuranceType> DeleteAgencyContractsInsuranceType(int id)
        {
            var itemToDelete = Context.AgencyContractsInsuranceTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyContractsInsuranceTypeDeleted(itemToDelete);

            Reset();

            Context.AgencyContractsInsuranceTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyContractsInsuranceTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyCreditDepositsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycreditdeposits/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycreditdeposits/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyCreditDepositsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycreditdeposits/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycreditdeposits/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyCreditDepositsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit>> GetAgencyCreditDeposits(Query query = null)
        {
            var items = Context.AgencyCreditDeposits.AsQueryable();


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

            OnAgencyCreditDepositsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyCreditDepositGet(ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit> GetAgencyCreditDepositById(int id)
        {
            var items = Context.AgencyCreditDeposits
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyCreditDepositGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyCreditDepositCreated(ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit item);
        partial void OnAfterAgencyCreditDepositCreated(ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit> CreateAgencyCreditDeposit(ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit agencycreditdeposit)
        {
            OnAgencyCreditDepositCreated(agencycreditdeposit);

            var existingItem = Context.AgencyCreditDeposits
                              .Where(i => i.Id == agencycreditdeposit.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyCreditDeposits.Add(agencycreditdeposit);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencycreditdeposit).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyCreditDepositCreated(agencycreditdeposit);

            return agencycreditdeposit;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit> CancelAgencyCreditDepositChanges(ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyCreditDepositUpdated(ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit item);
        partial void OnAfterAgencyCreditDepositUpdated(ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit> UpdateAgencyCreditDeposit(int id, ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit agencycreditdeposit)
        {
            OnAgencyCreditDepositUpdated(agencycreditdeposit);

            var itemToUpdate = Context.AgencyCreditDeposits
                              .Where(i => i.Id == agencycreditdeposit.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencycreditdeposit).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyCreditDepositUpdated(agencycreditdeposit);

            return agencycreditdeposit;
        }

        partial void OnAgencyCreditDepositDeleted(ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit item);
        partial void OnAfterAgencyCreditDepositDeleted(ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyCreditDeposit> DeleteAgencyCreditDeposit(int id)
        {
            var itemToDelete = Context.AgencyCreditDeposits
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyCreditDepositDeleted(itemToDelete);

            Reset();

            Context.AgencyCreditDeposits.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyCreditDepositDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyManagersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymanagers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymanagers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyManagersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymanagers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymanagers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyManagersRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyManager> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyManager>> GetAgencyManagers(Query query = null)
        {
            var items = Context.AgencyManagers.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyUser);

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

        partial void OnAgencyManagerGet(ZarenTravelBO.Models.zaren_test.AgencyManager item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyManager> GetAgencyManagerById(int id)
        {
            var items = Context.AgencyManagers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyUser);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyManagerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyManagerCreated(ZarenTravelBO.Models.zaren_test.AgencyManager item);
        partial void OnAfterAgencyManagerCreated(ZarenTravelBO.Models.zaren_test.AgencyManager item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyManager> CreateAgencyManager(ZarenTravelBO.Models.zaren_test.AgencyManager agencymanager)
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

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyManager> CancelAgencyManagerChanges(ZarenTravelBO.Models.zaren_test.AgencyManager item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyManagerUpdated(ZarenTravelBO.Models.zaren_test.AgencyManager item);
        partial void OnAfterAgencyManagerUpdated(ZarenTravelBO.Models.zaren_test.AgencyManager item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyManager> UpdateAgencyManager(int id, ZarenTravelBO.Models.zaren_test.AgencyManager agencymanager)
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
            agencymanager.Agency = null;
            agencymanager.AgencyUser = null;

            Context.Attach(agencymanager).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyManagerUpdated(agencymanager);

            return agencymanager;
        }

        partial void OnAgencyManagerDeleted(ZarenTravelBO.Models.zaren_test.AgencyManager item);
        partial void OnAfterAgencyManagerDeleted(ZarenTravelBO.Models.zaren_test.AgencyManager item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyManager> DeleteAgencyManager(int id)
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
    
        public async Task ExportAgencyMicroSiteApiProductProvidersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositeapiproductproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositeapiproductproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteApiProductProvidersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositeapiproductproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositeapiproductproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteApiProductProvidersRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider>> GetAgencyMicroSiteApiProductProviders(Query query = null)
        {
            var items = Context.AgencyMicroSiteApiProductProviders.AsQueryable();


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

            OnAgencyMicroSiteApiProductProvidersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteApiProductProviderGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider> GetAgencyMicroSiteApiProductProviderById(int id)
        {
            var items = Context.AgencyMicroSiteApiProductProviders
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteApiProductProviderGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteApiProductProviderCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider item);
        partial void OnAfterAgencyMicroSiteApiProductProviderCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider> CreateAgencyMicroSiteApiProductProvider(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider agencymicrositeapiproductprovider)
        {
            OnAgencyMicroSiteApiProductProviderCreated(agencymicrositeapiproductprovider);

            var existingItem = Context.AgencyMicroSiteApiProductProviders
                              .Where(i => i.Id == agencymicrositeapiproductprovider.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteApiProductProviders.Add(agencymicrositeapiproductprovider);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositeapiproductprovider).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteApiProductProviderCreated(agencymicrositeapiproductprovider);

            return agencymicrositeapiproductprovider;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider> CancelAgencyMicroSiteApiProductProviderChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteApiProductProviderUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider item);
        partial void OnAfterAgencyMicroSiteApiProductProviderUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider> UpdateAgencyMicroSiteApiProductProvider(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider agencymicrositeapiproductprovider)
        {
            OnAgencyMicroSiteApiProductProviderUpdated(agencymicrositeapiproductprovider);

            var itemToUpdate = Context.AgencyMicroSiteApiProductProviders
                              .Where(i => i.Id == agencymicrositeapiproductprovider.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositeapiproductprovider).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteApiProductProviderUpdated(agencymicrositeapiproductprovider);

            return agencymicrositeapiproductprovider;
        }

        partial void OnAgencyMicroSiteApiProductProviderDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider item);
        partial void OnAfterAgencyMicroSiteApiProductProviderDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteApiProductProvider> DeleteAgencyMicroSiteApiProductProvider(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteApiProductProviders
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteApiProductProviderDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteApiProductProviders.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteApiProductProviderDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteDesignsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositedesigns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositedesigns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteDesignsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositedesigns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositedesigns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteDesignsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign>> GetAgencyMicroSiteDesigns(Query query = null)
        {
            var items = Context.AgencyMicroSiteDesigns.AsQueryable();


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

            OnAgencyMicroSiteDesignsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteDesignGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign> GetAgencyMicroSiteDesignById(int id)
        {
            var items = Context.AgencyMicroSiteDesigns
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteDesignGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteDesignCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign item);
        partial void OnAfterAgencyMicroSiteDesignCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign> CreateAgencyMicroSiteDesign(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign agencymicrositedesign)
        {
            OnAgencyMicroSiteDesignCreated(agencymicrositedesign);

            var existingItem = Context.AgencyMicroSiteDesigns
                              .Where(i => i.Id == agencymicrositedesign.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteDesigns.Add(agencymicrositedesign);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositedesign).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteDesignCreated(agencymicrositedesign);

            return agencymicrositedesign;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign> CancelAgencyMicroSiteDesignChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteDesignUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign item);
        partial void OnAfterAgencyMicroSiteDesignUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign> UpdateAgencyMicroSiteDesign(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign agencymicrositedesign)
        {
            OnAgencyMicroSiteDesignUpdated(agencymicrositedesign);

            var itemToUpdate = Context.AgencyMicroSiteDesigns
                              .Where(i => i.Id == agencymicrositedesign.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositedesign).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteDesignUpdated(agencymicrositedesign);

            return agencymicrositedesign;
        }

        partial void OnAgencyMicroSiteDesignDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign item);
        partial void OnAfterAgencyMicroSiteDesignDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDesign> DeleteAgencyMicroSiteDesign(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteDesigns
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteDesignDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteDesigns.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteDesignDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteDomainLanguageSettingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositedomainlanguagesettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositedomainlanguagesettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteDomainLanguageSettingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositedomainlanguagesettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositedomainlanguagesettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteDomainLanguageSettingsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting>> GetAgencyMicroSiteDomainLanguageSettings(Query query = null)
        {
            var items = Context.AgencyMicroSiteDomainLanguageSettings.AsQueryable();


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

            OnAgencyMicroSiteDomainLanguageSettingsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteDomainLanguageSettingGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting> GetAgencyMicroSiteDomainLanguageSettingById(int id)
        {
            var items = Context.AgencyMicroSiteDomainLanguageSettings
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteDomainLanguageSettingGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteDomainLanguageSettingCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting item);
        partial void OnAfterAgencyMicroSiteDomainLanguageSettingCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting> CreateAgencyMicroSiteDomainLanguageSetting(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting agencymicrositedomainlanguagesetting)
        {
            OnAgencyMicroSiteDomainLanguageSettingCreated(agencymicrositedomainlanguagesetting);

            var existingItem = Context.AgencyMicroSiteDomainLanguageSettings
                              .Where(i => i.Id == agencymicrositedomainlanguagesetting.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteDomainLanguageSettings.Add(agencymicrositedomainlanguagesetting);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositedomainlanguagesetting).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteDomainLanguageSettingCreated(agencymicrositedomainlanguagesetting);

            return agencymicrositedomainlanguagesetting;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting> CancelAgencyMicroSiteDomainLanguageSettingChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteDomainLanguageSettingUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting item);
        partial void OnAfterAgencyMicroSiteDomainLanguageSettingUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting> UpdateAgencyMicroSiteDomainLanguageSetting(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting agencymicrositedomainlanguagesetting)
        {
            OnAgencyMicroSiteDomainLanguageSettingUpdated(agencymicrositedomainlanguagesetting);

            var itemToUpdate = Context.AgencyMicroSiteDomainLanguageSettings
                              .Where(i => i.Id == agencymicrositedomainlanguagesetting.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositedomainlanguagesetting).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteDomainLanguageSettingUpdated(agencymicrositedomainlanguagesetting);

            return agencymicrositedomainlanguagesetting;
        }

        partial void OnAgencyMicroSiteDomainLanguageSettingDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting item);
        partial void OnAfterAgencyMicroSiteDomainLanguageSettingDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomainLanguageSetting> DeleteAgencyMicroSiteDomainLanguageSetting(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteDomainLanguageSettings
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteDomainLanguageSettingDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteDomainLanguageSettings.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteDomainLanguageSettingDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteDomainsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositedomains/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositedomains/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteDomainsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositedomains/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositedomains/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteDomainsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain>> GetAgencyMicroSiteDomains(Query query = null)
        {
            var items = Context.AgencyMicroSiteDomains.AsQueryable();


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

            OnAgencyMicroSiteDomainsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteDomainGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain> GetAgencyMicroSiteDomainById(int id)
        {
            var items = Context.AgencyMicroSiteDomains
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteDomainGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteDomainCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain item);
        partial void OnAfterAgencyMicroSiteDomainCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain> CreateAgencyMicroSiteDomain(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain agencymicrositedomain)
        {
            OnAgencyMicroSiteDomainCreated(agencymicrositedomain);

            var existingItem = Context.AgencyMicroSiteDomains
                              .Where(i => i.Id == agencymicrositedomain.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteDomains.Add(agencymicrositedomain);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositedomain).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteDomainCreated(agencymicrositedomain);

            return agencymicrositedomain;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain> CancelAgencyMicroSiteDomainChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteDomainUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain item);
        partial void OnAfterAgencyMicroSiteDomainUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain> UpdateAgencyMicroSiteDomain(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain agencymicrositedomain)
        {
            OnAgencyMicroSiteDomainUpdated(agencymicrositedomain);

            var itemToUpdate = Context.AgencyMicroSiteDomains
                              .Where(i => i.Id == agencymicrositedomain.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositedomain).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteDomainUpdated(agencymicrositedomain);

            return agencymicrositedomain;
        }

        partial void OnAgencyMicroSiteDomainDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain item);
        partial void OnAfterAgencyMicroSiteDomainDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteDomain> DeleteAgencyMicroSiteDomain(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteDomains
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteDomainDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteDomains.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteDomainDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSitePaymentProvidersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositepaymentproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositepaymentproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSitePaymentProvidersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositepaymentproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositepaymentproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSitePaymentProvidersRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider>> GetAgencyMicroSitePaymentProviders(Query query = null)
        {
            var items = Context.AgencyMicroSitePaymentProviders.AsQueryable();


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

            OnAgencyMicroSitePaymentProvidersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSitePaymentProviderGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider> GetAgencyMicroSitePaymentProviderById(int id)
        {
            var items = Context.AgencyMicroSitePaymentProviders
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSitePaymentProviderGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSitePaymentProviderCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider item);
        partial void OnAfterAgencyMicroSitePaymentProviderCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider> CreateAgencyMicroSitePaymentProvider(ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider agencymicrositepaymentprovider)
        {
            OnAgencyMicroSitePaymentProviderCreated(agencymicrositepaymentprovider);

            var existingItem = Context.AgencyMicroSitePaymentProviders
                              .Where(i => i.Id == agencymicrositepaymentprovider.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSitePaymentProviders.Add(agencymicrositepaymentprovider);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositepaymentprovider).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSitePaymentProviderCreated(agencymicrositepaymentprovider);

            return agencymicrositepaymentprovider;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider> CancelAgencyMicroSitePaymentProviderChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSitePaymentProviderUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider item);
        partial void OnAfterAgencyMicroSitePaymentProviderUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider> UpdateAgencyMicroSitePaymentProvider(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider agencymicrositepaymentprovider)
        {
            OnAgencyMicroSitePaymentProviderUpdated(agencymicrositepaymentprovider);

            var itemToUpdate = Context.AgencyMicroSitePaymentProviders
                              .Where(i => i.Id == agencymicrositepaymentprovider.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositepaymentprovider).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSitePaymentProviderUpdated(agencymicrositepaymentprovider);

            return agencymicrositepaymentprovider;
        }

        partial void OnAgencyMicroSitePaymentProviderDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider item);
        partial void OnAfterAgencyMicroSitePaymentProviderDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSitePaymentProvider> DeleteAgencyMicroSitePaymentProvider(int id)
        {
            var itemToDelete = Context.AgencyMicroSitePaymentProviders
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSitePaymentProviderDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSitePaymentProviders.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSitePaymentProviderDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSitePropertiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositeproperties/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositeproperties/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSitePropertiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositeproperties/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositeproperties/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSitePropertiesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty>> GetAgencyMicroSiteProperties(Query query = null)
        {
            var items = Context.AgencyMicroSiteProperties.AsQueryable();


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

            OnAgencyMicroSitePropertiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSitePropertyGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty> GetAgencyMicroSitePropertyById(int id)
        {
            var items = Context.AgencyMicroSiteProperties
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSitePropertyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSitePropertyCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty item);
        partial void OnAfterAgencyMicroSitePropertyCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty> CreateAgencyMicroSiteProperty(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty agencymicrositeproperty)
        {
            OnAgencyMicroSitePropertyCreated(agencymicrositeproperty);

            var existingItem = Context.AgencyMicroSiteProperties
                              .Where(i => i.Id == agencymicrositeproperty.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteProperties.Add(agencymicrositeproperty);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositeproperty).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSitePropertyCreated(agencymicrositeproperty);

            return agencymicrositeproperty;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty> CancelAgencyMicroSitePropertyChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSitePropertyUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty item);
        partial void OnAfterAgencyMicroSitePropertyUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty> UpdateAgencyMicroSiteProperty(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty agencymicrositeproperty)
        {
            OnAgencyMicroSitePropertyUpdated(agencymicrositeproperty);

            var itemToUpdate = Context.AgencyMicroSiteProperties
                              .Where(i => i.Id == agencymicrositeproperty.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositeproperty).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSitePropertyUpdated(agencymicrositeproperty);

            return agencymicrositeproperty;
        }

        partial void OnAgencyMicroSitePropertyDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty item);
        partial void OnAfterAgencyMicroSitePropertyDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteProperty> DeleteAgencyMicroSiteProperty(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteProperties
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSitePropertyDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteProperties.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSitePropertyDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSitesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrosites/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrosites/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSitesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrosites/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrosites/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSitesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSite> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSite>> GetAgencyMicroSites(Query query = null)
        {
            var items = Context.AgencyMicroSites.AsQueryable();


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

            OnAgencyMicroSitesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSite item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSite> GetAgencyMicroSiteById(int id)
        {
            var items = Context.AgencyMicroSites
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSite item);
        partial void OnAfterAgencyMicroSiteCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSite item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSite> CreateAgencyMicroSite(ZarenTravelBO.Models.zaren_test.AgencyMicroSite agencymicrosite)
        {
            OnAgencyMicroSiteCreated(agencymicrosite);

            var existingItem = Context.AgencyMicroSites
                              .Where(i => i.Id == agencymicrosite.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSites.Add(agencymicrosite);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrosite).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteCreated(agencymicrosite);

            return agencymicrosite;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSite> CancelAgencyMicroSiteChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSite item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSite item);
        partial void OnAfterAgencyMicroSiteUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSite item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSite> UpdateAgencyMicroSite(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSite agencymicrosite)
        {
            OnAgencyMicroSiteUpdated(agencymicrosite);

            var itemToUpdate = Context.AgencyMicroSites
                              .Where(i => i.Id == agencymicrosite.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrosite).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteUpdated(agencymicrosite);

            return agencymicrosite;
        }

        partial void OnAgencyMicroSiteDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSite item);
        partial void OnAfterAgencyMicroSiteDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSite item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSite> DeleteAgencyMicroSite(int id)
        {
            var itemToDelete = Context.AgencyMicroSites
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSites.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingPassengerDataToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingpassengerdata/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingpassengerdata/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingPassengerDataToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingpassengerdata/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingpassengerdata/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingPassengerDataRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum>> GetAgencyMicroSiteSettingPassengerData(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingPassengerData.AsQueryable();


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

            OnAgencyMicroSiteSettingPassengerDataRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingPassengerDatumGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum> GetAgencyMicroSiteSettingPassengerDatumById(int id)
        {
            var items = Context.AgencyMicroSiteSettingPassengerData
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingPassengerDatumGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingPassengerDatumCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum item);
        partial void OnAfterAgencyMicroSiteSettingPassengerDatumCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum> CreateAgencyMicroSiteSettingPassengerDatum(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum agencymicrositesettingpassengerdatum)
        {
            OnAgencyMicroSiteSettingPassengerDatumCreated(agencymicrositesettingpassengerdatum);

            var existingItem = Context.AgencyMicroSiteSettingPassengerData
                              .Where(i => i.Id == agencymicrositesettingpassengerdatum.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingPassengerData.Add(agencymicrositesettingpassengerdatum);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingpassengerdatum).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingPassengerDatumCreated(agencymicrositesettingpassengerdatum);

            return agencymicrositesettingpassengerdatum;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum> CancelAgencyMicroSiteSettingPassengerDatumChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingPassengerDatumUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum item);
        partial void OnAfterAgencyMicroSiteSettingPassengerDatumUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum> UpdateAgencyMicroSiteSettingPassengerDatum(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum agencymicrositesettingpassengerdatum)
        {
            OnAgencyMicroSiteSettingPassengerDatumUpdated(agencymicrositesettingpassengerdatum);

            var itemToUpdate = Context.AgencyMicroSiteSettingPassengerData
                              .Where(i => i.Id == agencymicrositesettingpassengerdatum.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingpassengerdatum).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingPassengerDatumUpdated(agencymicrositesettingpassengerdatum);

            return agencymicrositesettingpassengerdatum;
        }

        partial void OnAgencyMicroSiteSettingPassengerDatumDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum item);
        partial void OnAfterAgencyMicroSiteSettingPassengerDatumDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingPassengerDatum> DeleteAgencyMicroSiteSettingPassengerDatum(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingPassengerData
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingPassengerDatumDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingPassengerData.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingPassengerDatumDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingsAccommodationSearchResultsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsaccommodationsearchresults/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsaccommodationsearchresults/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsAccommodationSearchResultsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsaccommodationsearchresults/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsaccommodationsearchresults/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsAccommodationSearchResultsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult>> GetAgencyMicroSiteSettingsAccommodationSearchResults(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsAccommodationSearchResults.AsQueryable();


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

            OnAgencyMicroSiteSettingsAccommodationSearchResultsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingsAccommodationSearchResultGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult> GetAgencyMicroSiteSettingsAccommodationSearchResultById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsAccommodationSearchResults
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsAccommodationSearchResultGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsAccommodationSearchResultCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult item);
        partial void OnAfterAgencyMicroSiteSettingsAccommodationSearchResultCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult> CreateAgencyMicroSiteSettingsAccommodationSearchResult(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult agencymicrositesettingsaccommodationsearchresult)
        {
            OnAgencyMicroSiteSettingsAccommodationSearchResultCreated(agencymicrositesettingsaccommodationsearchresult);

            var existingItem = Context.AgencyMicroSiteSettingsAccommodationSearchResults
                              .Where(i => i.Id == agencymicrositesettingsaccommodationsearchresult.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingsAccommodationSearchResults.Add(agencymicrositesettingsaccommodationsearchresult);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingsaccommodationsearchresult).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsAccommodationSearchResultCreated(agencymicrositesettingsaccommodationsearchresult);

            return agencymicrositesettingsaccommodationsearchresult;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult> CancelAgencyMicroSiteSettingsAccommodationSearchResultChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsAccommodationSearchResultUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult item);
        partial void OnAfterAgencyMicroSiteSettingsAccommodationSearchResultUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult> UpdateAgencyMicroSiteSettingsAccommodationSearchResult(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult agencymicrositesettingsaccommodationsearchresult)
        {
            OnAgencyMicroSiteSettingsAccommodationSearchResultUpdated(agencymicrositesettingsaccommodationsearchresult);

            var itemToUpdate = Context.AgencyMicroSiteSettingsAccommodationSearchResults
                              .Where(i => i.Id == agencymicrositesettingsaccommodationsearchresult.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingsaccommodationsearchresult).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsAccommodationSearchResultUpdated(agencymicrositesettingsaccommodationsearchresult);

            return agencymicrositesettingsaccommodationsearchresult;
        }

        partial void OnAgencyMicroSiteSettingsAccommodationSearchResultDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult item);
        partial void OnAfterAgencyMicroSiteSettingsAccommodationSearchResultDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsAccommodationSearchResult> DeleteAgencyMicroSiteSettingsAccommodationSearchResult(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingsAccommodationSearchResults
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingsAccommodationSearchResultDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingsAccommodationSearchResults.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsAccommodationSearchResultDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingsBookingProcessesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsbookingprocesses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsbookingprocesses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsBookingProcessesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsbookingprocesses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsbookingprocesses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsBookingProcessesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess>> GetAgencyMicroSiteSettingsBookingProcesses(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsBookingProcesses.AsQueryable();


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

            OnAgencyMicroSiteSettingsBookingProcessesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingsBookingProcessGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess> GetAgencyMicroSiteSettingsBookingProcessById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsBookingProcesses
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsBookingProcessGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsBookingProcessCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess item);
        partial void OnAfterAgencyMicroSiteSettingsBookingProcessCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess> CreateAgencyMicroSiteSettingsBookingProcess(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess agencymicrositesettingsbookingprocess)
        {
            OnAgencyMicroSiteSettingsBookingProcessCreated(agencymicrositesettingsbookingprocess);

            var existingItem = Context.AgencyMicroSiteSettingsBookingProcesses
                              .Where(i => i.Id == agencymicrositesettingsbookingprocess.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingsBookingProcesses.Add(agencymicrositesettingsbookingprocess);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingsbookingprocess).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsBookingProcessCreated(agencymicrositesettingsbookingprocess);

            return agencymicrositesettingsbookingprocess;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess> CancelAgencyMicroSiteSettingsBookingProcessChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsBookingProcessUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess item);
        partial void OnAfterAgencyMicroSiteSettingsBookingProcessUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess> UpdateAgencyMicroSiteSettingsBookingProcess(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess agencymicrositesettingsbookingprocess)
        {
            OnAgencyMicroSiteSettingsBookingProcessUpdated(agencymicrositesettingsbookingprocess);

            var itemToUpdate = Context.AgencyMicroSiteSettingsBookingProcesses
                              .Where(i => i.Id == agencymicrositesettingsbookingprocess.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingsbookingprocess).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsBookingProcessUpdated(agencymicrositesettingsbookingprocess);

            return agencymicrositesettingsbookingprocess;
        }

        partial void OnAgencyMicroSiteSettingsBookingProcessDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess item);
        partial void OnAfterAgencyMicroSiteSettingsBookingProcessDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingProcess> DeleteAgencyMicroSiteSettingsBookingProcess(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingsBookingProcesses
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingsBookingProcessDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingsBookingProcesses.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsBookingProcessDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingsBookingReplicatorModesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsbookingreplicatormodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsbookingreplicatormodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsBookingReplicatorModesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsbookingreplicatormodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsbookingreplicatormodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsBookingReplicatorModesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode>> GetAgencyMicroSiteSettingsBookingReplicatorModes(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsBookingReplicatorModes.AsQueryable();


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

            OnAgencyMicroSiteSettingsBookingReplicatorModesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingsBookingReplicatorModeGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode> GetAgencyMicroSiteSettingsBookingReplicatorModeById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsBookingReplicatorModes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsBookingReplicatorModeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsBookingReplicatorModeCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode item);
        partial void OnAfterAgencyMicroSiteSettingsBookingReplicatorModeCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode> CreateAgencyMicroSiteSettingsBookingReplicatorMode(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode agencymicrositesettingsbookingreplicatormode)
        {
            OnAgencyMicroSiteSettingsBookingReplicatorModeCreated(agencymicrositesettingsbookingreplicatormode);

            var existingItem = Context.AgencyMicroSiteSettingsBookingReplicatorModes
                              .Where(i => i.Id == agencymicrositesettingsbookingreplicatormode.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingsBookingReplicatorModes.Add(agencymicrositesettingsbookingreplicatormode);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingsbookingreplicatormode).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsBookingReplicatorModeCreated(agencymicrositesettingsbookingreplicatormode);

            return agencymicrositesettingsbookingreplicatormode;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode> CancelAgencyMicroSiteSettingsBookingReplicatorModeChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsBookingReplicatorModeUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode item);
        partial void OnAfterAgencyMicroSiteSettingsBookingReplicatorModeUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode> UpdateAgencyMicroSiteSettingsBookingReplicatorMode(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode agencymicrositesettingsbookingreplicatormode)
        {
            OnAgencyMicroSiteSettingsBookingReplicatorModeUpdated(agencymicrositesettingsbookingreplicatormode);

            var itemToUpdate = Context.AgencyMicroSiteSettingsBookingReplicatorModes
                              .Where(i => i.Id == agencymicrositesettingsbookingreplicatormode.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingsbookingreplicatormode).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsBookingReplicatorModeUpdated(agencymicrositesettingsbookingreplicatormode);

            return agencymicrositesettingsbookingreplicatormode;
        }

        partial void OnAgencyMicroSiteSettingsBookingReplicatorModeDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode item);
        partial void OnAfterAgencyMicroSiteSettingsBookingReplicatorModeDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsBookingReplicatorMode> DeleteAgencyMicroSiteSettingsBookingReplicatorMode(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingsBookingReplicatorModes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingsBookingReplicatorModeDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingsBookingReplicatorModes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsBookingReplicatorModeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingsEmailVouchersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsemailvouchers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsemailvouchers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsEmailVouchersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsemailvouchers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsemailvouchers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsEmailVouchersRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher>> GetAgencyMicroSiteSettingsEmailVouchers(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsEmailVouchers.AsQueryable();


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

            OnAgencyMicroSiteSettingsEmailVouchersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingsEmailVoucherGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher> GetAgencyMicroSiteSettingsEmailVoucherById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsEmailVouchers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsEmailVoucherGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsEmailVoucherCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher item);
        partial void OnAfterAgencyMicroSiteSettingsEmailVoucherCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher> CreateAgencyMicroSiteSettingsEmailVoucher(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher agencymicrositesettingsemailvoucher)
        {
            OnAgencyMicroSiteSettingsEmailVoucherCreated(agencymicrositesettingsemailvoucher);

            var existingItem = Context.AgencyMicroSiteSettingsEmailVouchers
                              .Where(i => i.Id == agencymicrositesettingsemailvoucher.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingsEmailVouchers.Add(agencymicrositesettingsemailvoucher);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingsemailvoucher).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsEmailVoucherCreated(agencymicrositesettingsemailvoucher);

            return agencymicrositesettingsemailvoucher;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher> CancelAgencyMicroSiteSettingsEmailVoucherChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsEmailVoucherUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher item);
        partial void OnAfterAgencyMicroSiteSettingsEmailVoucherUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher> UpdateAgencyMicroSiteSettingsEmailVoucher(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher agencymicrositesettingsemailvoucher)
        {
            OnAgencyMicroSiteSettingsEmailVoucherUpdated(agencymicrositesettingsemailvoucher);

            var itemToUpdate = Context.AgencyMicroSiteSettingsEmailVouchers
                              .Where(i => i.Id == agencymicrositesettingsemailvoucher.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingsemailvoucher).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsEmailVoucherUpdated(agencymicrositesettingsemailvoucher);

            return agencymicrositesettingsemailvoucher;
        }

        partial void OnAgencyMicroSiteSettingsEmailVoucherDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher item);
        partial void OnAfterAgencyMicroSiteSettingsEmailVoucherDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEmailVoucher> DeleteAgencyMicroSiteSettingsEmailVoucher(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingsEmailVouchers
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingsEmailVoucherDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingsEmailVouchers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsEmailVoucherDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingsEnableMultiDaysToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsenablemultidays/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsenablemultidays/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsEnableMultiDaysToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsenablemultidays/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsenablemultidays/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsEnableMultiDaysRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay>> GetAgencyMicroSiteSettingsEnableMultiDays(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsEnableMultiDays.AsQueryable();


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

            OnAgencyMicroSiteSettingsEnableMultiDaysRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingsEnableMultiDayGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay> GetAgencyMicroSiteSettingsEnableMultiDayById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsEnableMultiDays
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsEnableMultiDayGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsEnableMultiDayCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay item);
        partial void OnAfterAgencyMicroSiteSettingsEnableMultiDayCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay> CreateAgencyMicroSiteSettingsEnableMultiDay(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay agencymicrositesettingsenablemultiday)
        {
            OnAgencyMicroSiteSettingsEnableMultiDayCreated(agencymicrositesettingsenablemultiday);

            var existingItem = Context.AgencyMicroSiteSettingsEnableMultiDays
                              .Where(i => i.Id == agencymicrositesettingsenablemultiday.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingsEnableMultiDays.Add(agencymicrositesettingsenablemultiday);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingsenablemultiday).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsEnableMultiDayCreated(agencymicrositesettingsenablemultiday);

            return agencymicrositesettingsenablemultiday;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay> CancelAgencyMicroSiteSettingsEnableMultiDayChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsEnableMultiDayUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay item);
        partial void OnAfterAgencyMicroSiteSettingsEnableMultiDayUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay> UpdateAgencyMicroSiteSettingsEnableMultiDay(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay agencymicrositesettingsenablemultiday)
        {
            OnAgencyMicroSiteSettingsEnableMultiDayUpdated(agencymicrositesettingsenablemultiday);

            var itemToUpdate = Context.AgencyMicroSiteSettingsEnableMultiDays
                              .Where(i => i.Id == agencymicrositesettingsenablemultiday.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingsenablemultiday).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsEnableMultiDayUpdated(agencymicrositesettingsenablemultiday);

            return agencymicrositesettingsenablemultiday;
        }

        partial void OnAgencyMicroSiteSettingsEnableMultiDayDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay item);
        partial void OnAfterAgencyMicroSiteSettingsEnableMultiDayDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsEnableMultiDay> DeleteAgencyMicroSiteSettingsEnableMultiDay(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingsEnableMultiDays
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingsEnableMultiDayDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingsEnableMultiDays.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsEnableMultiDayDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingsGeneralsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsgenerals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsgenerals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsGeneralsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsgenerals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsgenerals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsGeneralsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral>> GetAgencyMicroSiteSettingsGenerals(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsGenerals.AsQueryable();


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

            OnAgencyMicroSiteSettingsGeneralsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingsGeneralGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral> GetAgencyMicroSiteSettingsGeneralById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsGenerals
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsGeneralGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsGeneralCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral item);
        partial void OnAfterAgencyMicroSiteSettingsGeneralCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral> CreateAgencyMicroSiteSettingsGeneral(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral agencymicrositesettingsgeneral)
        {
            OnAgencyMicroSiteSettingsGeneralCreated(agencymicrositesettingsgeneral);

            var existingItem = Context.AgencyMicroSiteSettingsGenerals
                              .Where(i => i.Id == agencymicrositesettingsgeneral.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingsGenerals.Add(agencymicrositesettingsgeneral);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingsgeneral).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsGeneralCreated(agencymicrositesettingsgeneral);

            return agencymicrositesettingsgeneral;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral> CancelAgencyMicroSiteSettingsGeneralChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsGeneralUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral item);
        partial void OnAfterAgencyMicroSiteSettingsGeneralUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral> UpdateAgencyMicroSiteSettingsGeneral(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral agencymicrositesettingsgeneral)
        {
            OnAgencyMicroSiteSettingsGeneralUpdated(agencymicrositesettingsgeneral);

            var itemToUpdate = Context.AgencyMicroSiteSettingsGenerals
                              .Where(i => i.Id == agencymicrositesettingsgeneral.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingsgeneral).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsGeneralUpdated(agencymicrositesettingsgeneral);

            return agencymicrositesettingsgeneral;
        }

        partial void OnAgencyMicroSiteSettingsGeneralDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral item);
        partial void OnAfterAgencyMicroSiteSettingsGeneralDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsGeneral> DeleteAgencyMicroSiteSettingsGeneral(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingsGenerals
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingsGeneralDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingsGenerals.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsGeneralDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingsHelpSupportsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingshelpsupports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingshelpsupports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsHelpSupportsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingshelpsupports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingshelpsupports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsHelpSupportsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport>> GetAgencyMicroSiteSettingsHelpSupports(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsHelpSupports.AsQueryable();


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

            OnAgencyMicroSiteSettingsHelpSupportsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingsHelpSupportGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport> GetAgencyMicroSiteSettingsHelpSupportById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsHelpSupports
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsHelpSupportGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsHelpSupportCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport item);
        partial void OnAfterAgencyMicroSiteSettingsHelpSupportCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport> CreateAgencyMicroSiteSettingsHelpSupport(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport agencymicrositesettingshelpsupport)
        {
            OnAgencyMicroSiteSettingsHelpSupportCreated(agencymicrositesettingshelpsupport);

            var existingItem = Context.AgencyMicroSiteSettingsHelpSupports
                              .Where(i => i.Id == agencymicrositesettingshelpsupport.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingsHelpSupports.Add(agencymicrositesettingshelpsupport);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingshelpsupport).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsHelpSupportCreated(agencymicrositesettingshelpsupport);

            return agencymicrositesettingshelpsupport;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport> CancelAgencyMicroSiteSettingsHelpSupportChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsHelpSupportUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport item);
        partial void OnAfterAgencyMicroSiteSettingsHelpSupportUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport> UpdateAgencyMicroSiteSettingsHelpSupport(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport agencymicrositesettingshelpsupport)
        {
            OnAgencyMicroSiteSettingsHelpSupportUpdated(agencymicrositesettingshelpsupport);

            var itemToUpdate = Context.AgencyMicroSiteSettingsHelpSupports
                              .Where(i => i.Id == agencymicrositesettingshelpsupport.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingshelpsupport).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsHelpSupportUpdated(agencymicrositesettingshelpsupport);

            return agencymicrositesettingshelpsupport;
        }

        partial void OnAgencyMicroSiteSettingsHelpSupportDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport item);
        partial void OnAfterAgencyMicroSiteSettingsHelpSupportDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsHelpSupport> DeleteAgencyMicroSiteSettingsHelpSupport(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingsHelpSupports
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingsHelpSupportDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingsHelpSupports.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsHelpSupportDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingsInvoicesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsinvoices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsinvoices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsInvoicesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsinvoices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsinvoices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsInvoicesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice>> GetAgencyMicroSiteSettingsInvoices(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsInvoices.AsQueryable();


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

            OnAgencyMicroSiteSettingsInvoicesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingsInvoiceGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice> GetAgencyMicroSiteSettingsInvoiceById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsInvoices
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsInvoiceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsInvoiceCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice item);
        partial void OnAfterAgencyMicroSiteSettingsInvoiceCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice> CreateAgencyMicroSiteSettingsInvoice(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice agencymicrositesettingsinvoice)
        {
            OnAgencyMicroSiteSettingsInvoiceCreated(agencymicrositesettingsinvoice);

            var existingItem = Context.AgencyMicroSiteSettingsInvoices
                              .Where(i => i.Id == agencymicrositesettingsinvoice.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingsInvoices.Add(agencymicrositesettingsinvoice);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingsinvoice).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsInvoiceCreated(agencymicrositesettingsinvoice);

            return agencymicrositesettingsinvoice;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice> CancelAgencyMicroSiteSettingsInvoiceChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsInvoiceUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice item);
        partial void OnAfterAgencyMicroSiteSettingsInvoiceUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice> UpdateAgencyMicroSiteSettingsInvoice(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice agencymicrositesettingsinvoice)
        {
            OnAgencyMicroSiteSettingsInvoiceUpdated(agencymicrositesettingsinvoice);

            var itemToUpdate = Context.AgencyMicroSiteSettingsInvoices
                              .Where(i => i.Id == agencymicrositesettingsinvoice.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingsinvoice).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsInvoiceUpdated(agencymicrositesettingsinvoice);

            return agencymicrositesettingsinvoice;
        }

        partial void OnAgencyMicroSiteSettingsInvoiceDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice item);
        partial void OnAfterAgencyMicroSiteSettingsInvoiceDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsInvoice> DeleteAgencyMicroSiteSettingsInvoice(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingsInvoices
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingsInvoiceDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingsInvoices.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsInvoiceDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingsOthersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsothers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsothers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsOthersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsothers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsothers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsOthersRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther>> GetAgencyMicroSiteSettingsOthers(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsOthers.AsQueryable();


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

            OnAgencyMicroSiteSettingsOthersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingsOtherGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther> GetAgencyMicroSiteSettingsOtherById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsOthers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsOtherGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsOtherCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther item);
        partial void OnAfterAgencyMicroSiteSettingsOtherCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther> CreateAgencyMicroSiteSettingsOther(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther agencymicrositesettingsother)
        {
            OnAgencyMicroSiteSettingsOtherCreated(agencymicrositesettingsother);

            var existingItem = Context.AgencyMicroSiteSettingsOthers
                              .Where(i => i.Id == agencymicrositesettingsother.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingsOthers.Add(agencymicrositesettingsother);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingsother).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsOtherCreated(agencymicrositesettingsother);

            return agencymicrositesettingsother;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther> CancelAgencyMicroSiteSettingsOtherChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsOtherUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther item);
        partial void OnAfterAgencyMicroSiteSettingsOtherUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther> UpdateAgencyMicroSiteSettingsOther(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther agencymicrositesettingsother)
        {
            OnAgencyMicroSiteSettingsOtherUpdated(agencymicrositesettingsother);

            var itemToUpdate = Context.AgencyMicroSiteSettingsOthers
                              .Where(i => i.Id == agencymicrositesettingsother.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingsother).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsOtherUpdated(agencymicrositesettingsother);

            return agencymicrositesettingsother;
        }

        partial void OnAgencyMicroSiteSettingsOtherDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther item);
        partial void OnAfterAgencyMicroSiteSettingsOtherDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsOther> DeleteAgencyMicroSiteSettingsOther(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingsOthers
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingsOtherDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingsOthers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsOtherDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingsPaymetOptionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingspaymetoptions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingspaymetoptions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsPaymetOptionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingspaymetoptions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingspaymetoptions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsPaymetOptionsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption>> GetAgencyMicroSiteSettingsPaymetOptions(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsPaymetOptions.AsQueryable();


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

            OnAgencyMicroSiteSettingsPaymetOptionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingsPaymetOptionGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption> GetAgencyMicroSiteSettingsPaymetOptionById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsPaymetOptions
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsPaymetOptionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsPaymetOptionCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption item);
        partial void OnAfterAgencyMicroSiteSettingsPaymetOptionCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption> CreateAgencyMicroSiteSettingsPaymetOption(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption agencymicrositesettingspaymetoption)
        {
            OnAgencyMicroSiteSettingsPaymetOptionCreated(agencymicrositesettingspaymetoption);

            var existingItem = Context.AgencyMicroSiteSettingsPaymetOptions
                              .Where(i => i.Id == agencymicrositesettingspaymetoption.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingsPaymetOptions.Add(agencymicrositesettingspaymetoption);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingspaymetoption).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsPaymetOptionCreated(agencymicrositesettingspaymetoption);

            return agencymicrositesettingspaymetoption;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption> CancelAgencyMicroSiteSettingsPaymetOptionChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsPaymetOptionUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption item);
        partial void OnAfterAgencyMicroSiteSettingsPaymetOptionUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption> UpdateAgencyMicroSiteSettingsPaymetOption(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption agencymicrositesettingspaymetoption)
        {
            OnAgencyMicroSiteSettingsPaymetOptionUpdated(agencymicrositesettingspaymetoption);

            var itemToUpdate = Context.AgencyMicroSiteSettingsPaymetOptions
                              .Where(i => i.Id == agencymicrositesettingspaymetoption.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingspaymetoption).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsPaymetOptionUpdated(agencymicrositesettingspaymetoption);

            return agencymicrositesettingspaymetoption;
        }

        partial void OnAgencyMicroSiteSettingsPaymetOptionDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption item);
        partial void OnAfterAgencyMicroSiteSettingsPaymetOptionDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsPaymetOption> DeleteAgencyMicroSiteSettingsPaymetOption(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingsPaymetOptions
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingsPaymetOptionDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingsPaymetOptions.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsPaymetOptionDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingsRequestInvoicesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsrequestinvoices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsrequestinvoices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsRequestInvoicesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsrequestinvoices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsrequestinvoices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsRequestInvoicesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice>> GetAgencyMicroSiteSettingsRequestInvoices(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsRequestInvoices.AsQueryable();


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

            OnAgencyMicroSiteSettingsRequestInvoicesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingsRequestInvoiceGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice> GetAgencyMicroSiteSettingsRequestInvoiceById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsRequestInvoices
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsRequestInvoiceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsRequestInvoiceCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice item);
        partial void OnAfterAgencyMicroSiteSettingsRequestInvoiceCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice> CreateAgencyMicroSiteSettingsRequestInvoice(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice agencymicrositesettingsrequestinvoice)
        {
            OnAgencyMicroSiteSettingsRequestInvoiceCreated(agencymicrositesettingsrequestinvoice);

            var existingItem = Context.AgencyMicroSiteSettingsRequestInvoices
                              .Where(i => i.Id == agencymicrositesettingsrequestinvoice.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingsRequestInvoices.Add(agencymicrositesettingsrequestinvoice);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingsrequestinvoice).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsRequestInvoiceCreated(agencymicrositesettingsrequestinvoice);

            return agencymicrositesettingsrequestinvoice;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice> CancelAgencyMicroSiteSettingsRequestInvoiceChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsRequestInvoiceUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice item);
        partial void OnAfterAgencyMicroSiteSettingsRequestInvoiceUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice> UpdateAgencyMicroSiteSettingsRequestInvoice(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice agencymicrositesettingsrequestinvoice)
        {
            OnAgencyMicroSiteSettingsRequestInvoiceUpdated(agencymicrositesettingsrequestinvoice);

            var itemToUpdate = Context.AgencyMicroSiteSettingsRequestInvoices
                              .Where(i => i.Id == agencymicrositesettingsrequestinvoice.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingsrequestinvoice).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsRequestInvoiceUpdated(agencymicrositesettingsrequestinvoice);

            return agencymicrositesettingsrequestinvoice;
        }

        partial void OnAgencyMicroSiteSettingsRequestInvoiceDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice item);
        partial void OnAfterAgencyMicroSiteSettingsRequestInvoiceDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequestInvoice> DeleteAgencyMicroSiteSettingsRequestInvoice(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingsRequestInvoices
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingsRequestInvoiceDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingsRequestInvoices.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsRequestInvoiceDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingsRequiredPassengersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsrequiredpassengers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsrequiredpassengers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsRequiredPassengersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingsrequiredpassengers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingsrequiredpassengers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsRequiredPassengersRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger>> GetAgencyMicroSiteSettingsRequiredPassengers(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsRequiredPassengers.AsQueryable();


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

            OnAgencyMicroSiteSettingsRequiredPassengersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingsRequiredPassengerGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger> GetAgencyMicroSiteSettingsRequiredPassengerById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsRequiredPassengers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsRequiredPassengerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsRequiredPassengerCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger item);
        partial void OnAfterAgencyMicroSiteSettingsRequiredPassengerCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger> CreateAgencyMicroSiteSettingsRequiredPassenger(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger agencymicrositesettingsrequiredpassenger)
        {
            OnAgencyMicroSiteSettingsRequiredPassengerCreated(agencymicrositesettingsrequiredpassenger);

            var existingItem = Context.AgencyMicroSiteSettingsRequiredPassengers
                              .Where(i => i.Id == agencymicrositesettingsrequiredpassenger.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingsRequiredPassengers.Add(agencymicrositesettingsrequiredpassenger);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingsrequiredpassenger).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsRequiredPassengerCreated(agencymicrositesettingsrequiredpassenger);

            return agencymicrositesettingsrequiredpassenger;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger> CancelAgencyMicroSiteSettingsRequiredPassengerChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsRequiredPassengerUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger item);
        partial void OnAfterAgencyMicroSiteSettingsRequiredPassengerUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger> UpdateAgencyMicroSiteSettingsRequiredPassenger(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger agencymicrositesettingsrequiredpassenger)
        {
            OnAgencyMicroSiteSettingsRequiredPassengerUpdated(agencymicrositesettingsrequiredpassenger);

            var itemToUpdate = Context.AgencyMicroSiteSettingsRequiredPassengers
                              .Where(i => i.Id == agencymicrositesettingsrequiredpassenger.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingsrequiredpassenger).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsRequiredPassengerUpdated(agencymicrositesettingsrequiredpassenger);

            return agencymicrositesettingsrequiredpassenger;
        }

        partial void OnAgencyMicroSiteSettingsRequiredPassengerDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger item);
        partial void OnAfterAgencyMicroSiteSettingsRequiredPassengerDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsRequiredPassenger> DeleteAgencyMicroSiteSettingsRequiredPassenger(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingsRequiredPassengers
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingsRequiredPassengerDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingsRequiredPassengers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsRequiredPassengerDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingsSearchEnginesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingssearchengines/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingssearchengines/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsSearchEnginesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingssearchengines/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingssearchengines/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsSearchEnginesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine>> GetAgencyMicroSiteSettingsSearchEngines(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsSearchEngines.AsQueryable();


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

            OnAgencyMicroSiteSettingsSearchEnginesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingsSearchEngineGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine> GetAgencyMicroSiteSettingsSearchEngineById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsSearchEngines
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsSearchEngineGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsSearchEngineCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine item);
        partial void OnAfterAgencyMicroSiteSettingsSearchEngineCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine> CreateAgencyMicroSiteSettingsSearchEngine(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine agencymicrositesettingssearchengine)
        {
            OnAgencyMicroSiteSettingsSearchEngineCreated(agencymicrositesettingssearchengine);

            var existingItem = Context.AgencyMicroSiteSettingsSearchEngines
                              .Where(i => i.Id == agencymicrositesettingssearchengine.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingsSearchEngines.Add(agencymicrositesettingssearchengine);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingssearchengine).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsSearchEngineCreated(agencymicrositesettingssearchengine);

            return agencymicrositesettingssearchengine;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine> CancelAgencyMicroSiteSettingsSearchEngineChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsSearchEngineUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine item);
        partial void OnAfterAgencyMicroSiteSettingsSearchEngineUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine> UpdateAgencyMicroSiteSettingsSearchEngine(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine agencymicrositesettingssearchengine)
        {
            OnAgencyMicroSiteSettingsSearchEngineUpdated(agencymicrositesettingssearchengine);

            var itemToUpdate = Context.AgencyMicroSiteSettingsSearchEngines
                              .Where(i => i.Id == agencymicrositesettingssearchengine.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingssearchengine).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsSearchEngineUpdated(agencymicrositesettingssearchengine);

            return agencymicrositesettingssearchengine;
        }

        partial void OnAgencyMicroSiteSettingsSearchEngineDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine item);
        partial void OnAfterAgencyMicroSiteSettingsSearchEngineDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchEngine> DeleteAgencyMicroSiteSettingsSearchEngine(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingsSearchEngines
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingsSearchEngineDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingsSearchEngines.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsSearchEngineDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingsSearchSettingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingssearchsettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingssearchsettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsSearchSettingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingssearchsettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingssearchsettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsSearchSettingsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting>> GetAgencyMicroSiteSettingsSearchSettings(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsSearchSettings.AsQueryable();


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

            OnAgencyMicroSiteSettingsSearchSettingsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingsSearchSettingGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting> GetAgencyMicroSiteSettingsSearchSettingById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsSearchSettings
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsSearchSettingGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsSearchSettingCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting item);
        partial void OnAfterAgencyMicroSiteSettingsSearchSettingCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting> CreateAgencyMicroSiteSettingsSearchSetting(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting agencymicrositesettingssearchsetting)
        {
            OnAgencyMicroSiteSettingsSearchSettingCreated(agencymicrositesettingssearchsetting);

            var existingItem = Context.AgencyMicroSiteSettingsSearchSettings
                              .Where(i => i.Id == agencymicrositesettingssearchsetting.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingsSearchSettings.Add(agencymicrositesettingssearchsetting);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingssearchsetting).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsSearchSettingCreated(agencymicrositesettingssearchsetting);

            return agencymicrositesettingssearchsetting;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting> CancelAgencyMicroSiteSettingsSearchSettingChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsSearchSettingUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting item);
        partial void OnAfterAgencyMicroSiteSettingsSearchSettingUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting> UpdateAgencyMicroSiteSettingsSearchSetting(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting agencymicrositesettingssearchsetting)
        {
            OnAgencyMicroSiteSettingsSearchSettingUpdated(agencymicrositesettingssearchsetting);

            var itemToUpdate = Context.AgencyMicroSiteSettingsSearchSettings
                              .Where(i => i.Id == agencymicrositesettingssearchsetting.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingssearchsetting).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsSearchSettingUpdated(agencymicrositesettingssearchsetting);

            return agencymicrositesettingssearchsetting;
        }

        partial void OnAgencyMicroSiteSettingsSearchSettingDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting item);
        partial void OnAfterAgencyMicroSiteSettingsSearchSettingDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSearchSetting> DeleteAgencyMicroSiteSettingsSearchSetting(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingsSearchSettings
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingsSearchSettingDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingsSearchSettings.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsSearchSettingDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingsSortTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingssorttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingssorttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsSortTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingssorttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingssorttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsSortTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType>> GetAgencyMicroSiteSettingsSortTypes(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsSortTypes.AsQueryable();


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

            OnAgencyMicroSiteSettingsSortTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingsSortTypeGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType> GetAgencyMicroSiteSettingsSortTypeById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsSortTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsSortTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsSortTypeCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType item);
        partial void OnAfterAgencyMicroSiteSettingsSortTypeCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType> CreateAgencyMicroSiteSettingsSortType(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType agencymicrositesettingssorttype)
        {
            OnAgencyMicroSiteSettingsSortTypeCreated(agencymicrositesettingssorttype);

            var existingItem = Context.AgencyMicroSiteSettingsSortTypes
                              .Where(i => i.Id == agencymicrositesettingssorttype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingsSortTypes.Add(agencymicrositesettingssorttype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingssorttype).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsSortTypeCreated(agencymicrositesettingssorttype);

            return agencymicrositesettingssorttype;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType> CancelAgencyMicroSiteSettingsSortTypeChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsSortTypeUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType item);
        partial void OnAfterAgencyMicroSiteSettingsSortTypeUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType> UpdateAgencyMicroSiteSettingsSortType(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType agencymicrositesettingssorttype)
        {
            OnAgencyMicroSiteSettingsSortTypeUpdated(agencymicrositesettingssorttype);

            var itemToUpdate = Context.AgencyMicroSiteSettingsSortTypes
                              .Where(i => i.Id == agencymicrositesettingssorttype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingssorttype).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsSortTypeUpdated(agencymicrositesettingssorttype);

            return agencymicrositesettingssorttype;
        }

        partial void OnAgencyMicroSiteSettingsSortTypeDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType item);
        partial void OnAfterAgencyMicroSiteSettingsSortTypeDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsSortType> DeleteAgencyMicroSiteSettingsSortType(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingsSortTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingsSortTypeDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingsSortTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsSortTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSiteSettingsTermsConditionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingstermsconditions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingstermsconditions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsTermsConditionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositesettingstermsconditions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositesettingstermsconditions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsTermsConditionsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition>> GetAgencyMicroSiteSettingsTermsConditions(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsTermsConditions.AsQueryable();


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

            OnAgencyMicroSiteSettingsTermsConditionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteSettingsTermsConditionGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition> GetAgencyMicroSiteSettingsTermsConditionById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsTermsConditions
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsTermsConditionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsTermsConditionCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition item);
        partial void OnAfterAgencyMicroSiteSettingsTermsConditionCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition> CreateAgencyMicroSiteSettingsTermsCondition(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition agencymicrositesettingstermscondition)
        {
            OnAgencyMicroSiteSettingsTermsConditionCreated(agencymicrositesettingstermscondition);

            var existingItem = Context.AgencyMicroSiteSettingsTermsConditions
                              .Where(i => i.Id == agencymicrositesettingstermscondition.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSiteSettingsTermsConditions.Add(agencymicrositesettingstermscondition);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositesettingstermscondition).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsTermsConditionCreated(agencymicrositesettingstermscondition);

            return agencymicrositesettingstermscondition;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition> CancelAgencyMicroSiteSettingsTermsConditionChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsTermsConditionUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition item);
        partial void OnAfterAgencyMicroSiteSettingsTermsConditionUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition> UpdateAgencyMicroSiteSettingsTermsCondition(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition agencymicrositesettingstermscondition)
        {
            OnAgencyMicroSiteSettingsTermsConditionUpdated(agencymicrositesettingstermscondition);

            var itemToUpdate = Context.AgencyMicroSiteSettingsTermsConditions
                              .Where(i => i.Id == agencymicrositesettingstermscondition.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositesettingstermscondition).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsTermsConditionUpdated(agencymicrositesettingstermscondition);

            return agencymicrositesettingstermscondition;
        }

        partial void OnAgencyMicroSiteSettingsTermsConditionDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition item);
        partial void OnAfterAgencyMicroSiteSettingsTermsConditionDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSiteSettingsTermsCondition> DeleteAgencyMicroSiteSettingsTermsCondition(int id)
        {
            var itemToDelete = Context.AgencyMicroSiteSettingsTermsConditions
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSiteSettingsTermsConditionDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSiteSettingsTermsConditions.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSiteSettingsTermsConditionDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyMicroSitesSettingsEmailConfigurationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositessettingsemailconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositessettingsemailconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSitesSettingsEmailConfigurationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencymicrositessettingsemailconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencymicrositessettingsemailconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSitesSettingsEmailConfigurationsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration>> GetAgencyMicroSitesSettingsEmailConfigurations(Query query = null)
        {
            var items = Context.AgencyMicroSitesSettingsEmailConfigurations.AsQueryable();


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

            OnAgencyMicroSitesSettingsEmailConfigurationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSitesSettingsEmailConfigurationGet(ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration> GetAgencyMicroSitesSettingsEmailConfigurationById(int id)
        {
            var items = Context.AgencyMicroSitesSettingsEmailConfigurations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSitesSettingsEmailConfigurationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSitesSettingsEmailConfigurationCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration item);
        partial void OnAfterAgencyMicroSitesSettingsEmailConfigurationCreated(ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration> CreateAgencyMicroSitesSettingsEmailConfiguration(ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration agencymicrositessettingsemailconfiguration)
        {
            OnAgencyMicroSitesSettingsEmailConfigurationCreated(agencymicrositessettingsemailconfiguration);

            var existingItem = Context.AgencyMicroSitesSettingsEmailConfigurations
                              .Where(i => i.Id == agencymicrositessettingsemailconfiguration.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencyMicroSitesSettingsEmailConfigurations.Add(agencymicrositessettingsemailconfiguration);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencymicrositessettingsemailconfiguration).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencyMicroSitesSettingsEmailConfigurationCreated(agencymicrositessettingsemailconfiguration);

            return agencymicrositessettingsemailconfiguration;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration> CancelAgencyMicroSitesSettingsEmailConfigurationChanges(ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSitesSettingsEmailConfigurationUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration item);
        partial void OnAfterAgencyMicroSitesSettingsEmailConfigurationUpdated(ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration> UpdateAgencyMicroSitesSettingsEmailConfiguration(int id, ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration agencymicrositessettingsemailconfiguration)
        {
            OnAgencyMicroSitesSettingsEmailConfigurationUpdated(agencymicrositessettingsemailconfiguration);

            var itemToUpdate = Context.AgencyMicroSitesSettingsEmailConfigurations
                              .Where(i => i.Id == agencymicrositessettingsemailconfiguration.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencymicrositessettingsemailconfiguration).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSitesSettingsEmailConfigurationUpdated(agencymicrositessettingsemailconfiguration);

            return agencymicrositessettingsemailconfiguration;
        }

        partial void OnAgencyMicroSitesSettingsEmailConfigurationDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration item);
        partial void OnAfterAgencyMicroSitesSettingsEmailConfigurationDeleted(ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyMicroSitesSettingsEmailConfiguration> DeleteAgencyMicroSitesSettingsEmailConfiguration(int id)
        {
            var itemToDelete = Context.AgencyMicroSitesSettingsEmailConfigurations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencyMicroSitesSettingsEmailConfigurationDeleted(itemToDelete);

            Reset();

            Context.AgencyMicroSitesSettingsEmailConfigurations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencyMicroSitesSettingsEmailConfigurationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencySupplementCommissionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencysupplementcommissions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencysupplementcommissions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencySupplementCommissionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencysupplementcommissions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencysupplementcommissions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencySupplementCommissionsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencySupplementCommission> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencySupplementCommission>> GetAgencySupplementCommissions(Query query = null)
        {
            var items = Context.AgencySupplementCommissions.AsQueryable();


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

            OnAgencySupplementCommissionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencySupplementCommissionGet(ZarenTravelBO.Models.zaren_test.AgencySupplementCommission item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencySupplementCommission> GetAgencySupplementCommissionById(int id)
        {
            var items = Context.AgencySupplementCommissions
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencySupplementCommissionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencySupplementCommissionCreated(ZarenTravelBO.Models.zaren_test.AgencySupplementCommission item);
        partial void OnAfterAgencySupplementCommissionCreated(ZarenTravelBO.Models.zaren_test.AgencySupplementCommission item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencySupplementCommission> CreateAgencySupplementCommission(ZarenTravelBO.Models.zaren_test.AgencySupplementCommission agencysupplementcommission)
        {
            OnAgencySupplementCommissionCreated(agencysupplementcommission);

            var existingItem = Context.AgencySupplementCommissions
                              .Where(i => i.Id == agencysupplementcommission.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AgencySupplementCommissions.Add(agencysupplementcommission);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(agencysupplementcommission).State = EntityState.Detached;
                throw;
            }

            OnAfterAgencySupplementCommissionCreated(agencysupplementcommission);

            return agencysupplementcommission;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.AgencySupplementCommission> CancelAgencySupplementCommissionChanges(ZarenTravelBO.Models.zaren_test.AgencySupplementCommission item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencySupplementCommissionUpdated(ZarenTravelBO.Models.zaren_test.AgencySupplementCommission item);
        partial void OnAfterAgencySupplementCommissionUpdated(ZarenTravelBO.Models.zaren_test.AgencySupplementCommission item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencySupplementCommission> UpdateAgencySupplementCommission(int id, ZarenTravelBO.Models.zaren_test.AgencySupplementCommission agencysupplementcommission)
        {
            OnAgencySupplementCommissionUpdated(agencysupplementcommission);

            var itemToUpdate = Context.AgencySupplementCommissions
                              .Where(i => i.Id == agencysupplementcommission.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(agencysupplementcommission).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencySupplementCommissionUpdated(agencysupplementcommission);

            return agencysupplementcommission;
        }

        partial void OnAgencySupplementCommissionDeleted(ZarenTravelBO.Models.zaren_test.AgencySupplementCommission item);
        partial void OnAfterAgencySupplementCommissionDeleted(ZarenTravelBO.Models.zaren_test.AgencySupplementCommission item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencySupplementCommission> DeleteAgencySupplementCommission(int id)
        {
            var itemToDelete = Context.AgencySupplementCommissions
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAgencySupplementCommissionDeleted(itemToDelete);

            Reset();

            Context.AgencySupplementCommissions.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAgencySupplementCommissionDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyUsersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencyusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencyusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyUsersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencyusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencyusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyUsersRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyUser> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyUser>> GetAgencyUsers(Query query = null)
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

        partial void OnAgencyUserGet(ZarenTravelBO.Models.zaren_test.AgencyUser item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyUser> GetAgencyUserById(int id)
        {
            var items = Context.AgencyUsers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyUserGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyUserCreated(ZarenTravelBO.Models.zaren_test.AgencyUser item);
        partial void OnAfterAgencyUserCreated(ZarenTravelBO.Models.zaren_test.AgencyUser item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyUser> CreateAgencyUser(ZarenTravelBO.Models.zaren_test.AgencyUser agencyuser)
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

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyUser> CancelAgencyUserChanges(ZarenTravelBO.Models.zaren_test.AgencyUser item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyUserUpdated(ZarenTravelBO.Models.zaren_test.AgencyUser item);
        partial void OnAfterAgencyUserUpdated(ZarenTravelBO.Models.zaren_test.AgencyUser item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyUser> UpdateAgencyUser(int id, ZarenTravelBO.Models.zaren_test.AgencyUser agencyuser)
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

            Context.Attach(agencyuser).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyUserUpdated(agencyuser);

            return agencyuser;
        }

        partial void OnAgencyUserDeleted(ZarenTravelBO.Models.zaren_test.AgencyUser item);
        partial void OnAfterAgencyUserDeleted(ZarenTravelBO.Models.zaren_test.AgencyUser item);

        public async Task<ZarenTravelBO.Models.zaren_test.AgencyUser> DeleteAgencyUser(int id)
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
    
        public async Task ExportApiProductsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/apiproducts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/apiproducts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportApiProductsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/apiproducts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/apiproducts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnApiProductsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.ApiProduct> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.ApiProduct>> GetApiProducts(Query query = null)
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

        partial void OnApiProductGet(ZarenTravelBO.Models.zaren_test.ApiProduct item);

        public async Task<ZarenTravelBO.Models.zaren_test.ApiProduct> GetApiProductById(int id)
        {
            var items = Context.ApiProducts
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnApiProductGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnApiProductCreated(ZarenTravelBO.Models.zaren_test.ApiProduct item);
        partial void OnAfterApiProductCreated(ZarenTravelBO.Models.zaren_test.ApiProduct item);

        public async Task<ZarenTravelBO.Models.zaren_test.ApiProduct> CreateApiProduct(ZarenTravelBO.Models.zaren_test.ApiProduct apiproduct)
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

        public async Task<ZarenTravelBO.Models.zaren_test.ApiProduct> CancelApiProductChanges(ZarenTravelBO.Models.zaren_test.ApiProduct item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnApiProductUpdated(ZarenTravelBO.Models.zaren_test.ApiProduct item);
        partial void OnAfterApiProductUpdated(ZarenTravelBO.Models.zaren_test.ApiProduct item);

        public async Task<ZarenTravelBO.Models.zaren_test.ApiProduct> UpdateApiProduct(int id, ZarenTravelBO.Models.zaren_test.ApiProduct apiproduct)
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

            Context.Attach(apiproduct).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterApiProductUpdated(apiproduct);

            return apiproduct;
        }

        partial void OnApiProductDeleted(ZarenTravelBO.Models.zaren_test.ApiProduct item);
        partial void OnAfterApiProductDeleted(ZarenTravelBO.Models.zaren_test.ApiProduct item);

        public async Task<ZarenTravelBO.Models.zaren_test.ApiProduct> DeleteApiProduct(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/apiresults/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/apiresults/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportApiResultsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/apiresults/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/apiresults/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnApiResultsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.ApiResult> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.ApiResult>> GetApiResults(Query query = null)
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

        partial void OnApiResultGet(ZarenTravelBO.Models.zaren_test.ApiResult item);

        public async Task<ZarenTravelBO.Models.zaren_test.ApiResult> GetApiResultById(int id)
        {
            var items = Context.ApiResults
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnApiResultGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnApiResultCreated(ZarenTravelBO.Models.zaren_test.ApiResult item);
        partial void OnAfterApiResultCreated(ZarenTravelBO.Models.zaren_test.ApiResult item);

        public async Task<ZarenTravelBO.Models.zaren_test.ApiResult> CreateApiResult(ZarenTravelBO.Models.zaren_test.ApiResult apiresult)
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

        public async Task<ZarenTravelBO.Models.zaren_test.ApiResult> CancelApiResultChanges(ZarenTravelBO.Models.zaren_test.ApiResult item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnApiResultUpdated(ZarenTravelBO.Models.zaren_test.ApiResult item);
        partial void OnAfterApiResultUpdated(ZarenTravelBO.Models.zaren_test.ApiResult item);

        public async Task<ZarenTravelBO.Models.zaren_test.ApiResult> UpdateApiResult(int id, ZarenTravelBO.Models.zaren_test.ApiResult apiresult)
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

            Context.Attach(apiresult).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterApiResultUpdated(apiresult);

            return apiresult;
        }

        partial void OnApiResultDeleted(ZarenTravelBO.Models.zaren_test.ApiResult item);
        partial void OnAfterApiResultDeleted(ZarenTravelBO.Models.zaren_test.ApiResult item);

        public async Task<ZarenTravelBO.Models.zaren_test.ApiResult> DeleteApiResult(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/autocompletes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/autocompletes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAutoCompletesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/autocompletes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/autocompletes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAutoCompletesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AutoComplete> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AutoComplete>> GetAutoCompletes(Query query = null)
        {
            var items = Context.AutoCompletes.AsQueryable();

            items = items.Include(i => i.AutoCompleteType);

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

        partial void OnAutoCompleteGet(ZarenTravelBO.Models.zaren_test.AutoComplete item);

        public async Task<ZarenTravelBO.Models.zaren_test.AutoComplete> GetAutoCompleteById(int id)
        {
            var items = Context.AutoCompletes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.AutoCompleteType);
  
            var itemToReturn = items.FirstOrDefault();

            OnAutoCompleteGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAutoCompleteCreated(ZarenTravelBO.Models.zaren_test.AutoComplete item);
        partial void OnAfterAutoCompleteCreated(ZarenTravelBO.Models.zaren_test.AutoComplete item);

        public async Task<ZarenTravelBO.Models.zaren_test.AutoComplete> CreateAutoComplete(ZarenTravelBO.Models.zaren_test.AutoComplete autocomplete)
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

        public async Task<ZarenTravelBO.Models.zaren_test.AutoComplete> CancelAutoCompleteChanges(ZarenTravelBO.Models.zaren_test.AutoComplete item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAutoCompleteUpdated(ZarenTravelBO.Models.zaren_test.AutoComplete item);
        partial void OnAfterAutoCompleteUpdated(ZarenTravelBO.Models.zaren_test.AutoComplete item);

        public async Task<ZarenTravelBO.Models.zaren_test.AutoComplete> UpdateAutoComplete(int id, ZarenTravelBO.Models.zaren_test.AutoComplete autocomplete)
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
            autocomplete.AutoCompleteType = null;

            Context.Attach(autocomplete).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAutoCompleteUpdated(autocomplete);

            return autocomplete;
        }

        partial void OnAutoCompleteDeleted(ZarenTravelBO.Models.zaren_test.AutoComplete item);
        partial void OnAfterAutoCompleteDeleted(ZarenTravelBO.Models.zaren_test.AutoComplete item);

        public async Task<ZarenTravelBO.Models.zaren_test.AutoComplete> DeleteAutoComplete(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/autocompletetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/autocompletetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAutoCompleteTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/autocompletetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/autocompletetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAutoCompleteTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AutoCompleteType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AutoCompleteType>> GetAutoCompleteTypes(Query query = null)
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

        partial void OnAutoCompleteTypeGet(ZarenTravelBO.Models.zaren_test.AutoCompleteType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AutoCompleteType> GetAutoCompleteTypeById(int id)
        {
            var items = Context.AutoCompleteTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAutoCompleteTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAutoCompleteTypeCreated(ZarenTravelBO.Models.zaren_test.AutoCompleteType item);
        partial void OnAfterAutoCompleteTypeCreated(ZarenTravelBO.Models.zaren_test.AutoCompleteType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AutoCompleteType> CreateAutoCompleteType(ZarenTravelBO.Models.zaren_test.AutoCompleteType autocompletetype)
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

        public async Task<ZarenTravelBO.Models.zaren_test.AutoCompleteType> CancelAutoCompleteTypeChanges(ZarenTravelBO.Models.zaren_test.AutoCompleteType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAutoCompleteTypeUpdated(ZarenTravelBO.Models.zaren_test.AutoCompleteType item);
        partial void OnAfterAutoCompleteTypeUpdated(ZarenTravelBO.Models.zaren_test.AutoCompleteType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AutoCompleteType> UpdateAutoCompleteType(int id, ZarenTravelBO.Models.zaren_test.AutoCompleteType autocompletetype)
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

        partial void OnAutoCompleteTypeDeleted(ZarenTravelBO.Models.zaren_test.AutoCompleteType item);
        partial void OnAfterAutoCompleteTypeDeleted(ZarenTravelBO.Models.zaren_test.AutoCompleteType item);

        public async Task<ZarenTravelBO.Models.zaren_test.AutoCompleteType> DeleteAutoCompleteType(int id)
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
    
        public async Task ExportBoardsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/boards/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/boards/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBoardsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/boards/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/boards/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBoardsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Board> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Board>> GetBoards(Query query = null)
        {
            var items = Context.Boards.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);

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

            OnBoardsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBoardGet(ZarenTravelBO.Models.zaren_test.Board item);

        public async Task<ZarenTravelBO.Models.zaren_test.Board> GetBoardById(int id)
        {
            var items = Context.Boards
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnBoardGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBoardCreated(ZarenTravelBO.Models.zaren_test.Board item);
        partial void OnAfterBoardCreated(ZarenTravelBO.Models.zaren_test.Board item);

        public async Task<ZarenTravelBO.Models.zaren_test.Board> CreateBoard(ZarenTravelBO.Models.zaren_test.Board board)
        {
            OnBoardCreated(board);

            var existingItem = Context.Boards
                              .Where(i => i.Id == board.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Boards.Add(board);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(board).State = EntityState.Detached;
                throw;
            }

            OnAfterBoardCreated(board);

            return board;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Board> CancelBoardChanges(ZarenTravelBO.Models.zaren_test.Board item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBoardUpdated(ZarenTravelBO.Models.zaren_test.Board item);
        partial void OnAfterBoardUpdated(ZarenTravelBO.Models.zaren_test.Board item);

        public async Task<ZarenTravelBO.Models.zaren_test.Board> UpdateBoard(int id, ZarenTravelBO.Models.zaren_test.Board board)
        {
            OnBoardUpdated(board);

            var itemToUpdate = Context.Boards
                              .Where(i => i.Id == board.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            board.Agency = null;
            board.Language = null;

            Context.Attach(board).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBoardUpdated(board);

            return board;
        }

        partial void OnBoardDeleted(ZarenTravelBO.Models.zaren_test.Board item);
        partial void OnAfterBoardDeleted(ZarenTravelBO.Models.zaren_test.Board item);

        public async Task<ZarenTravelBO.Models.zaren_test.Board> DeleteBoard(int id)
        {
            var itemToDelete = Context.Boards
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBoardDeleted(itemToDelete);

            Reset();

            Context.Boards.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBoardDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCancellationPoliciesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/cancellationpolicies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/cancellationpolicies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCancellationPoliciesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/cancellationpolicies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/cancellationpolicies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCancellationPoliciesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.CancellationPolicy> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.CancellationPolicy>> GetCancellationPolicies(Query query = null)
        {
            var items = Context.CancellationPolicies.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);

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

            OnCancellationPoliciesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCancellationPolicyGet(ZarenTravelBO.Models.zaren_test.CancellationPolicy item);

        public async Task<ZarenTravelBO.Models.zaren_test.CancellationPolicy> GetCancellationPolicyById(int id)
        {
            var items = Context.CancellationPolicies
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnCancellationPolicyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCancellationPolicyCreated(ZarenTravelBO.Models.zaren_test.CancellationPolicy item);
        partial void OnAfterCancellationPolicyCreated(ZarenTravelBO.Models.zaren_test.CancellationPolicy item);

        public async Task<ZarenTravelBO.Models.zaren_test.CancellationPolicy> CreateCancellationPolicy(ZarenTravelBO.Models.zaren_test.CancellationPolicy cancellationpolicy)
        {
            OnCancellationPolicyCreated(cancellationpolicy);

            var existingItem = Context.CancellationPolicies
                              .Where(i => i.Id == cancellationpolicy.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CancellationPolicies.Add(cancellationpolicy);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(cancellationpolicy).State = EntityState.Detached;
                throw;
            }

            OnAfterCancellationPolicyCreated(cancellationpolicy);

            return cancellationpolicy;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.CancellationPolicy> CancelCancellationPolicyChanges(ZarenTravelBO.Models.zaren_test.CancellationPolicy item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCancellationPolicyUpdated(ZarenTravelBO.Models.zaren_test.CancellationPolicy item);
        partial void OnAfterCancellationPolicyUpdated(ZarenTravelBO.Models.zaren_test.CancellationPolicy item);

        public async Task<ZarenTravelBO.Models.zaren_test.CancellationPolicy> UpdateCancellationPolicy(int id, ZarenTravelBO.Models.zaren_test.CancellationPolicy cancellationpolicy)
        {
            OnCancellationPolicyUpdated(cancellationpolicy);

            var itemToUpdate = Context.CancellationPolicies
                              .Where(i => i.Id == cancellationpolicy.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            cancellationpolicy.Agency = null;
            cancellationpolicy.Language = null;

            Context.Attach(cancellationpolicy).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCancellationPolicyUpdated(cancellationpolicy);

            return cancellationpolicy;
        }

        partial void OnCancellationPolicyDeleted(ZarenTravelBO.Models.zaren_test.CancellationPolicy item);
        partial void OnAfterCancellationPolicyDeleted(ZarenTravelBO.Models.zaren_test.CancellationPolicy item);

        public async Task<ZarenTravelBO.Models.zaren_test.CancellationPolicy> DeleteCancellationPolicy(int id)
        {
            var itemToDelete = Context.CancellationPolicies
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCancellationPolicyDeleted(itemToDelete);

            Reset();

            Context.CancellationPolicies.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCancellationPolicyDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/cities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/cities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/cities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/cities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCitiesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.City> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.City>> GetCities(Query query = null)
        {
            var items = Context.Cities.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);

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

        partial void OnCityGet(ZarenTravelBO.Models.zaren_test.City item);

        public async Task<ZarenTravelBO.Models.zaren_test.City> GetCityById(int id)
        {
            var items = Context.Cities
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnCityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCityCreated(ZarenTravelBO.Models.zaren_test.City item);
        partial void OnAfterCityCreated(ZarenTravelBO.Models.zaren_test.City item);

        public async Task<ZarenTravelBO.Models.zaren_test.City> CreateCity(ZarenTravelBO.Models.zaren_test.City city)
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

        public async Task<ZarenTravelBO.Models.zaren_test.City> CancelCityChanges(ZarenTravelBO.Models.zaren_test.City item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCityUpdated(ZarenTravelBO.Models.zaren_test.City item);
        partial void OnAfterCityUpdated(ZarenTravelBO.Models.zaren_test.City item);

        public async Task<ZarenTravelBO.Models.zaren_test.City> UpdateCity(int id, ZarenTravelBO.Models.zaren_test.City city)
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
            city.Agency = null;
            city.Language = null;

            Context.Attach(city).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCityUpdated(city);

            return city;
        }

        partial void OnCityDeleted(ZarenTravelBO.Models.zaren_test.City item);
        partial void OnAfterCityDeleted(ZarenTravelBO.Models.zaren_test.City item);

        public async Task<ZarenTravelBO.Models.zaren_test.City> DeleteCity(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/countries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/countries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCountriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/countries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/countries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCountriesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Country> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Country>> GetCountries(Query query = null)
        {
            var items = Context.Countries.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);

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

        partial void OnCountryGet(ZarenTravelBO.Models.zaren_test.Country item);

        public async Task<ZarenTravelBO.Models.zaren_test.Country> GetCountryById(int id)
        {
            var items = Context.Countries
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnCountryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCountryCreated(ZarenTravelBO.Models.zaren_test.Country item);
        partial void OnAfterCountryCreated(ZarenTravelBO.Models.zaren_test.Country item);

        public async Task<ZarenTravelBO.Models.zaren_test.Country> CreateCountry(ZarenTravelBO.Models.zaren_test.Country country)
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

        public async Task<ZarenTravelBO.Models.zaren_test.Country> CancelCountryChanges(ZarenTravelBO.Models.zaren_test.Country item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCountryUpdated(ZarenTravelBO.Models.zaren_test.Country item);
        partial void OnAfterCountryUpdated(ZarenTravelBO.Models.zaren_test.Country item);

        public async Task<ZarenTravelBO.Models.zaren_test.Country> UpdateCountry(int id, ZarenTravelBO.Models.zaren_test.Country country)
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
            country.Agency = null;
            country.Language = null;

            Context.Attach(country).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCountryUpdated(country);

            return country;
        }

        partial void OnCountryDeleted(ZarenTravelBO.Models.zaren_test.Country item);
        partial void OnAfterCountryDeleted(ZarenTravelBO.Models.zaren_test.Country item);

        public async Task<ZarenTravelBO.Models.zaren_test.Country> DeleteCountry(int id)
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
    
        public async Task ExportCountry1SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/country1s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/country1s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCountry1SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/country1s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/country1s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCountry1SRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Country1> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Country1>> GetCountry1S(Query query = null)
        {
            var items = Context.Country1S.AsQueryable();


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

            OnCountry1SRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCountry1Get(ZarenTravelBO.Models.zaren_test.Country1 item);

        public async Task<ZarenTravelBO.Models.zaren_test.Country1> GetCountry1ById(int id)
        {
            var items = Context.Country1S
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCountry1Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCountry1Created(ZarenTravelBO.Models.zaren_test.Country1 item);
        partial void OnAfterCountry1Created(ZarenTravelBO.Models.zaren_test.Country1 item);

        public async Task<ZarenTravelBO.Models.zaren_test.Country1> CreateCountry1(ZarenTravelBO.Models.zaren_test.Country1 country1)
        {
            OnCountry1Created(country1);

            var existingItem = Context.Country1S
                              .Where(i => i.Id == country1.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Country1S.Add(country1);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(country1).State = EntityState.Detached;
                throw;
            }

            OnAfterCountry1Created(country1);

            return country1;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Country1> CancelCountry1Changes(ZarenTravelBO.Models.zaren_test.Country1 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCountry1Updated(ZarenTravelBO.Models.zaren_test.Country1 item);
        partial void OnAfterCountry1Updated(ZarenTravelBO.Models.zaren_test.Country1 item);

        public async Task<ZarenTravelBO.Models.zaren_test.Country1> UpdateCountry1(int id, ZarenTravelBO.Models.zaren_test.Country1 country1)
        {
            OnCountry1Updated(country1);

            var itemToUpdate = Context.Country1S
                              .Where(i => i.Id == country1.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(country1).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCountry1Updated(country1);

            return country1;
        }

        partial void OnCountry1Deleted(ZarenTravelBO.Models.zaren_test.Country1 item);
        partial void OnAfterCountry1Deleted(ZarenTravelBO.Models.zaren_test.Country1 item);

        public async Task<ZarenTravelBO.Models.zaren_test.Country1> DeleteCountry1(int id)
        {
            var itemToDelete = Context.Country1S
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCountry1Deleted(itemToDelete);

            Reset();

            Context.Country1S.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCountry1Deleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCurrenciesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/currencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/currencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCurrenciesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/currencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/currencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCurrenciesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Currency> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Currency>> GetCurrencies(Query query = null)
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

        partial void OnCurrencyGet(ZarenTravelBO.Models.zaren_test.Currency item);

        public async Task<ZarenTravelBO.Models.zaren_test.Currency> GetCurrencyById(int id)
        {
            var items = Context.Currencies
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCurrencyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCurrencyCreated(ZarenTravelBO.Models.zaren_test.Currency item);
        partial void OnAfterCurrencyCreated(ZarenTravelBO.Models.zaren_test.Currency item);

        public async Task<ZarenTravelBO.Models.zaren_test.Currency> CreateCurrency(ZarenTravelBO.Models.zaren_test.Currency currency)
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

        public async Task<ZarenTravelBO.Models.zaren_test.Currency> CancelCurrencyChanges(ZarenTravelBO.Models.zaren_test.Currency item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCurrencyUpdated(ZarenTravelBO.Models.zaren_test.Currency item);
        partial void OnAfterCurrencyUpdated(ZarenTravelBO.Models.zaren_test.Currency item);

        public async Task<ZarenTravelBO.Models.zaren_test.Currency> UpdateCurrency(int id, ZarenTravelBO.Models.zaren_test.Currency currency)
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

        partial void OnCurrencyDeleted(ZarenTravelBO.Models.zaren_test.Currency item);
        partial void OnAfterCurrencyDeleted(ZarenTravelBO.Models.zaren_test.Currency item);

        public async Task<ZarenTravelBO.Models.zaren_test.Currency> DeleteCurrency(int id)
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
    
        public async Task ExportCurrency1SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/currency1s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/currency1s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCurrency1SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/currency1s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/currency1s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCurrency1SRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Currency1> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Currency1>> GetCurrency1S(Query query = null)
        {
            var items = Context.Currency1S.AsQueryable();

            items = items.Include(i => i.Agency);

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

            OnCurrency1SRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCurrency1Get(ZarenTravelBO.Models.zaren_test.Currency1 item);

        public async Task<ZarenTravelBO.Models.zaren_test.Currency1> GetCurrency1ById(int id)
        {
            var items = Context.Currency1S
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
  
            var itemToReturn = items.FirstOrDefault();

            OnCurrency1Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCurrency1Created(ZarenTravelBO.Models.zaren_test.Currency1 item);
        partial void OnAfterCurrency1Created(ZarenTravelBO.Models.zaren_test.Currency1 item);

        public async Task<ZarenTravelBO.Models.zaren_test.Currency1> CreateCurrency1(ZarenTravelBO.Models.zaren_test.Currency1 currency1)
        {
            OnCurrency1Created(currency1);

            var existingItem = Context.Currency1S
                              .Where(i => i.Id == currency1.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Currency1S.Add(currency1);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(currency1).State = EntityState.Detached;
                throw;
            }

            OnAfterCurrency1Created(currency1);

            return currency1;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Currency1> CancelCurrency1Changes(ZarenTravelBO.Models.zaren_test.Currency1 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCurrency1Updated(ZarenTravelBO.Models.zaren_test.Currency1 item);
        partial void OnAfterCurrency1Updated(ZarenTravelBO.Models.zaren_test.Currency1 item);

        public async Task<ZarenTravelBO.Models.zaren_test.Currency1> UpdateCurrency1(int id, ZarenTravelBO.Models.zaren_test.Currency1 currency1)
        {
            OnCurrency1Updated(currency1);

            var itemToUpdate = Context.Currency1S
                              .Where(i => i.Id == currency1.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            currency1.Agency = null;

            Context.Attach(currency1).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCurrency1Updated(currency1);

            return currency1;
        }

        partial void OnCurrency1Deleted(ZarenTravelBO.Models.zaren_test.Currency1 item);
        partial void OnAfterCurrency1Deleted(ZarenTravelBO.Models.zaren_test.Currency1 item);

        public async Task<ZarenTravelBO.Models.zaren_test.Currency1> DeleteCurrency1(int id)
        {
            var itemToDelete = Context.Currency1S
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCurrency1Deleted(itemToDelete);

            Reset();

            Context.Currency1S.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCurrency1Deleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFacilitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/facilities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/facilities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFacilitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/facilities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/facilities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFacilitiesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Facility> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Facility>> GetFacilities(Query query = null)
        {
            var items = Context.Facilities.AsQueryable();


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

            OnFacilitiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFacilityGet(ZarenTravelBO.Models.zaren_test.Facility item);

        public async Task<ZarenTravelBO.Models.zaren_test.Facility> GetFacilityById(int id)
        {
            var items = Context.Facilities
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnFacilityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFacilityCreated(ZarenTravelBO.Models.zaren_test.Facility item);
        partial void OnAfterFacilityCreated(ZarenTravelBO.Models.zaren_test.Facility item);

        public async Task<ZarenTravelBO.Models.zaren_test.Facility> CreateFacility(ZarenTravelBO.Models.zaren_test.Facility facility)
        {
            OnFacilityCreated(facility);

            var existingItem = Context.Facilities
                              .Where(i => i.Id == facility.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Facilities.Add(facility);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(facility).State = EntityState.Detached;
                throw;
            }

            OnAfterFacilityCreated(facility);

            return facility;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Facility> CancelFacilityChanges(ZarenTravelBO.Models.zaren_test.Facility item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFacilityUpdated(ZarenTravelBO.Models.zaren_test.Facility item);
        partial void OnAfterFacilityUpdated(ZarenTravelBO.Models.zaren_test.Facility item);

        public async Task<ZarenTravelBO.Models.zaren_test.Facility> UpdateFacility(int id, ZarenTravelBO.Models.zaren_test.Facility facility)
        {
            OnFacilityUpdated(facility);

            var itemToUpdate = Context.Facilities
                              .Where(i => i.Id == facility.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(facility).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFacilityUpdated(facility);

            return facility;
        }

        partial void OnFacilityDeleted(ZarenTravelBO.Models.zaren_test.Facility item);
        partial void OnAfterFacilityDeleted(ZarenTravelBO.Models.zaren_test.Facility item);

        public async Task<ZarenTravelBO.Models.zaren_test.Facility> DeleteFacility(int id)
        {
            var itemToDelete = Context.Facilities
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFacilityDeleted(itemToDelete);

            Reset();

            Context.Facilities.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFacilityDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFacilitiesSelectedCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/facilitiesselectedcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/facilitiesselectedcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFacilitiesSelectedCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/facilitiesselectedcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/facilitiesselectedcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFacilitiesSelectedCategoriesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory>> GetFacilitiesSelectedCategories(Query query = null)
        {
            var items = Context.FacilitiesSelectedCategories.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);

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

            OnFacilitiesSelectedCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFacilitiesSelectedCategoryGet(ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory> GetFacilitiesSelectedCategoryById(int id)
        {
            var items = Context.FacilitiesSelectedCategories
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnFacilitiesSelectedCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFacilitiesSelectedCategoryCreated(ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory item);
        partial void OnAfterFacilitiesSelectedCategoryCreated(ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory> CreateFacilitiesSelectedCategory(ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory facilitiesselectedcategory)
        {
            OnFacilitiesSelectedCategoryCreated(facilitiesselectedcategory);

            var existingItem = Context.FacilitiesSelectedCategories
                              .Where(i => i.Id == facilitiesselectedcategory.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.FacilitiesSelectedCategories.Add(facilitiesselectedcategory);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(facilitiesselectedcategory).State = EntityState.Detached;
                throw;
            }

            OnAfterFacilitiesSelectedCategoryCreated(facilitiesselectedcategory);

            return facilitiesselectedcategory;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory> CancelFacilitiesSelectedCategoryChanges(ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFacilitiesSelectedCategoryUpdated(ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory item);
        partial void OnAfterFacilitiesSelectedCategoryUpdated(ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory> UpdateFacilitiesSelectedCategory(int id, ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory facilitiesselectedcategory)
        {
            OnFacilitiesSelectedCategoryUpdated(facilitiesselectedcategory);

            var itemToUpdate = Context.FacilitiesSelectedCategories
                              .Where(i => i.Id == facilitiesselectedcategory.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            facilitiesselectedcategory.Agency = null;
            facilitiesselectedcategory.Language = null;

            Context.Attach(facilitiesselectedcategory).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFacilitiesSelectedCategoryUpdated(facilitiesselectedcategory);

            return facilitiesselectedcategory;
        }

        partial void OnFacilitiesSelectedCategoryDeleted(ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory item);
        partial void OnAfterFacilitiesSelectedCategoryDeleted(ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.FacilitiesSelectedCategory> DeleteFacilitiesSelectedCategory(int id)
        {
            var itemToDelete = Context.FacilitiesSelectedCategories
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFacilitiesSelectedCategoryDeleted(itemToDelete);

            Reset();

            Context.FacilitiesSelectedCategories.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFacilitiesSelectedCategoryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFacilityCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/facilitycategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/facilitycategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFacilityCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/facilitycategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/facilitycategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFacilityCategoriesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.FacilityCategory> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.FacilityCategory>> GetFacilityCategories(Query query = null)
        {
            var items = Context.FacilityCategories.AsQueryable();


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

            OnFacilityCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFacilityCategoryGet(ZarenTravelBO.Models.zaren_test.FacilityCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.FacilityCategory> GetFacilityCategoryById(int id)
        {
            var items = Context.FacilityCategories
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnFacilityCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFacilityCategoryCreated(ZarenTravelBO.Models.zaren_test.FacilityCategory item);
        partial void OnAfterFacilityCategoryCreated(ZarenTravelBO.Models.zaren_test.FacilityCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.FacilityCategory> CreateFacilityCategory(ZarenTravelBO.Models.zaren_test.FacilityCategory facilitycategory)
        {
            OnFacilityCategoryCreated(facilitycategory);

            var existingItem = Context.FacilityCategories
                              .Where(i => i.Id == facilitycategory.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.FacilityCategories.Add(facilitycategory);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(facilitycategory).State = EntityState.Detached;
                throw;
            }

            OnAfterFacilityCategoryCreated(facilitycategory);

            return facilitycategory;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.FacilityCategory> CancelFacilityCategoryChanges(ZarenTravelBO.Models.zaren_test.FacilityCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFacilityCategoryUpdated(ZarenTravelBO.Models.zaren_test.FacilityCategory item);
        partial void OnAfterFacilityCategoryUpdated(ZarenTravelBO.Models.zaren_test.FacilityCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.FacilityCategory> UpdateFacilityCategory(int id, ZarenTravelBO.Models.zaren_test.FacilityCategory facilitycategory)
        {
            OnFacilityCategoryUpdated(facilitycategory);

            var itemToUpdate = Context.FacilityCategories
                              .Where(i => i.Id == facilitycategory.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(facilitycategory).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFacilityCategoryUpdated(facilitycategory);

            return facilitycategory;
        }

        partial void OnFacilityCategoryDeleted(ZarenTravelBO.Models.zaren_test.FacilityCategory item);
        partial void OnAfterFacilityCategoryDeleted(ZarenTravelBO.Models.zaren_test.FacilityCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.FacilityCategory> DeleteFacilityCategory(int id)
        {
            var itemToDelete = Context.FacilityCategories
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFacilityCategoryDeleted(itemToDelete);

            Reset();

            Context.FacilityCategories.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFacilityCategoryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportGeolocationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/geolocations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/geolocations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportGeolocationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/geolocations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/geolocations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGeolocationsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Geolocation> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Geolocation>> GetGeolocations(Query query = null)
        {
            var items = Context.Geolocations.AsQueryable();


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

            OnGeolocationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnGeolocationGet(ZarenTravelBO.Models.zaren_test.Geolocation item);

        public async Task<ZarenTravelBO.Models.zaren_test.Geolocation> GetGeolocationById(int id)
        {
            var items = Context.Geolocations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnGeolocationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnGeolocationCreated(ZarenTravelBO.Models.zaren_test.Geolocation item);
        partial void OnAfterGeolocationCreated(ZarenTravelBO.Models.zaren_test.Geolocation item);

        public async Task<ZarenTravelBO.Models.zaren_test.Geolocation> CreateGeolocation(ZarenTravelBO.Models.zaren_test.Geolocation geolocation)
        {
            OnGeolocationCreated(geolocation);

            var existingItem = Context.Geolocations
                              .Where(i => i.Id == geolocation.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Geolocations.Add(geolocation);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(geolocation).State = EntityState.Detached;
                throw;
            }

            OnAfterGeolocationCreated(geolocation);

            return geolocation;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Geolocation> CancelGeolocationChanges(ZarenTravelBO.Models.zaren_test.Geolocation item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnGeolocationUpdated(ZarenTravelBO.Models.zaren_test.Geolocation item);
        partial void OnAfterGeolocationUpdated(ZarenTravelBO.Models.zaren_test.Geolocation item);

        public async Task<ZarenTravelBO.Models.zaren_test.Geolocation> UpdateGeolocation(int id, ZarenTravelBO.Models.zaren_test.Geolocation geolocation)
        {
            OnGeolocationUpdated(geolocation);

            var itemToUpdate = Context.Geolocations
                              .Where(i => i.Id == geolocation.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(geolocation).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterGeolocationUpdated(geolocation);

            return geolocation;
        }

        partial void OnGeolocationDeleted(ZarenTravelBO.Models.zaren_test.Geolocation item);
        partial void OnAfterGeolocationDeleted(ZarenTravelBO.Models.zaren_test.Geolocation item);

        public async Task<ZarenTravelBO.Models.zaren_test.Geolocation> DeleteGeolocation(int id)
        {
            var itemToDelete = Context.Geolocations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnGeolocationDeleted(itemToDelete);

            Reset();

            Context.Geolocations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterGeolocationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportGiataInfosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/giatainfos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/giatainfos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportGiataInfosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/giatainfos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/giatainfos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGiataInfosRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.GiataInfo> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.GiataInfo>> GetGiataInfos(Query query = null)
        {
            var items = Context.GiataInfos.AsQueryable();


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

            OnGiataInfosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnGiataInfoGet(ZarenTravelBO.Models.zaren_test.GiataInfo item);

        public async Task<ZarenTravelBO.Models.zaren_test.GiataInfo> GetGiataInfoById(int id)
        {
            var items = Context.GiataInfos
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnGiataInfoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnGiataInfoCreated(ZarenTravelBO.Models.zaren_test.GiataInfo item);
        partial void OnAfterGiataInfoCreated(ZarenTravelBO.Models.zaren_test.GiataInfo item);

        public async Task<ZarenTravelBO.Models.zaren_test.GiataInfo> CreateGiataInfo(ZarenTravelBO.Models.zaren_test.GiataInfo giatainfo)
        {
            OnGiataInfoCreated(giatainfo);

            var existingItem = Context.GiataInfos
                              .Where(i => i.Id == giatainfo.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.GiataInfos.Add(giatainfo);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(giatainfo).State = EntityState.Detached;
                throw;
            }

            OnAfterGiataInfoCreated(giatainfo);

            return giatainfo;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.GiataInfo> CancelGiataInfoChanges(ZarenTravelBO.Models.zaren_test.GiataInfo item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnGiataInfoUpdated(ZarenTravelBO.Models.zaren_test.GiataInfo item);
        partial void OnAfterGiataInfoUpdated(ZarenTravelBO.Models.zaren_test.GiataInfo item);

        public async Task<ZarenTravelBO.Models.zaren_test.GiataInfo> UpdateGiataInfo(int id, ZarenTravelBO.Models.zaren_test.GiataInfo giatainfo)
        {
            OnGiataInfoUpdated(giatainfo);

            var itemToUpdate = Context.GiataInfos
                              .Where(i => i.Id == giatainfo.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(giatainfo).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterGiataInfoUpdated(giatainfo);

            return giatainfo;
        }

        partial void OnGiataInfoDeleted(ZarenTravelBO.Models.zaren_test.GiataInfo item);
        partial void OnAfterGiataInfoDeleted(ZarenTravelBO.Models.zaren_test.GiataInfo item);

        public async Task<ZarenTravelBO.Models.zaren_test.GiataInfo> DeleteGiataInfo(int id)
        {
            var itemToDelete = Context.GiataInfos
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnGiataInfoDeleted(itemToDelete);

            Reset();

            Context.GiataInfos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterGiataInfoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelBoardsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/hotelboards/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/hotelboards/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelBoardsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/hotelboards/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/hotelboards/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelBoardsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.HotelBoard> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.HotelBoard>> GetHotelBoards(Query query = null)
        {
            var items = Context.HotelBoards.AsQueryable();


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

            OnHotelBoardsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelBoardGet(ZarenTravelBO.Models.zaren_test.HotelBoard item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelBoard> GetHotelBoardById(int id)
        {
            var items = Context.HotelBoards
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelBoardGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelBoardCreated(ZarenTravelBO.Models.zaren_test.HotelBoard item);
        partial void OnAfterHotelBoardCreated(ZarenTravelBO.Models.zaren_test.HotelBoard item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelBoard> CreateHotelBoard(ZarenTravelBO.Models.zaren_test.HotelBoard hotelboard)
        {
            OnHotelBoardCreated(hotelboard);

            var existingItem = Context.HotelBoards
                              .Where(i => i.Id == hotelboard.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelBoards.Add(hotelboard);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelboard).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelBoardCreated(hotelboard);

            return hotelboard;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.HotelBoard> CancelHotelBoardChanges(ZarenTravelBO.Models.zaren_test.HotelBoard item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelBoardUpdated(ZarenTravelBO.Models.zaren_test.HotelBoard item);
        partial void OnAfterHotelBoardUpdated(ZarenTravelBO.Models.zaren_test.HotelBoard item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelBoard> UpdateHotelBoard(int id, ZarenTravelBO.Models.zaren_test.HotelBoard hotelboard)
        {
            OnHotelBoardUpdated(hotelboard);

            var itemToUpdate = Context.HotelBoards
                              .Where(i => i.Id == hotelboard.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(hotelboard).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelBoardUpdated(hotelboard);

            return hotelboard;
        }

        partial void OnHotelBoardDeleted(ZarenTravelBO.Models.zaren_test.HotelBoard item);
        partial void OnAfterHotelBoardDeleted(ZarenTravelBO.Models.zaren_test.HotelBoard item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelBoard> DeleteHotelBoard(int id)
        {
            var itemToDelete = Context.HotelBoards
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelBoardDeleted(itemToDelete);

            Reset();

            Context.HotelBoards.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelBoardDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/hotelcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/hotelcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/hotelcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/hotelcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelCategoriesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.HotelCategory> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.HotelCategory>> GetHotelCategories(Query query = null)
        {
            var items = Context.HotelCategories.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);

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

        partial void OnHotelCategoryGet(ZarenTravelBO.Models.zaren_test.HotelCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelCategory> GetHotelCategoryById(int id)
        {
            var items = Context.HotelCategories
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelCategoryCreated(ZarenTravelBO.Models.zaren_test.HotelCategory item);
        partial void OnAfterHotelCategoryCreated(ZarenTravelBO.Models.zaren_test.HotelCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelCategory> CreateHotelCategory(ZarenTravelBO.Models.zaren_test.HotelCategory hotelcategory)
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

        public async Task<ZarenTravelBO.Models.zaren_test.HotelCategory> CancelHotelCategoryChanges(ZarenTravelBO.Models.zaren_test.HotelCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelCategoryUpdated(ZarenTravelBO.Models.zaren_test.HotelCategory item);
        partial void OnAfterHotelCategoryUpdated(ZarenTravelBO.Models.zaren_test.HotelCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelCategory> UpdateHotelCategory(int id, ZarenTravelBO.Models.zaren_test.HotelCategory hotelcategory)
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
            hotelcategory.Agency = null;
            hotelcategory.Language = null;

            Context.Attach(hotelcategory).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelCategoryUpdated(hotelcategory);

            return hotelcategory;
        }

        partial void OnHotelCategoryDeleted(ZarenTravelBO.Models.zaren_test.HotelCategory item);
        partial void OnAfterHotelCategoryDeleted(ZarenTravelBO.Models.zaren_test.HotelCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelCategory> DeleteHotelCategory(int id)
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
    
        public async Task ExportHotelOffersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/hoteloffers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/hoteloffers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelOffersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/hoteloffers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/hoteloffers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelOffersRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.HotelOffer> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.HotelOffer>> GetHotelOffers(Query query = null)
        {
            var items = Context.HotelOffers.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);

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

            OnHotelOffersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelOfferGet(ZarenTravelBO.Models.zaren_test.HotelOffer item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelOffer> GetHotelOfferById(int id)
        {
            var items = Context.HotelOffers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelOfferGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelOfferCreated(ZarenTravelBO.Models.zaren_test.HotelOffer item);
        partial void OnAfterHotelOfferCreated(ZarenTravelBO.Models.zaren_test.HotelOffer item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelOffer> CreateHotelOffer(ZarenTravelBO.Models.zaren_test.HotelOffer hoteloffer)
        {
            OnHotelOfferCreated(hoteloffer);

            var existingItem = Context.HotelOffers
                              .Where(i => i.Id == hoteloffer.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelOffers.Add(hoteloffer);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hoteloffer).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelOfferCreated(hoteloffer);

            return hoteloffer;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.HotelOffer> CancelHotelOfferChanges(ZarenTravelBO.Models.zaren_test.HotelOffer item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelOfferUpdated(ZarenTravelBO.Models.zaren_test.HotelOffer item);
        partial void OnAfterHotelOfferUpdated(ZarenTravelBO.Models.zaren_test.HotelOffer item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelOffer> UpdateHotelOffer(int id, ZarenTravelBO.Models.zaren_test.HotelOffer hoteloffer)
        {
            OnHotelOfferUpdated(hoteloffer);

            var itemToUpdate = Context.HotelOffers
                              .Where(i => i.Id == hoteloffer.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            hoteloffer.Agency = null;
            hoteloffer.Language = null;

            Context.Attach(hoteloffer).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelOfferUpdated(hoteloffer);

            return hoteloffer;
        }

        partial void OnHotelOfferDeleted(ZarenTravelBO.Models.zaren_test.HotelOffer item);
        partial void OnAfterHotelOfferDeleted(ZarenTravelBO.Models.zaren_test.HotelOffer item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelOffer> DeleteHotelOffer(int id)
        {
            var itemToDelete = Context.HotelOffers
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelOfferDeleted(itemToDelete);

            Reset();

            Context.HotelOffers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelOfferDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelPaymentPlansToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/hotelpaymentplans/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/hotelpaymentplans/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelPaymentPlansToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/hotelpaymentplans/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/hotelpaymentplans/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelPaymentPlansRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.HotelPaymentPlan> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.HotelPaymentPlan>> GetHotelPaymentPlans(Query query = null)
        {
            var items = Context.HotelPaymentPlans.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);

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

            OnHotelPaymentPlansRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelPaymentPlanGet(ZarenTravelBO.Models.zaren_test.HotelPaymentPlan item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelPaymentPlan> GetHotelPaymentPlanById(int id)
        {
            var items = Context.HotelPaymentPlans
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelPaymentPlanGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelPaymentPlanCreated(ZarenTravelBO.Models.zaren_test.HotelPaymentPlan item);
        partial void OnAfterHotelPaymentPlanCreated(ZarenTravelBO.Models.zaren_test.HotelPaymentPlan item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelPaymentPlan> CreateHotelPaymentPlan(ZarenTravelBO.Models.zaren_test.HotelPaymentPlan hotelpaymentplan)
        {
            OnHotelPaymentPlanCreated(hotelpaymentplan);

            var existingItem = Context.HotelPaymentPlans
                              .Where(i => i.Id == hotelpaymentplan.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelPaymentPlans.Add(hotelpaymentplan);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelpaymentplan).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelPaymentPlanCreated(hotelpaymentplan);

            return hotelpaymentplan;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.HotelPaymentPlan> CancelHotelPaymentPlanChanges(ZarenTravelBO.Models.zaren_test.HotelPaymentPlan item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelPaymentPlanUpdated(ZarenTravelBO.Models.zaren_test.HotelPaymentPlan item);
        partial void OnAfterHotelPaymentPlanUpdated(ZarenTravelBO.Models.zaren_test.HotelPaymentPlan item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelPaymentPlan> UpdateHotelPaymentPlan(int id, ZarenTravelBO.Models.zaren_test.HotelPaymentPlan hotelpaymentplan)
        {
            OnHotelPaymentPlanUpdated(hotelpaymentplan);

            var itemToUpdate = Context.HotelPaymentPlans
                              .Where(i => i.Id == hotelpaymentplan.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            hotelpaymentplan.Agency = null;
            hotelpaymentplan.Language = null;

            Context.Attach(hotelpaymentplan).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelPaymentPlanUpdated(hotelpaymentplan);

            return hotelpaymentplan;
        }

        partial void OnHotelPaymentPlanDeleted(ZarenTravelBO.Models.zaren_test.HotelPaymentPlan item);
        partial void OnAfterHotelPaymentPlanDeleted(ZarenTravelBO.Models.zaren_test.HotelPaymentPlan item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelPaymentPlan> DeleteHotelPaymentPlan(int id)
        {
            var itemToDelete = Context.HotelPaymentPlans
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelPaymentPlanDeleted(itemToDelete);

            Reset();

            Context.HotelPaymentPlans.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelPaymentPlanDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/hotels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/hotels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/hotels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/hotels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Hotel> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Hotel>> GetHotels(Query query = null)
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

        partial void OnHotelGet(ZarenTravelBO.Models.zaren_test.Hotel item);

        public async Task<ZarenTravelBO.Models.zaren_test.Hotel> GetHotelById(int id)
        {
            var items = Context.Hotels
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelCreated(ZarenTravelBO.Models.zaren_test.Hotel item);
        partial void OnAfterHotelCreated(ZarenTravelBO.Models.zaren_test.Hotel item);

        public async Task<ZarenTravelBO.Models.zaren_test.Hotel> CreateHotel(ZarenTravelBO.Models.zaren_test.Hotel hotel)
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

        public async Task<ZarenTravelBO.Models.zaren_test.Hotel> CancelHotelChanges(ZarenTravelBO.Models.zaren_test.Hotel item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelUpdated(ZarenTravelBO.Models.zaren_test.Hotel item);
        partial void OnAfterHotelUpdated(ZarenTravelBO.Models.zaren_test.Hotel item);

        public async Task<ZarenTravelBO.Models.zaren_test.Hotel> UpdateHotel(int id, ZarenTravelBO.Models.zaren_test.Hotel hotel)
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

            Context.Attach(hotel).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelUpdated(hotel);

            return hotel;
        }

        partial void OnHotelDeleted(ZarenTravelBO.Models.zaren_test.Hotel item);
        partial void OnAfterHotelDeleted(ZarenTravelBO.Models.zaren_test.Hotel item);

        public async Task<ZarenTravelBO.Models.zaren_test.Hotel> DeleteHotel(int id)
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
    
        public async Task ExportHotelSeasonsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/hotelseasons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/hotelseasons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelSeasonsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/hotelseasons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/hotelseasons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelSeasonsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.HotelSeason> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.HotelSeason>> GetHotelSeasons(Query query = null)
        {
            var items = Context.HotelSeasons.AsQueryable();


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

            OnHotelSeasonsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelSeasonGet(ZarenTravelBO.Models.zaren_test.HotelSeason item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelSeason> GetHotelSeasonById(int id)
        {
            var items = Context.HotelSeasons
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelSeasonGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelSeasonCreated(ZarenTravelBO.Models.zaren_test.HotelSeason item);
        partial void OnAfterHotelSeasonCreated(ZarenTravelBO.Models.zaren_test.HotelSeason item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelSeason> CreateHotelSeason(ZarenTravelBO.Models.zaren_test.HotelSeason hotelseason)
        {
            OnHotelSeasonCreated(hotelseason);

            var existingItem = Context.HotelSeasons
                              .Where(i => i.Id == hotelseason.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelSeasons.Add(hotelseason);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelseason).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelSeasonCreated(hotelseason);

            return hotelseason;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.HotelSeason> CancelHotelSeasonChanges(ZarenTravelBO.Models.zaren_test.HotelSeason item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelSeasonUpdated(ZarenTravelBO.Models.zaren_test.HotelSeason item);
        partial void OnAfterHotelSeasonUpdated(ZarenTravelBO.Models.zaren_test.HotelSeason item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelSeason> UpdateHotelSeason(int id, ZarenTravelBO.Models.zaren_test.HotelSeason hotelseason)
        {
            OnHotelSeasonUpdated(hotelseason);

            var itemToUpdate = Context.HotelSeasons
                              .Where(i => i.Id == hotelseason.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(hotelseason).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelSeasonUpdated(hotelseason);

            return hotelseason;
        }

        partial void OnHotelSeasonDeleted(ZarenTravelBO.Models.zaren_test.HotelSeason item);
        partial void OnAfterHotelSeasonDeleted(ZarenTravelBO.Models.zaren_test.HotelSeason item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelSeason> DeleteHotelSeason(int id)
        {
            var itemToDelete = Context.HotelSeasons
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelSeasonDeleted(itemToDelete);

            Reset();

            Context.HotelSeasons.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelSeasonDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelSelectedSeasonsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/hotelselectedseasons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/hotelselectedseasons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelSelectedSeasonsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/hotelselectedseasons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/hotelselectedseasons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelSelectedSeasonsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.HotelSelectedSeason> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.HotelSelectedSeason>> GetHotelSelectedSeasons(Query query = null)
        {
            var items = Context.HotelSelectedSeasons.AsQueryable();


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

            OnHotelSelectedSeasonsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelSelectedSeasonGet(ZarenTravelBO.Models.zaren_test.HotelSelectedSeason item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelSelectedSeason> GetHotelSelectedSeasonById(int id)
        {
            var items = Context.HotelSelectedSeasons
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelSelectedSeasonGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelSelectedSeasonCreated(ZarenTravelBO.Models.zaren_test.HotelSelectedSeason item);
        partial void OnAfterHotelSelectedSeasonCreated(ZarenTravelBO.Models.zaren_test.HotelSelectedSeason item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelSelectedSeason> CreateHotelSelectedSeason(ZarenTravelBO.Models.zaren_test.HotelSelectedSeason hotelselectedseason)
        {
            OnHotelSelectedSeasonCreated(hotelselectedseason);

            var existingItem = Context.HotelSelectedSeasons
                              .Where(i => i.Id == hotelselectedseason.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelSelectedSeasons.Add(hotelselectedseason);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelselectedseason).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelSelectedSeasonCreated(hotelselectedseason);

            return hotelselectedseason;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.HotelSelectedSeason> CancelHotelSelectedSeasonChanges(ZarenTravelBO.Models.zaren_test.HotelSelectedSeason item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelSelectedSeasonUpdated(ZarenTravelBO.Models.zaren_test.HotelSelectedSeason item);
        partial void OnAfterHotelSelectedSeasonUpdated(ZarenTravelBO.Models.zaren_test.HotelSelectedSeason item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelSelectedSeason> UpdateHotelSelectedSeason(int id, ZarenTravelBO.Models.zaren_test.HotelSelectedSeason hotelselectedseason)
        {
            OnHotelSelectedSeasonUpdated(hotelselectedseason);

            var itemToUpdate = Context.HotelSelectedSeasons
                              .Where(i => i.Id == hotelselectedseason.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(hotelselectedseason).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelSelectedSeasonUpdated(hotelselectedseason);

            return hotelselectedseason;
        }

        partial void OnHotelSelectedSeasonDeleted(ZarenTravelBO.Models.zaren_test.HotelSelectedSeason item);
        partial void OnAfterHotelSelectedSeasonDeleted(ZarenTravelBO.Models.zaren_test.HotelSelectedSeason item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelSelectedSeason> DeleteHotelSelectedSeason(int id)
        {
            var itemToDelete = Context.HotelSelectedSeasons
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelSelectedSeasonDeleted(itemToDelete);

            Reset();

            Context.HotelSelectedSeasons.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelSelectedSeasonDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelThemesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/hotelthemes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/hotelthemes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelThemesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/hotelthemes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/hotelthemes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelThemesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.HotelTheme> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.HotelTheme>> GetHotelThemes(Query query = null)
        {
            var items = Context.HotelThemes.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);
            items = items.Include(i => i.Theme);

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

            OnHotelThemesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelThemeGet(ZarenTravelBO.Models.zaren_test.HotelTheme item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelTheme> GetHotelThemeById(int id)
        {
            var items = Context.HotelThemes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);
            items = items.Include(i => i.Theme);
  
            var itemToReturn = items.FirstOrDefault();

            OnHotelThemeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelThemeCreated(ZarenTravelBO.Models.zaren_test.HotelTheme item);
        partial void OnAfterHotelThemeCreated(ZarenTravelBO.Models.zaren_test.HotelTheme item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelTheme> CreateHotelTheme(ZarenTravelBO.Models.zaren_test.HotelTheme hoteltheme)
        {
            OnHotelThemeCreated(hoteltheme);

            var existingItem = Context.HotelThemes
                              .Where(i => i.Id == hoteltheme.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelThemes.Add(hoteltheme);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hoteltheme).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelThemeCreated(hoteltheme);

            return hoteltheme;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.HotelTheme> CancelHotelThemeChanges(ZarenTravelBO.Models.zaren_test.HotelTheme item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelThemeUpdated(ZarenTravelBO.Models.zaren_test.HotelTheme item);
        partial void OnAfterHotelThemeUpdated(ZarenTravelBO.Models.zaren_test.HotelTheme item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelTheme> UpdateHotelTheme(int id, ZarenTravelBO.Models.zaren_test.HotelTheme hoteltheme)
        {
            OnHotelThemeUpdated(hoteltheme);

            var itemToUpdate = Context.HotelThemes
                              .Where(i => i.Id == hoteltheme.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            hoteltheme.Agency = null;
            hoteltheme.Language = null;
            hoteltheme.Theme = null;

            Context.Attach(hoteltheme).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelThemeUpdated(hoteltheme);

            return hoteltheme;
        }

        partial void OnHotelThemeDeleted(ZarenTravelBO.Models.zaren_test.HotelTheme item);
        partial void OnAfterHotelThemeDeleted(ZarenTravelBO.Models.zaren_test.HotelTheme item);

        public async Task<ZarenTravelBO.Models.zaren_test.HotelTheme> DeleteHotelTheme(int id)
        {
            var itemToDelete = Context.HotelThemes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelThemeDeleted(itemToDelete);

            Reset();

            Context.HotelThemes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelThemeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportInformationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/informations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/informations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInformationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/informations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/informations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInformationsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Information> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Information>> GetInformations(Query query = null)
        {
            var items = Context.Informations.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);

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

            OnInformationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnInformationGet(ZarenTravelBO.Models.zaren_test.Information item);

        public async Task<ZarenTravelBO.Models.zaren_test.Information> GetInformationById(int id)
        {
            var items = Context.Informations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnInformationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnInformationCreated(ZarenTravelBO.Models.zaren_test.Information item);
        partial void OnAfterInformationCreated(ZarenTravelBO.Models.zaren_test.Information item);

        public async Task<ZarenTravelBO.Models.zaren_test.Information> CreateInformation(ZarenTravelBO.Models.zaren_test.Information information)
        {
            OnInformationCreated(information);

            var existingItem = Context.Informations
                              .Where(i => i.Id == information.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Informations.Add(information);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(information).State = EntityState.Detached;
                throw;
            }

            OnAfterInformationCreated(information);

            return information;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Information> CancelInformationChanges(ZarenTravelBO.Models.zaren_test.Information item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnInformationUpdated(ZarenTravelBO.Models.zaren_test.Information item);
        partial void OnAfterInformationUpdated(ZarenTravelBO.Models.zaren_test.Information item);

        public async Task<ZarenTravelBO.Models.zaren_test.Information> UpdateInformation(int id, ZarenTravelBO.Models.zaren_test.Information information)
        {
            OnInformationUpdated(information);

            var itemToUpdate = Context.Informations
                              .Where(i => i.Id == information.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            information.Agency = null;
            information.Language = null;

            Context.Attach(information).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterInformationUpdated(information);

            return information;
        }

        partial void OnInformationDeleted(ZarenTravelBO.Models.zaren_test.Information item);
        partial void OnAfterInformationDeleted(ZarenTravelBO.Models.zaren_test.Information item);

        public async Task<ZarenTravelBO.Models.zaren_test.Information> DeleteInformation(int id)
        {
            var itemToDelete = Context.Informations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnInformationDeleted(itemToDelete);

            Reset();

            Context.Informations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterInformationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportItemsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/items/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/items/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportItemsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/items/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/items/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnItemsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Item> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Item>> GetItems(Query query = null)
        {
            var items = Context.Items.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.City);
            items = items.Include(i => i.Country);
            items = items.Include(i => i.Language);

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

            OnItemsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnItemGet(ZarenTravelBO.Models.zaren_test.Item item);

        public async Task<ZarenTravelBO.Models.zaren_test.Item> GetItemById(int id)
        {
            var items = Context.Items
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.City);
            items = items.Include(i => i.Country);
            items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnItemGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnItemCreated(ZarenTravelBO.Models.zaren_test.Item item);
        partial void OnAfterItemCreated(ZarenTravelBO.Models.zaren_test.Item item);

        public async Task<ZarenTravelBO.Models.zaren_test.Item> CreateItem(ZarenTravelBO.Models.zaren_test.Item item)
        {
            OnItemCreated(item);

            var existingItem = Context.Items
                              .Where(i => i.Id == item.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Items.Add(item);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(item).State = EntityState.Detached;
                throw;
            }

            OnAfterItemCreated(item);

            return item;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Item> CancelItemChanges(ZarenTravelBO.Models.zaren_test.Item item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnItemUpdated(ZarenTravelBO.Models.zaren_test.Item item);
        partial void OnAfterItemUpdated(ZarenTravelBO.Models.zaren_test.Item item);

        public async Task<ZarenTravelBO.Models.zaren_test.Item> UpdateItem(int id, ZarenTravelBO.Models.zaren_test.Item item)
        {
            OnItemUpdated(item);

            var itemToUpdate = Context.Items
                              .Where(i => i.Id == item.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            item.Agency = null;
            item.City = null;
            item.Country = null;
            item.Language = null;

            Context.Attach(item).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterItemUpdated(item);

            return item;
        }

        partial void OnItemDeleted(ZarenTravelBO.Models.zaren_test.Item item);
        partial void OnAfterItemDeleted(ZarenTravelBO.Models.zaren_test.Item item);

        public async Task<ZarenTravelBO.Models.zaren_test.Item> DeleteItem(int id)
        {
            var itemToDelete = Context.Items
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnItemDeleted(itemToDelete);

            Reset();

            Context.Items.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterItemDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/languages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/languages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/languages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/languages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLanguagesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Language> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Language>> GetLanguages(Query query = null)
        {
            var items = Context.Languages.AsQueryable();

            items = items.Include(i => i.Agency);

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

        partial void OnLanguageGet(ZarenTravelBO.Models.zaren_test.Language item);

        public async Task<ZarenTravelBO.Models.zaren_test.Language> GetLanguageById(int id)
        {
            var items = Context.Languages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
  
            var itemToReturn = items.FirstOrDefault();

            OnLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnLanguageCreated(ZarenTravelBO.Models.zaren_test.Language item);
        partial void OnAfterLanguageCreated(ZarenTravelBO.Models.zaren_test.Language item);

        public async Task<ZarenTravelBO.Models.zaren_test.Language> CreateLanguage(ZarenTravelBO.Models.zaren_test.Language language)
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

        public async Task<ZarenTravelBO.Models.zaren_test.Language> CancelLanguageChanges(ZarenTravelBO.Models.zaren_test.Language item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLanguageUpdated(ZarenTravelBO.Models.zaren_test.Language item);
        partial void OnAfterLanguageUpdated(ZarenTravelBO.Models.zaren_test.Language item);

        public async Task<ZarenTravelBO.Models.zaren_test.Language> UpdateLanguage(int id, ZarenTravelBO.Models.zaren_test.Language language)
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
            language.Agency = null;

            Context.Attach(language).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterLanguageUpdated(language);

            return language;
        }

        partial void OnLanguageDeleted(ZarenTravelBO.Models.zaren_test.Language item);
        partial void OnAfterLanguageDeleted(ZarenTravelBO.Models.zaren_test.Language item);

        public async Task<ZarenTravelBO.Models.zaren_test.Language> DeleteLanguage(int id)
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
    
        public async Task ExportLimitTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/limittypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/limittypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLimitTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/limittypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/limittypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLimitTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.LimitType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.LimitType>> GetLimitTypes(Query query = null)
        {
            var items = Context.LimitTypes.AsQueryable();


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

            OnLimitTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLimitTypeGet(ZarenTravelBO.Models.zaren_test.LimitType item);

        public async Task<ZarenTravelBO.Models.zaren_test.LimitType> GetLimitTypeById(int id)
        {
            var items = Context.LimitTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnLimitTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnLimitTypeCreated(ZarenTravelBO.Models.zaren_test.LimitType item);
        partial void OnAfterLimitTypeCreated(ZarenTravelBO.Models.zaren_test.LimitType item);

        public async Task<ZarenTravelBO.Models.zaren_test.LimitType> CreateLimitType(ZarenTravelBO.Models.zaren_test.LimitType limittype)
        {
            OnLimitTypeCreated(limittype);

            var existingItem = Context.LimitTypes
                              .Where(i => i.Id == limittype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.LimitTypes.Add(limittype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(limittype).State = EntityState.Detached;
                throw;
            }

            OnAfterLimitTypeCreated(limittype);

            return limittype;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.LimitType> CancelLimitTypeChanges(ZarenTravelBO.Models.zaren_test.LimitType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLimitTypeUpdated(ZarenTravelBO.Models.zaren_test.LimitType item);
        partial void OnAfterLimitTypeUpdated(ZarenTravelBO.Models.zaren_test.LimitType item);

        public async Task<ZarenTravelBO.Models.zaren_test.LimitType> UpdateLimitType(int id, ZarenTravelBO.Models.zaren_test.LimitType limittype)
        {
            OnLimitTypeUpdated(limittype);

            var itemToUpdate = Context.LimitTypes
                              .Where(i => i.Id == limittype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(limittype).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterLimitTypeUpdated(limittype);

            return limittype;
        }

        partial void OnLimitTypeDeleted(ZarenTravelBO.Models.zaren_test.LimitType item);
        partial void OnAfterLimitTypeDeleted(ZarenTravelBO.Models.zaren_test.LimitType item);

        public async Task<ZarenTravelBO.Models.zaren_test.LimitType> DeleteLimitType(int id)
        {
            var itemToDelete = Context.LimitTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLimitTypeDeleted(itemToDelete);

            Reset();

            Context.LimitTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterLimitTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportMediaFilesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/mediafiles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/mediafiles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMediaFilesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/mediafiles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/mediafiles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMediaFilesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.MediaFile> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.MediaFile>> GetMediaFiles(Query query = null)
        {
            var items = Context.MediaFiles.AsQueryable();


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

            OnMediaFilesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnMediaFileGet(ZarenTravelBO.Models.zaren_test.MediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_test.MediaFile> GetMediaFileById(int id)
        {
            var items = Context.MediaFiles
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnMediaFileGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnMediaFileCreated(ZarenTravelBO.Models.zaren_test.MediaFile item);
        partial void OnAfterMediaFileCreated(ZarenTravelBO.Models.zaren_test.MediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_test.MediaFile> CreateMediaFile(ZarenTravelBO.Models.zaren_test.MediaFile mediafile)
        {
            OnMediaFileCreated(mediafile);

            var existingItem = Context.MediaFiles
                              .Where(i => i.Id == mediafile.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.MediaFiles.Add(mediafile);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(mediafile).State = EntityState.Detached;
                throw;
            }

            OnAfterMediaFileCreated(mediafile);

            return mediafile;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.MediaFile> CancelMediaFileChanges(ZarenTravelBO.Models.zaren_test.MediaFile item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnMediaFileUpdated(ZarenTravelBO.Models.zaren_test.MediaFile item);
        partial void OnAfterMediaFileUpdated(ZarenTravelBO.Models.zaren_test.MediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_test.MediaFile> UpdateMediaFile(int id, ZarenTravelBO.Models.zaren_test.MediaFile mediafile)
        {
            OnMediaFileUpdated(mediafile);

            var itemToUpdate = Context.MediaFiles
                              .Where(i => i.Id == mediafile.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(mediafile).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterMediaFileUpdated(mediafile);

            return mediafile;
        }

        partial void OnMediaFileDeleted(ZarenTravelBO.Models.zaren_test.MediaFile item);
        partial void OnAfterMediaFileDeleted(ZarenTravelBO.Models.zaren_test.MediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_test.MediaFile> DeleteMediaFile(int id)
        {
            var itemToDelete = Context.MediaFiles
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnMediaFileDeleted(itemToDelete);

            Reset();

            Context.MediaFiles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterMediaFileDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportOfferCancellationPoliciesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/offercancellationpolicies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/offercancellationpolicies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOfferCancellationPoliciesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/offercancellationpolicies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/offercancellationpolicies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOfferCancellationPoliciesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy>> GetOfferCancellationPolicies(Query query = null)
        {
            var items = Context.OfferCancellationPolicies.AsQueryable();


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

            OnOfferCancellationPoliciesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnOfferCancellationPolicyGet(ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy item);

        public async Task<ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy> GetOfferCancellationPolicyById(int id)
        {
            var items = Context.OfferCancellationPolicies
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnOfferCancellationPolicyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnOfferCancellationPolicyCreated(ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy item);
        partial void OnAfterOfferCancellationPolicyCreated(ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy item);

        public async Task<ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy> CreateOfferCancellationPolicy(ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy offercancellationpolicy)
        {
            OnOfferCancellationPolicyCreated(offercancellationpolicy);

            var existingItem = Context.OfferCancellationPolicies
                              .Where(i => i.Id == offercancellationpolicy.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.OfferCancellationPolicies.Add(offercancellationpolicy);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(offercancellationpolicy).State = EntityState.Detached;
                throw;
            }

            OnAfterOfferCancellationPolicyCreated(offercancellationpolicy);

            return offercancellationpolicy;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy> CancelOfferCancellationPolicyChanges(ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnOfferCancellationPolicyUpdated(ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy item);
        partial void OnAfterOfferCancellationPolicyUpdated(ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy item);

        public async Task<ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy> UpdateOfferCancellationPolicy(int id, ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy offercancellationpolicy)
        {
            OnOfferCancellationPolicyUpdated(offercancellationpolicy);

            var itemToUpdate = Context.OfferCancellationPolicies
                              .Where(i => i.Id == offercancellationpolicy.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(offercancellationpolicy).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterOfferCancellationPolicyUpdated(offercancellationpolicy);

            return offercancellationpolicy;
        }

        partial void OnOfferCancellationPolicyDeleted(ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy item);
        partial void OnAfterOfferCancellationPolicyDeleted(ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy item);

        public async Task<ZarenTravelBO.Models.zaren_test.OfferCancellationPolicy> DeleteOfferCancellationPolicy(int id)
        {
            var itemToDelete = Context.OfferCancellationPolicies
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnOfferCancellationPolicyDeleted(itemToDelete);

            Reset();

            Context.OfferCancellationPolicies.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterOfferCancellationPolicyDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportOfferPriceBreakDownsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/offerpricebreakdowns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/offerpricebreakdowns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOfferPriceBreakDownsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/offerpricebreakdowns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/offerpricebreakdowns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOfferPriceBreakDownsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown>> GetOfferPriceBreakDowns(Query query = null)
        {
            var items = Context.OfferPriceBreakDowns.AsQueryable();


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

            OnOfferPriceBreakDownsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnOfferPriceBreakDownGet(ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown item);

        public async Task<ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown> GetOfferPriceBreakDownById(int id)
        {
            var items = Context.OfferPriceBreakDowns
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnOfferPriceBreakDownGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnOfferPriceBreakDownCreated(ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown item);
        partial void OnAfterOfferPriceBreakDownCreated(ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown item);

        public async Task<ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown> CreateOfferPriceBreakDown(ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown offerpricebreakdown)
        {
            OnOfferPriceBreakDownCreated(offerpricebreakdown);

            var existingItem = Context.OfferPriceBreakDowns
                              .Where(i => i.Id == offerpricebreakdown.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.OfferPriceBreakDowns.Add(offerpricebreakdown);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(offerpricebreakdown).State = EntityState.Detached;
                throw;
            }

            OnAfterOfferPriceBreakDownCreated(offerpricebreakdown);

            return offerpricebreakdown;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown> CancelOfferPriceBreakDownChanges(ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnOfferPriceBreakDownUpdated(ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown item);
        partial void OnAfterOfferPriceBreakDownUpdated(ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown item);

        public async Task<ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown> UpdateOfferPriceBreakDown(int id, ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown offerpricebreakdown)
        {
            OnOfferPriceBreakDownUpdated(offerpricebreakdown);

            var itemToUpdate = Context.OfferPriceBreakDowns
                              .Where(i => i.Id == offerpricebreakdown.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(offerpricebreakdown).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterOfferPriceBreakDownUpdated(offerpricebreakdown);

            return offerpricebreakdown;
        }

        partial void OnOfferPriceBreakDownDeleted(ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown item);
        partial void OnAfterOfferPriceBreakDownDeleted(ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown item);

        public async Task<ZarenTravelBO.Models.zaren_test.OfferPriceBreakDown> DeleteOfferPriceBreakDown(int id)
        {
            var itemToDelete = Context.OfferPriceBreakDowns
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnOfferPriceBreakDownDeleted(itemToDelete);

            Reset();

            Context.OfferPriceBreakDowns.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterOfferPriceBreakDownDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportOffersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/offers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/offers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOffersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/offers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/offers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOffersRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Offer> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Offer>> GetOffers(Query query = null)
        {
            var items = Context.Offers.AsQueryable();


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

            OnOffersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnOfferGet(ZarenTravelBO.Models.zaren_test.Offer item);

        public async Task<ZarenTravelBO.Models.zaren_test.Offer> GetOfferById(int id)
        {
            var items = Context.Offers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnOfferGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnOfferCreated(ZarenTravelBO.Models.zaren_test.Offer item);
        partial void OnAfterOfferCreated(ZarenTravelBO.Models.zaren_test.Offer item);

        public async Task<ZarenTravelBO.Models.zaren_test.Offer> CreateOffer(ZarenTravelBO.Models.zaren_test.Offer offer)
        {
            OnOfferCreated(offer);

            var existingItem = Context.Offers
                              .Where(i => i.Id == offer.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Offers.Add(offer);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(offer).State = EntityState.Detached;
                throw;
            }

            OnAfterOfferCreated(offer);

            return offer;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Offer> CancelOfferChanges(ZarenTravelBO.Models.zaren_test.Offer item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnOfferUpdated(ZarenTravelBO.Models.zaren_test.Offer item);
        partial void OnAfterOfferUpdated(ZarenTravelBO.Models.zaren_test.Offer item);

        public async Task<ZarenTravelBO.Models.zaren_test.Offer> UpdateOffer(int id, ZarenTravelBO.Models.zaren_test.Offer offer)
        {
            OnOfferUpdated(offer);

            var itemToUpdate = Context.Offers
                              .Where(i => i.Id == offer.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(offer).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterOfferUpdated(offer);

            return offer;
        }

        partial void OnOfferDeleted(ZarenTravelBO.Models.zaren_test.Offer item);
        partial void OnAfterOfferDeleted(ZarenTravelBO.Models.zaren_test.Offer item);

        public async Task<ZarenTravelBO.Models.zaren_test.Offer> DeleteOffer(int id)
        {
            var itemToDelete = Context.Offers
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnOfferDeleted(itemToDelete);

            Reset();

            Context.Offers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterOfferDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPassengerAmountsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/passengeramounts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/passengeramounts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPassengerAmountsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/passengeramounts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/passengeramounts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPassengerAmountsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.PassengerAmount> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.PassengerAmount>> GetPassengerAmounts(Query query = null)
        {
            var items = Context.PassengerAmounts.AsQueryable();


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

            OnPassengerAmountsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPassengerAmountGet(ZarenTravelBO.Models.zaren_test.PassengerAmount item);

        public async Task<ZarenTravelBO.Models.zaren_test.PassengerAmount> GetPassengerAmountById(int id)
        {
            var items = Context.PassengerAmounts
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPassengerAmountGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPassengerAmountCreated(ZarenTravelBO.Models.zaren_test.PassengerAmount item);
        partial void OnAfterPassengerAmountCreated(ZarenTravelBO.Models.zaren_test.PassengerAmount item);

        public async Task<ZarenTravelBO.Models.zaren_test.PassengerAmount> CreatePassengerAmount(ZarenTravelBO.Models.zaren_test.PassengerAmount passengeramount)
        {
            OnPassengerAmountCreated(passengeramount);

            var existingItem = Context.PassengerAmounts
                              .Where(i => i.Id == passengeramount.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PassengerAmounts.Add(passengeramount);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(passengeramount).State = EntityState.Detached;
                throw;
            }

            OnAfterPassengerAmountCreated(passengeramount);

            return passengeramount;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.PassengerAmount> CancelPassengerAmountChanges(ZarenTravelBO.Models.zaren_test.PassengerAmount item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPassengerAmountUpdated(ZarenTravelBO.Models.zaren_test.PassengerAmount item);
        partial void OnAfterPassengerAmountUpdated(ZarenTravelBO.Models.zaren_test.PassengerAmount item);

        public async Task<ZarenTravelBO.Models.zaren_test.PassengerAmount> UpdatePassengerAmount(int id, ZarenTravelBO.Models.zaren_test.PassengerAmount passengeramount)
        {
            OnPassengerAmountUpdated(passengeramount);

            var itemToUpdate = Context.PassengerAmounts
                              .Where(i => i.Id == passengeramount.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(passengeramount).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPassengerAmountUpdated(passengeramount);

            return passengeramount;
        }

        partial void OnPassengerAmountDeleted(ZarenTravelBO.Models.zaren_test.PassengerAmount item);
        partial void OnAfterPassengerAmountDeleted(ZarenTravelBO.Models.zaren_test.PassengerAmount item);

        public async Task<ZarenTravelBO.Models.zaren_test.PassengerAmount> DeletePassengerAmount(int id)
        {
            var itemToDelete = Context.PassengerAmounts
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPassengerAmountDeleted(itemToDelete);

            Reset();

            Context.PassengerAmounts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPassengerAmountDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPaymentPlanInfosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/paymentplaninfos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/paymentplaninfos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPaymentPlanInfosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/paymentplaninfos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/paymentplaninfos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPaymentPlanInfosRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.PaymentPlanInfo> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.PaymentPlanInfo>> GetPaymentPlanInfos(Query query = null)
        {
            var items = Context.PaymentPlanInfos.AsQueryable();


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

            OnPaymentPlanInfosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPaymentPlanInfoGet(ZarenTravelBO.Models.zaren_test.PaymentPlanInfo item);

        public async Task<ZarenTravelBO.Models.zaren_test.PaymentPlanInfo> GetPaymentPlanInfoById(int id)
        {
            var items = Context.PaymentPlanInfos
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPaymentPlanInfoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPaymentPlanInfoCreated(ZarenTravelBO.Models.zaren_test.PaymentPlanInfo item);
        partial void OnAfterPaymentPlanInfoCreated(ZarenTravelBO.Models.zaren_test.PaymentPlanInfo item);

        public async Task<ZarenTravelBO.Models.zaren_test.PaymentPlanInfo> CreatePaymentPlanInfo(ZarenTravelBO.Models.zaren_test.PaymentPlanInfo paymentplaninfo)
        {
            OnPaymentPlanInfoCreated(paymentplaninfo);

            var existingItem = Context.PaymentPlanInfos
                              .Where(i => i.Id == paymentplaninfo.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PaymentPlanInfos.Add(paymentplaninfo);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(paymentplaninfo).State = EntityState.Detached;
                throw;
            }

            OnAfterPaymentPlanInfoCreated(paymentplaninfo);

            return paymentplaninfo;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.PaymentPlanInfo> CancelPaymentPlanInfoChanges(ZarenTravelBO.Models.zaren_test.PaymentPlanInfo item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPaymentPlanInfoUpdated(ZarenTravelBO.Models.zaren_test.PaymentPlanInfo item);
        partial void OnAfterPaymentPlanInfoUpdated(ZarenTravelBO.Models.zaren_test.PaymentPlanInfo item);

        public async Task<ZarenTravelBO.Models.zaren_test.PaymentPlanInfo> UpdatePaymentPlanInfo(int id, ZarenTravelBO.Models.zaren_test.PaymentPlanInfo paymentplaninfo)
        {
            OnPaymentPlanInfoUpdated(paymentplaninfo);

            var itemToUpdate = Context.PaymentPlanInfos
                              .Where(i => i.Id == paymentplaninfo.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(paymentplaninfo).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPaymentPlanInfoUpdated(paymentplaninfo);

            return paymentplaninfo;
        }

        partial void OnPaymentPlanInfoDeleted(ZarenTravelBO.Models.zaren_test.PaymentPlanInfo item);
        partial void OnAfterPaymentPlanInfoDeleted(ZarenTravelBO.Models.zaren_test.PaymentPlanInfo item);

        public async Task<ZarenTravelBO.Models.zaren_test.PaymentPlanInfo> DeletePaymentPlanInfo(int id)
        {
            var itemToDelete = Context.PaymentPlanInfos
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPaymentPlanInfoDeleted(itemToDelete);

            Reset();

            Context.PaymentPlanInfos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPaymentPlanInfoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPaymentTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/paymenttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/paymenttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPaymentTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/paymenttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/paymenttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPaymentTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.PaymentType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.PaymentType>> GetPaymentTypes(Query query = null)
        {
            var items = Context.PaymentTypes.AsQueryable();


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

            OnPaymentTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPaymentTypeGet(ZarenTravelBO.Models.zaren_test.PaymentType item);

        public async Task<ZarenTravelBO.Models.zaren_test.PaymentType> GetPaymentTypeById(int id)
        {
            var items = Context.PaymentTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPaymentTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPaymentTypeCreated(ZarenTravelBO.Models.zaren_test.PaymentType item);
        partial void OnAfterPaymentTypeCreated(ZarenTravelBO.Models.zaren_test.PaymentType item);

        public async Task<ZarenTravelBO.Models.zaren_test.PaymentType> CreatePaymentType(ZarenTravelBO.Models.zaren_test.PaymentType paymenttype)
        {
            OnPaymentTypeCreated(paymenttype);

            var existingItem = Context.PaymentTypes
                              .Where(i => i.Id == paymenttype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PaymentTypes.Add(paymenttype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(paymenttype).State = EntityState.Detached;
                throw;
            }

            OnAfterPaymentTypeCreated(paymenttype);

            return paymenttype;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.PaymentType> CancelPaymentTypeChanges(ZarenTravelBO.Models.zaren_test.PaymentType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPaymentTypeUpdated(ZarenTravelBO.Models.zaren_test.PaymentType item);
        partial void OnAfterPaymentTypeUpdated(ZarenTravelBO.Models.zaren_test.PaymentType item);

        public async Task<ZarenTravelBO.Models.zaren_test.PaymentType> UpdatePaymentType(int id, ZarenTravelBO.Models.zaren_test.PaymentType paymenttype)
        {
            OnPaymentTypeUpdated(paymenttype);

            var itemToUpdate = Context.PaymentTypes
                              .Where(i => i.Id == paymenttype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(paymenttype).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPaymentTypeUpdated(paymenttype);

            return paymenttype;
        }

        partial void OnPaymentTypeDeleted(ZarenTravelBO.Models.zaren_test.PaymentType item);
        partial void OnAfterPaymentTypeDeleted(ZarenTravelBO.Models.zaren_test.PaymentType item);

        public async Task<ZarenTravelBO.Models.zaren_test.PaymentType> DeletePaymentType(int id)
        {
            var itemToDelete = Context.PaymentTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPaymentTypeDeleted(itemToDelete);

            Reset();

            Context.PaymentTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPaymentTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPossibleQueriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/possiblequeries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/possiblequeries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPossibleQueriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/possiblequeries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/possiblequeries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPossibleQueriesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.PossibleQuery> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.PossibleQuery>> GetPossibleQueries(Query query = null)
        {
            var items = Context.PossibleQueries.AsQueryable();


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

            OnPossibleQueriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPossibleQueryGet(ZarenTravelBO.Models.zaren_test.PossibleQuery item);

        public async Task<ZarenTravelBO.Models.zaren_test.PossibleQuery> GetPossibleQueryById(int id)
        {
            var items = Context.PossibleQueries
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPossibleQueryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPossibleQueryCreated(ZarenTravelBO.Models.zaren_test.PossibleQuery item);
        partial void OnAfterPossibleQueryCreated(ZarenTravelBO.Models.zaren_test.PossibleQuery item);

        public async Task<ZarenTravelBO.Models.zaren_test.PossibleQuery> CreatePossibleQuery(ZarenTravelBO.Models.zaren_test.PossibleQuery possiblequery)
        {
            OnPossibleQueryCreated(possiblequery);

            var existingItem = Context.PossibleQueries
                              .Where(i => i.Id == possiblequery.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PossibleQueries.Add(possiblequery);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(possiblequery).State = EntityState.Detached;
                throw;
            }

            OnAfterPossibleQueryCreated(possiblequery);

            return possiblequery;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.PossibleQuery> CancelPossibleQueryChanges(ZarenTravelBO.Models.zaren_test.PossibleQuery item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPossibleQueryUpdated(ZarenTravelBO.Models.zaren_test.PossibleQuery item);
        partial void OnAfterPossibleQueryUpdated(ZarenTravelBO.Models.zaren_test.PossibleQuery item);

        public async Task<ZarenTravelBO.Models.zaren_test.PossibleQuery> UpdatePossibleQuery(int id, ZarenTravelBO.Models.zaren_test.PossibleQuery possiblequery)
        {
            OnPossibleQueryUpdated(possiblequery);

            var itemToUpdate = Context.PossibleQueries
                              .Where(i => i.Id == possiblequery.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(possiblequery).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPossibleQueryUpdated(possiblequery);

            return possiblequery;
        }

        partial void OnPossibleQueryDeleted(ZarenTravelBO.Models.zaren_test.PossibleQuery item);
        partial void OnAfterPossibleQueryDeleted(ZarenTravelBO.Models.zaren_test.PossibleQuery item);

        public async Task<ZarenTravelBO.Models.zaren_test.PossibleQuery> DeletePossibleQuery(int id)
        {
            var itemToDelete = Context.PossibleQueries
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPossibleQueryDeleted(itemToDelete);

            Reset();

            Context.PossibleQueries.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPossibleQueryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPresentationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/presentations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/presentations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPresentationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/presentations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/presentations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPresentationsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Presentation> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Presentation>> GetPresentations(Query query = null)
        {
            var items = Context.Presentations.AsQueryable();


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

            OnPresentationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPresentationGet(ZarenTravelBO.Models.zaren_test.Presentation item);

        public async Task<ZarenTravelBO.Models.zaren_test.Presentation> GetPresentationById(int id)
        {
            var items = Context.Presentations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPresentationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPresentationCreated(ZarenTravelBO.Models.zaren_test.Presentation item);
        partial void OnAfterPresentationCreated(ZarenTravelBO.Models.zaren_test.Presentation item);

        public async Task<ZarenTravelBO.Models.zaren_test.Presentation> CreatePresentation(ZarenTravelBO.Models.zaren_test.Presentation presentation)
        {
            OnPresentationCreated(presentation);

            var existingItem = Context.Presentations
                              .Where(i => i.Id == presentation.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Presentations.Add(presentation);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(presentation).State = EntityState.Detached;
                throw;
            }

            OnAfterPresentationCreated(presentation);

            return presentation;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Presentation> CancelPresentationChanges(ZarenTravelBO.Models.zaren_test.Presentation item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPresentationUpdated(ZarenTravelBO.Models.zaren_test.Presentation item);
        partial void OnAfterPresentationUpdated(ZarenTravelBO.Models.zaren_test.Presentation item);

        public async Task<ZarenTravelBO.Models.zaren_test.Presentation> UpdatePresentation(int id, ZarenTravelBO.Models.zaren_test.Presentation presentation)
        {
            OnPresentationUpdated(presentation);

            var itemToUpdate = Context.Presentations
                              .Where(i => i.Id == presentation.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(presentation).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPresentationUpdated(presentation);

            return presentation;
        }

        partial void OnPresentationDeleted(ZarenTravelBO.Models.zaren_test.Presentation item);
        partial void OnAfterPresentationDeleted(ZarenTravelBO.Models.zaren_test.Presentation item);

        public async Task<ZarenTravelBO.Models.zaren_test.Presentation> DeletePresentation(int id)
        {
            var itemToDelete = Context.Presentations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPresentationDeleted(itemToDelete);

            Reset();

            Context.Presentations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPresentationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPriceBreakDownsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/pricebreakdowns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/pricebreakdowns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPriceBreakDownsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/pricebreakdowns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/pricebreakdowns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPriceBreakDownsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.PriceBreakDown> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.PriceBreakDown>> GetPriceBreakDowns(Query query = null)
        {
            var items = Context.PriceBreakDowns.AsQueryable();


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

            OnPriceBreakDownsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPriceBreakDownGet(ZarenTravelBO.Models.zaren_test.PriceBreakDown item);

        public async Task<ZarenTravelBO.Models.zaren_test.PriceBreakDown> GetPriceBreakDownById(int id)
        {
            var items = Context.PriceBreakDowns
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPriceBreakDownGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPriceBreakDownCreated(ZarenTravelBO.Models.zaren_test.PriceBreakDown item);
        partial void OnAfterPriceBreakDownCreated(ZarenTravelBO.Models.zaren_test.PriceBreakDown item);

        public async Task<ZarenTravelBO.Models.zaren_test.PriceBreakDown> CreatePriceBreakDown(ZarenTravelBO.Models.zaren_test.PriceBreakDown pricebreakdown)
        {
            OnPriceBreakDownCreated(pricebreakdown);

            var existingItem = Context.PriceBreakDowns
                              .Where(i => i.Id == pricebreakdown.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PriceBreakDowns.Add(pricebreakdown);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(pricebreakdown).State = EntityState.Detached;
                throw;
            }

            OnAfterPriceBreakDownCreated(pricebreakdown);

            return pricebreakdown;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.PriceBreakDown> CancelPriceBreakDownChanges(ZarenTravelBO.Models.zaren_test.PriceBreakDown item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPriceBreakDownUpdated(ZarenTravelBO.Models.zaren_test.PriceBreakDown item);
        partial void OnAfterPriceBreakDownUpdated(ZarenTravelBO.Models.zaren_test.PriceBreakDown item);

        public async Task<ZarenTravelBO.Models.zaren_test.PriceBreakDown> UpdatePriceBreakDown(int id, ZarenTravelBO.Models.zaren_test.PriceBreakDown pricebreakdown)
        {
            OnPriceBreakDownUpdated(pricebreakdown);

            var itemToUpdate = Context.PriceBreakDowns
                              .Where(i => i.Id == pricebreakdown.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(pricebreakdown).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPriceBreakDownUpdated(pricebreakdown);

            return pricebreakdown;
        }

        partial void OnPriceBreakDownDeleted(ZarenTravelBO.Models.zaren_test.PriceBreakDown item);
        partial void OnAfterPriceBreakDownDeleted(ZarenTravelBO.Models.zaren_test.PriceBreakDown item);

        public async Task<ZarenTravelBO.Models.zaren_test.PriceBreakDown> DeletePriceBreakDown(int id)
        {
            var itemToDelete = Context.PriceBreakDowns
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPriceBreakDownDeleted(itemToDelete);

            Reset();

            Context.PriceBreakDowns.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPriceBreakDownDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPricesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/prices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/prices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPricesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/prices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/prices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPricesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Price> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Price>> GetPrices(Query query = null)
        {
            var items = Context.Prices.AsQueryable();


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

            OnPricesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPriceGet(ZarenTravelBO.Models.zaren_test.Price item);

        public async Task<ZarenTravelBO.Models.zaren_test.Price> GetPriceById(int id)
        {
            var items = Context.Prices
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPriceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPriceCreated(ZarenTravelBO.Models.zaren_test.Price item);
        partial void OnAfterPriceCreated(ZarenTravelBO.Models.zaren_test.Price item);

        public async Task<ZarenTravelBO.Models.zaren_test.Price> CreatePrice(ZarenTravelBO.Models.zaren_test.Price price)
        {
            OnPriceCreated(price);

            var existingItem = Context.Prices
                              .Where(i => i.Id == price.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Prices.Add(price);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(price).State = EntityState.Detached;
                throw;
            }

            OnAfterPriceCreated(price);

            return price;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Price> CancelPriceChanges(ZarenTravelBO.Models.zaren_test.Price item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPriceUpdated(ZarenTravelBO.Models.zaren_test.Price item);
        partial void OnAfterPriceUpdated(ZarenTravelBO.Models.zaren_test.Price item);

        public async Task<ZarenTravelBO.Models.zaren_test.Price> UpdatePrice(int id, ZarenTravelBO.Models.zaren_test.Price price)
        {
            OnPriceUpdated(price);

            var itemToUpdate = Context.Prices
                              .Where(i => i.Id == price.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(price).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPriceUpdated(price);

            return price;
        }

        partial void OnPriceDeleted(ZarenTravelBO.Models.zaren_test.Price item);
        partial void OnAfterPriceDeleted(ZarenTravelBO.Models.zaren_test.Price item);

        public async Task<ZarenTravelBO.Models.zaren_test.Price> DeletePrice(int id)
        {
            var itemToDelete = Context.Prices
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPriceDeleted(itemToDelete);

            Reset();

            Context.Prices.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPriceDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProductTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/producttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/producttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProductTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/producttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/producttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProductTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.ProductType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.ProductType>> GetProductTypes(Query query = null)
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

        partial void OnProductTypeGet(ZarenTravelBO.Models.zaren_test.ProductType item);

        public async Task<ZarenTravelBO.Models.zaren_test.ProductType> GetProductTypeById(int id)
        {
            var items = Context.ProductTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProductTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProductTypeCreated(ZarenTravelBO.Models.zaren_test.ProductType item);
        partial void OnAfterProductTypeCreated(ZarenTravelBO.Models.zaren_test.ProductType item);

        public async Task<ZarenTravelBO.Models.zaren_test.ProductType> CreateProductType(ZarenTravelBO.Models.zaren_test.ProductType producttype)
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

        public async Task<ZarenTravelBO.Models.zaren_test.ProductType> CancelProductTypeChanges(ZarenTravelBO.Models.zaren_test.ProductType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProductTypeUpdated(ZarenTravelBO.Models.zaren_test.ProductType item);
        partial void OnAfterProductTypeUpdated(ZarenTravelBO.Models.zaren_test.ProductType item);

        public async Task<ZarenTravelBO.Models.zaren_test.ProductType> UpdateProductType(int id, ZarenTravelBO.Models.zaren_test.ProductType producttype)
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

        partial void OnProductTypeDeleted(ZarenTravelBO.Models.zaren_test.ProductType item);
        partial void OnAfterProductTypeDeleted(ZarenTravelBO.Models.zaren_test.ProductType item);

        public async Task<ZarenTravelBO.Models.zaren_test.ProductType> DeleteProductType(int id)
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
    
        public async Task ExportResourcesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/resources/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/resources/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportResourcesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/resources/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/resources/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnResourcesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Resource> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Resource>> GetResources(Query query = null)
        {
            var items = Context.Resources.AsQueryable();


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

            OnResourcesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnResourceGet(ZarenTravelBO.Models.zaren_test.Resource item);

        public async Task<ZarenTravelBO.Models.zaren_test.Resource> GetResourceById(int id)
        {
            var items = Context.Resources
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnResourceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnResourceCreated(ZarenTravelBO.Models.zaren_test.Resource item);
        partial void OnAfterResourceCreated(ZarenTravelBO.Models.zaren_test.Resource item);

        public async Task<ZarenTravelBO.Models.zaren_test.Resource> CreateResource(ZarenTravelBO.Models.zaren_test.Resource resource)
        {
            OnResourceCreated(resource);

            var existingItem = Context.Resources
                              .Where(i => i.Id == resource.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Resources.Add(resource);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(resource).State = EntityState.Detached;
                throw;
            }

            OnAfterResourceCreated(resource);

            return resource;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Resource> CancelResourceChanges(ZarenTravelBO.Models.zaren_test.Resource item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnResourceUpdated(ZarenTravelBO.Models.zaren_test.Resource item);
        partial void OnAfterResourceUpdated(ZarenTravelBO.Models.zaren_test.Resource item);

        public async Task<ZarenTravelBO.Models.zaren_test.Resource> UpdateResource(int id, ZarenTravelBO.Models.zaren_test.Resource resource)
        {
            OnResourceUpdated(resource);

            var itemToUpdate = Context.Resources
                              .Where(i => i.Id == resource.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(resource).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterResourceUpdated(resource);

            return resource;
        }

        partial void OnResourceDeleted(ZarenTravelBO.Models.zaren_test.Resource item);
        partial void OnAfterResourceDeleted(ZarenTravelBO.Models.zaren_test.Resource item);

        public async Task<ZarenTravelBO.Models.zaren_test.Resource> DeleteResource(int id)
        {
            var itemToDelete = Context.Resources
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnResourceDeleted(itemToDelete);

            Reset();

            Context.Resources.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterResourceDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportRoomFacilitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/roomfacilities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/roomfacilities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRoomFacilitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/roomfacilities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/roomfacilities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRoomFacilitiesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.RoomFacility> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.RoomFacility>> GetRoomFacilities(Query query = null)
        {
            var items = Context.RoomFacilities.AsQueryable();


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

            OnRoomFacilitiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRoomFacilityGet(ZarenTravelBO.Models.zaren_test.RoomFacility item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomFacility> GetRoomFacilityById(int id)
        {
            var items = Context.RoomFacilities
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnRoomFacilityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnRoomFacilityCreated(ZarenTravelBO.Models.zaren_test.RoomFacility item);
        partial void OnAfterRoomFacilityCreated(ZarenTravelBO.Models.zaren_test.RoomFacility item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomFacility> CreateRoomFacility(ZarenTravelBO.Models.zaren_test.RoomFacility roomfacility)
        {
            OnRoomFacilityCreated(roomfacility);

            var existingItem = Context.RoomFacilities
                              .Where(i => i.Id == roomfacility.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.RoomFacilities.Add(roomfacility);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(roomfacility).State = EntityState.Detached;
                throw;
            }

            OnAfterRoomFacilityCreated(roomfacility);

            return roomfacility;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.RoomFacility> CancelRoomFacilityChanges(ZarenTravelBO.Models.zaren_test.RoomFacility item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRoomFacilityUpdated(ZarenTravelBO.Models.zaren_test.RoomFacility item);
        partial void OnAfterRoomFacilityUpdated(ZarenTravelBO.Models.zaren_test.RoomFacility item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomFacility> UpdateRoomFacility(int id, ZarenTravelBO.Models.zaren_test.RoomFacility roomfacility)
        {
            OnRoomFacilityUpdated(roomfacility);

            var itemToUpdate = Context.RoomFacilities
                              .Where(i => i.Id == roomfacility.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(roomfacility).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterRoomFacilityUpdated(roomfacility);

            return roomfacility;
        }

        partial void OnRoomFacilityDeleted(ZarenTravelBO.Models.zaren_test.RoomFacility item);
        partial void OnAfterRoomFacilityDeleted(ZarenTravelBO.Models.zaren_test.RoomFacility item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomFacility> DeleteRoomFacility(int id)
        {
            var itemToDelete = Context.RoomFacilities
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRoomFacilityDeleted(itemToDelete);

            Reset();

            Context.RoomFacilities.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRoomFacilityDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportRoomInfoFacilitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/roominfofacilities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/roominfofacilities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRoomInfoFacilitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/roominfofacilities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/roominfofacilities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRoomInfoFacilitiesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.RoomInfoFacility> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.RoomInfoFacility>> GetRoomInfoFacilities(Query query = null)
        {
            var items = Context.RoomInfoFacilities.AsQueryable();


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

            OnRoomInfoFacilitiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRoomInfoFacilityGet(ZarenTravelBO.Models.zaren_test.RoomInfoFacility item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomInfoFacility> GetRoomInfoFacilityById(int id)
        {
            var items = Context.RoomInfoFacilities
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnRoomInfoFacilityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnRoomInfoFacilityCreated(ZarenTravelBO.Models.zaren_test.RoomInfoFacility item);
        partial void OnAfterRoomInfoFacilityCreated(ZarenTravelBO.Models.zaren_test.RoomInfoFacility item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomInfoFacility> CreateRoomInfoFacility(ZarenTravelBO.Models.zaren_test.RoomInfoFacility roominfofacility)
        {
            OnRoomInfoFacilityCreated(roominfofacility);

            var existingItem = Context.RoomInfoFacilities
                              .Where(i => i.Id == roominfofacility.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.RoomInfoFacilities.Add(roominfofacility);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(roominfofacility).State = EntityState.Detached;
                throw;
            }

            OnAfterRoomInfoFacilityCreated(roominfofacility);

            return roominfofacility;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.RoomInfoFacility> CancelRoomInfoFacilityChanges(ZarenTravelBO.Models.zaren_test.RoomInfoFacility item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRoomInfoFacilityUpdated(ZarenTravelBO.Models.zaren_test.RoomInfoFacility item);
        partial void OnAfterRoomInfoFacilityUpdated(ZarenTravelBO.Models.zaren_test.RoomInfoFacility item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomInfoFacility> UpdateRoomInfoFacility(int id, ZarenTravelBO.Models.zaren_test.RoomInfoFacility roominfofacility)
        {
            OnRoomInfoFacilityUpdated(roominfofacility);

            var itemToUpdate = Context.RoomInfoFacilities
                              .Where(i => i.Id == roominfofacility.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(roominfofacility).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterRoomInfoFacilityUpdated(roominfofacility);

            return roominfofacility;
        }

        partial void OnRoomInfoFacilityDeleted(ZarenTravelBO.Models.zaren_test.RoomInfoFacility item);
        partial void OnAfterRoomInfoFacilityDeleted(ZarenTravelBO.Models.zaren_test.RoomInfoFacility item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomInfoFacility> DeleteRoomInfoFacility(int id)
        {
            var itemToDelete = Context.RoomInfoFacilities
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRoomInfoFacilityDeleted(itemToDelete);

            Reset();

            Context.RoomInfoFacilities.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRoomInfoFacilityDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportRoomInfosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/roominfos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/roominfos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRoomInfosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/roominfos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/roominfos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRoomInfosRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.RoomInfo> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.RoomInfo>> GetRoomInfos(Query query = null)
        {
            var items = Context.RoomInfos.AsQueryable();


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

            OnRoomInfosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRoomInfoGet(ZarenTravelBO.Models.zaren_test.RoomInfo item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomInfo> GetRoomInfoById(int id)
        {
            var items = Context.RoomInfos
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnRoomInfoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnRoomInfoCreated(ZarenTravelBO.Models.zaren_test.RoomInfo item);
        partial void OnAfterRoomInfoCreated(ZarenTravelBO.Models.zaren_test.RoomInfo item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomInfo> CreateRoomInfo(ZarenTravelBO.Models.zaren_test.RoomInfo roominfo)
        {
            OnRoomInfoCreated(roominfo);

            var existingItem = Context.RoomInfos
                              .Where(i => i.Id == roominfo.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.RoomInfos.Add(roominfo);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(roominfo).State = EntityState.Detached;
                throw;
            }

            OnAfterRoomInfoCreated(roominfo);

            return roominfo;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.RoomInfo> CancelRoomInfoChanges(ZarenTravelBO.Models.zaren_test.RoomInfo item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRoomInfoUpdated(ZarenTravelBO.Models.zaren_test.RoomInfo item);
        partial void OnAfterRoomInfoUpdated(ZarenTravelBO.Models.zaren_test.RoomInfo item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomInfo> UpdateRoomInfo(int id, ZarenTravelBO.Models.zaren_test.RoomInfo roominfo)
        {
            OnRoomInfoUpdated(roominfo);

            var itemToUpdate = Context.RoomInfos
                              .Where(i => i.Id == roominfo.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(roominfo).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterRoomInfoUpdated(roominfo);

            return roominfo;
        }

        partial void OnRoomInfoDeleted(ZarenTravelBO.Models.zaren_test.RoomInfo item);
        partial void OnAfterRoomInfoDeleted(ZarenTravelBO.Models.zaren_test.RoomInfo item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomInfo> DeleteRoomInfo(int id)
        {
            var itemToDelete = Context.RoomInfos
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRoomInfoDeleted(itemToDelete);

            Reset();

            Context.RoomInfos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRoomInfoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportRoomInfosMediaFilesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/roominfosmediafiles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/roominfosmediafiles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRoomInfosMediaFilesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/roominfosmediafiles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/roominfosmediafiles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRoomInfosMediaFilesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile>> GetRoomInfosMediaFiles(Query query = null)
        {
            var items = Context.RoomInfosMediaFiles.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);

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

            OnRoomInfosMediaFilesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRoomInfosMediaFileGet(ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile> GetRoomInfosMediaFileById(int id)
        {
            var items = Context.RoomInfosMediaFiles
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnRoomInfosMediaFileGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnRoomInfosMediaFileCreated(ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile item);
        partial void OnAfterRoomInfosMediaFileCreated(ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile> CreateRoomInfosMediaFile(ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile roominfosmediafile)
        {
            OnRoomInfosMediaFileCreated(roominfosmediafile);

            var existingItem = Context.RoomInfosMediaFiles
                              .Where(i => i.Id == roominfosmediafile.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.RoomInfosMediaFiles.Add(roominfosmediafile);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(roominfosmediafile).State = EntityState.Detached;
                throw;
            }

            OnAfterRoomInfosMediaFileCreated(roominfosmediafile);

            return roominfosmediafile;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile> CancelRoomInfosMediaFileChanges(ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRoomInfosMediaFileUpdated(ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile item);
        partial void OnAfterRoomInfosMediaFileUpdated(ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile> UpdateRoomInfosMediaFile(int id, ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile roominfosmediafile)
        {
            OnRoomInfosMediaFileUpdated(roominfosmediafile);

            var itemToUpdate = Context.RoomInfosMediaFiles
                              .Where(i => i.Id == roominfosmediafile.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            roominfosmediafile.Agency = null;
            roominfosmediafile.Language = null;

            Context.Attach(roominfosmediafile).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterRoomInfosMediaFileUpdated(roominfosmediafile);

            return roominfosmediafile;
        }

        partial void OnRoomInfosMediaFileDeleted(ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile item);
        partial void OnAfterRoomInfosMediaFileDeleted(ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomInfosMediaFile> DeleteRoomInfosMediaFile(int id)
        {
            var itemToDelete = Context.RoomInfosMediaFiles
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRoomInfosMediaFileDeleted(itemToDelete);

            Reset();

            Context.RoomInfosMediaFiles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRoomInfosMediaFileDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportRoomMediaFilesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/roommediafiles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/roommediafiles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRoomMediaFilesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/roommediafiles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/roommediafiles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRoomMediaFilesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.RoomMediaFile> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.RoomMediaFile>> GetRoomMediaFiles(Query query = null)
        {
            var items = Context.RoomMediaFiles.AsQueryable();


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

            OnRoomMediaFilesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRoomMediaFileGet(ZarenTravelBO.Models.zaren_test.RoomMediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomMediaFile> GetRoomMediaFileById(int id)
        {
            var items = Context.RoomMediaFiles
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnRoomMediaFileGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnRoomMediaFileCreated(ZarenTravelBO.Models.zaren_test.RoomMediaFile item);
        partial void OnAfterRoomMediaFileCreated(ZarenTravelBO.Models.zaren_test.RoomMediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomMediaFile> CreateRoomMediaFile(ZarenTravelBO.Models.zaren_test.RoomMediaFile roommediafile)
        {
            OnRoomMediaFileCreated(roommediafile);

            var existingItem = Context.RoomMediaFiles
                              .Where(i => i.Id == roommediafile.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.RoomMediaFiles.Add(roommediafile);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(roommediafile).State = EntityState.Detached;
                throw;
            }

            OnAfterRoomMediaFileCreated(roommediafile);

            return roommediafile;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.RoomMediaFile> CancelRoomMediaFileChanges(ZarenTravelBO.Models.zaren_test.RoomMediaFile item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRoomMediaFileUpdated(ZarenTravelBO.Models.zaren_test.RoomMediaFile item);
        partial void OnAfterRoomMediaFileUpdated(ZarenTravelBO.Models.zaren_test.RoomMediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomMediaFile> UpdateRoomMediaFile(int id, ZarenTravelBO.Models.zaren_test.RoomMediaFile roommediafile)
        {
            OnRoomMediaFileUpdated(roommediafile);

            var itemToUpdate = Context.RoomMediaFiles
                              .Where(i => i.Id == roommediafile.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(roommediafile).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterRoomMediaFileUpdated(roommediafile);

            return roommediafile;
        }

        partial void OnRoomMediaFileDeleted(ZarenTravelBO.Models.zaren_test.RoomMediaFile item);
        partial void OnAfterRoomMediaFileDeleted(ZarenTravelBO.Models.zaren_test.RoomMediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomMediaFile> DeleteRoomMediaFile(int id)
        {
            var itemToDelete = Context.RoomMediaFiles
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRoomMediaFileDeleted(itemToDelete);

            Reset();

            Context.RoomMediaFiles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRoomMediaFileDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportRoomPresentationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/roompresentations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/roompresentations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRoomPresentationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/roompresentations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/roompresentations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRoomPresentationsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.RoomPresentation> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.RoomPresentation>> GetRoomPresentations(Query query = null)
        {
            var items = Context.RoomPresentations.AsQueryable();


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

            OnRoomPresentationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRoomPresentationGet(ZarenTravelBO.Models.zaren_test.RoomPresentation item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomPresentation> GetRoomPresentationById(int id)
        {
            var items = Context.RoomPresentations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnRoomPresentationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnRoomPresentationCreated(ZarenTravelBO.Models.zaren_test.RoomPresentation item);
        partial void OnAfterRoomPresentationCreated(ZarenTravelBO.Models.zaren_test.RoomPresentation item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomPresentation> CreateRoomPresentation(ZarenTravelBO.Models.zaren_test.RoomPresentation roompresentation)
        {
            OnRoomPresentationCreated(roompresentation);

            var existingItem = Context.RoomPresentations
                              .Where(i => i.Id == roompresentation.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.RoomPresentations.Add(roompresentation);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(roompresentation).State = EntityState.Detached;
                throw;
            }

            OnAfterRoomPresentationCreated(roompresentation);

            return roompresentation;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.RoomPresentation> CancelRoomPresentationChanges(ZarenTravelBO.Models.zaren_test.RoomPresentation item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRoomPresentationUpdated(ZarenTravelBO.Models.zaren_test.RoomPresentation item);
        partial void OnAfterRoomPresentationUpdated(ZarenTravelBO.Models.zaren_test.RoomPresentation item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomPresentation> UpdateRoomPresentation(int id, ZarenTravelBO.Models.zaren_test.RoomPresentation roompresentation)
        {
            OnRoomPresentationUpdated(roompresentation);

            var itemToUpdate = Context.RoomPresentations
                              .Where(i => i.Id == roompresentation.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(roompresentation).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterRoomPresentationUpdated(roompresentation);

            return roompresentation;
        }

        partial void OnRoomPresentationDeleted(ZarenTravelBO.Models.zaren_test.RoomPresentation item);
        partial void OnAfterRoomPresentationDeleted(ZarenTravelBO.Models.zaren_test.RoomPresentation item);

        public async Task<ZarenTravelBO.Models.zaren_test.RoomPresentation> DeleteRoomPresentation(int id)
        {
            var itemToDelete = Context.RoomPresentations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRoomPresentationDeleted(itemToDelete);

            Reset();

            Context.RoomPresentations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRoomPresentationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportRoomsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/rooms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/rooms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRoomsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/rooms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/rooms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRoomsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Room> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Room>> GetRooms(Query query = null)
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

        partial void OnRoomGet(ZarenTravelBO.Models.zaren_test.Room item);

        public async Task<ZarenTravelBO.Models.zaren_test.Room> GetRoomById(int id)
        {
            var items = Context.Rooms
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnRoomGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnRoomCreated(ZarenTravelBO.Models.zaren_test.Room item);
        partial void OnAfterRoomCreated(ZarenTravelBO.Models.zaren_test.Room item);

        public async Task<ZarenTravelBO.Models.zaren_test.Room> CreateRoom(ZarenTravelBO.Models.zaren_test.Room room)
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

        public async Task<ZarenTravelBO.Models.zaren_test.Room> CancelRoomChanges(ZarenTravelBO.Models.zaren_test.Room item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRoomUpdated(ZarenTravelBO.Models.zaren_test.Room item);
        partial void OnAfterRoomUpdated(ZarenTravelBO.Models.zaren_test.Room item);

        public async Task<ZarenTravelBO.Models.zaren_test.Room> UpdateRoom(int id, ZarenTravelBO.Models.zaren_test.Room room)
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

        partial void OnRoomDeleted(ZarenTravelBO.Models.zaren_test.Room item);
        partial void OnAfterRoomDeleted(ZarenTravelBO.Models.zaren_test.Room item);

        public async Task<ZarenTravelBO.Models.zaren_test.Room> DeleteRoom(int id)
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
    
        public async Task ExportSeasonMediaFilesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/seasonmediafiles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/seasonmediafiles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSeasonMediaFilesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/seasonmediafiles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/seasonmediafiles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSeasonMediaFilesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.SeasonMediaFile> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.SeasonMediaFile>> GetSeasonMediaFiles(Query query = null)
        {
            var items = Context.SeasonMediaFiles.AsQueryable();


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

            OnSeasonMediaFilesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSeasonMediaFileGet(ZarenTravelBO.Models.zaren_test.SeasonMediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_test.SeasonMediaFile> GetSeasonMediaFileById(int id)
        {
            var items = Context.SeasonMediaFiles
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnSeasonMediaFileGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSeasonMediaFileCreated(ZarenTravelBO.Models.zaren_test.SeasonMediaFile item);
        partial void OnAfterSeasonMediaFileCreated(ZarenTravelBO.Models.zaren_test.SeasonMediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_test.SeasonMediaFile> CreateSeasonMediaFile(ZarenTravelBO.Models.zaren_test.SeasonMediaFile seasonmediafile)
        {
            OnSeasonMediaFileCreated(seasonmediafile);

            var existingItem = Context.SeasonMediaFiles
                              .Where(i => i.Id == seasonmediafile.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SeasonMediaFiles.Add(seasonmediafile);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(seasonmediafile).State = EntityState.Detached;
                throw;
            }

            OnAfterSeasonMediaFileCreated(seasonmediafile);

            return seasonmediafile;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.SeasonMediaFile> CancelSeasonMediaFileChanges(ZarenTravelBO.Models.zaren_test.SeasonMediaFile item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSeasonMediaFileUpdated(ZarenTravelBO.Models.zaren_test.SeasonMediaFile item);
        partial void OnAfterSeasonMediaFileUpdated(ZarenTravelBO.Models.zaren_test.SeasonMediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_test.SeasonMediaFile> UpdateSeasonMediaFile(int id, ZarenTravelBO.Models.zaren_test.SeasonMediaFile seasonmediafile)
        {
            OnSeasonMediaFileUpdated(seasonmediafile);

            var itemToUpdate = Context.SeasonMediaFiles
                              .Where(i => i.Id == seasonmediafile.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(seasonmediafile).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSeasonMediaFileUpdated(seasonmediafile);

            return seasonmediafile;
        }

        partial void OnSeasonMediaFileDeleted(ZarenTravelBO.Models.zaren_test.SeasonMediaFile item);
        partial void OnAfterSeasonMediaFileDeleted(ZarenTravelBO.Models.zaren_test.SeasonMediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_test.SeasonMediaFile> DeleteSeasonMediaFile(int id)
        {
            var itemToDelete = Context.SeasonMediaFiles
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSeasonMediaFileDeleted(itemToDelete);

            Reset();

            Context.SeasonMediaFiles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSeasonMediaFileDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSeasonsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/seasons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/seasons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSeasonsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/seasons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/seasons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSeasonsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Season> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Season>> GetSeasons(Query query = null)
        {
            var items = Context.Seasons.AsQueryable();


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

            OnSeasonsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSeasonGet(ZarenTravelBO.Models.zaren_test.Season item);

        public async Task<ZarenTravelBO.Models.zaren_test.Season> GetSeasonById(int id)
        {
            var items = Context.Seasons
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnSeasonGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSeasonCreated(ZarenTravelBO.Models.zaren_test.Season item);
        partial void OnAfterSeasonCreated(ZarenTravelBO.Models.zaren_test.Season item);

        public async Task<ZarenTravelBO.Models.zaren_test.Season> CreateSeason(ZarenTravelBO.Models.zaren_test.Season season)
        {
            OnSeasonCreated(season);

            var existingItem = Context.Seasons
                              .Where(i => i.Id == season.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Seasons.Add(season);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(season).State = EntityState.Detached;
                throw;
            }

            OnAfterSeasonCreated(season);

            return season;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Season> CancelSeasonChanges(ZarenTravelBO.Models.zaren_test.Season item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSeasonUpdated(ZarenTravelBO.Models.zaren_test.Season item);
        partial void OnAfterSeasonUpdated(ZarenTravelBO.Models.zaren_test.Season item);

        public async Task<ZarenTravelBO.Models.zaren_test.Season> UpdateSeason(int id, ZarenTravelBO.Models.zaren_test.Season season)
        {
            OnSeasonUpdated(season);

            var itemToUpdate = Context.Seasons
                              .Where(i => i.Id == season.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(season).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSeasonUpdated(season);

            return season;
        }

        partial void OnSeasonDeleted(ZarenTravelBO.Models.zaren_test.Season item);
        partial void OnAfterSeasonDeleted(ZarenTravelBO.Models.zaren_test.Season item);

        public async Task<ZarenTravelBO.Models.zaren_test.Season> DeleteSeason(int id)
        {
            var itemToDelete = Context.Seasons
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSeasonDeleted(itemToDelete);

            Reset();

            Context.Seasons.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSeasonDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSeasonTextCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/seasontextcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/seasontextcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSeasonTextCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/seasontextcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/seasontextcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSeasonTextCategoriesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.SeasonTextCategory> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.SeasonTextCategory>> GetSeasonTextCategories(Query query = null)
        {
            var items = Context.SeasonTextCategories.AsQueryable();


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

            OnSeasonTextCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSeasonTextCategoryGet(ZarenTravelBO.Models.zaren_test.SeasonTextCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.SeasonTextCategory> GetSeasonTextCategoryById(int id)
        {
            var items = Context.SeasonTextCategories
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnSeasonTextCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSeasonTextCategoryCreated(ZarenTravelBO.Models.zaren_test.SeasonTextCategory item);
        partial void OnAfterSeasonTextCategoryCreated(ZarenTravelBO.Models.zaren_test.SeasonTextCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.SeasonTextCategory> CreateSeasonTextCategory(ZarenTravelBO.Models.zaren_test.SeasonTextCategory seasontextcategory)
        {
            OnSeasonTextCategoryCreated(seasontextcategory);

            var existingItem = Context.SeasonTextCategories
                              .Where(i => i.Id == seasontextcategory.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SeasonTextCategories.Add(seasontextcategory);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(seasontextcategory).State = EntityState.Detached;
                throw;
            }

            OnAfterSeasonTextCategoryCreated(seasontextcategory);

            return seasontextcategory;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.SeasonTextCategory> CancelSeasonTextCategoryChanges(ZarenTravelBO.Models.zaren_test.SeasonTextCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSeasonTextCategoryUpdated(ZarenTravelBO.Models.zaren_test.SeasonTextCategory item);
        partial void OnAfterSeasonTextCategoryUpdated(ZarenTravelBO.Models.zaren_test.SeasonTextCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.SeasonTextCategory> UpdateSeasonTextCategory(int id, ZarenTravelBO.Models.zaren_test.SeasonTextCategory seasontextcategory)
        {
            OnSeasonTextCategoryUpdated(seasontextcategory);

            var itemToUpdate = Context.SeasonTextCategories
                              .Where(i => i.Id == seasontextcategory.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(seasontextcategory).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSeasonTextCategoryUpdated(seasontextcategory);

            return seasontextcategory;
        }

        partial void OnSeasonTextCategoryDeleted(ZarenTravelBO.Models.zaren_test.SeasonTextCategory item);
        partial void OnAfterSeasonTextCategoryDeleted(ZarenTravelBO.Models.zaren_test.SeasonTextCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.SeasonTextCategory> DeleteSeasonTextCategory(int id)
        {
            var itemToDelete = Context.SeasonTextCategories
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSeasonTextCategoryDeleted(itemToDelete);

            Reset();

            Context.SeasonTextCategories.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSeasonTextCategoryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSeasonThemesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/seasonthemes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/seasonthemes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSeasonThemesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/seasonthemes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/seasonthemes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSeasonThemesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.SeasonTheme> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.SeasonTheme>> GetSeasonThemes(Query query = null)
        {
            var items = Context.SeasonThemes.AsQueryable();


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

            OnSeasonThemesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSeasonThemeGet(ZarenTravelBO.Models.zaren_test.SeasonTheme item);

        public async Task<ZarenTravelBO.Models.zaren_test.SeasonTheme> GetSeasonThemeById(int id)
        {
            var items = Context.SeasonThemes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnSeasonThemeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSeasonThemeCreated(ZarenTravelBO.Models.zaren_test.SeasonTheme item);
        partial void OnAfterSeasonThemeCreated(ZarenTravelBO.Models.zaren_test.SeasonTheme item);

        public async Task<ZarenTravelBO.Models.zaren_test.SeasonTheme> CreateSeasonTheme(ZarenTravelBO.Models.zaren_test.SeasonTheme seasontheme)
        {
            OnSeasonThemeCreated(seasontheme);

            var existingItem = Context.SeasonThemes
                              .Where(i => i.Id == seasontheme.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SeasonThemes.Add(seasontheme);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(seasontheme).State = EntityState.Detached;
                throw;
            }

            OnAfterSeasonThemeCreated(seasontheme);

            return seasontheme;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.SeasonTheme> CancelSeasonThemeChanges(ZarenTravelBO.Models.zaren_test.SeasonTheme item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSeasonThemeUpdated(ZarenTravelBO.Models.zaren_test.SeasonTheme item);
        partial void OnAfterSeasonThemeUpdated(ZarenTravelBO.Models.zaren_test.SeasonTheme item);

        public async Task<ZarenTravelBO.Models.zaren_test.SeasonTheme> UpdateSeasonTheme(int id, ZarenTravelBO.Models.zaren_test.SeasonTheme seasontheme)
        {
            OnSeasonThemeUpdated(seasontheme);

            var itemToUpdate = Context.SeasonThemes
                              .Where(i => i.Id == seasontheme.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(seasontheme).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSeasonThemeUpdated(seasontheme);

            return seasontheme;
        }

        partial void OnSeasonThemeDeleted(ZarenTravelBO.Models.zaren_test.SeasonTheme item);
        partial void OnAfterSeasonThemeDeleted(ZarenTravelBO.Models.zaren_test.SeasonTheme item);

        public async Task<ZarenTravelBO.Models.zaren_test.SeasonTheme> DeleteSeasonTheme(int id)
        {
            var itemToDelete = Context.SeasonThemes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSeasonThemeDeleted(itemToDelete);

            Reset();

            Context.SeasonThemes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSeasonThemeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportStatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/states/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/states/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportStatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/states/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/states/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnStatesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.State> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.State>> GetStates(Query query = null)
        {
            var items = Context.States.AsQueryable();


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

            OnStatesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnStateGet(ZarenTravelBO.Models.zaren_test.State item);

        public async Task<ZarenTravelBO.Models.zaren_test.State> GetStateById(int id)
        {
            var items = Context.States
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnStateGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnStateCreated(ZarenTravelBO.Models.zaren_test.State item);
        partial void OnAfterStateCreated(ZarenTravelBO.Models.zaren_test.State item);

        public async Task<ZarenTravelBO.Models.zaren_test.State> CreateState(ZarenTravelBO.Models.zaren_test.State state)
        {
            OnStateCreated(state);

            var existingItem = Context.States
                              .Where(i => i.Id == state.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.States.Add(state);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(state).State = EntityState.Detached;
                throw;
            }

            OnAfterStateCreated(state);

            return state;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.State> CancelStateChanges(ZarenTravelBO.Models.zaren_test.State item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnStateUpdated(ZarenTravelBO.Models.zaren_test.State item);
        partial void OnAfterStateUpdated(ZarenTravelBO.Models.zaren_test.State item);

        public async Task<ZarenTravelBO.Models.zaren_test.State> UpdateState(int id, ZarenTravelBO.Models.zaren_test.State state)
        {
            OnStateUpdated(state);

            var itemToUpdate = Context.States
                              .Where(i => i.Id == state.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(state).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterStateUpdated(state);

            return state;
        }

        partial void OnStateDeleted(ZarenTravelBO.Models.zaren_test.State item);
        partial void OnAfterStateDeleted(ZarenTravelBO.Models.zaren_test.State item);

        public async Task<ZarenTravelBO.Models.zaren_test.State> DeleteState(int id)
        {
            var itemToDelete = Context.States
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnStateDeleted(itemToDelete);

            Reset();

            Context.States.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterStateDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTextCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/textcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/textcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTextCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/textcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/textcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTextCategoriesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.TextCategory> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.TextCategory>> GetTextCategories(Query query = null)
        {
            var items = Context.TextCategories.AsQueryable();


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

            OnTextCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTextCategoryGet(ZarenTravelBO.Models.zaren_test.TextCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.TextCategory> GetTextCategoryById(int id)
        {
            var items = Context.TextCategories
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnTextCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTextCategoryCreated(ZarenTravelBO.Models.zaren_test.TextCategory item);
        partial void OnAfterTextCategoryCreated(ZarenTravelBO.Models.zaren_test.TextCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.TextCategory> CreateTextCategory(ZarenTravelBO.Models.zaren_test.TextCategory textcategory)
        {
            OnTextCategoryCreated(textcategory);

            var existingItem = Context.TextCategories
                              .Where(i => i.Id == textcategory.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TextCategories.Add(textcategory);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(textcategory).State = EntityState.Detached;
                throw;
            }

            OnAfterTextCategoryCreated(textcategory);

            return textcategory;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.TextCategory> CancelTextCategoryChanges(ZarenTravelBO.Models.zaren_test.TextCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTextCategoryUpdated(ZarenTravelBO.Models.zaren_test.TextCategory item);
        partial void OnAfterTextCategoryUpdated(ZarenTravelBO.Models.zaren_test.TextCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.TextCategory> UpdateTextCategory(int id, ZarenTravelBO.Models.zaren_test.TextCategory textcategory)
        {
            OnTextCategoryUpdated(textcategory);

            var itemToUpdate = Context.TextCategories
                              .Where(i => i.Id == textcategory.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(textcategory).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTextCategoryUpdated(textcategory);

            return textcategory;
        }

        partial void OnTextCategoryDeleted(ZarenTravelBO.Models.zaren_test.TextCategory item);
        partial void OnAfterTextCategoryDeleted(ZarenTravelBO.Models.zaren_test.TextCategory item);

        public async Task<ZarenTravelBO.Models.zaren_test.TextCategory> DeleteTextCategory(int id)
        {
            var itemToDelete = Context.TextCategories
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTextCategoryDeleted(itemToDelete);

            Reset();

            Context.TextCategories.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTextCategoryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportThemesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/themes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/themes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportThemesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/themes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/themes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnThemesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Theme> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Theme>> GetThemes(Query query = null)
        {
            var items = Context.Themes.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);

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

            OnThemesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnThemeGet(ZarenTravelBO.Models.zaren_test.Theme item);

        public async Task<ZarenTravelBO.Models.zaren_test.Theme> GetThemeById(int id)
        {
            var items = Context.Themes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnThemeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnThemeCreated(ZarenTravelBO.Models.zaren_test.Theme item);
        partial void OnAfterThemeCreated(ZarenTravelBO.Models.zaren_test.Theme item);

        public async Task<ZarenTravelBO.Models.zaren_test.Theme> CreateTheme(ZarenTravelBO.Models.zaren_test.Theme theme)
        {
            OnThemeCreated(theme);

            var existingItem = Context.Themes
                              .Where(i => i.Id == theme.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Themes.Add(theme);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(theme).State = EntityState.Detached;
                throw;
            }

            OnAfterThemeCreated(theme);

            return theme;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Theme> CancelThemeChanges(ZarenTravelBO.Models.zaren_test.Theme item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnThemeUpdated(ZarenTravelBO.Models.zaren_test.Theme item);
        partial void OnAfterThemeUpdated(ZarenTravelBO.Models.zaren_test.Theme item);

        public async Task<ZarenTravelBO.Models.zaren_test.Theme> UpdateTheme(int id, ZarenTravelBO.Models.zaren_test.Theme theme)
        {
            OnThemeUpdated(theme);

            var itemToUpdate = Context.Themes
                              .Where(i => i.Id == theme.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            theme.Agency = null;
            theme.Language = null;

            Context.Attach(theme).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterThemeUpdated(theme);

            return theme;
        }

        partial void OnThemeDeleted(ZarenTravelBO.Models.zaren_test.Theme item);
        partial void OnAfterThemeDeleted(ZarenTravelBO.Models.zaren_test.Theme item);

        public async Task<ZarenTravelBO.Models.zaren_test.Theme> DeleteTheme(int id)
        {
            var itemToDelete = Context.Themes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnThemeDeleted(itemToDelete);

            Reset();

            Context.Themes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterThemeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTownsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/towns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/towns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTownsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/towns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/towns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTownsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Town> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Town>> GetTowns(Query query = null)
        {
            var items = Context.Towns.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);

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

            OnTownsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTownGet(ZarenTravelBO.Models.zaren_test.Town item);

        public async Task<ZarenTravelBO.Models.zaren_test.Town> GetTownById(int id)
        {
            var items = Context.Towns
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnTownGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTownCreated(ZarenTravelBO.Models.zaren_test.Town item);
        partial void OnAfterTownCreated(ZarenTravelBO.Models.zaren_test.Town item);

        public async Task<ZarenTravelBO.Models.zaren_test.Town> CreateTown(ZarenTravelBO.Models.zaren_test.Town town)
        {
            OnTownCreated(town);

            var existingItem = Context.Towns
                              .Where(i => i.Id == town.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Towns.Add(town);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(town).State = EntityState.Detached;
                throw;
            }

            OnAfterTownCreated(town);

            return town;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Town> CancelTownChanges(ZarenTravelBO.Models.zaren_test.Town item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTownUpdated(ZarenTravelBO.Models.zaren_test.Town item);
        partial void OnAfterTownUpdated(ZarenTravelBO.Models.zaren_test.Town item);

        public async Task<ZarenTravelBO.Models.zaren_test.Town> UpdateTown(int id, ZarenTravelBO.Models.zaren_test.Town town)
        {
            OnTownUpdated(town);

            var itemToUpdate = Context.Towns
                              .Where(i => i.Id == town.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            town.Agency = null;
            town.Language = null;

            Context.Attach(town).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTownUpdated(town);

            return town;
        }

        partial void OnTownDeleted(ZarenTravelBO.Models.zaren_test.Town item);
        partial void OnAfterTownDeleted(ZarenTravelBO.Models.zaren_test.Town item);

        public async Task<ZarenTravelBO.Models.zaren_test.Town> DeleteTown(int id)
        {
            var itemToDelete = Context.Towns
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTownDeleted(itemToDelete);

            Reset();

            Context.Towns.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTownDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportVillagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/villages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/villages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportVillagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/villages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/villages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnVillagesRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Village> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Village>> GetVillages(Query query = null)
        {
            var items = Context.Villages.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);

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

            OnVillagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnVillageGet(ZarenTravelBO.Models.zaren_test.Village item);

        public async Task<ZarenTravelBO.Models.zaren_test.Village> GetVillageById(int id)
        {
            var items = Context.Villages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnVillageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnVillageCreated(ZarenTravelBO.Models.zaren_test.Village item);
        partial void OnAfterVillageCreated(ZarenTravelBO.Models.zaren_test.Village item);

        public async Task<ZarenTravelBO.Models.zaren_test.Village> CreateVillage(ZarenTravelBO.Models.zaren_test.Village village)
        {
            OnVillageCreated(village);

            var existingItem = Context.Villages
                              .Where(i => i.Id == village.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Villages.Add(village);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(village).State = EntityState.Detached;
                throw;
            }

            OnAfterVillageCreated(village);

            return village;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Village> CancelVillageChanges(ZarenTravelBO.Models.zaren_test.Village item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnVillageUpdated(ZarenTravelBO.Models.zaren_test.Village item);
        partial void OnAfterVillageUpdated(ZarenTravelBO.Models.zaren_test.Village item);

        public async Task<ZarenTravelBO.Models.zaren_test.Village> UpdateVillage(int id, ZarenTravelBO.Models.zaren_test.Village village)
        {
            OnVillageUpdated(village);

            var itemToUpdate = Context.Villages
                              .Where(i => i.Id == village.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();
            village.Agency = null;
            village.Language = null;

            Context.Attach(village).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterVillageUpdated(village);

            return village;
        }

        partial void OnVillageDeleted(ZarenTravelBO.Models.zaren_test.Village item);
        partial void OnAfterVillageDeleted(ZarenTravelBO.Models.zaren_test.Village item);

        public async Task<ZarenTravelBO.Models.zaren_test.Village> DeleteVillage(int id)
        {
            var itemToDelete = Context.Villages
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnVillageDeleted(itemToDelete);

            Reset();

            Context.Villages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterVillageDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportResource1SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/resource1s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/resource1s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportResource1SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/resource1s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/resource1s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnResource1SRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Resource1> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Resource1>> GetResource1S(Query query = null)
        {
            var items = Context.Resource1S.AsQueryable();


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

            OnResource1SRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnResource1Get(ZarenTravelBO.Models.zaren_test.Resource1 item);

        public async Task<ZarenTravelBO.Models.zaren_test.Resource1> GetResource1ById(int id)
        {
            var items = Context.Resource1S
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnResource1Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnResource1Created(ZarenTravelBO.Models.zaren_test.Resource1 item);
        partial void OnAfterResource1Created(ZarenTravelBO.Models.zaren_test.Resource1 item);

        public async Task<ZarenTravelBO.Models.zaren_test.Resource1> CreateResource1(ZarenTravelBO.Models.zaren_test.Resource1 resource1)
        {
            OnResource1Created(resource1);

            var existingItem = Context.Resource1S
                              .Where(i => i.Id == resource1.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Resource1S.Add(resource1);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(resource1).State = EntityState.Detached;
                throw;
            }

            OnAfterResource1Created(resource1);

            return resource1;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Resource1> CancelResource1Changes(ZarenTravelBO.Models.zaren_test.Resource1 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnResource1Updated(ZarenTravelBO.Models.zaren_test.Resource1 item);
        partial void OnAfterResource1Updated(ZarenTravelBO.Models.zaren_test.Resource1 item);

        public async Task<ZarenTravelBO.Models.zaren_test.Resource1> UpdateResource1(int id, ZarenTravelBO.Models.zaren_test.Resource1 resource1)
        {
            OnResource1Updated(resource1);

            var itemToUpdate = Context.Resource1S
                              .Where(i => i.Id == resource1.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(resource1).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterResource1Updated(resource1);

            return resource1;
        }

        partial void OnResource1Deleted(ZarenTravelBO.Models.zaren_test.Resource1 item);
        partial void OnAfterResource1Deleted(ZarenTravelBO.Models.zaren_test.Resource1 item);

        public async Task<ZarenTravelBO.Models.zaren_test.Resource1> DeleteResource1(int id)
        {
            var itemToDelete = Context.Resource1S
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnResource1Deleted(itemToDelete);

            Reset();

            Context.Resource1S.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterResource1Deleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTestsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/tests/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/tests/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTestsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/tests/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/tests/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTestsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.Test> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.Test>> GetTests(Query query = null)
        {
            var items = Context.Tests.AsQueryable();


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

            OnTestsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTestGet(ZarenTravelBO.Models.zaren_test.Test item);

        public async Task<ZarenTravelBO.Models.zaren_test.Test> GetTestById(int id)
        {
            var items = Context.Tests
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnTestGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTestCreated(ZarenTravelBO.Models.zaren_test.Test item);
        partial void OnAfterTestCreated(ZarenTravelBO.Models.zaren_test.Test item);

        public async Task<ZarenTravelBO.Models.zaren_test.Test> CreateTest(ZarenTravelBO.Models.zaren_test.Test test)
        {
            OnTestCreated(test);

            var existingItem = Context.Tests
                              .Where(i => i.Id == test.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Tests.Add(test);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(test).State = EntityState.Detached;
                throw;
            }

            OnAfterTestCreated(test);

            return test;
        }

        public async Task<ZarenTravelBO.Models.zaren_test.Test> CancelTestChanges(ZarenTravelBO.Models.zaren_test.Test item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTestUpdated(ZarenTravelBO.Models.zaren_test.Test item);
        partial void OnAfterTestUpdated(ZarenTravelBO.Models.zaren_test.Test item);

        public async Task<ZarenTravelBO.Models.zaren_test.Test> UpdateTest(int id, ZarenTravelBO.Models.zaren_test.Test test)
        {
            OnTestUpdated(test);

            var itemToUpdate = Context.Tests
                              .Where(i => i.Id == test.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(test).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTestUpdated(test);

            return test;
        }

        partial void OnTestDeleted(ZarenTravelBO.Models.zaren_test.Test item);
        partial void OnAfterTestDeleted(ZarenTravelBO.Models.zaren_test.Test item);

        public async Task<ZarenTravelBO.Models.zaren_test.Test> DeleteTest(int id)
        {
            var itemToDelete = Context.Tests
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTestDeleted(itemToDelete);

            Reset();

            Context.Tests.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTestDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAgencyContractsConfigurationByHotelsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractsconfigurationbyhotels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractsconfigurationbyhotels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsConfigurationByHotelsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_test/agencycontractsconfigurationbyhotels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_test/agencycontractsconfigurationbyhotels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsConfigurationByHotelsRead(ref IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsConfigurationByHotel> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_test.AgencyContractsConfigurationByHotel>> GetAgencyContractsConfigurationByHotels(Query query = null)
        {
            var items = Context.AgencyContractsConfigurationByHotels.AsQueryable();


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

            OnAgencyContractsConfigurationByHotelsRead(ref items);

            return await Task.FromResult(items);
        }
    }
}