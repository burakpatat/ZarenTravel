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
    public partial class zaren_prodService
    {
        zaren_prodContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly zaren_prodContext context;
        private readonly NavigationManager navigationManager;

        public zaren_prodService(zaren_prodContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);


        public async Task ExportAgenciesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgenciesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgenciesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Agency> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Agency>> GetAgencies(Query query = null)
        {
            var items = Context.Agencies.AsQueryable();

            items = items.Include(i => i.AgencyManager);
            items = items.Include(i => i.Country1);
            items = items.Include(i => i.InvoiceType);

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

        partial void OnAgencyGet(ZarenTravelBO.Models.zaren_prod.Agency item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Agency> GetAgencyById(int id)
        {
            var items = Context.Agencies
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.AgencyManager);
            items = items.Include(i => i.Country1);
            items = items.Include(i => i.InvoiceType);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyCreated(ZarenTravelBO.Models.zaren_prod.Agency item);
        partial void OnAfterAgencyCreated(ZarenTravelBO.Models.zaren_prod.Agency item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Agency> CreateAgency(ZarenTravelBO.Models.zaren_prod.Agency agency)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.Agency> CancelAgencyChanges(ZarenTravelBO.Models.zaren_prod.Agency item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyUpdated(ZarenTravelBO.Models.zaren_prod.Agency item);
        partial void OnAfterAgencyUpdated(ZarenTravelBO.Models.zaren_prod.Agency item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Agency> UpdateAgency(int id, ZarenTravelBO.Models.zaren_prod.Agency agency)
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
            agency.Country1 = null;
            agency.InvoiceType = null;

            Context.Attach(agency).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyUpdated(agency);

            return agency;
        }

        partial void OnAgencyDeleted(ZarenTravelBO.Models.zaren_prod.Agency item);
        partial void OnAfterAgencyDeleted(ZarenTravelBO.Models.zaren_prod.Agency item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Agency> DeleteAgency(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycmsdevices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycmsdevices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyCmsDevicesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycmsdevices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycmsdevices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyCmsDevicesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice>> GetAgencyCmsDevices(Query query = null)
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

        partial void OnAgencyCmsDeviceGet(ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice> GetAgencyCmsDeviceById(int id)
        {
            var items = Context.AgencyCmsDevices
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyCmsDeviceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyCmsDeviceCreated(ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice item);
        partial void OnAfterAgencyCmsDeviceCreated(ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice> CreateAgencyCmsDevice(ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice agencycmsdevice)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice> CancelAgencyCmsDeviceChanges(ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyCmsDeviceUpdated(ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice item);
        partial void OnAfterAgencyCmsDeviceUpdated(ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice> UpdateAgencyCmsDevice(int id, ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice agencycmsdevice)
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

        partial void OnAgencyCmsDeviceDeleted(ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice item);
        partial void OnAfterAgencyCmsDeviceDeleted(ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsDevice> DeleteAgencyCmsDevice(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycmssectiontypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycmssectiontypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyCmsSectionTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycmssectiontypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycmssectiontypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyCmsSectionTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType>> GetAgencyCmsSectionTypes(Query query = null)
        {
            var items = Context.AgencyCmsSectionTypes.AsQueryable();


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

        partial void OnAgencyCmsSectionTypeGet(ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType> GetAgencyCmsSectionTypeById(int id)
        {
            var items = Context.AgencyCmsSectionTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyCmsSectionTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyCmsSectionTypeCreated(ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType item);
        partial void OnAfterAgencyCmsSectionTypeCreated(ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType> CreateAgencyCmsSectionType(ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType agencycmssectiontype)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType> CancelAgencyCmsSectionTypeChanges(ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyCmsSectionTypeUpdated(ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType item);
        partial void OnAfterAgencyCmsSectionTypeUpdated(ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType> UpdateAgencyCmsSectionType(int id, ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType agencycmssectiontype)
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

            Context.Attach(agencycmssectiontype).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyCmsSectionTypeUpdated(agencycmssectiontype);

            return agencycmssectiontype;
        }

        partial void OnAgencyCmsSectionTypeDeleted(ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType item);
        partial void OnAfterAgencyCmsSectionTypeDeleted(ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsSectionType> DeleteAgencyCmsSectionType(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycmssocialmediaurls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycmssocialmediaurls/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyCmsSocialMediaUrlsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycmssocialmediaurls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycmssocialmediaurls/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyCmsSocialMediaUrlsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl>> GetAgencyCmsSocialMediaUrls(Query query = null)
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

        partial void OnAgencyCmsSocialMediaUrlGet(ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl> GetAgencyCmsSocialMediaUrlById(int id)
        {
            var items = Context.AgencyCmsSocialMediaUrls
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyCmsSocialMediaUrlGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyCmsSocialMediaUrlCreated(ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl item);
        partial void OnAfterAgencyCmsSocialMediaUrlCreated(ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl> CreateAgencyCmsSocialMediaUrl(ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl agencycmssocialmediaurl)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl> CancelAgencyCmsSocialMediaUrlChanges(ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyCmsSocialMediaUrlUpdated(ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl item);
        partial void OnAfterAgencyCmsSocialMediaUrlUpdated(ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl> UpdateAgencyCmsSocialMediaUrl(int id, ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl agencycmssocialmediaurl)
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

        partial void OnAgencyCmsSocialMediaUrlDeleted(ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl item);
        partial void OnAfterAgencyCmsSocialMediaUrlDeleted(ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsSocialMediaUrl> DeleteAgencyCmsSocialMediaUrl(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycmsthemes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycmsthemes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyCmsThemesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycmsthemes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycmsthemes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyCmsThemesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme>> GetAgencyCmsThemes(Query query = null)
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

        partial void OnAgencyCmsThemeGet(ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme> GetAgencyCmsThemeById(int id)
        {
            var items = Context.AgencyCmsThemes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyCmsThemeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyCmsThemeCreated(ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme item);
        partial void OnAfterAgencyCmsThemeCreated(ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme> CreateAgencyCmsTheme(ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme agencycmstheme)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme> CancelAgencyCmsThemeChanges(ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyCmsThemeUpdated(ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme item);
        partial void OnAfterAgencyCmsThemeUpdated(ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme> UpdateAgencyCmsTheme(int id, ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme agencycmstheme)
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

        partial void OnAgencyCmsThemeDeleted(ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme item);
        partial void OnAfterAgencyCmsThemeDeleted(ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCmsTheme> DeleteAgencyCmsTheme(int id)
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
    
        public async Task ExportAgencyContractsClosedToursToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractsclosedtours/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractsclosedtours/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsClosedToursToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractsclosedtours/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractsclosedtours/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsClosedToursRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour>> GetAgencyContractsClosedTours(Query query = null)
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

        partial void OnAgencyContractsClosedTourGet(ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour> GetAgencyContractsClosedTourById(int id)
        {
            var items = Context.AgencyContractsClosedTours
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsClosedTourGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsClosedTourCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour item);
        partial void OnAfterAgencyContractsClosedTourCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour> CreateAgencyContractsClosedTour(ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour agencycontractsclosedtour)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour> CancelAgencyContractsClosedTourChanges(ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsClosedTourUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour item);
        partial void OnAfterAgencyContractsClosedTourUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour> UpdateAgencyContractsClosedTour(int id, ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour agencycontractsclosedtour)
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

        partial void OnAgencyContractsClosedTourDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour item);
        partial void OnAfterAgencyContractsClosedTourDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsClosedTour> DeleteAgencyContractsClosedTour(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractshotelcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractshotelcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsHotelCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractshotelcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractshotelcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsHotelCategoriesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory>> GetAgencyContractsHotelCategories(Query query = null)
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

        partial void OnAgencyContractsHotelCategoryGet(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory> GetAgencyContractsHotelCategoryById(int id)
        {
            var items = Context.AgencyContractsHotelCategories
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsHotelCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsHotelCategoryCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory item);
        partial void OnAfterAgencyContractsHotelCategoryCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory> CreateAgencyContractsHotelCategory(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory agencycontractshotelcategory)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory> CancelAgencyContractsHotelCategoryChanges(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsHotelCategoryUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory item);
        partial void OnAfterAgencyContractsHotelCategoryUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory> UpdateAgencyContractsHotelCategory(int id, ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory agencycontractshotelcategory)
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

        partial void OnAgencyContractsHotelCategoryDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory item);
        partial void OnAfterAgencyContractsHotelCategoryDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelCategory> DeleteAgencyContractsHotelCategory(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractshotelinformations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractshotelinformations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsHotelInformationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractshotelinformations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractshotelinformations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsHotelInformationsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation>> GetAgencyContractsHotelInformations(Query query = null)
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

        partial void OnAgencyContractsHotelInformationGet(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation> GetAgencyContractsHotelInformationById(int id)
        {
            var items = Context.AgencyContractsHotelInformations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsHotelInformationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsHotelInformationCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation item);
        partial void OnAfterAgencyContractsHotelInformationCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation> CreateAgencyContractsHotelInformation(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation agencycontractshotelinformation)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation> CancelAgencyContractsHotelInformationChanges(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsHotelInformationUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation item);
        partial void OnAfterAgencyContractsHotelInformationUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation> UpdateAgencyContractsHotelInformation(int id, ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation agencycontractshotelinformation)
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

        partial void OnAgencyContractsHotelInformationDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation item);
        partial void OnAfterAgencyContractsHotelInformationDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformation> DeleteAgencyContractsHotelInformation(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractshotelinformationimages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractshotelinformationimages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsHotelInformationImagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractshotelinformationimages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractshotelinformationimages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsHotelInformationImagesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage>> GetAgencyContractsHotelInformationImages(Query query = null)
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

        partial void OnAgencyContractsHotelInformationImageGet(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage> GetAgencyContractsHotelInformationImageById(int id)
        {
            var items = Context.AgencyContractsHotelInformationImages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsHotelInformationImageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsHotelInformationImageCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage item);
        partial void OnAfterAgencyContractsHotelInformationImageCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage> CreateAgencyContractsHotelInformationImage(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage agencycontractshotelinformationimage)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage> CancelAgencyContractsHotelInformationImageChanges(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsHotelInformationImageUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage item);
        partial void OnAfterAgencyContractsHotelInformationImageUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage> UpdateAgencyContractsHotelInformationImage(int id, ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage agencycontractshotelinformationimage)
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

        partial void OnAgencyContractsHotelInformationImageDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage item);
        partial void OnAfterAgencyContractsHotelInformationImageDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelInformationImage> DeleteAgencyContractsHotelInformationImage(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractshotelsconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractshotelsconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsHotelsConfigurationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractshotelsconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractshotelsconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsHotelsConfigurationsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration>> GetAgencyContractsHotelsConfigurations(Query query = null)
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

        partial void OnAgencyContractsHotelsConfigurationGet(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration> GetAgencyContractsHotelsConfigurationById(int id)
        {
            var items = Context.AgencyContractsHotelsConfigurations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsHotelsConfigurationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsHotelsConfigurationCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration item);
        partial void OnAfterAgencyContractsHotelsConfigurationCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration> CreateAgencyContractsHotelsConfiguration(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration agencycontractshotelsconfiguration)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration> CancelAgencyContractsHotelsConfigurationChanges(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsHotelsConfigurationUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration item);
        partial void OnAfterAgencyContractsHotelsConfigurationUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration> UpdateAgencyContractsHotelsConfiguration(int id, ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration agencycontractshotelsconfiguration)
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

        partial void OnAgencyContractsHotelsConfigurationDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration item);
        partial void OnAfterAgencyContractsHotelsConfigurationDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfiguration> DeleteAgencyContractsHotelsConfiguration(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractshotelsconfigurationdays/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractshotelsconfigurationdays/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsHotelsConfigurationDaysToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractshotelsconfigurationdays/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractshotelsconfigurationdays/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsHotelsConfigurationDaysRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay>> GetAgencyContractsHotelsConfigurationDays(Query query = null)
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

        partial void OnAgencyContractsHotelsConfigurationDayGet(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay> GetAgencyContractsHotelsConfigurationDayById(int id)
        {
            var items = Context.AgencyContractsHotelsConfigurationDays
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsHotelsConfigurationDayGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsHotelsConfigurationDayCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay item);
        partial void OnAfterAgencyContractsHotelsConfigurationDayCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay> CreateAgencyContractsHotelsConfigurationDay(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay agencycontractshotelsconfigurationday)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay> CancelAgencyContractsHotelsConfigurationDayChanges(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsHotelsConfigurationDayUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay item);
        partial void OnAfterAgencyContractsHotelsConfigurationDayUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay> UpdateAgencyContractsHotelsConfigurationDay(int id, ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay agencycontractshotelsconfigurationday)
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

        partial void OnAgencyContractsHotelsConfigurationDayDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay item);
        partial void OnAfterAgencyContractsHotelsConfigurationDayDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsConfigurationDay> DeleteAgencyContractsHotelsConfigurationDay(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractshotelsmenus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractshotelsmenus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsHotelsMenusToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractshotelsmenus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractshotelsmenus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsHotelsMenusRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu>> GetAgencyContractsHotelsMenus(Query query = null)
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

        partial void OnAgencyContractsHotelsMenuGet(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu> GetAgencyContractsHotelsMenuById(int id)
        {
            var items = Context.AgencyContractsHotelsMenus
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsHotelsMenuGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsHotelsMenuCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu item);
        partial void OnAfterAgencyContractsHotelsMenuCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu> CreateAgencyContractsHotelsMenu(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu agencycontractshotelsmenu)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu> CancelAgencyContractsHotelsMenuChanges(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsHotelsMenuUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu item);
        partial void OnAfterAgencyContractsHotelsMenuUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu> UpdateAgencyContractsHotelsMenu(int id, ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu agencycontractshotelsmenu)
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

        partial void OnAgencyContractsHotelsMenuDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu item);
        partial void OnAfterAgencyContractsHotelsMenuDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsHotelsMenu> DeleteAgencyContractsHotelsMenu(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractsinsurancebasicdata/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractsinsurancebasicdata/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsInsuranceBasicDataToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractsinsurancebasicdata/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractsinsurancebasicdata/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsInsuranceBasicDataRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum>> GetAgencyContractsInsuranceBasicData(Query query = null)
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

        partial void OnAgencyContractsInsuranceBasicDatumGet(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum> GetAgencyContractsInsuranceBasicDatumById(int id)
        {
            var items = Context.AgencyContractsInsuranceBasicData
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsInsuranceBasicDatumGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsInsuranceBasicDatumCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum item);
        partial void OnAfterAgencyContractsInsuranceBasicDatumCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum> CreateAgencyContractsInsuranceBasicDatum(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum agencycontractsinsurancebasicdatum)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum> CancelAgencyContractsInsuranceBasicDatumChanges(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsInsuranceBasicDatumUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum item);
        partial void OnAfterAgencyContractsInsuranceBasicDatumUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum> UpdateAgencyContractsInsuranceBasicDatum(int id, ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum agencycontractsinsurancebasicdatum)
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

        partial void OnAgencyContractsInsuranceBasicDatumDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum item);
        partial void OnAfterAgencyContractsInsuranceBasicDatumDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceBasicDatum> DeleteAgencyContractsInsuranceBasicDatum(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractsinsuranceselectedlanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractsinsuranceselectedlanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsInsuranceSelectedLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractsinsuranceselectedlanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractsinsuranceselectedlanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsInsuranceSelectedLanguagesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage>> GetAgencyContractsInsuranceSelectedLanguages(Query query = null)
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

        partial void OnAgencyContractsInsuranceSelectedLanguageGet(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage> GetAgencyContractsInsuranceSelectedLanguageById(int id)
        {
            var items = Context.AgencyContractsInsuranceSelectedLanguages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsInsuranceSelectedLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsInsuranceSelectedLanguageCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage item);
        partial void OnAfterAgencyContractsInsuranceSelectedLanguageCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage> CreateAgencyContractsInsuranceSelectedLanguage(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage agencycontractsinsuranceselectedlanguage)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage> CancelAgencyContractsInsuranceSelectedLanguageChanges(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsInsuranceSelectedLanguageUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage item);
        partial void OnAfterAgencyContractsInsuranceSelectedLanguageUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage> UpdateAgencyContractsInsuranceSelectedLanguage(int id, ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage agencycontractsinsuranceselectedlanguage)
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

        partial void OnAgencyContractsInsuranceSelectedLanguageDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage item);
        partial void OnAfterAgencyContractsInsuranceSelectedLanguageDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedLanguage> DeleteAgencyContractsInsuranceSelectedLanguage(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractsinsuranceselectedproducttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractsinsuranceselectedproducttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsInsuranceSelectedProductTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractsinsuranceselectedproducttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractsinsuranceselectedproducttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsInsuranceSelectedProductTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType>> GetAgencyContractsInsuranceSelectedProductTypes(Query query = null)
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

        partial void OnAgencyContractsInsuranceSelectedProductTypeGet(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType> GetAgencyContractsInsuranceSelectedProductTypeById(int id)
        {
            var items = Context.AgencyContractsInsuranceSelectedProductTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsInsuranceSelectedProductTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsInsuranceSelectedProductTypeCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType item);
        partial void OnAfterAgencyContractsInsuranceSelectedProductTypeCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType> CreateAgencyContractsInsuranceSelectedProductType(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType agencycontractsinsuranceselectedproducttype)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType> CancelAgencyContractsInsuranceSelectedProductTypeChanges(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsInsuranceSelectedProductTypeUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType item);
        partial void OnAfterAgencyContractsInsuranceSelectedProductTypeUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType> UpdateAgencyContractsInsuranceSelectedProductType(int id, ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType agencycontractsinsuranceselectedproducttype)
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

        partial void OnAgencyContractsInsuranceSelectedProductTypeDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType item);
        partial void OnAfterAgencyContractsInsuranceSelectedProductTypeDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceSelectedProductType> DeleteAgencyContractsInsuranceSelectedProductType(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractsinsurancetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractsinsurancetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsInsuranceTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractsinsurancetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractsinsurancetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsInsuranceTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType>> GetAgencyContractsInsuranceTypes(Query query = null)
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

        partial void OnAgencyContractsInsuranceTypeGet(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType> GetAgencyContractsInsuranceTypeById(int id)
        {
            var items = Context.AgencyContractsInsuranceTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyContractsInsuranceTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyContractsInsuranceTypeCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType item);
        partial void OnAfterAgencyContractsInsuranceTypeCreated(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType> CreateAgencyContractsInsuranceType(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType agencycontractsinsurancetype)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType> CancelAgencyContractsInsuranceTypeChanges(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyContractsInsuranceTypeUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType item);
        partial void OnAfterAgencyContractsInsuranceTypeUpdated(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType> UpdateAgencyContractsInsuranceType(int id, ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType agencycontractsinsurancetype)
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

        partial void OnAgencyContractsInsuranceTypeDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType item);
        partial void OnAfterAgencyContractsInsuranceTypeDeleted(ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyContractsInsuranceType> DeleteAgencyContractsInsuranceType(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycreditdeposits/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycreditdeposits/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyCreditDepositsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycreditdeposits/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycreditdeposits/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyCreditDepositsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit>> GetAgencyCreditDeposits(Query query = null)
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

        partial void OnAgencyCreditDepositGet(ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit> GetAgencyCreditDepositById(int id)
        {
            var items = Context.AgencyCreditDeposits
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyCreditDepositGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyCreditDepositCreated(ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit item);
        partial void OnAfterAgencyCreditDepositCreated(ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit> CreateAgencyCreditDeposit(ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit agencycreditdeposit)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit> CancelAgencyCreditDepositChanges(ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyCreditDepositUpdated(ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit item);
        partial void OnAfterAgencyCreditDepositUpdated(ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit> UpdateAgencyCreditDeposit(int id, ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit agencycreditdeposit)
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

        partial void OnAgencyCreditDepositDeleted(ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit item);
        partial void OnAfterAgencyCreditDepositDeleted(ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyCreditDeposit> DeleteAgencyCreditDeposit(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymanagers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymanagers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyManagersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymanagers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymanagers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyManagersRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyManager> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyManager>> GetAgencyManagers(Query query = null)
        {
            var items = Context.AgencyManagers.AsQueryable();

            items = items.Include(i => i.AgencyMicroSite);

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

        partial void OnAgencyManagerGet(ZarenTravelBO.Models.zaren_prod.AgencyManager item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyManager> GetAgencyManagerById(int id)
        {
            var items = Context.AgencyManagers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.AgencyMicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyManagerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyManagerCreated(ZarenTravelBO.Models.zaren_prod.AgencyManager item);
        partial void OnAfterAgencyManagerCreated(ZarenTravelBO.Models.zaren_prod.AgencyManager item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyManager> CreateAgencyManager(ZarenTravelBO.Models.zaren_prod.AgencyManager agencymanager)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyManager> CancelAgencyManagerChanges(ZarenTravelBO.Models.zaren_prod.AgencyManager item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyManagerUpdated(ZarenTravelBO.Models.zaren_prod.AgencyManager item);
        partial void OnAfterAgencyManagerUpdated(ZarenTravelBO.Models.zaren_prod.AgencyManager item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyManager> UpdateAgencyManager(int id, ZarenTravelBO.Models.zaren_prod.AgencyManager agencymanager)
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
            agencymanager.AgencyMicroSite = null;

            Context.Attach(agencymanager).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyManagerUpdated(agencymanager);

            return agencymanager;
        }

        partial void OnAgencyManagerDeleted(ZarenTravelBO.Models.zaren_prod.AgencyManager item);
        partial void OnAfterAgencyManagerDeleted(ZarenTravelBO.Models.zaren_prod.AgencyManager item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyManager> DeleteAgencyManager(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositeapiproductproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositeapiproductproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteApiProductProvidersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositeapiproductproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositeapiproductproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteApiProductProvidersRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider>> GetAgencyMicroSiteApiProductProviders(Query query = null)
        {
            var items = Context.AgencyMicroSiteApiProductProviders.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);

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

        partial void OnAgencyMicroSiteApiProductProviderGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider> GetAgencyMicroSiteApiProductProviderById(int id)
        {
            var items = Context.AgencyMicroSiteApiProductProviders
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteApiProductProviderGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteApiProductProviderCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider item);
        partial void OnAfterAgencyMicroSiteApiProductProviderCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider> CreateAgencyMicroSiteApiProductProvider(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider agencymicrositeapiproductprovider)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider> CancelAgencyMicroSiteApiProductProviderChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteApiProductProviderUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider item);
        partial void OnAfterAgencyMicroSiteApiProductProviderUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider> UpdateAgencyMicroSiteApiProductProvider(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider agencymicrositeapiproductprovider)
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
            agencymicrositeapiproductprovider.Agency = null;
            agencymicrositeapiproductprovider.AgencyMicroSite = null;

            Context.Attach(agencymicrositeapiproductprovider).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteApiProductProviderUpdated(agencymicrositeapiproductprovider);

            return agencymicrositeapiproductprovider;
        }

        partial void OnAgencyMicroSiteApiProductProviderDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider item);
        partial void OnAfterAgencyMicroSiteApiProductProviderDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteApiProductProvider> DeleteAgencyMicroSiteApiProductProvider(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositedesigns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositedesigns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteDesignsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositedesigns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositedesigns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteDesignsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign>> GetAgencyMicroSiteDesigns(Query query = null)
        {
            var items = Context.AgencyMicroSiteDesigns.AsQueryable();

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

            OnAgencyMicroSiteDesignsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteDesignGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign> GetAgencyMicroSiteDesignById(int id)
        {
            var items = Context.AgencyMicroSiteDesigns
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteDesignGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteDesignCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign item);
        partial void OnAfterAgencyMicroSiteDesignCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign> CreateAgencyMicroSiteDesign(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign agencymicrositedesign)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign> CancelAgencyMicroSiteDesignChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteDesignUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign item);
        partial void OnAfterAgencyMicroSiteDesignUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign> UpdateAgencyMicroSiteDesign(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign agencymicrositedesign)
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
            agencymicrositedesign.Agency = null;

            Context.Attach(agencymicrositedesign).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteDesignUpdated(agencymicrositedesign);

            return agencymicrositedesign;
        }

        partial void OnAgencyMicroSiteDesignDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign item);
        partial void OnAfterAgencyMicroSiteDesignDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDesign> DeleteAgencyMicroSiteDesign(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositedomainlanguagesettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositedomainlanguagesettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteDomainLanguageSettingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositedomainlanguagesettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositedomainlanguagesettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteDomainLanguageSettingsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting>> GetAgencyMicroSiteDomainLanguageSettings(Query query = null)
        {
            var items = Context.AgencyMicroSiteDomainLanguageSettings.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);

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

        partial void OnAgencyMicroSiteDomainLanguageSettingGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting> GetAgencyMicroSiteDomainLanguageSettingById(int id)
        {
            var items = Context.AgencyMicroSiteDomainLanguageSettings
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteDomainLanguageSettingGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteDomainLanguageSettingCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting item);
        partial void OnAfterAgencyMicroSiteDomainLanguageSettingCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting> CreateAgencyMicroSiteDomainLanguageSetting(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting agencymicrositedomainlanguagesetting)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting> CancelAgencyMicroSiteDomainLanguageSettingChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteDomainLanguageSettingUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting item);
        partial void OnAfterAgencyMicroSiteDomainLanguageSettingUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting> UpdateAgencyMicroSiteDomainLanguageSetting(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting agencymicrositedomainlanguagesetting)
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
            agencymicrositedomainlanguagesetting.Agency = null;
            agencymicrositedomainlanguagesetting.AgencyMicroSite = null;

            Context.Attach(agencymicrositedomainlanguagesetting).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteDomainLanguageSettingUpdated(agencymicrositedomainlanguagesetting);

            return agencymicrositedomainlanguagesetting;
        }

        partial void OnAgencyMicroSiteDomainLanguageSettingDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting item);
        partial void OnAfterAgencyMicroSiteDomainLanguageSettingDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomainLanguageSetting> DeleteAgencyMicroSiteDomainLanguageSetting(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositedomains/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositedomains/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteDomainsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositedomains/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositedomains/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteDomainsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain>> GetAgencyMicroSiteDomains(Query query = null)
        {
            var items = Context.AgencyMicroSiteDomains.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);

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

        partial void OnAgencyMicroSiteDomainGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain> GetAgencyMicroSiteDomainById(int id)
        {
            var items = Context.AgencyMicroSiteDomains
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteDomainGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteDomainCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain item);
        partial void OnAfterAgencyMicroSiteDomainCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain> CreateAgencyMicroSiteDomain(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain agencymicrositedomain)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain> CancelAgencyMicroSiteDomainChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteDomainUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain item);
        partial void OnAfterAgencyMicroSiteDomainUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain> UpdateAgencyMicroSiteDomain(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain agencymicrositedomain)
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
            agencymicrositedomain.Agency = null;
            agencymicrositedomain.AgencyMicroSite = null;

            Context.Attach(agencymicrositedomain).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteDomainUpdated(agencymicrositedomain);

            return agencymicrositedomain;
        }

        partial void OnAgencyMicroSiteDomainDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain item);
        partial void OnAfterAgencyMicroSiteDomainDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteDomain> DeleteAgencyMicroSiteDomain(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositepaymentproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositepaymentproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSitePaymentProvidersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositepaymentproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositepaymentproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSitePaymentProvidersRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider>> GetAgencyMicroSitePaymentProviders(Query query = null)
        {
            var items = Context.AgencyMicroSitePaymentProviders.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);

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

        partial void OnAgencyMicroSitePaymentProviderGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider> GetAgencyMicroSitePaymentProviderById(int id)
        {
            var items = Context.AgencyMicroSitePaymentProviders
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSitePaymentProviderGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSitePaymentProviderCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider item);
        partial void OnAfterAgencyMicroSitePaymentProviderCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider> CreateAgencyMicroSitePaymentProvider(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider agencymicrositepaymentprovider)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider> CancelAgencyMicroSitePaymentProviderChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSitePaymentProviderUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider item);
        partial void OnAfterAgencyMicroSitePaymentProviderUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider> UpdateAgencyMicroSitePaymentProvider(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider agencymicrositepaymentprovider)
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
            agencymicrositepaymentprovider.Agency = null;
            agencymicrositepaymentprovider.AgencyMicroSite = null;

            Context.Attach(agencymicrositepaymentprovider).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSitePaymentProviderUpdated(agencymicrositepaymentprovider);

            return agencymicrositepaymentprovider;
        }

        partial void OnAgencyMicroSitePaymentProviderDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider item);
        partial void OnAfterAgencyMicroSitePaymentProviderDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitePaymentProvider> DeleteAgencyMicroSitePaymentProvider(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositeproperties/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositeproperties/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSitePropertiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositeproperties/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositeproperties/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSitePropertiesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty>> GetAgencyMicroSiteProperties(Query query = null)
        {
            var items = Context.AgencyMicroSiteProperties.AsQueryable();

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

            OnAgencyMicroSitePropertiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSitePropertyGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty> GetAgencyMicroSitePropertyById(int id)
        {
            var items = Context.AgencyMicroSiteProperties
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSitePropertyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSitePropertyCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty item);
        partial void OnAfterAgencyMicroSitePropertyCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty> CreateAgencyMicroSiteProperty(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty agencymicrositeproperty)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty> CancelAgencyMicroSitePropertyChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSitePropertyUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty item);
        partial void OnAfterAgencyMicroSitePropertyUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty> UpdateAgencyMicroSiteProperty(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty agencymicrositeproperty)
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
            agencymicrositeproperty.Agency = null;

            Context.Attach(agencymicrositeproperty).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSitePropertyUpdated(agencymicrositeproperty);

            return agencymicrositeproperty;
        }

        partial void OnAgencyMicroSitePropertyDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty item);
        partial void OnAfterAgencyMicroSitePropertyDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteProperty> DeleteAgencyMicroSiteProperty(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrosites/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrosites/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSitesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrosites/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrosites/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSitesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSite> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSite>> GetAgencyMicroSites(Query query = null)
        {
            var items = Context.AgencyMicroSites.AsQueryable();

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

            OnAgencyMicroSitesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAgencyMicroSiteGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSite item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSite> GetAgencyMicroSiteById(int id)
        {
            var items = Context.AgencyMicroSites
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSite item);
        partial void OnAfterAgencyMicroSiteCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSite item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSite> CreateAgencyMicroSite(ZarenTravelBO.Models.zaren_prod.AgencyMicroSite agencymicrosite)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSite> CancelAgencyMicroSiteChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSite item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSite item);
        partial void OnAfterAgencyMicroSiteUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSite item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSite> UpdateAgencyMicroSite(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSite agencymicrosite)
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
            agencymicrosite.Agency = null;

            Context.Attach(agencymicrosite).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteUpdated(agencymicrosite);

            return agencymicrosite;
        }

        partial void OnAgencyMicroSiteDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSite item);
        partial void OnAfterAgencyMicroSiteDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSite item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSite> DeleteAgencyMicroSite(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingpassengerdata/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingpassengerdata/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingPassengerDataToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingpassengerdata/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingpassengerdata/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingPassengerDataRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum>> GetAgencyMicroSiteSettingPassengerData(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingPassengerData.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);

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

        partial void OnAgencyMicroSiteSettingPassengerDatumGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum> GetAgencyMicroSiteSettingPassengerDatumById(int id)
        {
            var items = Context.AgencyMicroSiteSettingPassengerData
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingPassengerDatumGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingPassengerDatumCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum item);
        partial void OnAfterAgencyMicroSiteSettingPassengerDatumCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum> CreateAgencyMicroSiteSettingPassengerDatum(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum agencymicrositesettingpassengerdatum)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum> CancelAgencyMicroSiteSettingPassengerDatumChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingPassengerDatumUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum item);
        partial void OnAfterAgencyMicroSiteSettingPassengerDatumUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum> UpdateAgencyMicroSiteSettingPassengerDatum(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum agencymicrositesettingpassengerdatum)
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
            agencymicrositesettingpassengerdatum.Agency = null;
            agencymicrositesettingpassengerdatum.AgencyMicroSite = null;

            Context.Attach(agencymicrositesettingpassengerdatum).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingPassengerDatumUpdated(agencymicrositesettingpassengerdatum);

            return agencymicrositesettingpassengerdatum;
        }

        partial void OnAgencyMicroSiteSettingPassengerDatumDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum item);
        partial void OnAfterAgencyMicroSiteSettingPassengerDatumDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingPassengerDatum> DeleteAgencyMicroSiteSettingPassengerDatum(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsaccommodationsearchresults/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsaccommodationsearchresults/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsAccommodationSearchResultsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsaccommodationsearchresults/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsaccommodationsearchresults/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsAccommodationSearchResultsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult>> GetAgencyMicroSiteSettingsAccommodationSearchResults(Query query = null)
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

        partial void OnAgencyMicroSiteSettingsAccommodationSearchResultGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult> GetAgencyMicroSiteSettingsAccommodationSearchResultById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsAccommodationSearchResults
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsAccommodationSearchResultGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsAccommodationSearchResultCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult item);
        partial void OnAfterAgencyMicroSiteSettingsAccommodationSearchResultCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult> CreateAgencyMicroSiteSettingsAccommodationSearchResult(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult agencymicrositesettingsaccommodationsearchresult)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult> CancelAgencyMicroSiteSettingsAccommodationSearchResultChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsAccommodationSearchResultUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult item);
        partial void OnAfterAgencyMicroSiteSettingsAccommodationSearchResultUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult> UpdateAgencyMicroSiteSettingsAccommodationSearchResult(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult agencymicrositesettingsaccommodationsearchresult)
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

        partial void OnAgencyMicroSiteSettingsAccommodationSearchResultDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult item);
        partial void OnAfterAgencyMicroSiteSettingsAccommodationSearchResultDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsAccommodationSearchResult> DeleteAgencyMicroSiteSettingsAccommodationSearchResult(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsbookingprocesses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsbookingprocesses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsBookingProcessesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsbookingprocesses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsbookingprocesses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsBookingProcessesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess>> GetAgencyMicroSiteSettingsBookingProcesses(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsBookingProcesses.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);

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

        partial void OnAgencyMicroSiteSettingsBookingProcessGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess> GetAgencyMicroSiteSettingsBookingProcessById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsBookingProcesses
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsBookingProcessGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsBookingProcessCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess item);
        partial void OnAfterAgencyMicroSiteSettingsBookingProcessCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess> CreateAgencyMicroSiteSettingsBookingProcess(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess agencymicrositesettingsbookingprocess)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess> CancelAgencyMicroSiteSettingsBookingProcessChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsBookingProcessUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess item);
        partial void OnAfterAgencyMicroSiteSettingsBookingProcessUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess> UpdateAgencyMicroSiteSettingsBookingProcess(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess agencymicrositesettingsbookingprocess)
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
            agencymicrositesettingsbookingprocess.Agency = null;
            agencymicrositesettingsbookingprocess.AgencyMicroSite = null;

            Context.Attach(agencymicrositesettingsbookingprocess).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsBookingProcessUpdated(agencymicrositesettingsbookingprocess);

            return agencymicrositesettingsbookingprocess;
        }

        partial void OnAgencyMicroSiteSettingsBookingProcessDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess item);
        partial void OnAfterAgencyMicroSiteSettingsBookingProcessDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingProcess> DeleteAgencyMicroSiteSettingsBookingProcess(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsbookingreplicatormodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsbookingreplicatormodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsBookingReplicatorModesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsbookingreplicatormodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsbookingreplicatormodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsBookingReplicatorModesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode>> GetAgencyMicroSiteSettingsBookingReplicatorModes(Query query = null)
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

        partial void OnAgencyMicroSiteSettingsBookingReplicatorModeGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode> GetAgencyMicroSiteSettingsBookingReplicatorModeById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsBookingReplicatorModes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsBookingReplicatorModeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsBookingReplicatorModeCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode item);
        partial void OnAfterAgencyMicroSiteSettingsBookingReplicatorModeCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode> CreateAgencyMicroSiteSettingsBookingReplicatorMode(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode agencymicrositesettingsbookingreplicatormode)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode> CancelAgencyMicroSiteSettingsBookingReplicatorModeChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsBookingReplicatorModeUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode item);
        partial void OnAfterAgencyMicroSiteSettingsBookingReplicatorModeUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode> UpdateAgencyMicroSiteSettingsBookingReplicatorMode(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode agencymicrositesettingsbookingreplicatormode)
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

        partial void OnAgencyMicroSiteSettingsBookingReplicatorModeDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode item);
        partial void OnAfterAgencyMicroSiteSettingsBookingReplicatorModeDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsBookingReplicatorMode> DeleteAgencyMicroSiteSettingsBookingReplicatorMode(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsemailvouchers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsemailvouchers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsEmailVouchersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsemailvouchers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsemailvouchers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsEmailVouchersRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher>> GetAgencyMicroSiteSettingsEmailVouchers(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsEmailVouchers.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);

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

        partial void OnAgencyMicroSiteSettingsEmailVoucherGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher> GetAgencyMicroSiteSettingsEmailVoucherById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsEmailVouchers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsEmailVoucherGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsEmailVoucherCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher item);
        partial void OnAfterAgencyMicroSiteSettingsEmailVoucherCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher> CreateAgencyMicroSiteSettingsEmailVoucher(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher agencymicrositesettingsemailvoucher)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher> CancelAgencyMicroSiteSettingsEmailVoucherChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsEmailVoucherUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher item);
        partial void OnAfterAgencyMicroSiteSettingsEmailVoucherUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher> UpdateAgencyMicroSiteSettingsEmailVoucher(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher agencymicrositesettingsemailvoucher)
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
            agencymicrositesettingsemailvoucher.Agency = null;
            agencymicrositesettingsemailvoucher.AgencyMicroSite = null;

            Context.Attach(agencymicrositesettingsemailvoucher).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsEmailVoucherUpdated(agencymicrositesettingsemailvoucher);

            return agencymicrositesettingsemailvoucher;
        }

        partial void OnAgencyMicroSiteSettingsEmailVoucherDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher item);
        partial void OnAfterAgencyMicroSiteSettingsEmailVoucherDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEmailVoucher> DeleteAgencyMicroSiteSettingsEmailVoucher(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsenablemultidays/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsenablemultidays/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsEnableMultiDaysToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsenablemultidays/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsenablemultidays/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsEnableMultiDaysRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay>> GetAgencyMicroSiteSettingsEnableMultiDays(Query query = null)
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

        partial void OnAgencyMicroSiteSettingsEnableMultiDayGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay> GetAgencyMicroSiteSettingsEnableMultiDayById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsEnableMultiDays
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsEnableMultiDayGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsEnableMultiDayCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay item);
        partial void OnAfterAgencyMicroSiteSettingsEnableMultiDayCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay> CreateAgencyMicroSiteSettingsEnableMultiDay(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay agencymicrositesettingsenablemultiday)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay> CancelAgencyMicroSiteSettingsEnableMultiDayChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsEnableMultiDayUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay item);
        partial void OnAfterAgencyMicroSiteSettingsEnableMultiDayUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay> UpdateAgencyMicroSiteSettingsEnableMultiDay(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay agencymicrositesettingsenablemultiday)
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

        partial void OnAgencyMicroSiteSettingsEnableMultiDayDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay item);
        partial void OnAfterAgencyMicroSiteSettingsEnableMultiDayDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsEnableMultiDay> DeleteAgencyMicroSiteSettingsEnableMultiDay(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsgenerals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsgenerals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsGeneralsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsgenerals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsgenerals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsGeneralsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral>> GetAgencyMicroSiteSettingsGenerals(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsGenerals.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);

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

        partial void OnAgencyMicroSiteSettingsGeneralGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral> GetAgencyMicroSiteSettingsGeneralById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsGenerals
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsGeneralGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsGeneralCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral item);
        partial void OnAfterAgencyMicroSiteSettingsGeneralCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral> CreateAgencyMicroSiteSettingsGeneral(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral agencymicrositesettingsgeneral)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral> CancelAgencyMicroSiteSettingsGeneralChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsGeneralUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral item);
        partial void OnAfterAgencyMicroSiteSettingsGeneralUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral> UpdateAgencyMicroSiteSettingsGeneral(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral agencymicrositesettingsgeneral)
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
            agencymicrositesettingsgeneral.Agency = null;
            agencymicrositesettingsgeneral.AgencyMicroSite = null;

            Context.Attach(agencymicrositesettingsgeneral).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsGeneralUpdated(agencymicrositesettingsgeneral);

            return agencymicrositesettingsgeneral;
        }

        partial void OnAgencyMicroSiteSettingsGeneralDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral item);
        partial void OnAfterAgencyMicroSiteSettingsGeneralDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsGeneral> DeleteAgencyMicroSiteSettingsGeneral(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingshelpsupports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingshelpsupports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsHelpSupportsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingshelpsupports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingshelpsupports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsHelpSupportsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport>> GetAgencyMicroSiteSettingsHelpSupports(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsHelpSupports.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);

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

        partial void OnAgencyMicroSiteSettingsHelpSupportGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport> GetAgencyMicroSiteSettingsHelpSupportById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsHelpSupports
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsHelpSupportGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsHelpSupportCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport item);
        partial void OnAfterAgencyMicroSiteSettingsHelpSupportCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport> CreateAgencyMicroSiteSettingsHelpSupport(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport agencymicrositesettingshelpsupport)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport> CancelAgencyMicroSiteSettingsHelpSupportChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsHelpSupportUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport item);
        partial void OnAfterAgencyMicroSiteSettingsHelpSupportUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport> UpdateAgencyMicroSiteSettingsHelpSupport(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport agencymicrositesettingshelpsupport)
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
            agencymicrositesettingshelpsupport.Agency = null;
            agencymicrositesettingshelpsupport.AgencyMicroSite = null;

            Context.Attach(agencymicrositesettingshelpsupport).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsHelpSupportUpdated(agencymicrositesettingshelpsupport);

            return agencymicrositesettingshelpsupport;
        }

        partial void OnAgencyMicroSiteSettingsHelpSupportDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport item);
        partial void OnAfterAgencyMicroSiteSettingsHelpSupportDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsHelpSupport> DeleteAgencyMicroSiteSettingsHelpSupport(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsinvoices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsinvoices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsInvoicesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsinvoices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsinvoices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsInvoicesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice>> GetAgencyMicroSiteSettingsInvoices(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsInvoices.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);

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

        partial void OnAgencyMicroSiteSettingsInvoiceGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice> GetAgencyMicroSiteSettingsInvoiceById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsInvoices
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsInvoiceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsInvoiceCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice item);
        partial void OnAfterAgencyMicroSiteSettingsInvoiceCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice> CreateAgencyMicroSiteSettingsInvoice(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice agencymicrositesettingsinvoice)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice> CancelAgencyMicroSiteSettingsInvoiceChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsInvoiceUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice item);
        partial void OnAfterAgencyMicroSiteSettingsInvoiceUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice> UpdateAgencyMicroSiteSettingsInvoice(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice agencymicrositesettingsinvoice)
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
            agencymicrositesettingsinvoice.Agency = null;
            agencymicrositesettingsinvoice.AgencyMicroSite = null;

            Context.Attach(agencymicrositesettingsinvoice).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsInvoiceUpdated(agencymicrositesettingsinvoice);

            return agencymicrositesettingsinvoice;
        }

        partial void OnAgencyMicroSiteSettingsInvoiceDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice item);
        partial void OnAfterAgencyMicroSiteSettingsInvoiceDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsInvoice> DeleteAgencyMicroSiteSettingsInvoice(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsothers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsothers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsOthersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsothers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsothers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsOthersRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther>> GetAgencyMicroSiteSettingsOthers(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsOthers.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);

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

        partial void OnAgencyMicroSiteSettingsOtherGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther> GetAgencyMicroSiteSettingsOtherById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsOthers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsOtherGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsOtherCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther item);
        partial void OnAfterAgencyMicroSiteSettingsOtherCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther> CreateAgencyMicroSiteSettingsOther(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther agencymicrositesettingsother)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther> CancelAgencyMicroSiteSettingsOtherChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsOtherUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther item);
        partial void OnAfterAgencyMicroSiteSettingsOtherUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther> UpdateAgencyMicroSiteSettingsOther(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther agencymicrositesettingsother)
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
            agencymicrositesettingsother.Agency = null;
            agencymicrositesettingsother.AgencyMicroSite = null;

            Context.Attach(agencymicrositesettingsother).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsOtherUpdated(agencymicrositesettingsother);

            return agencymicrositesettingsother;
        }

        partial void OnAgencyMicroSiteSettingsOtherDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther item);
        partial void OnAfterAgencyMicroSiteSettingsOtherDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsOther> DeleteAgencyMicroSiteSettingsOther(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingspaymetoptions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingspaymetoptions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsPaymetOptionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingspaymetoptions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingspaymetoptions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsPaymetOptionsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption>> GetAgencyMicroSiteSettingsPaymetOptions(Query query = null)
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

        partial void OnAgencyMicroSiteSettingsPaymetOptionGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption> GetAgencyMicroSiteSettingsPaymetOptionById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsPaymetOptions
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsPaymetOptionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsPaymetOptionCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption item);
        partial void OnAfterAgencyMicroSiteSettingsPaymetOptionCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption> CreateAgencyMicroSiteSettingsPaymetOption(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption agencymicrositesettingspaymetoption)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption> CancelAgencyMicroSiteSettingsPaymetOptionChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsPaymetOptionUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption item);
        partial void OnAfterAgencyMicroSiteSettingsPaymetOptionUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption> UpdateAgencyMicroSiteSettingsPaymetOption(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption agencymicrositesettingspaymetoption)
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

        partial void OnAgencyMicroSiteSettingsPaymetOptionDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption item);
        partial void OnAfterAgencyMicroSiteSettingsPaymetOptionDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsPaymetOption> DeleteAgencyMicroSiteSettingsPaymetOption(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsrequestinvoices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsrequestinvoices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsRequestInvoicesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsrequestinvoices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsrequestinvoices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsRequestInvoicesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice>> GetAgencyMicroSiteSettingsRequestInvoices(Query query = null)
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

        partial void OnAgencyMicroSiteSettingsRequestInvoiceGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice> GetAgencyMicroSiteSettingsRequestInvoiceById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsRequestInvoices
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsRequestInvoiceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsRequestInvoiceCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice item);
        partial void OnAfterAgencyMicroSiteSettingsRequestInvoiceCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice> CreateAgencyMicroSiteSettingsRequestInvoice(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice agencymicrositesettingsrequestinvoice)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice> CancelAgencyMicroSiteSettingsRequestInvoiceChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsRequestInvoiceUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice item);
        partial void OnAfterAgencyMicroSiteSettingsRequestInvoiceUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice> UpdateAgencyMicroSiteSettingsRequestInvoice(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice agencymicrositesettingsrequestinvoice)
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

        partial void OnAgencyMicroSiteSettingsRequestInvoiceDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice item);
        partial void OnAfterAgencyMicroSiteSettingsRequestInvoiceDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequestInvoice> DeleteAgencyMicroSiteSettingsRequestInvoice(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsrequiredpassengers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsrequiredpassengers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsRequiredPassengersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingsrequiredpassengers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingsrequiredpassengers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsRequiredPassengersRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger>> GetAgencyMicroSiteSettingsRequiredPassengers(Query query = null)
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

        partial void OnAgencyMicroSiteSettingsRequiredPassengerGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger> GetAgencyMicroSiteSettingsRequiredPassengerById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsRequiredPassengers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsRequiredPassengerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsRequiredPassengerCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger item);
        partial void OnAfterAgencyMicroSiteSettingsRequiredPassengerCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger> CreateAgencyMicroSiteSettingsRequiredPassenger(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger agencymicrositesettingsrequiredpassenger)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger> CancelAgencyMicroSiteSettingsRequiredPassengerChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsRequiredPassengerUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger item);
        partial void OnAfterAgencyMicroSiteSettingsRequiredPassengerUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger> UpdateAgencyMicroSiteSettingsRequiredPassenger(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger agencymicrositesettingsrequiredpassenger)
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

        partial void OnAgencyMicroSiteSettingsRequiredPassengerDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger item);
        partial void OnAfterAgencyMicroSiteSettingsRequiredPassengerDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsRequiredPassenger> DeleteAgencyMicroSiteSettingsRequiredPassenger(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingssearchengines/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingssearchengines/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsSearchEnginesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingssearchengines/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingssearchengines/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsSearchEnginesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine>> GetAgencyMicroSiteSettingsSearchEngines(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsSearchEngines.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);

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

        partial void OnAgencyMicroSiteSettingsSearchEngineGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine> GetAgencyMicroSiteSettingsSearchEngineById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsSearchEngines
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsSearchEngineGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsSearchEngineCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine item);
        partial void OnAfterAgencyMicroSiteSettingsSearchEngineCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine> CreateAgencyMicroSiteSettingsSearchEngine(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine agencymicrositesettingssearchengine)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine> CancelAgencyMicroSiteSettingsSearchEngineChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsSearchEngineUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine item);
        partial void OnAfterAgencyMicroSiteSettingsSearchEngineUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine> UpdateAgencyMicroSiteSettingsSearchEngine(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine agencymicrositesettingssearchengine)
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
            agencymicrositesettingssearchengine.Agency = null;
            agencymicrositesettingssearchengine.AgencyMicroSite = null;

            Context.Attach(agencymicrositesettingssearchengine).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsSearchEngineUpdated(agencymicrositesettingssearchengine);

            return agencymicrositesettingssearchengine;
        }

        partial void OnAgencyMicroSiteSettingsSearchEngineDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine item);
        partial void OnAfterAgencyMicroSiteSettingsSearchEngineDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchEngine> DeleteAgencyMicroSiteSettingsSearchEngine(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingssearchsettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingssearchsettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsSearchSettingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingssearchsettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingssearchsettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsSearchSettingsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting>> GetAgencyMicroSiteSettingsSearchSettings(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsSearchSettings.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);

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

        partial void OnAgencyMicroSiteSettingsSearchSettingGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting> GetAgencyMicroSiteSettingsSearchSettingById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsSearchSettings
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsSearchSettingGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsSearchSettingCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting item);
        partial void OnAfterAgencyMicroSiteSettingsSearchSettingCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting> CreateAgencyMicroSiteSettingsSearchSetting(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting agencymicrositesettingssearchsetting)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting> CancelAgencyMicroSiteSettingsSearchSettingChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsSearchSettingUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting item);
        partial void OnAfterAgencyMicroSiteSettingsSearchSettingUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting> UpdateAgencyMicroSiteSettingsSearchSetting(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting agencymicrositesettingssearchsetting)
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
            agencymicrositesettingssearchsetting.Agency = null;
            agencymicrositesettingssearchsetting.AgencyMicroSite = null;

            Context.Attach(agencymicrositesettingssearchsetting).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsSearchSettingUpdated(agencymicrositesettingssearchsetting);

            return agencymicrositesettingssearchsetting;
        }

        partial void OnAgencyMicroSiteSettingsSearchSettingDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting item);
        partial void OnAfterAgencyMicroSiteSettingsSearchSettingDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSearchSetting> DeleteAgencyMicroSiteSettingsSearchSetting(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingssorttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingssorttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsSortTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingssorttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingssorttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsSortTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType>> GetAgencyMicroSiteSettingsSortTypes(Query query = null)
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

        partial void OnAgencyMicroSiteSettingsSortTypeGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType> GetAgencyMicroSiteSettingsSortTypeById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsSortTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsSortTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsSortTypeCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType item);
        partial void OnAfterAgencyMicroSiteSettingsSortTypeCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType> CreateAgencyMicroSiteSettingsSortType(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType agencymicrositesettingssorttype)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType> CancelAgencyMicroSiteSettingsSortTypeChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsSortTypeUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType item);
        partial void OnAfterAgencyMicroSiteSettingsSortTypeUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType> UpdateAgencyMicroSiteSettingsSortType(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType agencymicrositesettingssorttype)
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

        partial void OnAgencyMicroSiteSettingsSortTypeDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType item);
        partial void OnAfterAgencyMicroSiteSettingsSortTypeDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsSortType> DeleteAgencyMicroSiteSettingsSortType(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingstermsconditions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingstermsconditions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSiteSettingsTermsConditionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositesettingstermsconditions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositesettingstermsconditions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSiteSettingsTermsConditionsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition>> GetAgencyMicroSiteSettingsTermsConditions(Query query = null)
        {
            var items = Context.AgencyMicroSiteSettingsTermsConditions.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);

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

        partial void OnAgencyMicroSiteSettingsTermsConditionGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition> GetAgencyMicroSiteSettingsTermsConditionById(int id)
        {
            var items = Context.AgencyMicroSiteSettingsTermsConditions
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSiteSettingsTermsConditionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSiteSettingsTermsConditionCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition item);
        partial void OnAfterAgencyMicroSiteSettingsTermsConditionCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition> CreateAgencyMicroSiteSettingsTermsCondition(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition agencymicrositesettingstermscondition)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition> CancelAgencyMicroSiteSettingsTermsConditionChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSiteSettingsTermsConditionUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition item);
        partial void OnAfterAgencyMicroSiteSettingsTermsConditionUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition> UpdateAgencyMicroSiteSettingsTermsCondition(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition agencymicrositesettingstermscondition)
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
            agencymicrositesettingstermscondition.Agency = null;
            agencymicrositesettingstermscondition.AgencyMicroSite = null;

            Context.Attach(agencymicrositesettingstermscondition).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSiteSettingsTermsConditionUpdated(agencymicrositesettingstermscondition);

            return agencymicrositesettingstermscondition;
        }

        partial void OnAgencyMicroSiteSettingsTermsConditionDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition item);
        partial void OnAfterAgencyMicroSiteSettingsTermsConditionDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSiteSettingsTermsCondition> DeleteAgencyMicroSiteSettingsTermsCondition(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositessettingsemailconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositessettingsemailconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyMicroSitesSettingsEmailConfigurationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencymicrositessettingsemailconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencymicrositessettingsemailconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyMicroSitesSettingsEmailConfigurationsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration>> GetAgencyMicroSitesSettingsEmailConfigurations(Query query = null)
        {
            var items = Context.AgencyMicroSitesSettingsEmailConfigurations.AsQueryable();

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);

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

        partial void OnAgencyMicroSitesSettingsEmailConfigurationGet(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration> GetAgencyMicroSitesSettingsEmailConfigurationById(int id)
        {
            var items = Context.AgencyMicroSitesSettingsEmailConfigurations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
            items = items.Include(i => i.AgencyMicroSite);
  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyMicroSitesSettingsEmailConfigurationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyMicroSitesSettingsEmailConfigurationCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration item);
        partial void OnAfterAgencyMicroSitesSettingsEmailConfigurationCreated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration> CreateAgencyMicroSitesSettingsEmailConfiguration(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration agencymicrositessettingsemailconfiguration)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration> CancelAgencyMicroSitesSettingsEmailConfigurationChanges(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyMicroSitesSettingsEmailConfigurationUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration item);
        partial void OnAfterAgencyMicroSitesSettingsEmailConfigurationUpdated(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration> UpdateAgencyMicroSitesSettingsEmailConfiguration(int id, ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration agencymicrositessettingsemailconfiguration)
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
            agencymicrositessettingsemailconfiguration.Agency = null;
            agencymicrositessettingsemailconfiguration.AgencyMicroSite = null;

            Context.Attach(agencymicrositessettingsemailconfiguration).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAgencyMicroSitesSettingsEmailConfigurationUpdated(agencymicrositessettingsemailconfiguration);

            return agencymicrositessettingsemailconfiguration;
        }

        partial void OnAgencyMicroSitesSettingsEmailConfigurationDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration item);
        partial void OnAfterAgencyMicroSitesSettingsEmailConfigurationDeleted(ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyMicroSitesSettingsEmailConfiguration> DeleteAgencyMicroSitesSettingsEmailConfiguration(int id)
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
    
        public async Task ExportAgencyUsersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencyusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencyusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyUsersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencyusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencyusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyUsersRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyUser> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyUser>> GetAgencyUsers(Query query = null)
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

        partial void OnAgencyUserGet(ZarenTravelBO.Models.zaren_prod.AgencyUser item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyUser> GetAgencyUserById(int id)
        {
            var items = Context.AgencyUsers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAgencyUserGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAgencyUserCreated(ZarenTravelBO.Models.zaren_prod.AgencyUser item);
        partial void OnAfterAgencyUserCreated(ZarenTravelBO.Models.zaren_prod.AgencyUser item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyUser> CreateAgencyUser(ZarenTravelBO.Models.zaren_prod.AgencyUser agencyuser)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyUser> CancelAgencyUserChanges(ZarenTravelBO.Models.zaren_prod.AgencyUser item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAgencyUserUpdated(ZarenTravelBO.Models.zaren_prod.AgencyUser item);
        partial void OnAfterAgencyUserUpdated(ZarenTravelBO.Models.zaren_prod.AgencyUser item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyUser> UpdateAgencyUser(int id, ZarenTravelBO.Models.zaren_prod.AgencyUser agencyuser)
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

        partial void OnAgencyUserDeleted(ZarenTravelBO.Models.zaren_prod.AgencyUser item);
        partial void OnAfterAgencyUserDeleted(ZarenTravelBO.Models.zaren_prod.AgencyUser item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AgencyUser> DeleteAgencyUser(int id)
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
    
        public async Task ExportAirLinesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/airlines/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/airlines/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAirLinesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/airlines/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/airlines/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAirLinesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AirLine> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AirLine>> GetAirLines(Query query = null)
        {
            var items = Context.AirLines.AsQueryable();


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

            OnAirLinesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAirLineGet(ZarenTravelBO.Models.zaren_prod.AirLine item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AirLine> GetAirLineById(int id)
        {
            var items = Context.AirLines
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAirLineGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAirLineCreated(ZarenTravelBO.Models.zaren_prod.AirLine item);
        partial void OnAfterAirLineCreated(ZarenTravelBO.Models.zaren_prod.AirLine item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AirLine> CreateAirLine(ZarenTravelBO.Models.zaren_prod.AirLine airline)
        {
            OnAirLineCreated(airline);

            var existingItem = Context.AirLines
                              .Where(i => i.Id == airline.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AirLines.Add(airline);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(airline).State = EntityState.Detached;
                throw;
            }

            OnAfterAirLineCreated(airline);

            return airline;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.AirLine> CancelAirLineChanges(ZarenTravelBO.Models.zaren_prod.AirLine item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAirLineUpdated(ZarenTravelBO.Models.zaren_prod.AirLine item);
        partial void OnAfterAirLineUpdated(ZarenTravelBO.Models.zaren_prod.AirLine item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AirLine> UpdateAirLine(int id, ZarenTravelBO.Models.zaren_prod.AirLine airline)
        {
            OnAirLineUpdated(airline);

            var itemToUpdate = Context.AirLines
                              .Where(i => i.Id == airline.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(airline).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAirLineUpdated(airline);

            return airline;
        }

        partial void OnAirLineDeleted(ZarenTravelBO.Models.zaren_prod.AirLine item);
        partial void OnAfterAirLineDeleted(ZarenTravelBO.Models.zaren_prod.AirLine item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AirLine> DeleteAirLine(int id)
        {
            var itemToDelete = Context.AirLines
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAirLineDeleted(itemToDelete);

            Reset();

            Context.AirLines.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAirLineDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAirPortsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/airports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/airports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAirPortsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/airports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/airports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAirPortsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AirPort> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AirPort>> GetAirPorts(Query query = null)
        {
            var items = Context.AirPorts.AsQueryable();


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

            OnAirPortsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAirPortGet(ZarenTravelBO.Models.zaren_prod.AirPort item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AirPort> GetAirPortById(int id)
        {
            var items = Context.AirPorts
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAirPortGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAirPortCreated(ZarenTravelBO.Models.zaren_prod.AirPort item);
        partial void OnAfterAirPortCreated(ZarenTravelBO.Models.zaren_prod.AirPort item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AirPort> CreateAirPort(ZarenTravelBO.Models.zaren_prod.AirPort airport)
        {
            OnAirPortCreated(airport);

            var existingItem = Context.AirPorts
                              .Where(i => i.Id == airport.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AirPorts.Add(airport);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(airport).State = EntityState.Detached;
                throw;
            }

            OnAfterAirPortCreated(airport);

            return airport;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.AirPort> CancelAirPortChanges(ZarenTravelBO.Models.zaren_prod.AirPort item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAirPortUpdated(ZarenTravelBO.Models.zaren_prod.AirPort item);
        partial void OnAfterAirPortUpdated(ZarenTravelBO.Models.zaren_prod.AirPort item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AirPort> UpdateAirPort(int id, ZarenTravelBO.Models.zaren_prod.AirPort airport)
        {
            OnAirPortUpdated(airport);

            var itemToUpdate = Context.AirPorts
                              .Where(i => i.Id == airport.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(airport).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAirPortUpdated(airport);

            return airport;
        }

        partial void OnAirPortDeleted(ZarenTravelBO.Models.zaren_prod.AirPort item);
        partial void OnAfterAirPortDeleted(ZarenTravelBO.Models.zaren_prod.AirPort item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AirPort> DeleteAirPort(int id)
        {
            var itemToDelete = Context.AirPorts
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAirPortDeleted(itemToDelete);

            Reset();

            Context.AirPorts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAirPortDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAirPortTaxesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/airporttaxes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/airporttaxes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAirPortTaxesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/airporttaxes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/airporttaxes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAirPortTaxesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AirPortTax> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AirPortTax>> GetAirPortTaxes(Query query = null)
        {
            var items = Context.AirPortTaxes.AsQueryable();


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

            OnAirPortTaxesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAirPortTaxGet(ZarenTravelBO.Models.zaren_prod.AirPortTax item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AirPortTax> GetAirPortTaxById(int id)
        {
            var items = Context.AirPortTaxes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAirPortTaxGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAirPortTaxCreated(ZarenTravelBO.Models.zaren_prod.AirPortTax item);
        partial void OnAfterAirPortTaxCreated(ZarenTravelBO.Models.zaren_prod.AirPortTax item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AirPortTax> CreateAirPortTax(ZarenTravelBO.Models.zaren_prod.AirPortTax airporttax)
        {
            OnAirPortTaxCreated(airporttax);

            var existingItem = Context.AirPortTaxes
                              .Where(i => i.Id == airporttax.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AirPortTaxes.Add(airporttax);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(airporttax).State = EntityState.Detached;
                throw;
            }

            OnAfterAirPortTaxCreated(airporttax);

            return airporttax;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.AirPortTax> CancelAirPortTaxChanges(ZarenTravelBO.Models.zaren_prod.AirPortTax item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAirPortTaxUpdated(ZarenTravelBO.Models.zaren_prod.AirPortTax item);
        partial void OnAfterAirPortTaxUpdated(ZarenTravelBO.Models.zaren_prod.AirPortTax item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AirPortTax> UpdateAirPortTax(int id, ZarenTravelBO.Models.zaren_prod.AirPortTax airporttax)
        {
            OnAirPortTaxUpdated(airporttax);

            var itemToUpdate = Context.AirPortTaxes
                              .Where(i => i.Id == airporttax.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(airporttax).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAirPortTaxUpdated(airporttax);

            return airporttax;
        }

        partial void OnAirPortTaxDeleted(ZarenTravelBO.Models.zaren_prod.AirPortTax item);
        partial void OnAfterAirPortTaxDeleted(ZarenTravelBO.Models.zaren_prod.AirPortTax item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AirPortTax> DeleteAirPortTax(int id)
        {
            var itemToDelete = Context.AirPortTaxes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAirPortTaxDeleted(itemToDelete);

            Reset();

            Context.AirPortTaxes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAirPortTaxDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportApiProductsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/apiproducts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/apiproducts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportApiProductsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/apiproducts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/apiproducts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnApiProductsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.ApiProduct> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.ApiProduct>> GetApiProducts(Query query = null)
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

        partial void OnApiProductGet(ZarenTravelBO.Models.zaren_prod.ApiProduct item);

        public async Task<ZarenTravelBO.Models.zaren_prod.ApiProduct> GetApiProductById(int id)
        {
            var items = Context.ApiProducts
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnApiProductGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnApiProductCreated(ZarenTravelBO.Models.zaren_prod.ApiProduct item);
        partial void OnAfterApiProductCreated(ZarenTravelBO.Models.zaren_prod.ApiProduct item);

        public async Task<ZarenTravelBO.Models.zaren_prod.ApiProduct> CreateApiProduct(ZarenTravelBO.Models.zaren_prod.ApiProduct apiproduct)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.ApiProduct> CancelApiProductChanges(ZarenTravelBO.Models.zaren_prod.ApiProduct item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnApiProductUpdated(ZarenTravelBO.Models.zaren_prod.ApiProduct item);
        partial void OnAfterApiProductUpdated(ZarenTravelBO.Models.zaren_prod.ApiProduct item);

        public async Task<ZarenTravelBO.Models.zaren_prod.ApiProduct> UpdateApiProduct(int id, ZarenTravelBO.Models.zaren_prod.ApiProduct apiproduct)
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

        partial void OnApiProductDeleted(ZarenTravelBO.Models.zaren_prod.ApiProduct item);
        partial void OnAfterApiProductDeleted(ZarenTravelBO.Models.zaren_prod.ApiProduct item);

        public async Task<ZarenTravelBO.Models.zaren_prod.ApiProduct> DeleteApiProduct(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/apiresults/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/apiresults/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportApiResultsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/apiresults/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/apiresults/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnApiResultsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.ApiResult> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.ApiResult>> GetApiResults(Query query = null)
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

        partial void OnApiResultGet(ZarenTravelBO.Models.zaren_prod.ApiResult item);

        public async Task<ZarenTravelBO.Models.zaren_prod.ApiResult> GetApiResultById(int id)
        {
            var items = Context.ApiResults
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnApiResultGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnApiResultCreated(ZarenTravelBO.Models.zaren_prod.ApiResult item);
        partial void OnAfterApiResultCreated(ZarenTravelBO.Models.zaren_prod.ApiResult item);

        public async Task<ZarenTravelBO.Models.zaren_prod.ApiResult> CreateApiResult(ZarenTravelBO.Models.zaren_prod.ApiResult apiresult)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.ApiResult> CancelApiResultChanges(ZarenTravelBO.Models.zaren_prod.ApiResult item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnApiResultUpdated(ZarenTravelBO.Models.zaren_prod.ApiResult item);
        partial void OnAfterApiResultUpdated(ZarenTravelBO.Models.zaren_prod.ApiResult item);

        public async Task<ZarenTravelBO.Models.zaren_prod.ApiResult> UpdateApiResult(int id, ZarenTravelBO.Models.zaren_prod.ApiResult apiresult)
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

        partial void OnApiResultDeleted(ZarenTravelBO.Models.zaren_prod.ApiResult item);
        partial void OnAfterApiResultDeleted(ZarenTravelBO.Models.zaren_prod.ApiResult item);

        public async Task<ZarenTravelBO.Models.zaren_prod.ApiResult> DeleteApiResult(int id)
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
    
        public async Task ExportApisToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/apis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/apis/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportApisToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/apis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/apis/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnApisRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Api> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Api>> GetApis(Query query = null)
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

        partial void OnApiGet(ZarenTravelBO.Models.zaren_prod.Api item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Api> GetApiById(int id)
        {
            var items = Context.Apis
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnApiGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnApiCreated(ZarenTravelBO.Models.zaren_prod.Api item);
        partial void OnAfterApiCreated(ZarenTravelBO.Models.zaren_prod.Api item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Api> CreateApi(ZarenTravelBO.Models.zaren_prod.Api api)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.Api> CancelApiChanges(ZarenTravelBO.Models.zaren_prod.Api item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnApiUpdated(ZarenTravelBO.Models.zaren_prod.Api item);
        partial void OnAfterApiUpdated(ZarenTravelBO.Models.zaren_prod.Api item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Api> UpdateApi(int id, ZarenTravelBO.Models.zaren_prod.Api api)
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

        partial void OnApiDeleted(ZarenTravelBO.Models.zaren_prod.Api item);
        partial void OnAfterApiDeleted(ZarenTravelBO.Models.zaren_prod.Api item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Api> DeleteApi(int id)
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
    
        public async Task ExportArrivalsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/arrivals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/arrivals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportArrivalsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/arrivals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/arrivals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnArrivalsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Arrival> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Arrival>> GetArrivals(Query query = null)
        {
            var items = Context.Arrivals.AsQueryable();


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

            OnArrivalsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnArrivalGet(ZarenTravelBO.Models.zaren_prod.Arrival item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Arrival> GetArrivalById(int id)
        {
            var items = Context.Arrivals
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnArrivalGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnArrivalCreated(ZarenTravelBO.Models.zaren_prod.Arrival item);
        partial void OnAfterArrivalCreated(ZarenTravelBO.Models.zaren_prod.Arrival item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Arrival> CreateArrival(ZarenTravelBO.Models.zaren_prod.Arrival arrival)
        {
            OnArrivalCreated(arrival);

            var existingItem = Context.Arrivals
                              .Where(i => i.Id == arrival.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Arrivals.Add(arrival);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(arrival).State = EntityState.Detached;
                throw;
            }

            OnAfterArrivalCreated(arrival);

            return arrival;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.Arrival> CancelArrivalChanges(ZarenTravelBO.Models.zaren_prod.Arrival item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnArrivalUpdated(ZarenTravelBO.Models.zaren_prod.Arrival item);
        partial void OnAfterArrivalUpdated(ZarenTravelBO.Models.zaren_prod.Arrival item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Arrival> UpdateArrival(int id, ZarenTravelBO.Models.zaren_prod.Arrival arrival)
        {
            OnArrivalUpdated(arrival);

            var itemToUpdate = Context.Arrivals
                              .Where(i => i.Id == arrival.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(arrival).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterArrivalUpdated(arrival);

            return arrival;
        }

        partial void OnArrivalDeleted(ZarenTravelBO.Models.zaren_prod.Arrival item);
        partial void OnAfterArrivalDeleted(ZarenTravelBO.Models.zaren_prod.Arrival item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Arrival> DeleteArrival(int id)
        {
            var itemToDelete = Context.Arrivals
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnArrivalDeleted(itemToDelete);

            Reset();

            Context.Arrivals.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterArrivalDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportAutoCompletesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/autocompletes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/autocompletes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAutoCompletesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/autocompletes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/autocompletes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAutoCompletesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AutoComplete> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AutoComplete>> GetAutoCompletes(Query query = null)
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

        partial void OnAutoCompleteGet(ZarenTravelBO.Models.zaren_prod.AutoComplete item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AutoComplete> GetAutoCompleteById(int id)
        {
            var items = Context.AutoCompletes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAutoCompleteGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAutoCompleteCreated(ZarenTravelBO.Models.zaren_prod.AutoComplete item);
        partial void OnAfterAutoCompleteCreated(ZarenTravelBO.Models.zaren_prod.AutoComplete item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AutoComplete> CreateAutoComplete(ZarenTravelBO.Models.zaren_prod.AutoComplete autocomplete)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AutoComplete> CancelAutoCompleteChanges(ZarenTravelBO.Models.zaren_prod.AutoComplete item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAutoCompleteUpdated(ZarenTravelBO.Models.zaren_prod.AutoComplete item);
        partial void OnAfterAutoCompleteUpdated(ZarenTravelBO.Models.zaren_prod.AutoComplete item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AutoComplete> UpdateAutoComplete(int id, ZarenTravelBO.Models.zaren_prod.AutoComplete autocomplete)
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

            Context.Attach(autocomplete).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterAutoCompleteUpdated(autocomplete);

            return autocomplete;
        }

        partial void OnAutoCompleteDeleted(ZarenTravelBO.Models.zaren_prod.AutoComplete item);
        partial void OnAfterAutoCompleteDeleted(ZarenTravelBO.Models.zaren_prod.AutoComplete item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AutoComplete> DeleteAutoComplete(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/autocompletetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/autocompletetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAutoCompleteTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/autocompletetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/autocompletetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAutoCompleteTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AutoCompleteType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AutoCompleteType>> GetAutoCompleteTypes(Query query = null)
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

        partial void OnAutoCompleteTypeGet(ZarenTravelBO.Models.zaren_prod.AutoCompleteType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AutoCompleteType> GetAutoCompleteTypeById(int id)
        {
            var items = Context.AutoCompleteTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnAutoCompleteTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnAutoCompleteTypeCreated(ZarenTravelBO.Models.zaren_prod.AutoCompleteType item);
        partial void OnAfterAutoCompleteTypeCreated(ZarenTravelBO.Models.zaren_prod.AutoCompleteType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AutoCompleteType> CreateAutoCompleteType(ZarenTravelBO.Models.zaren_prod.AutoCompleteType autocompletetype)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.AutoCompleteType> CancelAutoCompleteTypeChanges(ZarenTravelBO.Models.zaren_prod.AutoCompleteType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAutoCompleteTypeUpdated(ZarenTravelBO.Models.zaren_prod.AutoCompleteType item);
        partial void OnAfterAutoCompleteTypeUpdated(ZarenTravelBO.Models.zaren_prod.AutoCompleteType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AutoCompleteType> UpdateAutoCompleteType(int id, ZarenTravelBO.Models.zaren_prod.AutoCompleteType autocompletetype)
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

        partial void OnAutoCompleteTypeDeleted(ZarenTravelBO.Models.zaren_prod.AutoCompleteType item);
        partial void OnAfterAutoCompleteTypeDeleted(ZarenTravelBO.Models.zaren_prod.AutoCompleteType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.AutoCompleteType> DeleteAutoCompleteType(int id)
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
    
        public async Task ExportBaggageInformationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/baggageinformations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/baggageinformations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBaggageInformationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/baggageinformations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/baggageinformations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBaggageInformationsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.BaggageInformation> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.BaggageInformation>> GetBaggageInformations(Query query = null)
        {
            var items = Context.BaggageInformations.AsQueryable();


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

            OnBaggageInformationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBaggageInformationGet(ZarenTravelBO.Models.zaren_prod.BaggageInformation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.BaggageInformation> GetBaggageInformationById(int id)
        {
            var items = Context.BaggageInformations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnBaggageInformationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBaggageInformationCreated(ZarenTravelBO.Models.zaren_prod.BaggageInformation item);
        partial void OnAfterBaggageInformationCreated(ZarenTravelBO.Models.zaren_prod.BaggageInformation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.BaggageInformation> CreateBaggageInformation(ZarenTravelBO.Models.zaren_prod.BaggageInformation baggageinformation)
        {
            OnBaggageInformationCreated(baggageinformation);

            var existingItem = Context.BaggageInformations
                              .Where(i => i.Id == baggageinformation.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.BaggageInformations.Add(baggageinformation);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(baggageinformation).State = EntityState.Detached;
                throw;
            }

            OnAfterBaggageInformationCreated(baggageinformation);

            return baggageinformation;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.BaggageInformation> CancelBaggageInformationChanges(ZarenTravelBO.Models.zaren_prod.BaggageInformation item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBaggageInformationUpdated(ZarenTravelBO.Models.zaren_prod.BaggageInformation item);
        partial void OnAfterBaggageInformationUpdated(ZarenTravelBO.Models.zaren_prod.BaggageInformation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.BaggageInformation> UpdateBaggageInformation(int id, ZarenTravelBO.Models.zaren_prod.BaggageInformation baggageinformation)
        {
            OnBaggageInformationUpdated(baggageinformation);

            var itemToUpdate = Context.BaggageInformations
                              .Where(i => i.Id == baggageinformation.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(baggageinformation).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBaggageInformationUpdated(baggageinformation);

            return baggageinformation;
        }

        partial void OnBaggageInformationDeleted(ZarenTravelBO.Models.zaren_prod.BaggageInformation item);
        partial void OnAfterBaggageInformationDeleted(ZarenTravelBO.Models.zaren_prod.BaggageInformation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.BaggageInformation> DeleteBaggageInformation(int id)
        {
            var itemToDelete = Context.BaggageInformations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBaggageInformationDeleted(itemToDelete);

            Reset();

            Context.BaggageInformations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBaggageInformationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBaggageTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/baggagetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/baggagetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBaggageTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/baggagetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/baggagetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBaggageTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.BaggageType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.BaggageType>> GetBaggageTypes(Query query = null)
        {
            var items = Context.BaggageTypes.AsQueryable();


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

            OnBaggageTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBaggageTypeGet(ZarenTravelBO.Models.zaren_prod.BaggageType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.BaggageType> GetBaggageTypeById(int id)
        {
            var items = Context.BaggageTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnBaggageTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBaggageTypeCreated(ZarenTravelBO.Models.zaren_prod.BaggageType item);
        partial void OnAfterBaggageTypeCreated(ZarenTravelBO.Models.zaren_prod.BaggageType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.BaggageType> CreateBaggageType(ZarenTravelBO.Models.zaren_prod.BaggageType baggagetype)
        {
            OnBaggageTypeCreated(baggagetype);

            var existingItem = Context.BaggageTypes
                              .Where(i => i.Id == baggagetype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.BaggageTypes.Add(baggagetype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(baggagetype).State = EntityState.Detached;
                throw;
            }

            OnAfterBaggageTypeCreated(baggagetype);

            return baggagetype;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.BaggageType> CancelBaggageTypeChanges(ZarenTravelBO.Models.zaren_prod.BaggageType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBaggageTypeUpdated(ZarenTravelBO.Models.zaren_prod.BaggageType item);
        partial void OnAfterBaggageTypeUpdated(ZarenTravelBO.Models.zaren_prod.BaggageType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.BaggageType> UpdateBaggageType(int id, ZarenTravelBO.Models.zaren_prod.BaggageType baggagetype)
        {
            OnBaggageTypeUpdated(baggagetype);

            var itemToUpdate = Context.BaggageTypes
                              .Where(i => i.Id == baggagetype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(baggagetype).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBaggageTypeUpdated(baggagetype);

            return baggagetype;
        }

        partial void OnBaggageTypeDeleted(ZarenTravelBO.Models.zaren_prod.BaggageType item);
        partial void OnAfterBaggageTypeDeleted(ZarenTravelBO.Models.zaren_prod.BaggageType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.BaggageType> DeleteBaggageType(int id)
        {
            var itemToDelete = Context.BaggageTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBaggageTypeDeleted(itemToDelete);

            Reset();

            Context.BaggageTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBaggageTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportBaggageUnitTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/baggageunittypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/baggageunittypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBaggageUnitTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/baggageunittypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/baggageunittypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBaggageUnitTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.BaggageUnitType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.BaggageUnitType>> GetBaggageUnitTypes(Query query = null)
        {
            var items = Context.BaggageUnitTypes.AsQueryable();


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

            OnBaggageUnitTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBaggageUnitTypeGet(ZarenTravelBO.Models.zaren_prod.BaggageUnitType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.BaggageUnitType> GetBaggageUnitTypeById(int id)
        {
            var items = Context.BaggageUnitTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnBaggageUnitTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnBaggageUnitTypeCreated(ZarenTravelBO.Models.zaren_prod.BaggageUnitType item);
        partial void OnAfterBaggageUnitTypeCreated(ZarenTravelBO.Models.zaren_prod.BaggageUnitType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.BaggageUnitType> CreateBaggageUnitType(ZarenTravelBO.Models.zaren_prod.BaggageUnitType baggageunittype)
        {
            OnBaggageUnitTypeCreated(baggageunittype);

            var existingItem = Context.BaggageUnitTypes
                              .Where(i => i.Id == baggageunittype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.BaggageUnitTypes.Add(baggageunittype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(baggageunittype).State = EntityState.Detached;
                throw;
            }

            OnAfterBaggageUnitTypeCreated(baggageunittype);

            return baggageunittype;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.BaggageUnitType> CancelBaggageUnitTypeChanges(ZarenTravelBO.Models.zaren_prod.BaggageUnitType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBaggageUnitTypeUpdated(ZarenTravelBO.Models.zaren_prod.BaggageUnitType item);
        partial void OnAfterBaggageUnitTypeUpdated(ZarenTravelBO.Models.zaren_prod.BaggageUnitType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.BaggageUnitType> UpdateBaggageUnitType(int id, ZarenTravelBO.Models.zaren_prod.BaggageUnitType baggageunittype)
        {
            OnBaggageUnitTypeUpdated(baggageunittype);

            var itemToUpdate = Context.BaggageUnitTypes
                              .Where(i => i.Id == baggageunittype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(baggageunittype).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterBaggageUnitTypeUpdated(baggageunittype);

            return baggageunittype;
        }

        partial void OnBaggageUnitTypeDeleted(ZarenTravelBO.Models.zaren_prod.BaggageUnitType item);
        partial void OnAfterBaggageUnitTypeDeleted(ZarenTravelBO.Models.zaren_prod.BaggageUnitType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.BaggageUnitType> DeleteBaggageUnitType(int id)
        {
            var itemToDelete = Context.BaggageUnitTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBaggageUnitTypeDeleted(itemToDelete);

            Reset();

            Context.BaggageUnitTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBaggageUnitTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/cities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/cities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/cities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/cities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCitiesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.City> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.City>> GetCities(Query query = null)
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

        partial void OnCityGet(ZarenTravelBO.Models.zaren_prod.City item);

        public async Task<ZarenTravelBO.Models.zaren_prod.City> GetCityById(int id)
        {
            var items = Context.Cities
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCityCreated(ZarenTravelBO.Models.zaren_prod.City item);
        partial void OnAfterCityCreated(ZarenTravelBO.Models.zaren_prod.City item);

        public async Task<ZarenTravelBO.Models.zaren_prod.City> CreateCity(ZarenTravelBO.Models.zaren_prod.City city)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.City> CancelCityChanges(ZarenTravelBO.Models.zaren_prod.City item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCityUpdated(ZarenTravelBO.Models.zaren_prod.City item);
        partial void OnAfterCityUpdated(ZarenTravelBO.Models.zaren_prod.City item);

        public async Task<ZarenTravelBO.Models.zaren_prod.City> UpdateCity(int id, ZarenTravelBO.Models.zaren_prod.City city)
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

            Context.Attach(city).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCityUpdated(city);

            return city;
        }

        partial void OnCityDeleted(ZarenTravelBO.Models.zaren_prod.City item);
        partial void OnAfterCityDeleted(ZarenTravelBO.Models.zaren_prod.City item);

        public async Task<ZarenTravelBO.Models.zaren_prod.City> DeleteCity(int id)
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
    
        public async Task ExportCityModelsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/citymodels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/citymodels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCityModelsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/citymodels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/citymodels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCityModelsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.CityModel> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.CityModel>> GetCityModels(Query query = null)
        {
            var items = Context.CityModels.AsQueryable();


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

            OnCityModelsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCityModelGet(ZarenTravelBO.Models.zaren_prod.CityModel item);

        public async Task<ZarenTravelBO.Models.zaren_prod.CityModel> GetCityModelByCityId(int cityid)
        {
            var items = Context.CityModels
                              .AsNoTracking()
                              .Where(i => i.CityId == cityid);

  
            var itemToReturn = items.FirstOrDefault();

            OnCityModelGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCityModelCreated(ZarenTravelBO.Models.zaren_prod.CityModel item);
        partial void OnAfterCityModelCreated(ZarenTravelBO.Models.zaren_prod.CityModel item);

        public async Task<ZarenTravelBO.Models.zaren_prod.CityModel> CreateCityModel(ZarenTravelBO.Models.zaren_prod.CityModel citymodel)
        {
            OnCityModelCreated(citymodel);

            var existingItem = Context.CityModels
                              .Where(i => i.CityId == citymodel.CityId)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CityModels.Add(citymodel);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(citymodel).State = EntityState.Detached;
                throw;
            }

            OnAfterCityModelCreated(citymodel);

            return citymodel;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.CityModel> CancelCityModelChanges(ZarenTravelBO.Models.zaren_prod.CityModel item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCityModelUpdated(ZarenTravelBO.Models.zaren_prod.CityModel item);
        partial void OnAfterCityModelUpdated(ZarenTravelBO.Models.zaren_prod.CityModel item);

        public async Task<ZarenTravelBO.Models.zaren_prod.CityModel> UpdateCityModel(int cityid, ZarenTravelBO.Models.zaren_prod.CityModel citymodel)
        {
            OnCityModelUpdated(citymodel);

            var itemToUpdate = Context.CityModels
                              .Where(i => i.CityId == citymodel.CityId)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(citymodel).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCityModelUpdated(citymodel);

            return citymodel;
        }

        partial void OnCityModelDeleted(ZarenTravelBO.Models.zaren_prod.CityModel item);
        partial void OnAfterCityModelDeleted(ZarenTravelBO.Models.zaren_prod.CityModel item);

        public async Task<ZarenTravelBO.Models.zaren_prod.CityModel> DeleteCityModel(int cityid)
        {
            var itemToDelete = Context.CityModels
                              .Where(i => i.CityId == cityid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCityModelDeleted(itemToDelete);

            Reset();

            Context.CityModels.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCityModelDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCountriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/countries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/countries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCountriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/countries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/countries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCountriesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Country> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Country>> GetCountries(Query query = null)
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

        partial void OnCountryGet(ZarenTravelBO.Models.zaren_prod.Country item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Country> GetCountryById(int id)
        {
            var items = Context.Countries
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCountryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCountryCreated(ZarenTravelBO.Models.zaren_prod.Country item);
        partial void OnAfterCountryCreated(ZarenTravelBO.Models.zaren_prod.Country item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Country> CreateCountry(ZarenTravelBO.Models.zaren_prod.Country country)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.Country> CancelCountryChanges(ZarenTravelBO.Models.zaren_prod.Country item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCountryUpdated(ZarenTravelBO.Models.zaren_prod.Country item);
        partial void OnAfterCountryUpdated(ZarenTravelBO.Models.zaren_prod.Country item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Country> UpdateCountry(int id, ZarenTravelBO.Models.zaren_prod.Country country)
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

            Context.Attach(country).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCountryUpdated(country);

            return country;
        }

        partial void OnCountryDeleted(ZarenTravelBO.Models.zaren_prod.Country item);
        partial void OnAfterCountryDeleted(ZarenTravelBO.Models.zaren_prod.Country item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Country> DeleteCountry(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/country1s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/country1s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCountry1SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/country1s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/country1s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCountry1SRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Country1> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Country1>> GetCountry1S(Query query = null)
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

        partial void OnCountry1Get(ZarenTravelBO.Models.zaren_prod.Country1 item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Country1> GetCountry1ById(int id)
        {
            var items = Context.Country1S
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCountry1Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCountry1Created(ZarenTravelBO.Models.zaren_prod.Country1 item);
        partial void OnAfterCountry1Created(ZarenTravelBO.Models.zaren_prod.Country1 item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Country1> CreateCountry1(ZarenTravelBO.Models.zaren_prod.Country1 country1)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.Country1> CancelCountry1Changes(ZarenTravelBO.Models.zaren_prod.Country1 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCountry1Updated(ZarenTravelBO.Models.zaren_prod.Country1 item);
        partial void OnAfterCountry1Updated(ZarenTravelBO.Models.zaren_prod.Country1 item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Country1> UpdateCountry1(int id, ZarenTravelBO.Models.zaren_prod.Country1 country1)
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

        partial void OnCountry1Deleted(ZarenTravelBO.Models.zaren_prod.Country1 item);
        partial void OnAfterCountry1Deleted(ZarenTravelBO.Models.zaren_prod.Country1 item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Country1> DeleteCountry1(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/currencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/currencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCurrenciesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/currencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/currencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCurrenciesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Currency> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Currency>> GetCurrencies(Query query = null)
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

        partial void OnCurrencyGet(ZarenTravelBO.Models.zaren_prod.Currency item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Currency> GetCurrencyById(int id)
        {
            var items = Context.Currencies
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCurrencyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCurrencyCreated(ZarenTravelBO.Models.zaren_prod.Currency item);
        partial void OnAfterCurrencyCreated(ZarenTravelBO.Models.zaren_prod.Currency item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Currency> CreateCurrency(ZarenTravelBO.Models.zaren_prod.Currency currency)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.Currency> CancelCurrencyChanges(ZarenTravelBO.Models.zaren_prod.Currency item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCurrencyUpdated(ZarenTravelBO.Models.zaren_prod.Currency item);
        partial void OnAfterCurrencyUpdated(ZarenTravelBO.Models.zaren_prod.Currency item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Currency> UpdateCurrency(int id, ZarenTravelBO.Models.zaren_prod.Currency currency)
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

        partial void OnCurrencyDeleted(ZarenTravelBO.Models.zaren_prod.Currency item);
        partial void OnAfterCurrencyDeleted(ZarenTravelBO.Models.zaren_prod.Currency item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Currency> DeleteCurrency(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/currency1s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/currency1s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCurrency1SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/currency1s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/currency1s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCurrency1SRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Currency1> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Currency1>> GetCurrency1S(Query query = null)
        {
            var items = Context.Currency1S.AsQueryable();


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

        partial void OnCurrency1Get(ZarenTravelBO.Models.zaren_prod.Currency1 item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Currency1> GetCurrency1ById(int id)
        {
            var items = Context.Currency1S
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCurrency1Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCurrency1Created(ZarenTravelBO.Models.zaren_prod.Currency1 item);
        partial void OnAfterCurrency1Created(ZarenTravelBO.Models.zaren_prod.Currency1 item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Currency1> CreateCurrency1(ZarenTravelBO.Models.zaren_prod.Currency1 currency1)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.Currency1> CancelCurrency1Changes(ZarenTravelBO.Models.zaren_prod.Currency1 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCurrency1Updated(ZarenTravelBO.Models.zaren_prod.Currency1 item);
        partial void OnAfterCurrency1Updated(ZarenTravelBO.Models.zaren_prod.Currency1 item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Currency1> UpdateCurrency1(int id, ZarenTravelBO.Models.zaren_prod.Currency1 currency1)
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

            Context.Attach(currency1).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCurrency1Updated(currency1);

            return currency1;
        }

        partial void OnCurrency1Deleted(ZarenTravelBO.Models.zaren_prod.Currency1 item);
        partial void OnAfterCurrency1Deleted(ZarenTravelBO.Models.zaren_prod.Currency1 item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Currency1> DeleteCurrency1(int id)
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
    
        public async Task ExportDatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/dates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/dates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/dates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/dates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDatesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Date> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Date>> GetDates(Query query = null)
        {
            var items = Context.Dates.AsQueryable();


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

            OnDatesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDateGet(ZarenTravelBO.Models.zaren_prod.Date item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Date> GetDateById(int id)
        {
            var items = Context.Dates
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnDateGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDateCreated(ZarenTravelBO.Models.zaren_prod.Date item);
        partial void OnAfterDateCreated(ZarenTravelBO.Models.zaren_prod.Date item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Date> CreateDate(ZarenTravelBO.Models.zaren_prod.Date date)
        {
            OnDateCreated(date);

            var existingItem = Context.Dates
                              .Where(i => i.Id == date.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Dates.Add(date);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(date).State = EntityState.Detached;
                throw;
            }

            OnAfterDateCreated(date);

            return date;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.Date> CancelDateChanges(ZarenTravelBO.Models.zaren_prod.Date item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDateUpdated(ZarenTravelBO.Models.zaren_prod.Date item);
        partial void OnAfterDateUpdated(ZarenTravelBO.Models.zaren_prod.Date item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Date> UpdateDate(int id, ZarenTravelBO.Models.zaren_prod.Date date)
        {
            OnDateUpdated(date);

            var itemToUpdate = Context.Dates
                              .Where(i => i.Id == date.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(date).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDateUpdated(date);

            return date;
        }

        partial void OnDateDeleted(ZarenTravelBO.Models.zaren_prod.Date item);
        partial void OnAfterDateDeleted(ZarenTravelBO.Models.zaren_prod.Date item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Date> DeleteDate(int id)
        {
            var itemToDelete = Context.Dates
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDateDeleted(itemToDelete);

            Reset();

            Context.Dates.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDateDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDeparturesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/departures/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/departures/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDeparturesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/departures/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/departures/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDeparturesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Departure> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Departure>> GetDepartures(Query query = null)
        {
            var items = Context.Departures.AsQueryable();


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

            OnDeparturesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDepartureGet(ZarenTravelBO.Models.zaren_prod.Departure item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Departure> GetDepartureById(int id)
        {
            var items = Context.Departures
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnDepartureGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDepartureCreated(ZarenTravelBO.Models.zaren_prod.Departure item);
        partial void OnAfterDepartureCreated(ZarenTravelBO.Models.zaren_prod.Departure item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Departure> CreateDeparture(ZarenTravelBO.Models.zaren_prod.Departure departure)
        {
            OnDepartureCreated(departure);

            var existingItem = Context.Departures
                              .Where(i => i.Id == departure.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Departures.Add(departure);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(departure).State = EntityState.Detached;
                throw;
            }

            OnAfterDepartureCreated(departure);

            return departure;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.Departure> CancelDepartureChanges(ZarenTravelBO.Models.zaren_prod.Departure item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDepartureUpdated(ZarenTravelBO.Models.zaren_prod.Departure item);
        partial void OnAfterDepartureUpdated(ZarenTravelBO.Models.zaren_prod.Departure item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Departure> UpdateDeparture(int id, ZarenTravelBO.Models.zaren_prod.Departure departure)
        {
            OnDepartureUpdated(departure);

            var itemToUpdate = Context.Departures
                              .Where(i => i.Id == departure.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(departure).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDepartureUpdated(departure);

            return departure;
        }

        partial void OnDepartureDeleted(ZarenTravelBO.Models.zaren_prod.Departure item);
        partial void OnAfterDepartureDeleted(ZarenTravelBO.Models.zaren_prod.Departure item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Departure> DeleteDeparture(int id)
        {
            var itemToDelete = Context.Departures
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDepartureDeleted(itemToDelete);

            Reset();

            Context.Departures.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDepartureDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportExplanationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/explanations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/explanations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportExplanationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/explanations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/explanations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnExplanationsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Explanation> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Explanation>> GetExplanations(Query query = null)
        {
            var items = Context.Explanations.AsQueryable();


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

            OnExplanationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnExplanationGet(ZarenTravelBO.Models.zaren_prod.Explanation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Explanation> GetExplanationById(int id)
        {
            var items = Context.Explanations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnExplanationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnExplanationCreated(ZarenTravelBO.Models.zaren_prod.Explanation item);
        partial void OnAfterExplanationCreated(ZarenTravelBO.Models.zaren_prod.Explanation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Explanation> CreateExplanation(ZarenTravelBO.Models.zaren_prod.Explanation explanation)
        {
            OnExplanationCreated(explanation);

            var existingItem = Context.Explanations
                              .Where(i => i.Id == explanation.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Explanations.Add(explanation);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(explanation).State = EntityState.Detached;
                throw;
            }

            OnAfterExplanationCreated(explanation);

            return explanation;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.Explanation> CancelExplanationChanges(ZarenTravelBO.Models.zaren_prod.Explanation item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnExplanationUpdated(ZarenTravelBO.Models.zaren_prod.Explanation item);
        partial void OnAfterExplanationUpdated(ZarenTravelBO.Models.zaren_prod.Explanation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Explanation> UpdateExplanation(int id, ZarenTravelBO.Models.zaren_prod.Explanation explanation)
        {
            OnExplanationUpdated(explanation);

            var itemToUpdate = Context.Explanations
                              .Where(i => i.Id == explanation.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(explanation).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterExplanationUpdated(explanation);

            return explanation;
        }

        partial void OnExplanationDeleted(ZarenTravelBO.Models.zaren_prod.Explanation item);
        partial void OnAfterExplanationDeleted(ZarenTravelBO.Models.zaren_prod.Explanation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Explanation> DeleteExplanation(int id)
        {
            var itemToDelete = Context.Explanations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnExplanationDeleted(itemToDelete);

            Reset();

            Context.Explanations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterExplanationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFeaturesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/features/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/features/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFeaturesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/features/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/features/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFeaturesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Feature> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Feature>> GetFeatures(Query query = null)
        {
            var items = Context.Features.AsQueryable();


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

            OnFeaturesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFeatureGet(ZarenTravelBO.Models.zaren_prod.Feature item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Feature> GetFeatureById(int id)
        {
            var items = Context.Features
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnFeatureGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFeatureCreated(ZarenTravelBO.Models.zaren_prod.Feature item);
        partial void OnAfterFeatureCreated(ZarenTravelBO.Models.zaren_prod.Feature item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Feature> CreateFeature(ZarenTravelBO.Models.zaren_prod.Feature feature)
        {
            OnFeatureCreated(feature);

            var existingItem = Context.Features
                              .Where(i => i.Id == feature.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Features.Add(feature);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(feature).State = EntityState.Detached;
                throw;
            }

            OnAfterFeatureCreated(feature);

            return feature;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.Feature> CancelFeatureChanges(ZarenTravelBO.Models.zaren_prod.Feature item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFeatureUpdated(ZarenTravelBO.Models.zaren_prod.Feature item);
        partial void OnAfterFeatureUpdated(ZarenTravelBO.Models.zaren_prod.Feature item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Feature> UpdateFeature(int id, ZarenTravelBO.Models.zaren_prod.Feature feature)
        {
            OnFeatureUpdated(feature);

            var itemToUpdate = Context.Features
                              .Where(i => i.Id == feature.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(feature).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFeatureUpdated(feature);

            return feature;
        }

        partial void OnFeatureDeleted(ZarenTravelBO.Models.zaren_prod.Feature item);
        partial void OnAfterFeatureDeleted(ZarenTravelBO.Models.zaren_prod.Feature item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Feature> DeleteFeature(int id)
        {
            var itemToDelete = Context.Features
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFeatureDeleted(itemToDelete);

            Reset();

            Context.Features.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFeatureDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFlightBrandsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/flightbrands/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/flightbrands/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFlightBrandsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/flightbrands/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/flightbrands/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFlightBrandsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.FlightBrand> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.FlightBrand>> GetFlightBrands(Query query = null)
        {
            var items = Context.FlightBrands.AsQueryable();


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

            OnFlightBrandsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFlightBrandGet(ZarenTravelBO.Models.zaren_prod.FlightBrand item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightBrand> GetFlightBrandById(int id)
        {
            var items = Context.FlightBrands
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnFlightBrandGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFlightBrandCreated(ZarenTravelBO.Models.zaren_prod.FlightBrand item);
        partial void OnAfterFlightBrandCreated(ZarenTravelBO.Models.zaren_prod.FlightBrand item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightBrand> CreateFlightBrand(ZarenTravelBO.Models.zaren_prod.FlightBrand flightbrand)
        {
            OnFlightBrandCreated(flightbrand);

            var existingItem = Context.FlightBrands
                              .Where(i => i.Id == flightbrand.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.FlightBrands.Add(flightbrand);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(flightbrand).State = EntityState.Detached;
                throw;
            }

            OnAfterFlightBrandCreated(flightbrand);

            return flightbrand;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightBrand> CancelFlightBrandChanges(ZarenTravelBO.Models.zaren_prod.FlightBrand item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFlightBrandUpdated(ZarenTravelBO.Models.zaren_prod.FlightBrand item);
        partial void OnAfterFlightBrandUpdated(ZarenTravelBO.Models.zaren_prod.FlightBrand item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightBrand> UpdateFlightBrand(int id, ZarenTravelBO.Models.zaren_prod.FlightBrand flightbrand)
        {
            OnFlightBrandUpdated(flightbrand);

            var itemToUpdate = Context.FlightBrands
                              .Where(i => i.Id == flightbrand.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(flightbrand).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFlightBrandUpdated(flightbrand);

            return flightbrand;
        }

        partial void OnFlightBrandDeleted(ZarenTravelBO.Models.zaren_prod.FlightBrand item);
        partial void OnAfterFlightBrandDeleted(ZarenTravelBO.Models.zaren_prod.FlightBrand item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightBrand> DeleteFlightBrand(int id)
        {
            var itemToDelete = Context.FlightBrands
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFlightBrandDeleted(itemToDelete);

            Reset();

            Context.FlightBrands.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFlightBrandDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFlightClassesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/flightclasses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/flightclasses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFlightClassesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/flightclasses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/flightclasses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFlightClassesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.FlightClass> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.FlightClass>> GetFlightClasses(Query query = null)
        {
            var items = Context.FlightClasses.AsQueryable();


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

            OnFlightClassesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFlightClassGet(ZarenTravelBO.Models.zaren_prod.FlightClass item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightClass> GetFlightClassById(int id)
        {
            var items = Context.FlightClasses
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnFlightClassGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFlightClassCreated(ZarenTravelBO.Models.zaren_prod.FlightClass item);
        partial void OnAfterFlightClassCreated(ZarenTravelBO.Models.zaren_prod.FlightClass item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightClass> CreateFlightClass(ZarenTravelBO.Models.zaren_prod.FlightClass flightclass)
        {
            OnFlightClassCreated(flightclass);

            var existingItem = Context.FlightClasses
                              .Where(i => i.Id == flightclass.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.FlightClasses.Add(flightclass);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(flightclass).State = EntityState.Detached;
                throw;
            }

            OnAfterFlightClassCreated(flightclass);

            return flightclass;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightClass> CancelFlightClassChanges(ZarenTravelBO.Models.zaren_prod.FlightClass item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFlightClassUpdated(ZarenTravelBO.Models.zaren_prod.FlightClass item);
        partial void OnAfterFlightClassUpdated(ZarenTravelBO.Models.zaren_prod.FlightClass item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightClass> UpdateFlightClass(int id, ZarenTravelBO.Models.zaren_prod.FlightClass flightclass)
        {
            OnFlightClassUpdated(flightclass);

            var itemToUpdate = Context.FlightClasses
                              .Where(i => i.Id == flightclass.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(flightclass).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFlightClassUpdated(flightclass);

            return flightclass;
        }

        partial void OnFlightClassDeleted(ZarenTravelBO.Models.zaren_prod.FlightClass item);
        partial void OnAfterFlightClassDeleted(ZarenTravelBO.Models.zaren_prod.FlightClass item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightClass> DeleteFlightClass(int id)
        {
            var itemToDelete = Context.FlightClasses
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFlightClassDeleted(itemToDelete);

            Reset();

            Context.FlightClasses.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFlightClassDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFlightFeesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/flightfees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/flightfees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFlightFeesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/flightfees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/flightfees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFlightFeesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.FlightFee> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.FlightFee>> GetFlightFees(Query query = null)
        {
            var items = Context.FlightFees.AsQueryable();


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

            OnFlightFeesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFlightFeeGet(ZarenTravelBO.Models.zaren_prod.FlightFee item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightFee> GetFlightFeeById(int id)
        {
            var items = Context.FlightFees
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnFlightFeeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFlightFeeCreated(ZarenTravelBO.Models.zaren_prod.FlightFee item);
        partial void OnAfterFlightFeeCreated(ZarenTravelBO.Models.zaren_prod.FlightFee item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightFee> CreateFlightFee(ZarenTravelBO.Models.zaren_prod.FlightFee flightfee)
        {
            OnFlightFeeCreated(flightfee);

            var existingItem = Context.FlightFees
                              .Where(i => i.Id == flightfee.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.FlightFees.Add(flightfee);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(flightfee).State = EntityState.Detached;
                throw;
            }

            OnAfterFlightFeeCreated(flightfee);

            return flightfee;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightFee> CancelFlightFeeChanges(ZarenTravelBO.Models.zaren_prod.FlightFee item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFlightFeeUpdated(ZarenTravelBO.Models.zaren_prod.FlightFee item);
        partial void OnAfterFlightFeeUpdated(ZarenTravelBO.Models.zaren_prod.FlightFee item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightFee> UpdateFlightFee(int id, ZarenTravelBO.Models.zaren_prod.FlightFee flightfee)
        {
            OnFlightFeeUpdated(flightfee);

            var itemToUpdate = Context.FlightFees
                              .Where(i => i.Id == flightfee.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(flightfee).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFlightFeeUpdated(flightfee);

            return flightfee;
        }

        partial void OnFlightFeeDeleted(ZarenTravelBO.Models.zaren_prod.FlightFee item);
        partial void OnAfterFlightFeeDeleted(ZarenTravelBO.Models.zaren_prod.FlightFee item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightFee> DeleteFlightFee(int id)
        {
            var itemToDelete = Context.FlightFees
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFlightFeeDeleted(itemToDelete);

            Reset();

            Context.FlightFees.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFlightFeeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFlightGeoLocationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/flightgeolocations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/flightgeolocations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFlightGeoLocationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/flightgeolocations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/flightgeolocations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFlightGeoLocationsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.FlightGeoLocation> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.FlightGeoLocation>> GetFlightGeoLocations(Query query = null)
        {
            var items = Context.FlightGeoLocations.AsQueryable();


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

            OnFlightGeoLocationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFlightGeoLocationGet(ZarenTravelBO.Models.zaren_prod.FlightGeoLocation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightGeoLocation> GetFlightGeoLocationById(int id)
        {
            var items = Context.FlightGeoLocations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnFlightGeoLocationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFlightGeoLocationCreated(ZarenTravelBO.Models.zaren_prod.FlightGeoLocation item);
        partial void OnAfterFlightGeoLocationCreated(ZarenTravelBO.Models.zaren_prod.FlightGeoLocation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightGeoLocation> CreateFlightGeoLocation(ZarenTravelBO.Models.zaren_prod.FlightGeoLocation flightgeolocation)
        {
            OnFlightGeoLocationCreated(flightgeolocation);

            var existingItem = Context.FlightGeoLocations
                              .Where(i => i.Id == flightgeolocation.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.FlightGeoLocations.Add(flightgeolocation);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(flightgeolocation).State = EntityState.Detached;
                throw;
            }

            OnAfterFlightGeoLocationCreated(flightgeolocation);

            return flightgeolocation;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightGeoLocation> CancelFlightGeoLocationChanges(ZarenTravelBO.Models.zaren_prod.FlightGeoLocation item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFlightGeoLocationUpdated(ZarenTravelBO.Models.zaren_prod.FlightGeoLocation item);
        partial void OnAfterFlightGeoLocationUpdated(ZarenTravelBO.Models.zaren_prod.FlightGeoLocation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightGeoLocation> UpdateFlightGeoLocation(int id, ZarenTravelBO.Models.zaren_prod.FlightGeoLocation flightgeolocation)
        {
            OnFlightGeoLocationUpdated(flightgeolocation);

            var itemToUpdate = Context.FlightGeoLocations
                              .Where(i => i.Id == flightgeolocation.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(flightgeolocation).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFlightGeoLocationUpdated(flightgeolocation);

            return flightgeolocation;
        }

        partial void OnFlightGeoLocationDeleted(ZarenTravelBO.Models.zaren_prod.FlightGeoLocation item);
        partial void OnAfterFlightGeoLocationDeleted(ZarenTravelBO.Models.zaren_prod.FlightGeoLocation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightGeoLocation> DeleteFlightGeoLocation(int id)
        {
            var itemToDelete = Context.FlightGeoLocations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFlightGeoLocationDeleted(itemToDelete);

            Reset();

            Context.FlightGeoLocations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFlightGeoLocationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFlightItemsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/flightitems/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/flightitems/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFlightItemsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/flightitems/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/flightitems/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFlightItemsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.FlightItem> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.FlightItem>> GetFlightItems(Query query = null)
        {
            var items = Context.FlightItems.AsQueryable();


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

            OnFlightItemsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFlightItemGet(ZarenTravelBO.Models.zaren_prod.FlightItem item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightItem> GetFlightItemById(int id)
        {
            var items = Context.FlightItems
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnFlightItemGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFlightItemCreated(ZarenTravelBO.Models.zaren_prod.FlightItem item);
        partial void OnAfterFlightItemCreated(ZarenTravelBO.Models.zaren_prod.FlightItem item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightItem> CreateFlightItem(ZarenTravelBO.Models.zaren_prod.FlightItem flightitem)
        {
            OnFlightItemCreated(flightitem);

            var existingItem = Context.FlightItems
                              .Where(i => i.Id == flightitem.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.FlightItems.Add(flightitem);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(flightitem).State = EntityState.Detached;
                throw;
            }

            OnAfterFlightItemCreated(flightitem);

            return flightitem;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightItem> CancelFlightItemChanges(ZarenTravelBO.Models.zaren_prod.FlightItem item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFlightItemUpdated(ZarenTravelBO.Models.zaren_prod.FlightItem item);
        partial void OnAfterFlightItemUpdated(ZarenTravelBO.Models.zaren_prod.FlightItem item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightItem> UpdateFlightItem(int id, ZarenTravelBO.Models.zaren_prod.FlightItem flightitem)
        {
            OnFlightItemUpdated(flightitem);

            var itemToUpdate = Context.FlightItems
                              .Where(i => i.Id == flightitem.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(flightitem).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFlightItemUpdated(flightitem);

            return flightitem;
        }

        partial void OnFlightItemDeleted(ZarenTravelBO.Models.zaren_prod.FlightItem item);
        partial void OnAfterFlightItemDeleted(ZarenTravelBO.Models.zaren_prod.FlightItem item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightItem> DeleteFlightItem(int id)
        {
            var itemToDelete = Context.FlightItems
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFlightItemDeleted(itemToDelete);

            Reset();

            Context.FlightItems.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFlightItemDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFlightOffersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/flightoffers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/flightoffers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFlightOffersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/flightoffers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/flightoffers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFlightOffersRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.FlightOffer> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.FlightOffer>> GetFlightOffers(Query query = null)
        {
            var items = Context.FlightOffers.AsQueryable();


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

            OnFlightOffersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFlightOfferGet(ZarenTravelBO.Models.zaren_prod.FlightOffer item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightOffer> GetFlightOfferById(int id)
        {
            var items = Context.FlightOffers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnFlightOfferGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFlightOfferCreated(ZarenTravelBO.Models.zaren_prod.FlightOffer item);
        partial void OnAfterFlightOfferCreated(ZarenTravelBO.Models.zaren_prod.FlightOffer item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightOffer> CreateFlightOffer(ZarenTravelBO.Models.zaren_prod.FlightOffer flightoffer)
        {
            OnFlightOfferCreated(flightoffer);

            var existingItem = Context.FlightOffers
                              .Where(i => i.Id == flightoffer.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.FlightOffers.Add(flightoffer);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(flightoffer).State = EntityState.Detached;
                throw;
            }

            OnAfterFlightOfferCreated(flightoffer);

            return flightoffer;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightOffer> CancelFlightOfferChanges(ZarenTravelBO.Models.zaren_prod.FlightOffer item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFlightOfferUpdated(ZarenTravelBO.Models.zaren_prod.FlightOffer item);
        partial void OnAfterFlightOfferUpdated(ZarenTravelBO.Models.zaren_prod.FlightOffer item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightOffer> UpdateFlightOffer(int id, ZarenTravelBO.Models.zaren_prod.FlightOffer flightoffer)
        {
            OnFlightOfferUpdated(flightoffer);

            var itemToUpdate = Context.FlightOffers
                              .Where(i => i.Id == flightoffer.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(flightoffer).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFlightOfferUpdated(flightoffer);

            return flightoffer;
        }

        partial void OnFlightOfferDeleted(ZarenTravelBO.Models.zaren_prod.FlightOffer item);
        partial void OnAfterFlightOfferDeleted(ZarenTravelBO.Models.zaren_prod.FlightOffer item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightOffer> DeleteFlightOffer(int id)
        {
            var itemToDelete = Context.FlightOffers
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFlightOfferDeleted(itemToDelete);

            Reset();

            Context.FlightOffers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFlightOfferDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFlightProvidersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/flightproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/flightproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFlightProvidersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/flightproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/flightproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFlightProvidersRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.FlightProvider> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.FlightProvider>> GetFlightProviders(Query query = null)
        {
            var items = Context.FlightProviders.AsQueryable();


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

            OnFlightProvidersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFlightProviderGet(ZarenTravelBO.Models.zaren_prod.FlightProvider item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightProvider> GetFlightProviderById(int id)
        {
            var items = Context.FlightProviders
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnFlightProviderGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFlightProviderCreated(ZarenTravelBO.Models.zaren_prod.FlightProvider item);
        partial void OnAfterFlightProviderCreated(ZarenTravelBO.Models.zaren_prod.FlightProvider item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightProvider> CreateFlightProvider(ZarenTravelBO.Models.zaren_prod.FlightProvider flightprovider)
        {
            OnFlightProviderCreated(flightprovider);

            var existingItem = Context.FlightProviders
                              .Where(i => i.Id == flightprovider.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.FlightProviders.Add(flightprovider);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(flightprovider).State = EntityState.Detached;
                throw;
            }

            OnAfterFlightProviderCreated(flightprovider);

            return flightprovider;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightProvider> CancelFlightProviderChanges(ZarenTravelBO.Models.zaren_prod.FlightProvider item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFlightProviderUpdated(ZarenTravelBO.Models.zaren_prod.FlightProvider item);
        partial void OnAfterFlightProviderUpdated(ZarenTravelBO.Models.zaren_prod.FlightProvider item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightProvider> UpdateFlightProvider(int id, ZarenTravelBO.Models.zaren_prod.FlightProvider flightprovider)
        {
            OnFlightProviderUpdated(flightprovider);

            var itemToUpdate = Context.FlightProviders
                              .Where(i => i.Id == flightprovider.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(flightprovider).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFlightProviderUpdated(flightprovider);

            return flightprovider;
        }

        partial void OnFlightProviderDeleted(ZarenTravelBO.Models.zaren_prod.FlightProvider item);
        partial void OnAfterFlightProviderDeleted(ZarenTravelBO.Models.zaren_prod.FlightProvider item);

        public async Task<ZarenTravelBO.Models.zaren_prod.FlightProvider> DeleteFlightProvider(int id)
        {
            var itemToDelete = Context.FlightProviders
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFlightProviderDeleted(itemToDelete);

            Reset();

            Context.FlightProviders.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFlightProviderDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFlightsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/flights/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/flights/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFlightsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/flights/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/flights/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFlightsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Flight> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Flight>> GetFlights(Query query = null)
        {
            var items = Context.Flights.AsQueryable();


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

            OnFlightsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFlightGet(ZarenTravelBO.Models.zaren_prod.Flight item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Flight> GetFlightById(int id)
        {
            var items = Context.Flights
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnFlightGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFlightCreated(ZarenTravelBO.Models.zaren_prod.Flight item);
        partial void OnAfterFlightCreated(ZarenTravelBO.Models.zaren_prod.Flight item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Flight> CreateFlight(ZarenTravelBO.Models.zaren_prod.Flight flight)
        {
            OnFlightCreated(flight);

            var existingItem = Context.Flights
                              .Where(i => i.Id == flight.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Flights.Add(flight);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(flight).State = EntityState.Detached;
                throw;
            }

            OnAfterFlightCreated(flight);

            return flight;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.Flight> CancelFlightChanges(ZarenTravelBO.Models.zaren_prod.Flight item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFlightUpdated(ZarenTravelBO.Models.zaren_prod.Flight item);
        partial void OnAfterFlightUpdated(ZarenTravelBO.Models.zaren_prod.Flight item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Flight> UpdateFlight(int id, ZarenTravelBO.Models.zaren_prod.Flight flight)
        {
            OnFlightUpdated(flight);

            var itemToUpdate = Context.Flights
                              .Where(i => i.Id == flight.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(flight).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFlightUpdated(flight);

            return flight;
        }

        partial void OnFlightDeleted(ZarenTravelBO.Models.zaren_prod.Flight item);
        partial void OnAfterFlightDeleted(ZarenTravelBO.Models.zaren_prod.Flight item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Flight> DeleteFlight(int id)
        {
            var itemToDelete = Context.Flights
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFlightDeleted(itemToDelete);

            Reset();

            Context.Flights.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFlightDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportGendersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/genders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/genders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportGendersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/genders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/genders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGendersRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Gender> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Gender>> GetGenders(Query query = null)
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

        partial void OnGenderGet(ZarenTravelBO.Models.zaren_prod.Gender item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Gender> GetGenderById(int id)
        {
            var items = Context.Genders
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnGenderGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnGenderCreated(ZarenTravelBO.Models.zaren_prod.Gender item);
        partial void OnAfterGenderCreated(ZarenTravelBO.Models.zaren_prod.Gender item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Gender> CreateGender(ZarenTravelBO.Models.zaren_prod.Gender gender)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.Gender> CancelGenderChanges(ZarenTravelBO.Models.zaren_prod.Gender item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnGenderUpdated(ZarenTravelBO.Models.zaren_prod.Gender item);
        partial void OnAfterGenderUpdated(ZarenTravelBO.Models.zaren_prod.Gender item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Gender> UpdateGender(int id, ZarenTravelBO.Models.zaren_prod.Gender gender)
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

        partial void OnGenderDeleted(ZarenTravelBO.Models.zaren_prod.Gender item);
        partial void OnAfterGenderDeleted(ZarenTravelBO.Models.zaren_prod.Gender item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Gender> DeleteGender(int id)
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
    
        public async Task ExportGroupKeysToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/groupkeys/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/groupkeys/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportGroupKeysToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/groupkeys/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/groupkeys/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGroupKeysRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.GroupKey> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.GroupKey>> GetGroupKeys(Query query = null)
        {
            var items = Context.GroupKeys.AsQueryable();


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

            OnGroupKeysRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnGroupKeyGet(ZarenTravelBO.Models.zaren_prod.GroupKey item);

        public async Task<ZarenTravelBO.Models.zaren_prod.GroupKey> GetGroupKeyById(int id)
        {
            var items = Context.GroupKeys
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnGroupKeyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnGroupKeyCreated(ZarenTravelBO.Models.zaren_prod.GroupKey item);
        partial void OnAfterGroupKeyCreated(ZarenTravelBO.Models.zaren_prod.GroupKey item);

        public async Task<ZarenTravelBO.Models.zaren_prod.GroupKey> CreateGroupKey(ZarenTravelBO.Models.zaren_prod.GroupKey groupkey)
        {
            OnGroupKeyCreated(groupkey);

            var existingItem = Context.GroupKeys
                              .Where(i => i.Id == groupkey.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.GroupKeys.Add(groupkey);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(groupkey).State = EntityState.Detached;
                throw;
            }

            OnAfterGroupKeyCreated(groupkey);

            return groupkey;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.GroupKey> CancelGroupKeyChanges(ZarenTravelBO.Models.zaren_prod.GroupKey item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnGroupKeyUpdated(ZarenTravelBO.Models.zaren_prod.GroupKey item);
        partial void OnAfterGroupKeyUpdated(ZarenTravelBO.Models.zaren_prod.GroupKey item);

        public async Task<ZarenTravelBO.Models.zaren_prod.GroupKey> UpdateGroupKey(int id, ZarenTravelBO.Models.zaren_prod.GroupKey groupkey)
        {
            OnGroupKeyUpdated(groupkey);

            var itemToUpdate = Context.GroupKeys
                              .Where(i => i.Id == groupkey.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(groupkey).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterGroupKeyUpdated(groupkey);

            return groupkey;
        }

        partial void OnGroupKeyDeleted(ZarenTravelBO.Models.zaren_prod.GroupKey item);
        partial void OnAfterGroupKeyDeleted(ZarenTravelBO.Models.zaren_prod.GroupKey item);

        public async Task<ZarenTravelBO.Models.zaren_prod.GroupKey> DeleteGroupKey(int id)
        {
            var itemToDelete = Context.GroupKeys
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnGroupKeyDeleted(itemToDelete);

            Reset();

            Context.GroupKeys.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterGroupKeyDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelCategoriesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.HotelCategory> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.HotelCategory>> GetHotelCategories(Query query = null)
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

        partial void OnHotelCategoryGet(ZarenTravelBO.Models.zaren_prod.HotelCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelCategory> GetHotelCategoryById(int id)
        {
            var items = Context.HotelCategories
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelCategoryCreated(ZarenTravelBO.Models.zaren_prod.HotelCategory item);
        partial void OnAfterHotelCategoryCreated(ZarenTravelBO.Models.zaren_prod.HotelCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelCategory> CreateHotelCategory(ZarenTravelBO.Models.zaren_prod.HotelCategory hotelcategory)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelCategory> CancelHotelCategoryChanges(ZarenTravelBO.Models.zaren_prod.HotelCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelCategoryUpdated(ZarenTravelBO.Models.zaren_prod.HotelCategory item);
        partial void OnAfterHotelCategoryUpdated(ZarenTravelBO.Models.zaren_prod.HotelCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelCategory> UpdateHotelCategory(int id, ZarenTravelBO.Models.zaren_prod.HotelCategory hotelcategory)
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

            Context.Attach(hotelcategory).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelCategoryUpdated(hotelcategory);

            return hotelcategory;
        }

        partial void OnHotelCategoryDeleted(ZarenTravelBO.Models.zaren_prod.HotelCategory item);
        partial void OnAfterHotelCategoryDeleted(ZarenTravelBO.Models.zaren_prod.HotelCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelCategory> DeleteHotelCategory(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelfacilities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelfacilities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelFacilitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelfacilities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelfacilities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelFacilitiesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.HotelFacility> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.HotelFacility>> GetHotelFacilities(Query query = null)
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

        partial void OnHotelFacilityGet(ZarenTravelBO.Models.zaren_prod.HotelFacility item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelFacility> GetHotelFacilityById(int id)
        {
            var items = Context.HotelFacilities
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelFacilityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelFacilityCreated(ZarenTravelBO.Models.zaren_prod.HotelFacility item);
        partial void OnAfterHotelFacilityCreated(ZarenTravelBO.Models.zaren_prod.HotelFacility item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelFacility> CreateHotelFacility(ZarenTravelBO.Models.zaren_prod.HotelFacility hotelfacility)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelFacility> CancelHotelFacilityChanges(ZarenTravelBO.Models.zaren_prod.HotelFacility item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelFacilityUpdated(ZarenTravelBO.Models.zaren_prod.HotelFacility item);
        partial void OnAfterHotelFacilityUpdated(ZarenTravelBO.Models.zaren_prod.HotelFacility item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelFacility> UpdateHotelFacility(int id, ZarenTravelBO.Models.zaren_prod.HotelFacility hotelfacility)
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

        partial void OnHotelFacilityDeleted(ZarenTravelBO.Models.zaren_prod.HotelFacility item);
        partial void OnAfterHotelFacilityDeleted(ZarenTravelBO.Models.zaren_prod.HotelFacility item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelFacility> DeleteHotelFacility(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelfacilitycategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelfacilitycategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelFacilityCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelfacilitycategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelfacilitycategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelFacilityCategoriesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory>> GetHotelFacilityCategories(Query query = null)
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

        partial void OnHotelFacilityCategoryGet(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory> GetHotelFacilityCategoryById(int id)
        {
            var items = Context.HotelFacilityCategories
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelFacilityCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelFacilityCategoryCreated(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory item);
        partial void OnAfterHotelFacilityCategoryCreated(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory> CreateHotelFacilityCategory(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory hotelfacilitycategory)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory> CancelHotelFacilityCategoryChanges(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelFacilityCategoryUpdated(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory item);
        partial void OnAfterHotelFacilityCategoryUpdated(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory> UpdateHotelFacilityCategory(int id, ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory hotelfacilitycategory)
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

        partial void OnHotelFacilityCategoryDeleted(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory item);
        partial void OnAfterHotelFacilityCategoryDeleted(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelFacilityCategory> DeleteHotelFacilityCategory(int id)
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
    
        public async Task ExportHotelFacilityCategorySelectedFacilitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelfacilitycategoryselectedfacilities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelfacilitycategoryselectedfacilities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelFacilityCategorySelectedFacilitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelfacilitycategoryselectedfacilities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelfacilitycategoryselectedfacilities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelFacilityCategorySelectedFacilitiesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility>> GetHotelFacilityCategorySelectedFacilities(Query query = null)
        {
            var items = Context.HotelFacilityCategorySelectedFacilities.AsQueryable();


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

            OnHotelFacilityCategorySelectedFacilitiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelFacilityCategorySelectedFacilityGet(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility> GetHotelFacilityCategorySelectedFacilityById(int id)
        {
            var items = Context.HotelFacilityCategorySelectedFacilities
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelFacilityCategorySelectedFacilityGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelFacilityCategorySelectedFacilityCreated(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility item);
        partial void OnAfterHotelFacilityCategorySelectedFacilityCreated(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility> CreateHotelFacilityCategorySelectedFacility(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility hotelfacilitycategoryselectedfacility)
        {
            OnHotelFacilityCategorySelectedFacilityCreated(hotelfacilitycategoryselectedfacility);

            var existingItem = Context.HotelFacilityCategorySelectedFacilities
                              .Where(i => i.Id == hotelfacilitycategoryselectedfacility.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelFacilityCategorySelectedFacilities.Add(hotelfacilitycategoryselectedfacility);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelfacilitycategoryselectedfacility).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelFacilityCategorySelectedFacilityCreated(hotelfacilitycategoryselectedfacility);

            return hotelfacilitycategoryselectedfacility;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility> CancelHotelFacilityCategorySelectedFacilityChanges(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelFacilityCategorySelectedFacilityUpdated(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility item);
        partial void OnAfterHotelFacilityCategorySelectedFacilityUpdated(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility> UpdateHotelFacilityCategorySelectedFacility(int id, ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility hotelfacilitycategoryselectedfacility)
        {
            OnHotelFacilityCategorySelectedFacilityUpdated(hotelfacilitycategoryselectedfacility);

            var itemToUpdate = Context.HotelFacilityCategorySelectedFacilities
                              .Where(i => i.Id == hotelfacilitycategoryselectedfacility.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(hotelfacilitycategoryselectedfacility).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelFacilityCategorySelectedFacilityUpdated(hotelfacilitycategoryselectedfacility);

            return hotelfacilitycategoryselectedfacility;
        }

        partial void OnHotelFacilityCategorySelectedFacilityDeleted(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility item);
        partial void OnAfterHotelFacilityCategorySelectedFacilityDeleted(ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelFacilityCategorySelectedFacility> DeleteHotelFacilityCategorySelectedFacility(int id)
        {
            var itemToDelete = Context.HotelFacilityCategorySelectedFacilities
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelFacilityCategorySelectedFacilityDeleted(itemToDelete);

            Reset();

            Context.HotelFacilityCategorySelectedFacilities.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelFacilityCategorySelectedFacilityDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelPresentationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelpresentations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelpresentations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelPresentationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelpresentations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelpresentations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelPresentationsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.HotelPresentation> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.HotelPresentation>> GetHotelPresentations(Query query = null)
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

        partial void OnHotelPresentationGet(ZarenTravelBO.Models.zaren_prod.HotelPresentation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelPresentation> GetHotelPresentationById(int id)
        {
            var items = Context.HotelPresentations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelPresentationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelPresentationCreated(ZarenTravelBO.Models.zaren_prod.HotelPresentation item);
        partial void OnAfterHotelPresentationCreated(ZarenTravelBO.Models.zaren_prod.HotelPresentation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelPresentation> CreateHotelPresentation(ZarenTravelBO.Models.zaren_prod.HotelPresentation hotelpresentation)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelPresentation> CancelHotelPresentationChanges(ZarenTravelBO.Models.zaren_prod.HotelPresentation item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelPresentationUpdated(ZarenTravelBO.Models.zaren_prod.HotelPresentation item);
        partial void OnAfterHotelPresentationUpdated(ZarenTravelBO.Models.zaren_prod.HotelPresentation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelPresentation> UpdateHotelPresentation(int id, ZarenTravelBO.Models.zaren_prod.HotelPresentation hotelpresentation)
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

        partial void OnHotelPresentationDeleted(ZarenTravelBO.Models.zaren_prod.HotelPresentation item);
        partial void OnAfterHotelPresentationDeleted(ZarenTravelBO.Models.zaren_prod.HotelPresentation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelPresentation> DeleteHotelPresentation(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Hotel> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Hotel>> GetHotels(Query query = null)
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

        partial void OnHotelGet(ZarenTravelBO.Models.zaren_prod.Hotel item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Hotel> GetHotelById(int id)
        {
            var items = Context.Hotels
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelCreated(ZarenTravelBO.Models.zaren_prod.Hotel item);
        partial void OnAfterHotelCreated(ZarenTravelBO.Models.zaren_prod.Hotel item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Hotel> CreateHotel(ZarenTravelBO.Models.zaren_prod.Hotel hotel)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.Hotel> CancelHotelChanges(ZarenTravelBO.Models.zaren_prod.Hotel item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelUpdated(ZarenTravelBO.Models.zaren_prod.Hotel item);
        partial void OnAfterHotelUpdated(ZarenTravelBO.Models.zaren_prod.Hotel item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Hotel> UpdateHotel(int id, ZarenTravelBO.Models.zaren_prod.Hotel hotel)
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

        partial void OnHotelDeleted(ZarenTravelBO.Models.zaren_prod.Hotel item);
        partial void OnAfterHotelDeleted(ZarenTravelBO.Models.zaren_prod.Hotel item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Hotel> DeleteHotel(int id)
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
    
        public async Task ExportHotelSeasonMediaFilesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelseasonmediafiles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelseasonmediafiles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelSeasonMediaFilesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelseasonmediafiles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelseasonmediafiles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelSeasonMediaFilesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile>> GetHotelSeasonMediaFiles(Query query = null)
        {
            var items = Context.HotelSeasonMediaFiles.AsQueryable();


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

            OnHotelSeasonMediaFilesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelSeasonMediaFileGet(ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile> GetHotelSeasonMediaFileById(int id)
        {
            var items = Context.HotelSeasonMediaFiles
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelSeasonMediaFileGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelSeasonMediaFileCreated(ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile item);
        partial void OnAfterHotelSeasonMediaFileCreated(ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile> CreateHotelSeasonMediaFile(ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile hotelseasonmediafile)
        {
            OnHotelSeasonMediaFileCreated(hotelseasonmediafile);

            var existingItem = Context.HotelSeasonMediaFiles
                              .Where(i => i.Id == hotelseasonmediafile.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelSeasonMediaFiles.Add(hotelseasonmediafile);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelseasonmediafile).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelSeasonMediaFileCreated(hotelseasonmediafile);

            return hotelseasonmediafile;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile> CancelHotelSeasonMediaFileChanges(ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelSeasonMediaFileUpdated(ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile item);
        partial void OnAfterHotelSeasonMediaFileUpdated(ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile> UpdateHotelSeasonMediaFile(int id, ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile hotelseasonmediafile)
        {
            OnHotelSeasonMediaFileUpdated(hotelseasonmediafile);

            var itemToUpdate = Context.HotelSeasonMediaFiles
                              .Where(i => i.Id == hotelseasonmediafile.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(hotelseasonmediafile).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelSeasonMediaFileUpdated(hotelseasonmediafile);

            return hotelseasonmediafile;
        }

        partial void OnHotelSeasonMediaFileDeleted(ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile item);
        partial void OnAfterHotelSeasonMediaFileDeleted(ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSeasonMediaFile> DeleteHotelSeasonMediaFile(int id)
        {
            var itemToDelete = Context.HotelSeasonMediaFiles
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelSeasonMediaFileDeleted(itemToDelete);

            Reset();

            Context.HotelSeasonMediaFiles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelSeasonMediaFileDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelSeasonsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelseasons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelseasons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelSeasonsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelseasons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelseasons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelSeasonsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.HotelSeason> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.HotelSeason>> GetHotelSeasons(Query query = null)
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

        partial void OnHotelSeasonGet(ZarenTravelBO.Models.zaren_prod.HotelSeason item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSeason> GetHotelSeasonById(int id)
        {
            var items = Context.HotelSeasons
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelSeasonGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelSeasonCreated(ZarenTravelBO.Models.zaren_prod.HotelSeason item);
        partial void OnAfterHotelSeasonCreated(ZarenTravelBO.Models.zaren_prod.HotelSeason item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSeason> CreateHotelSeason(ZarenTravelBO.Models.zaren_prod.HotelSeason hotelseason)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSeason> CancelHotelSeasonChanges(ZarenTravelBO.Models.zaren_prod.HotelSeason item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelSeasonUpdated(ZarenTravelBO.Models.zaren_prod.HotelSeason item);
        partial void OnAfterHotelSeasonUpdated(ZarenTravelBO.Models.zaren_prod.HotelSeason item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSeason> UpdateHotelSeason(int id, ZarenTravelBO.Models.zaren_prod.HotelSeason hotelseason)
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

        partial void OnHotelSeasonDeleted(ZarenTravelBO.Models.zaren_prod.HotelSeason item);
        partial void OnAfterHotelSeasonDeleted(ZarenTravelBO.Models.zaren_prod.HotelSeason item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSeason> DeleteHotelSeason(int id)
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
    
        public async Task ExportHotelSeasonSelectedTextCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelseasonselectedtextcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelseasonselectedtextcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelSeasonSelectedTextCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelseasonselectedtextcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelseasonselectedtextcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelSeasonSelectedTextCategoriesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory>> GetHotelSeasonSelectedTextCategories(Query query = null)
        {
            var items = Context.HotelSeasonSelectedTextCategories.AsQueryable();


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

            OnHotelSeasonSelectedTextCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelSeasonSelectedTextCategoryGet(ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory> GetHotelSeasonSelectedTextCategoryById(int id)
        {
            var items = Context.HotelSeasonSelectedTextCategories
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelSeasonSelectedTextCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelSeasonSelectedTextCategoryCreated(ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory item);
        partial void OnAfterHotelSeasonSelectedTextCategoryCreated(ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory> CreateHotelSeasonSelectedTextCategory(ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory hotelseasonselectedtextcategory)
        {
            OnHotelSeasonSelectedTextCategoryCreated(hotelseasonselectedtextcategory);

            var existingItem = Context.HotelSeasonSelectedTextCategories
                              .Where(i => i.Id == hotelseasonselectedtextcategory.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelSeasonSelectedTextCategories.Add(hotelseasonselectedtextcategory);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelseasonselectedtextcategory).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelSeasonSelectedTextCategoryCreated(hotelseasonselectedtextcategory);

            return hotelseasonselectedtextcategory;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory> CancelHotelSeasonSelectedTextCategoryChanges(ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelSeasonSelectedTextCategoryUpdated(ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory item);
        partial void OnAfterHotelSeasonSelectedTextCategoryUpdated(ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory> UpdateHotelSeasonSelectedTextCategory(int id, ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory hotelseasonselectedtextcategory)
        {
            OnHotelSeasonSelectedTextCategoryUpdated(hotelseasonselectedtextcategory);

            var itemToUpdate = Context.HotelSeasonSelectedTextCategories
                              .Where(i => i.Id == hotelseasonselectedtextcategory.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(hotelseasonselectedtextcategory).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelSeasonSelectedTextCategoryUpdated(hotelseasonselectedtextcategory);

            return hotelseasonselectedtextcategory;
        }

        partial void OnHotelSeasonSelectedTextCategoryDeleted(ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory item);
        partial void OnAfterHotelSeasonSelectedTextCategoryDeleted(ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSeasonSelectedTextCategory> DeleteHotelSeasonSelectedTextCategory(int id)
        {
            var itemToDelete = Context.HotelSeasonSelectedTextCategories
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelSeasonSelectedTextCategoryDeleted(itemToDelete);

            Reset();

            Context.HotelSeasonSelectedTextCategories.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelSeasonSelectedTextCategoryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelSelectedCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelselectedcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelselectedcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelSelectedCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hotelselectedcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hotelselectedcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelSelectedCategoriesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory>> GetHotelSelectedCategories(Query query = null)
        {
            var items = Context.HotelSelectedCategories.AsQueryable();


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

            OnHotelSelectedCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelSelectedCategoryGet(ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory> GetHotelSelectedCategoryById(int id)
        {
            var items = Context.HotelSelectedCategories
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelSelectedCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelSelectedCategoryCreated(ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory item);
        partial void OnAfterHotelSelectedCategoryCreated(ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory> CreateHotelSelectedCategory(ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory hotelselectedcategory)
        {
            OnHotelSelectedCategoryCreated(hotelselectedcategory);

            var existingItem = Context.HotelSelectedCategories
                              .Where(i => i.Id == hotelselectedcategory.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelSelectedCategories.Add(hotelselectedcategory);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hotelselectedcategory).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelSelectedCategoryCreated(hotelselectedcategory);

            return hotelselectedcategory;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory> CancelHotelSelectedCategoryChanges(ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelSelectedCategoryUpdated(ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory item);
        partial void OnAfterHotelSelectedCategoryUpdated(ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory> UpdateHotelSelectedCategory(int id, ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory hotelselectedcategory)
        {
            OnHotelSelectedCategoryUpdated(hotelselectedcategory);

            var itemToUpdate = Context.HotelSelectedCategories
                              .Where(i => i.Id == hotelselectedcategory.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(hotelselectedcategory).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelSelectedCategoryUpdated(hotelselectedcategory);

            return hotelselectedcategory;
        }

        partial void OnHotelSelectedCategoryDeleted(ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory item);
        partial void OnAfterHotelSelectedCategoryDeleted(ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelSelectedCategory> DeleteHotelSelectedCategory(int id)
        {
            var itemToDelete = Context.HotelSelectedCategories
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelSelectedCategoryDeleted(itemToDelete);

            Reset();

            Context.HotelSelectedCategories.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelSelectedCategoryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelTextCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hoteltextcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hoteltextcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelTextCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hoteltextcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hoteltextcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelTextCategoriesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.HotelTextCategory> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.HotelTextCategory>> GetHotelTextCategories(Query query = null)
        {
            var items = Context.HotelTextCategories.AsQueryable();


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

            OnHotelTextCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelTextCategoryGet(ZarenTravelBO.Models.zaren_prod.HotelTextCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelTextCategory> GetHotelTextCategoryById(int id)
        {
            var items = Context.HotelTextCategories
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelTextCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelTextCategoryCreated(ZarenTravelBO.Models.zaren_prod.HotelTextCategory item);
        partial void OnAfterHotelTextCategoryCreated(ZarenTravelBO.Models.zaren_prod.HotelTextCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelTextCategory> CreateHotelTextCategory(ZarenTravelBO.Models.zaren_prod.HotelTextCategory hoteltextcategory)
        {
            OnHotelTextCategoryCreated(hoteltextcategory);

            var existingItem = Context.HotelTextCategories
                              .Where(i => i.Id == hoteltextcategory.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelTextCategories.Add(hoteltextcategory);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hoteltextcategory).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelTextCategoryCreated(hoteltextcategory);

            return hoteltextcategory;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelTextCategory> CancelHotelTextCategoryChanges(ZarenTravelBO.Models.zaren_prod.HotelTextCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelTextCategoryUpdated(ZarenTravelBO.Models.zaren_prod.HotelTextCategory item);
        partial void OnAfterHotelTextCategoryUpdated(ZarenTravelBO.Models.zaren_prod.HotelTextCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelTextCategory> UpdateHotelTextCategory(int id, ZarenTravelBO.Models.zaren_prod.HotelTextCategory hoteltextcategory)
        {
            OnHotelTextCategoryUpdated(hoteltextcategory);

            var itemToUpdate = Context.HotelTextCategories
                              .Where(i => i.Id == hoteltextcategory.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(hoteltextcategory).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelTextCategoryUpdated(hoteltextcategory);

            return hoteltextcategory;
        }

        partial void OnHotelTextCategoryDeleted(ZarenTravelBO.Models.zaren_prod.HotelTextCategory item);
        partial void OnAfterHotelTextCategoryDeleted(ZarenTravelBO.Models.zaren_prod.HotelTextCategory item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelTextCategory> DeleteHotelTextCategory(int id)
        {
            var itemToDelete = Context.HotelTextCategories
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelTextCategoryDeleted(itemToDelete);

            Reset();

            Context.HotelTextCategories.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelTextCategoryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportHotelTextCategoriesSelectedPresentationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hoteltextcategoriesselectedpresentations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hoteltextcategoriesselectedpresentations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportHotelTextCategoriesSelectedPresentationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/hoteltextcategoriesselectedpresentations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/hoteltextcategoriesselectedpresentations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnHotelTextCategoriesSelectedPresentationsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation>> GetHotelTextCategoriesSelectedPresentations(Query query = null)
        {
            var items = Context.HotelTextCategoriesSelectedPresentations.AsQueryable();


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

            OnHotelTextCategoriesSelectedPresentationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnHotelTextCategoriesSelectedPresentationGet(ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation> GetHotelTextCategoriesSelectedPresentationById(int id)
        {
            var items = Context.HotelTextCategoriesSelectedPresentations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnHotelTextCategoriesSelectedPresentationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnHotelTextCategoriesSelectedPresentationCreated(ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation item);
        partial void OnAfterHotelTextCategoriesSelectedPresentationCreated(ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation> CreateHotelTextCategoriesSelectedPresentation(ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation hoteltextcategoriesselectedpresentation)
        {
            OnHotelTextCategoriesSelectedPresentationCreated(hoteltextcategoriesselectedpresentation);

            var existingItem = Context.HotelTextCategoriesSelectedPresentations
                              .Where(i => i.Id == hoteltextcategoriesselectedpresentation.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.HotelTextCategoriesSelectedPresentations.Add(hoteltextcategoriesselectedpresentation);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(hoteltextcategoriesselectedpresentation).State = EntityState.Detached;
                throw;
            }

            OnAfterHotelTextCategoriesSelectedPresentationCreated(hoteltextcategoriesselectedpresentation);

            return hoteltextcategoriesselectedpresentation;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation> CancelHotelTextCategoriesSelectedPresentationChanges(ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnHotelTextCategoriesSelectedPresentationUpdated(ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation item);
        partial void OnAfterHotelTextCategoriesSelectedPresentationUpdated(ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation> UpdateHotelTextCategoriesSelectedPresentation(int id, ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation hoteltextcategoriesselectedpresentation)
        {
            OnHotelTextCategoriesSelectedPresentationUpdated(hoteltextcategoriesselectedpresentation);

            var itemToUpdate = Context.HotelTextCategoriesSelectedPresentations
                              .Where(i => i.Id == hoteltextcategoriesselectedpresentation.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(hoteltextcategoriesselectedpresentation).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterHotelTextCategoriesSelectedPresentationUpdated(hoteltextcategoriesselectedpresentation);

            return hoteltextcategoriesselectedpresentation;
        }

        partial void OnHotelTextCategoriesSelectedPresentationDeleted(ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation item);
        partial void OnAfterHotelTextCategoriesSelectedPresentationDeleted(ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation item);

        public async Task<ZarenTravelBO.Models.zaren_prod.HotelTextCategoriesSelectedPresentation> DeleteHotelTextCategoriesSelectedPresentation(int id)
        {
            var itemToDelete = Context.HotelTextCategoriesSelectedPresentations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnHotelTextCategoriesSelectedPresentationDeleted(itemToDelete);

            Reset();

            Context.HotelTextCategoriesSelectedPresentations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterHotelTextCategoriesSelectedPresentationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportInsuranceSelectedLangsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/insuranceselectedlangs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/insuranceselectedlangs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInsuranceSelectedLangsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/insuranceselectedlangs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/insuranceselectedlangs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInsuranceSelectedLangsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang>> GetInsuranceSelectedLangs(Query query = null)
        {
            var items = Context.InsuranceSelectedLangs.AsQueryable();


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

            OnInsuranceSelectedLangsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnInsuranceSelectedLangGet(ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang item);

        public async Task<ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang> GetInsuranceSelectedLangById(int id)
        {
            var items = Context.InsuranceSelectedLangs
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnInsuranceSelectedLangGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnInsuranceSelectedLangCreated(ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang item);
        partial void OnAfterInsuranceSelectedLangCreated(ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang item);

        public async Task<ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang> CreateInsuranceSelectedLang(ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang insuranceselectedlang)
        {
            OnInsuranceSelectedLangCreated(insuranceselectedlang);

            var existingItem = Context.InsuranceSelectedLangs
                              .Where(i => i.Id == insuranceselectedlang.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.InsuranceSelectedLangs.Add(insuranceselectedlang);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(insuranceselectedlang).State = EntityState.Detached;
                throw;
            }

            OnAfterInsuranceSelectedLangCreated(insuranceselectedlang);

            return insuranceselectedlang;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang> CancelInsuranceSelectedLangChanges(ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnInsuranceSelectedLangUpdated(ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang item);
        partial void OnAfterInsuranceSelectedLangUpdated(ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang item);

        public async Task<ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang> UpdateInsuranceSelectedLang(int id, ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang insuranceselectedlang)
        {
            OnInsuranceSelectedLangUpdated(insuranceselectedlang);

            var itemToUpdate = Context.InsuranceSelectedLangs
                              .Where(i => i.Id == insuranceselectedlang.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(insuranceselectedlang).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterInsuranceSelectedLangUpdated(insuranceselectedlang);

            return insuranceselectedlang;
        }

        partial void OnInsuranceSelectedLangDeleted(ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang item);
        partial void OnAfterInsuranceSelectedLangDeleted(ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang item);

        public async Task<ZarenTravelBO.Models.zaren_prod.InsuranceSelectedLang> DeleteInsuranceSelectedLang(int id)
        {
            var itemToDelete = Context.InsuranceSelectedLangs
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnInsuranceSelectedLangDeleted(itemToDelete);

            Reset();

            Context.InsuranceSelectedLangs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterInsuranceSelectedLangDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportInvoiceTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/invoicetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/invoicetypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInvoiceTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/invoicetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/invoicetypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInvoiceTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.InvoiceType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.InvoiceType>> GetInvoiceTypes(Query query = null)
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

        partial void OnInvoiceTypeGet(ZarenTravelBO.Models.zaren_prod.InvoiceType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.InvoiceType> GetInvoiceTypeById(int id)
        {
            var items = Context.InvoiceTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnInvoiceTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnInvoiceTypeCreated(ZarenTravelBO.Models.zaren_prod.InvoiceType item);
        partial void OnAfterInvoiceTypeCreated(ZarenTravelBO.Models.zaren_prod.InvoiceType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.InvoiceType> CreateInvoiceType(ZarenTravelBO.Models.zaren_prod.InvoiceType invoicetype)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.InvoiceType> CancelInvoiceTypeChanges(ZarenTravelBO.Models.zaren_prod.InvoiceType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnInvoiceTypeUpdated(ZarenTravelBO.Models.zaren_prod.InvoiceType item);
        partial void OnAfterInvoiceTypeUpdated(ZarenTravelBO.Models.zaren_prod.InvoiceType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.InvoiceType> UpdateInvoiceType(int id, ZarenTravelBO.Models.zaren_prod.InvoiceType invoicetype)
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

        partial void OnInvoiceTypeDeleted(ZarenTravelBO.Models.zaren_prod.InvoiceType item);
        partial void OnAfterInvoiceTypeDeleted(ZarenTravelBO.Models.zaren_prod.InvoiceType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.InvoiceType> DeleteInvoiceType(int id)
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
    
        public async Task ExportLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/languages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/languages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/languages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/languages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLanguagesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Language> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Language>> GetLanguages(Query query = null)
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

        partial void OnLanguageGet(ZarenTravelBO.Models.zaren_prod.Language item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Language> GetLanguageById(int id)
        {
            var items = Context.Languages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Agency);
  
            var itemToReturn = items.FirstOrDefault();

            OnLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnLanguageCreated(ZarenTravelBO.Models.zaren_prod.Language item);
        partial void OnAfterLanguageCreated(ZarenTravelBO.Models.zaren_prod.Language item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Language> CreateLanguage(ZarenTravelBO.Models.zaren_prod.Language language)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.Language> CancelLanguageChanges(ZarenTravelBO.Models.zaren_prod.Language item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLanguageUpdated(ZarenTravelBO.Models.zaren_prod.Language item);
        partial void OnAfterLanguageUpdated(ZarenTravelBO.Models.zaren_prod.Language item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Language> UpdateLanguage(int id, ZarenTravelBO.Models.zaren_prod.Language language)
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

        partial void OnLanguageDeleted(ZarenTravelBO.Models.zaren_prod.Language item);
        partial void OnAfterLanguageDeleted(ZarenTravelBO.Models.zaren_prod.Language item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Language> DeleteLanguage(int id)
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
    
        public async Task ExportLanguage1SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/language1s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/language1s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLanguage1SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/language1s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/language1s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLanguage1SRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Language1> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Language1>> GetLanguage1S(Query query = null)
        {
            var items = Context.Language1S.AsQueryable();


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

            OnLanguage1SRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLanguage1Get(ZarenTravelBO.Models.zaren_prod.Language1 item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Language1> GetLanguage1ById(int id)
        {
            var items = Context.Language1S
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnLanguage1Get(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnLanguage1Created(ZarenTravelBO.Models.zaren_prod.Language1 item);
        partial void OnAfterLanguage1Created(ZarenTravelBO.Models.zaren_prod.Language1 item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Language1> CreateLanguage1(ZarenTravelBO.Models.zaren_prod.Language1 language1)
        {
            OnLanguage1Created(language1);

            var existingItem = Context.Language1S
                              .Where(i => i.Id == language1.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Language1S.Add(language1);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(language1).State = EntityState.Detached;
                throw;
            }

            OnAfterLanguage1Created(language1);

            return language1;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.Language1> CancelLanguage1Changes(ZarenTravelBO.Models.zaren_prod.Language1 item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLanguage1Updated(ZarenTravelBO.Models.zaren_prod.Language1 item);
        partial void OnAfterLanguage1Updated(ZarenTravelBO.Models.zaren_prod.Language1 item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Language1> UpdateLanguage1(int id, ZarenTravelBO.Models.zaren_prod.Language1 language1)
        {
            OnLanguage1Updated(language1);

            var itemToUpdate = Context.Language1S
                              .Where(i => i.Id == language1.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(language1).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterLanguage1Updated(language1);

            return language1;
        }

        partial void OnLanguage1Deleted(ZarenTravelBO.Models.zaren_prod.Language1 item);
        partial void OnAfterLanguage1Deleted(ZarenTravelBO.Models.zaren_prod.Language1 item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Language1> DeleteLanguage1(int id)
        {
            var itemToDelete = Context.Language1S
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLanguage1Deleted(itemToDelete);

            Reset();

            Context.Language1S.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterLanguage1Deleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportLimitTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/limittypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/limittypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLimitTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/limittypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/limittypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLimitTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.LimitType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.LimitType>> GetLimitTypes(Query query = null)
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

        partial void OnLimitTypeGet(ZarenTravelBO.Models.zaren_prod.LimitType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.LimitType> GetLimitTypeById(int id)
        {
            var items = Context.LimitTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnLimitTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnLimitTypeCreated(ZarenTravelBO.Models.zaren_prod.LimitType item);
        partial void OnAfterLimitTypeCreated(ZarenTravelBO.Models.zaren_prod.LimitType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.LimitType> CreateLimitType(ZarenTravelBO.Models.zaren_prod.LimitType limittype)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.LimitType> CancelLimitTypeChanges(ZarenTravelBO.Models.zaren_prod.LimitType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLimitTypeUpdated(ZarenTravelBO.Models.zaren_prod.LimitType item);
        partial void OnAfterLimitTypeUpdated(ZarenTravelBO.Models.zaren_prod.LimitType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.LimitType> UpdateLimitType(int id, ZarenTravelBO.Models.zaren_prod.LimitType limittype)
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

        partial void OnLimitTypeDeleted(ZarenTravelBO.Models.zaren_prod.LimitType item);
        partial void OnAfterLimitTypeDeleted(ZarenTravelBO.Models.zaren_prod.LimitType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.LimitType> DeleteLimitType(int id)
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
    
        public async Task ExportPassengersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/passengers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/passengers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPassengersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/passengers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/passengers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPassengersRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Passenger> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Passenger>> GetPassengers(Query query = null)
        {
            var items = Context.Passengers.AsQueryable();


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

            OnPassengersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPassengerGet(ZarenTravelBO.Models.zaren_prod.Passenger item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Passenger> GetPassengerById(int id)
        {
            var items = Context.Passengers
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPassengerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPassengerCreated(ZarenTravelBO.Models.zaren_prod.Passenger item);
        partial void OnAfterPassengerCreated(ZarenTravelBO.Models.zaren_prod.Passenger item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Passenger> CreatePassenger(ZarenTravelBO.Models.zaren_prod.Passenger passenger)
        {
            OnPassengerCreated(passenger);

            var existingItem = Context.Passengers
                              .Where(i => i.Id == passenger.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Passengers.Add(passenger);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(passenger).State = EntityState.Detached;
                throw;
            }

            OnAfterPassengerCreated(passenger);

            return passenger;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.Passenger> CancelPassengerChanges(ZarenTravelBO.Models.zaren_prod.Passenger item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPassengerUpdated(ZarenTravelBO.Models.zaren_prod.Passenger item);
        partial void OnAfterPassengerUpdated(ZarenTravelBO.Models.zaren_prod.Passenger item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Passenger> UpdatePassenger(int id, ZarenTravelBO.Models.zaren_prod.Passenger passenger)
        {
            OnPassengerUpdated(passenger);

            var itemToUpdate = Context.Passengers
                              .Where(i => i.Id == passenger.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(passenger).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPassengerUpdated(passenger);

            return passenger;
        }

        partial void OnPassengerDeleted(ZarenTravelBO.Models.zaren_prod.Passenger item);
        partial void OnAfterPassengerDeleted(ZarenTravelBO.Models.zaren_prod.Passenger item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Passenger> DeletePassenger(int id)
        {
            var itemToDelete = Context.Passengers
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPassengerDeleted(itemToDelete);

            Reset();

            Context.Passengers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPassengerDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPassengerTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/passengertypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/passengertypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPassengerTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/passengertypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/passengertypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPassengerTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.PassengerType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.PassengerType>> GetPassengerTypes(Query query = null)
        {
            var items = Context.PassengerTypes.AsQueryable();


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

            OnPassengerTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPassengerTypeGet(ZarenTravelBO.Models.zaren_prod.PassengerType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.PassengerType> GetPassengerTypeById(int id)
        {
            var items = Context.PassengerTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPassengerTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPassengerTypeCreated(ZarenTravelBO.Models.zaren_prod.PassengerType item);
        partial void OnAfterPassengerTypeCreated(ZarenTravelBO.Models.zaren_prod.PassengerType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.PassengerType> CreatePassengerType(ZarenTravelBO.Models.zaren_prod.PassengerType passengertype)
        {
            OnPassengerTypeCreated(passengertype);

            var existingItem = Context.PassengerTypes
                              .Where(i => i.Id == passengertype.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PassengerTypes.Add(passengertype);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(passengertype).State = EntityState.Detached;
                throw;
            }

            OnAfterPassengerTypeCreated(passengertype);

            return passengertype;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.PassengerType> CancelPassengerTypeChanges(ZarenTravelBO.Models.zaren_prod.PassengerType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPassengerTypeUpdated(ZarenTravelBO.Models.zaren_prod.PassengerType item);
        partial void OnAfterPassengerTypeUpdated(ZarenTravelBO.Models.zaren_prod.PassengerType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.PassengerType> UpdatePassengerType(int id, ZarenTravelBO.Models.zaren_prod.PassengerType passengertype)
        {
            OnPassengerTypeUpdated(passengertype);

            var itemToUpdate = Context.PassengerTypes
                              .Where(i => i.Id == passengertype.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(passengertype).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPassengerTypeUpdated(passengertype);

            return passengertype;
        }

        partial void OnPassengerTypeDeleted(ZarenTravelBO.Models.zaren_prod.PassengerType item);
        partial void OnAfterPassengerTypeDeleted(ZarenTravelBO.Models.zaren_prod.PassengerType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.PassengerType> DeletePassengerType(int id)
        {
            var itemToDelete = Context.PassengerTypes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPassengerTypeDeleted(itemToDelete);

            Reset();

            Context.PassengerTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPassengerTypeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPaymentTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/paymenttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/paymenttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPaymentTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/paymenttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/paymenttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPaymentTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.PaymentType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.PaymentType>> GetPaymentTypes(Query query = null)
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

        partial void OnPaymentTypeGet(ZarenTravelBO.Models.zaren_prod.PaymentType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.PaymentType> GetPaymentTypeById(int id)
        {
            var items = Context.PaymentTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPaymentTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPaymentTypeCreated(ZarenTravelBO.Models.zaren_prod.PaymentType item);
        partial void OnAfterPaymentTypeCreated(ZarenTravelBO.Models.zaren_prod.PaymentType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.PaymentType> CreatePaymentType(ZarenTravelBO.Models.zaren_prod.PaymentType paymenttype)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.PaymentType> CancelPaymentTypeChanges(ZarenTravelBO.Models.zaren_prod.PaymentType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPaymentTypeUpdated(ZarenTravelBO.Models.zaren_prod.PaymentType item);
        partial void OnAfterPaymentTypeUpdated(ZarenTravelBO.Models.zaren_prod.PaymentType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.PaymentType> UpdatePaymentType(int id, ZarenTravelBO.Models.zaren_prod.PaymentType paymenttype)
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

        partial void OnPaymentTypeDeleted(ZarenTravelBO.Models.zaren_prod.PaymentType item);
        partial void OnAfterPaymentTypeDeleted(ZarenTravelBO.Models.zaren_prod.PaymentType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.PaymentType> DeletePaymentType(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/possiblequeries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/possiblequeries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPossibleQueriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/possiblequeries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/possiblequeries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPossibleQueriesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.PossibleQuery> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.PossibleQuery>> GetPossibleQueries(Query query = null)
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

        partial void OnPossibleQueryGet(ZarenTravelBO.Models.zaren_prod.PossibleQuery item);

        public async Task<ZarenTravelBO.Models.zaren_prod.PossibleQuery> GetPossibleQueryById(int id)
        {
            var items = Context.PossibleQueries
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPossibleQueryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPossibleQueryCreated(ZarenTravelBO.Models.zaren_prod.PossibleQuery item);
        partial void OnAfterPossibleQueryCreated(ZarenTravelBO.Models.zaren_prod.PossibleQuery item);

        public async Task<ZarenTravelBO.Models.zaren_prod.PossibleQuery> CreatePossibleQuery(ZarenTravelBO.Models.zaren_prod.PossibleQuery possiblequery)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.PossibleQuery> CancelPossibleQueryChanges(ZarenTravelBO.Models.zaren_prod.PossibleQuery item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPossibleQueryUpdated(ZarenTravelBO.Models.zaren_prod.PossibleQuery item);
        partial void OnAfterPossibleQueryUpdated(ZarenTravelBO.Models.zaren_prod.PossibleQuery item);

        public async Task<ZarenTravelBO.Models.zaren_prod.PossibleQuery> UpdatePossibleQuery(int id, ZarenTravelBO.Models.zaren_prod.PossibleQuery possiblequery)
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

        partial void OnPossibleQueryDeleted(ZarenTravelBO.Models.zaren_prod.PossibleQuery item);
        partial void OnAfterPossibleQueryDeleted(ZarenTravelBO.Models.zaren_prod.PossibleQuery item);

        public async Task<ZarenTravelBO.Models.zaren_prod.PossibleQuery> DeletePossibleQuery(int id)
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
    
        public async Task ExportPriceBreakDownsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/pricebreakdowns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/pricebreakdowns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPriceBreakDownsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/pricebreakdowns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/pricebreakdowns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPriceBreakDownsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.PriceBreakDown> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.PriceBreakDown>> GetPriceBreakDowns(Query query = null)
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

        partial void OnPriceBreakDownGet(ZarenTravelBO.Models.zaren_prod.PriceBreakDown item);

        public async Task<ZarenTravelBO.Models.zaren_prod.PriceBreakDown> GetPriceBreakDownById(int id)
        {
            var items = Context.PriceBreakDowns
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPriceBreakDownGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPriceBreakDownCreated(ZarenTravelBO.Models.zaren_prod.PriceBreakDown item);
        partial void OnAfterPriceBreakDownCreated(ZarenTravelBO.Models.zaren_prod.PriceBreakDown item);

        public async Task<ZarenTravelBO.Models.zaren_prod.PriceBreakDown> CreatePriceBreakDown(ZarenTravelBO.Models.zaren_prod.PriceBreakDown pricebreakdown)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.PriceBreakDown> CancelPriceBreakDownChanges(ZarenTravelBO.Models.zaren_prod.PriceBreakDown item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPriceBreakDownUpdated(ZarenTravelBO.Models.zaren_prod.PriceBreakDown item);
        partial void OnAfterPriceBreakDownUpdated(ZarenTravelBO.Models.zaren_prod.PriceBreakDown item);

        public async Task<ZarenTravelBO.Models.zaren_prod.PriceBreakDown> UpdatePriceBreakDown(int id, ZarenTravelBO.Models.zaren_prod.PriceBreakDown pricebreakdown)
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

        partial void OnPriceBreakDownDeleted(ZarenTravelBO.Models.zaren_prod.PriceBreakDown item);
        partial void OnAfterPriceBreakDownDeleted(ZarenTravelBO.Models.zaren_prod.PriceBreakDown item);

        public async Task<ZarenTravelBO.Models.zaren_prod.PriceBreakDown> DeletePriceBreakDown(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/prices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/prices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPricesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/prices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/prices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPricesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Price> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Price>> GetPrices(Query query = null)
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

        partial void OnPriceGet(ZarenTravelBO.Models.zaren_prod.Price item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Price> GetPriceById(int id)
        {
            var items = Context.Prices
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnPriceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPriceCreated(ZarenTravelBO.Models.zaren_prod.Price item);
        partial void OnAfterPriceCreated(ZarenTravelBO.Models.zaren_prod.Price item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Price> CreatePrice(ZarenTravelBO.Models.zaren_prod.Price price)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.Price> CancelPriceChanges(ZarenTravelBO.Models.zaren_prod.Price item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPriceUpdated(ZarenTravelBO.Models.zaren_prod.Price item);
        partial void OnAfterPriceUpdated(ZarenTravelBO.Models.zaren_prod.Price item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Price> UpdatePrice(int id, ZarenTravelBO.Models.zaren_prod.Price price)
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

        partial void OnPriceDeleted(ZarenTravelBO.Models.zaren_prod.Price item);
        partial void OnAfterPriceDeleted(ZarenTravelBO.Models.zaren_prod.Price item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Price> DeletePrice(int id)
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
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/producttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/producttypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProductTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/producttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/producttypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProductTypesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.ProductType> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.ProductType>> GetProductTypes(Query query = null)
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

        partial void OnProductTypeGet(ZarenTravelBO.Models.zaren_prod.ProductType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.ProductType> GetProductTypeById(int id)
        {
            var items = Context.ProductTypes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProductTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProductTypeCreated(ZarenTravelBO.Models.zaren_prod.ProductType item);
        partial void OnAfterProductTypeCreated(ZarenTravelBO.Models.zaren_prod.ProductType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.ProductType> CreateProductType(ZarenTravelBO.Models.zaren_prod.ProductType producttype)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.ProductType> CancelProductTypeChanges(ZarenTravelBO.Models.zaren_prod.ProductType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProductTypeUpdated(ZarenTravelBO.Models.zaren_prod.ProductType item);
        partial void OnAfterProductTypeUpdated(ZarenTravelBO.Models.zaren_prod.ProductType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.ProductType> UpdateProductType(int id, ZarenTravelBO.Models.zaren_prod.ProductType producttype)
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

        partial void OnProductTypeDeleted(ZarenTravelBO.Models.zaren_prod.ProductType item);
        partial void OnAfterProductTypeDeleted(ZarenTravelBO.Models.zaren_prod.ProductType item);

        public async Task<ZarenTravelBO.Models.zaren_prod.ProductType> DeleteProductType(int id)
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
    
        public async Task ExportSeatInfosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/seatinfos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/seatinfos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSeatInfosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/seatinfos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/seatinfos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSeatInfosRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.SeatInfo> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.SeatInfo>> GetSeatInfos(Query query = null)
        {
            var items = Context.SeatInfos.AsQueryable();


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

            OnSeatInfosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSeatInfoGet(ZarenTravelBO.Models.zaren_prod.SeatInfo item);

        public async Task<ZarenTravelBO.Models.zaren_prod.SeatInfo> GetSeatInfoById(int id)
        {
            var items = Context.SeatInfos
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnSeatInfoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSeatInfoCreated(ZarenTravelBO.Models.zaren_prod.SeatInfo item);
        partial void OnAfterSeatInfoCreated(ZarenTravelBO.Models.zaren_prod.SeatInfo item);

        public async Task<ZarenTravelBO.Models.zaren_prod.SeatInfo> CreateSeatInfo(ZarenTravelBO.Models.zaren_prod.SeatInfo seatinfo)
        {
            OnSeatInfoCreated(seatinfo);

            var existingItem = Context.SeatInfos
                              .Where(i => i.Id == seatinfo.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SeatInfos.Add(seatinfo);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(seatinfo).State = EntityState.Detached;
                throw;
            }

            OnAfterSeatInfoCreated(seatinfo);

            return seatinfo;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.SeatInfo> CancelSeatInfoChanges(ZarenTravelBO.Models.zaren_prod.SeatInfo item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSeatInfoUpdated(ZarenTravelBO.Models.zaren_prod.SeatInfo item);
        partial void OnAfterSeatInfoUpdated(ZarenTravelBO.Models.zaren_prod.SeatInfo item);

        public async Task<ZarenTravelBO.Models.zaren_prod.SeatInfo> UpdateSeatInfo(int id, ZarenTravelBO.Models.zaren_prod.SeatInfo seatinfo)
        {
            OnSeatInfoUpdated(seatinfo);

            var itemToUpdate = Context.SeatInfos
                              .Where(i => i.Id == seatinfo.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(seatinfo).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSeatInfoUpdated(seatinfo);

            return seatinfo;
        }

        partial void OnSeatInfoDeleted(ZarenTravelBO.Models.zaren_prod.SeatInfo item);
        partial void OnAfterSeatInfoDeleted(ZarenTravelBO.Models.zaren_prod.SeatInfo item);

        public async Task<ZarenTravelBO.Models.zaren_prod.SeatInfo> DeleteSeatInfo(int id)
        {
            var itemToDelete = Context.SeatInfos
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSeatInfoDeleted(itemToDelete);

            Reset();

            Context.SeatInfos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSeatInfoDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSegmentsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/segments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/segments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSegmentsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/segments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/segments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSegmentsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Segment> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Segment>> GetSegments(Query query = null)
        {
            var items = Context.Segments.AsQueryable();


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

            OnSegmentsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSegmentGet(ZarenTravelBO.Models.zaren_prod.Segment item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Segment> GetSegmentById(int id)
        {
            var items = Context.Segments
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnSegmentGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSegmentCreated(ZarenTravelBO.Models.zaren_prod.Segment item);
        partial void OnAfterSegmentCreated(ZarenTravelBO.Models.zaren_prod.Segment item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Segment> CreateSegment(ZarenTravelBO.Models.zaren_prod.Segment segment)
        {
            OnSegmentCreated(segment);

            var existingItem = Context.Segments
                              .Where(i => i.Id == segment.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Segments.Add(segment);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(segment).State = EntityState.Detached;
                throw;
            }

            OnAfterSegmentCreated(segment);

            return segment;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.Segment> CancelSegmentChanges(ZarenTravelBO.Models.zaren_prod.Segment item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSegmentUpdated(ZarenTravelBO.Models.zaren_prod.Segment item);
        partial void OnAfterSegmentUpdated(ZarenTravelBO.Models.zaren_prod.Segment item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Segment> UpdateSegment(int id, ZarenTravelBO.Models.zaren_prod.Segment segment)
        {
            OnSegmentUpdated(segment);

            var itemToUpdate = Context.Segments
                              .Where(i => i.Id == segment.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(segment).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSegmentUpdated(segment);

            return segment;
        }

        partial void OnSegmentDeleted(ZarenTravelBO.Models.zaren_prod.Segment item);
        partial void OnAfterSegmentDeleted(ZarenTravelBO.Models.zaren_prod.Segment item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Segment> DeleteSegment(int id)
        {
            var itemToDelete = Context.Segments
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSegmentDeleted(itemToDelete);

            Reset();

            Context.Segments.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSegmentDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportServiceFeesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/servicefees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/servicefees/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportServiceFeesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/servicefees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/servicefees/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnServiceFeesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.ServiceFee> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.ServiceFee>> GetServiceFees(Query query = null)
        {
            var items = Context.ServiceFees.AsQueryable();


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

            OnServiceFeesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnServiceFeeGet(ZarenTravelBO.Models.zaren_prod.ServiceFee item);

        public async Task<ZarenTravelBO.Models.zaren_prod.ServiceFee> GetServiceFeeById(int id)
        {
            var items = Context.ServiceFees
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnServiceFeeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnServiceFeeCreated(ZarenTravelBO.Models.zaren_prod.ServiceFee item);
        partial void OnAfterServiceFeeCreated(ZarenTravelBO.Models.zaren_prod.ServiceFee item);

        public async Task<ZarenTravelBO.Models.zaren_prod.ServiceFee> CreateServiceFee(ZarenTravelBO.Models.zaren_prod.ServiceFee servicefee)
        {
            OnServiceFeeCreated(servicefee);

            var existingItem = Context.ServiceFees
                              .Where(i => i.Id == servicefee.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ServiceFees.Add(servicefee);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(servicefee).State = EntityState.Detached;
                throw;
            }

            OnAfterServiceFeeCreated(servicefee);

            return servicefee;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.ServiceFee> CancelServiceFeeChanges(ZarenTravelBO.Models.zaren_prod.ServiceFee item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnServiceFeeUpdated(ZarenTravelBO.Models.zaren_prod.ServiceFee item);
        partial void OnAfterServiceFeeUpdated(ZarenTravelBO.Models.zaren_prod.ServiceFee item);

        public async Task<ZarenTravelBO.Models.zaren_prod.ServiceFee> UpdateServiceFee(int id, ZarenTravelBO.Models.zaren_prod.ServiceFee servicefee)
        {
            OnServiceFeeUpdated(servicefee);

            var itemToUpdate = Context.ServiceFees
                              .Where(i => i.Id == servicefee.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(servicefee).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterServiceFeeUpdated(servicefee);

            return servicefee;
        }

        partial void OnServiceFeeDeleted(ZarenTravelBO.Models.zaren_prod.ServiceFee item);
        partial void OnAfterServiceFeeDeleted(ZarenTravelBO.Models.zaren_prod.ServiceFee item);

        public async Task<ZarenTravelBO.Models.zaren_prod.ServiceFee> DeleteServiceFee(int id)
        {
            var itemToDelete = Context.ServiceFees
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnServiceFeeDeleted(itemToDelete);

            Reset();

            Context.ServiceFees.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterServiceFeeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportServicesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/services/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/services/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportServicesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/services/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/services/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnServicesRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Service> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Service>> GetServices(Query query = null)
        {
            var items = Context.Services.AsQueryable();


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

            OnServicesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnServiceGet(ZarenTravelBO.Models.zaren_prod.Service item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Service> GetServiceById(int id)
        {
            var items = Context.Services
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnServiceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnServiceCreated(ZarenTravelBO.Models.zaren_prod.Service item);
        partial void OnAfterServiceCreated(ZarenTravelBO.Models.zaren_prod.Service item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Service> CreateService(ZarenTravelBO.Models.zaren_prod.Service service)
        {
            OnServiceCreated(service);

            var existingItem = Context.Services
                              .Where(i => i.Id == service.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Services.Add(service);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(service).State = EntityState.Detached;
                throw;
            }

            OnAfterServiceCreated(service);

            return service;
        }

        public async Task<ZarenTravelBO.Models.zaren_prod.Service> CancelServiceChanges(ZarenTravelBO.Models.zaren_prod.Service item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnServiceUpdated(ZarenTravelBO.Models.zaren_prod.Service item);
        partial void OnAfterServiceUpdated(ZarenTravelBO.Models.zaren_prod.Service item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Service> UpdateService(int id, ZarenTravelBO.Models.zaren_prod.Service service)
        {
            OnServiceUpdated(service);

            var itemToUpdate = Context.Services
                              .Where(i => i.Id == service.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            Reset();

            Context.Attach(service).State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterServiceUpdated(service);

            return service;
        }

        partial void OnServiceDeleted(ZarenTravelBO.Models.zaren_prod.Service item);
        partial void OnAfterServiceDeleted(ZarenTravelBO.Models.zaren_prod.Service item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Service> DeleteService(int id)
        {
            var itemToDelete = Context.Services
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnServiceDeleted(itemToDelete);

            Reset();

            Context.Services.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterServiceDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportStatusToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/status/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/status/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportStatusToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/status/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/status/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnStatusRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.Statu> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.Statu>> GetStatus(Query query = null)
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

        partial void OnStatuGet(ZarenTravelBO.Models.zaren_prod.Statu item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Statu> GetStatuById(int id)
        {
            var items = Context.Status
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnStatuGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnStatuCreated(ZarenTravelBO.Models.zaren_prod.Statu item);
        partial void OnAfterStatuCreated(ZarenTravelBO.Models.zaren_prod.Statu item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Statu> CreateStatu(ZarenTravelBO.Models.zaren_prod.Statu statu)
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

        public async Task<ZarenTravelBO.Models.zaren_prod.Statu> CancelStatuChanges(ZarenTravelBO.Models.zaren_prod.Statu item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnStatuUpdated(ZarenTravelBO.Models.zaren_prod.Statu item);
        partial void OnAfterStatuUpdated(ZarenTravelBO.Models.zaren_prod.Statu item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Statu> UpdateStatu(int id, ZarenTravelBO.Models.zaren_prod.Statu statu)
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

        partial void OnStatuDeleted(ZarenTravelBO.Models.zaren_prod.Statu item);
        partial void OnAfterStatuDeleted(ZarenTravelBO.Models.zaren_prod.Statu item);

        public async Task<ZarenTravelBO.Models.zaren_prod.Statu> DeleteStatu(int id)
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
    
        public async Task ExportAgencyContractsConfigurationByHotelsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractsconfigurationbyhotels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractsconfigurationbyhotels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAgencyContractsConfigurationByHotelsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/zaren_prod/agencycontractsconfigurationbyhotels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/zaren_prod/agencycontractsconfigurationbyhotels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAgencyContractsConfigurationByHotelsRead(ref IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsConfigurationByHotel> items);

        public async Task<IQueryable<ZarenTravelBO.Models.zaren_prod.AgencyContractsConfigurationByHotel>> GetAgencyContractsConfigurationByHotels(Query query = null)
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