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

using Payzee.Data;

namespace Payzee
{
    public partial class Payment3Service
    {
        Payment3Context Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly Payment3Context context;
        private readonly NavigationManager navigationManager;

        public Payment3Service(Payment3Context context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);


        public async Task ExportCurrenciesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/payment3/currencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/payment3/currencies/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCurrenciesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/payment3/currencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/payment3/currencies/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCurrenciesRead(ref IQueryable<Payzee.Models.Payment3.Currency> items);

        public async Task<IQueryable<Payzee.Models.Payment3.Currency>> GetCurrencies(Query query = null)
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

        partial void OnCurrencyGet(Payzee.Models.Payment3.Currency item);

        public async Task<Payzee.Models.Payment3.Currency> GetCurrencyById(int id)
        {
            var items = Context.Currencies
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnCurrencyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCurrencyCreated(Payzee.Models.Payment3.Currency item);
        partial void OnAfterCurrencyCreated(Payzee.Models.Payment3.Currency item);

        public async Task<Payzee.Models.Payment3.Currency> CreateCurrency(Payzee.Models.Payment3.Currency currency)
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

        public async Task<Payzee.Models.Payment3.Currency> CancelCurrencyChanges(Payzee.Models.Payment3.Currency item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCurrencyUpdated(Payzee.Models.Payment3.Currency item);
        partial void OnAfterCurrencyUpdated(Payzee.Models.Payment3.Currency item);

        public async Task<Payzee.Models.Payment3.Currency> UpdateCurrency(int id, Payzee.Models.Payment3.Currency currency)
        {
            OnCurrencyUpdated(currency);

            var itemToUpdate = Context.Currencies
                              .Where(i => i.Id == currency.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(currency);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCurrencyUpdated(currency);

            return currency;
        }

        partial void OnCurrencyDeleted(Payzee.Models.Payment3.Currency item);
        partial void OnAfterCurrencyDeleted(Payzee.Models.Payment3.Currency item);

        public async Task<Payzee.Models.Payment3.Currency> DeleteCurrency(int id)
        {
            var itemToDelete = Context.Currencies
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCurrencyDeleted(itemToDelete);


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
    
        public async Task ExportLanguagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/payment3/languages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/payment3/languages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLanguagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/payment3/languages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/payment3/languages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLanguagesRead(ref IQueryable<Payzee.Models.Payment3.Language> items);

        public async Task<IQueryable<Payzee.Models.Payment3.Language>> GetLanguages(Query query = null)
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

        partial void OnLanguageGet(Payzee.Models.Payment3.Language item);

        public async Task<Payzee.Models.Payment3.Language> GetLanguageById(int id)
        {
            var items = Context.Languages
                              .AsNoTracking()
                              .Where(i => i.Id == id);

  
            var itemToReturn = items.FirstOrDefault();

            OnLanguageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnLanguageCreated(Payzee.Models.Payment3.Language item);
        partial void OnAfterLanguageCreated(Payzee.Models.Payment3.Language item);

        public async Task<Payzee.Models.Payment3.Language> CreateLanguage(Payzee.Models.Payment3.Language language)
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

        public async Task<Payzee.Models.Payment3.Language> CancelLanguageChanges(Payzee.Models.Payment3.Language item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLanguageUpdated(Payzee.Models.Payment3.Language item);
        partial void OnAfterLanguageUpdated(Payzee.Models.Payment3.Language item);

        public async Task<Payzee.Models.Payment3.Language> UpdateLanguage(int id, Payzee.Models.Payment3.Language language)
        {
            OnLanguageUpdated(language);

            var itemToUpdate = Context.Languages
                              .Where(i => i.Id == language.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(language);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterLanguageUpdated(language);

            return language;
        }

        partial void OnLanguageDeleted(Payzee.Models.Payment3.Language item);
        partial void OnAfterLanguageDeleted(Payzee.Models.Payment3.Language item);

        public async Task<Payzee.Models.Payment3.Language> DeleteLanguage(int id)
        {
            var itemToDelete = Context.Languages
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLanguageDeleted(itemToDelete);


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
    
        public async Task ExportPaymentConfigurationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/payment3/paymentconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/payment3/paymentconfigurations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPaymentConfigurationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/payment3/paymentconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/payment3/paymentconfigurations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPaymentConfigurationsRead(ref IQueryable<Payzee.Models.Payment3.PaymentConfiguration> items);

        public async Task<IQueryable<Payzee.Models.Payment3.PaymentConfiguration>> GetPaymentConfigurations(Query query = null)
        {
            var items = Context.PaymentConfigurations.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPaymentConfigurationsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPaymentConfigurationGet(Payzee.Models.Payment3.PaymentConfiguration item);

        public async Task<Payzee.Models.Payment3.PaymentConfiguration> GetPaymentConfigurationById(int id)
        {
            var items = Context.PaymentConfigurations
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Language1);
  
            var itemToReturn = items.FirstOrDefault();

            OnPaymentConfigurationGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPaymentConfigurationCreated(Payzee.Models.Payment3.PaymentConfiguration item);
        partial void OnAfterPaymentConfigurationCreated(Payzee.Models.Payment3.PaymentConfiguration item);

        public async Task<Payzee.Models.Payment3.PaymentConfiguration> CreatePaymentConfiguration(Payzee.Models.Payment3.PaymentConfiguration paymentconfiguration)
        {
            OnPaymentConfigurationCreated(paymentconfiguration);

            var existingItem = Context.PaymentConfigurations
                              .Where(i => i.Id == paymentconfiguration.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PaymentConfigurations.Add(paymentconfiguration);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(paymentconfiguration).State = EntityState.Detached;
                throw;
            }

            OnAfterPaymentConfigurationCreated(paymentconfiguration);

            return paymentconfiguration;
        }

        public async Task<Payzee.Models.Payment3.PaymentConfiguration> CancelPaymentConfigurationChanges(Payzee.Models.Payment3.PaymentConfiguration item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPaymentConfigurationUpdated(Payzee.Models.Payment3.PaymentConfiguration item);
        partial void OnAfterPaymentConfigurationUpdated(Payzee.Models.Payment3.PaymentConfiguration item);

        public async Task<Payzee.Models.Payment3.PaymentConfiguration> UpdatePaymentConfiguration(int id, Payzee.Models.Payment3.PaymentConfiguration paymentconfiguration)
        {
            OnPaymentConfigurationUpdated(paymentconfiguration);

            var itemToUpdate = Context.PaymentConfigurations
                              .Where(i => i.Id == paymentconfiguration.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(paymentconfiguration);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPaymentConfigurationUpdated(paymentconfiguration);

            return paymentconfiguration;
        }

        partial void OnPaymentConfigurationDeleted(Payzee.Models.Payment3.PaymentConfiguration item);
        partial void OnAfterPaymentConfigurationDeleted(Payzee.Models.Payment3.PaymentConfiguration item);

        public async Task<Payzee.Models.Payment3.PaymentConfiguration> DeletePaymentConfiguration(int id)
        {
            var itemToDelete = Context.PaymentConfigurations
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPaymentConfigurationDeleted(itemToDelete);


            Context.PaymentConfigurations.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPaymentConfigurationDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportPaymentLogsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/payment3/paymentlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/payment3/paymentlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPaymentLogsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/payment3/paymentlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/payment3/paymentlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPaymentLogsRead(ref IQueryable<Payzee.Models.Payment3.PaymentLog> items);

        public async Task<IQueryable<Payzee.Models.Payment3.PaymentLog>> GetPaymentLogs(Query query = null)
        {
            var items = Context.PaymentLogs.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPaymentLogsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPaymentLogGet(Payzee.Models.Payment3.PaymentLog item);

        public async Task<Payzee.Models.Payment3.PaymentLog> GetPaymentLogById(int id)
        {
            var items = Context.PaymentLogs
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Transaction);
  
            var itemToReturn = items.FirstOrDefault();

            OnPaymentLogGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPaymentLogCreated(Payzee.Models.Payment3.PaymentLog item);
        partial void OnAfterPaymentLogCreated(Payzee.Models.Payment3.PaymentLog item);

        public async Task<Payzee.Models.Payment3.PaymentLog> CreatePaymentLog(Payzee.Models.Payment3.PaymentLog paymentlog)
        {
            OnPaymentLogCreated(paymentlog);

            var existingItem = Context.PaymentLogs
                              .Where(i => i.Id == paymentlog.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PaymentLogs.Add(paymentlog);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(paymentlog).State = EntityState.Detached;
                throw;
            }

            OnAfterPaymentLogCreated(paymentlog);

            return paymentlog;
        }

        public async Task<Payzee.Models.Payment3.PaymentLog> CancelPaymentLogChanges(Payzee.Models.Payment3.PaymentLog item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPaymentLogUpdated(Payzee.Models.Payment3.PaymentLog item);
        partial void OnAfterPaymentLogUpdated(Payzee.Models.Payment3.PaymentLog item);

        public async Task<Payzee.Models.Payment3.PaymentLog> UpdatePaymentLog(int id, Payzee.Models.Payment3.PaymentLog paymentlog)
        {
            OnPaymentLogUpdated(paymentlog);

            var itemToUpdate = Context.PaymentLogs
                              .Where(i => i.Id == paymentlog.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(paymentlog);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPaymentLogUpdated(paymentlog);

            return paymentlog;
        }

        partial void OnPaymentLogDeleted(Payzee.Models.Payment3.PaymentLog item);
        partial void OnAfterPaymentLogDeleted(Payzee.Models.Payment3.PaymentLog item);

        public async Task<Payzee.Models.Payment3.PaymentLog> DeletePaymentLog(int id)
        {
            var itemToDelete = Context.PaymentLogs
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPaymentLogDeleted(itemToDelete);


            Context.PaymentLogs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPaymentLogDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportResourcesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/payment3/resources/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/payment3/resources/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportResourcesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/payment3/resources/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/payment3/resources/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnResourcesRead(ref IQueryable<Payzee.Models.Payment3.Resource> items);

        public async Task<IQueryable<Payzee.Models.Payment3.Resource>> GetResources(Query query = null)
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

        partial void OnResourceGet(Payzee.Models.Payment3.Resource item);

        public async Task<Payzee.Models.Payment3.Resource> GetResourceById(int id)
        {
            var items = Context.Resources
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Language);
  
            var itemToReturn = items.FirstOrDefault();

            OnResourceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnResourceCreated(Payzee.Models.Payment3.Resource item);
        partial void OnAfterResourceCreated(Payzee.Models.Payment3.Resource item);

        public async Task<Payzee.Models.Payment3.Resource> CreateResource(Payzee.Models.Payment3.Resource resource)
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

        public async Task<Payzee.Models.Payment3.Resource> CancelResourceChanges(Payzee.Models.Payment3.Resource item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnResourceUpdated(Payzee.Models.Payment3.Resource item);
        partial void OnAfterResourceUpdated(Payzee.Models.Payment3.Resource item);

        public async Task<Payzee.Models.Payment3.Resource> UpdateResource(int id, Payzee.Models.Payment3.Resource resource)
        {
            OnResourceUpdated(resource);

            var itemToUpdate = Context.Resources
                              .Where(i => i.Id == resource.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(resource);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterResourceUpdated(resource);

            return resource;
        }

        partial void OnResourceDeleted(Payzee.Models.Payment3.Resource item);
        partial void OnAfterResourceDeleted(Payzee.Models.Payment3.Resource item);

        public async Task<Payzee.Models.Payment3.Resource> DeleteResource(int id)
        {
            var itemToDelete = Context.Resources
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnResourceDeleted(itemToDelete);


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
    
        public async Task ExportTestCardsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/payment3/testcards/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/payment3/testcards/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTestCardsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/payment3/testcards/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/payment3/testcards/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTestCardsRead(ref IQueryable<Payzee.Models.Payment3.TestCard> items);

        public async Task<IQueryable<Payzee.Models.Payment3.TestCard>> GetTestCards(Query query = null)
        {
            var items = Context.TestCards.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTestCardsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTestCardGet(Payzee.Models.Payment3.TestCard item);

        public async Task<Payzee.Models.Payment3.TestCard> GetTestCardById(int id)
        {
            var items = Context.TestCards
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.PaymentConfiguration);
  
            var itemToReturn = items.FirstOrDefault();

            OnTestCardGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTestCardCreated(Payzee.Models.Payment3.TestCard item);
        partial void OnAfterTestCardCreated(Payzee.Models.Payment3.TestCard item);

        public async Task<Payzee.Models.Payment3.TestCard> CreateTestCard(Payzee.Models.Payment3.TestCard testcard)
        {
            OnTestCardCreated(testcard);

            var existingItem = Context.TestCards
                              .Where(i => i.Id == testcard.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TestCards.Add(testcard);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(testcard).State = EntityState.Detached;
                throw;
            }

            OnAfterTestCardCreated(testcard);

            return testcard;
        }

        public async Task<Payzee.Models.Payment3.TestCard> CancelTestCardChanges(Payzee.Models.Payment3.TestCard item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTestCardUpdated(Payzee.Models.Payment3.TestCard item);
        partial void OnAfterTestCardUpdated(Payzee.Models.Payment3.TestCard item);

        public async Task<Payzee.Models.Payment3.TestCard> UpdateTestCard(int id, Payzee.Models.Payment3.TestCard testcard)
        {
            OnTestCardUpdated(testcard);

            var itemToUpdate = Context.TestCards
                              .Where(i => i.Id == testcard.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(testcard);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTestCardUpdated(testcard);

            return testcard;
        }

        partial void OnTestCardDeleted(Payzee.Models.Payment3.TestCard item);
        partial void OnAfterTestCardDeleted(Payzee.Models.Payment3.TestCard item);

        public async Task<Payzee.Models.Payment3.TestCard> DeleteTestCard(int id)
        {
            var itemToDelete = Context.TestCards
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTestCardDeleted(itemToDelete);


            Context.TestCards.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTestCardDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTransactionDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/payment3/transactiondetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/payment3/transactiondetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTransactionDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/payment3/transactiondetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/payment3/transactiondetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTransactionDetailsRead(ref IQueryable<Payzee.Models.Payment3.TransactionDetail> items);

        public async Task<IQueryable<Payzee.Models.Payment3.TransactionDetail>> GetTransactionDetails(Query query = null)
        {
            var items = Context.TransactionDetails.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTransactionDetailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTransactionDetailGet(Payzee.Models.Payment3.TransactionDetail item);

        public async Task<Payzee.Models.Payment3.TransactionDetail> GetTransactionDetailById(int id)
        {
            var items = Context.TransactionDetails
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Transaction);
  
            var itemToReturn = items.FirstOrDefault();

            OnTransactionDetailGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTransactionDetailCreated(Payzee.Models.Payment3.TransactionDetail item);
        partial void OnAfterTransactionDetailCreated(Payzee.Models.Payment3.TransactionDetail item);

        public async Task<Payzee.Models.Payment3.TransactionDetail> CreateTransactionDetail(Payzee.Models.Payment3.TransactionDetail transactiondetail)
        {
            OnTransactionDetailCreated(transactiondetail);

            var existingItem = Context.TransactionDetails
                              .Where(i => i.Id == transactiondetail.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TransactionDetails.Add(transactiondetail);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(transactiondetail).State = EntityState.Detached;
                throw;
            }

            OnAfterTransactionDetailCreated(transactiondetail);

            return transactiondetail;
        }

        public async Task<Payzee.Models.Payment3.TransactionDetail> CancelTransactionDetailChanges(Payzee.Models.Payment3.TransactionDetail item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTransactionDetailUpdated(Payzee.Models.Payment3.TransactionDetail item);
        partial void OnAfterTransactionDetailUpdated(Payzee.Models.Payment3.TransactionDetail item);

        public async Task<Payzee.Models.Payment3.TransactionDetail> UpdateTransactionDetail(int id, Payzee.Models.Payment3.TransactionDetail transactiondetail)
        {
            OnTransactionDetailUpdated(transactiondetail);

            var itemToUpdate = Context.TransactionDetails
                              .Where(i => i.Id == transactiondetail.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(transactiondetail);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTransactionDetailUpdated(transactiondetail);

            return transactiondetail;
        }

        partial void OnTransactionDetailDeleted(Payzee.Models.Payment3.TransactionDetail item);
        partial void OnAfterTransactionDetailDeleted(Payzee.Models.Payment3.TransactionDetail item);

        public async Task<Payzee.Models.Payment3.TransactionDetail> DeleteTransactionDetail(int id)
        {
            var itemToDelete = Context.TransactionDetails
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTransactionDetailDeleted(itemToDelete);


            Context.TransactionDetails.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTransactionDetailDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportTransactionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/payment3/transactions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/payment3/transactions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTransactionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/payment3/transactions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/payment3/transactions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTransactionsRead(ref IQueryable<Payzee.Models.Payment3.Transaction> items);

        public async Task<IQueryable<Payzee.Models.Payment3.Transaction>> GetTransactions(Query query = null)
        {
            var items = Context.Transactions.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTransactionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTransactionGet(Payzee.Models.Payment3.Transaction item);

        public async Task<Payzee.Models.Payment3.Transaction> GetTransactionById(int id)
        {
            var items = Context.Transactions
                              .AsNoTracking()
                              .Where(i => i.Id == id);

                items = items.Include(i => i.Currency1);
                items = items.Include(i => i.Language1);
                items = items.Include(i => i.PaymentConfiguration);
  
            var itemToReturn = items.FirstOrDefault();

            OnTransactionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnTransactionCreated(Payzee.Models.Payment3.Transaction item);
        partial void OnAfterTransactionCreated(Payzee.Models.Payment3.Transaction item);

        public async Task<Payzee.Models.Payment3.Transaction> CreateTransaction(Payzee.Models.Payment3.Transaction transaction)
        {
            OnTransactionCreated(transaction);

            var existingItem = Context.Transactions
                              .Where(i => i.Id == transaction.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Transactions.Add(transaction);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(transaction).State = EntityState.Detached;
                throw;
            }

            OnAfterTransactionCreated(transaction);

            return transaction;
        }

        public async Task<Payzee.Models.Payment3.Transaction> CancelTransactionChanges(Payzee.Models.Payment3.Transaction item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTransactionUpdated(Payzee.Models.Payment3.Transaction item);
        partial void OnAfterTransactionUpdated(Payzee.Models.Payment3.Transaction item);

        public async Task<Payzee.Models.Payment3.Transaction> UpdateTransaction(int id, Payzee.Models.Payment3.Transaction transaction)
        {
            OnTransactionUpdated(transaction);

            var itemToUpdate = Context.Transactions
                              .Where(i => i.Id == transaction.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(transaction);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterTransactionUpdated(transaction);

            return transaction;
        }

        partial void OnTransactionDeleted(Payzee.Models.Payment3.Transaction item);
        partial void OnAfterTransactionDeleted(Payzee.Models.Payment3.Transaction item);

        public async Task<Payzee.Models.Payment3.Transaction> DeleteTransaction(int id)
        {
            var itemToDelete = Context.Transactions
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTransactionDeleted(itemToDelete);


            Context.Transactions.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTransactionDeleted(itemToDelete);

            return itemToDelete;
        }
        }
}