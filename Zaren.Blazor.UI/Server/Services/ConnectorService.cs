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

using ZarenUI.Server.Data;

namespace ZarenUI.Server
{
    public partial class ConnectorService
    {
        ConnectorContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly ConnectorContext context;
        private readonly NavigationManager navigationManager;

        public ConnectorService(ConnectorContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);


        public async Task ExportColorGroupsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/colorgroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/colorgroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportColorGroupsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/colorgroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/colorgroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnColorGroupsRead(ref IQueryable<ZarenUI.Server.Models.Connector.ColorGroup> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.ColorGroup>> GetColorGroups(Query query = null)
        {
            var items = Context.ColorGroups.AsQueryable();

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

            OnColorGroupsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnColorGroupGet(ZarenUI.Server.Models.Connector.ColorGroup item);

        public async Task<ZarenUI.Server.Models.Connector.ColorGroup> GetColorGroupById(int id)
        {
            var items = Context.ColorGroups
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnColorGroupGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnColorGroupCreated(ZarenUI.Server.Models.Connector.ColorGroup item);
        partial void OnAfterColorGroupCreated(ZarenUI.Server.Models.Connector.ColorGroup item);

        public async Task<ZarenUI.Server.Models.Connector.ColorGroup> CreateColorGroup(ZarenUI.Server.Models.Connector.ColorGroup colorgroup)
        {
            OnColorGroupCreated(colorgroup);

            var existingItem = Context.ColorGroups
                              .Where(i => i.Id == colorgroup.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ColorGroups.Add(colorgroup);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(colorgroup).State = EntityState.Detached;
                throw;
            }

            OnAfterColorGroupCreated(colorgroup);

            return colorgroup;
        }

        public async Task<ZarenUI.Server.Models.Connector.ColorGroup> CancelColorGroupChanges(ZarenUI.Server.Models.Connector.ColorGroup item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnColorGroupUpdated(ZarenUI.Server.Models.Connector.ColorGroup item);
        partial void OnAfterColorGroupUpdated(ZarenUI.Server.Models.Connector.ColorGroup item);

        public async Task<ZarenUI.Server.Models.Connector.ColorGroup> UpdateColorGroup(int id, ZarenUI.Server.Models.Connector.ColorGroup colorgroup)
        {
            OnColorGroupUpdated(colorgroup);

            var itemToUpdate = Context.ColorGroups
                              .Where(i => i.Id == colorgroup.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(colorgroup);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterColorGroupUpdated(colorgroup);

            return colorgroup;
        }

        partial void OnColorGroupDeleted(ZarenUI.Server.Models.Connector.ColorGroup item);
        partial void OnAfterColorGroupDeleted(ZarenUI.Server.Models.Connector.ColorGroup item);

        public async Task<ZarenUI.Server.Models.Connector.ColorGroup> DeleteColorGroup(int id)
        {
            var itemToDelete = Context.ColorGroups
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnColorGroupDeleted(itemToDelete);


            Context.ColorGroups.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterColorGroupDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportCountriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/countries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/countries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCountriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/countries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/countries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCountriesRead(ref IQueryable<ZarenUI.Server.Models.Connector.Country> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.Country>> GetCountries(Query query = null)
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

        partial void OnCountryGet(ZarenUI.Server.Models.Connector.Country item);

        public async Task<ZarenUI.Server.Models.Connector.Country> GetCountryById(int id)
        {
            var items = Context.Countries
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCountryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCountryCreated(ZarenUI.Server.Models.Connector.Country item);
        partial void OnAfterCountryCreated(ZarenUI.Server.Models.Connector.Country item);

        public async Task<ZarenUI.Server.Models.Connector.Country> CreateCountry(ZarenUI.Server.Models.Connector.Country country)
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

        public async Task<ZarenUI.Server.Models.Connector.Country> CancelCountryChanges(ZarenUI.Server.Models.Connector.Country item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCountryUpdated(ZarenUI.Server.Models.Connector.Country item);
        partial void OnAfterCountryUpdated(ZarenUI.Server.Models.Connector.Country item);

        public async Task<ZarenUI.Server.Models.Connector.Country> UpdateCountry(int id, ZarenUI.Server.Models.Connector.Country country)
        {
            OnCountryUpdated(country);

            var itemToUpdate = Context.Countries
                              .Where(i => i.Id == country.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(country);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCountryUpdated(country);

            return country;
        }

        partial void OnCountryDeleted(ZarenUI.Server.Models.Connector.Country item);
        partial void OnAfterCountryDeleted(ZarenUI.Server.Models.Connector.Country item);

        public async Task<ZarenUI.Server.Models.Connector.Country> DeleteCountry(int id)
        {
            var itemToDelete = Context.Countries
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCountryDeleted(itemToDelete);


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
    
        public async Task ExportCountryLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/countrylanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/countrylanguages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCountryLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/countrylanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/countrylanguages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCountryLanguagesRead(ref IQueryable<ZarenUI.Server.Models.Connector.CountryLanguage> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.CountryLanguage>> GetCountryLanguages(Query query = null)
        {
            var items = Context.CountryLanguages.AsQueryable();

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

            OnCountryLanguagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCountryLanguageGet(ZarenUI.Server.Models.Connector.CountryLanguage item);

        public async Task<ZarenUI.Server.Models.Connector.CountryLanguage> GetCountryLanguageById(int id)
        {
            var items = Context.CountryLanguages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCountryLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCountryLanguageCreated(ZarenUI.Server.Models.Connector.CountryLanguage item);
        partial void OnAfterCountryLanguageCreated(ZarenUI.Server.Models.Connector.CountryLanguage item);

        public async Task<ZarenUI.Server.Models.Connector.CountryLanguage> CreateCountryLanguage(ZarenUI.Server.Models.Connector.CountryLanguage countrylanguage)
        {
            OnCountryLanguageCreated(countrylanguage);

            var existingItem = Context.CountryLanguages
                              .Where(i => i.Id == countrylanguage.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CountryLanguages.Add(countrylanguage);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(countrylanguage).State = EntityState.Detached;
                throw;
            }

            OnAfterCountryLanguageCreated(countrylanguage);

            return countrylanguage;
        }

        public async Task<ZarenUI.Server.Models.Connector.CountryLanguage> CancelCountryLanguageChanges(ZarenUI.Server.Models.Connector.CountryLanguage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCountryLanguageUpdated(ZarenUI.Server.Models.Connector.CountryLanguage item);
        partial void OnAfterCountryLanguageUpdated(ZarenUI.Server.Models.Connector.CountryLanguage item);

        public async Task<ZarenUI.Server.Models.Connector.CountryLanguage> UpdateCountryLanguage(int id, ZarenUI.Server.Models.Connector.CountryLanguage countrylanguage)
        {
            OnCountryLanguageUpdated(countrylanguage);

            var itemToUpdate = Context.CountryLanguages
                              .Where(i => i.Id == countrylanguage.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(countrylanguage);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCountryLanguageUpdated(countrylanguage);

            return countrylanguage;
        }

        partial void OnCountryLanguageDeleted(ZarenUI.Server.Models.Connector.CountryLanguage item);
        partial void OnAfterCountryLanguageDeleted(ZarenUI.Server.Models.Connector.CountryLanguage item);

        public async Task<ZarenUI.Server.Models.Connector.CountryLanguage> DeleteCountryLanguage(int id)
        {
            var itemToDelete = Context.CountryLanguages
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCountryLanguageDeleted(itemToDelete);


            Context.CountryLanguages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCountryLanguageDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDeviceGroupsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/devicegroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/devicegroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDeviceGroupsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/devicegroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/devicegroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDeviceGroupsRead(ref IQueryable<ZarenUI.Server.Models.Connector.DeviceGroup> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.DeviceGroup>> GetDeviceGroups(Query query = null)
        {
            var items = Context.DeviceGroups.AsQueryable();

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

            OnDeviceGroupsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDeviceGroupGet(ZarenUI.Server.Models.Connector.DeviceGroup item);

        public async Task<ZarenUI.Server.Models.Connector.DeviceGroup> GetDeviceGroupById(int id)
        {
            var items = Context.DeviceGroups
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnDeviceGroupGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDeviceGroupCreated(ZarenUI.Server.Models.Connector.DeviceGroup item);
        partial void OnAfterDeviceGroupCreated(ZarenUI.Server.Models.Connector.DeviceGroup item);

        public async Task<ZarenUI.Server.Models.Connector.DeviceGroup> CreateDeviceGroup(ZarenUI.Server.Models.Connector.DeviceGroup devicegroup)
        {
            OnDeviceGroupCreated(devicegroup);

            var existingItem = Context.DeviceGroups
                              .Where(i => i.Id == devicegroup.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.DeviceGroups.Add(devicegroup);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(devicegroup).State = EntityState.Detached;
                throw;
            }

            OnAfterDeviceGroupCreated(devicegroup);

            return devicegroup;
        }

        public async Task<ZarenUI.Server.Models.Connector.DeviceGroup> CancelDeviceGroupChanges(ZarenUI.Server.Models.Connector.DeviceGroup item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDeviceGroupUpdated(ZarenUI.Server.Models.Connector.DeviceGroup item);
        partial void OnAfterDeviceGroupUpdated(ZarenUI.Server.Models.Connector.DeviceGroup item);

        public async Task<ZarenUI.Server.Models.Connector.DeviceGroup> UpdateDeviceGroup(int id, ZarenUI.Server.Models.Connector.DeviceGroup devicegroup)
        {
            OnDeviceGroupUpdated(devicegroup);

            var itemToUpdate = Context.DeviceGroups
                              .Where(i => i.Id == devicegroup.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(devicegroup);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDeviceGroupUpdated(devicegroup);

            return devicegroup;
        }

        partial void OnDeviceGroupDeleted(ZarenUI.Server.Models.Connector.DeviceGroup item);
        partial void OnAfterDeviceGroupDeleted(ZarenUI.Server.Models.Connector.DeviceGroup item);

        public async Task<ZarenUI.Server.Models.Connector.DeviceGroup> DeleteDeviceGroup(int id)
        {
            var itemToDelete = Context.DeviceGroups
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDeviceGroupDeleted(itemToDelete);


            Context.DeviceGroups.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDeviceGroupDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDevicesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/devices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/devices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDevicesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/devices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/devices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDevicesRead(ref IQueryable<ZarenUI.Server.Models.Connector.Device> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.Device>> GetDevices(Query query = null)
        {
            var items = Context.Devices.AsQueryable();

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

            OnDevicesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDeviceGet(ZarenUI.Server.Models.Connector.Device item);

        public async Task<ZarenUI.Server.Models.Connector.Device> GetDeviceById(int id)
        {
            var items = Context.Devices
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnDeviceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDeviceCreated(ZarenUI.Server.Models.Connector.Device item);
        partial void OnAfterDeviceCreated(ZarenUI.Server.Models.Connector.Device item);

        public async Task<ZarenUI.Server.Models.Connector.Device> CreateDevice(ZarenUI.Server.Models.Connector.Device device)
        {
            OnDeviceCreated(device);

            var existingItem = Context.Devices
                              .Where(i => i.Id == device.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Devices.Add(device);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(device).State = EntityState.Detached;
                throw;
            }

            OnAfterDeviceCreated(device);

            return device;
        }

        public async Task<ZarenUI.Server.Models.Connector.Device> CancelDeviceChanges(ZarenUI.Server.Models.Connector.Device item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDeviceUpdated(ZarenUI.Server.Models.Connector.Device item);
        partial void OnAfterDeviceUpdated(ZarenUI.Server.Models.Connector.Device item);

        public async Task<ZarenUI.Server.Models.Connector.Device> UpdateDevice(int id, ZarenUI.Server.Models.Connector.Device device)
        {
            OnDeviceUpdated(device);

            var itemToUpdate = Context.Devices
                              .Where(i => i.Id == device.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(device);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDeviceUpdated(device);

            return device;
        }

        partial void OnDeviceDeleted(ZarenUI.Server.Models.Connector.Device item);
        partial void OnAfterDeviceDeleted(ZarenUI.Server.Models.Connector.Device item);

        public async Task<ZarenUI.Server.Models.Connector.Device> DeleteDevice(int id)
        {
            var itemToDelete = Context.Devices
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDeviceDeleted(itemToDelete);


            Context.Devices.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDeviceDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDistributedServerCachesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/distributedservercaches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/distributedservercaches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDistributedServerCachesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/distributedservercaches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/distributedservercaches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDistributedServerCachesRead(ref IQueryable<ZarenUI.Server.Models.Connector.DistributedServerCache> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.DistributedServerCache>> GetDistributedServerCaches(Query query = null)
        {
            var items = Context.DistributedServerCaches.AsQueryable();

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

            OnDistributedServerCachesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDistributedServerCacheGet(ZarenUI.Server.Models.Connector.DistributedServerCache item);

        public async Task<ZarenUI.Server.Models.Connector.DistributedServerCache> GetDistributedServerCacheById(string id)
        {
            var items = Context.DistributedServerCaches
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnDistributedServerCacheGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnDistributedServerCacheCreated(ZarenUI.Server.Models.Connector.DistributedServerCache item);
        partial void OnAfterDistributedServerCacheCreated(ZarenUI.Server.Models.Connector.DistributedServerCache item);

        public async Task<ZarenUI.Server.Models.Connector.DistributedServerCache> CreateDistributedServerCache(ZarenUI.Server.Models.Connector.DistributedServerCache distributedservercache)
        {
            OnDistributedServerCacheCreated(distributedservercache);

            var existingItem = Context.DistributedServerCaches
                              .Where(i => i.Id == distributedservercache.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.DistributedServerCaches.Add(distributedservercache);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(distributedservercache).State = EntityState.Detached;
                throw;
            }

            OnAfterDistributedServerCacheCreated(distributedservercache);

            return distributedservercache;
        }

        public async Task<ZarenUI.Server.Models.Connector.DistributedServerCache> CancelDistributedServerCacheChanges(ZarenUI.Server.Models.Connector.DistributedServerCache item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDistributedServerCacheUpdated(ZarenUI.Server.Models.Connector.DistributedServerCache item);
        partial void OnAfterDistributedServerCacheUpdated(ZarenUI.Server.Models.Connector.DistributedServerCache item);

        public async Task<ZarenUI.Server.Models.Connector.DistributedServerCache> UpdateDistributedServerCache(string id, ZarenUI.Server.Models.Connector.DistributedServerCache distributedservercache)
        {
            OnDistributedServerCacheUpdated(distributedservercache);

            var itemToUpdate = Context.DistributedServerCaches
                              .Where(i => i.Id == distributedservercache.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(distributedservercache);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterDistributedServerCacheUpdated(distributedservercache);

            return distributedservercache;
        }

        partial void OnDistributedServerCacheDeleted(ZarenUI.Server.Models.Connector.DistributedServerCache item);
        partial void OnAfterDistributedServerCacheDeleted(ZarenUI.Server.Models.Connector.DistributedServerCache item);

        public async Task<ZarenUI.Server.Models.Connector.DistributedServerCache> DeleteDistributedServerCache(string id)
        {
            var itemToDelete = Context.DistributedServerCaches
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDistributedServerCacheDeleted(itemToDelete);


            Context.DistributedServerCaches.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDistributedServerCacheDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportFieldsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/fields/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/fields/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFieldsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/fields/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/fields/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFieldsRead(ref IQueryable<ZarenUI.Server.Models.Connector.Field> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.Field>> GetFields(Query query = null)
        {
            var items = Context.Fields.AsQueryable();

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

            OnFieldsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFieldGet(ZarenUI.Server.Models.Connector.Field item);

        public async Task<ZarenUI.Server.Models.Connector.Field> GetFieldById(int id)
        {
            var items = Context.Fields
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnFieldGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnFieldCreated(ZarenUI.Server.Models.Connector.Field item);
        partial void OnAfterFieldCreated(ZarenUI.Server.Models.Connector.Field item);

        public async Task<ZarenUI.Server.Models.Connector.Field> CreateField(ZarenUI.Server.Models.Connector.Field field)
        {
            OnFieldCreated(field);

            var existingItem = Context.Fields
                              .Where(i => i.Id == field.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Fields.Add(field);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(field).State = EntityState.Detached;
                throw;
            }

            OnAfterFieldCreated(field);

            return field;
        }

        public async Task<ZarenUI.Server.Models.Connector.Field> CancelFieldChanges(ZarenUI.Server.Models.Connector.Field item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFieldUpdated(ZarenUI.Server.Models.Connector.Field item);
        partial void OnAfterFieldUpdated(ZarenUI.Server.Models.Connector.Field item);

        public async Task<ZarenUI.Server.Models.Connector.Field> UpdateField(int id, ZarenUI.Server.Models.Connector.Field field)
        {
            OnFieldUpdated(field);

            var itemToUpdate = Context.Fields
                              .Where(i => i.Id == field.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(field);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterFieldUpdated(field);

            return field;
        }

        partial void OnFieldDeleted(ZarenUI.Server.Models.Connector.Field item);
        partial void OnAfterFieldDeleted(ZarenUI.Server.Models.Connector.Field item);

        public async Task<ZarenUI.Server.Models.Connector.Field> DeleteField(int id)
        {
            var itemToDelete = Context.Fields
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFieldDeleted(itemToDelete);


            Context.Fields.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFieldDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProgrammingCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/programmingcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/programmingcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProgrammingCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/programmingcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/programmingcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProgrammingCategoriesRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProgrammingCategory> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.ProgrammingCategory>> GetProgrammingCategories(Query query = null)
        {
            var items = Context.ProgrammingCategories.AsQueryable();

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

            OnProgrammingCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProgrammingCategoryGet(ZarenUI.Server.Models.Connector.ProgrammingCategory item);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCategory> GetProgrammingCategoryById(int id)
        {
            var items = Context.ProgrammingCategories
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProgrammingCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProgrammingCategoryCreated(ZarenUI.Server.Models.Connector.ProgrammingCategory item);
        partial void OnAfterProgrammingCategoryCreated(ZarenUI.Server.Models.Connector.ProgrammingCategory item);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCategory> CreateProgrammingCategory(ZarenUI.Server.Models.Connector.ProgrammingCategory programmingcategory)
        {
            OnProgrammingCategoryCreated(programmingcategory);

            var existingItem = Context.ProgrammingCategories
                              .Where(i => i.Id == programmingcategory.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProgrammingCategories.Add(programmingcategory);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(programmingcategory).State = EntityState.Detached;
                throw;
            }

            OnAfterProgrammingCategoryCreated(programmingcategory);

            return programmingcategory;
        }

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCategory> CancelProgrammingCategoryChanges(ZarenUI.Server.Models.Connector.ProgrammingCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProgrammingCategoryUpdated(ZarenUI.Server.Models.Connector.ProgrammingCategory item);
        partial void OnAfterProgrammingCategoryUpdated(ZarenUI.Server.Models.Connector.ProgrammingCategory item);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCategory> UpdateProgrammingCategory(int id, ZarenUI.Server.Models.Connector.ProgrammingCategory programmingcategory)
        {
            OnProgrammingCategoryUpdated(programmingcategory);

            var itemToUpdate = Context.ProgrammingCategories
                              .Where(i => i.Id == programmingcategory.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(programmingcategory);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProgrammingCategoryUpdated(programmingcategory);

            return programmingcategory;
        }

        partial void OnProgrammingCategoryDeleted(ZarenUI.Server.Models.Connector.ProgrammingCategory item);
        partial void OnAfterProgrammingCategoryDeleted(ZarenUI.Server.Models.Connector.ProgrammingCategory item);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCategory> DeleteProgrammingCategory(int id)
        {
            var itemToDelete = Context.ProgrammingCategories
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProgrammingCategoryDeleted(itemToDelete);


            Context.ProgrammingCategories.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProgrammingCategoryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProgrammingCodesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/programmingcodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/programmingcodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProgrammingCodesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/programmingcodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/programmingcodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProgrammingCodesRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProgrammingCode> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.ProgrammingCode>> GetProgrammingCodes(Query query = null)
        {
            var items = Context.ProgrammingCodes.AsQueryable();

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

            OnProgrammingCodesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProgrammingCodeGet(ZarenUI.Server.Models.Connector.ProgrammingCode item);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCode> GetProgrammingCodeById(int id)
        {
            var items = Context.ProgrammingCodes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProgrammingCodeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProgrammingCodeCreated(ZarenUI.Server.Models.Connector.ProgrammingCode item);
        partial void OnAfterProgrammingCodeCreated(ZarenUI.Server.Models.Connector.ProgrammingCode item);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCode> CreateProgrammingCode(ZarenUI.Server.Models.Connector.ProgrammingCode programmingcode)
        {
            OnProgrammingCodeCreated(programmingcode);

            var existingItem = Context.ProgrammingCodes
                              .Where(i => i.Id == programmingcode.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProgrammingCodes.Add(programmingcode);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(programmingcode).State = EntityState.Detached;
                throw;
            }

            OnAfterProgrammingCodeCreated(programmingcode);

            return programmingcode;
        }

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCode> CancelProgrammingCodeChanges(ZarenUI.Server.Models.Connector.ProgrammingCode item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProgrammingCodeUpdated(ZarenUI.Server.Models.Connector.ProgrammingCode item);
        partial void OnAfterProgrammingCodeUpdated(ZarenUI.Server.Models.Connector.ProgrammingCode item);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCode> UpdateProgrammingCode(int id, ZarenUI.Server.Models.Connector.ProgrammingCode programmingcode)
        {
            OnProgrammingCodeUpdated(programmingcode);

            var itemToUpdate = Context.ProgrammingCodes
                              .Where(i => i.Id == programmingcode.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(programmingcode);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProgrammingCodeUpdated(programmingcode);

            return programmingcode;
        }

        partial void OnProgrammingCodeDeleted(ZarenUI.Server.Models.Connector.ProgrammingCode item);
        partial void OnAfterProgrammingCodeDeleted(ZarenUI.Server.Models.Connector.ProgrammingCode item);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCode> DeleteProgrammingCode(int id)
        {
            var itemToDelete = Context.ProgrammingCodes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProgrammingCodeDeleted(itemToDelete);


            Context.ProgrammingCodes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProgrammingCodeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProgrammingCodeTemplatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/programmingcodetemplates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/programmingcodetemplates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProgrammingCodeTemplatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/programmingcodetemplates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/programmingcodetemplates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProgrammingCodeTemplatesRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate>> GetProgrammingCodeTemplates(Query query = null)
        {
            var items = Context.ProgrammingCodeTemplates.AsQueryable();

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

            OnProgrammingCodeTemplatesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProgrammingCodeTemplateGet(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate item);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate> GetProgrammingCodeTemplateById(int id)
        {
            var items = Context.ProgrammingCodeTemplates
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProgrammingCodeTemplateGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProgrammingCodeTemplateCreated(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate item);
        partial void OnAfterProgrammingCodeTemplateCreated(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate item);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate> CreateProgrammingCodeTemplate(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate programmingcodetemplate)
        {
            OnProgrammingCodeTemplateCreated(programmingcodetemplate);

            var existingItem = Context.ProgrammingCodeTemplates
                              .Where(i => i.Id == programmingcodetemplate.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProgrammingCodeTemplates.Add(programmingcodetemplate);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(programmingcodetemplate).State = EntityState.Detached;
                throw;
            }

            OnAfterProgrammingCodeTemplateCreated(programmingcodetemplate);

            return programmingcodetemplate;
        }

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate> CancelProgrammingCodeTemplateChanges(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProgrammingCodeTemplateUpdated(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate item);
        partial void OnAfterProgrammingCodeTemplateUpdated(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate item);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate> UpdateProgrammingCodeTemplate(int id, ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate programmingcodetemplate)
        {
            OnProgrammingCodeTemplateUpdated(programmingcodetemplate);

            var itemToUpdate = Context.ProgrammingCodeTemplates
                              .Where(i => i.Id == programmingcodetemplate.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(programmingcodetemplate);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProgrammingCodeTemplateUpdated(programmingcodetemplate);

            return programmingcodetemplate;
        }

        partial void OnProgrammingCodeTemplateDeleted(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate item);
        partial void OnAfterProgrammingCodeTemplateDeleted(ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate item);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate> DeleteProgrammingCodeTemplate(int id)
        {
            var itemToDelete = Context.ProgrammingCodeTemplates
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProgrammingCodeTemplateDeleted(itemToDelete);


            Context.ProgrammingCodeTemplates.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProgrammingCodeTemplateDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProgrammingTechnologiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/programmingtechnologies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/programmingtechnologies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProgrammingTechnologiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/programmingtechnologies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/programmingtechnologies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProgrammingTechnologiesRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProgrammingTechnology> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.ProgrammingTechnology>> GetProgrammingTechnologies(Query query = null)
        {
            var items = Context.ProgrammingTechnologies.AsQueryable();

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

            OnProgrammingTechnologiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProgrammingTechnologyGet(ZarenUI.Server.Models.Connector.ProgrammingTechnology item);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingTechnology> GetProgrammingTechnologyById(int id)
        {
            var items = Context.ProgrammingTechnologies
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProgrammingTechnologyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProgrammingTechnologyCreated(ZarenUI.Server.Models.Connector.ProgrammingTechnology item);
        partial void OnAfterProgrammingTechnologyCreated(ZarenUI.Server.Models.Connector.ProgrammingTechnology item);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingTechnology> CreateProgrammingTechnology(ZarenUI.Server.Models.Connector.ProgrammingTechnology programmingtechnology)
        {
            OnProgrammingTechnologyCreated(programmingtechnology);

            var existingItem = Context.ProgrammingTechnologies
                              .Where(i => i.Id == programmingtechnology.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProgrammingTechnologies.Add(programmingtechnology);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(programmingtechnology).State = EntityState.Detached;
                throw;
            }

            OnAfterProgrammingTechnologyCreated(programmingtechnology);

            return programmingtechnology;
        }

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingTechnology> CancelProgrammingTechnologyChanges(ZarenUI.Server.Models.Connector.ProgrammingTechnology item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProgrammingTechnologyUpdated(ZarenUI.Server.Models.Connector.ProgrammingTechnology item);
        partial void OnAfterProgrammingTechnologyUpdated(ZarenUI.Server.Models.Connector.ProgrammingTechnology item);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingTechnology> UpdateProgrammingTechnology(int id, ZarenUI.Server.Models.Connector.ProgrammingTechnology programmingtechnology)
        {
            OnProgrammingTechnologyUpdated(programmingtechnology);

            var itemToUpdate = Context.ProgrammingTechnologies
                              .Where(i => i.Id == programmingtechnology.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(programmingtechnology);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProgrammingTechnologyUpdated(programmingtechnology);

            return programmingtechnology;
        }

        partial void OnProgrammingTechnologyDeleted(ZarenUI.Server.Models.Connector.ProgrammingTechnology item);
        partial void OnAfterProgrammingTechnologyDeleted(ZarenUI.Server.Models.Connector.ProgrammingTechnology item);

        public async Task<ZarenUI.Server.Models.Connector.ProgrammingTechnology> DeleteProgrammingTechnology(int id)
        {
            var itemToDelete = Context.ProgrammingTechnologies
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProgrammingTechnologyDeleted(itemToDelete);


            Context.ProgrammingTechnologies.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProgrammingTechnologyDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProjectCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProjectCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProjectCategoriesRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectCategory> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.ProjectCategory>> GetProjectCategories(Query query = null)
        {
            var items = Context.ProjectCategories.AsQueryable();

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

            OnProjectCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProjectCategoryGet(ZarenUI.Server.Models.Connector.ProjectCategory item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectCategory> GetProjectCategoryById(int id)
        {
            var items = Context.ProjectCategories
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProjectCategoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProjectCategoryCreated(ZarenUI.Server.Models.Connector.ProjectCategory item);
        partial void OnAfterProjectCategoryCreated(ZarenUI.Server.Models.Connector.ProjectCategory item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectCategory> CreateProjectCategory(ZarenUI.Server.Models.Connector.ProjectCategory projectcategory)
        {
            OnProjectCategoryCreated(projectcategory);

            var existingItem = Context.ProjectCategories
                              .Where(i => i.Id == projectcategory.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProjectCategories.Add(projectcategory);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(projectcategory).State = EntityState.Detached;
                throw;
            }

            OnAfterProjectCategoryCreated(projectcategory);

            return projectcategory;
        }

        public async Task<ZarenUI.Server.Models.Connector.ProjectCategory> CancelProjectCategoryChanges(ZarenUI.Server.Models.Connector.ProjectCategory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProjectCategoryUpdated(ZarenUI.Server.Models.Connector.ProjectCategory item);
        partial void OnAfterProjectCategoryUpdated(ZarenUI.Server.Models.Connector.ProjectCategory item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectCategory> UpdateProjectCategory(int id, ZarenUI.Server.Models.Connector.ProjectCategory projectcategory)
        {
            OnProjectCategoryUpdated(projectcategory);

            var itemToUpdate = Context.ProjectCategories
                              .Where(i => i.Id == projectcategory.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(projectcategory);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProjectCategoryUpdated(projectcategory);

            return projectcategory;
        }

        partial void OnProjectCategoryDeleted(ZarenUI.Server.Models.Connector.ProjectCategory item);
        partial void OnAfterProjectCategoryDeleted(ZarenUI.Server.Models.Connector.ProjectCategory item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectCategory> DeleteProjectCategory(int id)
        {
            var itemToDelete = Context.ProjectCategories
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProjectCategoryDeleted(itemToDelete);


            Context.ProjectCategories.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProjectCategoryDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProjectConfigurationKeyAndValuesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectconfigurationkeyandvalues/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectconfigurationkeyandvalues/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProjectConfigurationKeyAndValuesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectconfigurationkeyandvalues/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectconfigurationkeyandvalues/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProjectConfigurationKeyAndValuesRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue>> GetProjectConfigurationKeyAndValues(Query query = null)
        {
            var items = Context.ProjectConfigurationKeyAndValues.AsQueryable();

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

            OnProjectConfigurationKeyAndValuesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProjectConfigurationKeyAndValueGet(ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue> GetProjectConfigurationKeyAndValueById(int id)
        {
            var items = Context.ProjectConfigurationKeyAndValues
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProjectConfigurationKeyAndValueGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProjectConfigurationKeyAndValueCreated(ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue item);
        partial void OnAfterProjectConfigurationKeyAndValueCreated(ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue> CreateProjectConfigurationKeyAndValue(ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue projectconfigurationkeyandvalue)
        {
            OnProjectConfigurationKeyAndValueCreated(projectconfigurationkeyandvalue);

            var existingItem = Context.ProjectConfigurationKeyAndValues
                              .Where(i => i.Id == projectconfigurationkeyandvalue.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProjectConfigurationKeyAndValues.Add(projectconfigurationkeyandvalue);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(projectconfigurationkeyandvalue).State = EntityState.Detached;
                throw;
            }

            OnAfterProjectConfigurationKeyAndValueCreated(projectconfigurationkeyandvalue);

            return projectconfigurationkeyandvalue;
        }

        public async Task<ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue> CancelProjectConfigurationKeyAndValueChanges(ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProjectConfigurationKeyAndValueUpdated(ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue item);
        partial void OnAfterProjectConfigurationKeyAndValueUpdated(ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue> UpdateProjectConfigurationKeyAndValue(int id, ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue projectconfigurationkeyandvalue)
        {
            OnProjectConfigurationKeyAndValueUpdated(projectconfigurationkeyandvalue);

            var itemToUpdate = Context.ProjectConfigurationKeyAndValues
                              .Where(i => i.Id == projectconfigurationkeyandvalue.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(projectconfigurationkeyandvalue);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProjectConfigurationKeyAndValueUpdated(projectconfigurationkeyandvalue);

            return projectconfigurationkeyandvalue;
        }

        partial void OnProjectConfigurationKeyAndValueDeleted(ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue item);
        partial void OnAfterProjectConfigurationKeyAndValueDeleted(ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue> DeleteProjectConfigurationKeyAndValue(int id)
        {
            var itemToDelete = Context.ProjectConfigurationKeyAndValues
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProjectConfigurationKeyAndValueDeleted(itemToDelete);


            Context.ProjectConfigurationKeyAndValues.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProjectConfigurationKeyAndValueDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProjectConfigurationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProjectConfigurationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProjectConfigurationsRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectConfiguration> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.ProjectConfiguration>> GetProjectConfigurations(Query query = null)
        {
            var items = Context.ProjectConfigurations.AsQueryable();

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

            OnProjectConfigurationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProjectConfigurationGet(ZarenUI.Server.Models.Connector.ProjectConfiguration item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectConfiguration> GetProjectConfigurationById(int id)
        {
            var items = Context.ProjectConfigurations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProjectConfigurationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProjectConfigurationCreated(ZarenUI.Server.Models.Connector.ProjectConfiguration item);
        partial void OnAfterProjectConfigurationCreated(ZarenUI.Server.Models.Connector.ProjectConfiguration item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectConfiguration> CreateProjectConfiguration(ZarenUI.Server.Models.Connector.ProjectConfiguration projectconfiguration)
        {
            OnProjectConfigurationCreated(projectconfiguration);

            var existingItem = Context.ProjectConfigurations
                              .Where(i => i.Id == projectconfiguration.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProjectConfigurations.Add(projectconfiguration);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(projectconfiguration).State = EntityState.Detached;
                throw;
            }

            OnAfterProjectConfigurationCreated(projectconfiguration);

            return projectconfiguration;
        }

        public async Task<ZarenUI.Server.Models.Connector.ProjectConfiguration> CancelProjectConfigurationChanges(ZarenUI.Server.Models.Connector.ProjectConfiguration item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProjectConfigurationUpdated(ZarenUI.Server.Models.Connector.ProjectConfiguration item);
        partial void OnAfterProjectConfigurationUpdated(ZarenUI.Server.Models.Connector.ProjectConfiguration item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectConfiguration> UpdateProjectConfiguration(int id, ZarenUI.Server.Models.Connector.ProjectConfiguration projectconfiguration)
        {
            OnProjectConfigurationUpdated(projectconfiguration);

            var itemToUpdate = Context.ProjectConfigurations
                              .Where(i => i.Id == projectconfiguration.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(projectconfiguration);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProjectConfigurationUpdated(projectconfiguration);

            return projectconfiguration;
        }

        partial void OnProjectConfigurationDeleted(ZarenUI.Server.Models.Connector.ProjectConfiguration item);
        partial void OnAfterProjectConfigurationDeleted(ZarenUI.Server.Models.Connector.ProjectConfiguration item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectConfiguration> DeleteProjectConfiguration(int id)
        {
            var itemToDelete = Context.ProjectConfigurations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProjectConfigurationDeleted(itemToDelete);


            Context.ProjectConfigurations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProjectConfigurationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProjectFunctionGroupsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectfunctiongroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectfunctiongroups/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProjectFunctionGroupsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectfunctiongroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectfunctiongroups/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProjectFunctionGroupsRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectFunctionGroup> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.ProjectFunctionGroup>> GetProjectFunctionGroups(Query query = null)
        {
            var items = Context.ProjectFunctionGroups.AsQueryable();

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

            OnProjectFunctionGroupsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProjectFunctionGroupGet(ZarenUI.Server.Models.Connector.ProjectFunctionGroup item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectFunctionGroup> GetProjectFunctionGroupById(int id)
        {
            var items = Context.ProjectFunctionGroups
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProjectFunctionGroupGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProjectFunctionGroupCreated(ZarenUI.Server.Models.Connector.ProjectFunctionGroup item);
        partial void OnAfterProjectFunctionGroupCreated(ZarenUI.Server.Models.Connector.ProjectFunctionGroup item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectFunctionGroup> CreateProjectFunctionGroup(ZarenUI.Server.Models.Connector.ProjectFunctionGroup projectfunctiongroup)
        {
            OnProjectFunctionGroupCreated(projectfunctiongroup);

            var existingItem = Context.ProjectFunctionGroups
                              .Where(i => i.Id == projectfunctiongroup.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProjectFunctionGroups.Add(projectfunctiongroup);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(projectfunctiongroup).State = EntityState.Detached;
                throw;
            }

            OnAfterProjectFunctionGroupCreated(projectfunctiongroup);

            return projectfunctiongroup;
        }

        public async Task<ZarenUI.Server.Models.Connector.ProjectFunctionGroup> CancelProjectFunctionGroupChanges(ZarenUI.Server.Models.Connector.ProjectFunctionGroup item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProjectFunctionGroupUpdated(ZarenUI.Server.Models.Connector.ProjectFunctionGroup item);
        partial void OnAfterProjectFunctionGroupUpdated(ZarenUI.Server.Models.Connector.ProjectFunctionGroup item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectFunctionGroup> UpdateProjectFunctionGroup(int id, ZarenUI.Server.Models.Connector.ProjectFunctionGroup projectfunctiongroup)
        {
            OnProjectFunctionGroupUpdated(projectfunctiongroup);

            var itemToUpdate = Context.ProjectFunctionGroups
                              .Where(i => i.Id == projectfunctiongroup.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(projectfunctiongroup);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProjectFunctionGroupUpdated(projectfunctiongroup);

            return projectfunctiongroup;
        }

        partial void OnProjectFunctionGroupDeleted(ZarenUI.Server.Models.Connector.ProjectFunctionGroup item);
        partial void OnAfterProjectFunctionGroupDeleted(ZarenUI.Server.Models.Connector.ProjectFunctionGroup item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectFunctionGroup> DeleteProjectFunctionGroup(int id)
        {
            var itemToDelete = Context.ProjectFunctionGroups
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProjectFunctionGroupDeleted(itemToDelete);


            Context.ProjectFunctionGroups.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProjectFunctionGroupDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProjectFunctionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectfunctions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectfunctions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProjectFunctionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectfunctions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectfunctions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProjectFunctionsRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectFunction> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.ProjectFunction>> GetProjectFunctions(Query query = null)
        {
            var items = Context.ProjectFunctions.AsQueryable();

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

            OnProjectFunctionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProjectFunctionGet(ZarenUI.Server.Models.Connector.ProjectFunction item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectFunction> GetProjectFunctionById(int id)
        {
            var items = Context.ProjectFunctions
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProjectFunctionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProjectFunctionCreated(ZarenUI.Server.Models.Connector.ProjectFunction item);
        partial void OnAfterProjectFunctionCreated(ZarenUI.Server.Models.Connector.ProjectFunction item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectFunction> CreateProjectFunction(ZarenUI.Server.Models.Connector.ProjectFunction projectfunction)
        {
            OnProjectFunctionCreated(projectfunction);

            var existingItem = Context.ProjectFunctions
                              .Where(i => i.Id == projectfunction.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProjectFunctions.Add(projectfunction);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(projectfunction).State = EntityState.Detached;
                throw;
            }

            OnAfterProjectFunctionCreated(projectfunction);

            return projectfunction;
        }

        public async Task<ZarenUI.Server.Models.Connector.ProjectFunction> CancelProjectFunctionChanges(ZarenUI.Server.Models.Connector.ProjectFunction item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProjectFunctionUpdated(ZarenUI.Server.Models.Connector.ProjectFunction item);
        partial void OnAfterProjectFunctionUpdated(ZarenUI.Server.Models.Connector.ProjectFunction item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectFunction> UpdateProjectFunction(int id, ZarenUI.Server.Models.Connector.ProjectFunction projectfunction)
        {
            OnProjectFunctionUpdated(projectfunction);

            var itemToUpdate = Context.ProjectFunctions
                              .Where(i => i.Id == projectfunction.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(projectfunction);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProjectFunctionUpdated(projectfunction);

            return projectfunction;
        }

        partial void OnProjectFunctionDeleted(ZarenUI.Server.Models.Connector.ProjectFunction item);
        partial void OnAfterProjectFunctionDeleted(ZarenUI.Server.Models.Connector.ProjectFunction item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectFunction> DeleteProjectFunction(int id)
        {
            var itemToDelete = Context.ProjectFunctions
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProjectFunctionDeleted(itemToDelete);


            Context.ProjectFunctions.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProjectFunctionDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProjectPageComponentElementsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectpagecomponentelements/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectpagecomponentelements/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProjectPageComponentElementsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectpagecomponentelements/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectpagecomponentelements/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProjectPageComponentElementsRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectPageComponentElement> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.ProjectPageComponentElement>> GetProjectPageComponentElements(Query query = null)
        {
            var items = Context.ProjectPageComponentElements.AsQueryable();

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

            OnProjectPageComponentElementsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProjectPageComponentElementGet(ZarenUI.Server.Models.Connector.ProjectPageComponentElement item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPageComponentElement> GetProjectPageComponentElementById(int id)
        {
            var items = Context.ProjectPageComponentElements
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProjectPageComponentElementGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProjectPageComponentElementCreated(ZarenUI.Server.Models.Connector.ProjectPageComponentElement item);
        partial void OnAfterProjectPageComponentElementCreated(ZarenUI.Server.Models.Connector.ProjectPageComponentElement item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPageComponentElement> CreateProjectPageComponentElement(ZarenUI.Server.Models.Connector.ProjectPageComponentElement projectpagecomponentelement)
        {
            OnProjectPageComponentElementCreated(projectpagecomponentelement);

            var existingItem = Context.ProjectPageComponentElements
                              .Where(i => i.Id == projectpagecomponentelement.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProjectPageComponentElements.Add(projectpagecomponentelement);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(projectpagecomponentelement).State = EntityState.Detached;
                throw;
            }

            OnAfterProjectPageComponentElementCreated(projectpagecomponentelement);

            return projectpagecomponentelement;
        }

        public async Task<ZarenUI.Server.Models.Connector.ProjectPageComponentElement> CancelProjectPageComponentElementChanges(ZarenUI.Server.Models.Connector.ProjectPageComponentElement item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProjectPageComponentElementUpdated(ZarenUI.Server.Models.Connector.ProjectPageComponentElement item);
        partial void OnAfterProjectPageComponentElementUpdated(ZarenUI.Server.Models.Connector.ProjectPageComponentElement item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPageComponentElement> UpdateProjectPageComponentElement(int id, ZarenUI.Server.Models.Connector.ProjectPageComponentElement projectpagecomponentelement)
        {
            OnProjectPageComponentElementUpdated(projectpagecomponentelement);

            var itemToUpdate = Context.ProjectPageComponentElements
                              .Where(i => i.Id == projectpagecomponentelement.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(projectpagecomponentelement);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProjectPageComponentElementUpdated(projectpagecomponentelement);

            return projectpagecomponentelement;
        }

        partial void OnProjectPageComponentElementDeleted(ZarenUI.Server.Models.Connector.ProjectPageComponentElement item);
        partial void OnAfterProjectPageComponentElementDeleted(ZarenUI.Server.Models.Connector.ProjectPageComponentElement item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPageComponentElement> DeleteProjectPageComponentElement(int id)
        {
            var itemToDelete = Context.ProjectPageComponentElements
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProjectPageComponentElementDeleted(itemToDelete);


            Context.ProjectPageComponentElements.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProjectPageComponentElementDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProjectPageComponentsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectpagecomponents/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectpagecomponents/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProjectPageComponentsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectpagecomponents/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectpagecomponents/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProjectPageComponentsRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectPageComponent> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.ProjectPageComponent>> GetProjectPageComponents(Query query = null)
        {
            var items = Context.ProjectPageComponents.AsQueryable();

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

            OnProjectPageComponentsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProjectPageComponentGet(ZarenUI.Server.Models.Connector.ProjectPageComponent item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPageComponent> GetProjectPageComponentById(int id)
        {
            var items = Context.ProjectPageComponents
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProjectPageComponentGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProjectPageComponentCreated(ZarenUI.Server.Models.Connector.ProjectPageComponent item);
        partial void OnAfterProjectPageComponentCreated(ZarenUI.Server.Models.Connector.ProjectPageComponent item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPageComponent> CreateProjectPageComponent(ZarenUI.Server.Models.Connector.ProjectPageComponent projectpagecomponent)
        {
            OnProjectPageComponentCreated(projectpagecomponent);

            var existingItem = Context.ProjectPageComponents
                              .Where(i => i.Id == projectpagecomponent.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProjectPageComponents.Add(projectpagecomponent);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(projectpagecomponent).State = EntityState.Detached;
                throw;
            }

            OnAfterProjectPageComponentCreated(projectpagecomponent);

            return projectpagecomponent;
        }

        public async Task<ZarenUI.Server.Models.Connector.ProjectPageComponent> CancelProjectPageComponentChanges(ZarenUI.Server.Models.Connector.ProjectPageComponent item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProjectPageComponentUpdated(ZarenUI.Server.Models.Connector.ProjectPageComponent item);
        partial void OnAfterProjectPageComponentUpdated(ZarenUI.Server.Models.Connector.ProjectPageComponent item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPageComponent> UpdateProjectPageComponent(int id, ZarenUI.Server.Models.Connector.ProjectPageComponent projectpagecomponent)
        {
            OnProjectPageComponentUpdated(projectpagecomponent);

            var itemToUpdate = Context.ProjectPageComponents
                              .Where(i => i.Id == projectpagecomponent.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(projectpagecomponent);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProjectPageComponentUpdated(projectpagecomponent);

            return projectpagecomponent;
        }

        partial void OnProjectPageComponentDeleted(ZarenUI.Server.Models.Connector.ProjectPageComponent item);
        partial void OnAfterProjectPageComponentDeleted(ZarenUI.Server.Models.Connector.ProjectPageComponent item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPageComponent> DeleteProjectPageComponent(int id)
        {
            var itemToDelete = Context.ProjectPageComponents
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProjectPageComponentDeleted(itemToDelete);


            Context.ProjectPageComponents.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProjectPageComponentDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProjectPagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectpages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectpages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProjectPagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projectpages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projectpages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProjectPagesRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectPage> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.ProjectPage>> GetProjectPages(Query query = null)
        {
            var items = Context.ProjectPages.AsQueryable();

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

            OnProjectPagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProjectPageGet(ZarenUI.Server.Models.Connector.ProjectPage item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPage> GetProjectPageById(int id)
        {
            var items = Context.ProjectPages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProjectPageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProjectPageCreated(ZarenUI.Server.Models.Connector.ProjectPage item);
        partial void OnAfterProjectPageCreated(ZarenUI.Server.Models.Connector.ProjectPage item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPage> CreateProjectPage(ZarenUI.Server.Models.Connector.ProjectPage projectpage)
        {
            OnProjectPageCreated(projectpage);

            var existingItem = Context.ProjectPages
                              .Where(i => i.Id == projectpage.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProjectPages.Add(projectpage);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(projectpage).State = EntityState.Detached;
                throw;
            }

            OnAfterProjectPageCreated(projectpage);

            return projectpage;
        }

        public async Task<ZarenUI.Server.Models.Connector.ProjectPage> CancelProjectPageChanges(ZarenUI.Server.Models.Connector.ProjectPage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProjectPageUpdated(ZarenUI.Server.Models.Connector.ProjectPage item);
        partial void OnAfterProjectPageUpdated(ZarenUI.Server.Models.Connector.ProjectPage item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPage> UpdateProjectPage(int id, ZarenUI.Server.Models.Connector.ProjectPage projectpage)
        {
            OnProjectPageUpdated(projectpage);

            var itemToUpdate = Context.ProjectPages
                              .Where(i => i.Id == projectpage.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(projectpage);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProjectPageUpdated(projectpage);

            return projectpage;
        }

        partial void OnProjectPageDeleted(ZarenUI.Server.Models.Connector.ProjectPage item);
        partial void OnAfterProjectPageDeleted(ZarenUI.Server.Models.Connector.ProjectPage item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectPage> DeleteProjectPage(int id)
        {
            var itemToDelete = Context.ProjectPages
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProjectPageDeleted(itemToDelete);


            Context.ProjectPages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProjectPageDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProjectsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projects/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projects/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProjectsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projects/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projects/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProjectsRead(ref IQueryable<ZarenUI.Server.Models.Connector.Project> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.Project>> GetProjects(Query query = null)
        {
            var items = Context.Projects.AsQueryable();

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

            OnProjectsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProjectGet(ZarenUI.Server.Models.Connector.Project item);

        public async Task<ZarenUI.Server.Models.Connector.Project> GetProjectById(int id)
        {
            var items = Context.Projects
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProjectGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProjectCreated(ZarenUI.Server.Models.Connector.Project item);
        partial void OnAfterProjectCreated(ZarenUI.Server.Models.Connector.Project item);

        public async Task<ZarenUI.Server.Models.Connector.Project> CreateProject(ZarenUI.Server.Models.Connector.Project project)
        {
            OnProjectCreated(project);

            var existingItem = Context.Projects
                              .Where(i => i.Id == project.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Projects.Add(project);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(project).State = EntityState.Detached;
                throw;
            }

            OnAfterProjectCreated(project);

            return project;
        }

        public async Task<ZarenUI.Server.Models.Connector.Project> CancelProjectChanges(ZarenUI.Server.Models.Connector.Project item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProjectUpdated(ZarenUI.Server.Models.Connector.Project item);
        partial void OnAfterProjectUpdated(ZarenUI.Server.Models.Connector.Project item);

        public async Task<ZarenUI.Server.Models.Connector.Project> UpdateProject(int id, ZarenUI.Server.Models.Connector.Project project)
        {
            OnProjectUpdated(project);

            var itemToUpdate = Context.Projects
                              .Where(i => i.Id == project.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(project);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProjectUpdated(project);

            return project;
        }

        partial void OnProjectDeleted(ZarenUI.Server.Models.Connector.Project item);
        partial void OnAfterProjectDeleted(ZarenUI.Server.Models.Connector.Project item);

        public async Task<ZarenUI.Server.Models.Connector.Project> DeleteProject(int id)
        {
            var itemToDelete = Context.Projects
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProjectDeleted(itemToDelete);


            Context.Projects.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProjectDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProjectTableColumnsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projecttablecolumns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projecttablecolumns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProjectTableColumnsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projecttablecolumns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projecttablecolumns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProjectTableColumnsRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectTableColumn> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.ProjectTableColumn>> GetProjectTableColumns(Query query = null)
        {
            var items = Context.ProjectTableColumns.AsQueryable();

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

            OnProjectTableColumnsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProjectTableColumnGet(ZarenUI.Server.Models.Connector.ProjectTableColumn item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectTableColumn> GetProjectTableColumnById(int id)
        {
            var items = Context.ProjectTableColumns
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProjectTableColumnGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProjectTableColumnCreated(ZarenUI.Server.Models.Connector.ProjectTableColumn item);
        partial void OnAfterProjectTableColumnCreated(ZarenUI.Server.Models.Connector.ProjectTableColumn item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectTableColumn> CreateProjectTableColumn(ZarenUI.Server.Models.Connector.ProjectTableColumn projecttablecolumn)
        {
            OnProjectTableColumnCreated(projecttablecolumn);

            var existingItem = Context.ProjectTableColumns
                              .Where(i => i.Id == projecttablecolumn.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProjectTableColumns.Add(projecttablecolumn);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(projecttablecolumn).State = EntityState.Detached;
                throw;
            }

            OnAfterProjectTableColumnCreated(projecttablecolumn);

            return projecttablecolumn;
        }

        public async Task<ZarenUI.Server.Models.Connector.ProjectTableColumn> CancelProjectTableColumnChanges(ZarenUI.Server.Models.Connector.ProjectTableColumn item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProjectTableColumnUpdated(ZarenUI.Server.Models.Connector.ProjectTableColumn item);
        partial void OnAfterProjectTableColumnUpdated(ZarenUI.Server.Models.Connector.ProjectTableColumn item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectTableColumn> UpdateProjectTableColumn(int id, ZarenUI.Server.Models.Connector.ProjectTableColumn projecttablecolumn)
        {
            OnProjectTableColumnUpdated(projecttablecolumn);

            var itemToUpdate = Context.ProjectTableColumns
                              .Where(i => i.Id == projecttablecolumn.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(projecttablecolumn);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProjectTableColumnUpdated(projecttablecolumn);

            return projecttablecolumn;
        }

        partial void OnProjectTableColumnDeleted(ZarenUI.Server.Models.Connector.ProjectTableColumn item);
        partial void OnAfterProjectTableColumnDeleted(ZarenUI.Server.Models.Connector.ProjectTableColumn item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectTableColumn> DeleteProjectTableColumn(int id)
        {
            var itemToDelete = Context.ProjectTableColumns
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProjectTableColumnDeleted(itemToDelete);


            Context.ProjectTableColumns.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProjectTableColumnDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportProjectTablesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projecttables/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projecttables/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProjectTablesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/projecttables/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/projecttables/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProjectTablesRead(ref IQueryable<ZarenUI.Server.Models.Connector.ProjectTable> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.ProjectTable>> GetProjectTables(Query query = null)
        {
            var items = Context.ProjectTables.AsQueryable();

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

            OnProjectTablesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProjectTableGet(ZarenUI.Server.Models.Connector.ProjectTable item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectTable> GetProjectTableById(int id)
        {
            var items = Context.ProjectTables
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnProjectTableGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnProjectTableCreated(ZarenUI.Server.Models.Connector.ProjectTable item);
        partial void OnAfterProjectTableCreated(ZarenUI.Server.Models.Connector.ProjectTable item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectTable> CreateProjectTable(ZarenUI.Server.Models.Connector.ProjectTable projecttable)
        {
            OnProjectTableCreated(projecttable);

            var existingItem = Context.ProjectTables
                              .Where(i => i.Id == projecttable.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ProjectTables.Add(projecttable);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(projecttable).State = EntityState.Detached;
                throw;
            }

            OnAfterProjectTableCreated(projecttable);

            return projecttable;
        }

        public async Task<ZarenUI.Server.Models.Connector.ProjectTable> CancelProjectTableChanges(ZarenUI.Server.Models.Connector.ProjectTable item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProjectTableUpdated(ZarenUI.Server.Models.Connector.ProjectTable item);
        partial void OnAfterProjectTableUpdated(ZarenUI.Server.Models.Connector.ProjectTable item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectTable> UpdateProjectTable(int id, ZarenUI.Server.Models.Connector.ProjectTable projecttable)
        {
            OnProjectTableUpdated(projecttable);

            var itemToUpdate = Context.ProjectTables
                              .Where(i => i.Id == projecttable.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(projecttable);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterProjectTableUpdated(projecttable);

            return projecttable;
        }

        partial void OnProjectTableDeleted(ZarenUI.Server.Models.Connector.ProjectTable item);
        partial void OnAfterProjectTableDeleted(ZarenUI.Server.Models.Connector.ProjectTable item);

        public async Task<ZarenUI.Server.Models.Connector.ProjectTable> DeleteProjectTable(int id)
        {
            var itemToDelete = Context.ProjectTables
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProjectTableDeleted(itemToDelete);


            Context.ProjectTables.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProjectTableDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportReferenceWebSitesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/referencewebsites/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/referencewebsites/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportReferenceWebSitesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/referencewebsites/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/referencewebsites/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnReferenceWebSitesRead(ref IQueryable<ZarenUI.Server.Models.Connector.ReferenceWebSite> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.ReferenceWebSite>> GetReferenceWebSites(Query query = null)
        {
            var items = Context.ReferenceWebSites.AsQueryable();

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

            OnReferenceWebSitesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnReferenceWebSiteGet(ZarenUI.Server.Models.Connector.ReferenceWebSite item);

        public async Task<ZarenUI.Server.Models.Connector.ReferenceWebSite> GetReferenceWebSiteById(int id)
        {
            var items = Context.ReferenceWebSites
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnReferenceWebSiteGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnReferenceWebSiteCreated(ZarenUI.Server.Models.Connector.ReferenceWebSite item);
        partial void OnAfterReferenceWebSiteCreated(ZarenUI.Server.Models.Connector.ReferenceWebSite item);

        public async Task<ZarenUI.Server.Models.Connector.ReferenceWebSite> CreateReferenceWebSite(ZarenUI.Server.Models.Connector.ReferenceWebSite referencewebsite)
        {
            OnReferenceWebSiteCreated(referencewebsite);

            var existingItem = Context.ReferenceWebSites
                              .Where(i => i.Id == referencewebsite.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ReferenceWebSites.Add(referencewebsite);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(referencewebsite).State = EntityState.Detached;
                throw;
            }

            OnAfterReferenceWebSiteCreated(referencewebsite);

            return referencewebsite;
        }

        public async Task<ZarenUI.Server.Models.Connector.ReferenceWebSite> CancelReferenceWebSiteChanges(ZarenUI.Server.Models.Connector.ReferenceWebSite item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnReferenceWebSiteUpdated(ZarenUI.Server.Models.Connector.ReferenceWebSite item);
        partial void OnAfterReferenceWebSiteUpdated(ZarenUI.Server.Models.Connector.ReferenceWebSite item);

        public async Task<ZarenUI.Server.Models.Connector.ReferenceWebSite> UpdateReferenceWebSite(int id, ZarenUI.Server.Models.Connector.ReferenceWebSite referencewebsite)
        {
            OnReferenceWebSiteUpdated(referencewebsite);

            var itemToUpdate = Context.ReferenceWebSites
                              .Where(i => i.Id == referencewebsite.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(referencewebsite);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterReferenceWebSiteUpdated(referencewebsite);

            return referencewebsite;
        }

        partial void OnReferenceWebSiteDeleted(ZarenUI.Server.Models.Connector.ReferenceWebSite item);
        partial void OnAfterReferenceWebSiteDeleted(ZarenUI.Server.Models.Connector.ReferenceWebSite item);

        public async Task<ZarenUI.Server.Models.Connector.ReferenceWebSite> DeleteReferenceWebSite(int id)
        {
            var itemToDelete = Context.ReferenceWebSites
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnReferenceWebSiteDeleted(itemToDelete);


            Context.ReferenceWebSites.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterReferenceWebSiteDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSchemesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/schemes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/schemes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSchemesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/schemes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/schemes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSchemesRead(ref IQueryable<ZarenUI.Server.Models.Connector.Scheme> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.Scheme>> GetSchemes(Query query = null)
        {
            var items = Context.Schemes.AsQueryable();

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

            OnSchemesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSchemeGet(ZarenUI.Server.Models.Connector.Scheme item);

        public async Task<ZarenUI.Server.Models.Connector.Scheme> GetSchemeById(int id)
        {
            var items = Context.Schemes
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnSchemeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSchemeCreated(ZarenUI.Server.Models.Connector.Scheme item);
        partial void OnAfterSchemeCreated(ZarenUI.Server.Models.Connector.Scheme item);

        public async Task<ZarenUI.Server.Models.Connector.Scheme> CreateScheme(ZarenUI.Server.Models.Connector.Scheme scheme)
        {
            OnSchemeCreated(scheme);

            var existingItem = Context.Schemes
                              .Where(i => i.Id == scheme.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Schemes.Add(scheme);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(scheme).State = EntityState.Detached;
                throw;
            }

            OnAfterSchemeCreated(scheme);

            return scheme;
        }

        public async Task<ZarenUI.Server.Models.Connector.Scheme> CancelSchemeChanges(ZarenUI.Server.Models.Connector.Scheme item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSchemeUpdated(ZarenUI.Server.Models.Connector.Scheme item);
        partial void OnAfterSchemeUpdated(ZarenUI.Server.Models.Connector.Scheme item);

        public async Task<ZarenUI.Server.Models.Connector.Scheme> UpdateScheme(int id, ZarenUI.Server.Models.Connector.Scheme scheme)
        {
            OnSchemeUpdated(scheme);

            var itemToUpdate = Context.Schemes
                              .Where(i => i.Id == scheme.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(scheme);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSchemeUpdated(scheme);

            return scheme;
        }

        partial void OnSchemeDeleted(ZarenUI.Server.Models.Connector.Scheme item);
        partial void OnAfterSchemeDeleted(ZarenUI.Server.Models.Connector.Scheme item);

        public async Task<ZarenUI.Server.Models.Connector.Scheme> DeleteScheme(int id)
        {
            var itemToDelete = Context.Schemes
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSchemeDeleted(itemToDelete);


            Context.Schemes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSchemeDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTablesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/tables/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/tables/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTablesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/tables/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/tables/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTablesRead(ref IQueryable<ZarenUI.Server.Models.Connector.Table> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.Table>> GetTables(Query query = null)
        {
            var items = Context.Tables.AsQueryable();

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

            OnTablesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTableGet(ZarenUI.Server.Models.Connector.Table item);

        public async Task<ZarenUI.Server.Models.Connector.Table> GetTableById(int id)
        {
            var items = Context.Tables
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnTableGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTableCreated(ZarenUI.Server.Models.Connector.Table item);
        partial void OnAfterTableCreated(ZarenUI.Server.Models.Connector.Table item);

        public async Task<ZarenUI.Server.Models.Connector.Table> CreateTable(ZarenUI.Server.Models.Connector.Table table)
        {
            OnTableCreated(table);

            var existingItem = Context.Tables
                              .Where(i => i.Id == table.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Tables.Add(table);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(table).State = EntityState.Detached;
                throw;
            }

            OnAfterTableCreated(table);

            return table;
        }

        public async Task<ZarenUI.Server.Models.Connector.Table> CancelTableChanges(ZarenUI.Server.Models.Connector.Table item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTableUpdated(ZarenUI.Server.Models.Connector.Table item);
        partial void OnAfterTableUpdated(ZarenUI.Server.Models.Connector.Table item);

        public async Task<ZarenUI.Server.Models.Connector.Table> UpdateTable(int id, ZarenUI.Server.Models.Connector.Table table)
        {
            OnTableUpdated(table);

            var itemToUpdate = Context.Tables
                              .Where(i => i.Id == table.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(table);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTableUpdated(table);

            return table;
        }

        partial void OnTableDeleted(ZarenUI.Server.Models.Connector.Table item);
        partial void OnAfterTableDeleted(ZarenUI.Server.Models.Connector.Table item);

        public async Task<ZarenUI.Server.Models.Connector.Table> DeleteTable(int id)
        {
            var itemToDelete = Context.Tables
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTableDeleted(itemToDelete);


            Context.Tables.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTableDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportDesignSchemesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/designschemes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/designschemes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDesignSchemesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/connector/designschemes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/connector/designschemes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDesignSchemesRead(ref IQueryable<ZarenUI.Server.Models.Connector.DesignScheme> items);

        public async Task<IQueryable<ZarenUI.Server.Models.Connector.DesignScheme>> GetDesignSchemes(Query query = null)
        {
            var items = Context.DesignSchemes.AsQueryable();

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

            OnDesignSchemesRead(ref items);

            return await Task.FromResult(items);
        }
    }
}